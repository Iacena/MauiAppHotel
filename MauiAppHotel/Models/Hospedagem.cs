using System;

namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; }
        public int QntAdultos { get; set; }
        public int QntCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        public int Estadia
        {
            get { return DataCheckOut.Subtract(DataCheckIn).Days; }
        }

        public double ValorTotal
        {
            get
            {
                if (QuartoSelecionado == null) return 0;
                return Estadia * QuartoSelecionado.ValorDiaria;
            }
        }
    }

    public class Quarto
    {
        public string Descricao { get; set; }
        public double ValorDiaria { get; set; }
    }
}