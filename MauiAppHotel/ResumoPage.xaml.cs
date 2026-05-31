using System;
using Microsoft.Maui.Controls;
using MauiAppHotel.Models;

namespace MauiAppHotel;

public partial class ResumoPage : ContentPage
{
    // O construtor recebe o objeto do tipo Hospedagem
    public ResumoPage(Hospedagem hospedagem)
    {
        InitializeComponent();

        // Isso conecta o objeto recebido com a interface visual XAML
        BindingContext = hospedagem;
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        // Remove a página atual da pilha de navegação, voltando para a tela anterior
        await Navigation.PopAsync();
    }
}