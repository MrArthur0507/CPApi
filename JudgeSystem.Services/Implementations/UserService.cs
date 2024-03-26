using AutoMapper;
using JudgeSystem.DataAccess.Data;
using JudgeSystem.Models.User;
using JudgeSystem.Models.ViewModels;
using JudgeSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly JudgeDataContext _context;
        private readonly IMapper _mapper;

        public UserService(JudgeDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public List<UserViewModel> GetAllUsers()
        {
            List<UserViewModel> users = _mapper.Map<List<UserViewModel>>(_context.Users.ToList());
            return users;
        }

        public UserViewModel GetUserById(string userId)
        {

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            
            return _mapper.Map<UserViewModel>(user);
        }
    }
}
