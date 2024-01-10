using System.Linq.Expressions;
using WebMarket_Models;
using WebMarket_Models.ViewModels;

namespace WebMarket_DataAccess.Services.Interface
{
    public interface IProductServices
    {
        void Add(ProductVM entity);
        IEnumerable<Product> GetAll();
        Product GetFirstOrDefaulte(Expression<Func<Product, bool>> filter);
        void Remove(Product entity);
        void RemoveRange(IEnumerable<Product> entities);
        void Update(Product product);
    }
}
