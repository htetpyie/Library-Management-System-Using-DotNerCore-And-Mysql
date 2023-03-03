using LMS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Interfaces
{
    public interface IMemberService
    {
        Task<List<ViewMemberVM>> GetAllMember(int pageNo, int rowCount);
        Task<bool> IsDuplicate(ViewMemberVM memberVM);
        Task<bool> SaveMember(ViewMemberVM memberVM, int loginUserId);
        Task<ViewMemberVM> GetMemberById(int memberId);
        Task<bool> UpdateMember(ViewMemberVM memberVm, int loginUserId);
        Task<bool> DeleteMember(int memberId, int loginUserId);
    }
}
