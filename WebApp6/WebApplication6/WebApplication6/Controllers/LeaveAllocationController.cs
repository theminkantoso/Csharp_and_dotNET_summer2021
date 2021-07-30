using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Contracts;
using WebApplication6.Data;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveAllocationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        public LeaveAllocationController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<Employee> userManager)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._userManager = userManager;
        }
        // GET: LeaveAllocationController
        public async Task<ActionResult> Index()
        {
            //var leavetypes = await _typerepo.FindAll();
            var leavetypes = await _unitOfWork.LeaveTypes.FindAll();
            // map between the two from the leavetype object
            var mappedLeaveTypes = _mapper.Map<List<LeaveType>, List<LeaveTypeViewModel>>(leavetypes.ToList());
            // passing view model, creating an instance of this view model, giving default value come from DB
            var model = new CreateLeaveAllocationViewModel
            {
                LeaveTypes = mappedLeaveTypes,
                NumberUpdated = 0
            };
            return View(model);
        }

        public async Task<ActionResult> SetLeave(int id)
        {
            // get all leave types
            var leaveType = await _unitOfWork.LeaveTypes.Find(q => q.Id == id);
            // get all employees
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            // creating leave allocation
            var period = DateTime.Now.Year;
            foreach (var emp in employees)
            {
                // if already exists then we dont create a duplicate one
                if(await _unitOfWork.LeaveAllocations.isExists(q => q.EmployeeId == emp.Id 
                                                                && q.LeaveTypeId == id 
                                                                && q.Period == period))
                {
                    continue;
                }
                var allocation = new LeaveAllocationViewModel
                {
                    DateCreated = DateTime.Now, 
                    EmployeeId = emp.Id,
                    LeaveTypeId = id,
                    NumberOfDays = leaveType.DefaultDays,
                    Period = DateTime.Now.Year,
                };
                var leaveAllocation = _mapper.Map<LeaveAllocation>(allocation);
                //await _allocationrepo.Create(leaveAllocation);
                await _unitOfWork.LeaveAllocations.Create(leaveAllocation);
                await _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> ListEmployees()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            var model = _mapper.Map<List<EmployeeViewModel>>(employees);
            return View(model);
        }
        // GET: LeaveAllocationController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            // mapping one instance of the object to one instance to be returned
            var employee = _mapper.Map<EmployeeViewModel>(await _userManager.FindByIdAsync(id));
            // a list and mapping back to the view model
            //var allocations = _mapper.Map<List<LeaveAllocationViewModel>>(await _allocationrepo.GetLeaveAllocationsByEmployee(id));
            var period = DateTime.Now.Year;
            var records = await _unitOfWork.LeaveAllocations.FindAll(
                expression: q => q.EmployeeId == id && q.Period == period,
                includes: q => q.Include(x => x.LeaveType)
            );

            var allocations = _mapper.Map<List<LeaveAllocationViewModel>>
                    (records);

            var model = new ViewAllocationViewModel
            {
                Employee = employee,
                LeaveAllocations = allocations
            };
            return View(model);
        }

        // GET: LeaveAllocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveAllocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //var leaveAllocation = await _allocationrepo.FindById(id);
            var leaveAllocation = await _unitOfWork.LeaveAllocations.Find(q => q.Id == id,
                includes: q => q.Include(x => x.Employee).Include(x => x.LeaveType));
            var model = _mapper.Map<EditLeaveAllocationViewModel>(leaveAllocation);
            return View(model);
        }

        // POST: LeaveAllocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditLeaveAllocationViewModel model)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(model);
                }
                //var record = await _allocationrepo.FindById(model.Id);
                //record.NumberOfDays = model.NumbeOfDays;
                //var isSuccess = await _allocationrepo.Update(record);
                //if(!isSuccess)
                //{
                //    ModelState.AddModelError("", "Error while saving");
                //    return View(model);
                //}
                //var record = await _leaveallocationrepo.FindById(model.Id);
                var record = await _unitOfWork.LeaveAllocations.Find(q => q.Id == model.Id);
                record.NumberOfDays = model.NumberOfDays;
                _unitOfWork.LeaveAllocations.Update(record);
                await _unitOfWork.Save();
                return RedirectToAction(nameof(Details), new { id = model.EmployeeId });
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveAllocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
