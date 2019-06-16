using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;
using BLL;

namespace BLL
{
    public class ClientsList
    {
        List<Client> clients { get; set; } = new List<Client>();
        private Serialize<Client> Database;
        public ClientsList()
        {
            Database = new Serialize<Client>("Client");
            try
            {
                var a = Database.Load();
                clients = a.ToList();
            }
            catch (Exception e)
            {
                Database.Save(clients.ToArray());
            }
        }
        public ClientsList(Serialize<Client> sr)
        {
            Database = sr;
            try
            {
                var a = Database.Load();
                clients = a.ToList();
            }
            catch (Exception e)
            {
                Database.Save(clients.ToArray());
            }
        }
        //добавление
        public void Add(string n, string sn,string b_a,int mon, Building_Offers b) => clients.Add(new Client
        {
            name = String.IsNullOrEmpty(n.Trim()) ? throw new ClientException("Invald name") : n,
            bank_account = Regex.IsMatch(b_a, "[0-9]{8}") ? throw new ClientException("Invalid bank account") : b_a,
            money = mon<0 ? throw new ClientException("Invalid money") : mon,
            surname = String.IsNullOrEmpty(sn.Trim()) ? throw new ClientException("Invalid surname") : sn,
            building_Offers = b.Offer
        });
        //удалаение
        public void Remove(int ind)
        {
            if (ind < 0 || ind >= clients.Count)
                throw new ClientException("Index out of range");
            clients.RemoveAt(ind);
        }
        //редактирование
        public void Edit(int ind, string n, string sn,string b_a, Building_Offers b )
        {
            if (ind < 0 || ind >= clients.Count)
                throw new ClientException("Index out of range");
            var client = clients[ind];
            client.name = n;
            client.surname = sn;
            client.bank_account = b_a;
            client.building_Offers = b.Offer;
            clients[ind] = client;
        }
        //поиск по имени
        public Client FindN(string n) => clients.Find(x => x.name == n);
        //поиск по фамилии
        public Client FindSn(string sn) => clients.Find(x => x.surname == sn);
        //поиск по банковскому счету
        public Client FindBa(string b_a) => clients.Find(x => x.bank_account == b_a);
        //поиск по деньгам
        public Client FindM(int mon) => clients.Find(x => x.money == mon);
        //сортировка по имени
        public List<Client> SortByName()
        {
            var temp = clients;
            for (int i = 0; i < clients.Count - 1; i++)
            {
                int min = i;
                for (int j = i; j < clients.Count - 1; j++)
                    if (temp[j].name.CompareTo(temp[min].name) < 0)
                        min = j;
                var a = temp[min];
                temp[min] = temp[i];
                temp[i] = a;
            }
            return temp;
        }
        //сортировка по фамилии
        public List<Client> SortBySurname()
        {
            var temp = clients;
            for (int i = 0; i < clients.Count - 1; i++)
            {
                int min = i;
                for (int j = i; j < clients.Count - 1; j++)
                    if (temp[j].surname.CompareTo(temp[min].surname) < 0)
                        min = j;
                var a = temp[min];
                temp[min] = temp[i];
                temp[i] = a;
            }
            return temp;
        }
        //сортировка по первой цифре
        public List<Client> SortByFirstDigit()
        {
            var temp = clients;
            for (int i = 0; i < clients.Count - 1; i++)
            {
                int min = i;
                for (int j = i; j < clients.Count - 1; j++)
                    if (Convert.ToInt16(temp[j].bank_account) < Convert.ToInt16(temp[min].bank_account))
                        min = j;
                var a = temp[min];
                temp[min] = temp[i];
                temp[i] = a;
            }
            return temp;
        }
        //список всех клиентов
        public string GetClients()
        {
            string list = "";
            foreach (var a in clients)
                list += $"Name: {a.name}\tSurname: {a.surname}\tMoney: {a.money}\n";
            return list;
        }
        public void Save()
        {
            Database.Save(clients.ToArray());
        }
    }
}
