
jQuery(document).ready(function () {
    ConsultarCliente();
});


function ConsultarCliente() {
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

                    if (respostaControle.Codigo == 1)
                        alert("Erro ao buscar pedido do cliente...");

                    if (respostaControle.Dados.length > 0) {
                        jQuery("#nome_cliente").html(respostaControle.Dados[0].Nome);
                        jQuery("#qtde_credito").html("Carteira:  R$<b><u>" + parseFloat(respostaControle.Dados[0].Credito).toFixed(2) + "</u></b>");
                    }
                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}