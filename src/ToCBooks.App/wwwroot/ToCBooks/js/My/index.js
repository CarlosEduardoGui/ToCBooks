jQuery(document).ready(function () {
    BuscarUltimosProdutosCadastrados();

    jQuery("#btn_login").on("click", function (e) {
        e.preventDefault();

        var Object = {
            email: jQuery('#email').val(),
            senha: jQuery('#senha').val()
        };

        FazerLogin(Object);

    });
});


function BuscarUltimosProdutosCadastrados() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: 1, mapKey: 'LivrosModel', JsonString: JSON.stringify() },
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