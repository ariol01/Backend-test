using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppRovemaAriel.Data;
using AppRovemaAriel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppRovemaAriel.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        
        /// <summary>
        /// cria varias categorias ao produto To-do list.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="productId">Id do produto</param>
        /// <param name="ListCategoryProduct">informe o id de cada categoria</param>
        /// <remarks>
        /// Exemplo:
        ///  [ 1,2,3,4,5 ]
        /// </remarks>
        /// <returns>Produto com várias categorias</returns>
         [HttpPost("{productId}/product")]
        public async Task<IActionResult> AddProductCategories([FromServices] DataContext context,
            int productId, [FromBody] params int[] ListCategoryProduct)
        {
            if (ModelState.IsValid)
            {
                try
                {                 
                    var product = await context.Products.Include(x=>x.ProductCategory).FirstOrDefaultAsync(x=>x.ProductId == productId);
                    if (product.ProductCategory ==  null)
                    {
                        product.ProductCategory = new List<ProductCategory>();
                    }
                    foreach (var categoryId in ListCategoryProduct)
                    {
                          var modelProductCategory = new ProductCategory();
                          var category = await context.Categories.FindAsync(categoryId); 
                          if (category == null || product.ProductCategory.Any(x=>x.CategoryId == categoryId))
                          {
                              continue;
                          }                         
                          modelProductCategory.CategoryId = category.CategoryId;                          
                          modelProductCategory.ProductId = productId;                      
                          product.ProductCategory.Add(modelProductCategory);
                           
                    }
                    
                     context.Update(product);
                     await context.SaveChangesAsync();
                    return Ok(product);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return BadRequest();           
        }
       
    }
}