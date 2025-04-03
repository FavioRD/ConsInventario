using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioApp
{
    class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }

        public Producto(int id, string nombre, string categoria, int stock, double precio)
        {
            Id = id;
            Nombre = nombre;
            Categoria = categoria;
            Stock = stock;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Categoría: {Categoria}, Stock: {Stock}, Precio: {Precio:C}";
        }
    }
}
