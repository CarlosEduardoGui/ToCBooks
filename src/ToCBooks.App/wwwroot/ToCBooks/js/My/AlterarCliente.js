var idEntidadeTemp;

jQuery(document).ready(function () {
    buscarCliente();

    jQuery("#btn_salvar").on('click', function (e) {
        e.preventDefault();

        if (jQuery("#form_cliente").valid())
            jQuery("#form_cliente").submit();
        else
            alert("Preencha o formulário corretamente...");
    });


    jQuery("#form_cliente").on("submit", function (e) {
        e.preventDefault();
        var formData = new FormData(this);

        console.log(formData.get('id_cliente'));

        var telefone = {
            Id: jQuery("#id_telefone").val(),
            ddd: formData.get('ddd'),
            numero: formData.get('telefone'),
            tipo: formData.get('eTipoTelefone')
        };

        var login = {
            Id: jQuery("#id_login").val(),
            Senha: jQuery("#senha").val(),
            ClienteID: jQuery("#id_cliente").val(),
            email: formData.get('email')
        }

        var cliente = {
            Id: jQuery("#id_cliente").val(),
            Nome: formData.get('nome'),
            Login: login,
            CPF: formData.get('CPF'),
            tipoGenero: formData.get('eTipoGenero'),
            dataNascimento: formData.get('dataNascimento'),
            telefone: telefone,
            tipoUsuario: 2
        };


        atualizarCliente(cliente);
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


function buscarCliente() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 26, mapKey: "ClienteModel", JsonString: JSON.stringify({}) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0) {
                        var Cliente = respostaControle.Dados[0];

                        jQuery("#id_cliente").val(Cliente.Id);
                        jQuery("#email").val(Cliente.Login.Email);
                        jQuery("#id_login").val(Cliente.Login.Id);
                        jQuery("#senha").val(Cliente.Login.Senha);
                        jQuery("#nome").val(Cliente.Nome);
                        jQuery("#CPF").val(Cliente.CPF);
                        jQuery("#eTipoGenero").val(Cliente.TipoGenero);
                        jQuery("#dataNascimento").val(Cliente.DataNascimento.split("T")[0]);
                        jQuery("#ddd").val(Cliente.Telefone.DDD);
                        jQuery("#telefone").val(Cliente.Telefone.Numero);
                        jQuery("#eTipoTelefone").val(Cliente.Telefone.Tipo);
                        jQuery("#id_telefone").val(Cliente.Telefone.Id);

                        jQuery("select").niceSelect("update");

                    }
                    else
                        alert(respostaControle.Resposta);

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}


function atualizarCliente(objeto) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 2, mapKey: "ClienteModel", JsonString: JSON.stringify(objeto) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var resposta_controle = JSON.parse(e.responseText);

                    if (resposta_controle.Codigo == 0) {
                        alert("Dados Atualizados");
                    } else {
                        alert(resposta_controle.Resposta);
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}
