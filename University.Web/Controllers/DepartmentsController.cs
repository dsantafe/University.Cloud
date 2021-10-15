using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using University.BL.DTOs;
using University.BL.Helpers;
using University.BL.Services.Implements;

namespace University.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ApiService apiService = new ApiService();

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var responseDTO = await apiService.RequestAPI<List<DepartmentOutputDTO>>(Endpoints.URL_BASE,
                Endpoints.GET_DEPARTMENTS,
                null,
                ApiService.Method.Get,
                false);

            var departments = (List<DepartmentOutputDTO>)responseDTO.Data;
            return View(departments);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await GetInstructors();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentDTO departmentDTO)
        {
            await GetInstructors();

            if (!ModelState.IsValid)
                return View(departmentDTO);

            try
            {
                var responseDTO = await apiService.RequestAPI<DepartmentDTO>(Endpoints.URL_BASE,
                        Endpoints.POST_DEPARTMENTS,
                        departmentDTO,
                        ApiService.Method.Post,
                        false);

                if (responseDTO.Code == (int)HttpStatusCode.Created)
                    return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(departmentDTO);
        }

        private async Task GetInstructors()
        {
            var responseDTO = await apiService.RequestAPI<List<InstructorOutputDTO>>(Endpoints.URL_BASE,
                Endpoints.GET_INSTRUCTORS,
                null,
                ApiService.Method.Get,
                false);

            var instructors = (List<InstructorOutputDTO>)responseDTO.Data;
            ViewData["instructors"] = new SelectList(instructors, "ID", "FullName");
        }
    }
}
