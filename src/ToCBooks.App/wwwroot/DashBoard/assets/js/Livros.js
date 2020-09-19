var idEntidadeTemp;
var grupoPrecificacaoTemp;


jQuery(document).ready(function () {
    buscarLivros();
    buscarParametros();

    jQuery("#btn_cad_livro").on('click', function () {
        buscarParametros();

        jQuery("#form_cad_livro")[0].reset();
        jQuery("#cad_id_livro").val('');
        jQuery("#foto").val('');
        //jQuery("#preview_imagem_livro").attr("src", 'assets/img/no-image.png"');
        jQuery("#modal_cad_livro").modal("show");
    });


    jQuery("#btn_salvar_cad_livro").on('click', function (e) {
        e.preventDefault();

        if (jQuery("#form_cad_livro").valid())
            jQuery("#form_cad_livro").submit();
    });

    jQuery(document).on('click', '.desativar', function (e) {
        e.preventDefault();

        idEntidadeTemp = jQuery(this).attr('id_livro');

        jQuery("#modal_confirmacao_delecao").modal('show');
    });

    jQuery("#form_cad_livro").on('submit', function (e) {
        e.preventDefault();
        var formData = new FormData(this);

        var Categorias = new Array();
        jQuery("#cad_categoria_livro").val().forEach(elemento => {
            var categoria = { NomeCategoria: '' };
            categoria.NomeCategoria = elemento;
            Categorias.push(categoria);
        });

        var livro = {
            Titulo: formData.get('titulo'), Preco: formData.get('preco'), Descricao: formData.get('descricao'), Foto: formData.get("foto"),
            Autor: formData.get("autor"), Ano: formData.get('ano'), Editora: formData.get('editora'), Edicao: formData.get("edicao"),
            CodigoDeBarras: formData.get('barras'), ISBN: formData.get('isbn'), Paginas: formData.get("paginas"), Altura: formData.get("altura"),
            Largura: formData.get("largura"), Profundidade: formData.get('profundidade'), Peso: formData.get("peso"),
            Categorias: Categorias, Precificacao: { Id: jQuery("#cad_grupo_precificacao").val() },Preco: '0.00'
        };

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
        var id_livro = jQuery(this).attr("id_livro");
        jQuery("#modal_cad_livro").modal('show');
        consultarLivro({ oper: '5', mapKey: 'LivrosModel', jsonString: JSON.stringify({ Id: id_livro }) })
    });

    jQuery(document).on('click', '.definir_preco', function () {
        idEntidadeTemp = jQuery(this).attr("id_livro");
        consultarLivro({ oper: '5', mapKey: 'LivrosModel', jsonString: JSON.stringify({ Id: idEntidadeTemp }) })
        jQuery("#modal_definir_precificacao").modal('show');
    });

    jQuery("#btn_consultar").on('click', function () {

        jQuery("#busca_ano").val(new Date().getFullYear());
        jQuery("#busca_edicao").val("0");
        jQuery("#busca_paginas").val("0");
        jQuery("#busca_altura").val("0.00");
        jQuery("#busca_largura").val("0.00");
        jQuery("#busca_peso").val("0.00");
        jQuery("#busca_profundidade").val("0.00");
        jQuery("#modal_busca").modal("show");
    });

    jQuery(document).on("click", '.restaurar', function () {
        jQuery("#modal_confirmacao_ativacao").modal('show');
    });

    jQuery('.preco').mask('#.##0.00', { reverse: true });

    jQuery(document).on("click", '.definir_estoque', function () {
        jQuery("#modal_estoque").modal("show");
    });

    jQuery("#habilitar_edicao_estoque").on("click", function () {
        jQuery("#qtde_estoque").removeAttr("disabled");
        jQuery("#habilitar_edicao_estoque").fadeOut(300);
        setTimeout(function () { jQuery("#btn_salvar_estoque").fadeIn("300"); }, 300);
    });

    jQuery('.selectpicker').selectpicker({
        noneSelectedText: "Selecione..."
    });

    jQuery("#btn_del_nao").on('click', function () {
        jQuery("#modal_confirmacao_delecao").modal('hide');
    });

    jQuery("#btn_del_sim").on('click', function () {
        desativarLivro({ Id: idEntidadeTemp, Justificativa: jQuery("#descricao_del").val() });
    });

    jQuery("#btn_consultar_livros").on('click', function (e) {
        e.preventDefault();

        if (jQuery("#form_consulta_livros").valid())
            jQuery("#form_consulta_livros").submit();
    });

    jQuery("#form_consulta_livros").on('submit', function (e) {
        e.preventDefault();
        var formData = new FormData(this);

        var Categorias = new Array();
        jQuery("#busca_categoria").val().forEach(elemento => {
            var categoria = { NomeCategoria: '' };
            categoria.NomeCategoria = elemento;
            Categorias.push(categoria);
        });

        var livro = {
            Titulo: formData.get('titulo'), Preco: formData.get('preco'), Descricao: formData.get('descricao'),
            Autor: formData.get("autor"), Ano: formData.get('ano'), Editora: formData.get('editora'), Edicao: formData.get("edicao"),
            CodigoDeBarras: formData.get('barras'), ISBN: formData.get('isbn'), Paginas: formData.get("paginas"), Altura: formData.get("altura"),
            Largura: formData.get("largura"), Profundidade: formData.get('profundidade'), Peso: formData.get("peso"),
            Categorias: Categorias, Preco: '0.00', StatusAtual: formData.get("status")
        };

        var objetoEnvio = { oper: '5', mapKey: 'LivrosModel', jsonString: JSON.stringify(livro) }

        consultarLivros(objetoEnvio);
    });

    jQuery(document).on('click', '.ativar', function () {
        idEntidadeTemp = jQuery(this).attr("id_livro");
        jQuery("#modal_confirmacao_ativacao").modal('show');
    });

    jQuery("#btn_atv_sim").on('click', function () {
        ativarLivro({ Id: idEntidadeTemp, Justificativa: jQuery("#atv_justificativa").val() });
    });

    jQuery("#btn_atv_nao").on('click', function () {
        jQuery("#modal_confirmacao_ativacao").modal('hide');
    });

    jQuery("#valor_livro_def").keyup(function () {

        var grupoSelecionado = jQuery("#grupo_def_preco").val();

        if (grupoSelecionado == '')
            alert("Selecione um Grupo de Precificação");
        else {
            var porcentagemGrupo;
            grupoPrecificacaoTemp.forEach(grupo => {
                if (grupo.Id == grupoSelecionado)
                    porcentagemGrupo = grupo.Valor;
            });

            var valorLivro = parseFloat(jQuery("#valor_livro_def").val());
            valorLivro += (valorLivro * (porcentagemGrupo / 100));
            jQuery("#preco_livro_definido").val(valorLivro.toFixed(2));
        }
    });

    jQuery("#btn_salvar_precificacao").on('click', function () {
        var preco_definido = jQuery("#preco_livro_definido").val();

        if (preco_definido != '') {
            var livro = {
                Id: idEntidadeTemp, Preco: parseFloat(preco_definido)
            };

            definirPreco(livro);
        } else {
            alert("Preço inválido...");
        }
    });


    jQuery(document).on("click", '.definir_estoque' , function () {
        jQuery("#habilitar_edicao_estoque").show();
        jQuery("#qtde_estoque").val('');
        jQuery("#qtde_estoque").attr('disabled', 'disabled');
        jQuery("#btn_salvar_estoque").hide();

        idEntidadeTemp = jQuery(this).attr('id_livro');

        var Livro = { Id: idEntidadeTemp };

        buscarEstoque({Livro: Livro, Qtde: 0});
    });

    jQuery("#btn_salvar_estoque").on("click", function () {
        var Qtde = jQuery("#qtde_estoque").val();
        if (Qtde > 0) {
            var Livro = { Id: idEntidadeTemp };

            atualizarEstoque({ Livro: Livro, Qtde: Qtde });
        } else {
            alert("Número Inválido Digitado...");
        }
    });
});

