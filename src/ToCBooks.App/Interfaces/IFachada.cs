using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToCBooks.App.Models;

namespace ToCBooks.App.Interfaces
{
    interface IFachada
    {
        Mensagem Consultar(Entidade Objeto);
        Mensagem Cadastrar(Entidade Objeto);
        Mensagem Atualizar(Entidade Objeto);
        Mensagem Excluir(Entidade Objeto);
    }
}
