﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Data.Interfaces
{
    public interface IDAO : IDisposable
    {
        Task<MensagemModel> Cadastrar(EntidadeDominio Objeto);

        Task<MensagemModel> Atualizar(EntidadeDominio Objeto);

        Task<MensagemModel> Editar(EntidadeDominio Objeto);

        Task<MensagemModel> Excluir(EntidadeDominio Objeto);

        Task<MensagemModel> Consultar(EntidadeDominio Objeto);

        Task<IEnumerable<MensagemModel>> Buscar(Expression<Func<EntidadeDominio, bool>> predicate);
    }
}