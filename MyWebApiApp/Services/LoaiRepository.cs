using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public class LoaiRepository : ILoaiRepository
    {
        private readonly MyDBContext _context;

        public LoaiRepository(MyDBContext context) {
            _context = context;
        }
        public LoaiVM Add(LoaiModel loai)
        {
            // gán Loai chính
            var _loai = new Loai
            {
                TenLoai = loai.TenLoai
            };
            _context.Add(_loai);
            _context.SaveChanges();
            // trả về loại mong muốn
            return new LoaiVM
            {
                MaLoai = _loai.MaLoai,
                TenLoai = _loai.TenLoai,
            };
        }

        public void Delete(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo =>  lo.MaLoai == id);
            if (loai != null)
            {
                _context.Loais.Remove(loai);
                _context.SaveChanges();
            }
        }

        public List<LoaiVM> GetAll()
        {
            var loais = _context.Loais.Select(lo => new LoaiVM
            {
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai
            });
            return loais.ToList();

        }

        public LoaiVM GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                return new LoaiVM
                {
                    MaLoai = loai.MaLoai,
                    TenLoai = loai.TenLoai,
                };
            }
            return null;
        }


        public void Update(LoaiVM loai)
        {
            var _loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == loai.MaLoai);
            if (_loai != null)
            {
                _loai.TenLoai = loai.TenLoai;
                _context.SaveChanges();
            }
        }
    }
}
