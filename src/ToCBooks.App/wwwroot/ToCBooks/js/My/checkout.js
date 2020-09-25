jQuery(document).ready(function () {
    buscarEnderecos();
    buscarCartoesCredito();

    jQuery("#btn_salvar_endereco").on('click', function (e) {
        e.preventDefault();

        if (jQuery("#form_endereco").valid())
            jQuery("#form_endereco").submit();
        else
            alert("Preencha o formulário corretamente...");
    });

    jQuery("#form_endereco").on("submit", function (e) {
        e.preventDefault();

        var formData = new FormData(this);
        var enderecoEntrega, cidade, estado, pais;


        pais = {
            nome: formData.get('enderecoEntregaPais'),
        };


        estado = {
            nome: formData.get('enderecoEntregaEstado'),
            pais: pais
        };

        cidade = {
            nome: formData.get('enderecoEntregaCidade'),
            estado: estado
        };

        enderecoEntrega = {
            nome: formData.get('enderecoEntrega'),
            tipologradouro: formData.get('enderecoEntregaEtipologradouro'),
            tiporesidencia: formData.get('enderecoEntregaEtiporesidencia'),
            cep: formData.get('enderecoEntregaCep'),
            bairro: formData.get('enderecoEntregaBairro'),
            numero: formData.get('enderecoEntregaNumero'),
            ClienteId: jQuery("#id_cliente_endereco").val(),
            cidade: cidade,
            principal: true
        };

        cadastrarEndereco(enderecoEntrega);

    });


    jQuery("#btn_salvar_cartaoCredito").on('click', function (e) {
        e.preventDefault();

        if (jQuery("#form_cartaoCredito").valid())
            jQuery("#form_cartaoCredito").submit();
        else
            alert("Preencha o formulário corretamente...");
    });

    jQuery("#form_cartaoCredito").on("submit", function (e) {
        e.preventDefault();

        var formData = new FormData(this);
        var cartaoCredito;


        cartaoCredito = {
            numeroCartao: formData.get('numeroCartao'),
            nome: formData.get('nomeCartao'),
            CodigoSeguranca: formData.get('cvvCartao'),
            Bandeira: formData.get('bandeiraCartao'),
            ClienteId: jQuery("#id_cliente_cartaoCredito").val(),
            DataVencimento: formData.get('dataVencimento'),
            principal: true
        };

        cadastrarCartaoCredito(cartaoCredito);

    });
});


function cadastrarEndereco(objeto) {

    console.log(objeto);

    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 2, mapKey: 'EnderecoEntregaModel', JsonString: JSON.stringify(objeto) },
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
                        buscarEnderecos();
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


function buscarEnderecos() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "1", mapKey: "EnderecoEntregaModel", JsonString: JSON.stringify({}) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 1)
                        alert("Erro ao Buscar Endereços...");
                    else {
                        var htmlEndereco = '';
                        var i = 1;
                        var j = 1;

                        if (respostaControle.Dados.length > 0) {
                            respostaControle.Dados.forEach(endereco => {
                                htmlEndereco += '<input type="hidden" id="id_cliente_endereco" value="' + endereco.ClienteId + '"/>';
                                htmlEndereco += '<input type="hidden" id="id_endereco" value="' + endereco.Id + '"/>';
                                htmlEndereco += '<div class="card">';
                                htmlEndereco += '<div class="card-header">';
                                htmlEndereco += '<a class="card-link" data-toggle="collapse" href="#collapse' + i + '">Endereço de Entrega #' + j + ' </a>';
                                htmlEndereco += '<div class="card-switch">';
                                htmlEndereco += '<div>';
                                htmlEndereco += '<input type="radio" name="checkBox" class="form-check-input" id="checkBoxEndereco"/>';
                                htmlEndereco += '<label class="form-check-label" for="checkBoxEndereco">Usar este </label>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '<div id="collapse' + i + '" class="collapse" data-parent="#enderecoEntrega">';
                                htmlEndereco += '<div class="card-body">';
                                htmlEndereco += '<form>';
                                htmlEndereco += '<div class="form-row">';
                                htmlEndereco += '<div class="col-md-3 form-group">';
                                htmlEndereco += '<select ><option>' + endereco.TipoLogradouro + '</option></select>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '<div class="col-md-3 form-group">';
                                htmlEndereco += '<select ><option>' + endereco.TipoResidencia + '</option></select>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '<div class="form-group col-md-6">';
                                htmlEndereco += '<input type="text" class="form-control" value="' + endereco.Nome + '" readonly="true"/>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '<div class="form-group col-md-4">';
                                htmlEndereco += '<input type="text" class="form-control"  value="' + endereco.CEP + '" readonly="true"/>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '<div class="form-group col-md-8">';
                                htmlEndereco += '<input type="text" class="form-control"  value="' + endereco.Bairro + '" readonly="true"/>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '<div class="form-group col-md-4">';
                                htmlEndereco += '<input type="text" class="form-control"  value="' + endereco.Numero + '" readonly="true"/>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '<div class="form-group col-md-8">';
                                htmlEndereco += '<input type="text" class="form-control" value="' + endereco.Cidade.Nome + '" readonly="true"/>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '<div class="form-group col-md-6">';
                                htmlEndereco += '<input type="text" class="form-control" value="' + endereco.Cidade.Estado.Nome + '" readonly="true"/>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '<div class="form-group col-md-6">';
                                htmlEndereco += '<input type="text" class="form-control" value="' + endereco.Cidade.Estado.Pais.Nome + '" readonly="true"/>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '</form>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '</div>';


                                i++;
                                j++;
                            });
                        } else {
                            htmlEndereco += '<tr><td>Nenhum Registro Encontrado</td></tr>';
                        }

                        jQuery("#enderecoEntrega").html(htmlEndereco);
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}


