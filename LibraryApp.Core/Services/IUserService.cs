using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace LibraryApp.Core.Services
{
    public interface IUserService
    {
        ClaimsPrincipal User { get; }
        string CurrentUserId { get; }
    }
}
