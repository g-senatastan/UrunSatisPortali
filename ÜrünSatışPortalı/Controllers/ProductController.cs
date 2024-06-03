using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ÜrünSatışPortalı.Dtos;
using ÜrünSatışPortalı.Models;

namespace ÜrünSatışPortalı.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public ProductController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<ProductDto> GetList()
        {
            var product = _context.Products.ToList();
            var productsdto = _mapper.Map<List<ProductDto>>(product);
            return productsdto;
        }


        [HttpGet]
        [Route("{id}")]
        public ProductDto Get(int id)
        {
            var product = _context.Products.Where(s => s.Id == id).SingleOrDefault();
            var productsdto = _mapper.Map<ProductDto>(product);
            return productsdto;
        }

        [HttpPost]
        public ResultDto Post(ProductDto dto)
        {
            if (_context.Products.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Ürün Adı Kayıtlıdır!";
                return result;
            }
            var product = _mapper.Map<Product>(dto);

            _context.Products.Add(product);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ürün Eklendi";
            return result;
        }


        [HttpPut]
        public ResultDto Put(ProductDto dto)
        {
            var product = _context.Products.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (product == null)
            {
                result.Status = false;
                result.Message = "Ürün Bulunamadı!";
                return result;
            }
            product.Name = dto.Name;
            product.BrandName = dto.BrandName;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.IsActive = dto.IsActive;




            product.AltCategoryId = dto.AltCategoryId;
            _context.Products.Update(product);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ürün Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var product = _context.Products.Where(s => s.Id == id).SingleOrDefault();
            if (product == null)
            {
                result.Status = false;
                result.Message = "Ürün Bulunamadı!";
                return result;
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ürün Silindi";
            return result;
        }
    }
}
