using MemberRegistiration.Business.Abstract;
using MemberRegistiration.Entities.Concrete;
using MemberRegistiration.MVCWebUI.Filters;
using MemberRegistiration.MVCWebUI.Models.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemberRegistiration.MVCWebUI.Controllers
{
    public class MemberController : Controller
    {
        IMemberService _service;
        public MemberController(IMemberService service)
        {
            _service = service;
        }
        // GET: Member
        public ActionResult Add()
        {
            return View(new MemberAddViewModel());
        }
        [HttpPost]
        [ExceptionHandler]
        public ActionResult Add(Member member)
        {
            _service.Add(member);
            return View(new MemberAddViewModel());
        }
    }
}