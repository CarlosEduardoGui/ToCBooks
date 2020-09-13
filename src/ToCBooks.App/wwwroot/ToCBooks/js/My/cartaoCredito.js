

function ListarCartoes(objetoEnvio) {
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