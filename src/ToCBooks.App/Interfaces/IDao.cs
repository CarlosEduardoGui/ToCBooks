using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Models;

namespace ToCBooks.App.Interfaces
{
    interface IDao
    {
        Mensagem Cadastrar(Entidade Objeto);
        Mensagem Atualizar(Entidade Objeto);
        Mensagem Editar(Entidade Objeto);
        Mensagem Excluir(Entidade Objeto);
        Mensagem Consultar(Entidade Objeto);
    }
}
