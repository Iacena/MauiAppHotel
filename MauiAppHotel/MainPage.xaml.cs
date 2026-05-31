using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using MauiAppHotel.Models;

namespace MauiAppHotel;

public partial class MainPage : ContentPage
{
    // Requisito: Array de Objetos com Tamanho Dinâmico (List)
    public List<Quarto> ListaQuartos { get; set; } = new List<Quarto>
    {
        new Quarto { Descricao = "Suíte Standard (Simples)", ValorDiaria = 150.00 },
        new Quarto { Descricao = "Suíte Premium (Casal)", ValorDiaria = 280.00 },
        new Quarto { Descricao = "Suíte Master (Família)", ValorDiaria = 450.00 }
    };

    public MainPage()
    {
        InitializeComponent();

        // Requisito: Validação de elementos da UI
        dtpCheckIn.MinimumDate = DateTime.Now;
        dtpCheckOut.MinimumDate = DateTime.Now.AddDays(1);
        pckQuartos.ItemsSource = ListaQuartos;
    }

    private void OnDataSelecionada(object sender, DateChangedEventArgs e)
    {
        // Garante que o Check-Out seja sempre no mínimo um dia após o Check-In
        dtpCheckOut.MinimumDate = ((DateTime)e.NewDate).AddDays(1);
    }

    private async void OnAvancarClicked(object sender, EventArgs e)
    {
        if (pckQuartos.SelectedItem == null)
        {
            await DisplayAlertAsync("Aviso", "Por favor, selecione um tipo de quarto.", "OK");
            return;
        }

        try
        {
            var dadosHospedagem = new Hospedagem
            {
                QuartoSelecionado = (Quarto)pckQuartos.SelectedItem,
                QntAdultos = Convert.ToInt32(stpAdultos.Value),
                QntCriancas = Convert.ToInt32(stpCriancas.Value),
                DataCheckIn = (DateTime)dtpCheckIn.Date,
                DataCheckOut = (DateTime)dtpCheckOut.Date
            };

            await Navigation.PushAsync(new ResumoPage(dadosHospedagem));
        }
        catch (Exception ex)
        {
            // Captura as exceções lançadas pelo set das propriedades
            await DisplayAlertAsync("Erro", ex.Message, "OK");
        }
    }

    private async void OnSobreClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SobrePage());
    }
}