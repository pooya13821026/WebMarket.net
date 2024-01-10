using System.Linq.Expressions;
using WebMarket_DataAccess.Services.Interface;
using WebMarket_Models;

namespace WebMarket_DataAccess.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ApplicationDbContext _CategoryServices;

        public CategoryServices(ApplicationDbContext CategoryServices)
        {
            _CategoryServices = CategoryServices;
        }
        public void Add(Category entity)
        {
            _CategoryServices.Categories.Add(entity);
            _CategoryServices.SaveChanges();
        }
        public void Update(Category category)
        {
            _CategoryServices.Categories.Update(category);
            _CategoryServices.SaveChanges();
        }
        public void Remove(Category entity)
        {
            _CategoryServices.Categories.Remove(entity);
            _CategoryServices.SaveChanges();
        }
        public void RemoveRange(IEnumerable<Category> entities)
        {
            _CategoryServices.Categories.RemoveRange(entities);
            _CategoryServices.SaveChanges();
        }
        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> query = _CategoryServices.Categories;
            return query;
        }
        public Category GetFirstOrDefaulte(Expression<Func<Category, bool>> filter)
        {
            IQueryable<Category> query = _CategoryServices.Categories;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
    }
}
