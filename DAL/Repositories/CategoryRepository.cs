using DAL.Classes;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CategoryRepository : IRepository<Category>
{
    private HotelDbContext _dbContext;
    private bool _disposed = false;


    public CategoryRepository(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Category> GetAll()
    {
        return _dbContext.Categories;
    }

    public Category GetItem(int id)
    {
        var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
        if (category != null) 
            return category;
        throw new KeyNotFoundException();
    }

    public void Create(Category item)
    {
        _dbContext.Categories.Add(item);
    }
    
    public IEnumerable<Category> Where(Func<Category, bool> predicate)
    {
        return _dbContext.Categories.Where(predicate);
    }

    public void Update(Category item)
    {
        _dbContext.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
            _dbContext.Categories.Remove(category);
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
    
    public virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
                _dbContext.Dispose();
            _disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}