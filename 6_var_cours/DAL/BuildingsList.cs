using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BuildingsList
    {
        List<Buildings> buildings { get; set; } = new List<Buildings>();
        private Serialize<Buildings> Database;
        public BuildingsList()
        {
            Database = new Serialize<Buildings>("Building");
            try
            {
                var a = Database.Load();
                buildings = a.ToList();
            }
            catch (Exception e)
            {
                Database.Save(buildings.ToArray());
            }
        }
        public BuildingsList(Serialize<Buildings> sr)
        {
            Database = sr;
            try
            {
                var a = Database.Load();
                buildings = a.ToList();
            }
            catch (Exception e)
            {
                Database.Save(buildings.ToArray());
            }
        }
        //добавление
        public void Add(int cost, string numb) => buildings.Add(new Buildings
        {
            Cost = cost<=0 ? throw new BuildingExeption("Invald cost") : cost,
            type_of_building = Convert.ToInt16(numb)< 0|| Convert.ToInt16(numb)> 3 ? throw new BuildingExeption("Invalid type of building") : numb,
        });
        //удалаение
        public void Remove(int ind)
        {
            if (ind < 0 || ind >= buildings.Count)
                throw new ClientException("Index out of range");
            buildings.RemoveAt(ind);
        }
        public Buildings GetInfo(int ind) => ind < 0 || ind >= buildings.Count ? null : buildings[ind];
        //редактирование
        public void Edit(int ind, int c, string tpb)
        {
            if (ind < 0 || ind >= buildings.Count)
                throw new ClientException("Index out of range");
            var building = buildings[ind];
            building.Cost = c;
            building.type_of_building = tpb;
            buildings[ind] = building;
        }
        //сортировка по стоимости
        public List<Buildings> SortByCost()
        {
            var temp = buildings;
            for (int i = 0; i < buildings.Count - 1; i++)
            {
                int min = i;
                for (int j = i; j < buildings.Count - 1; j++)
                    if (temp[j].Cost < temp[min].Cost)
                        min = j;
                var a = temp[min];
                temp[min] = temp[i];
                temp[i] = a;
            }
            return temp;
        }
        //сортировка по типу строения
        public List<Buildings> SortByType()
        {
            var temp = buildings;
            for (int i = 0; i < buildings.Count - 1; i++)
            {
                int min = i;
                for (int j = i; j < buildings.Count - 1; j++)
                    if (Convert.ToInt16(temp[j].type_of_building) < Convert.ToInt16( temp[min].type_of_building))
                        min = j;
                var a = temp[min];
                temp[min] = temp[i];
                temp[i] = a;
            }
            return temp;
        }

        //поиск по стоимости
        public Buildings FindCost(int cos) => buildings.Find(x => x.Cost == cos);
        //поиск по типу строения
        public Buildings FindType(string tpb) => buildings.Find(x => x.type_of_building == tpb);
        //поиск по доступности
        public Buildings FindAvaible(bool av) => buildings.Find(x => x.avaible == av);
        //список всех объектов недвижимости
        public string GetBuildings()
        {
            string list="";
            foreach (var a in buildings)
                list += $"type of building {a.type_of_building}\tCost: {a.Cost}\n";
            return list;
        }

        public void Save()
        {
            Database.Save(buildings.ToArray());
        }
    }
}
