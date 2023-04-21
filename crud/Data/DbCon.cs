using Microsoft.EntityFrameworkCore;
using crud.Models;


namespace crud.Data
{
    public class DbCon : DbContext
    {
        public DbCon(DbContextOptions<DbCon> options) : base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>().ToTable("Usuarios");
            builder.Entity<Usuario>().HasKey(u => u.Id_Usuario);
            builder.Entity<Usuario>().Property(u => u.Id_Usuario).HasColumnName("Id_Usuarios");
            builder.Entity<Usuario>().Property(u => u.Nombre).HasColumnName("Nombre");
            builder.Entity<Usuario>().Property(u => u.Apellido).HasColumnName("Apellido");
            builder.Entity<Usuario>().Property(u => u.Edad).HasColumnName("Edad");
            builder.Entity<Usuario>().Property(u => u.Email).HasColumnName("Email");
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return Usuarios.FromSqlRaw("exec sp_obtener_usuarios").ToList();
        }

        public Usuario? ObtenerUsuario(int id)
        {
            var usuario = Usuarios.FromSqlInterpolated($"exec sp_obtener_usuario {id}").AsEnumerable().FirstOrDefault();
            return usuario;
        }

        public void CrearUsuario(string nombre, string apellido, int edad, string email)
        {
            Database.ExecuteSqlRaw("exec sp_insertar_usuario {0}, {1}, {2}, {3}", nombre, apellido, edad, email);
        }

        public void ActualizarUsuario(int id, string nombre, string apellido, int edad, string email)
        {
            Database.ExecuteSqlRaw("exec sp_actualizar_usuario {0}, {1}, {2}, {3}, {4}", id, nombre, apellido, edad, email);
        }

        public void EliminarUsuario(int id)
        {
            Database.ExecuteSqlRaw("exec sp_eliminar_usuario {0}", id);
        }
    }
}