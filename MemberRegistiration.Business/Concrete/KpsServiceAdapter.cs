using MemberRegistiration.Business.Abstract;
using MemberRegistiration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistiration.Business.Concrete
{
    public class KpsServiceAdapter : IKpsService
    {
        private KPSServiceReference.KPSPublicSoapClient _client = new KPSServiceReference.KPSPublicSoapClient();
        public bool Validate(Member member)
        {
            string firstName = GetFirstName(member);
            string lastName = GetLastName(member);
            long tcNo = GetTcNo(member);
            int year = GetYear(member);

           return _client.TCKimlikNoDogrula(tcNo, firstName, lastName, year);
        }


        private int GetYear(Member member)
        {
            return member.DateOfBirth.Year;
        }

        private long GetTcNo(Member member)
        {
            long tc = 0;
            long.TryParse(member.TcNo,out tc);
            return tc;
        }

        private string GetFirstName(Member member)
        {
            return member.FirstName;
        }

        private string GetLastName(Member member)
        {
            return member.LastName;
        }
    }
}
