using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace LibraryApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _context;

        public UserService(IHttpContextAccessor httpContext)
        {
            _context = httpContext;
        }

        public ClaimsPrincipal User
        {
            get
            {
                return _context.HttpContext.User;
            }
        }

        public string CurrentUserId
        {
            get
            {
                return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
        }
    }
}
