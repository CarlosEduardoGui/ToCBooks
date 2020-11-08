
var PedidoTemp = '';


var statusMap = new Map();
statusMap.set(2, '<span class="badge badge-success">Aprovada</span>');
statusMap.set(3, '<span class="badge badge-danger">Reprovada</span>');
statusMap.set(4, '<span class="badge badge-info">Em Processamento</span>');
statusMap.set(5, '<span class="badge badge-primary">Entregue</span>');
statusMap.set(6, '<span class="badge badge-info">Em Trâsito</span>');
statusMap.set(7, '<span class="badge badge-info">Troca Autorizada</span>');
statusMap.set(8, '<span class="badge badge-info">Em Troca</span>');
statusMap.set(9, '<span class="badge badge-info">Trocado</span>');

jQuery(document).ready(function () {
    ProcessarPedidosPendentes();

    jQuery(document).on('click', '.ver_pedidos_retornados', function () {
        jQuery("#modal_produtos_troca").modal("show");
    });

    jQuery(document).on('click', '.Aprovada', function () {

        var id = jQuery(this).attr('id');

        var objeto = {
            Id: id,
        };

        TrocarStatusAtivo(objeto);
    });


    jQuery(document).on('click', '.EmTransito', function () {

        var id = jQuery(this).attr('id');

        var objeto = {
            Id: id,
        };

        TrocarStatusEmTransito(objeto);
    });


    jQuery(document).on('click', '.AceitarTroca', function () {

        var id = jQuery(this).attr('id');

        var Pedido = {
            Id: id,
        };

        PedidoTemp = Pedido;

        ConsultarPedido(Pedido);
    });


    jQuery(document).on('click', '.Trocar', function () {

        var id = jQuery(this).attr('id');

        var objeto = {
            Id: id,
        };

        TrocarStatusTrocaAutorizada(id);
    });

    jQuery("#btn_salvar_precificacao").on('click', function (e) {
        e.preventDefault();

        jQuery("#modal_produtos_troca").modal('hide');
        TrocarStatusEmTroca(PedidoTemp);
    });

    jQuery("#btn_retornar_estoque").on('click', function (e) {
        e.preventDefault();

        jQuery("#modal_produtos_troca").modal('hide');
        RetornarItensAoEstoque(PedidoTemp);
    });
});


function RetornarItensAoEstoque(pedido) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "19", mapKey: "PedidoModel", JsonString: JSON.stringify(pedido) },
        cache: false,
        beforeSend: function (xhr) {
            console.log("Trocando status de Entregue para EmTroca");
        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);
                    if (respostaControle.Codigo == 0) {
                        buscarVendas();
                    } else {
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


function ConsultarPedido(Pedido) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 1, mapKey: "PedidoModel", JsonString: JSON.stringify(Pedido) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {

                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 1)
                        alert("Erro ao buscar pedido do cliente...");

                    if (respostaControle.Dados.length > 0) {

                        var htmlTabela = ''
                        respostaControle.Dados.forEach(Pedido => {
                            Pedido.ItensPedido.forEach(Item => {
                                htmlTabela += '<tr><td>' + Pedido.Id + '</td>';
                                htmlTabela += '<td><a class="text-dark" href = "">' + Item.Livro.Titulo + '</a></td>';
                                htmlTabela += '<td><a class="text-dark" href = ""> ' + Item.Qtde + ' Uds</a></td>';
                                htmlTabela += '<td class="d-none d-md-table-cell">' + FormatarHora(Pedido.DataCadastro) + '</td>';
                                htmlTabela += '<td class="d-none d-md-table-cell">R$' + (Item.Qtde * Item.Livro.Preco).toFixed(2) + '</td></tr>';
                            });
                        });

                        jQuery("#tbody_tabela_reiintregacao").html(htmlTabela);

                        jQuery("#modal_produtos_troca").modal('show');

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

function ProcessarPedidosPendentes() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "14", mapKey: "PedidoModel", JsonString: JSON.stringify({}) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 1)
                        alert("Erro ao Buscar Vendas...");
                    else {
                        buscarVendas();
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}

function buscarVendas() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "1", mapKey: "PedidoModel", JsonString: JSON.stringify({}) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 1)
                        alert("Erro ao Buscar Vendas...");
                    else {
                        var htmlVendaAprovada = '';
                        var htmlVendaTroca = '';
                        var htmlVendaTransito = '';

                        var i = 1;
                        var j = 1;
                        var k = 1;

                        respostaControle.Dados.forEach(vendas => {

                            if (vendas.StatusAtual == 2 || vendas.StatusAtual == 3) {
                                htmlVendaAprovada += renderizaHtmlAprovada(vendas, i);

                            } else if (vendas.StatusAtual == 5 || vendas.StatusAtual == 7 || vendas.StatusAtual == 8 || vendas.StatusAtual == 9) {
                                htmlVendaTroca += rendeziraHtmlTroca(vendas, j);

                            } else if (vendas.StatusAtual == 6) {
                                htmlVendaTransito += rendeziraHtmlTransito(vendas, k);

                            }

                        });

                        jQuery("#tbody_vendas_confirmadas").html(htmlVendaAprovada);
                        jQuery("#tbody_vendas_trocas").html(htmlVendaTroca);
                        jQuery("#tbody_vendas_transito").html(htmlVendaTransito);

                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}