function cadastrarCartaoCredito(objeto) {

    console.log(objeto);

    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 2, mapKey: 'CartaoCreditoModel', JsonString: JSON.stringify(objeto) },
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
                        buscarCartoesCredito();
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


function buscarCartoesCredito() {
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

                    if (respostaControle.Codigo == 1) {
                        alert("Erro ao Buscar Cartões de Crédito...");

                    } else {
                        var htmlCartaoCredito = '';
                        var i = 1;
                        var j = 1;

                        if (respostaControle.Dados.length > 0) {
                            respostaControle.Dados.forEach(cartaoCredito => {
                                htmlCartaoCredito += '<input type="hidden" id="id_cliente_cartaoCredito" value="' + cartaoCredito.ClienteId + '"/>';
                                htmlCartaoCredito += '<input type="hidden" id="id_cartaoCredito" value="' + cartaoCredito.Id + '"/>';
                                htmlCartaoCredito += '<div class="card">';
                                htmlCartaoCredito += '<div class="card-header">';
                                htmlCartaoCredito += '<a class="card-link" data-toggle="collapse" href="#collapse' + i + '">Cartão de Crédito #' + j + ' </a>';
                                htmlCartaoCredito += '<div class="card-switch">';
                                htmlCartaoCredito += '<div>';
                                htmlCartaoCredito += '<input type="checkbox" name="checkBox" class="form-check-input" id="checkBoxCartao"/>';
                                htmlCartaoCredito += '<label class="form-check-label" for="checkBoxCartao">Usar este </label>';
                                htmlCartaoCredito += '</div>';
                                htmlCartaoCredito += '</div>';
                                htmlCartaoCredito += '</div>';
                                htmlCartaoCredito += '<div id="collapse' + i + '" class="collapse" data-parent="#cartaoCredito">';
                                htmlCartaoCredito += '<div class="card-body">';
                                htmlCartaoCredito += '<form>';
                                htmlCartaoCredito += '<div class="form-row">';
                                htmlCartaoCredito += '<div class="col-md-6 form-group">';
                                htmlCartaoCredito += '<input type="text" class="form-control" readonly="true" id="numeroCartao" name="numeroCartao" value="' + cartaoCredito.NumeroCartao + '" />';
                                htmlCartaoCredito += '</div>';
                                htmlCartaoCredito += '<div class="col-md-6 form-group">';
                                htmlCartaoCredito += '<input type="text" class="form-control" readonly="true" id="numeroCartao" name="numeroCartao" value="' + cartaoCredito.Nome + '" />';
                                htmlCartaoCredito += '</div>';
                                htmlCartaoCredito += '<div class="col-md-6 form-group">';
                                htmlCartaoCredito += '<input type="text" class="form-control" readonly="true" id="numeroCartao" name="numeroCartao" value="' + cartaoCredito.CodigoSeguranca + '" />';
                                htmlCartaoCredito += '</div>';
                                if (cartaoCredito.Bandeira == 1) {
                                    htmlCartaoCredito += '<div class="col-md-6 form-group">';
                                    htmlCartaoCredito += '<input type="text" class="form-control" readonly="true" id="numeroCartao" name="numeroCartao" placeholder="Visa" value="1" />';
                                    htmlCartaoCredito += '</div>';
                                } else {
                                    htmlCartaoCredito += '<div class="col-md-6 form-group">';
                                    htmlCartaoCredito += '<input type="text" class="form-control" readonly="true" id="numeroCartao" name="numeroCartao" placeholder="Mastercard" value="2" />';
                                    htmlCartaoCredito += '</div>';
                                }
                                htmlCartaoCredito += '</div>';
                                htmlCartaoCredito += '</div>';
                                htmlCartaoCredito += '</form>';
                                htmlCartaoCredito += '</div>';
                                htmlCartaoCredito += '</div>';
                                htmlCartaoCredito += '</div>';


                                i++;
                                j++;
                            });
                        } else {
                            htmlCartaoCredito += '<tr><td>Nenhum Registro Encontrado</td></tr>';
                        }

                        jQuery("#cartaoCredito").html(htmlCartaoCredito);
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}