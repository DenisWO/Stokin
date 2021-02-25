using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stokin.Models
{
    public class ItemSale
    {
        public ItemSale()
        {
            this.Id = Guid.NewGuid();
        }

        public ItemSale(Product product, Sale sale)
        {
            this.Id = Guid.NewGuid();
            this.Product = product;
            this.Sale = sale;
            this.Price = product.Price;
            this.Quantity = 1;
        }
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Quantidade é obrigatória")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public Sale Sale { get; set; }
    }
}
