jQuery(document).ready(function () {
    buscarEnderecos();

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

        var enderecoEntrega = {
            nome: "Bolivia",
            tipologradouro: 1,
            tiporesidencia: 2,
            cep: "07500000",
            bairro: "Ouro Fino",
            numero: 164,
            observacao: "Testando o Cadastro",
            ClienteId: jQuery("#id_cliente_endereco").val(),
            cidade: cidade,
            principal: true
        };


        cadastrarEndereco(enderecoEntrega);

    });
});

function buscarEndereco(id_endereco) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "1", mapKey: "EnderecoEntregaModel", JsonString: JSON.stringify({ Id: id_endereco }) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0) {
                        var Endereco = respostaControle.Dados[0];

                        jQuery("#id_cliente").val(Endereco.ClienteId);
                        jQuery("#id_endereco").val(Endereco.Id);
                        jQuery("#enderecoCobrancaEtipologradouro").val(Endereco.TipoLogradouro);
                        jQuery("#enderecoCobranca").val(Endereco.Nome);
                        jQuery("#enderecoCobrancaEtiporesidencia").val(Endereco.TipoResidencia);
                        jQuery("#enderecoCobrancaCep").val(Endereco.CEP);
                        jQuery("#enderecoCobrancaBairro").val(Endereco.Bairro);
                        jQuery("#enderecoCobrancaNumero").val(Endereco.Numero);
                        jQuery("#id_cidade").val(Endereco.Cidade.Id);
                        jQuery("#enderecoCobrancaCidade").val(Endereco.Cidade.Nome);
                        jQuery("#id_estado").val(Endereco.Cidade.Estado.Id);
                        jQuery("#enderecoCobrancaEstado").val(Endereco.Cidade.Estado.Nome);
                        jQuery("#id_pais").val(Endereco.Cidade.Estado.Pais.Id);
                        jQuery("#enderecoCobrancaPais").val(Endereco.Cidade.Estado.Pais.Nome);
                        jQuery("#enderecoObservacoesCobranca").val(Endereco.Observacao);

                        jQuery("select").niceSelect("update");


                        jQuery("#modal_add_endereco").modal("show");
                    }
                    else
                        alert("Erro ao Buscar Livros...");

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
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

                    if (resposta_controle.Codigo == 0)
                        buscarEnderecos();

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
                                htmlEndereco += '<div class="card">';
                                htmlEndereco += '<div class="card-header">';
                                htmlEndereco += '<a class="card-link" data-toggle="collapse" href="#collapse' + i + '">Endereço de Entrega #' + j + ' </a>';
                                htmlEndereco += '<div class="card-switch">';
                                htmlEndereco += '<div>';
                                htmlEndereco += '<input type="radio" name="checkBox" class="form-check-input" id="checkBox"/>';
                                htmlEndereco += '<label class="form-check-label" for="checkBox">Usar este </label>';
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