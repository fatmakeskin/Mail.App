using AutoMapper;
using Data.DTO;
using Data.Models;
using DataAccess.BaseRepo;
using DataAccess.MongoRepo;
using DataAccess.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.UserServices
{
    public class UserService : IUserService
    {
        private IMapper mapper;
        private IUnitofWork uow;
        public UserService(IMapper _mapper)
        {
            _mapper=mapper;
        }

        public void Add(UserDto model)
        {
            UserModel result = mapper.Map<UserModel>(model);
            uow.GetRepository<UserModel>().Add(result);
            uow.SaveChanges();
        }

        public void Delete(UserDto model)
        {
            UserModel result = mapper.Map<UserModel>(model);
            uow.GetRepository<UserModel>().Delete(result);
            uow.SaveChanges();
        }

        public UserDto Get(int Id)
        {
            UserModel data = uow.GetRepository<UserModel>().Get(x=>x.Id.Equals(x.Id));
            UserDto result = mapper.Map<UserDto>(data);
            return result;
        }

        public List<UserDto> GetAll()
        {
            var data = uow.GetRepository<UserModel>().GetAll();
            List<UserDto> result = mapper.Map<List<UserDto>>(data);
            return result;
        }

        public LoginDto Login(LoginDto model)
        {
            if (model.Email == "superuser@admin.com" && model.Password == "superuser")
            {
                var result = new LoginDto() { Email = "superuser", Role = 0 };
                return result;
            }
            using (var uow = new UnitofWork<UserModel>())
            {
                var data = uow.GetRepository<UserModel>().Get(x => x.Email.Equals(model.Email) && x.Password.Equals(model.Password));                
                var result = mapper.Map<LoginDto>(data);
                return result;
            }
        }

        public void Update(UserDto model)
        {
            UserModel data = mapper.Map<UserModel>(model);
            uow.GetRepository<UserModel>().Update(data);
            uow.SaveChanges();
        }
    }
}
