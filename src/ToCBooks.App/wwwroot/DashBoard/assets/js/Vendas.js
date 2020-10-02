
var statusMap = new Map();
statusMap.set(4, '<span class="badge badge-info">Em Processamento</span>');
statusMap.set(2, '<span class="badge badge-success">Aprovada</span>');
statusMap.set(3, '<span class="badge badge-danger">Reprovada</span>');


jQuery(document).ready(function () {
    ProcessarPedidosPendentes();

    jQuery(document).on('click', '.ver_pedidos_retornados', function () {
        jQuery("#modal_produtos_troca").modal("show");
    });

});


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
                        buscarVendas()
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
                        var htmlVendas = '';

                        htmlVendas += '<table class="table card-table table-responsive table-responsive-large" style = "width:100%" >';
                        htmlVendas += '<thead>';
                        htmlVendas += '<tr>';
                        htmlVendas += '<th>Número da Ordem</th>';
                        htmlVendas += '<th>Cliente</th>';
                        htmlVendas += '<th class="d-none d-md-table-cell">Data da Ordem</th>';
                        htmlVendas += '<th class="d-none d-md-table-cell">Preço</th>';
                        htmlVendas += '<th>Status</th>';
                        htmlVendas += '<th></th>';
                        htmlVendas += '<th></th>';
                        htmlVendas += '</tr>';
                        htmlVendas += '</thead>';
                        htmlVendas += '<tbody>';

                        respostaControle.Dados.forEach(vendas => {
                            htmlVendas += '<tr>';
                            htmlVendas += '<td>' + vendas.Id + '</td>';
                            htmlVendas += '<td>';
                            htmlVendas += '<a class="text-dark" href="">' + vendas.Cliente.Nome + '</a>';
                            htmlVendas += '</td>';
                            htmlVendas += '<td class="d-none d-md-table-cell">' + FormatarHora(vendas.DataCadastro) + '</td>';
                            htmlVendas += '<td class="d-none d-md-table-cell">' + vendas.TotalPedido + '</td>';
                            htmlVendas += '<td>' + statusMap.get(vendas.StatusAtual) + '</td>';
                            htmlVendas += '<td class="text-right">';
                            htmlVendas += '<div class="dropdown show d-inline-block widget-dropdown">';
                            htmlVendas += '<a class="dropdown-toggle icon-burger-mini" href="" role = "button" id = "dropdown-recent-order1" data - toggle="dropdown" aria - haspopup="true" aria - expanded="false" data - display="static" ></a >';
                            htmlVendas += '<ul class="dropdown-menu dropdown-menu-right" aria - labelledby="dropdown-recent-order1" >';
                            htmlVendas += '<li class="dropdown-item">';
                            htmlVendas += '<a href="#">Enviar para Entrega</a>';
                            htmlVendas += '</li>';
                            htmlVendas += '</ul>';
                            htmlVendas += '</div>';
                            htmlVendas += '</td>';
                            htmlVendas += '</tr>';
                        });

                        htmlVendas += '</tbody>';

                        if (htmlVendas == '') {

                        }

                        jQuery("#tvendas").html(htmlVendas);
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