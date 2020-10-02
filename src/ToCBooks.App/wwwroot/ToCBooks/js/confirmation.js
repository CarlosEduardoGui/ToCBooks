

jQuery(document).ready(function () {
    CarregarDetalhes();
});


function CarregarDetalhes() {
    var Pedido = JSON.parse(localStorage.getItem('Ulltimo Pedido'));

    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 1, mapKey: 'PedidoModel', JsonString: JSON.stringify(Pedido) },
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
                        var EnderecoEntrega = resposta_controle.Dados[0].EnderecoEntrega;

                        jQuery("#pedido").html("Número da Ordem: " + resposta_controle.Dados[0].Id);
                        jQuery("#data_compra").html("Data: " + FormataData(resposta_controle.Dados[0].DataCadastro));
                        jQuery("#total_compra").html("Total: " + resposta_controle.Dados[0].TotalPedido);

                        jQuery("#Rua").html("Rua: " + EnderecoEntrega.Nome);
                        jQuery("#Cidade").html("Cidade: " + EnderecoEntrega.Cidade.Nome);
                        jQuery("#Estado").html("Estado: " + EnderecoEntrega.Cidade.Estado.Nome);
                        jQuery("#Pais").html("País: " + EnderecoEntrega.Cidade.Estado.Pais.Nome);
                        jQuery("#CEP").html("CEP: " + EnderecoEntrega.CEP);

                        var ItensPedido = resposta_controle.Dados[0].ItensPedido;

                        var htmlPedidos = '';
                        ItensPedido.forEach(Item => {
                            htmlPedidos += '<tr><td><p>' + Item.Livro.Titulo + '</p></td>';
                            htmlPedidos += '<td><h5>x ' + Item.Qtde + '</h5></td>';
                            htmlPedidos += '<td><p>R$' + (Item.Livro.Preco * Item.Qtde).toFixed(2) + '</p></td></tr>';
                        });

                        jQuery("#tbody_itens_pedidos").html(htmlPedidos);

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

function FormataData(Data) {
    return Data.split('T')[0].split('-')[2] + '/' + Data.split('T')[0].split('-')[2] + '/' + Data.split('T')[0].split('-')[0];;
}