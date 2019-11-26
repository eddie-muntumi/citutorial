using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public GradeController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllGrades()
        {
            try
            {
                var grades = _repository.Grade.GetAllGrades();

                return Ok(grades);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return StatusCode(500, "Internal server error");
            }
        }
    }
}