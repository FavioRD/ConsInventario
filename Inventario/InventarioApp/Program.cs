using System;
using System.Collections.Generic;

namespace InventarioApp
{
    class Program
    {
        static Inventario inventario = new Inventario();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n--- Sistema de Gestión de Inventario ---");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Listar Productos");
                Console.WriteLine("3. Modificar Producto");
                Console.WriteLine("4. Eliminar Producto");
                Console.WriteLine("5. Listar Productos por Categoría");
                Console.WriteLine("6. Salir");
                Console.Write("Selecciona una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarProducto();
                        break;
                    case "2":
                        inventario.ListarProductos();
                        break;
                    case "3":
                        ModificarProducto();
                        break;
                    case "4":
                        EliminarProducto();
                        break;
                    case "5":
                        ListarProductosPorCategoria();
                        break;
                    case "6":
                        Console.WriteLine("Saliendo del sistema...");
                        return;
                    default:
                        Console.WriteLine("Opción no válida, intenta de nuevo.");
                        break;
                }
            }
        }

        static void AgregarProducto()
        {
            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();
            Console.Write("Categoría: ");
            string categoria = Console.ReadLine();
            Console.Write("Stock: ");
            int stock = int.Parse(Console.ReadLine());
            Console.Write("Precio: ");
            double precio = double.Parse(Console.ReadLine());

            inventario.AgregarProducto(nombre, categoria, stock, precio);
        }

        static void ModificarProducto()
        {
            Console.Write("ID del producto a modificar: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();
            Console.Write("Nuevo stock: ");
            int nuevoStock = int.Parse(Console.ReadLine());
            Console.Write("Nuevo precio: ");
            double nuevoPrecio = double.Parse(Console.ReadLine());

            inventario.ModificarProducto(id, nuevoNombre, nuevoStock, nuevoPrecio);
        }

        static void EliminarProducto()
        {
            Console.Write("ID del producto a eliminar: ");
            int id = int.Parse(Console.ReadLine());

            inventario.EliminarProducto(id);
        }

        static void ListarProductosPorCategoria()
        {
            Console.Write("Ingrese la categoría a buscar: ");
            string categoria = Console.ReadLine();

            List<Producto> productosFiltrados = inventario.ListarProductosPorCategoria(categoria);

            if (productosFiltrados.Count > 0)
            {
                Console.WriteLine("\nProductos en la categoría " + categoria + ":");
                foreach (var producto in productosFiltrados)
                {
                    Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Stock: {producto.Stock}, Precio: {producto.Precio}");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron productos en esa categoría.");
            }
        }
    }
}
