using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui;
using ProjectCheckPointage.Mobile.ViewModels;

namespace ProjectCheckPointage.Mobile.Views;

public partial class ConnexionPage : ContentPage
{
    private bool _isPasswordVisible = false;
    private ConnexionViewModel viewModel;



    public ConnexionPage()
    {
        InitializeComponent();
        BindingContext = viewModel = new ConnexionViewModel();


    }



    private void OnTogglePasswordVisibility(object sender, EventArgs e)
    {
        _isPasswordVisible = !_isPasswordVisible;
        if (PinEntry != null)
            PinEntry.IsPassword = !_isPasswordVisible;

        var eyeButton = sender as ImageButton;
        if (eyeButton != null)
        {
            eyeButton.Source = _isPasswordVisible ? "eye_off.png" : "eye.png";
        }
    }






}
