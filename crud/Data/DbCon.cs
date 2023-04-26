using crud.Models;
using Microsoft.EntityFrameworkCore;

namespace crud.Data
{
    public class DbCon : DbContext
    {
        public DbCon(DbContextOptions<DbCon> options) : base(options)
        {
            Usuarios = Set<Usuario>();
        }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>().ToTable("Usuarios");
            builder.Entity<Usuario>().HasKey(u => u.Id_Usuario);
            builder.Entity<Usuario>().Property(u => u.Id_Usuario).HasColumnName("Id_Usuario");
            builder.Entity<Usuario>().Property(u => u.Nombre).HasColumnName("Nombre");
            builder.Entity<Usuario>().Property(u => u.Apellido).HasColumnName("Apellido");
            builder.Entity<Usuario>().Property(u => u.Email).HasColumnName("Email");
            builder.Entity<Usuario>().Property(u => u.Edad).HasColumnName("Edad");

        }

        public List<Usuario> ObtenerUsuarios()
        {
            return Set<Usuario>().FromSqlRaw("exec sp_obtener_usuarios").ToList();
        }

        public Usuario? ObtenerUsuario(int id)
        {
            var usuario = Set<Usuario>().FromSqlInterpolated($"exec sp_obtener_usuario {id}").AsEnumerable().FirstOrDefault();
            return usuario;
        }

        public void CrearUsuario(string nombre, string apellido, string email, int edad)
        {
            Database.ExecuteSqlRaw("exec sp_insertar_usuario {0}, {1}, {2}, {3}", nombre, apellido, email, edad);
        }

        public void ActualizarUsuario(int id, string nombre, string apellido, string email, int edad)
        {
            Database.ExecuteSqlRaw("exec sp_actualizar_usuario {0}, {1}, {2}, {3}, {4}", id, nombre, apellido, email, edad);
        }

        public void EliminarUsuario(int id)
        {
            Database.ExecuteSqlRaw("exec sp_eliminar_usuario {0}", id);
        }
    }
}