var idEntidadeTemp;


jQuery(document).ready(function () {
    buscarEnderecos();

    jQuery(document).on('click', '.excluir', function () {
        idEntidadeTemp = jQuery(this).attr('id_endereco');
        jQuery("#modal_confirmacao_delecao").modal('show');
    });

    jQuery("#btn_sim").on('click', function (e) {
        e.preventDefault();

        excluirEndereco(idEntidadeTemp);
    });

    jQuery("#btn_nao").on('click', function (e) {
        e.preventDefault();

        jQuery("#modal_confirmacao_delecao").modal('hide');
    });

    jQuery("#btn_add_endereco").on('click', function (e) {
        e.preventDefault();

        jQuery("#modal_add_endereco").modal("show");
    });

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

        var pais = {
            nome: formData.get('enderecoCobrancaPais'),
        };


        var estado = {
            nome: formData.get('enderecoCobrancaEstado'),
            pais: pais
        };

        var cidade = {
            nome: formData.get('enderecoCobrancaCidade'),
            estado: estado
        };

        var enderecoCobranca = {
            nome: formData.get('enderecoCobranca'),
            tipologradouro: formData.get('enderecoCobrancaEtipologradouro'),
            tiporesidencia: formData.get('enderecoCobrancaEtiporesidencia'),
            cep: formData.get('enderecoCobrancaCep'),
            bairro: formData.get('enderecoCobrancaBairro'),
            numero: formData.get('enderecoCobrancaNumero'),
            observacao: formData.get('enderecoObservacoesCobranca'),
            ClienteId: jQuery("#id_cliente").val(),
            cidade: cidade,
            principal: true
        };

        cadastrarEndereco(enderecoCobranca);

    });

    jQuery("#btn_testar").on('click', function () {
        var pais = {
            nome: "Brasil"
        };


        var estado = {
            nome: "São Paulo",
            pais: pais
        };

        var cidade = {
            nome: "Santa Isabel",
            estado: estado
        };

        var enderecoCobranca = {
            nome: "Bolivia",
            tipologradouro: 1,
            tiporesidencia: 2,
            cep: "17500000",
            bairro: "Ouro Fino",
            numero: 164,
            observacao: "Testando o Cadastro",
            ClienteId: jQuery("#id_cliente").val(),
            cidade: cidade,
            principal: true
        };


        cadastrarEndereco(enderecoCobranca);

    });

}) 

function cadastrarEndereco(objeto) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 2, mapKey: 'EnderecoCobrancaModel', JsonString: JSON.stringify(objeto) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            console.log(e.readyState);
            console.log(e.status);
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var resposta_controle = JSON.parse(e.responseText);

                    if (resposta_controle.Codigo == 0)
                        buscarEnderecos();

                    
                    jQuery("#modal_add_endereco").modal("hide");
                } catch (error) {
                    console.log(error);
                }
            }
        }
    });
}

function excluirEndereco(id_endereco) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "4", mapKey: "EnderecoCobrancaModel", JsonString: JSON.stringify({ Id: id_endereco }) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0)
                        buscarEnderecos();
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


function buscarEnderecos() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "1", mapKey: "EnderecoCobrancaModel", JsonString: JSON.stringify({})},
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
                        var htmlLivros = '';

                        if (respostaControle.Dados.length > 0) {
                            respostaControle.Dados.forEach(endereco => {
                                htmlLivros += '<tr><td>' + endereco.Nome + '</td>';
                                htmlLivros += '<td>' + endereco.Numero + '</td>';
                                htmlLivros += '<td>' + endereco.Bairro + '</td>';
                                htmlLivros += '<td><a style="cursor:pointer;" id_endereco="' + endereco.Id + ' class="editar""><i style="font-size: 20px;" class="far fa-edit"></i></a> | ';
                                htmlLivros += ' <a style="cursor:pointer;" id_endereco="' + endereco.Id + '" class="excluir"><i style="font-size: 20px;" class="far fa-trash-alt"></i></td></tr>';


                                jQuery("#id_cliente").val(endereco.ClienteId);
                            });
                        } else {
                            htmlLivros += '<tr><td>Nenhum Registro Encontrado</td></tr>';
                        }

                        jQuery("#tbody_table_endereco").html(htmlLivros);
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}