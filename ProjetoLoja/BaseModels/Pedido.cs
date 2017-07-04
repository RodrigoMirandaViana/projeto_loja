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
        [DataType(DataType.MultilineText)]
        public string Itens { get; set; }
    }
}