function atualizarEstoque(ObjetoEnvio) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: '2', mapKey: "ItemEstoque", JsonString: JSON.stringify(ObjetoEnvio) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0) {
                        jQuery("#modal_estoque").modal("hide");
                        alert("Estoque Atualizado...");
                    }
                    else
                        alert("Erro ao atualizar Estoque...");

                    jQuery("#modal_cad_livro").modal('hide');

                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}

function buscarEstoque(ObjetoEnvio) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: {
            oper: '1', mapKey: 'ItemEstoque', JsonString: JSON.stringify(ObjetoEnvio)
        },
        cache: false,
        beforeSend: function (xhr) {
        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0) {
                        if (respostaControle.Dados[0] != null)
                            jQuery("#qtde_estoque").val(respostaControle.Dados[0].Qtde);

                        jQuery("#modal_estoque").modal('show');
                    } else {
                        alert("Erro ao definir Preço...");
                    }
                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}

function definirPreco(ObjetoEnvio) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: {
            oper: '8', mapKey: 'LivrosModel', JsonString: JSON.stringify(ObjetoEnvio)
        },
        cache: false,
        beforeSend: function (xhr) {
        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0) {
                        jQuery("#modal_definir_precificacao").modal('hide');
                        buscarLivros();
                    } else {
                        alert("Erro ao definir Preço...");
                    }
                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}


