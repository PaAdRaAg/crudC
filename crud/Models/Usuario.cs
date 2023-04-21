namespace crud.Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int Edad { get; set; }
        public string? Email { get; set; }
    }
}