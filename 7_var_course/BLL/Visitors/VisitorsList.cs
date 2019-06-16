using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class VisitorsList
    {
        List<Visitors> visitors { get; set; } = new List<Visitors>();
        private Serialize<Visitors> Datbase;

        public VisitorsList()
        {
            Datbase = new Serialize<Visitors>("Visitor");
            try
            {
                var a = Datbase.Load();
                visitors = a.ToList();
            }
            catch (Exception e)
            {
                Datbase.Save(visitors.ToArray());
            }
        }
        public int Last
        {
            get { return visitors.Count; }
        }
        public VisitorsList(Serialize<Visitors> sr)
        {
            Datbase = sr;
            try
            {
                var a = Datbase.Load();
                visitors = a.ToList();
            }
            catch (Exception e)
            {
                Datbase.Save(visitors.ToArray());
            }
        }
        //добавить посетителя
        public void Add(string name, string surname, int mon, DocOffers offers) => visitors.Add(new Visitors
        {
            Name = String.IsNullOrEmpty(name.Trim()) ? throw new LibraryException("Invald name") : name,
            AcademGroup = mon < 0 ? throw new LibraryException("Invalid group") : mon,
            Surname = String.IsNullOrEmpty(surname.Trim()) ? throw new LibraryException("Invalid surname") : surname,
            offers = offers
        });
        //удалить посетителя
        public void Remove(int ind)
        {
            if (ind < 0 || ind >= visitors.Count)
                throw new LibraryException("Index out of range");
            visitors.RemoveAt(ind);
        }
        //изменить данные посетителя
        public void Edit(int ind,string n,string sn,int group)
        {
            if (ind < 0 || ind >= visitors.Count)
                throw new LibraryException("Index out of range");
            var vis = visitors[ind];
            vis.Name = n;
            vis.Surname = sn;
            vis.AcademGroup = group;
            visitors[ind] = vis;
        }
        //поулчить информацию об нужном посетителе
        public Visitors GetInfo(int ind) => ind < 0 || ind >= visitors.Count ? null : visitors[ind];
        //сортировка по имени
        public List<Visitors> SortByName()
        {
            var temp = visitors;
            for (int i = 0; i < visitors.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < visitors.Count; j++)
                    if (temp[j].Name.CompareTo(temp[min].Name) < 0)
                        min = j;
                var a = temp[min];
                temp[min] = temp[i];
                temp[i] = a;
            }
            return temp;
        }

        //сортировка по фамилии 
        public List<Visitors> SortBySurname()
        {
            var temp = visitors;
            for (int i = 0; i < visitors.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < visitors.Count; j++)
                    if (temp[j].Surname.CompareTo(temp[min].Surname) < 0)
                        min = j;
                var a = temp[min];
                temp[min] = temp[i];
                temp[i] = a;
            }
            return temp;
        }

        //сортировка по группам 
        public List<Visitors> SortByGroup()
        {
            var temp = visitors;
            for (int i = 0; i < visitors.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < visitors.Count; j++)
                    if (Convert.ToInt16(temp[j].AcademGroup) < Convert.ToInt16(temp[min].AcademGroup))
                        min = j;
                var a = temp[min];
                temp[min] = temp[i];
                temp[i] = a;
            }
            return temp;
        }

        //поиск по имени
        public Visitors FindByName(string name) => visitors.Find(x => x.Name == name);
        //поиск по фамилии
        public Visitors FindBySurname(string sname) => visitors.Find(x => x.Surname == sname);
        //поиск по группе
        public Visitors FindByGroup(int group) => visitors.Find(x => x.AcademGroup == group);

        //получить список с посетителями
        public string GetAllVisitors()
        {
            string list = "";
            foreach (var a in visitors)
                list += "AcademGroup:\t" + a.AcademGroup + "\tName:\t" + a.Name + "\tSurname:\t" + a.Surname + $"\tHave a {a.offers.Offer.Count} books\n";
            return list;
        }
        //поиск у кого сейчас книга
        public string FindByBookOwner(string Author, string Title)
        {
            string b = "";
            foreach(var a in visitors)
            {
                for (int i = 0; i < 5; i++)
                   b += visitors.Find(x => x.offers.Offer[i] == ("Title:\t\t" + Title + "\tAuthor:\t\t" + Author));
            }
            return b;
        }

        public void AddOffer(int ind, Docs doc)
        {
            if (ind < 0 || ind >= visitors.Count)
                throw new LibraryException("Index out of range");
            visitors[ind].offers.AddBook(doc);
        }
        public void RemoveOffer(int ind, int indoffer)
        {
            if (ind < 0 || ind >= visitors.Count)
                throw new LibraryException("Index out of range");
            if (indoffer < 0 || indoffer >= 5)
                throw new LibraryException("Index out of range");
            visitors[ind].offers.ReturnBook(indoffer);
        }
        public string ShowOffers(int ind)
        {
            if (ind < 0 || ind >= visitors.Count)
                throw new LibraryException("Index out of range");
            return visitors[ind].offers.ToString();
        }
        //сохранение
        public void Save()
        {
            Datbase.Save(visitors.ToArray());
        }
    }
}
