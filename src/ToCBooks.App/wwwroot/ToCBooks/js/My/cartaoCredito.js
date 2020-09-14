var idEntidadeTemp;

jQuery(document).ready(function () {
    buscarCartaoCredito();

    jQuery(document).on('click', '.excluir', function () {
        idEntidadeTemp = jQuery(this).attr('id_cartaoCredito');
        jQuery("#modal_confirmacao_delecao").modal('show');
    });


    jQuery("#btn_sim").on('click', function (e) {
        e.preventDefault();

        excluirCartaoCredito(idEntidadeTemp);
    });


    jQuery("#btn_nao").on('click', function (e) {
        e.preventDefault();

        jQuery("#modal_confirmacao_delecao").modal('hide');
    });


    jQuery("#btn_add_cartaoCredito").on('click', function (e) {
        e.preventDefault();

        jQuery("#modal_add_cartaoCredito").modal("show");
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

        var cartao = {
            numeroCartao: formData.get('numeroCartao'),
            nome: formData.get('nomeCartao'),
            codigoSeguranca: formData.get('cvvCartao'),
            dataVencimento: formData.get('dataVencimento'),
            bandeira: formData.get('eTipoBandeira'),
            clienteId: jQuery("#id_cliente").val()
        };

        cadastrarCartaoCredito(cartao);

    });

    jQuery("#btn_testar").on('click', function () {

        var cartao = {
            NumeroCartao: "4321 4321 4321 4321",
            Nome: "Eduardo Carlos",
            CodigoSeguranca: "123",
            DataVencimento: "2029-01-01",
            Bandeira: 2,
            Principal: true,
            ClienteId: jQuery("#id_cliente").val()
        };


        cadastrarCartaoCredito(cartao);

    });
});

function cadastrarCartaoCredito(objeto) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "2", mapKey: "CartaoCreditoModel", JsonString: JSON.stringify(objeto) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var resposta_controle = JSON.parse(e.responseText);

                    if (resposta_controle.Codigo == 0) {
                        buscarCartaoCredito();

                        jQuery("#modal_add_endereco").modal("hide");
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
                    var htmlCartaoCredito = '';

                    if (respostaControle.Dados.length > 0) {
                        respostaControle.Dados.forEach(cartaoCredito => {
                            htmlCartaoCredito += '<tr><td>' + cartaoCredito.NumeroCartao + '</td>';
                            htmlCartaoCredito += '<td>' + cartaoCredito.DataVencimento + '</td>';
                            htmlCartaoCredito += '<td>' + cartaoCredito.Nome + '</td>';
                            if (cartaoCredito.Bandeira == 1) {
                                htmlCartaoCredito += '<td>Visa</td>';
                            } else {
                                htmlCartaoCredito += '<td>MasterCard</td>';
                            }
                            
                            htmlCartaoCredito += '<td>' + cartaoCredito.CodigoSeguranca + '</td>';
                            htmlCartaoCredito += '<td><a style="cursor:pointer;" id_cartaoCredito="' + cartaoCredito.Id + ' class="editar""><i style="font-size: 20px;" class="far fa-edit"></i></a> | ';
                            htmlCartaoCredito += ' <a style="cursor:pointer;" id_cartaoCredito="' + cartaoCredito.Id + '" class="excluir"><i style="font-size: 20px;" class="far fa-trash-alt"></i></td></tr>';


                            jQuery("#id_cliente").val(cartaoCredito.ClienteId);
                        });
                    } else {
                        htmlCartaoCredito += '<tr><td>Nenhum Registro Encontrado</td></tr>';
                    }

                    jQuery("#tbody_table_cartaoCredito").html(htmlCartaoCredito);

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}

function excluirCartaoCredito(id_cartaoCredito) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "4", mapKey: "CartaoCreditoModel", JsonString: JSON.stringify({ Id: id_cartaoCredito }) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0)
                        buscarCartaoCredito();
                    else
                        alert(respostaControle.Resposta);

                    jQuery("#modal_confirmacao_delecao").modal('hide');

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}

function edicaoCartaoCredito(){
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
                    var htmlCartaoCredito = '';

                    if (respostaControle.Dados.length > 0) {
                        respostaControle.Dados.forEach(cartaoCredito => {
                            htmlCartaoCredito += '<tr><td>' + cartaoCredito.NumeroCartao + '</td>';
                            htmlCartaoCredito += '<td>' + cartaoCredito.DataVencimento + '</td>';
                            htmlCartaoCredito += '<td>' + cartaoCredito.Nome + '</td>';
                            if (cartaoCredito.Bandeira == 1) {
                                htmlCartaoCredito += '<td>Visa</td>';
                            } else {
                                htmlCartaoCredito += '<td>MasterCard</td>';
                            }

                            htmlCartaoCredito += '<td>' + cartaoCredito.CodigoSeguranca + '</td>';
                            htmlCartaoCredito += '<td><a style="cursor:pointer;" id_cartaoCredito="' + cartaoCredito.Id + ' class="editar""><i style="font-size: 20px;" class="far fa-edit"></i></a> | ';
                            htmlCartaoCredito += ' <a style="cursor:pointer;" id_cartaoCredito="' + cartaoCredito.Id + '" class="excluir"><i style="font-size: 20px;" class="far fa-trash-alt"></i></td></tr>';


                            jQuery("#id_cliente").val(cartaoCredito.ClienteId);
                        });
                    } else {
                        htmlCartaoCredito += '<tr><td>Nenhum Registro Encontrado</td></tr>';
                    }

                    jQuery("#tbody_table_cartaoCredito").html(htmlCartaoCredito);

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}