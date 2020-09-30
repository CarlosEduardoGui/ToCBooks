var idEntidadeTemp;

jQuery(document).ready(function () {
    buscarPedidos();

    jQuery("#btn_nao").on('click', function (e) {
        e.preventDefault();

        jQuery("#modal_confirmacao_delecao").modal('hide');
    });

});

function buscarPedidos() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 1, mapKey: "PedidoModel", JsonString: JSON.stringify({}) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);
                    console.log(respostaControle.Dados);
                    if (respostaControle.Codigo == 1)
                        alert("Erro ao buscar Pedidos do cliente...");
                    var htmlPedido = '';

                    htmlPedido += '<div class="order_details_table">';
                    htmlPedido += '<input type="hidden" value="' + pedido.Id + '" id="' + pedido.ClienteId + '"/>';
                    htmlPedido += '<h2>Pedidos</h2>';

                    if (respostaControle.Dados.length > 0) {
                        respostaControle.Dados.forEach(pedido => {
                            pedido.ItensPedido.forEach(item => {
                                htmlPedido += '<div class="row">';
                                htmlPedido += '<div class="col-md-5">';
                                htmlPedido += '<h5>Livro - ' + item.Livro.Titulo + '</h5>';
                                htmlPedido += '</div>';
                                htmlPedido += '<div class="col">';
                                htmlPedido += '<label>' + pedido.StatusAtual + ' </label>';
                                htmlPedido += '</div>';
                                htmlPedido += '<div class="col">';
                                htmlPedido += '<label>R$: ' + pedido.TotalPedido + ' </label>';
                                htmlPedido += '</div>';
                                htmlPedido += '<div class="col">';
                                htmlPedido += '<a href="#" class="genric-btn info circle arrow" data-toggle="modal" data-target="#exampleModal">Detalhes<span class="lnr lnr-arrow-right"></span></a>';
                                htmlPedido += '</div>';
                                htmlPedido += '</div>';
                            });
                        });

                        htmlPedido += '</div>';
                    } else {
                        htmlPedido += '<tr><td>Nenhum Registro Encontrado</td></tr>';
                    }

                    jQuery("#pedido").html(htmlPedido);

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}