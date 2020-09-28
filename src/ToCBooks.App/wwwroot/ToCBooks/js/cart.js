


jQuery(document).ready(function () {
    BuscarCarrinho();


    jQuery(document).on('click', '.excluir_item', function (e) {
        e.preventDefault();

        var id_item = jQuery(this).attr("id_item");

        ExcluirItemCarrinho({ Id: id_item, Qtde: 0, Livro: {} });
    });

    jQuery(document).on('click', '#btn_confirmar_venda', function (e) {
        e.preventDefault();

        var Itens = new Array()

        jQuery('.qty').each(function () {
            var ItemEstoque = {
                Id: jQuery(this).attr('id_item'), Qtde: jQuery(this).val(), Livro: { Id: jQuery(this).attr('id_livro') }
            };
            Itens.push(ItemEstoque);
        });

        ContinuarParaCompra({ Itens: Itens });
    });
});


function ContinuarParaCompra(ObjetoEnvio) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 12, mapKey: 'Carrinho', JsonString: JSON.stringify(ObjetoEnvio) },
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
                        window.location.href = "/ToCBooks/checkout.html";
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

function ExcluirItemCarrinho(ObjetoEnvio) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 11, mapKey: 'ItemEstoque', JsonString: JSON.stringify(ObjetoEnvio) },
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
                        BuscarCarrinho();
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

function BuscarCarrinho() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 10, mapKey: 'Carrinho', JsonString: JSON.stringify({}) },
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
                        var Carrinho = resposta_controle.Dados[0];

                        var TotalCompra = 0;
                        htmlTabela = ' ';
                        Carrinho.Itens.forEach(ItemCarrinho => {
                            if (ItemCarrinho != null) {
                                htmlTabela += '<tr><td><div class="media"><div class="d-flex">';
                                htmlTabela += '<img style="width: 200px; height: 160px; border-radius: 20px;" src="' + ItemCarrinho.Livro.Foto + '" alt="">';
                                htmlTabela += '</div><div class="media-body">';
                                htmlTabela += '<p>' + ItemCarrinho.Livro.Titulo + '</p>';
                                htmlTabela += '</div></div></td><td>';
                                htmlTabela += '<h5>R$ ' + ItemCarrinho.Livro.Preco + '</h5>';
                                htmlTabela += '</td><td><div class="product_count">';
                                htmlTabela += '<input type="number" name="qty" id="sst" maxlength="12" id_livro="' + ItemCarrinho.Livro.Id + '" id_item="' + ItemCarrinho.Id + '" value="' + ItemCarrinho.Qtde + '" title="Quantity:" class="input-text qty" ></td>';
                                htmlTabela += '<td><h5>R$ ' + (ItemCarrinho.Qtde * ItemCarrinho.Livro.Preco).toFixed(2) + '</h5></td>';
                                htmlTabela += '<td><h5>' + FormatarHora(ItemCarrinho.DataCadastro) + '</h5></td>';
                                htmlTabela += '<td><button id_item="' + ItemCarrinho.Id + '" class="btn btn-warning excluir_item"><i class="fa fa-trash-o"></i></button></td></tr>';

                                TotalCompra += (ItemCarrinho.Qtde * ItemCarrinho.Livro.Preco);
                            }
                        });

                        htmlTabela += '<tr><td></td><td></td><td></td><td><h5>Subtotal</h5></td><td><h5>R$' + TotalCompra.toFixed(2) + '</h5></td></tr>';
                        htmlTabela += '<tr class="out_button_area"><td></td><td></td><td></td><td></td><td></td><td><div class="checkout_btn_inner d-flex align-items-center"><a class="gray_btn" href="/">Continue Comprando</a><a style="color: white;" class="primary-btn" id="btn_confirmar_venda">Continuar para Compra</a></div></td></tr>';

                        jQuery("#tbody_tabela_carrinho").html(htmlTabela);
                        jQuery("#tbody_tabela_carrinho").fadeIn(400);

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

function FormatarHora(DataRecebida) {
    return DataRecebida.split('T')[1].split('.')[0];
}

