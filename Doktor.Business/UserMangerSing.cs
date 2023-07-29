using DoktorKlinik.Domain.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Business
{
    public class UserMangerSing:UserManager<KlinikUser>
    {
        IHttpContextAccessor _httpContext;
        public UserMangerSing(IUserStore<KlinikUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IHttpContextAccessor httpContext,
            IPasswordHasher<KlinikUser> passwordHasher,
            IEnumerable<IUserValidator<KlinikUser>> userValidators,
            IEnumerable<IPasswordValidator<KlinikUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<KlinikUser>> logger) : base(store, optionsAccessor,
                passwordHasher, userValidators, passwordValidators,
                keyNormalizer, errors, services, logger)
        {
            _httpContext = httpContext;
        }
        public KlinikUser ActiveUser
        {
            get { return GetUserAsync(_httpContext.HttpContext.User).Result;}
        }
    }
}
