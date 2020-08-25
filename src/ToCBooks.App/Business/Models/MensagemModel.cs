﻿using System.Collections.Generic;

namespace ToCBooks.App.Business.Models
{
    public class MensagemModel
    {
        public MensagemModel()
        {
            Dados = new List<EntidadeDominio>();
        }

        public int Codigo { get; set; }
        public string Resposta { get; set; }
        public List<EntidadeDominio> Dados { get; set; }
    }
}
