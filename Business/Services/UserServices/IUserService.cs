using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.UserServices
{
    public interface IUserService
    {
        UserDto Get(int Id);
        List<UserDto> GetAll();
        void Add(UserDto model);
        void Update(UserDto model);
        void Delete(UserDto model);
        LoginDto Login(LoginDto model);
    }
}
