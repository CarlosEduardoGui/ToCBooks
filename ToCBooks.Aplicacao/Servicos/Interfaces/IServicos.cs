using System.Collections.Generic;

namespace ToCBooks.Aplicacao.Servicos.Interfaces
{
    public interface IServicos<TInput, TView>
    {
        IList<TView> GetAll();

        TView GetByID(object id);

        TInput Update(TInput obj);

        void Delete(object id);
    }
}
