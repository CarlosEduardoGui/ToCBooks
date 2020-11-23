var graficoBarra;

jQuery(document).ready(function () {

    BuscarPedidosPorPeriodo({Inicio: '2020-09-01', Fim: '2020-11-22'});


    jQuery("#filtro_data_fim").on('change', function (e) {
        e.preventDefault();

        var DataInicio = jQuery("#filtro_data_inicio").val();
        var DataFim = jQuery(this).val();

        if (DataInicio == '' || DataInicio == null || typeof (DataInicio) == 'undefined') {
            alert('Digite uma Data de Inicio Válida...');
            return;
        }

        if (DataFim < DataInicio) {
            alert("A data Inicial não pode ser menor que a Final...");
            return;
        }

        var Periodo = { Inicio: DataInicio, Fim: DataFim };


        BuscarPedidosPorPeriodo(Periodo, true);
    });
});


function BuscarPedidosPorPeriodo(Periodo, Destroy = false) {
    jQuery.ajax({
        type: "POST",
        url: 'https://localhost:44354/Operations',
        data: {
            oper: '25', mapKey: 'Periodo', JsonString: JSON.stringify(Periodo)
        },
        cache: false,
        beforeSend: function (xhr) {
        },
        complete: function (e, xhr, result) {
            if (e.readyState == 4 && e.status == 200) {

                try {
                    var respostaControle = JSON.parse(e.responseText);

                    if (respostaControle.Codigo == 0) {

                        // Separar as Datas
                        var Datas = new Array();
                        respostaControle.Dados.forEach(Pedido => {
                            Datas.push(Pedido.DataCadastro.split('T')[0]);
                        });

                        Datas = Datas.filter(onlyUnique);

                        // Separar Todas Categorias
                        var Categorias = new Array();

                        respostaControle.Dados.forEach(Pedido => {
                            Pedido.ItensPedido.forEach(Item => {
                                Item.Livro.Categorias.forEach(Categoria => {
                                    Categorias.push(Categoria.NomeCategoria);
                                });
                            });
                        });

                        Categorias = Categorias.filter(onlyUnique);

                        // Quantidade Por Categoria e por Data
                        var QtdeLivrosPorCategoria = new Array();
                        Datas.forEach(Data => {
                            var ObjetoComposto = { Data: Data, Categorias: new Array(), QtdeCategorias: new Array() };

                            Categorias.forEach(Categoria => {
                                var QtdeLivros = 0;
                                respostaControle.Dados.forEach(Pedido => {
                                    if (Data == Pedido.DataCadastro.split('T')[0]) {
                                        Pedido.ItensPedido.forEach(Item => {
                                            var FlagCategoriaEncontrada = false;
                                            Item.Livro.Categorias.forEach(CategoriaItem => {
                                                if (Categoria == CategoriaItem.NomeCategoria)
                                                    FlagCategoriaEncontrada = true;
                                            });

                                            if (FlagCategoriaEncontrada)
                                                QtdeLivros += Item.Qtde;
                                        });
                                    }
                                });


                                ObjetoComposto.QtdeCategorias.push(QtdeLivros);
                                ObjetoComposto.Categorias.push(Categoria);
                            });

                            QtdeLivrosPorCategoria.push(ObjetoComposto);
                        });

                        var DataArray = new Array();
                        Categorias.forEach(Categoria => {
                            var QtdeArray = new Array();
                            QtdeLivrosPorCategoria.forEach(Item => {
                                for (var i = 0; i < Item.Categorias.length; i++) {
                                    if (Categoria == Item.Categorias[i]) {
                                        QtdeArray.push(Item.QtdeCategorias[i]);
                                        break;
                                    }
                                }
                            });

                            DataArray.push(QtdeArray);
                        });

                        var RandomColors = new Array();
                        for (var i = 0; i < 7; i++) 
                            RandomColors.push(Math.floor(Math.random() * 16777215).toString(16));

                        var Datasets = new Array();
                        for (var i = 0; i < Categorias.length; i++) {
                            
                            var Dataset = {
                                label: Categorias[i],
                                backgroundColor: "#" + RandomColors[i],
                                borderColor: "rgba(76, 132, 255,0)",
                                data: DataArray[i],
                                pointBackgroundColor: "rgba(76, 132, 255,0)",
                                pointHoverBackgroundColor: "rgba(76, 132, 255,1)",
                                pointHoverRadius: 3,
                                pointHitRadius: 30
                            };

                            Datasets.push(Dataset);
                        }

                        for (var i = 0; i < Datas.length; i++) 
                            Datas[i] = FormatarData(Datas[i]);

                        MontarGraficoBarra(Datas, Datasets, Destroy);

                    } else {
                        alert("Erro ao buscar Pedidos...");
                    }
                } catch (error) {
                    console.log(error);
                    alert("Erro na Comunicação com o Servidor...");
                }
            }
        }
    });
}



function MontarGraficoBarra(Labels, Datasets, Destroy = false) {
    var acquisition3 = document.getElementById("bar3");
    if (acquisition3 !== null) {

        if (Destroy)
            graficoBarra.destroy();

        graficoBarra = new Chart(acquisition3, {
            type: "bar",
            data: {
                labels: Labels,
                datasets: Datasets
            },

            // Configuration options go here
            options: {
                responsive: true,
                maintainAspectRatio: false,
                legend: {
                    display: false
                },
                scales: {
                    xAxes: [
                        {
                            gridLines: {
                                display: false
                            }
                        }
                    ],
                    yAxes: [
                        {
                            gridLines: {
                                display: true
                            },
                            ticks: {
                                beginAtZero: true,
                                stepSize: 10,
                                fontColor: "#8a909d",
                                fontFamily: "Roboto, sans-serif",
                                max: 100
                            }
                        }
                    ]
                },
                tooltips: {}
            }
        });
        document.getElementById("customLegend").innerHTML = graficoBarra.generateLegend();
    }
}

function onlyUnique(value, index, self) {
    return self.indexOf(value) === index;
}

function FormatarData(Data) {
    var DataQuebrada = Data.split("-");
    return DataQuebrada[2] + '/' + DataQuebrada[1] + '/' + DataQuebrada[0];
}