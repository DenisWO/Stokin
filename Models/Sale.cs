using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stokin.Models
{
    public class Sale
    {
        public Sale()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Valor é obrigatório")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor Total")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Cliente é obrigatório")]
        [Display(Name = "Cliente")]
        public Client Client { get; set; }

        [Required(ErrorMessage ="Data é obrigatória")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Emissão")]
        public DateTime DateSale { get; set; }

        [Display(Name = "Itens")]
        [Required(ErrorMessage ="Itens são obrigatórios")]
        public List<ItemSale> Items { get; set; }
    }
}
