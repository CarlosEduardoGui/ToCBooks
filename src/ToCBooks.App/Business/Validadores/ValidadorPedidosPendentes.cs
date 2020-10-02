using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Business.Interfaces;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;

namespace ToCBooks.App.Business.Validadores
{
    public class ValidadorPedidosPendentes : IStrategy
    {
        public MensagemModel Validar(EntidadeDominio Objeto)
        {
            var Pedido = (PedidoModel)Objeto;

            Pedido.CartoesCredito.ForEach(x => 
            {
                if (x.NumeroCartao.Split(" ")[3] == "0000")
                    throw new Exception("Cartão Sem Limite para Compra...");
            });

            MensagemModel Mensagem = new MensagemModel();
            Mensagem.Codigo = ETipoCodigo.Correto;
            Mensagem.Resposta = "Pedido Validado com Sucesso !!!";

            return Mensagem;
        }
    }
}
