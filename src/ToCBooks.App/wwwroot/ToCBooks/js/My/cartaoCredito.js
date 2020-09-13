jQuery(document).ready(function () {
    buscarCartaoCredito();
    jQuery("#btn_salvar").on("click", function (e) {
        e.preventDefault();

        var cartao = {
            numeroCartao: jQuery('#numeroCartao').val(),
            nome: jQuery('#nomeCartao').val(),
            codigoSeguranca: jQuery('#cvvCartao').val(),
            bandeira: jQuery('#eTipoBandeira').val(),
            clienteId: jQuery('#ClienteID').val()
        }

        cadastrarCartaoCredito(cartao);
    });
});

function cadastrarCartaoCredito(objeto) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "2", mapKey: "CartaoCreditoModel", JsonString: JSON.stringify({}) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var resposta_controle = JSON.parse(e.responseText);

                    if (resposta_controle.Codigo == 1) {
                        alert("Erro ao Cadastrar Cartão de Crédito..."
                            + "Campo errado" + resposta_controle.Resposta);
                    } else {
                        alert("Cartão de Crédito cadastrado com sucesso!");
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}

function buscarCartaoCredito() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "1", mapKey: "CartaoCreditoModel", JsonString: JSON.stringify({}) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 1)
                        alert("Erro ao Buscar Cartão de Crédito...");
                    else {
                        var htmlCartaoCredito = '';

                        respostaControle.Dados.forEach(CartaoCredito => {
                            var count = 1;
                            htmlCartaoCredito += '<div id="accordion">'
                            htmlCartaoCredito += '<div class="card">';
                            htmlCartaoCredito += '<input type="hidden" id="ClienteID" value="' + CartaoCredito.ClienteId + '"/>';
                            htmlCartaoCredito += '<div class="card-header>"';
                            htmlCartaoCredito += '<a class="card-link" data-toggle="collapse" href="#collapse' + count + '" Cartão de Crédito #' + count + '</a>';
                            htmlCartaoCredito += '<div class="card-switch">';
                            htmlCartaoCredito += '<div class="card-switch">';
                            htmlCartaoCredito += '</div>';
                            htmlCartaoCredito += '</div>';
                            htmlCartaoCredito += '</div>';
                            htmlCartaoCredito += '<div id="collapse' + count + '" class="collapse show" data-parent="#accordion">';
                            htmlCartaoCredito += '<div class="card-body">';
                            htmlCartaoCredito += '<div class="form-row">';
                            htmlCartaoCredito += '<div class="col-md-6 form-group">';
                            htmlCartaoCredito += '<input class="form-control" disabled placeholder="' + CartaoCredito.NumeroCartao + '"></input>';
                            htmlCartaoCredito += '</div>';
                            htmlCartaoCredito += '<div class="col-md-6 form-group">';
                            htmlCartaoCredito += '<input class="form-control" disabled placeholder="' + CartaoCredito.Nome + '"></input>';
                            htmlCartaoCredito += '</div>';
                            htmlCartaoCredito += '<div class="col-md-6 form-group">';
                            htmlCartaoCredito += '<input class="form-control" disabled placeholder="' + CartaoCredito.CodigoSeguranca + '"></input>';
                            htmlCartaoCredito += '</div>';
                            htmlCartaoCredito += '<div class="col-md-6 form-group">';
                            if (CartaoCredito.Bandeira == 1) {
                                htmlCartaoCredito += '<input class="form-control" disabled placeholder="Visa"></input>';
                            } else {
                                htmlCartaoCredito += '<input class="form-control" disabled placeholder="MasterCard"></input>';
                            }
                            htmlCartaoCredito += '</div>';
                            htmlCartaoCredito += '</div></div></div></div></div></div>';
                            count++;
                        });

                        jQuery("#tabelaCartaoCredito").html(htmlCartaoCredito);
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}