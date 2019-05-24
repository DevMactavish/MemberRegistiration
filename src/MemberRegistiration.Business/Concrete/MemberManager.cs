using MemberRegistiration.Business.Abstract;
using MemberRegistiration.Entities.Concrete;
using MemberRegistiration.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using MemberRegistiration.Core.Aspects.PostSharp;
using MemberRegistiration.Business.ValidationRules.FluentValidation;
using FluentValidation.Results;

namespace MemberRegistiration.Business.Concrete
{
    public class MemberManager : IMemberService
    {
        IMemberDal _memberDal;
        IKpsService _service;
        public MemberManager(IMemberDal memberDal, IKpsService service)
        {
            _memberDal = memberDal;
            _service = service;
        }
        [FluentValidationAspect(typeof(MemberValidator))]
        public Member Add(Member member)
        {
            CheckMmemberExist(member);
            ValidateMember(member);
            return _memberDal.Add(member);
        }

        private void ValidateMember(Member member)
        {
            bool validate = _service.Validate(member);
            if (!validate)
                throw new Exception("Kullanıcı doğrulanamadı.");
        }

        private void CheckMmemberExist(Member member)
        {
            if (_memberDal.Get(m => m.TcNo == member.TcNo) != null)
                throw new Exception("Bu kullanıcı daha önce kayıt olmuştur.");
        }

        public Member Get(int id)
        {
            return _memberDal.Get(row => row.Id == id);
        }
        public List<Member> GetAll()
        {
            return _memberDal.GetAll();
        }

        public Member Update(Member member)
        {
            ValidateMember(member);
            return _memberDal.Update(member);
        }

        public void Delete(Member member)
        {
            _memberDal.Delete(member);
        }
    }
}
