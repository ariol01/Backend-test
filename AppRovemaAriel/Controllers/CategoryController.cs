using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppRovemaAriel.Data;
using AppRovemaAriel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppRovemaAriel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        /// <summary>
        /// lista as categorias  da To-do list.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>As Categorias da to-do list</returns>
        /// <response code="200">Returna as categorias da To-do list cadastrados</response>
         /// <response code="200">Returna um  produto com varias categorias </response>
        /// <response code="400">Caso o post falhe</response> 

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get ([FromServices] DataContext context)
        {     
          
           if (ModelState.IsValid)
            {
                var categories  = await context.Categories.ToListAsync();
                if (categories != null)
                {
                    return Ok(categories);
                }
            }

            return NotFound();        
        
        }
       /// <summary>
        /// cria uma categoria To-do list.
        /// </summary>
        /// <remarks> 
        /// Exemplo:
        ///     {
        ///          
        ///  "descricao": "Frios e Gelados"
        ///     }
        /// </remarks>
        /// <param name="context"></param>
        /// <param name="model"></param>
        /// <returns>Uma nova catgoria criado</returns>
        /// <response code="200">Returna uma categoria cadastrada </response>
        /// <response code="400">Caso o post falhe</response>

        [HttpPost]        
        public async Task<ActionResult<Category>> Post ([FromServices] DataContext context, [FromBody] Category model)
        {     
      
          if (ModelState.IsValid)
            {
                try
                {
                context.Categories.Add(model);
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
        /// Edita uma categoria na To-do List.
        /// </summary>
        /// <remarks>         
        ///    "nova descricao do categoria"       
        ///  
        /// </remarks>
        /// <param name="context"></param>
        /// <param name="Id">informa o id da categoria </param>
        /// <param name="descricao">nova descricao da categoria</param>
        /// <returns>A categoria que foi alterado</returns>
        ///  <response code="200">Returna uma categoria alterada </response>
        /// <response code="400">Caso a alteracao falhe</response>
        
         [HttpPut]
        [Route("{Id}")]
         public async Task<ActionResult<Category>> Edit ([FromServices] DataContext context, int Id, [FromBody] string descricao )
        {     
      
               var category = await context.Categories.FirstOrDefaultAsync(x=>x.CategoryId == Id);
               if (category != null)
               {
                    category.Descricao = descricao;
                    context.Update(category);
                    await context.SaveChangesAsync();
                    return Ok(category);
               }               
                    
             return BadRequest();
        }

         /// <summary>
        /// remove uma catgoria na To-do list.
        /// </summary>
         /// <param name="context"></param>
        /// <param name="Id">informe o id  da categoria</param>
        /// <returns> A Categoria removida</returns>
        ///  <response code="200">Returna a categoria  removida </response>
         /// <response code="400">Caso a remocao falhe</response>


        [HttpDelete]
        [Route("{Id}")]
         public async Task<ActionResult<Category>> Delete ([FromServices] DataContext context, int Id)
        {     
      
          if (ModelState.IsValid)
            {
               var category = await context.Categories.FirstOrDefaultAsync(x=>x.CategoryId == Id);
               context.Remove(category);
               await context.SaveChangesAsync();
               return Ok(category);
            }         
             return BadRequest();
        }

    }
}