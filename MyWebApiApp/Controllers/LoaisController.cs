using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {
        private readonly MyDBContext _context;

        public LoaisController(MyDBContext context) {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll() {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.FirstOrDefault(lo => lo.MaLoai == id);
            if(loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai()
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateLoaiById(LoaiModel model,int id)
        {
            var loai = _context.Loais.FirstOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteLoaiById(int id)
        {
            var loai = _context.Loais.FirstOrDefault(lo => lo.MaLoai == id);
            if(loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound(id);
            }
        }
    }
}
