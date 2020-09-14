

jQuery(document).ready(function () {
    buscarClientes();

    jQuery("#btn_consultar").on('click', function () {
        jQuery("#modal_busca").modal("show");
    });

    jQuery(document).on('click', '.editar_livro', function () {
        buscarCliente(jQuery(this).attr('id_cliente'));;
    });

    jQuery("#btn_consultar_clientes").on("click", function () {

        var Login = { Email: jQuery("#cons_email").val() };
        var Telefone = { Numero: jQuery("#cons_telefone").val() };

        var ObjetoConsulta = {
            Nome: jQuery("#cons_nome").val(), CPF: jQuery("#cons_cpf").val(), Login: Login, Telefone: Telefone
        }

        consultarCliente(ObjetoConsulta);
    });

    jQuery(document).on('click', '.inativar', function () {
        desativarCliente({ Id: jQuery(this).attr("id_cliente") });
    });
});

function desativarCliente(objetoEnvio) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "3", mapKey: "ClienteModel", JsonString: JSON.stringify(objetoEnvio) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {
                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 1)
                        alert("Erro ao Desativar Livro...");
                    else {
                        buscarClientes();
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}

function consultarCliente(objetoEnvio) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 5, mapKey: "ClienteModel", JsonString: JSON.stringify(objetoEnvio) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 1)
                        alert("Erro ao Buscar Livros...");
                    else {
                        var htmlTabela = '';

                        respostaControle.Dados.forEach(Cliente => {
                            htmlTabela += '<div class="media d-flex mb-5">';
                            htmlTabela += '<div class="media-body align-self-center">';
                            htmlTabela += '<a href="#"><h6 class="mb-3 text-dark font-weight-medium">';
                            htmlTabela += Cliente.Nome + '</h6></a><p class="float-md-right">';
                            htmlTabela += '<button id_cliente="' + Cliente.Id + '" class="text-black-50 mr-2 font-size-20 editar_livro">';
                            htmlTabela += '<strong><i class="mdi mdi-table-search"></i></strong></button> | '; 
                            htmlTabela += '<a style="cursor: pointer" id_cliente="' + Cliente.Id + '" class="inativar"><i class="mdi mdi-trash-can"></i></a>';
                            htmlTabela += '</p><p class="d-none d-md-block">' + Cliente.Login.Email;
                            htmlTabela += '</p></div></div>';
                        });

                        if (htmlTabela == '') {
                            htmlTabela += '<div class="media d-flex mb-5">';
                            htmlTabela += '<div class="media-body align-self-center">';
                            htmlTabela += 'Nenhum Registro Encontrado<a href="#"><h6 class="mb-3 text-dark font-weight-medium">';
                            htmlTabela += '</h6></a><p class="float-md-right">';
                            htmlTabela += '<strong><i class="mdi mdi-table-search"></i></strong></button >';
                            htmlTabela += '</p><p class="d-none d-md-block">';
                            htmlTabela += '</p></div></div>';
                        }
                    }
                    jQuery("#modal_busca").modal("hide");
                    jQuery("#tabela_clientes").html(htmlTabela);
                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}


