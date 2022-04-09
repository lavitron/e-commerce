using Business.Abstract;
using Entity.Dto.Product;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{productId:int}")]
    public async Task<IActionResult> GetById(int productId)
    {
        try
        {
            var result = await _productService.Get(productId);
            return Ok(result);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        try
        {
            var result = await _productService.GetList();
            if (!result.Any()) return NotFound();

            return Ok(result);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductAddDto productAddDto)
    {
        try
        {
            var result = await _productService.Add(productAddDto);
            return result switch
            {
                > 0 => Ok("İşlem başarılı"),
                _ => BadRequest("İşlem sırasında hata meydana geldi"),
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
    {
        try
        {
            var result = await _productService.Update(productUpdateDto);
            return result switch
            {
                > 0 => Ok("İşlem başarılı"),
                _ => BadRequest("İşlem sırasında hata meydana geldi"),
            };
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(ProductDeleteDto productDeleteDto)
    {
        try
        {
            var result = await _productService.Delete(productDeleteDto);
            return result switch
            {
                > 0 => Ok("İşlem başarılı"),
                _ => BadRequest("İşlem sırasında hata meydana geldi"),
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
