
var idTempExclusao;

jQuery(document).ready(function () {

    buscarParametros();


    jQuery("#btn_cad_grupo").on('click', function () {
        jQuery("#id_grupo").val('');
        jQuery("#nome").val('');
        jQuery("#valor").val('');
        jQuery("#modal_cad_grupo").modal("show");
    });

    jQuery("#btn_salvar_cad_grupo").on('click', function (e) {
        e.preventDefault();

        if (jQuery("#form_cad_grupo").valid())
            jQuery("#form_cad_grupo").submit();        
    });

    jQuery("#form_cad_grupo").on('submit', function (e) {
        e.preventDefault();

        var formData = new FormData(this);
        var guid = formData.get('Id');
        var objetoEnvio;
        if (guid != null && guid != '')
            objetoEnvio = { oper: '2', mapKey: 'Parametro', jsonString: JSON.stringify({ Id: formData.get('Id'), Nome: formData.get("nome"), Valor: formData.get('valor').replace("%", ''), Tipo: '0' }) }
        else
            objetoEnvio = { oper: '2', mapKey: 'Parametro', jsonString: JSON.stringify({ Nome: formData.get("nome"), Valor: formData.get('valor').replace("%", ''), Tipo: '0' }) }

        cadastrarGrupo(objetoEnvio);
    });

    jQuery(document).on("click", '.editar', function (e) {
        e.preventDefault();

        var id_grupo = jQuery(this).attr('id_grupo');
        buscarParametro(id_grupo);
    });

    jQuery(document).on('click', '.editar', function () {
        var id_grupo = jQuery(this).attr('id_grupo');

        jQuery("#modal_cad_grupo").modal('show');
    });

    jQuery(document).on('click', '.excluir', function () {
        idTempExclusao = jQuery(this).attr('id_grupo');

        jQuery("#modal_confirmacao_delecao").modal('show');
    });

    jQuery("#btn_sim").on('click', function () {
        excluirParametro(idTempExclusao);
    });


    jQuery("#btn_nao").on('click', function () {
        jQuery("#modal_confirmacao_delecao").modal('hide');
    });

    jQuery('.preco').mask('00.00%');
});


function excluirParametro(id_grupo) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "4", mapKey: "Parametro", JsonString: JSON.stringify({ Id: id_grupo}) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0) {
                        buscarParametros();
                        jQuery("#modal_confirmacao_delecao").modal('hide');
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

function buscarParametro(id_grupo) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "1", mapKey: "Parametro", JsonString: JSON.stringify({ Id: id_grupo}) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0) {
                        jQuery("#id_grupo").val(respostaControle.Dados[0].Id);
                        jQuery("#nome").val(respostaControle.Dados[0].Nome);
                        jQuery("#valor").val(respostaControle.Dados[0].Valor);
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

function buscarParametros() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "1", mapKey: "Parametro", JsonString: JSON.stringify({}) },
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

                        respostaControle.Dados.forEach(grupo => {
                            htmlTabela += '<tr><td class="text-dark">' + grupo.Nome + '</td>';
                            htmlTabela += '<td class="text-center">' + grupo.Valor + '%</td>';
                            htmlTabela += '<td class="text-right">';
                            htmlTabela += '<button type="button" class="editar" id_grupo="' + grupo.Id + '"><i style="font-size: 20px;" class="mdi mdi-account-edit"></i></button> | ';
                            htmlTabela += '<button type="button" class="excluir" id_grupo="' + grupo.Id + '"><i style="font-size: 20px;" class="mdi mdi-trash-can"></i></button>';
                            htmlTabela += '</td></tr>';
                        });

                        if (htmlTabela == '') {
                            htmlTabela += '<tr><td class="text-dark">Nenhum Registro Encontrado</td>';
                            htmlTabela += '<td class="text-center"></td>';
                            htmlTabela += '<td class="text-right">';
                            htmlTabela += '</td></tr>';
                        }

                        jQuery("#tbody_tabela_grupo").html(htmlTabela);
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}

function cadastrarGrupo(objetoEnvio) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: objetoEnvio.oper, mapKey: objetoEnvio.mapKey, JsonString: objetoEnvio.jsonString },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0) {
                        buscarParametros();
                    }
                    else
                        alert("Erro ao cadastrar Grupo");

                    jQuery("#modal_cad_grupo").modal('hide');

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}