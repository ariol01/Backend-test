using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppRovemaAriel.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage=(" Este campo é obrigatório"))]
        [MinLength(3, ErrorMessage =("este campo deve conter entre 3 a 100 caracteres"))]
        [MaxLength(100, ErrorMessage =("este campo deve conter entre 3 a 100 caracteres"))]

        public string Nome  { get; set; } 
        [Required(ErrorMessage =("Este campo é obrigatório"))]       
        [Range(1, int.MaxValue, ErrorMessage =("Preco deve ser maior que zero"))]       
        public decimal Preco { get; set; }
        public ICollection<ProductCategory> ProductCategory {get;set;}

    }
}