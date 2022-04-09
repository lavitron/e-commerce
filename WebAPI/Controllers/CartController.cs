using Business.Abstract;
using Entity.Dto.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CartAddDto cartAddDto)
        {
            try
            {
                var result = await _cartService.Add(cartAddDto);
                switch (result.Result)
                {
                    case > 0:
                        return Ok(new { message = "İşlem başarılı.", remained = result.TotalRemainedCount });
                    case -1:
                        return BadRequest(new { message = "Talep edilen miktarda ürün bulunmamaktadır.", remained = result.TotalRemainedCount });
                    default:
                        return BadRequest("İşlem sırasında hata meydana geldi.");
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
