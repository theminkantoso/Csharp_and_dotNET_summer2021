using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this._repo = repo;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        // GET: LeaveTypesController
        public async Task<ActionResult> Index()
        {
            //var leavetypes = await _repo.FindAll();
            var leavetypes = await _unitOfWork.LeaveTypes.FindAll();
            // map between the two from the leavetype object
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeViewModel>>(leavetypes.ToList());
            return View(model);
        }

        // GET: LeaveTypesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            //var isExists = await _repo.isExists(id);
            var isExists = await _unitOfWork.LeaveTypes.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            //var leaveType = await _repo.FindById(id);
            var leaveType = await _unitOfWork.LeaveTypes.Find(q => q.Id == id);
            var model = _mapper.Map<LeaveTypeViewModel>(leaveType);
            return View(model);
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                // map object model to LeaveType datatype then store in leaveType
                var leaveType = _mapper.Map<LeaveType>(model);
                leaveType.DateCreated = DateTime.Now;
                //var isSuccess = await _repo.Create(leaveType);
                //if(!isSuccess)
                //{
                //    ModelState.AddModelError("", "Something went wrong...");
                //    return View(model);
                //}
                await _unitOfWork.LeaveTypes.Create(leaveType);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(model);
            }
        }

        // GET: LeaveTypesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //var isExists = await _repo.isExists(id);
            //if (!isExists)
            //{
            //    return NotFound();
            //}
            //var leaveType = await _repo.FindById(id);
            //var model = _mapper.Map<LeaveTypeViewModel>(leaveType); // mapping (like converting to DTO)
            //return View(model);
            //var isExists = await _repo.isExists(id);
            var isExists = await _unitOfWork.LeaveTypes.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            //var leaveType = await _repo.FindById(id);
            var leaveType = await _unitOfWork.LeaveTypes.Find(q => q.Id == id);
            var model = _mapper.Map<LeaveTypeViewModel>(leaveType);
            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leaveType = _mapper.Map<LeaveType>(model);
                _unitOfWork.LeaveTypes.Update(leaveType);
                await _unitOfWork.Save();
                //var isSuccess = await _repo.Update(leaveType);
                //if (!isSuccess)
                //{
                //    ModelState.AddModelError("", "Something went wrong...");
                //    return View(model);
                //}
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(model);
            }
        }

        // GET: LeaveTypesController/Delete/5
        //public async Task<ActionResult> Delete(int id)
        //{

        //    //var leaveType = await _repo.FindById(id);
        //    var leaveType = await _unitOfWork.LeaveTypes.Find(expression: q => q.Id == id);
        //    if (leaveType == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.LeaveTypes.Delete(leaveType);
        //    await _unitOfWork.Save();
        //    //var isSuccess = await _repo.Delete(leaveType);
        //    //if (!isSuccess)
        //    //{
        //    //    return BadRequest();
        //    //}
        //    return RedirectToAction(nameof(Index));
        //}

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var leaveType = await _unitOfWork.LeaveTypes.Find(expression: q => q.Id == id);
                if (leaveType == null)
                {
                    return NotFound();
                }
                _unitOfWork.LeaveTypes.Delete(leaveType);
                await _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }
        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
