using AutoMapper;
using Project.Bll.Dtos;
using Project.Bll.Handlers;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Enums;
using Project.Entities.Models;

namespace Project.Bll.Managers.Concretes
{
    public abstract class BaseManager<T, U> : IManager<T, U> where T : class, IDto where U : BaseEntity
    {
        private readonly IRepository<U> _repository;
        protected readonly IMapper _mapper;

        public BaseManager(IRepository<U> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(T entity)
        {
            await DelegateErrorHandler.Execute(async () =>
            {
                U domainEntity = _mapper.Map<U>(entity);
                domainEntity.CreatedDate = DateTime.Now;
                domainEntity.Status = DataStatus.Inserted;

                await _repository.CreateAsync(domainEntity);
            });
        }

        public List<T> GetActives()
        {
            return DelegateErrorHandler.Execute(() =>
            {
                List<U> values = _repository
                    .Where(x => x.Status != DataStatus.Deleted)
                    .ToList();

                return _mapper.Map<List<T>>(values);
            });
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DelegateErrorHandler.Execute(async () =>
            {
                IEnumerable<U> values = await _repository.GetAllAsync();
                return _mapper.Map<List<T>>(values.ToList());
            });
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DelegateErrorHandler.Execute(async () =>
            {
                U originalvalue = await _repository.GetByIdAsync(id);

                return _mapper.Map<T>(originalvalue);
            });
        }

        public List<T> GetPassives()
        {
            return DelegateErrorHandler.Execute(() =>
            {
                List<U> values = _repository
                   .Where(x => x.Status == DataStatus.Deleted)
                   .ToList();

                return _mapper.Map<List<T>>(values);
            });
        }

        public List<T> GetUpdatedes()
        {
            return DelegateErrorHandler.Execute(() =>
            {
                List<U> values = _repository
                 .Where(x => x.Status == DataStatus.Updated)
                 .ToList();

                return _mapper.Map<List<T>>(values);
            });
        }

        public async Task<string> HardDeleteAsync(int id)
        {
            return await DelegateErrorHandler.Execute(async () =>
            {

                U originialValue = await _repository.GetByIdAsync(id);
                if (originialValue == null)
                    return $"{id} ID'li kayıt bulunamadı." ;

                if (originialValue.Status == DataStatus.Deleted)
                     return "Pasif veriler silinemez.";

                await _repository.DeleteAsync(originialValue);
                return $"{id}'li veri silinmiştir.";
            });
        }

        public async Task<string> SoftDeleteAsync(int id)
        {
            return await DelegateErrorHandler.Execute(async () =>
            {

                U originialValue = await _repository.GetByIdAsync(id);
                 if (originialValue == null)
                    return $"{id} ID'li kayıt bulunamadı." ;

                if (originialValue.Status == DataStatus.Deleted)
                     return "Pasif veriler silinemez.";

                originialValue.DeletedDate = DateTime.Now;
                originialValue.Status = DataStatus.Deleted;
                await _repository.SaveChangesAsync();

                return $"{id}'li veri pasif hale getirilmiştir.";
            });
        }

        public async Task UpdateAsync(T entity)
        {
            await DelegateErrorHandler.Execute(async () =>
            {
                U originialValue = await _repository.GetByIdAsync(entity.Id);
                 if (originialValue == null)
                    throw new Exception($"{entity.Id} ID'li kayıt bulunamadı.");

                if (originialValue.Status == DataStatus.Deleted)
                    throw new Exception("Pasif veriler silinemez.");

                U newValue = _mapper.Map<U>(entity);
                newValue.UpdatedDate = DateTime.Now;
                newValue.Status = DataStatus.Updated;

                await _repository.UpdateAsync(originialValue, newValue);
            });
        }
    }


}
