using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppMvcBasica.Models
{
    public class Produto : Entity
    {
        public Guid FornecedorId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCdastro { get; set; }
        public bool Ativo { get; set; }

        /* Ef Relations (N produtos => 1 Fornecedor) */
        public Fornecedor Fornecedor { get; set; }
    }
}
