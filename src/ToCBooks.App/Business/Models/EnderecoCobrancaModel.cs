﻿using ToCBooks.App.Models.Enum;

namespace ToCBooks.App.Business.Models
{
    public class EnderecoCobrancaModel
    {
        public int Numero { get; set; }

        public string Nome { get; set; }

        public string Bairro { get; set; }

        public int CEP { get; set; }

        public PaisModel Pais { get; set; }

        public ETipoLogradouro TipoLogradouro { get; set; }

        public ETipoResidencia TipoResidencia { get; set; }
    }
}