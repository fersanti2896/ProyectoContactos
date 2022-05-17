namespace ContactosWebApp.Helpers {
    public class ContactoAPI {
        /* Accede a la información de la Web API */
        public HttpClient Initial() { 
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7129/");

            return client;
        }
    }
}
