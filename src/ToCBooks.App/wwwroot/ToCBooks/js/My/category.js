jQuery(document).ready(function () {
    buscarLivros();
    buscarAutoresFiltro();

    jQuery("#autorLivro").on('click', function () {
        alert(jQuery("#autorLivro").val());
    });

    jQuery("#ordenacao").on('change', function () {
        var ordenacao = jQuery("#ordenacao").val();

        if (ordenacao == 1) {
            ordenarBuscaPreco(ordenacao);
        } else {
            ordenarBuscaNome(ordenacao);
        }
    });

    jQuery("#FiltroAutor").on('click', function () {

        var autor;
        jQuery(".autor_check").each(function () {
            if (jQuery(this).is(":checked"))
                autor = jQuery(this).attr('value')
        });

        var Categorias = new Array();
        var categoria = { NomeCategoria: '' };
        Categorias.push(categoria);

        var precificacao = {
            nome: null,
            valor: "0",
            tipo: "0"
        };

        var livro = {
            Titulo: "a",
            Preco: "0",
            Descricao: "a",
            Foto: "a",
            Autor: autor,
            Ano: "1",
            Editora: "a",
            Edicao: "1",
            CodigoDeBarras: "1",
            ISBN: "a",
            Paginas: "1",
            Altura: "1",
            Largura: "1",
            Profundidade: "1",
            Peso: "1",
            Categorias: Categorias,
            Precificacao: precificacao,
        };

        filtrarPorAutor(livro);
    });

});

function buscarLivros() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 1, mapKey: "LivrosModel", JsonString: JSON.stringify({}) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {
                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0) {

                        jQuery("#listagemProduto").html(CriarHtml(respostaControle));

                    }
                    else {
                        alert(respostaControle.Resposta);
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}

function ordenarBuscaPreco(ordenacao) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 22, mapKey: "LivrosModel", JsonString: JSON.stringify({ ordenacao }) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {
                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0) {

                        jQuery("#listagemProduto").html(CriarHtml(respostaControle));

                    }
                    else {
                        alert(respostaControle.Resposta);
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}


function ordenarBuscaNome(ordenacao) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 23, mapKey: "LivrosModel", JsonString: JSON.stringify({ ordenacao }) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {
                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0) {

                        jQuery("#listagemProduto").html(CriarHtml(respostaControle));

                    }
                    else {
                        alert(respostaControle.Resposta);
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}


function buscarAutoresFiltro() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 1, mapKey: "LivrosModel", JsonString: JSON.stringify({}) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {
                try {
                    var respostaControle = JSON.parse(e.responseText);
                    var htmlFiltro = '';
                    var autores = new Array();
                    var countAutor = new Array();

                    console.log(respostaControle);


                    if (respostaControle.Codigo == 0) {

                        respostaControle.Dados.forEach(Livro => {
                            autores.push(Livro.Autor);

                        });

                        autores.forEach(Autor => {
                            var flagAutor = false;

                            countAutor.forEach(count => {
                                if (Autor == count.Nome) {
                                    count.qtd++;
                                    flagAutor = true;
                                }
                            });

                            if (!flagAutor) {
                                var count = { Nome: Autor, qtd: 1 };
                                countAutor.push(count);
                            }
                        });

                        console.log(countAutor);

                        autores = autores.filter(onlyUnique);
                        for (var i = 0; i < autores.length; i++) {
                            htmlFiltro += '<li class="filter-list"><input class="form-check-input autor_check" type="radio" name="filtroAutor" value="' + autores[i] + '"><label>' + autores[i] + '  (' + countAutor[i].qtd + ')</label></li>';
                        }
                    }
                    else {
                        alert(respostaControle.Resposta);
                    }

                    jQuery("#FiltroAutor").html(htmlFiltro);

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}

function filtrarPorAutor(livro) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 24, mapKey: "LivrosModel", JsonString: JSON.stringify(livro) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {
                try {
                    var respostaControle = JSON.parse(e.responseText);

                    console.log(respostaControle);

                    if (respostaControle.Codigo == 0) {

                        jQuery("#listagemProduto").html(CriarHtml(respostaControle));
                    }
                    else {
                        alert(respostaControle.Resposta);
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}

function CriarHtml(respostaControle) {
    var htmlListagemProduto = '';

    respostaControle.Dados.forEach(Livros => {
        if (Livros.StatusAtual == 0) {
            htmlListagemProduto += '<div class="col-lg-4 col-md-6">';
            htmlListagemProduto += '<div class="single-product">';
            htmlListagemProduto += '<img src="' + Livros.Foto + '" style="width: 250px; height:300px; border-radius: 20px;" />';
            htmlListagemProduto += '<div class="product-details">';
            htmlListagemProduto += '<h6>' + Livros.Titulo + '</h6>';
            htmlListagemProduto += '<div class="price">';
            htmlListagemProduto += '<h6>R$' + Livros.Preco.toFixed(2) + '</h6>'
            var precoDesconto = Livros.Preco + (Livros.Preco * 0.10);
            htmlListagemProduto += '<h6 class="l-through">R$' + precoDesconto.toFixed(2) + '</h6>';
            htmlListagemProduto += '</div>';
            htmlListagemProduto += '<div class="prd-bottom">';
            htmlListagemProduto += '<a href="" class="social-info">';
            htmlListagemProduto += '<span class="lnr lnr-sync"></span>';
            htmlListagemProduto += '<p class="hover-text">Comprar</p>';
            htmlListagemProduto += '</a>';
            htmlListagemProduto += '<a href="single-product.html?id_livro=' + Livros.Id + '" class="social-info">';
            htmlListagemProduto += '<span class="lnr lnr-move"></span>';
            htmlListagemProduto += '<p class="hover-text">Ver Produto</p>';
            htmlListagemProduto += '</a>';
            htmlListagemProduto += '</div>';
            htmlListagemProduto += '</div>';
            htmlListagemProduto += '</div>';
            htmlListagemProduto += '</div>';
        }
    });

    return htmlListagemProduto;

}

function onlyUnique(value, index, self) {
    return self.indexOf(value) === index;
}