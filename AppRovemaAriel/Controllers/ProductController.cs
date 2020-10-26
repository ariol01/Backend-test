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

    public class ProductController : ControllerBase
    {
        /// <summary>
        /// lista os produtos  da To-do list.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>Os itens da to-do list</returns>
        /// <response code="200">Returna os produtos da To-do list cadastrados</response>

        [HttpGet]       
        public async Task<ActionResult<List<Product>>> Get ([FromServices] DataContext context)
        {     
          
           if (ModelState.IsValid)
            {
                var products  = await context.Products.Include(x=>x.ProductCategory).ThenInclude(x=>x.Category).ToListAsync();   

                if (products != null)
                {
                    var produtcsOnlyCategories =  products.Select(x=> 
                    {   
                        var listaCategoria =  x?.ProductCategory.Where(x=>x.Category != null).Select(x=> new { x.Category.CategoryId, x.Category.Descricao });
                        var produto =  new 
                        { 
                            x.ProductId, x.Nome, x.Preco, categoria = listaCategoria
                        };
                        return produto;                      
                    }
                );


                    return Ok(produtcsOnlyCategories);
                }           
                     

            }

            return NotFound();        
        
        }

        /// <summary>
        /// lista um produto na To-do List. 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="Id">informe o id do produto</param>
        /// <returns>um produto cadastrado</returns>
         /// <response code="200">Returna um  produto  pelo id informado</response>
        /// <response code="400">Se o item não for encontrado</response>
        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<Product>> GetById ([FromServices] DataContext context, int Id)
        {     
          
           if (ModelState.IsValid)
            {
               
                var product  = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x=>x.ProductId == Id);
                return Ok(product);
            }

            return NotFound();        
        
        }
        /// <summary>
        /// cria um produtona To-do list.
        /// </summary>
        /// <remarks> 
        /// Exemplo:
        ///     {
         /// 
        ///  "name": "canetea azul",
        /// "preco": 1870.50
        ///     }
        /// </remarks>
        /// <param name="context"></param>
        /// <param name="model"></param>
        /// <returns>Um novo produto criado</returns>
        /// <response code="200">Returna um  produto cadastrado </response>
        /// <response code="400">Caso o post falhe</response>
         [HttpPost]        
        public async Task<ActionResult<Product>> Post ([FromServices] DataContext context, [FromBody] Product model)
        {     
      
          if (ModelState.IsValid)
            {
                try
                {
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }         
             return BadRequest();
        }
     /// <summary>
     /// remove um produto na To-do list.
     /// </summary>
     /// <param name="context"></param>
    /// <param name="Id">informe o id  do produto</param>
    /// <returns>O  produto que acabou de ser deletado</returns>
    ///  <response code="200">Returna o produto que acabou de ser removido </response>
    /// <response code="400">Caso a removacao falhe</response>
        [HttpDelete]
        [Route("{Id}")]
         public async Task<ActionResult<Product>> Delete ([FromServices] DataContext context, int Id)
        {     
      
          if (ModelState.IsValid)
            {
               var product = await context.Products.FirstOrDefaultAsync(x=>x.ProductId == Id);
               context.Remove(product);
               await context.SaveChangesAsync();
               return Ok(product);
            }         
             return BadRequest();
        }

        /// <summary>
        /// Edita um produto na To-do List.
        /// </summary>
        /// <remarks>         
        ///    "minha nova descricao do produto"       
        ///  
        /// </remarks>
        /// <param name="context"></param>
        /// <param name="Id">informa o id do produto </param>
        /// <param name="descricao">nova descricao do produto</param>
        /// <returns>O produto que foi alterado</returns>
        ///  <response code="200">Returna um  produto alterado </response>
        /// <response code="400">Caso a alteracao falhe</response>
        [HttpPut]
        [Route("{Id}")]
         public async Task<ActionResult<Product>> Edit ([FromServices] DataContext context, int Id, [FromBody] string descricao )
        {     
      
               var product = await context.Products.FirstOrDefaultAsync(x=>x.ProductId == Id);
               if (product != null)
               {
                    product.Nome = descricao;
                    context.Update(product);
                    await context.SaveChangesAsync();
                    return Ok(product);
               }               
                    
             return BadRequest();
        }
        
    }
}