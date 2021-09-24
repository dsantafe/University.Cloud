using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using University.BL.DTOs;
using University.BL.Services.Implements;

namespace University.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApiService apiService = new ApiService();

        public async Task<IActionResult> Index()
        {
            var responseDTO = await apiService.RequestAPI<List<StudentOutputDTO>>("https://university-api.azurewebsites.net/",
                "api/Students/GetStudents/",
                null,
                ApiService.Method.Get,
                false);

            var students = (List<StudentOutputDTO>)responseDTO.Data;
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new StudentDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDTO studentDTO)
        {
            var responseDTO = await apiService.RequestAPI<StudentDTO>("https://university-api.azurewebsites.net/",
                "api/Students/",
                studentDTO,
                ApiService.Method.Post,
                false);

            if (responseDTO.Code == (int)HttpStatusCode.Created)
                return RedirectToAction(nameof(Index));

            return View(studentDTO);
        }
    }
}
