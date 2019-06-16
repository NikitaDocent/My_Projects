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
    public class ItemService:IItemService
    {
        IUnitOfWork Database { get; set; }
        IMapper UserMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Item, ItemDTO>();
            cfg.CreateMap<ItemDTO, Item>();
        }).CreateMapper();


        public ItemService()
        {
            Database = LogicDependencyResolver.ResolveUoW();
        }



        public IEnumerable<ItemDTO> Get()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Item, ItemDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Item>, List<ItemDTO>>(Database.Item.GetAll());
        }
        public void Add(ItemDTO i)
        { 
            
            Database.Item.Create(UserMapper.Map<ItemDTO, Item>(i));
            Database.Save();
            ///new Item { Name = name, Category = category, Count = count, Description = description, MainPhoto = mainphoto, OtherPhotos = otherphotos, Price = price }
            ///string name, int category, int count, string description, string mainphoto, string otherphotos, decimal price

        }
        public void Delete(int? id)
        {
            Database.Item.Delete(id.Value);
        }
        public ItemDTO Get(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id телефона", "");
            var Item = Database.Item.Get(id.Value);
            if (Item == null)
                throw new ValidationException("Телефон не найден", "");

            return UserMapper.Map<Item, ItemDTO>(Item);
               //// new ItemDTO { Id = Item.Id, Name = Item.Name, Category = Item.Category, Price = Item.Price, OtherPhotos = Item.OtherPhotos, MainPhoto = Item.MainPhoto, Count = Item.Count, Description = Item.Description };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
