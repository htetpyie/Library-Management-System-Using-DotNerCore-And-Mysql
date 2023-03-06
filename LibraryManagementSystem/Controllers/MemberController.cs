using LMS.Data.ViewModels;
using LMS.Service.Interfaces;
using LMS.Web.Constants;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _iMemberService;
        private readonly Message _message = new Message();
        private const string Message = "Message";

        public MemberController(IMemberService memberService)
        {
            _iMemberService = memberService;
        }

        // Index
        public IActionResult Index()
        {
            return View();
        }

        // Member Data Table
        public async Task<IActionResult> MemberDataTable()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();

                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();

                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                // Sort Column Name  
                //var sortColumn = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all User data  
                var roleList = await _iMemberService.GetAllMember(sortColumn, sortColumnDirection, searchValue, skip, pageSize);

                //total number of rows count   
                recordsTotal = roleList.Count();
                //Paging   
                var data = roleList.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Create Member
        public IActionResult CreateMember()
        {
            return View();
        }

        // Save Member
        [HttpPost]
        public async Task<IActionResult> SaveMember(MemberVM memberVM)
        {
            int loginUserId = 1;

            if (memberVM == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            bool isSaved = await _iMemberService.SaveMember(memberVM, loginUserId);
            if (isSaved)
            {
                TempData[Message] = _message.MemberSaveSuccess;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData[Message] = _message.MemberSaveError;
                return RedirectToAction(nameof(CreateMember));
            }
        }

        // View Member
        public async Task<IActionResult> ViewMember(int Id)
        {
            MemberVM memberVm = await _iMemberService.GetMemberById(Id);
            if (memberVm == null)
            {
                TempData[Message] = _message.MemberNotFound;
                return NotFound();
            }
            return View(memberVm);
        }

        // Edit Member
        public async Task<IActionResult> EditMember(int Id)
        {

            MemberVM memberVm = await _iMemberService.GetMemberById(Id);
            if (memberVm == null)
            {
                TempData[Message] = _message.MemberNotFound;
                return NotFound();
            }
            return View(memberVm);
        }

        // Update Member
        public async Task<IActionResult> UpdateMember(MemberVM memberVm)
        {
            int loginUserId = 1;
            if (memberVm == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            bool isUpdated = await _iMemberService.UpdateMember(memberVm, loginUserId);
            if (isUpdated)
            {
                TempData[Message] = _message.MemberUpdateSuccess;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData[Message] = _message.MemberUpdateError;
                return RedirectToAction(nameof(EditMember));
            }
        }

        // Delete Member
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteMember(int Id)
        {
            int loginUserId = 1;
            bool isDeleted = await _iMemberService.DeleteMember(Id, loginUserId);
            if (isDeleted)
            {
                TempData[Message] = _message.MemberDeleteSuccess;
            }
            else
            {
                TempData[Message] = _message.MemberDeleteError;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
