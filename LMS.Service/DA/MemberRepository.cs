using LMS.Data.Context;
using LMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Repository
{
    public class MemberRepository
    {
        private readonly LMSDbContext _context;
        public MemberRepository(LMSDbContext context)
        {
            _context = context;
        }

        public async Task<List<MemberDM>> GetAllMembers(int pageNo, int rowCount)
        {
            //int skip = (pageNo - 1) * rowCount;
            int skip = pageNo;
            List<MemberDM> list = await _context.Member
                                    .AsNoTracking()                                  
                                    .Skip(skip)
                                    .Take(rowCount)
                                    .ToListAsync();
            return list;
        }

        public async Task<bool> SaveMember(MemberDM memberData, int loginUserId)
        {
            MemberDM memberModel = new MemberDM();
                     
            memberModel.FirstName = memberData.FirstName;
            memberModel.LastName = memberData.LastName;
            memberModel.Email = memberData.Email;
            memberModel.Phone = memberData.Phone;
            memberModel.Address = memberData.Address;

            await _context.AddAsync(memberModel);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<MemberDM> GetMemberById(int memberId)
        {
            var member = await _context.Member.FirstOrDefaultAsync(m => m.MemberId == memberId);
            return member;
        }

        public async Task<bool> UpdateMember(MemberDM memberData, int loginUserId)
        {
            MemberDM memberModel = await _context.Member.FirstOrDefaultAsync(b => b.MemberId == memberData.MemberId);
            if (memberModel == null) return false;
                     
            memberModel.FirstName = memberData.FirstName;
            memberModel.LastName = memberData.LastName;
            memberModel.Email = memberData.Email;
            memberModel.Phone = memberData.Phone;
            memberModel.Address = memberData.Address;

            _context.Entry(memberModel).State = EntityState.Modified;
            _context.Update(memberModel);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteMember(int memberId, int loginUserId)
        {
            MemberDM memberModel = await _context.Member.FirstOrDefaultAsync(m => m.MemberId == memberId);
            if (memberModel == null) return false;

            _context.Entry(memberModel).State = EntityState.Deleted;
            _context.Update(memberModel);
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> IsDuplicate(MemberDM member)
        {
            bool isDuplicate;
            if (member.MemberId > 0)
            {
                isDuplicate = await _context.Member.AnyAsync(m => m.MemberId != member.MemberId
                                && (m.Email.ToLower().Trim() == member.Email.ToLower().Trim() || m.Phone.Trim() == member.Phone.Trim()));
            }
            else
            {
                isDuplicate = await _context.Member.AnyAsync(m =>  
                                                             m.Email.ToLower().Trim() == member.Email.ToLower().Trim() || 
                                                             m.Phone.Trim() == member.Phone.Trim());
            }
            return isDuplicate;
        }
    }
}
