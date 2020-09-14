jQuery(document).ready(function () {
    jQuery("#btn_salvar").on("click", function (e) {
        e.preventDefault();

        var login = {
            email: jQuery('#email').val(),
            senha: jQuery('#senha1').val()
        };

        var cartaoCredito = {
            numeroCartao: jQuery('#numeroCartao').val(),
            nome: jQuery('#nomeCartao').val(),
            codigoSeguranca: jQuery('#codigoSeguranca').val(),
            dataVencimento: jQuery('#dataVencimento').val(),
            bandeira: jQuery('#etipoCartao').val()
        };

        var telefone = {
            ddd: jQuery('#ddd').val(),
            numero: jQuery('#telefone').val(),
            tipo: jQuery('#etipotelefone').val()
        };

        var paisCobranca = {
            nome: jQuery('#enderecoCobrancaPais').val(),
        };


        var estadoCobranca = {
            nome: jQuery('#enderecoCobrancaEstado').val(),
            pais: paisCobranca
        };

        var cidadeCobranca = {
            nome: jQuery('#enderecoCobrancaCidade').val(),
            estado: estadoCobranca
        };

        var paisEntrega = {
            nome: jQuery('#enderecoEntregaPais').val()
        };

        var estadoEntrega = {
            nome: jQuery('#enderecoEntregaEstado').val(),
            pais: paisEntrega
        };

        var cidadeEntrega = {
            nome: jQuery('#enderecoEntregaCidade').val(),
            estado: estadoEntrega
        };


        var enderecoCobranca = {
            nome: jQuery('#enderecoCobranca').val(),
            tipologradouro: jQuery('#enderecoCobrancaEtipologradouro').val(),
            tiporesidencia: jQuery('#enderecoCobrancaEtiporesidencia').val(),
            cep: jQuery('#enderecoCobrancaCep').val(),
            bairro: jQuery('#enderecoCobrancaBairro').val(),
            numero: jQuery('#enderecoCobrancaNumero').val(),
            observacao: jQuery('#enderecoObservacoesCobranca').val(),
            cidade: cidadeCobranca,
            principal: true
        };

        var enderecoEntrega = {
            nome: jQuery('#enderecoEntrega').val(),
            tipologradouro: jQuery('#enderecoEntregaEtipologradouro').val(),
            tipoResidencia: jQuery('#enderecoEntregaEtiporesidencia').val(),
            cep: jQuery('#enderecoEntregaCep').val(),
            bairro: jQuery('#enderecoEntregaBairro').val(),
            numero: jQuery('#enderecoEntregaNumero').val(),
            observacao: jQuery('#enderecoObservacoesEntrega').val(),
            cidade: cidadeEntrega,
            principal: true
        };

        var Object = {
            nome: jQuery('#nome').val(),
            cpf: jQuery('#cpf').val(),
            login: login,
            telefone: telefone,
            genero: jQuery('#genero').val(),
            datanascimento: jQuery('#dataNascimento').val(),
            enderecoCobranca: [enderecoCobranca],
            enderecoEntrega: [enderecoEntrega],
            tipoUsuario: 2,
            tipoGenero: jQuery('#genero').val(),
            cartaoCredito: [cartaoCredito],
            ativo: true
        };

        CadastrarCliente(Object);

    });
});

function CadastrarCliente(objeto) {
    if (objeto != null) {
        jQuery.ajax({
            type: "POST",
            url: 'https://localhost:44354/Operations',
            data: { oper: 2, mapKey: 'ClienteModel', JsonString: JSON.stringify(objeto) },
            cache: false,
            beforeSend: function (xhr) {

            },
            complete: function (e, xhr, result) {
                console.log(e.readyState);
                console.log(e.status);
                if (e.readyState == 4 && e.status == 200) {
                    try {
                        var resposta_controle = JSON.parse(e.responseText);
                        console.log(resposta_controle);
                        if (resposta_controle.Codigo == 0) {
                            alert("Cliente Cadastrado!");
                        } else {
                            alert(resposta_controle.Resposta);
                        }

                    } catch (error) {
                        console.log(error);
                    }
                }
            }
        });
    } else {
        alert("Preencha o formulário.");
    }
    
}

function ConsultarCliente(objeto) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 1, mapKey: 'ClienteModel', JsonString: JSON.stringify(objeto) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            console.log(e.readyState);
            console.log(e.status);
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var resposta_controle = JSON.parse(e.responseText);
                    console.log(reposta_controle);

                } catch (error) {
                    console.log(error);
                }
            }
        }
    });
}

function DesativarCliente(objeto) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 3, mapKey: 'ClienteModel', JsonString: JSON.stringify(objeto) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            console.log(e.readyState);
            console.log(e.status);
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var resposta_controle = JSON.parse(e.responseText);
                    console.log(reposta_controle);

                } catch (error) {
                    console.log(error);
                }
            }
        }
    });
}

function AtivarCliente(objeto) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 6, mapKey: 'ClienteModel', JsonString: JSON.stringify(objeto) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            console.log(e.readyState);
            console.log(e.status);
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var resposta_controle = JSON.parse(e.responseText);
                    console.log(reposta_controle);

                } catch (error) {
                    console.log(error);
                }
            }
        }
    });
}

function BuscaCEPEntrega() {
    jQuery(document).ready(function () {

        function limpa_formulario_cep() {
            //Limpa valores do formulário de cep.
            jQuery("#enderecoEntregaNumero").val("");
            jQuery("#enderecoEntregaBairro").val("");
            jQuery("#enderecoEntregaCep").val("");
            jQuery('#enderecoEntregaCidade').val("");
            jQuery('#enderecoEntregaEstado').val("");
            jQuery('#enderecoEntregaPais').val("");

        }


        //Quando o campo CEP perde o foco.
        jQuery("#").blur(function () {

            //Nova variável "cep" somente com dígitos.
            var cep = jQuery(this).val().replace(/\D/g, '');

            //Verifica se o campo possui valor informado.
            if (cep != "") {

                //Expressão reguçar para validar o CEP.
                var validacep = /^[0-9]{8}$/;

                //Valida o formato do CEP.
                if (validacep.test(cep)) {

                    //Preenche os campos com "..." enquanto consulta webservice.
                    jQuery("#enderecoEntrega").val("...");
                    jQuery("#enderecoEntregaBairro").val("...");
                    jQuery('#enderecoEntregaCidade').val("...");
                    jQuery('#enderecoEntregaEstado').val("...");
                    jQuery('#enderecoEntregaPais').val("...");

                    //Consulta o webservice viacep.com.br/
                    jQuery.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?",
                        function (dados) {

                            if (!("erro" in dados)) {

                                //Atualiza os campos com os valores da Consulta
                                jQuery("#enderecoEntrega").val(dados.localidade);
                                jQuery("#enderecoEntregaBairro").val(dados.bairro);
                                jQuery('#enderecoEntregaCidade').val(dados.localidade);
                                jQuery('#enderecoEntregaEstado').val(dados.uf);
                            }
                            else {
                                limpa_formulario_cep();
                                alert("CEP não encontrado.");
                            }
                        });
                } else {
                    //CEP inválido
                    limpa_formulario_cep();
                    alert("Formato de CEP inválido.");
                }
            } else {
                //CEP sem valor, limpa formulário
                limpa_formulario_cep();
            }

        });
    });
}