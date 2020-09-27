jQuery(document).ready(function () {
    BuscarUltimosProdutosCadastrados();

});


function BuscarUltimosProdutosCadastrados() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 1, mapKey: 'LivrosModel', JsonString: JSON.stringify({}) },
        cache: false,
        beforeSend: function (xhr) {
        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {
                var htmlDestaque = '';
                var htmlUltimosLancamentos = '';

                try {
                    var resposta_controle = JSON.parse(e.responseText);

                    console.log(resposta_controle);

                    if (resposta_controle.Codigo == 0) {

                        var livro = resposta_controle.Dados[0];

                        htmlDestaque += '<div class="active-banner-slider">';
                        htmlDestaque += '<div class="row single-slide align-items-center d-flex">';
                        htmlDestaque += '<div class="col-lg-5 col-md-6">';
                        htmlDestaque += '<div class="banner-content">';
                        htmlDestaque += '<h1>Novo Livro: <br /> ' + livro.Titulo + '</h1>';
                        htmlDestaque += '<p>' + livro.Autor + '</p>';
                        htmlDestaque += '<div class="add-bag d-flex align-items-center">';
                        htmlDestaque += '<a class="add-btn" href="ToCBooks/single-product.html?id_livro=' + livro.Id + '"><span class="lnr lnr-cross"></span></a>';
                        htmlDestaque += '<span class="add-text text-uppercase">Compre agora!</span>'
                        htmlDestaque += '</div>';
                        htmlDestaque += '</div>';
                        htmlDestaque += '</div>';
                        htmlDestaque += '<div class="col-lg-7">';
                        htmlDestaque += '<div class="banner-img">';
                        htmlDestaque += '<img src="' + livro.Foto + '" style="max-width:1000px; max-height:1000px; border-radius: 20px;" />';
                        htmlDestaque += '</div>';
                        htmlDestaque += '</div>';
                        htmlDestaque += '</div>';

                        jQuery("#livros").html(htmlDestaque);

                        htmlUltimosLancamentos += '<div class="container">';
                        htmlUltimosLancamentos += '<div class="row justify-content-center">';
                        htmlUltimosLancamentos += '<div class="col-lg-6 text-center">';
                        htmlUltimosLancamentos += '<div class="sectopm-title">';
                        htmlUltimosLancamentos += '<h1>Lançamentos</h1>';
                        htmlUltimosLancamentos += '<p>Últimos produtos a chegar na loja você encontra aqui! Compra agora!</p>';
                        htmlUltimosLancamentos += '</div>';
                        htmlUltimosLancamentos += '</div>';
                        htmlUltimosLancamentos += '</div>';
                        htmlUltimosLancamentos += '<div class="row">';

                        for (var i = 0; i < 8; i++) {
                            var ultimoLivro = resposta_controle.Dados[i];

                            if (typeof (ultimoLivro) != "undefined") {
                                htmlUltimosLancamentos += '<div class="col-lg-3 col-md-6">';
                                htmlUltimosLancamentos += '<div class="single-product">';
                                htmlUltimosLancamentos += '<img src="' + ultimoLivro.Foto + '" style="width: 250px; height:300px; border-radius: 20px;" />';
                                htmlUltimosLancamentos += '<div class="product-details">';
                                htmlUltimosLancamentos += '<h6>' + ultimoLivro.Titulo + '</h6>';
                                htmlUltimosLancamentos += '<div class="price">';
                                htmlUltimosLancamentos += '<h6>R$ ' + ultimoLivro.Preco + '</h6>';
                                var precoDesconto = ultimoLivro.Preco + (ultimoLivro.Preco * 0.10);
                                htmlUltimosLancamentos += '<h6 class="l-through">R$ ' + precoDesconto + '</h6>';
                                htmlUltimosLancamentos += '</div>';
                                htmlUltimosLancamentos += '<div class="prd-bottom">';
                                htmlUltimosLancamentos += '<a href="#" class="social-info">';
                                htmlUltimosLancamentos += '<span class="ti-bag"></span>';
                                htmlUltimosLancamentos += '<p class="hover-text">Adicionar na sacola</p>';
                                htmlUltimosLancamentos += '</a>';
                                htmlUltimosLancamentos += '<a href="ToCBooks/single-product.html?id_livro=' + ultimoLivro.Id + '" class="social-info">';
                                htmlUltimosLancamentos += '<span class="lnr lnr-sync"></span>';
                                htmlUltimosLancamentos += '<p class="hover-text">Comprar</p>';
                                htmlUltimosLancamentos += '</a>';
                                htmlUltimosLancamentos += '<a href="ToCBooks/single-product.html?id_livro=' + ultimoLivro.Id + '" class="social-info">';
                                htmlUltimosLancamentos += '<span class="lnr lnr-move"></span>';
                                htmlUltimosLancamentos += '<p class="hover-text">Visualizar</p>';
                                htmlUltimosLancamentos += '</div>';
                                htmlUltimosLancamentos += '</div>';
                                htmlUltimosLancamentos += '</div>';
                                htmlUltimosLancamentos += '</div>';
                            } else {
                                break;
                            }
                        }

                        htmlUltimosLancamentos += '</div>';

                        jQuery("#ultimosLancamentos").html(htmlUltimosLancamentos);

                    } else {
                        alert("Usuário não Cadastrado");
                    }

                } catch (error) {
                    console.log(error);
                }
            }
        }
    });
}