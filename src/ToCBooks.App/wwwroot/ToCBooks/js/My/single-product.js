jQuery(document).ready(function () {

    var id_livro = getUrlVars()['id_livro'];

    var livro = {
        Id: id_livro,
    }

    BuscarProduto(livro);


    jQuery("#btn_login").on("click", function (e) {
        e.preventDefault();

    });
});

function getUrlVars() {
    var vars = {};
    var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
        vars[key] = value;
    });
    return vars;
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
                            htmlItem += '<li><a class="active"><span>Disponibilidade: </span>: Arrumar</a></li>';
                            htmlItem += '</lu>';
                            htmlItem += '<p>'+ livro.Descricao +'</p>';
                            htmlItem += '<div class="product_count">';
                            htmlItem += '<label for="qty">Quantidade:</label>';
                            htmlItem += '<input type="number" id="qtdItem"/></button>';
                            htmlItem += '</div>';
                            htmlItem += '<div class="card_area d-flex align-items-center">';
                            htmlItem += '<a class="primary-btn" href="#">Comprar</a>';
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