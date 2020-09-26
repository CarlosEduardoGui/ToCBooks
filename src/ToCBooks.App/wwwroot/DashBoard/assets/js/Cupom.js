jQuery(document).ready(function () {

    jQuery("#btn_salvar_cupom").on('click', function (e) {
        e.preventDefault();

        if (jQuery("#form_cupom").valid())
            jQuery("#form_cupom").submit();
        else
            alert("Preencha o formulário corretamente...");
    });

    jQuery("#form_cupom").on("submit", function (e) {
        e.preventDefault();

        var formData = new FormData(this);
        var cupom;

        cupom = {
            nome: formData.get('nome'),
            desconto: formData.get('desconto')
        };

        console.log(cupom);

        cadastrarCupom(cupom);

    });
});

function cadastrarCupom(objeto) {

    console.log(objeto);

    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 2, mapKey: 'CupomModel', JsonString: JSON.stringify(objeto) },
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
                        alert("Cupom cadastrado com sucesso");
                    } else {
                        alert(resposta_controle.Resposta);
                    }

                } catch (error) {
                    console.log(error);
                }
            }
        }
    });
}


//function buscarCupons() {
//    jQuery.ajax({
//        type: "POST",
//        url: 'https://localhost:44354/Operations',
//        data: { oper: "1", mapKey: "CupomModel", JsonString: JSON.stringify({}) },
//        cache: false,
//        beforeSend: function (xhr) {

//        },
//        complete: function (e, xhr, result) {
//            if (e.readyState == 4 && e.status == 200) {

//                try {
//                    var respostaControle = JSON.parse(e.responseText);

//                    if (respostaControle.Codigo == 1) {
//                        alert("Erro ao Buscar Cartões de Crédito...");

//                    } else {
//                        var htmlCartaoCredito = '';
//                        var i = 1;
//                        var j = 1;

//                        if (respostaControle.Dados.length > 0) {
//                            respostaControle.Dados.forEach(cartaoCredito => {
//                                htmlCartaoCredito += '<input type="hidden" id="id_cliente_cartaoCredito" value="' + cartaoCredito.ClienteId + '"/>';
//                                htmlCartaoCredito += '<input type="hidden" id="id_cartaoCredito" value="' + cartaoCredito.Id + '"/>';
//                                htmlCartaoCredito += '<div class="card">';
//                                htmlCartaoCredito += '<div class="card-header">';
//                                htmlCartaoCredito += '<a class="card-link" data-toggle="collapse" href="#collapse' + i + '">Cartão de Crédito #' + j + ' </a>';
//                                htmlCartaoCredito += '<div class="card-switch">';
//                                htmlCartaoCredito += '<div>';
//                                htmlCartaoCredito += '<input type="checkbox" name="checkBox" class="form-check-input" id="checkBoxCartao"/>';
//                                htmlCartaoCredito += '<label class="form-check-label" for="checkBoxCartao">Usar este </label>';
//                                htmlCartaoCredito += '</div>';
//                                htmlCartaoCredito += '</div>';
//                                htmlCartaoCredito += '</div>';
//                                htmlCartaoCredito += '<div id="collapse' + i + '" class="collapse" data-parent="#cartaoCredito">';
//                                htmlCartaoCredito += '<div class="card-body">';
//                                htmlCartaoCredito += '<form>';
//                                htmlCartaoCredito += '<div class="form-row">';
//                                htmlCartaoCredito += '<div class="col-md-6 form-group">';
//                                htmlCartaoCredito += '<input type="text" class="form-control" readonly="true" id="numeroCartao" name="numeroCartao" value="' + cartaoCredito.NumeroCartao + '" />';
//                                htmlCartaoCredito += '</div>';
//                                htmlCartaoCredito += '<div class="col-md-6 form-group">';
//                                htmlCartaoCredito += '<input type="text" class="form-control" readonly="true" id="numeroCartao" name="numeroCartao" value="' + cartaoCredito.Nome + '" />';
//                                htmlCartaoCredito += '</div>';
//                                htmlCartaoCredito += '<div class="col-md-6 form-group">';
//                                htmlCartaoCredito += '<input type="text" class="form-control" readonly="true" id="numeroCartao" name="numeroCartao" value="' + cartaoCredito.CodigoSeguranca + '" />';
//                                htmlCartaoCredito += '</div>';
//                                if (cartaoCredito.Bandeira == 1) {
//                                    htmlCartaoCredito += '<div class="col-md-6 form-group">';
//                                    htmlCartaoCredito += '<input type="text" class="form-control" readonly="true" id="numeroCartao" name="numeroCartao" placeholder="Visa" value="1" />';
//                                    htmlCartaoCredito += '</div>';
//                                } else {
//                                    htmlCartaoCredito += '<div class="col-md-6 form-group">';
//                                    htmlCartaoCredito += '<input type="text" class="form-control" readonly="true" id="numeroCartao" name="numeroCartao" placeholder="Mastercard" value="2" />';
//                                    htmlCartaoCredito += '</div>';
//                                }
//                                htmlCartaoCredito += '</div>';
//                                htmlCartaoCredito += '</div>';
//                                htmlCartaoCredito += '</form>';
//                                htmlCartaoCredito += '</div>';
//                                htmlCartaoCredito += '</div>';
//                                htmlCartaoCredito += '</div>';


//                                i++;
//                                j++;
//                            });
//                        } else {
//                            htmlCartaoCredito += '<tr><td>Nenhum Registro Encontrado</td></tr>';
//                        }

//                        jQuery("#cartaoCredito").html(htmlCartaoCredito);
//                    }

//                } catch (error) {
//                    console.log(error);
//                    alert("Erro na Comunicação com o Servidor...");
//                }
//            }
//        }
//    });
//}