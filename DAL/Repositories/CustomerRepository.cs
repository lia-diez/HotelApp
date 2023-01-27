using DAL.Classes;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CustomerRepository : IRepository<Customer>
{
    private HotelDbContext _dbContext;
    private bool _disposed = false;


    public CustomerRepository(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Customer> GetAll()
    {
        return _dbContext.Customers;
    }

    public Customer GetItem(int id)
    {
        var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
        if (customer != null) 
            return customer;
        throw new Exception();    
    }

    public void Create(Customer item)
    {
        _dbContext.Customers.Add(item);
    }

    public void Update(Customer item)
    {
        _dbContext.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var customer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
        if (customer != null)
            _dbContext.Customers.Remove(customer);
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