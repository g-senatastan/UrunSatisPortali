using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ÜrünSatışPortalı.UI.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly IConfiguration _configuration;


        public AdminController(IConfiguration configuration)
        {


            _configuration = configuration;


        }


        public IActionResult Index()
        {
            return View();
        }

        [Route("Users")]
        public IActionResult AdminUser()
        {
            string ApiBaseUrl = _configuration["ApiBaseUrl"]!;
            ViewBag.ApiBaseUrl = ApiBaseUrl;
            return View();
        }

        [Route("Roles")]
        public IActionResult AdminRole()
        {
            string ApiBaseUrl = _configuration["ApiBaseUrl"]!;
            ViewBag.ApiBaseUrl = ApiBaseUrl;
            return View();
        }

        [Route("AdminCategories")]
        public IActionResult AdminCategories()
        {
            string ApiBaseUrl = _configuration["ApiBaseUrl"]!;
            ViewBag.ApiBaseUrl = ApiBaseUrl;
            return View();
        }
        
        [Route("AdminAltCategories")]
        public IActionResult AdminAltCategories()
        {
            string ApiBaseUrl = _configuration["ApiBaseUrl"]!;
            ViewBag.ApiBaseUrl = ApiBaseUrl;
            return View();
        }

        [Route("AdminProducts")]
        public IActionResult AdminProducts()
        {
            string ApiBaseUrl = _configuration["ApiBaseUrl"]!;
            ViewBag.ApiBaseUrl = ApiBaseUrl;
            return View();
        }

        

        public async Task<IActionResult> GetRoleList()
        {

            return View();
        }

        public IActionResult RoleAdd()
        {
            return View();
        }
    }
}