function renderizaHtmlAprovada(vendas, i) {
    try {
        if (vendas.StatusAtual == 2 || vendas.StatusAtual == 3) {
            console.log(vendas);
            var htmlVendaAprovada = '';

            htmlVendaAprovada += '<tr>';
            htmlVendaAprovada += '<td>' + vendas.Id + '</td>';
            htmlVendaAprovada += '<td>';
            htmlVendaAprovada += '<a class="text-dark" href="">' + vendas.Cliente.Nome + '</a>';
            htmlVendaAprovada += '</td>';
            htmlVendaAprovada += '<td class="d-none d-md-table-cell">' + FormatarHora(vendas.DataCadastro) + '</td>';
            htmlVendaAprovada += '<td class="d-none d-md-table-cell">' + parseFloat(vendas.TotalPedido).toFixed(2) + '</td>';
            htmlVendaAprovada += '<td>' + statusMap.get(vendas.StatusAtual) + '</td>';

            if (vendas.StatusAtual == 2) {
                htmlVendaAprovada += '<td class="text-right">';
                htmlVendaAprovada += '<div class="dropdown show d-inline-block widget-dropdown">';
                htmlVendaAprovada += '<a class="dropdown-toggle icon-burger-mini" href="#" role="button" id="dropdown-recent-order' + i + '" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static"></a>';
                htmlVendaAprovada += '<ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-recent-order' + i + '" >';
                htmlVendaAprovada += '<li class="dropdown-item">';
                htmlVendaAprovada += '<a class="Aprovada" id="' + vendas.Id + '" name="enviarParaEntrega">Enviar para Entrega</a>';
                htmlVendaAprovada += '</li>';
                htmlVendaAprovada += '</ul>';
                htmlVendaAprovada += '</div>';
                htmlVendaAprovada += '</td>';

            } else if (vendas.StatusAtual == 3) {
                htmlVendaAprovada += '<td class="text-right">';
                htmlVendaAprovada += '</td>';

            }

            htmlVendaAprovada += '</tr>';
            i++;
        }

        return htmlVendaAprovada;


    } catch (error) {
        console.log(error);
        alert("Erro na Comunicação com o Servidor...");
    }

}


function rendeziraHtmlTroca(vendas, j) {
    try {
        var htmlVendaTroca = '';

        if (vendas.StatusAtual == 5 || vendas.StatusAtual == 7 || vendas.StatusAtual == 8 || vendas.StatusAtual == 9) {

            htmlVendaTroca += '<tr>';
            htmlVendaTroca += '<td>' + vendas.Id + '</td>';
            htmlVendaTroca += '<td>';
            htmlVendaTroca += '<a class="text-dark" href="">' + vendas.Cliente.Nome + '</a>';
            htmlVendaTroca += '</td>';
            htmlVendaTroca += '<td class="d-none d-md-table-cell">' + FormatarHora(vendas.DataCadastro) + '</td>';
            htmlVendaTroca += '<td class="d-none d-md-table-cell">' + (vendas.TotalPedido).toFixed(2) + '</td>';
            htmlVendaTroca += '<td>' + statusMap.get(vendas.StatusAtual) + '</td>';

            //if (vendas.StatusAtual == 7) {
            //    //htmlVendaTroca += '<td class="text-right">';
            //    //htmlVendaTroca += '<div class="dropdown show d-inline-block widget-dropdown">';
            //    //htmlVendaTroca += '<a class="dropdown-toggle icon-burger-mini" href="#" role="button" id="dropdown-recent-order' + j + '" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static"></a>';
            //    //htmlVendaTroca += '<ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-recent-order' + j + '" >';
            //    //htmlVendaTroca += '<li class="dropdown-item">';
            //    //htmlVendaTroca += '<a style="cursor: pointer;" class="Trocar" id="' + vendas.Id + '" name="' + vendas.Id + '">Trocar</a>';
            //    //htmlVendaTroca += '</li>';
            //    //htmlVendaTroca += '</ul>';
            //    //htmlVendaTroca += '</div>';
            //    //htmlVendaTroca += '</td>';

            //} else
            if (vendas.StatusAtual == 8) {
                htmlVendaTroca += '<td class="text-right">';
                htmlVendaTroca += '<div class="dropdown show d-inline-block widget-dropdown">';
                htmlVendaTroca += '<a class="dropdown-toggle icon-burger-mini" href="#" role="button" id="emTroca' + j + '" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static"></a>';
                htmlVendaTroca += '<ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-recent-order' + j + '" >';
                htmlVendaTroca += '<li class="dropdown-item">';
                htmlVendaTroca += '<a style="cursor: pointer;" class="AceitarTroca" id="' + vendas.Id + '" name="aceitarTroca">Aceitar Troca</a>';
                htmlVendaTroca += '</li>';
                htmlVendaTroca += '</ul>';
                htmlVendaTroca += '</div>';
                htmlVendaTroca += '</td>';

            } else if (vendas.StatusAtual == 9) {
                htmlVendaTroca += '<td class="text-right">';
                htmlVendaTroca += '</td>';
            }

            htmlVendaTroca += '</tr>';
            j++;

            if (htmlVendaTroca == '') {

            }

            return htmlVendaTroca;
        }

        return htmlVendaTroca;

    } catch (error) {
        console.log(error);
        alert("Erro na Comunicação com o Servidor...");
    }

}


