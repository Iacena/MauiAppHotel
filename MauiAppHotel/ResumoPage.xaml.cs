using Microsoft.Maui.Controls;
using MauiAppHotel.Models;
using System;

namespace MauiAppHotel;

public partial class ResumoPage : ContentPage
{
    public ResumoPage(Hospedagem hospedagem)
    {
        InitializeComponent();
        this.BindingContext = hospedagem;
    }

    private async void OnConcluirClicked(object sender, EventArgs e)
    {
        await DisplayAlertAsync("Sucesso!", "Sua reserva foi confirmada.", "OK");
        await Navigation.PopToRootAsync();
    }
}