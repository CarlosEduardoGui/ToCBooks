jQuery(document).ready(function () {

    jQuery("#btn_login").on('click', function (e) {
        e.preventDefault();

        if (jQuery("#form_login").valid())
            jQuery("#form_login").submit();
        else
            alert("Preencha o formulário corretamente...");
    });

    jQuery("#form_login").on("submit", function (e) {
        e.preventDefault();

        var formData = new FormData(this);
        var Object;

        var Object = {
            email: formData.get('email'),
            senha: formData.get('senha')
        };

        FazerLogin(Object);

    });
});


function FazerLogin(objeto) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Login',
        data: { oper: 7, mapKey: 'LoginModel', JsonString: JSON.stringify(objeto) },
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