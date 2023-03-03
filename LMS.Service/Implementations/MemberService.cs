using AutoMapper;
using LMS.Data.Models;
using LMS.Data.ViewModels;
using LMS.Service.Interfaces;
using LMS.Service.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Implementations
{
    public class MemberService : IMemberService
    {
        private readonly MemberRepository _memberRepo;
        private readonly IMapper _mapper;

        public MemberService(MemberRepository memberRepo, IMapper mapper)
        {
            _memberRepo = memberRepo;
            _mapper = mapper;
        }

        // Read, Retrieve All
        public async Task<List<ViewMemberVM>> GetAllMember(int pageNo, int rowCount)
        {
            var memberList = await _memberRepo.GetAllMembers(pageNo, rowCount);
            List<ViewMemberVM> resultList = _mapper.Map<List<ViewMemberVM>>(memberList);
            return resultList;
        }

        // Check Duplicate
        public async Task<bool> IsDuplicate(ViewMemberVM memberVM)
        {
            Member member = _mapper.Map<Member>(memberVM);
            bool isDuplicate = await _memberRepo.IsDuplicate(member);
            return isDuplicate;
        }

        // Save Member
        public async Task<bool> SaveMember(ViewMemberVM memberVM, int loginUserId)
        {
            Member member = _mapper.Map<Member>(memberVM);
            bool isSaved = await _memberRepo.SaveMember(member, loginUserId);
            return isSaved;
        }

        // Get By Id
        public async Task<ViewMemberVM> GetMemberById(int memberId)
        {
            var member = await _memberRepo.GetMemberById(memberId);
            ViewMemberVM memberVm = _mapper.Map<ViewMemberVM>(member);
            return memberVm;
        }

        // Update Member
        public async Task<bool> UpdateMember(ViewMemberVM memberVm, int loginUserId)
        {
            Member member = _mapper.Map<Member>(memberVm);
            bool isUpdated = await _memberRepo.UpdateMember(member, loginUserId);
            return isUpdated;
        }

        // Delete
        public async Task<bool> DeleteMember(int memberId, int loginUserId)
        {
            bool isDeleted = await _memberRepo.DeleteMember(memberId, loginUserId);
            return isDeleted;
        }
    }
}
