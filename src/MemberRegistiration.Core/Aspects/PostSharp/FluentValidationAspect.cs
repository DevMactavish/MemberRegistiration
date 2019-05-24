using FluentValidation;
using MemberRegistiration.Core.Validation.FluentValidation;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistiration.Core.Aspects.PostSharp
{
    [Serializable]
    public class FluentValidationAspect:OnMethodBoundaryAspect
    {
        Type _type;
        public FluentValidationAspect(Type type)
        {
            _type = type;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator =(IValidator)Activator.CreateInstance(_type);
            var entityType = _type.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(row => row.GetType() == entityType);
            foreach (var entity in entities)
                ValidatorTool.FluentValidate(validator,entity);
        }
    }
}
