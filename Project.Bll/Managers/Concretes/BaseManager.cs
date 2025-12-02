using AutoMapper;
using Project.Bll.Dtos;
using Project.Bll.Exceptions;
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

        // Hata yönetimi için event (Microsoft ErrorEventHandler pattern'ine uygun)
        public event Handlers.ErrorEventHandler? Error;

        public BaseManager(IRepository<U> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(T entity)
        {
            await ErrorHandler.ExecuteAsync(this, async () =>
            {
                if (entity == null)
                    throw new ValidationException("Entity boş olamaz.");

                U domainEntity = _mapper.Map<U>(entity);
                domainEntity.CreatedDate = DateTime.Now;
                domainEntity.Status = DataStatus.Inserted;

                await _repository.CreateAsync(domainEntity);
            }, Error);
        }

        public List<T> GetActives()
        {
            return ErrorHandler.Execute(this, () =>
            {
                List<U> values = _repository
                    .Where(x => x.Status != DataStatus.Deleted)
                    .ToList();

                return _mapper.Map<List<T>>(values);
            }, Error);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await ErrorHandler.ExecuteAsync(this, async () =>
            {
                IEnumerable<U> values = await _repository.GetAllAsync();
                return _mapper.Map<List<T>>(values.ToList());
            }, Error);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await ErrorHandler.ExecuteAsync(this, async () =>
            {
                if (id <= 0)
                    throw new ValidationException("Id 0'dan büyük olmalıdır.");

                U originalvalue = await _repository.GetByIdAsync(id);

                if (originalvalue == null)
                    throw new NotFoundException($"{id} ID'li kayıt bulunamadı.");

                return _mapper.Map<T>(originalvalue);
            }, Error);
        }

        public List<T> GetPassives()
        {
            return ErrorHandler.Execute(this, () =>
            {
                List<U> values = _repository
                   .Where(x => x.Status == DataStatus.Deleted)
                   .ToList();

                return _mapper.Map<List<T>>(values);
            }, Error);
        }

        public List<T> GetUpdatedes()
        {
            return ErrorHandler.Execute(this, () =>
            {
                List<U> values = _repository
                 .Where(x => x.Status == DataStatus.Updated)
                 .ToList();

                return _mapper.Map<List<T>>(values);
            }, Error);
        }

        public async Task<string> HardDeleteAsync(int id)
        {
            return await ErrorHandler.ExecuteAsync(this, async () =>
            {
                if (id <= 0)
                    throw new ValidationException("Id 0'dan büyük olmalıdır.");

                U originialValue = await _repository.GetByIdAsync(id);
                if (originialValue == null)
                    throw new NotFoundException($"{id} ID'li kayıt bulunamadı.");

                if (originialValue.Status == DataStatus.Deleted)
                    throw new BusinessException("Pasif veriler silinemez.");

                await _repository.DeleteAsync(originialValue);
                return $"{id}'li veri silinmiştir.";
            }, Error);
        }

        public async Task<string> SoftDeleteAsync(int id)
        {
            return await ErrorHandler.ExecuteAsync(this, async () =>
            {
                if (id <= 0)
                    throw new ValidationException("Id 0'dan büyük olmalıdır.");

                U originialValue = await _repository.GetByIdAsync(id);
                if (originialValue == null)
                    throw new NotFoundException($"{id} ID'li kayıt bulunamadı.");

                if (originialValue.Status == DataStatus.Deleted)
                    throw new BusinessException("Veri zaten pasif durumda.");

                originialValue.DeletedDate = DateTime.Now;
                originialValue.Status = DataStatus.Deleted;
                await _repository.SaveChangesAsync();

                return $"{id}'li veri pasif hale getirilmiştir.";
            }, Error);
        }

        public async Task UpdateAsync(T entity)
        {
            await ErrorHandler.ExecuteAsync(this, async () =>
            {
                if (entity == null)
                    throw new ValidationException("Entity boş olamaz.");

                if (entity.Id <= 0)
                    throw new ValidationException("Id 0'dan büyük olmalıdır.");

                U originialValue = await _repository.GetByIdAsync(entity.Id);
                if (originialValue == null)
                    throw new NotFoundException($"{entity.Id} ID'li kayıt bulunamadı.");

                if (originialValue.Status == DataStatus.Deleted)
                    throw new BusinessException("Pasif veriler güncellenemez.");

                U newValue = _mapper.Map<U>(entity);
                newValue.UpdatedDate = DateTime.Now;
                newValue.Status = DataStatus.Updated;

                await _repository.UpdateAsync(originialValue, newValue);
            }, Error);
        }
    }


}
