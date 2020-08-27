

jQuery(document).ready(function () {


    buscarLivros();
    jQuery("#btn_cad_livro").on('click', function () {
        jQuery("#modal_cad_livro").modal("show");
    });


    jQuery("#btn_salvar_cad_livro").on('click', function (e) {
        e.preventDefault();

        if (jQuery("#form_cad_livro").valid())
            jQuery("#form_cad_livro").submit();
    });

    jQuery(document).on('click', '.desativar', function (e) {
        e.preventDefault();

        jQuery("#modal_confirmacao_delecao").modal('show');
        //var id_livro = jQuery(this).attr('id_livro');
        //desativarLivro(id_livro);
    });

    jQuery("#form_cad_livro").on('submit', function (e) {
        e.preventDefault();
        var formData = new FormData(this);
        var livro = { Titulo: formData.get('titulo'), Preco: formData.get('preco'), Descricao: formData.get('descricao'), Foto: formData.get("foto")  };

        var objetoEnvio = { oper: '2', mapKey: 'LivrosModel', jsonString: JSON.stringify(livro) }
        cadastrarLivro(objetoEnvio);
    });

    jQuery("#btn_add_imagem").on('click', function (e) {
        e.preventDefault();

        jQuery("#input_file_img_livro").trigger('click');
    });

    jQuery("#input_file_img_livro").on('change', function () {
        encodeImageFileAsURL('input_file_img_livro', 'foto', 'preview_imagem_livro');
    });

    jQuery(document).on('click', '.editar_livro', function () {
        jQuery("#modal_cad_livro").modal('show');
    });

    jQuery(document).on('click', '.definir_preco', function () {
        jQuery("#modal_definir_precificacao").modal('show');
    });

    jQuery("#btn_consultar").on('click', function () {

        jQuery("#modal_busca").modal("show");
    });

    jQuery(document).on("click", '.restaurar', function () {
        jQuery("#modal_confirmacao_ativacao").modal('show');
    });

    jQuery('.preco').mask('#.##0.00', { reverse: true });

    jQuery('select').selectpicker({
        noneSelectedText: "Selecione..."
    });
});

function desativarLivro(id_livro) { 
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "3", mapKey: "LivrosModel", JsonString: JSON.stringify({Id: id_livro}) },
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
                        alert("Livro desativado...");
                        buscarLivros();
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}

function buscarLivros() {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "1", mapKey: "LivrosModel", JsonString: JSON.stringify({}) },
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
                        var htmlLivros = '';

                        if (respostaControle.Dados.length > 0) {
                            respostaControle.Dados.forEach(Livro => {
                                htmlLivros += '<div class="media d-flex mb-5"><div class="media-image align-self-center mr-3 rounded"><a href="#">';
                                htmlLivros += '<img style="border-radius: 20px; max-height: 100px; max-width: 100px;" src="' + Livro.Foto + '" alt="customer image"></a></div>';
                                htmlLivros += '<div class="media-body align-self-center"><a href="#"><h6 class="mb-3 text-dark font-weight-medium">';
                                htmlLivros += Livro.Titulo;
                                htmlLivros += '</h6></a><p class="float-md-right"><span class="text-dark mr-2">';
                                htmlLivros += '<button type="button" class="editar_livro" id_livro="' + Livro.Id + '"><i style="font-size: 20px;" class="mdi mdi-account-edit"></i></button>';
                                htmlLivros += '</span><button type="button" class="desativar" id_livro="' + Livro.Id + '"><i style="font-size: 20px;" class="mdi mdi-trash-can"></i></button></p>';
                                htmlLivros += '<p class="d-none d-md-block">';
                                htmlLivros += Livro.Descricao;
                                htmlLivros += '</p><p class="mb-0" >';
                                htmlLivros += 'R$' + Livro.Preco;
                                htmlLivros += '</p></div></div>';
                            });
                        } else {
                            htmlLivros += '<div class="media d-flex mb-5"><div class="media-image align-self-center mr-3 rounded"><a href="#">';
                            htmlLivros += '</a></div>';
                            htmlLivros += '<div class="media-body align-self-center"><a href="#"><h6 class="mb-3 text-dark font-weight-medium">';
                            htmlLivros += "Nenhum Livro Cadastrado.";
                            htmlLivros += '</h6></a><p class="float-md-right"><span class="text-dark mr-2">';
                            htmlLivros += '</span></p>';
                            htmlLivros += '<p class="d-none d-md-block">';
                            htmlLivros += '</p><p class="mb-0" >';
                            htmlLivros += '</p></div></div>';
                        }

                        //jQuery("#tabela_livros").html(htmlLivros);
                    }

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}


function cadastrarLivro(objetoEnvio) {
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
                        alert("Livro Cadastrado");
                        buscarLivros();
                    }
                    else
                        alert("Erro ao cadastrar Livro");

                    jQuery("#modal_cad_livro").modal('hide');

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}


function encodeImageFileAsURL(id_element, id_target_element, id_preview) {
    var filesSelected = document.getElementById(id_element).files;
    if (filesSelected.length > 0) {
        var fileToLoad = filesSelected[0];

        var fileReader = new FileReader();

        fileReader.onload = function (fileLoadedEvent) {
            var base64 = fileLoadedEvent.target.result;

            jQuery("#" + id_target_element).val(base64);
            jQuery("#" + id_preview).attr('src', base64);
        }
        fileReader.readAsDataURL(fileToLoad);
    }
}