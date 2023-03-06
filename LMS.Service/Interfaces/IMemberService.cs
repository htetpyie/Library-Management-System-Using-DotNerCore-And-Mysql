using LMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Interfaces
{
    public interface IMemberService
    {
        Task<List<MemberVM>> GetAllMember(string sortColumn,string sortColumnDirection,string searchValue,int skip, int rowCount);
        Task<bool> IsDuplicate(MemberVM memberVM);
        Task<bool> SaveMember(MemberVM memberVM, int loginUserId);
        Task<MemberVM> GetMemberById(int memberId);
        Task<bool> UpdateMember(MemberVM memberVm, int loginUserId);
        Task<bool> DeleteMember(int memberId, int loginUserId);
    }
}
