using System.ComponentModel.DataAnnotations;

namespace ContactosWebApp.Models {
    public class ContactoData {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        public string Correo { get; set; }
    }
}
