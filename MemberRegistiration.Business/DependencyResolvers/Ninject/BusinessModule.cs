using MemberRegistiration.Business.Abstract;
using MemberRegistiration.Business.Concrete;
using MemberRegistiration.DataAccess.Abstract;
using MemberRegistiration.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace MemberRegistiration.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMemberDal>().To<EfMemberDal>().InSingletonScope();
            Bind<IMemberService>().To<MemberManager>().InSingletonScope();

            Bind<IKpsService>().To<KpsServiceAdapter>().InSingletonScope();

        }
    }
}
