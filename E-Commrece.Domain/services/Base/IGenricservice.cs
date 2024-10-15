﻿using E_commerce.Ef.Core.Employee;
using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Base
{
    public interface IGenricservice<TModel> where TModel : BaseEntityModel, new()
    {
        Task<List<TModel>> GetAll();
        Task<TModel> GetById(int id);
        Task<TModel> Add(TModel TModel);
        Task<TModel> Delete(int id);
        Task<TModel> update(TModel TModel);
    }
}
