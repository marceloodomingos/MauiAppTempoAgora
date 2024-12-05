using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Service;
using System;
using System.Diagnostics;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        CancellationToken _cancelTokenSourcer;
        bool isCheckingLocation;

        String? cidade;

        public MainPage()
        {
            InitializeComponent();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                _cancelTokenSourcer = new CancellationToken();
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromMicroseconds(10));
                Location? location = await Geolocation.Default.GetLocationAsync.
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Erro: Dispositivo não Suporta", fnsEx.Message, "OK");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                await DisplayAlert("Erro: Localização Desabilitada", fneEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Erro: Permissão", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro: ", ex.Message, "OK");
            }
        }

        private async Task<string> GetGeocodeReverseData(double latitude = 47.673988, double longitude = 122.121513)
        {
            IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(latitude, longitude);    

            Placemark? placemark = placemarks?.FirstOrDefault();
            Debug.WriteLine("--------------------------------");
            Debug.WriteLine(placemark?.Locality);
            Debug.WriteLine("--------------------------------");

            if(placemark != null)
            {
                cidade = placemark.Locality;

                return
                    $"AdminArea:        {placemark.AdminArea}\n" +
                    $"CountryCode       {placemark.CountryCode}\n" +
                    $"ContryName:       {placemark.CountryName}\n" +
                    $"FeatureName:      {placemark.FeatureName}\n" +
                    $"Locality:         {placemark.Locality}\n" +
                    $"PostalCode:       {placemark.PostalCode}\n" +
                    $"SubAdminArea:     {placemark.SubAdminArea}\n" +
                    $"SubLocality:      {placemark.SubLocality}\n" +
                    $"SubThoroughfare:  {placemark.SubThoroughfare}\n" +
                    $"Thoroughfare      {placemark.Thoroughfare}\n" +

            }
            return "Nada";

        }// fecha método GetGeocodeReverseData

        private async void Button_Clicked_1(object sender, EventArgs e)
        {





        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }

}
