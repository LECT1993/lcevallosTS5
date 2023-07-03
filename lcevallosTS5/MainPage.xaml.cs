using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace lcevallosTS5
{
    public partial class MainPage : ContentPage
    {
        private string Url = "http://172.20.3.52/rutasegura/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<Vehiculo> post;
        public MainPage()
        {
            InitializeComponent();
        }

             
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var contenido = await cliente.GetStringAsync(Url);
            List<Vehiculo> listaPost = JsonConvert.DeserializeObject<List<Vehiculo>>(contenido);
            post = new ObservableCollection<Vehiculo>(listaPost);
            listaVehiculos.ItemsSource = post;
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<Vehiculo> listaPost = JsonConvert.DeserializeObject<List<Vehiculo>>(contenido);
            post = new ObservableCollection<Vehiculo>(listaPost);
            listaVehiculos.ItemsSource = post;
        }
    }
}
