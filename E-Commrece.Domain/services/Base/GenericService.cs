
using E_Commrece.Domain.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commrece.Domain.services.Base
{
    public class GenericService<TModel> : IGenricservice<TModel> where TModel : BaseEntityModel, new()
    {
        private readonly IGenricRepository<TModel> _genricRepository;
        public GenericService(IGenricRepository<TModel> genricRepository)
        {
            _genricRepository = genricRepository;
        }
        public Task<TModel> Add(TModel TModel)
        {
            return _genricRepository.Add(TModel);
        }

        public Task<TModel> Delete(int id)
        {
            return _genricRepository.Delete(id);
        }

        public Task<List<TModel>> GetAll()
        {
            return _genricRepository.GetAll();
        }

        public Task<TModel> GetById(int id)
        {
           return _genricRepository.GetById(id);
        }

        public Task<List<TModel>> GetByUserId(int id)
        {
            return _genricRepository.GetByUserId(id);
        }

        public Task<TModel> update(TModel TModel)
        {
           return _genricRepository.update(TModel);
        }
    }
}
