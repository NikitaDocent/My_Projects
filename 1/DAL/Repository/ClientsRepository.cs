﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface;
using DesignAgency;
using System.Collections.Concurrent;
using System.Data.Entity.Migrations;

namespace DAL.Repository
{
    public class ClientsRepository : IRepository<Client>
    {
        private Entity accessContext;

        public ClientsRepository(Entity p_accessContext)
        {
            accessContext = p_accessContext;
        }

        public IEnumerable<Client> Find(Func<Client, bool> predicate)
        {
            return accessContext.Clients.Where(predicate).ToList();
        }

        public Client Get(int id)
        {
            return accessContext.Clients.Find(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return accessContext.Clients.Local.ToBindingList();
        }

        public void Insert(Client obj)
        {
            accessContext.Clients.Add(obj);
            accessContext.Entry(obj).State = EntityState.Added;
        }
        public void Update(Client obj)
        {
            accessContext.Entry<Client>(obj).State = EntityState.Modified;
        }
        

        public void Delete(Client obj)
        {
            accessContext.Clients.Remove(obj);
            accessContext.Entry<Client>(obj).State = EntityState.Deleted;
        }

        public void Load()
        {
            accessContext.Clients.Load();
        }
    }
}
