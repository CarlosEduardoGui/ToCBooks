jQuery(document).ready(function () {
    buscarLivros();

    jQuery("#btn_consultar").on('click', function () {
        jQuery("#modal_busca").modal("show");
    });
});

function buscarLivros() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "1", mapKey: "LivrosModel", JsonString: JSON.stringify({}) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {
                try {
                    var respostaControle = JSON.parse(e.responseText);
                    htmlListagemProduto = '';

                    if (respostaControle.Codigo == 0) {
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
                            htmlListagemProduto += '<span class="ti-bag"></span>';
                            htmlListagemProduto += '<p class="hover-text">Adicionar a Sacola</p>';
                            htmlListagemProduto += '</a>';
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

                        jQuery("#listagemProduto").html(htmlListagemProduto);
                    
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