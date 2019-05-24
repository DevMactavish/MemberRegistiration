using MemberRegistiration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistiration.Business.Abstract
{
    public interface IKpsService
    {
        bool Validate(Member member);
    }
}