function buscarCliente(id_cliente) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "1", mapKey: "ClienteModel", JsonString: JSON.stringify({ Id: id_cliente }) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0) {
                        var Cliente = respostaControle.Dados[0];

                        jQuery("#busca_nome").val(Cliente.Nome);
                        jQuery("#busca_cpf").val(Cliente.CPF);
                        jQuery("#busca_email").val(Cliente.Login.Email);
                        jQuery("#busca_telefone").val(Cliente.Telefone.Numero);

                        jQuery("#enderecoCobrancaEtipologradouro").val(Cliente.EnderecoCobranca[0].TipoLogradouro);
                        jQuery("#enderecoCobrancaNome").val(Cliente.EnderecoCobranca[0].Nome);
                        jQuery("#enderecoCobrancaEtiporesidencia").val(Cliente.EnderecoCobranca[0].TipoResidencia);
                        jQuery("#enderecoCobrancaCep").val(Cliente.EnderecoCobranca[0].CEP);
                        jQuery("#enderecoCobrancaBairro").val(Cliente.EnderecoCobranca[0].Bairro);
                        jQuery("#enderecoCobrancaNumero").val(Cliente.EnderecoCobranca[0].Numero);
                        jQuery("#enderecoCobrancaCidade").val(Cliente.EnderecoCobranca[0].Cidade.Nome);
                        jQuery("#enderecoCobrancaEstado").val(Cliente.EnderecoCobranca[0].Cidade.Estado.Nome);
                        jQuery("#enderecoCobrancaPais").val(Cliente.EnderecoCobranca[0].Cidade.Estado.Pais.Nome);

                        jQuery("#enderecoEntregaEtipologradouro").val(Cliente.EnderecoEntrega[0].TipoLogradouro);
                        jQuery("#enderecoEntregaNome").val(Cliente.EnderecoEntrega[0].Nome);
                        jQuery("#enderecoEntregaEtiporesidencia").val(Cliente.EnderecoEntrega[0].TipoResidencia);
                        jQuery("#enderecoEntregaCep").val(Cliente.EnderecoEntrega[0].CEP);
                        jQuery("#enderecoEntregaBairro").val(Cliente.EnderecoEntrega[0].Bairro);
                        jQuery("#enderecoEntregaNumero").val(Cliente.EnderecoEntrega[0].Numero);
                        jQuery("#enderecoEntregaCidade").val(Cliente.EnderecoEntrega[0].Cidade.Nome);
                        jQuery("#enderecoEntregaEstado").val(Cliente.EnderecoEntrega[0].Cidade.Estado.Nome);
                        jQuery("#enderecoEntregaPais").val(Cliente.EnderecoEntrega[0].Cidade.Estado.Pais.Nome);

                        jQuery("#numeroCartao").val(Cliente.CartaoCredito[0].NumeroCartao);
                        jQuery("#nomeCartao").val(Cliente.CartaoCredito[0].Nome);
                        jQuery("#cvvCartao").val(Cliente.CartaoCredito[0].CodigoSeguranca);
                        jQuery("#bandeira_Cartao").val(Cliente.CartaoCredito[0].Bandeira);

                        jQuery("#modal_show_cliente").modal('show');
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

function buscarClientes() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "1", mapKey: "ClienteModel", JsonString: JSON.stringify({}) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 1)
                        alert("Erro ao Buscar Livros...");
                    else {
                        var htmlTabela = '';

                        respostaControle.Dados.forEach(Cliente => {
                            htmlTabela += '<div class="media d-flex mb-5">';
                            htmlTabela += '<div class="media-body align-self-center">';
                            htmlTabela += '<a href="#"><h6 class="mb-3 text-dark font-weight-medium">';
                            htmlTabela += Cliente.Nome + '</h6></a><p class="float-md-right">';
                            htmlTabela += '<button id_cliente="' + Cliente.Id + '" class="text-black-50 mr-2 font-size-20 editar_livro">';
                            htmlTabela += '<strong><i class="mdi mdi-table-search"></i></strong></button> | '
                            htmlTabela += '<a style="cursor: pointer" id_cliente="' + Cliente.Id + '" class="inativar"><i class="mdi mdi-trash-can"></i></a>';
                            htmlTabela += '</p><p class="d-none d-md-block">' + Cliente.Login.Email;
                            htmlTabela += '</p></div></div>';
                        });

                        if (htmlTabela == '') {
                            htmlTabela += '<div class="media d-flex mb-5">';
                            htmlTabela += '<div class="media-body align-self-center">';
                            htmlTabela += 'Nenhum Registro Encontrado<a href="#"><h6 class="mb-3 text-dark font-weight-medium">';
                            htmlTabela += '</h6></a><p class="float-md-right">';
                            htmlTabela += '</p><p class="d-none d-md-block">';
                            htmlTabela += '</p></div></div>';
                        }

                        jQuery("#tabela_clientes").html(htmlTabela);
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}