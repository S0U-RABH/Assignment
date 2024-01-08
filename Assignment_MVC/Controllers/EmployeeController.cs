using Assignment_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Assignment_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient _httpClient;
        
        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7001");
        }
        // GET: EmployeeController
        public async Task< IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Employees");
            List<Employee> list = new List<Employee>();
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<Employee>>(Convert.ToString(apiResponse));
                return View(list);
            }
            else
            {
                // Handle errors
                return View("Error");
            }
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Employees", employee);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Handle errors
                return View("Error");
            }
        }

        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"api/Employees/{id}");
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Employee item = JsonConvert.DeserializeObject<Employee>(responseContent);

                return View(item);
            }
            else
            {
                // Handle errors
                return View("Error");
            }
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee emp)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/Employees/{id}", emp);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Handle errors
                return View("Error");
            }
        }

        #region APICALL
        [HttpGet]
        public async Task<IActionResult> GetAll(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Employees");
            List<Employee> list = new List<Employee>();
            var apiResponse = await response.Content.ReadAsStringAsync();
            list = JsonConvert.DeserializeObject<List<Employee>>(Convert.ToString(apiResponse));
            return Json(new {data = list});
        }
       
        public async Task <IActionResult> Delete(int? id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/Employees/{id}");
            return RedirectToAction("Index");
        }
        #endregion
    }
}
