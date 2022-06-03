using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.DAL.Data;

public class CustomerManagerDal : IManagerDal<CustomerDTO> 
{
    private readonly ApplicationDbContext _db;

    public CustomerManagerDal(ApplicationDbContext db)
    {
        _db = db;
    }

    public CustomerDTO Get(Guid? id)
    {
        return _db.Customers.Find(id);
    }
    
    //Get
    public List<CustomerDTO> GetAll()
    {
        return _db.Customers.ToList();
    }

    //Create
    public bool Create(CustomerDTO obj)
    {
        _db.Customers.Add(obj);
        _db.SaveChanges();
        
        return true;
    }


    //get edit/id data
    public object Edit(Guid? id)
    {
        return _db.Customers.Find(id)!;
    }

    //save changes (update item)
    public bool Edit(CustomerDTO obj)
    {
        _db.Customers.Update(obj);
        _db.SaveChanges();
        
        return true;
    }

    //Delete

    //get delete/id data
    public bool Delete(Guid? id)
    {
        var customerFromDb = _db.Customers.Find(id);

        //just in case someone deleted at the same time.
        if (customerFromDb == null)
        {
            return false;
        }

        //actually remove from the database
        _db.Customers.Remove(customerFromDb);
        _db.SaveChanges();

        return true;
    }
}