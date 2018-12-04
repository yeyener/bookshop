using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static bookshop.Core.SessionExtensions;

namespace bookshop.Controllers
{
    [RouteAttribute("api/frontPage")]
    public class FrontPageController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public FrontPageController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("addToCart")]
        public async Task<IActionResult> AddToCart([FromBody]int bookId)
        {
            var cartItems = httpContextAccessor.HttpContext.Session.Get<List<int>>("cart");
            if (cartItems == null)
                cartItems = new List<int>();

            cartItems.Add(bookId);

            httpContextAccessor.HttpContext.Session.Set<List<int>>("cart",cartItems);
                                
            return Ok(cartItems);
        }
    }
}