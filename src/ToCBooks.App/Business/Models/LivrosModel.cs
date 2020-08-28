using System.Collections.Generic;

namespace ToCBooks.App.Business.Models
{
    public class LivrosModel : EntidadeDominio
    {
        public string Titulo { get; set; } //
        public double Preco { get; set; } 
        public string Foto { get; set; } // 
        public string Descricao { get; set; } //
        public string Autor { get; set; } // 
        public int Ano { get; set; } // 
        public string Editora { get; set; } //
        public int Edicao { get; set; } // 
        public string ISBN { get; set; }//
        public int Paginas { get; set; } // 
        public double Altura { get; set; }//
        public double Largura { get; set; }//
        public double Profundidade { get; set; }
        public double Peso { get; set; }//
        public Parametro Precificacao { get; set; }
        public string CodigoDeBarras { get; set; }//
        public List<Categoria> Categoria { get; set; }
    }
}
