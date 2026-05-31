using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using MauiAppHotel.Models;

namespace MauiAppHotel;

public partial class MainPage : ContentPage
{
    public List<Quarto> ListaQuartos { get; set; } = new List<Quarto>
    {
        new Quarto { Descricao = "Suíte Standard (Simples)", ValorDiaria = 150.00 },
        new Quarto { Descricao = "Suíte Premium (Casal)", ValorDiaria = 280.00 },
        new Quarto { Descricao = "Suíte Master (Família)", ValorDiaria = 450.00 }
    };

    public MainPage()
    {
        InitializeComponent();

        dtpCheckIn.MinimumDate = DateTime.Now;
        dtpCheckOut.MinimumDate = DateTime.Now.AddDays(1);
        pckQuartos.ItemsSource = ListaQuartos;
    }

    private void OnDataSelecionada(object sender, DateChangedEventArgs e)
    {
        dtpCheckOut.MinimumDate = e.NewDate.Value.AddDays(1);
    }

    private async void OnAvancarClicked(object sender, EventArgs e)
    {
        if (pckQuartos.SelectedItem == null)
        {
            await DisplayAlertAsync("Aviso", "Por favor, selecione um tipo de quarto.", "OK");
            return;
        }

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

    private async void OnSobreClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SobrePage());
    }
}