function consultarLivro(objetoEnvio) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: {
            oper: '1', mapKey: 'LivrosModel', JsonString: objetoEnvio.jsonString },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Dados.length > 0) {

                        var livro = respostaControle.Dados[0];

                        jQuery("#cad_id_livro").val(livro.Id);
                        jQuery("#cad_titulo").val(livro.Titulo);
                        jQuery("#cad_autor").val(livro.Autor);
                        jQuery("#cad_editora").val(livro.Editora);
                        jQuery("#cad_barras").val(livro.CodigoDeBarras);
                        jQuery("#cad_ano").val(livro.Ano);
                        jQuery("#cad_edicao").val(livro.Edicao);
                        jQuery("#cad_paginas").val(livro.Paginas);
                        jQuery("#cad_altura").val(livro.Altura);
                        jQuery("#cad_largura").val(livro.Largura);
                        jQuery("#cad_peso").val(livro.Peso);
                        jQuery("#cad_profundidade").val(livro.Profundidade);
                        jQuery("#cad_isbn").val(livro.ISBN);
                        jQuery("#cad_categoria_livro").val(livro.Categorias);
                        jQuery("#cad_categoria_livro").selectpicker('refresh');
                        jQuery("#cad_descricao").val(livro.Descricao);

                        jQuery("#grupo_def_preco").val(livro.Precificacao.Id);
                        jQuery("#cad_grupo_precificacao").val(livro.Precificacao.id);
                        jQuery("#grupo_def_preco").selectpicker('refresh');
                        jQuery("#cad_grupo_precificacao").selectpicker('refresh');
                    }
                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}
function ativarLivro(objetoEnvio) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "6", mapKey: "LivrosModel", JsonString: JSON.stringify(objetoEnvio) },
        cache: false,
        beforeSend: function (xhr) {

        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {
                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 1)
                        alert("Erro ao Ativar Livro...");
                    else {
                        jQuery("#modal_confirmacao_ativacao").modal("hide");
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

function consultarLivros(objetoEnvio) {
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

                    if (respostaControle.Dados.length > 0) {

                        var htmlLivros = '';

                        respostaControle.Dados.forEach(Livro => {
                            htmlLivros += '<div class="media d-flex mb-5"><div class="media-image align-self-center mr-3 rounded"><a href="#">';
                            htmlLivros += '<img style="border-radius: 20px; max-height: 100px; max-width: 100px;" src="' + Livro.Foto + '" alt="customer image"></a></div>';
                            htmlLivros += '<div class="media-body align-self-center"><a href="#"><h6 class="mb-3 text-dark font-weight-medium">';
                            htmlLivros += Livro.Titulo;
                            htmlLivros += '</h6></a><p class="float-md-right"><span class="text-dark mr-2">';
                            htmlLivros += '<button type="button" class="editar_livro" id_livro="' + Livro.Id + '"><i style="font-size: 20px;" class="mdi mdi-account-edit"></i></button>';

                            if (Livro.StatusAtual == 0)
                                htmlLivros += '</span><button type="button" class="desativar" id_livro="' + Livro.Id + '"><i style="font-size: 20px;" class="mdi mdi-trash-can"></i></button></p>';
                            else
                                htmlLivros += '</span><button type="button" class="ativar" id_livro="' + Livro.Id + '"><i style="font-size: 20px;" class="mdi mdi-delete-restore"></i></button></p>';

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

                    jQuery("#modal_busca").modal("hide");
                    jQuery("#tabela_livros").html(htmlLivros);
                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}

function desativarLivro(objetoEnvio) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: { oper: "3", mapKey: "LivrosModel", JsonString: JSON.stringify(objetoEnvio) },
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
                        jQuery("#modal_confirmacao_delecao").modal("hide");
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
                        var htmlSelect = '<option value=""></option>';

                        respostaControle.Dados.forEach(grupo => {
                            htmlSelect += '<option value="' + grupo.Id + '">' + grupo.Nome + '</option>';
                        });

                        grupoPrecificacaoTemp = respostaControle.Dados;

                        jQuery("#grupo_def_preco").html(htmlSelect);
                        jQuery("#cad_grupo_precificacao").html(htmlSelect);
                        jQuery("#cad_grupo_precificacao").selectpicker({
                            noneSelectedText: "Selecione..."
                        });

                        jQuery("#grupo_def_preco").selectpicker({
                            noneSelectedText: "Selecione..."
                        });
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
                                htmlLivros += '<button type="button" id_livro="' + Livro.Id + '" class="definir_estoque"><i style="font-size: 20px;" class="mdi mdi-settings" ></i ></button > |';
                                htmlLivros += '<button type="button" class="editar_livro" id_livro="' + Livro.Id + '"><i style="font-size: 20px;" class="mdi mdi-account-edit"></i></button> | ';
                                htmlLivros += '<button type="button" id_livro="' + Livro.Id + '" class="definir_preco"><i style="font-size: 20px;" class="mdi mdi-square-inc-cash" ></i ></button > |';
                                htmlLivros += '</span><button type="button" class="desativar" id_livro="' + Livro.Id + '"><i style="font-size: 20px;" class="mdi mdi-trash-can"></i></button></p>';
                                htmlLivros += '<p class="d-none d-md-block">';
                                htmlLivros += Livro.Descricao;
                                htmlLivros += '</p><p class="mb-0" >';
                                htmlLivros += 'R$' + Livro.Preco;
                                htmlLivros += '</p><br />';
                                htmlLivros += '<span class="mb-2 mr-2 badge badge-success">Ativo</span>';
                                htmlLivros += '</div></div>';
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

                        jQuery("#tabela_livros").html(htmlLivros);
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
                        buscarLivros();
                    }
                    else
                        alert(respostaControle.Resposta);


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