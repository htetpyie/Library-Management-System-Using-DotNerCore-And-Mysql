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

        // Create Member
        public IActionResult CreateMember()
        {
            return View();
        }

        // Save Member
        [HttpPost]
        public async Task<IActionResult> SaveMember(ViewMemberVM memberVM)
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
        public async Task<IActionResult> ViewMember(int memberId)
        {
            ViewMemberVM memberVm = await _iMemberService.GetMemberById(memberId);
            if (memberVm == null)
            {
                TempData[Message] = _message.MemberNotFound;
                return NotFound();
            }
            return View(memberVm);
        }

        // Edit Member
        public async Task<IActionResult> EditMember(int memberId)
        {

            ViewMemberVM memberVm = await _iMemberService.GetMemberById(memberId);
            if (memberVm == null)
            {
                TempData[Message] = _message.MemberNotFound;
                return NotFound();
            }
            return View(memberVm);
        }

        // Update Member
        public async Task<IActionResult> UpdateMember(ViewMemberVM memberVm)
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
        public async Task<IActionResult> DeleteMember(int memberId)
        {
            int loginUserId = 1;
            bool isDeleted = await _iMemberService.DeleteMember(memberId, loginUserId);
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
