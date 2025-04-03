using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace InventarioApp
{
    class Inventario
    {
        private string conexionString = "Server=cambiar-por-tu-servidor;Database=BD_Inventario;Trusted_Connection=True;";
        private List<Producto> productos = new List<Producto>();

        public Inventario()
        {
            CargarDesdeSQL();
        }

        public void CargarDesdeSQL()
        {
            productos.Clear();
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                string query = "SELECT Id, Nombre, Categoria, Stock, Precio FROM Productos";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto producto = new Producto(
                        lector.GetInt32(0),
                        lector.GetString(1),
                        lector.GetString(2),
                        lector.GetInt32(3),
                        Convert.ToDouble(lector["Precio"])
                    );
                    productos.Add(producto);
                }
            }
        }

        public void AgregarProducto(string nombre, string categoria, int stock, double precio)
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                string query = "INSERT INTO Productos (Nombre, Categoria, Stock, Precio) VALUES (@Nombre, @Categoria, @Stock, @Precio)";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Categoria", categoria);
                comando.Parameters.AddWithValue("@Stock", stock);
                comando.Parameters.AddWithValue("@Precio", precio);

                comando.ExecuteNonQuery();
            }
            CargarDesdeSQL();
        }

        public void ListarProductos()
        {
            if (productos.Count == 0)
            {
                Console.WriteLine(" No hay productos en el inventario.");
                return;
            }

            Console.WriteLine("\n Lista de Productos:");
            foreach (var producto in productos)
            {
                Console.WriteLine(producto);
            }
        }

        public void ModificarProducto(int id, string nuevoNombre, int nuevoStock, double nuevoPrecio)
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                string query = "UPDATE Productos SET Nombre = @Nombre, Stock = @Stock, Precio = @Precio WHERE Id = @Id";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombre", nuevoNombre);
                comando.Parameters.AddWithValue("@Stock", nuevoStock);
                comando.Parameters.AddWithValue("@Precio", nuevoPrecio);
                comando.Parameters.AddWithValue("@Id", id);

                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    Console.WriteLine(" Producto modificado correctamente.");
                }
                else
                {
                    Console.WriteLine(" Producto no encontrado.");
                }
            }
            CargarDesdeSQL();
        }
        public List<Producto> ListarProductosPorCategoria(string categoria)
        {
            return productos.Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void EliminarProducto(int id)
        {
            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                conexion.Open();
                string query = "DELETE FROM Productos WHERE Id = @Id";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Id", id);

                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    Console.WriteLine(" Producto eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine(" Producto no encontrado.");
                }
            }
            CargarDesdeSQL();
        }
    }
}
