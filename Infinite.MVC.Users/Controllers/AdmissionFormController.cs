using Infinite.MVC.Users.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infinite.MVC.Users.Controllers
{
    public class AdmissionFormController : Controller
    {
        private readonly IConfiguration _configuration;
        public AdmissionFormController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            List<FormViewModel> forms = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(_configuration["ApiUrl:api"]);
                var result = await client.GetAsync("AdmissionForm/GetAllForms");
                if (result.IsSuccessStatusCode)
                {
                    forms = await result.Content.ReadAsAsync<List<FormViewModel>>();
                }

            }
            return View(forms);
        }
        //[Route("AdmissionForm/Details/{Id}")]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            FormViewModel form = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["ApiUrl:api"]);
                var result = await client.GetAsync($"AdmissionForm/GetAdmissionFormById/{id}");
                if (result.IsSuccessStatusCode)
                {
                    form = await result.Content.ReadAsAsync<FormViewModel>();
                    
                }
            }
            return View(form);
        }



        public async Task<IActionResult> Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(FormViewModel form)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration["ApiUrl:api"]);
                    var result = await client.PostAsJsonAsync("AdmissionForm/CreateForm", form);
                    if (result.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            if (ModelState.IsValid)
            {
                FormViewModel form = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration["ApiUrl:api"]);
                    var result = await client.GetAsync($"AdmissionForm/GetFormsById/{id}");
                    if (result.IsSuccessStatusCode)
                    {
                        form = await result.Content.ReadAsAsync<FormViewModel>();
                        return View(form);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Form doesn't exists");
                    }
                }
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Edit(FormViewModel form)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                    client.BaseAddress = new Uri(_configuration["ApiUrl:api"]);
                    var result = await client.PutAsJsonAsync($"AdmissionForm/UpdateForm/{form.Id}", form);
                    if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            FormViewModel form = await this.FormById(id);
            if (form != null)
            {
                return View(form);
            }
            ModelState.AddModelError("", "Server Error. Please try later");
            return View(form);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(FormViewModel form)
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
                client.BaseAddress = new System.Uri(_configuration["ApiUrl:api"]);
                var result = await client.DeleteAsync($"AdmissionForm/DeleteForm/{form.Id}");
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [NonAction]
        public async Task<FormViewModel> FormById(int id)
        {
            FormViewModel form = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(_configuration["ApiUrl:api"]);
                var result = await client.GetAsync($"AdmissionForm/GetFormsById/{id}");
                if (result.IsSuccessStatusCode)
                {
                    form = await result.Content.ReadAsAsync<FormViewModel>();
                }
            }
            return form;
        }
    }
}

