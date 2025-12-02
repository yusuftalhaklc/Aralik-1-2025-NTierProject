using Project.Bll.Dtos;
using Project.Entities.Models;

namespace Project.Bll.Managers.Abstracts
{
    public interface IManager<T, U> where T: class, IDto where U:BaseEntity
    {
        // BLL FOR QUERIES
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        List<T> GetActives();
        List<T> GetPassives();
        List<T> GetUpdatedes();

        // BLL FOR COMMANDS
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<string> SoftDeleteAsync(int id);
        Task<string> HardDeleteAsync(int id);
    }
}
