using System;
using System.Linq.Expressions;
using ToCBooks.App.Business.Models;
using ToCBooks.App.Business.Models.Enum;
using ToCBooks.App.Interfaces;

namespace ToCBooks.App.Modeladores
{
    public class BuscaLivros : IBusca
    {
        public Expression<Func<EntidadeDominio, bool>> GetExpression(EntidadeDominio Objeto)
        {
            var Livro = (LivrosModel)Objeto;
            Expression<Func<EntidadeDominio, bool>> Busca = x => x.StatusAtual == ETipoStatus.Inativo;
            
            return Busca;
        }
    }
}
