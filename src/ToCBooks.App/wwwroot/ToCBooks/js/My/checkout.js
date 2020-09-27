
var CupomTemp = null;



jQuery(document).ready(function () {
    buscarEnderecos();
    buscarCartoesCredito();
    BuscarCarrinho();

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

    jQuery("#btn_aplicar_cupom").on('click', function () {
        CupomTemp = { Nome: jQuery("#input_cupom").val() };

        if (CupomTemp.Nome == '') {
            alert("Cupom Inválido");
            return;
        }

        alert("Cupom Aplicado");
    });

    jQuery("#btn_confirmar_compra").on('click', function () {

        var Endereco;
        jQuery(".endereco_check").each(function () {
            if (jQuery(this).is(":checked")) 
                Endereco = { Id: jQuery(this).attr('id_endereco') };
        });

        var CartoesCredito = new Array();
        jQuery(".cartao_credito_check").each(function () {
            if (jQuery(this).is(":checked")) {
                var CartaoCredito = { Id: jQuery(this).attr('id_cartao') };
                CartoesCredito.push(CartaoCredito);
            }
        });

        if (Endereco == null) {
            alert("Selecione ao menos um Endereço de Entrega...");
            return;
        }

        if (CartoesCredito.length <= 0) {
            alert("Selecione ao menos um Cartão de Crédito...");
            return;
        }

        var Pedido;
        if (CupomTemp != null)
            Pedido = { EnderecoEntrega: Endereco, CartoesCredito: CartoesCredito, Cupom: CupomTemp };
        else
            Pedido = { EnderecoEntrega: Endereco, CartoesCredito: CartoesCredito };

        
        ConfimarPedido(Pedido);
    });
});

function ConfimarPedido(ObjetoEnvio) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 13, mapKey: 'PedidoModel', JsonString: JSON.stringify(ObjetoEnvio) },
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
                        window.location.href = "/ToCBooks/confirmation.html";
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
                        var htmlLista = '<li><a>Produto <span>Total</span><a></li>';
                        Carrinho.Itens.forEach(Item => {
                            htmlLista += '<li><a>' + Item.Livro.Titulo + '<span class="middle">x ' + Item.Qtde + '</span> <span class="last">R$' + (Item.Qtde * Item.Livro.Preco).toFixed(2) + '</span></a></li>';
                            TotalCompra += (Item.Qtde * Item.Livro.Preco);
                        });

                        jQuery("#lista_produtos").html(htmlLista);
                        jQuery("#span_total_compra").html("R$" + TotalCompra);
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
                                htmlEndereco += '<input type="radio" id_endereco="' + endereco.Id + '" name="checkBox" class="form-check-input endereco_check"/>';
                                htmlEndereco += '<label class="form-check-label" for="checkBoxEndereco">Usar este </label>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '<div id="collapse' + i + '" class="collapse" data-parent="#enderecoEntrega">';
                                htmlEndereco += '<div class="card-body">';
                                htmlEndereco += '<input type="hidden" value="' + endereco.Id + '" />';
                                htmlEndereco += '<div class="form-row">';
                                htmlEndereco += '<div class="col-md-3 form-group">';
                                htmlEndereco += '<select class="form-control" ><option>' + endereco.TipoLogradouro + '</option></select>';
                                htmlEndereco += '</div>';
                                htmlEndereco += '<div class="col-md-3 form-group">';
                                htmlEndereco += '<select class="form-control"><option>' + endereco.TipoResidencia + '</option></select>';
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
                                htmlCartaoCredito += '<input type="checkbox" name="checkBox" id_cartao="' + cartaoCredito.Id + '" class="form-check-input cartao_credito_check" />';
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