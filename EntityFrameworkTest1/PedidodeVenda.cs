﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTest1
{
    public class PedidoDeVenda
    {
        public int Id { get; set; }
        public string Observacao { get; set; }
        public Cliente cliente { get; set; }
        public bool Valido { get; set; }
    }
}
