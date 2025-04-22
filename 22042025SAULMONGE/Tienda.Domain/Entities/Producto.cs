using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tienda.Domain.Entities
{
    public class Producto
    {
        public Guid Id { get; private set; }            // Identificador
        public string Nombre { get; private set; }        // Nombre
        public string Descripcion { get; private set; } // Descripción
        public decimal Precio { get; private set; }      // Precio base
        public string? Imagen { get; private set; }   // URL de imagen

        private Producto() { /* EF */ }

        public Producto(string nombre, string descripcion, decimal price, string? iamgen)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre es requerido.");
            if (price <= 0) throw new ArgumentException("El precio debe ser mayor que cero.");

            Id = Guid.NewGuid();
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = price;
            Imagen = iamgen;
        }

        public void ActualizarDetalle(string nombre, string descripcion, string? iamgen)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre es requerido.");
            Nombre = nombre;
            Descripcion = descripcion;
            Imagen = iamgen;
        }

        public void ActualizarPrecio(decimal nuevoPrecio)
        {
            if (nuevoPrecio <= 0) throw new ArgumentException("El precio debe ser mayor que cero.");
            Precio = nuevoPrecio;
        }
    }
}
