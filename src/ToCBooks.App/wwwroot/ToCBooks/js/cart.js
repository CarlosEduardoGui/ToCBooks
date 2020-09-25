


jQuery(document).ready(function () {
    BuscarCarrinho();


    jQuery(document).on('click', '.excluir_item', function (e) {
        e.preventDefault();

        var id_item = jQuery(this).attr("id_item");

        ExcluirItemCarrinho({ Id: id_item, Qtde: 0, Livro: {} });
    });

});

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
                                htmlTabela += '<input type="text" name="qty" id="sst" maxlength="12" value="' + ItemCarrinho.Qtde + '" title="Quantity:" class="input-text qty" >';
                                htmlTabela += '<button onclick="aumentar();" class="increase items-count" type="button"><i class="lnr lnr-chevron-up"></i></button>';
                                htmlTabela += '<button onclick="diminuir();" class="reduced items-count" type="button"><i class="lnr lnr-chevron-down"></i></button></div></td>';
                                htmlTabela += '<td><h5>R$ ' + (ItemCarrinho.Qtde * ItemCarrinho.Livro.Preco).toFixed(2) + '</h5></td>';
                                htmlTabela += '<td><h5>' + FormatarHora(ItemCarrinho.DataCadastro) + '</h5></td>';
                                htmlTabela += '<td><button id_item="' + ItemCarrinho.Id + '" class="btn btn-warning excluir_item"><i class="fa fa-trash-o"></i></button></td></tr>';
                            }
                        });


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


function aumentar() {
    var result = document.getElementById('sst');
    var sst = result.value;
    if (!isNaN(sst)) result.value++;
    return false;
}

function diminuir() {
    var result = document.getElementById('sst');
    var sst = result.value;
    if (!isNaN(sst) && sst > 0)
        result.value--; return false;
}