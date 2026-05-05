using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Application.DTO;
using Template.Application.Features.Interface;
using Template.Domain.Entities.Commerce;

namespace Template.API.Controllers.Commerce
{
    [Route("api/commerce/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] CartItem item)
        {
            var updatedCart = await _cartService.AddItemAsync(item);
            return Ok(updatedCart);
        }

        [HttpPut("update/quantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateCartDto request)
        {
            var cart = await _cartService.UpdateProductQuantityAsync(request);
            return Ok(cart);
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var cart = await _cartService.GetCartAsync();
            return Ok(cart);
        }

        [HttpDelete("remove/item/{productId}")]
        public async Task<IActionResult> RemoveItem(int productId)
        {
            try
            {
                var cart = await _cartService.RemoveItemAsync(productId);
                return Ok(cart);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            try
            {
                await _cartService.ClearCartAsync();
                return Ok("Cleared");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
