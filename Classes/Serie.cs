using System;

namespace Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        public string Titulo { get; private set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        public bool Excluido { get; private set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {
            var retorno = "";
            retorno += $"Gênero: {Genero + Environment.NewLine}";
            retorno += $"Título: {Titulo + Environment.NewLine}";
            retorno += $"Descrição: {Descricao + Environment.NewLine}";
            retorno += $"Ano de Lançamento: {Ano}" + Environment.NewLine;
             retorno += $"Excluído: {Excluido}";
            return retorno;
        }

        public void Excluir()
        {
            Excluido = true;
        }
    }
}