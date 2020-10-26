using System.ComponentModel.DataAnnotations;

namespace AppRovemaAriel.Models
{
    public class ProductCategory
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }   
        [Range(1, int.MaxValue, ErrorMessage =("Não é possível inserir categoria já existe para esse produto."))]     
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}