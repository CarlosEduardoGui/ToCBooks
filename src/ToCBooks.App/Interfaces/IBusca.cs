using System;
using System.Linq.Expressions;
using ToCBooks.App.Business.Models;

namespace ToCBooks.App.Interfaces
{
    public interface IBusca
    {
        Expression<Func<EntidadeDominio, bool>> GetExpression(EntidadeDominio Objeto);
    }
}
