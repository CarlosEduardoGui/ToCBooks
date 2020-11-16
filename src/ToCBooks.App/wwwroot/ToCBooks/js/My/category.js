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
                    var htmlComparacao = '';
                    var radio = 1;
                    var autores = [];
                    var countAutor = 1;

                    console.log(respostaControle);


                    if (respostaControle.Codigo == 0) {
                        respostaControle.Dados.forEach(Livro => {
                            htmlFiltro += '<li class="filter-list"><input class="form-check-input autor_check" id="autorLivro" type="radio" name="' + Livro.Autor + '" value="' + Livro.Autor + '"><label for="">' + Livro.Autor + '</label></li>';
                        });


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

function CriarHtml(respostaControle) {
    var htmlListagemProduto = '';

    respostaControle.Dados.forEach(Livros => {
        htmlListagemProduto += '<div class="col-lg-4 col-md-6">';
        htmlListagemProduto += '<div class="single-product">';
        htmlListagemProduto += '<img src="' + Livros.Foto + '" style="width: 250px; height:300px; border-radius: 20px;" />';
        htmlListagemProduto += '<div class="product-details">';
        htmlListagemProduto += '<h6>' + Livros.Titulo + '</h6>';
        htmlListagemProduto += '<div class="price">';
        htmlListagemProduto += '<h6>R$' + Livros.Preco.toFixed(2) + '</h6>'
        var precoDesconto = Livros.Preco + (Livros.Preco * 0.10);
        htmlListagemProduto += '<h6 class="l-through">R$' + precoDesconto + '</h6>';
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

    });

    return htmlListagemProduto;

}