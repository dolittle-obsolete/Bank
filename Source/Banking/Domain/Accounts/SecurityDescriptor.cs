using Dolittle.Runtime.Commands.Security;
using Dolittle.Security;

namespace Domain.Accounts
{
    public class SecurityDescriptor : Dolittle.Security.SecurityDescriptor
    {
        public SecurityDescriptor(ICanResolvePrincipal principalResolver)
        {
            //When.Handling().Commands().InNamespace(typeof(OpenAccount).Namespace, _ => _.UserFrom(principalResolver).MustBeInRole("customer"));
        }
    }
}