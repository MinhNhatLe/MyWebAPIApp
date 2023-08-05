﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using MyWebApiApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHangHoaResposity _hangHoaResposity;
        private readonly MyDBContext _context;

        public ProductsController(IHangHoaResposity hangHoaResposity, MyDBContext context)
        {
            _hangHoaResposity = hangHoaResposity;
            _context = context;
        }

        [HttpGet]
        public IActionResult GettAllProducts(string search, double? from, double? to, string sortBy, int page = 1)
        {
            try
            {
                var result = _hangHoaResposity.GetAll(search, from, to, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can't get the product.");
            }
        }



    }
}