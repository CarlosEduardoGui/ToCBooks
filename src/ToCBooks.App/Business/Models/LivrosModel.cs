using System.Collections.Generic;

namespace ToCBooks.App.Business.Models
{
    public class LivrosModel : EntidadeDominio
    {
        public string Titulo { get; set; } //
        public double Preco { get; set; } //
        public string Foto { get; set; } //
        public string Descricao { get; set; } //
        public string Autor { get; set; } //
        public int Ano { get; set; }  //
        public string Editora { get; set; } //
        public int Edicao { get; set; } //
        public string ISBN { get; set; } //
        public int Paginas { get; set; } //
        public double Altura { get; set; } // 
        public double Largura { get; set; } //
        public double Profundidade { get; set; } //
        public double Peso { get; set; } //
        public Parametro Precificacao { get; set; }
        public string CodigoDeBarras { get; set; }
        public List<Categoria> Categorias { get; set; }

        public LivrosModel Diff(LivrosModel LivroAtual)
        {
            LivrosModel Livro = new LivrosModel
            {
                Titulo = (this.Titulo != LivroAtual.Titulo && this.Titulo != null) ? this.Titulo : LivroAtual.Titulo,
                Preco = (this.Preco != LivroAtual.Preco && this.Preco > 0) ? this.Preco : LivroAtual.Preco,
                Foto = (this.Foto != LivroAtual.Foto && this.Foto != null) ? this.Foto : LivroAtual.Foto,
                Descricao = (this.Descricao != LivroAtual.Descricao && this.Descricao != null) ? this.Descricao : LivroAtual.Descricao,
                Autor = (this.Autor != LivroAtual.Autor && this.Autor != null) ? this.Autor : LivroAtual.Autor,
                Editora = (this.Editora != LivroAtual.Editora && this.Editora != null) ? this.Editora : LivroAtual.Editora,
                Edicao = (this.Edicao != LivroAtual.Edicao && this.Edicao > 0) ? this.Edicao : LivroAtual.Edicao,
                ISBN = (this.ISBN != LivroAtual.ISBN && this.ISBN != null) ? this.ISBN : LivroAtual.ISBN,
                Paginas = (this.Paginas != LivroAtual.Paginas && this.Paginas > 0) ? this.Paginas : LivroAtual.Paginas,
                Altura = (this.Altura != LivroAtual.Altura && this.Altura > 0) ? this.Altura : LivroAtual.Altura,
                Largura = (this.Largura != LivroAtual.Largura && this.Largura > 0) ? this.Largura : LivroAtual.Largura,
                Profundidade = (this.Profundidade != LivroAtual.Profundidade && this.Profundidade > 0) ? this.Profundidade : LivroAtual.Profundidade,
                Peso = (this.Peso != LivroAtual.Peso && this.Peso > 0) ? this.Peso : LivroAtual.Peso,
                CodigoDeBarras = (this.CodigoDeBarras != LivroAtual.CodigoDeBarras && this.CodigoDeBarras != null) ? this.CodigoDeBarras : LivroAtual.CodigoDeBarras,

                Precificacao = LivroAtual.Precificacao
            };

            return Livro;
        }
    }
}
