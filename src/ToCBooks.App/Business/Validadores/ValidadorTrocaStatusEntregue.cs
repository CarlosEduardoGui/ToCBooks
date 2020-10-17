﻿using System;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorTrocaStatusTrocaAutorizada : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {
            if (Objeto == null)
                throw new Exception("Objeto inválido");

            var Mensagem = new MensagemModel();

            if (Objeto.StatusAtual == ETipoStatus.Entregue)
            {
                Mensagem.Codigo = ETipoCodigo.Correto;
                Mensagem.Resposta = "Correto";

            }

            return Mensagem;
        }
    }
}