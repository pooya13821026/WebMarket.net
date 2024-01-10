using System.Linq.Expressions;
using WebMarket_Models;

namespace WebMarket_DataAccess.Services.Interface
{
    public interface ICategoryServices
    {
        void Add(Category entity);
        IEnumerable<Category> GetAll();
        Category GetFirstOrDefaulte(Expression<Func<Category, bool>> filter);
        void Remove(Category entity);
        void RemoveRange(IEnumerable<Category> entities);
        void Update(Category category);
    }
}
