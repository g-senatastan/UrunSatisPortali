using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ÜrünSatışPortalı.API.Models;
using ÜrünSatışPortalı.Dtos;
using ÜrünSatışPortalı.Models;

namespace ÜrünSatışPortalı.Controllers
{
        [Authorize]
        // Ürünü sepete eklemek için HTTP Post metodu
        [Route("api/ShoppingCart")]
        [ApiController]
        public class ShoppingCartItemsController : ControllerBase
        {
            
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public ShoppingCartItemsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        [HttpGet]
        public List<ShoppingCartItemDto> GetList()
        {
            string userId = GetUserId();
            var shoppingCarts = _context.ShoppingCartItems.Where(s => s.UserId == userId).ToList();
            var shoppingCartItemDtos = _mapper.Map<List<ShoppingCartItemDto>>(shoppingCarts);
            return shoppingCartItemDtos;
        }
        [HttpGet]
        [Route("{id}")]
        public ShoppingCartItemDto Get(int id)
        {
            string userId = GetUserId();
            var shopping = _context.ShoppingCartItems.Where(s => s.Id == id && s.UserId == userId).SingleOrDefault();
            var shoppingDto = _mapper.Map<ShoppingCartItemDto>(shopping);
            return shoppingDto;
        }

        [HttpPost]
        public ResultDto Post(ShoppingCartItemDto dto)
        {
            string userId = GetUserId();
            var shoppingCart = _mapper.Map<ShoppingCartItem>(dto);
            shoppingCart.UserId = userId;
            
            _context.ShoppingCartItems.Add(shoppingCart);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ürün Sepete Eklendi";
            return result;
        }

        [HttpDelete("{id}")]
        public ResultDto Delete(int id)
        {
            string userId = GetUserId();
            var shoppingCartItem = _context.ShoppingCartItems
                .Where(s => s.Id == id && s.UserId == userId).SingleOrDefault();
            if (shoppingCartItem == null)
            {
                result.Status = false;
                result.Message = "Ürün bulunamadı veya yetkiniz yok!";
                return result;
            }

            _context.ShoppingCartItems.Remove(shoppingCartItem);
            _context.SaveChanges();

            result.Status = true;
            result.Message = "Ürün Sepetten Kaldırıldı";
            return result;
        }
    }
  }

