using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp;
using WebBL.DTO;
using WebBL.Infrastructure;
using WebBL.Interfaces;
using WebDL.Interfaces;

namespace WebBL.Services
{
    public class CategoryService:ICategoryService
    {
        IUnitOfWork Database { get; set; }
        IMapper UserMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category, CategoryDTO>();
            cfg.CreateMap<CategoryDTO, Category>();
        }).CreateMapper();


        public CategoryService()
        {
            Database = LogicDependencyResolver.ResolveUoW();
        }



        public IEnumerable<CategoryDTO> Get()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Category.GetAll());
        }
        public void Add(CategoryDTO c)
        {
            Database.Category.Create(UserMapper.Map<CategoryDTO,Category>(c));
            Database.Save();

        }
        public void Delete(int? id)
        {
            Database.Category.Delete(id.Value);
        }
        public CategoryDTO Get(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id категории", "");
            var Category = Database.Category.Get(id.Value);
            if (Category == null)
                throw new ValidationException("Категория не найдена", "");

            return UserMapper.Map<Category, CategoryDTO>(Category);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
