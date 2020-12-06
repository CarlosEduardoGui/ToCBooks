jQuery(document).ready(function () {

    var id_livro = getUrlVars()['id_livro'];

    var livro = {
        Id: id_livro,
    }

    jQuery(document).on("click", '#btn_add_carrinho', function () {
        var IdLivro = jQuery(this).attr('id_livro');

        var QtdeLivro = jQuery("#qtdItem").val();
        if (QtdeLivro <= 0) {
            alert("Escolha uma quantidade Valida !!!");
            return;
        }

        var Livro = { Id: IdLivro };

        AdicionarItemCarrinho({ Livro: Livro, Qtde: QtdeLivro });

    });

    BuscarProduto(livro);

});


function AdicionarItemCarrinho(ObjetoEnvio) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 9, mapKey: 'ItemEstoque', JsonString: JSON.stringify(ObjetoEnvio) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            console.log(e.readyState);
            console.log(e.status);
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var resposta_controle = JSON.parse(e.responseText);
                    if (resposta_controle.Codigo == 0) {
                        window.location.href = 'cart.html';
                    } else {
                        alert(resposta_controle.Resposta);
                    }

                } catch (error) {
                    alert(error);
                }
            }
        }
    });
}


function BuscarProduto(objeto) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 1, mapKey: 'LivrosModel', JsonString: JSON.stringify(objeto) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            console.log(e.readyState);
            console.log(e.status);
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var resposta_controle = JSON.parse(e.responseText);
                    if (resposta_controle.Codigo == 0) {
                        var htmlItem = '';

                        console.log(resposta_controle);

                        resposta_controle.Dados.forEach(livro => {
                            htmlItem += '<div class="col-lg-6">';
                            htmlItem += '<div class="single-prd-item">';
                            htmlItem += '<img class="img-fluid" src="'+ livro.Foto +'">';
                            htmlItem += '</div>';
                            htmlItem += '</div>';
                            htmlItem += '</div>';
                            htmlItem += '<div class="col-lg-5 offset-lg-1">';
                            htmlItem += '<div class="s_product_text">';
                            htmlItem += '<h3>'+ livro.Titulo +'</h3>';
                            htmlItem += '<h2>R$ ' + livro.Preco +'</h2>';
                            htmlItem += '<ul class="list">';
                            livro.Categorias.forEach(categoria => {
                                htmlItem += '<li><a class="active"><span>Categoria: </span>: ' + categoria.NomeCategoria + '</a></li>';
                            });
                            //htmlItem += '<li><a class="active"><span>Disponibilidade: </span>: Arrumar</a></li>';
                            htmlItem += '</lu>';
                            htmlItem += '<label><strong>Autor(a):</strong> ' + livro.Autor + '</label><br />';
                            htmlItem += '<label><strong>Editora:</strong> ' + livro.Editora + '</label><br />';
                            htmlItem += '<label><strong>Quantidade de Páginas:</strong> ' + livro.Paginas + '</label><br />';
                            htmlItem += '<label><strong>Peso:</strong> ' + livro.Peso + '</label><br />';
                            htmlItem += '<label><strong>Código de Barras:</strong> ' + livro.CodigoDeBarras + '</label>';
                            htmlItem += '<p>'+ livro.Descricao +'</p>';
                            htmlItem += '<div class="product_count">';
                            htmlItem += '<label for="qty">Quantidade:</label>';
                            htmlItem += '<input type="number" id="qtdItem" min="1" value="1"/></button>';
                            htmlItem += '</div>';
                            htmlItem += '<div class="card_area d-flex align-items-center">';
                            htmlItem += '<a class="primary-btn" style="cursor: pointer;" id="btn_add_carrinho" id_livro="' + livro.Id + '">Comprar</a>';
                            htmlItem += '</div>';
                            htmlItem += '</div>';
                            htmlItem += '</div>';

                            jQuery("#id_livro").val(livro.Id);
                        });

                        jQuery("#produto").html(htmlItem);
                    } else {
                        alert(resposta_controle.Resposta);
                    }

                } catch (error) {
                    alert(error);
                }
            }
        }
    });
}



function getUrlVars() {
    var vars = {};
    var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
        vars[key] = value;
    });
    return vars;
}