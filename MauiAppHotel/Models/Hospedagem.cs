using System;

namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; }

        // Atributo privado e Propriedade pública com validação (Encapsulamento)
        private int _qntAdultos;
        public int QntAdultos
        {
            get { return _qntAdultos; }
            set
            {
                if (value >= 1)
                    _qntAdultos = value;
                else
                    throw new ArgumentException("A quantidade de adultos não pode ser menor que 1.");
            }
        }

        private int _qntCriancas;
        public int QntCriancas
        {
            get { return _qntCriancas; }
            set
            {
                if (value >= 0)
                    _qntCriancas = value;
                else
                    throw new ArgumentException("A quantidade de crianças não pode ser negativa.");
            }
        }

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