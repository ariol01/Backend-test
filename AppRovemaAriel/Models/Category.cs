using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppRovemaAriel.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage=(" Este campo é obrigatório"))]
        [MinLength(3, ErrorMessage =("este campo deve conter entre 3 a 200 caracteres"))]
        [MaxLength(200, ErrorMessage =("este campo deve conter entre 3 a 200 caracteres"))]

        public string Descricao { get; set; }
        public ICollection<ProductCategory> ProductCategory {get;set;}
    }
}