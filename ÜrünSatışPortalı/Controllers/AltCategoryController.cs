using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ÜrünSatışPortalı.API.Dtos;
using ÜrünSatışPortalı.API.Models;
using ÜrünSatışPortalı.Dtos;
using ÜrünSatışPortalı.Models;

namespace ÜrünSatışPortalı.Controllers
{
    [Route("api/AltCategories")]
    [ApiController]
    public class AltCategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public AltCategoryController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<AltCategoryDto> GetList()
        {
            var AltCategories = _context.AltCategories.ToList();
            var AltCategoriesDtos = _mapper.Map<List<AltCategoryDto>>(AltCategories);
            return AltCategoriesDtos;
        }

        [HttpGet]
        [Route("{id}")]
        public AltCategoryDto Get(int id)
        {
            var survey = _context.AltCategories.Where(s => s.Id == id).SingleOrDefault();
            var AltCategoryDto = _mapper.Map<AltCategoryDto>(survey);
            return AltCategoryDto;
        }

        [HttpGet]
        [Route("{id}/Products")]
        public List<ProductDto> GetQuestion(int id)
        {
            var products = _context.Products.Where(q => q.AltCategoryId == id).ToList();
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return productDtos;
        }

        [HttpPost]
        public ResultDto Post(AltCategoryDto dto)
        {
            if (_context.AltCategories.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Alt Kategori Adı Kayıtlıdır!";
                return result;
            }
            var product = _mapper.Map<AltCategory>(dto);
            product.Updated = DateTime.Now;
            product.Created = DateTime.Now;
            _context.AltCategories.Add(product);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Alt Kategori Eklendi";
            return result;
        }


        [HttpPut]
        public ResultDto Put(AltCategoryDto dto)
        {
            var product = _context.AltCategories.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (product == null)
            {
                result.Status = false;
                result.Message = "Alt Kategori Bulunamadı!";
                return result;
            }
            product.Name = dto.Name;
            product.IsActive = dto.IsActive;

            product.Updated = DateTime.Now;
            product.CategoryId = dto.CategoryId;
            _context.AltCategories.Update(product);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Alt Kategori Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var survey = _context.AltCategories.Where(s => s.Id == id).SingleOrDefault();
            if (survey == null)
            {
                result.Status = false;
                result.Message = "Alt Kategori Bulunamadı!";
                return result;
            }
            _context.AltCategories.Remove(survey);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Alt Kategori Silindi";
            return result;
        }
    }
}
