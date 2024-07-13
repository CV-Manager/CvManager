using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CvManager.Services.Account
{
    public interface IAccountService
    {
        Task<bool> CreateUserAsync(User user);
    }
}