using DCProyectoPersAPP.Models;
using Newtonsoft.Json;

namespace DCProyectoPersAPP
{
    public partial class DCMainPage : ContentPage
    {
         public DCMainPage()
        {
            InitializeComponent();
        }

        private void DC_BotonAPI(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7159/api/");

            var response = client.GetAsync("dcBebida").Result;

            if (response.IsSuccessStatusCode)
            {
                var dcBebidas = response.Content.ReadAsStringAsync().Result;
                var dcBebidasList = JsonConvert.DeserializeObject<List<DCBebida>>(dcBebidas);
                DC_Lista.ItemsSource = dcBebidasList;
            }
        }
    }

}
