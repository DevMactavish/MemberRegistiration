using MemberRegistiration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistiration.Business.Abstract
{
    public interface IMemberService
    {
        Member Add(Member member);
        Member Update(Member member);
        void Delete(Member member);
        List<Member> GetAll();
        Member Get(int id);
    }
}
