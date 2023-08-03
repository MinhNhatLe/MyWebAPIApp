﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hangHoas = new List<HangHoa>();


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hangHoas);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if(hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,  
                DonGia = hangHoaVM.DonGia
            };

            hangHoas.Add(hanghoa);
            return Ok(new
            {
                Success = true,
                Data = hanghoa
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, HangHoa hangHoaEdit)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hangHoa == null)
                {
                    return NotFound ();
                }

                if(id != hangHoa.MaHangHoa.ToString())
                {
                    return BadRequest ();
                }
                hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                hangHoa.DonGia = hangHoaEdit.DonGia;
                return Ok(hangHoa);
            }
            catch (Exception ex)
            {
                return BadRequest (ex); 
            }
            
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if(hangHoa == null)
                {
                    return NotFound ();
                }
                hangHoas.Remove(hangHoa);
                return Ok(hangHoa);
            }
            catch(Exception ex)
            {
                    return BadRequest (ex);
            }
        }
    }
}
