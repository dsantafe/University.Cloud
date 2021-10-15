using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using University.BL.DTOs;
using University.BL.Helpers;
using University.BL.Services.Implements;

namespace University.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApiService apiService = new ApiService();

        public async Task<IActionResult> Index()
        {
            var responseDTO = await apiService.RequestAPI<List<StudentOutputDTO>>(Endpoints.URL_BASE,
                Endpoints.GET_STUDENTS,
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
            var responseDTO = await apiService.RequestAPI<StudentDTO>(Endpoints.URL_BASE,
                Endpoints.POST_STUDENTS,
                studentDTO,
                ApiService.Method.Post,
                false);

            if (responseDTO.Code == (int)HttpStatusCode.Created)
                return RedirectToAction(nameof(Index));

            return View(studentDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //api/Students/GetStudent/{id}
            var responseDTO = await apiService.RequestAPI<StudentOutputDTO>(Endpoints.URL_BASE,
                Endpoints.GET_STUDENT + id,
                null,
                ApiService.Method.Get,
                false);

            var student = (StudentOutputDTO)responseDTO.Data;

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentOutputDTO studentDTO)
        {
            var responseDTO = await apiService.RequestAPI<StudentDTO>(Endpoints.URL_BASE,
                Endpoints.PUT_STUDENTS + studentDTO.ID,
                studentDTO,
                ApiService.Method.Put,
                false);

            if (responseDTO.Code == (int)HttpStatusCode.NoContent)
                return RedirectToAction(nameof(Index));

            return View(studentDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            //api/Students/GetStudent/{id}
            var responseDTO = await apiService.RequestAPI<StudentOutputDTO>(Endpoints.URL_BASE,
                Endpoints.GET_STUDENT + id,
                null,
                ApiService.Method.Get,
                false);

            var student = (StudentOutputDTO)responseDTO.Data;

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(StudentOutputDTO studentDTO)
        {            
            var responseDTO = await apiService.RequestAPI<StudentOutputDTO>(Endpoints.URL_BASE,
                Endpoints.DELETE_STUDENTS + studentDTO.ID,
                null,
                ApiService.Method.Delete,
                false);

            if (responseDTO.Code == (int)HttpStatusCode.NoContent)
                return RedirectToAction(nameof(Index));

            return View(studentDTO);
        }
    }
}
