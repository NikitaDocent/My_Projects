using System;
using WebBL.DTO;
using System.Collections.Generic;
using AutoMapper;
using WebBL.Interfaces;
using WebDL.Interfaces;
using TestApp;
using WebBL.Infrastructure;

namespace NLayerApp.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }
        IMapper UserMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Users, UsersDTO>();
            cfg.CreateMap<UsersDTO, Users>();
        }).CreateMapper();


        public UserService()
        {
            Database = LogicDependencyResolver.ResolveUoW();
        }

       

        public IEnumerable<UsersDTO> GetAllUsers()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Users, UsersDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Users>, List<UsersDTO>>(Database.Users.GetAll());
        }
        public void Register(UsersDTO u)
        {
            Database.Users.Create(UserMapper.Map<UsersDTO, Users>(u));
            Database.Save();

        }
        public void Delete(int? id)
        {
            Database.Users.Delete(id.Value);
        }
        public UsersDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id пользователя", "");
            var Users = Database.Users.Get(id.Value);
            if (Users == null)
                throw new ValidationException("Пользователь не найден", "");

            return UserMapper.Map<Users, UsersDTO>(Users);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}