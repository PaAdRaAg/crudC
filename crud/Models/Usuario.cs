using System.ComponentModel.DataAnnotations;

namespace crud.Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        
        [Required(ErrorMessage = "El nombre es requerido.")]
        public string? Nombre { get; set; }
        
        [Required(ErrorMessage = "El apellido es requerido.")]
        public string? Apellido { get; set; }
        
        [Required(ErrorMessage = "El email es requerido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "La edad es requerida y no acepta valores negativos.")]
        public int Edad { get; set; }
    }
}