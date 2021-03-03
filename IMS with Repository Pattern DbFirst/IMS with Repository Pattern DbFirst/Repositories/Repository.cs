﻿using IMS_with_Repository_Pattern_DbFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IMS_with_Repository_Pattern_DbFirst.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected InventoryDb context = new InventoryDb();
        public void Delete(int id)
        {
            context.Set<TEntity>().Remove(Get(id));
            context.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}