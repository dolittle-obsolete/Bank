using Dolittle.DependencyInversion;
using Dolittle.Security;

namespace Core
{
    public class Bindings : ICanProvideBindings
    {
        public void Provide(IBindingProviderBuilder builder)
        {
            builder
                .Bind<ICanResolvePrincipal>()
                .To(new PrincipalProvider());
        }
    }
}