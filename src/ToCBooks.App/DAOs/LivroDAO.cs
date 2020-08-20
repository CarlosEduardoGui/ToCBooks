using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Interfaces;
using ToCBooks.App.Models;

namespace ToCBooks.App.DAOs
{
    public class LivroDAO : IDao
    {
        public Mensagem Atualizar(Entidade Objeto)
        {
            throw new NotImplementedException();
        }

        public Mensagem Cadastrar(Entidade Objeto)
        {
            Mensagem Mensagem = new Mensagem();
            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Dados Cadastrados Com Sucesso !!!";
            Mensagem.Dados = null;

            return Mensagem;
        }

        public Mensagem Consultar(Entidade Objeto)
        {
            Mensagem Mensagem = new Mensagem();
            Mensagem.Codigo = 0;
            Mensagem.Resposta = "Dados Encontrados Com Sucesso !!!";
            Mensagem.Dados = null;

            return Mensagem;
        }

        public Mensagem Editar(Entidade Objeto)
        {
            throw new NotImplementedException();
        }

        public Mensagem Excluir(Entidade Objeto)
        {
            throw new NotImplementedException();
        }
    }
}
