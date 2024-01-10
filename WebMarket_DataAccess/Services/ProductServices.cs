using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebMarket_DataAccess.Services.Interface;
using WebMarket_Models;
using WebMarket_Models.ViewModels;

namespace WebMarket_DataAccess.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _db;

        public ProductServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(ProductVM entity)
        {
            _db.Products.Add(entity.Product);
            _db.SaveChanges();
        }
        public void Update(Product obj)
        {
            _db.Products.Update(obj);
            _db.SaveChanges();
        }
        public void Remove(Product entity)
        {
            _db.Products.Remove(entity);
            _db.SaveChanges();
        }
        public void RemoveRange(IEnumerable<Product> entities)
        {
            _db.Products.RemoveRange(entities);
            _db.SaveChanges();
        }
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> query = _db.Products.Include(c => c.Category);
            return query;
        }
        public Product GetFirstOrDefaulte(Expression<Func<Product, bool>> filter)
        {
            IQueryable<Product> query = _db.Products;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
    }
}
