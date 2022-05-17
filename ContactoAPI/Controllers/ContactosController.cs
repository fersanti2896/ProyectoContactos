using ContactoAPI.Data;
using ContactoAPI.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactoAPI.Controllers {
    [ApiController]
    [Route("api/contactos")]
    public class ContactosController : ControllerBase {
        private readonly DataContext context;

        public ContactosController(DataContext context) {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contacto>>> Get() {
            var contactos = await context.Contactos.ToListAsync();

            return Ok(contactos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Contacto>> Get(int id){
            var contacto = await context.Contactos.FindAsync(id);

            if (contacto is null)
                return BadRequest("Contacto not found.");

            return Ok(contacto);
        }

        [HttpPost]
        public async Task<ActionResult<List<Contacto>>> AddContacto(Contacto contacto) {
            context.Contactos.Add(contacto);
            await context.SaveChangesAsync();

            var contactos = await context.Contactos.ToListAsync(); 

            return Ok(contactos);
        }

        [HttpPut]
        public async Task<ActionResult<List<Contacto>>> UpdateContacto(Contacto contacto) {
            var contact = await context.Contactos.FindAsync(contacto.Id);

            if (contact is null)
                return BadRequest("Contact not found.");

            contact.Nombre   = contacto.Nombre;
            contact.Telefono = Convert.ToString( contacto.Telefono);
            contact.Correo   = contacto.Correo;

            await context.SaveChangesAsync();

            var contactos = await context.Contactos.ToListAsync();

            return Ok(contactos);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteContacto(int id) {

            var contacto = await context.Contactos.FindAsync(id);

            if (contacto is null)
                return BadRequest("Contact not found.");

            context.Contactos.Remove(contacto);
            await context.SaveChangesAsync();

            //var contactos = await context.Contactos.ToListAsync();

            return Ok();
        }
    }
}
