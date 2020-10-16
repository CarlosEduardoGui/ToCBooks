var idEntidadeTemp;
var statusMap = new Map();

statusMap.set(0, 'Ativo');
statusMap.set(1, 'Inativo');
statusMap.set(2, 'Aprovada');
statusMap.set(3, 'Reprovada');
statusMap.set(4, 'Em Processamento');
statusMap.set(5, 'Entregue');
statusMap.set(6, 'Em Trânsito');
statusMap.set(7, 'Troca Autorizada');
statusMap.set(8, 'Em Troca');
statusMap.set(9, 'Trocado');
statusMap.set(10, 'Fora de Mercado');


jQuery(document).ready(function () {
    buscarPedidos();

    jQuery(document).on('click', ".btn_detalhes", function (e) {
        e.preventDefault();

        var id = jQuery(this).attr("value");

        buscaPedido(id);

        jQuery("#modalDetalhes").modal('show');

    });

    jQuery(document).on('click', "#id_devolucao", function (e) {
        e.preventDefault();

        var id = jQuery(this).attr("value");

        SolicitarTrocaProduto(id);

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
                    htmlPedido += '<h2>Pedidos</h2>';

                    console.log(respostaControle.Dados);

                    if (respostaControle.Dados.length > 0) {
                        respostaControle.Dados.forEach(pedido => {
                            htmlPedido += '<hr />';
                            htmlPedido += '<div class="row">';
                            htmlPedido += '<div class="col-md-5">';
                            htmlPedido += '<h5>Pedido: ' + pedido.Id + '</h5>';
                            htmlPedido += '</div>';
                            htmlPedido += '<div class="col">';
                            htmlPedido += '<label>Status: ' + statusMap.get(pedido.StatusAtual) + ' </label>';
                            htmlPedido += '</div>';
                            htmlPedido += '<div class="col">';
                            htmlPedido += '<label class="dinheiro">R$ ' + pedido.TotalPedido + ' </label>';
                            htmlPedido += '</div>';
                            htmlPedido += '<div class="col">';
                            htmlPedido += '<button value="' + pedido.Id + '" class="btn_detalhes genric-btn info circle arrow" >Detalhes<span class="lnr lnr-arrow-right"></span></button>'; //data-toggle="modal" data-target="#exampleModal"
                            htmlPedido += '</div>';
                            htmlPedido += '</div>';
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

function buscaPedido(id) {

    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 1, mapKey: "PedidoModel", JsonString: JSON.stringify({ id }) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {

                    var respostaControle = JSON.parse(e.responseText);
                    console.log(respostaControle.Dados);
                    if (respostaControle.Codigo == 1)
                        alert("Erro ao buscar pedido do cliente...");
                    var htmlListaProduto = '';
                    var htmlTotal = '';
                    var htmlStatus = '';
                    var htmlDevolucao = '';

                    console.log(respostaControle.Dados);

                    if (respostaControle.Dados.length > 0) {
                        respostaControle.Dados.forEach(pedido => {
                            pedido.ItensPedido.forEach(item => {
                                htmlListaProduto += '<input type="hidden" id="item_id" value="' + item.Id + '" />'
                                htmlListaProduto += '<li><a href="#">' + item.Livro.Titulo + '<span class="middle">x ' + item.Qtde + '</span> <span class="last">R$ ' + item.Livro.Preco + '</span></a></li>';
                            });
                            htmlTotal += '<li><a href="#">Subtotal <span>R$ ' + pedido.TotalPedido + '</span></a></li>';
                            htmlTotal += '<li><a href="#">Total <span>R$ ' + pedido.TotalPedido + '</span></a></li>';

                            htmlStatus += '<li><a>Status: ' + statusMap.get(pedido.StatusAtual) + '</a></li>';
                            if (pedido.StatusAtual == 5) {
                                htmlDevolucao += '<button type="button" value="' + pedido.Id + '"  id="id_devolucao" class="btn btn-block" data-dismiss="modal">Devolver</button>';
                            }

                            jQuery("#lista_produto").html(htmlListaProduto);
                            jQuery("#total").html(htmlTotal);
                            jQuery("#status").html(htmlStatus);
                            jQuery("#devolucao").html(htmlDevolucao);

                        });

                    } else {
                        htmlPedido += 'Nenhum Registro Encontrado';
                    }

                    jQuery("#modalDetalhes").modal('show');

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}


function SolicitarTrocaProduto(id) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 17, mapKey: "PedidoModel", JsonString: JSON.stringify({ id }) },
        cache: false,
        beforeSend: function (xhr) {
            console.log("Solicitando a troca do produto");
        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {

                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0) {
                        alert("Pedido de Troca feito com sucesso!");
                        buscarPedidos();
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}