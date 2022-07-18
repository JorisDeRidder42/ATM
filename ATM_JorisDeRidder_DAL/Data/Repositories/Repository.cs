﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ATM_JorisDeRidder_DAL.Data.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class, new()
    {
        protected DbContext Context { get; }

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public void Aanpassen(T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Ophalen()
        {
            return Context.Set<T>().ToList();
        }

        public void Toevoegen(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Verwijderen(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public IEnumerable<T> Ophalen(Expression<Func<T, bool>> voorwaarden,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            if (voorwaarden != null)
            {
                query = query.Where(voorwaarden);
            }
            return query.ToList();
        }

        public IEnumerable<T> Ophalen(Expression<Func<T, bool>> voorwaarden)
        {
            return Ophalen(voorwaarden, null).ToList();
        }

        public IEnumerable<T> Ophalen(params Expression<Func<T, object>>[] includes)
        {
            return Ophalen(null, includes).ToList();
        }
    }
}