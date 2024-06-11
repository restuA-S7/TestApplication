using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.WebApplication.DAL;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomer _CustomerEF;
        public CustomersController(ICustomer customerEF)
        {
            _CustomerEF = customerEF;
        }

        // GET: CustomersController
        public ActionResult Index(string customersname = "")
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            IEnumerable<Customer> customers;
            if(customersname != "")
            {
                customers = _CustomerEF.GetCustomersByNameOrCity(customersname);
            }
            else
            {
                customers = _CustomerEF.GetAll();
            }
            return View(customers);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var customer = _CustomerEF.GetById(id);
            return View(customer);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                var result = _CustomerEF.Add(customer);
                TempData["Message"] = $"Customer {customer.CustomerName} added successfully";
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                ViewBag.ErrorMessage = "Customer not added";
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _CustomerEF.GetById(id) ;
            return View(customer);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                var result = _CustomerEF.Update(customer);
                TempData["Message"] = $"Customer {customer.CustomerName} updated successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Customer not updated";
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _CustomerEF.GetById(id);
            return View(result);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int CustomerId)
        {
            try
            {
                _CustomerEF.Delete(CustomerId);
                TempData["Message"] = $"Customer with id: {CustomerId} Delete succsessfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMesage = "Customer not found";
                return View();
            }
        }
    }
}
