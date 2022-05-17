using ContactosWebApp.Helpers;
using ContactosWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContactosWebApp.Controllers {
    public class ContactoController : Controller {
        ContactoAPI api = new ContactoAPI();

        public async Task<IActionResult> Index() {
            List<ContactoData> contacts = new List<ContactoData>();

            HttpClient client       = api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/contactos");

            if (res.IsSuccessStatusCode) {
                var results = res.Content.ReadAsStringAsync().Result;
                contacts    = JsonConvert.DeserializeObject<List<ContactoData>>(results);
            }

            return View(contacts);
        }

        public async Task<IActionResult> Detalles(int id) {
            var contact = new ContactoData();

            HttpClient client       = api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/contactos/{id}");

            if (res.IsSuccessStatusCode) { 
                var result = res.Content.ReadAsStringAsync().Result;
                contact    = JsonConvert.DeserializeObject<ContactoData>(result);
            }

            return View(contact);
        }

        public IActionResult Crear() {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(ContactoData contacto) {
            HttpClient client = api.Initial();

            var creacion = client.PostAsJsonAsync<ContactoData>("api/contactos", contacto);
            creacion.Wait();

            var result = creacion.Result;
            if (result.IsSuccessStatusCode) { 
                return RedirectToAction("Index");   
            }

            return View();
        }

        public async Task<IActionResult> Editar(int id) {
            var contact = new ContactoData();

            HttpClient client       = api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/contactos/{id}");

            if (res.IsSuccessStatusCode) {
                var result = res.Content.ReadAsStringAsync().Result;
                contact    = JsonConvert.DeserializeObject<ContactoData>(result);
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult Editar(ContactoData contacto) {
            HttpClient client = api.Initial();

            var actualizacion = client.PutAsJsonAsync<ContactoData>("api/contactos/", contacto);
            actualizacion.Wait();

            var result = actualizacion.Result;
            if (result.IsSuccessStatusCode) { 
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Eliminar(int id) {
            var contact = new ContactoData();

            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/contactos/{id}");

            return RedirectToAction("Index");
        }
    }
}
