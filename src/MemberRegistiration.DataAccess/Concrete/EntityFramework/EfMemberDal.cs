﻿using MemberRegistiration.Core.DataAccess.EntityFramework;
using MemberRegistiration.DataAccess.Abstract;
using MemberRegistiration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistiration.DataAccess.Concrete.EntityFramework
{
    public class EfMemberDal:EfEntityRepositoryBase<Member, MembershipContext>,IMemberDal
    {
    }
}
