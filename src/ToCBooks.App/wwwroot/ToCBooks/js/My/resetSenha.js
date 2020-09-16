﻿jQuery(document).ready(function () {

    trazerDados();

    jQuery("#btn_salvar_cartaoCredito").on('click', function (e) {
        e.preventDefault();

        if (jQuery("#form_login").valid())
            jQuery("#form_login").submit();
        else
            alert("Preencha o formulário corretamente...");
    });

    jQuery("#btn_alterar").on("click", function (e) {
        e.preventDefault();

        if (validarSenha(jQuery("#senha1").val(), jQuery("#senha2").val())) {
            var Object = {
                email: jQuery('#email_banco').val(),
                senha: jQuery('#senha1').val(),
                clienteId: jQuery('#id_cliente').val(),
                tipoUsuario: jQuery('#eTipoUsuario').val()
            };

            AtualizarSenha(Object);

        } else {
            alert("Senhas divergente");
        }

    });
});


function AtualizarSenha(objeto) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Login',
        data: { oper: 2, mapKey: 'LoginModel', JsonString: JSON.stringify(objeto) },
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
                        alert("Senha alterada");
                        window.location = "perfil.html";
                    } else {
                        alert("Usuário não Cadastrado");
                    }

                } catch (error) {
                    console.log(error);
                }
            }
        }
    });
}


function validarSenha(senha1, senha2) {
    var result = false;

    if (senha1 == senha2) {
        result = true;
    }

    return result;
}

function trazerDados() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "1", mapKey: "LoginModel", JsonString: JSON.stringify({}) },
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
                        if (respostaControle.Dados.length > 0) {
                            respostaControle.Dados.forEach(login => {
                                jQuery("#id_cliente").val(login.ClienteId);
                                jQuery("#id_login").val(login.Id);
                                jQuery("#email_banco").val(login.Email);
                                jQuery("#eTipoUsuario").val(login.TipoUsuario);
                            });
                        }
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}