using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Pedido
    {
        [Key]
        public int PedidoID { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Required]
        [Display(Name = "Número")]
        public int Numero { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Itens { get; set; }
        [Required]
        [Display(Name = "Forma de pagamento")]
        public string FormaPagamento { get; set; }
    }
}
