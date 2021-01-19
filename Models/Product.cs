using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stokin.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é inválido")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Código de Barras é inválido")]
        [Display(Name = "Código de Barras")]
        [StringLength(14, ErrorMessage = "Máximo de 14 caracteres")]
        [MinLength(1, ErrorMessage = "Código de Barras não pode ser vazio")]
        public string Barcode { get; set; }
        
        [Required(ErrorMessage = "Preço de Custo é inválido")]
        [Display(Name = "Preço de Custo")]
        [DataType(DataType.Currency, ErrorMessage = "Preço de Custo deve ser um valor")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Preço de Venda é inválido")]
        [Display(Name = "Preço de Venda")]
        [DataType(DataType.Currency, ErrorMessage = "Preço de Venda deve ser um valor")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Estoque é inválido")]
        [Display(Name = "Estoque")]
        public decimal Stock { get; set; }

    }
}
