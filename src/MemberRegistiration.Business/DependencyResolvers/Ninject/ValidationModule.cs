using FluentValidation;
using MemberRegistiration.Business.ValidationRules.FluentValidation;
using MemberRegistiration.Entities.Concrete;
using Ninject.Modules;

namespace MemberRegistiration.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Member>>().To<MemberValidator>().InSingletonScope();
        }
    }
}
