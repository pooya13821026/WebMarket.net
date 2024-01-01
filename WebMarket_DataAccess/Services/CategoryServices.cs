using System.Linq.Expressions;
using WebMarket_DataAccess.Services.Interface;
using WebMarket_Models;

namespace WebMarket_DataAccess.Services
{
    public class CategoryServices : ICategoryServicess   
    {
        private readonly ApplicationDbContext _db;

        public CategoryServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Category entity)
        {
            _db.Categories.Add(entity);
            _db.SaveChanges();
        }
        public void Update(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
        }
        public void Remove(Category entity)
        {
            _db.Categories.Remove(entity);
            _db.SaveChanges();
        }
        public void RemoveRange(IEnumerable<Category> entities)
        {
            _db.Categories.RemoveRange(entities);
            _db.SaveChanges();
        }
        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> query = _db.Categories;
            return query;
        }
        public Category GetFirstOrDefaulte(Expression<Func<Category, bool>> filter)
        {
            IQueryable<Category> query = _db.Categories;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
    }
}
