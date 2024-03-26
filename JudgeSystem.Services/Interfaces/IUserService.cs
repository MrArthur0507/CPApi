using JudgeSystem.Models.User;
using JudgeSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Services.Interfaces
{
    public interface IUserService
    {
        public List<UserViewModel> GetAllUsers();
        public UserViewModel GetUserById(string userId);
    }
}