function rendeziraHtmlTransito(vendas, k) {
    try {
        var htmlVendaTransito = '';
        if (vendas.StatusAtual == 6) {

            htmlVendaTransito += '<tr>';
            htmlVendaTransito += '<td>' + vendas.Id + '</td>';
            htmlVendaTransito += '<td>';
            htmlVendaTransito += '<a class="text-dark" href="">' + vendas.Cliente.Nome + '</a>';
            htmlVendaTransito += '</td>';
            htmlVendaTransito += '<td class="d-none d-md-table-cell">' + FormatarHora(vendas.DataCadastro) + '</td>';
            htmlVendaTransito += '<td class="d-none d-md-table-cell">' + vendas.TotalPedido + '</td>';
            htmlVendaTransito += '<td>' + statusMap.get(vendas.StatusAtual) + '</td>';

            if (vendas.StatusAtual == 6) {
                htmlVendaTransito += '<td class="text-right">';
                htmlVendaTransito += '<div class="dropdown show d-inline-block widget-dropdown">';
                htmlVendaTransito += '<a class="dropdown-toggle icon-burger-mini" href="#" role="button" id="emTransito' + k + '" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static"></a>';
                htmlVendaTransito += '<ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-recent-order' + k + '" >';
                htmlVendaTransito += '<li class="dropdown-item">';
                htmlVendaTransito += '<a href="#" class="EmTransito" id="' + vendas.Id + '" name="confirmarEntrega">Confirmar Entrega</a>';
                htmlVendaTransito += '</li>';
                htmlVendaTransito += '</ul>';
                htmlVendaTransito += '</div>';
                htmlVendaTransito += '</td>';

            } else if (vendas.StatusAtual == 3) {
                htmlVendaTransito += '<td class="text-right">';
                htmlVendaTransito += '</td>';

            }

            htmlVendaTransito += '</tr>';
            k++;

            return htmlVendaTransito;
        }

        return htmlVendaTransito;

    } catch (error) {
        console.log(error);
        alert("Erro na Comunicação com o Servidor...");
    }

}



function TrocarStatusAtivo(pedido) { //Troca o Status Ativo para Em Transito
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "15", mapKey: "PedidoModel", JsonString: JSON.stringify(pedido) },
        cache: false,
        beforeSend: function (xhr) {
            console.log("Trocando status de Ativo para EmTransito");
        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);
                    if (respostaControle.Codigo == 0) {
                        buscarVendas();
                    } else {
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


function TrocarStatusEmTransito(pedido) { //Troca o Status Em Transito para Entregue
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "16", mapKey: "PedidoModel", JsonString: JSON.stringify(pedido) },
        cache: false,
        beforeSend: function (xhr) {
            console.log("Trocando status de EmTransito para Entregue");
        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);
                    if (respostaControle.Codigo == 0) {
                        buscarVendas();
                    } else {
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


function TrocarStatusEmTroca(pedido) { //Troca o Status Em Transito para Entregue
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "17", mapKey: "PedidoModel", JsonString: JSON.stringify(pedido) },
        cache: false,
        beforeSend: function (xhr) {
            console.log("Trocando status de Entregue para EmTroca");
        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);
                    if (respostaControle.Codigo == 0) {
                        buscarVendas();
                    } else {
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



function TrocarStatusEmTroca(pedido) { //Troca o Status Em Transito para Entregue
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "18", mapKey: "PedidoModel", JsonString: JSON.stringify(pedido) },
        cache: false,
        beforeSend: function (xhr) {
            console.log("Trocando status de EmTroca para TrocaAutorizada");
        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);
                    if (respostaControle.Codigo == 0) {
                        buscarVendas();
                    } else {
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


function TrocarStatusTrocaAutorizada(pedido) { //Troca o Status Em Transito para Entregue
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "19", mapKey: "PedidoModel", JsonString: JSON.stringify(pedido) },
        cache: false,
        beforeSend: function (xhr) {
            console.log("Trocando status de TrocaAutorizada para Trocado");
        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);
                    if (respostaControle.Codigo == 0) {
                        buscarVendas();
                    } else {
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

function FormatarHora(DataRecebida) {


    var data = DataRecebida.split('T')[0].split('-');

    return data[2] + '/' + data[1] + '/' + data[0];
}