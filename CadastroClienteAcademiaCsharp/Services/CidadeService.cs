﻿using System.Collections;
using System.Collections.Generic;
using CadastroClienteAcademiaCsharp.Data;
using System.Data;
using CadastroClienteAcademiaCsharp.Domain;

namespace CadastroClienteAcademiaCsharp.Services
{
    public class CidadeService
    {
        public IEnumerable<Cidade> GetCidades()
        {
            return new CidadeRepository().GetCidades();
        }

        public IEnumerable<Cidade> GetCidadesByNome(string nome)
        {
            return string.IsNullOrEmpty(nome) ?
                GetCidades() :
                new CidadeRepository().GetCidadesByNome(nome);
        }
    }
}