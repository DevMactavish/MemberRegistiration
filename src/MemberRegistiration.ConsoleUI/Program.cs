using MemberRegistiration.Business.Abstract;
using MemberRegistiration.Business.Concrete;
using MemberRegistiration.Business.DependencyResolvers.Ninject;
using MemberRegistiration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistiration.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Member member = new Member();

            IMemberService memberService = InstanceFactory.GetInstance<IMemberService>();
            memberService.Add(member);
            Console.WriteLine("Eklendi.");
            Console.ReadLine();
        }
    }
}
