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
        private readonly DbContextLMS _context;
        public MemberRepository(DbContextLMS context)
        {
            _context = context;
        }

        public async Task<List<Member>> GetAllMembers()
        {
            return await _context.Member.Where(b => b.IsDelete == false).ToListAsync();
        }

        public int SaveMember(Member memberData, int loginUserId)
        {
            Member memberModel = new Member();

            memberModel.CreatedBy = loginUserId;
            memberModel.CreatedDate = DateTime.Now;
            memberModel.FirstName = memberData.FirstName;
            memberModel.LastName = memberData.LastName;
            memberModel.Email = memberData.Email;
            memberModel.Phone = memberData.Phone;
            memberModel.Address = memberData.Address;

            _context.Add(memberModel);
            return _context.SaveChanges();
        }

        public Member FindMemberById(int memberId)
        {
            return _context.Member.Where(m => m.IsDelete == false && m.Id == memberId).FirstOrDefault();
        }

        public int UpdateMember(Member memberData, int loginUserId)
        {
            Member memberModel = _context.Member.Where(b => b.IsDelete == false && b.Id == memberData.Id).FirstOrDefault();
            if (memberModel == null) return -1;

            memberModel.UpdatedBy = loginUserId;
            memberModel.UpdatedDate = DateTime.Now;
            memberModel.FirstName = memberData.FirstName;
            memberModel.LastName = memberData.LastName;
            memberModel.Email = memberData.Email;
            memberModel.Phone = memberData.Phone;
            memberModel.Address = memberData.Address;

            _context.Update(memberModel);
            return _context.SaveChanges();
        }

        public int DeleteMember(int memberId, int loginUserId)
        {
            Member memberModel = _context.Member.Where(m => m.IsDelete == false && m.Id == memberId).FirstOrDefault();
            if (memberModel == null) return -1;

            memberModel.UpdatedBy = loginUserId;
            memberModel.UpdatedDate = DateTime.Now;
            memberModel.IsDelete = true;

            _context.Update(memberModel);
            return _context.SaveChanges();
        }
    }
}
