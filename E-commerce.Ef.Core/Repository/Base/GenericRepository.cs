﻿using E_Commrece.Domain;
using E_Commrece.Domain.BaseClass;
using E_Commrece.Domain.services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Repository.Base
{
    public class GenericRepository<TModel> : IGenricRepository<TModel> where TModel : BaseEntityModel, new()
    {
        private readonly ApplicationDbContext applicationDb;
        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            applicationDb = applicationDbContext;
        }
        public async Task<TModel> Add(TModel TModel)
        {
           
                await applicationDb.Set<TModel>().AddAsync(TModel);
                await applicationDb.SaveChangesAsync();
                return TModel;
        }
        public async Task<TModel> Delete(int id)
        {
            var DeletedData = await GetById(id);
            applicationDb.Set<TModel>().Remove(DeletedData);
            await applicationDb.SaveChangesAsync();
            return DeletedData;
        }
        public virtual async Task<List<TModel>> GetAll()
        {
            return await applicationDb.Set<TModel>().AsNoTracking().ToListAsync();
        }
        public virtual async Task<TModel> GetById(int id)
        {
            return await applicationDb.Set<TModel>().AsNoTracking().Where(x=>x.id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<List<TModel>> GetByUserId(int id)
        {
            return await applicationDb.Set<TModel>().AsNoTracking().Where(x => x.id == id).ToListAsync();
        }

        public async Task<TModel> update(TModel TModel)
        {
            applicationDb.Set<TModel>().Update(TModel);
            await applicationDb.SaveChangesAsync();
            return TModel;
        }

        Task<TModel> IGenricRepository<TModel>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
