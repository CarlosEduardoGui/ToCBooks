﻿using System;
using System.Linq.Expressions;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Data.Interfaces
{
    public interface IDAO : IDisposable
    {
        MensagemModel Cadastrar(EntidadeDominio Objeto);

        MensagemModel Desativar(EntidadeDominio Objeto);

        MensagemModel Ativar(EntidadeDominio Objeto);

        MensagemModel Atualizar(EntidadeDominio Objeto);

        MensagemModel Editar(EntidadeDominio Objeto);

        MensagemModel Excluir(EntidadeDominio Objeto);

        MensagemModel Consultar(EntidadeDominio Objeto);

        MensagemModel Buscar(Expression<Func<EntidadeDominio, bool>> predicate);
    }
}
