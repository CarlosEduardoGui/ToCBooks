function SalvarCliente() {
    jQuery("#btn_salvar").on("click", function (e) {
        e.preventDefault();

        var telefone = {
            ddd: jQuery('#ddd').val(),
            numero: jQuery('#telefone').val()
        };

        var cidadeCobranca = {
            nome: jQuery('#enderecoCobrancaCidade').val(),
        };

        var estadoCobranca = {
            nome: jQuery('#enderecoCobrancaEstado').val(),
            cidade: cidadeCobranca
        };

        var paisCobranca = {
            nome: jQuery('#enderecoCobrancaPais').val(),
            estado: estadoCobranca
        };

        var cidadeEntrega = {
            nome: jQuery('#enderecoEntregaCidade').val(),
        };

        var estadoEntrega = {
            nome: jQuery('#enderecoEntregaEstado').val(),
            cidade: cidadeEntrega
        };

        var paisEntrega = {
            nome: jQuery('#enderecoEntregaPais').val(),
            estado: estadoEntrega
        };

        var enderecoCobranca = {
            enderecocobranca: jQuery('#enderecoCobranca').val(),
            tipologradouro: jQuery('#enderecoCobrancaEtipologradouro').val(),
            tiporesidencia: jQuery('#enderecoCobrancaEtiporesidencia').val(),
            cep: jQuery('#enderecoCobrancaCep').val(),
            bairro: jQuery('#enderecoCobrancaBairro').val(),
            numero: jQuery('#enderecoCobrancaNumero').val(),
            pais: paisCobranca
        };

        var enderecoEntrega = {
            numero: jQuery('#enderecoEntregaNumero').val(),
            nome: jQuery('#enderecoEntrega').val(),
            bairro: jQuery('#enderecoEntregaBairro').val(),
            cep: jQuery('#enderecoEntregaCep').val(),
            pais: paisEntrega,
            tipologradouro: jQuery('#enderecoEntregaEtipologradouro').val(),
            tipoResidencia: jQuery('#enderecoEntregaEtiporesidencia').val()
        };

        var Object = {
            nome: jQuery('#nome').val(),
            cpf: jQuery('#cpf').val(),
            email: jQuery('#email').val(),
            senha: jQuery('#senha').val(),
            telefone: telefone,
            genero: jQuery('#genero').val(),
            datanascimento: jQuery('#datanascimento').val(),
            enderecoCobranca: enderecoCobranca,
            enderecoEntrega: enderecoEntrega,
            tipoUsuario: 2,
            tipoGenero: jQuery('#genero').val()
        };

        console.log(Object);

        jQuery.ajax({
            type: "POST",
            url: 'https://localhost:44354/Operations',
            data: { oper: 2, mapKey: 'ClienteModel', JsonString: JSON.stringify(Object) },
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
                        iziToast.error({
                            message: "<strong>Erro na Autenticação...</strong>"
                        });
                    }
                }
            }
        });
    });
}