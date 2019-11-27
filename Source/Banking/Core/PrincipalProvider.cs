using System.Security.Claims;
using System.Threading;
using Dolittle.Security;

namespace Core
{
    public class PrincipalProvider : ICanResolvePrincipal
    {
        private static readonly AsyncLocal<ClaimsPrincipal> _currentClaimsPrincipal = new AsyncLocal<ClaimsPrincipal>();

        public ClaimsPrincipal Resolve()
        {
            if(_currentClaimsPrincipal == null)
            {
                return new ClaimsPrincipal(new ClaimsIdentity());
            }
            return _currentClaimsPrincipal.Value;
        }
    }
}