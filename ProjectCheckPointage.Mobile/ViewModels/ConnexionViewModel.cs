//using Android.Telephony;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectCheckPointage.Mobile.Services.Interfaces;
using ProjectCheckPointage.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectCheckPointage.Mobile.ViewModels
{

    public partial class ConnexionViewModel : ObservableObject
    {
        private readonly IAuthService _authService;

        
        [ObservableProperty] 
        private string numero;

        [ObservableProperty]
        private string pin;

        [ObservableProperty]
        private string errorMessage;

        [ObservableProperty] 
        private bool hasError;

        [ObservableProperty]
        private bool pinInvalide;

        [ObservableProperty]
        private string nomUtilisateur;

        [ObservableProperty]
        private string numeroUtilisateur;

        [ObservableProperty]
        private string derniereConnexion;

        [ObservableProperty]
        private bool afficherInfos;

        [ObservableProperty]
        private bool isFormValid;

        partial void OnNumeroChanged(string value) => VerifierFormulaire();
        partial void OnPinChanged(string value) => VerifierFormulaire();


        public ConnexionViewModel()
        {
        }

        public ConnexionViewModel(IAuthService authService)
        {
            _authService = authService;
          
        }

        private void VerifierFormulaire()
        {
            IsFormValid = !string.IsNullOrWhiteSpace(Numero)
                       && Numero.Length >= 8
                       && !string.IsNullOrWhiteSpace(Pin)
                       && Pin.Length == 5;
        }

        [RelayCommand]
        private async Task ConnexionAsync()
        {
            if (string.IsNullOrWhiteSpace(Numero) || string.IsNullOrWhiteSpace(Pin))
            {
                // if (Shell.Current != null)
                // await Shell.Current.DisplayAlert("Erreur", "Veuillez saisir le numéro et le PIN.", "OK");
                //await Application.Current.MainPage.DisplayAlert("Erreur", "Veuillez saisir le numéro et le PIN.", "OK");

                ErrorMessage = "Veuillez renseigner le numero et code pin";
                PinInvalide = true;

                return;
            }

            //if (Numero != "0504895819" || Pin != "12345") // simulation
            //{

            //    PinInvalide = true;
            //    ErrorMessage = "Veuillez saisir un numéro et Code PIN Correct";

            //    return;
            //}

            PinInvalide = false;
            ErrorMessage = string.Empty;

            //Preferences.Set("NomUtilisateur", "Edoh");
            Preferences.Set("NumeroUtilisateur", Numero);
            Preferences.Set("DerniereConnexion", DateTime.Now.ToString("HH:mm dd/MM/yy"));

            //await Application.Current.MainPage.Navigation.PushAsync(new DashboardSuperviseurPage());

            // ✅ Redirection selon rôle
            if ((Numero == "0504895819"))
            {
                await Application.Current.MainPage.Navigation.PushAsync(new DashboardSuperviseurPage());
            }
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(new DashboardPromoteurPage());
            }

        }

        public void ChargementInfosEnMemoire()
        {
            if(Preferences.ContainsKey("NumeroUtilisateur"))
            {
                NomUtilisateur = Preferences.Get("NomUtilisateur", string.Empty);
                NumeroUtilisateur = Preferences.Get("NumeroUtilisateur", string.Empty);
                DerniereConnexion = Preferences.Get("DerniereConnexion", string.Empty);
                AfficherInfos = true;
            }
            else
            {
                AfficherInfos = false;
            }
        }




   


    }
}