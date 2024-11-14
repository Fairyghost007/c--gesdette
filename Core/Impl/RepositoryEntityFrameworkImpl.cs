using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cours.Core
{
    public interface RepositoryEntityFrameworkImpl<T>
    {
        Task<List<T>> SelectAll();
        Task<T?> SelectById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
