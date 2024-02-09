using AppWebMVC.Services;
using AppWebMVC.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using AppDataBase.Data;

namespace AppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IComputerServices _computerServices;

        public ComputersController (ApplicationDbContext context, IComputerServices computerServices)  {

            _context = context;
            _computerServices = computerServices;
            
        }

        // GET: api/Computers
        [HttpGet]
        public IActionResult GetComputers()
        {
            var computers = _computerServices.GetAll();
            return Ok(computers);
        }

        // GET: api/Computers/filter
        [HttpGet("filter")]
        public IActionResult GetComputersFilter(string name)
        {
            return Ok(_context.Computers
                .Where(o => o.Name.StartsWith(name))
                .ToList());
        }

        // GET: api/Computers/5
        [HttpGet("{id}")]
        public IActionResult GetComputerById(int id)
        {
            var computer = _computerServices.GetById(id);
            if (computer == null)
            {
                return NotFound();
            }
            return Ok(computer);
        }
    }
}
