using AutoMapper;
using LMS.Data.Models;
using LMS.Data.ViewModels;
using LMS.Service.Interfaces;
using LMS.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<List<MemberVM>> GetAllMember(string sortColumn,string sortColumnDirection,string searchValue, int skip, int rowCount)
        {
            var memberList = await _memberRepo.GetAllMembers(skip, rowCount);
            List<MemberVM> resultList = memberList.Select(m => _mapper.Map<MemberVM>(m)).ToList();
            return resultList;
        }

        // Check Duplicate
        public async Task<bool> IsDuplicate(MemberVM memberVM)
        {
            MemberDM member = _mapper.Map<MemberDM>(memberVM);
            bool isDuplicate = await _memberRepo.IsDuplicate(member);
            return isDuplicate;
        }

        // Save Member
        public async Task<bool> SaveMember(MemberVM memberVM, int loginUserId)
        {
            MemberDM member = _mapper.Map<MemberDM>(memberVM);
            bool isSaved = await _memberRepo.SaveMember(member, loginUserId);
            return isSaved;
        }

        // Get By Id
        public async Task<MemberVM> GetMemberById(int memberId)
        {
            var member = await _memberRepo.GetMemberById(memberId);
            MemberVM memberVm = _mapper.Map<MemberVM>(member);
            return memberVm;
        }

        // Update Member
        public async Task<bool> UpdateMember(MemberVM memberVm, int loginUserId)
        {
            MemberDM member = _mapper.Map<MemberDM>(memberVm);
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
