using Microsoft.AspNetCore.Mvc;
using Visual_Capture.BLL.Entities;
using Visual_Capture.Contracts;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;

namespace Visual_Capture.BLL.Manager;

public class CustomerManager
{
    private readonly IManagerDal<CustomerDTO> _customersManagerDal;

        public CustomerManager(IManagerDal<CustomerDTO> customersManagerDal)
        {
            _customersManagerDal = customersManagerDal;
        }

        
        //Get Single data 
        public CustomerDTO? GetOne(Guid? id)
        {
            CustomerDTO? obj = _customersManagerDal.Get(id);
            return obj;
        }


        //Get All data 
        public List<CustomerDTO> GetAll()
        {
            List<CustomerDTO> obj = _customersManagerDal.GetAll();
            return obj;
        }
        
        //GET
        [HttpPost]
        public void Create(CustomerDTO obj)
        {
            _customersManagerDal.Create(obj);
        }

        //GET
        [HttpPost]
        public void Edit(CustomerDTO obj)
        {
            _customersManagerDal.Edit(obj);
        }

        public bool Delete(Guid id)
        {
            //get object
            var customersFromDb = _customersManagerDal.Delete(id);

            if (customersFromDb)
            {
                return true;
            }

            return false;
            // return RedirectToAction("Index");
        }
}