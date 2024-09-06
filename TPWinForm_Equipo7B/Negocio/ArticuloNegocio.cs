using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //(0) Agrego esto para la conexion.
using Dominio;//(1) Agrego
using Negocio;//(2) Agrego
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;

namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> listar()
        {

            List<Articulo> lista = new List<Articulo>(); //instancio mi lista;
            AccesoDatos datos = new AccesoDatos(); // instancio mi conexion;

            try
            {

                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion AS Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, I.ImagenUrl FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo");
                datos.ejecutarLectura();
                
                
                //Voy a leer, si es que pudo me posiciona el puntero en la siguiente posicion;
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    //Aca procedo a evaluar si tiene nulos  o no.
                    if (!Convert.IsDBNull(datos.Lector["ImagenUrl"]))
                    {
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    }
                    else
                    {
                        aux.UrlImagen = "";
                    }
                    //-------------------------------------------------
                    if (!Convert.IsDBNull(datos.Lector["Marca"]))
                    {
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    else
                    {
                        aux.Marca.Descripcion = "";
                    }

                    //---------------------------------------------------

                    if (!Convert.IsDBNull(datos.Lector["Categoria"]))
                    {
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    }
                    else
                    {
                        aux.Categoria.Descripcion = "";
                    }

                    lista.Add(aux);// Agrego finalmente a la lista este articulo.     

                }

                return lista; //Cuando termino de leer que me devuelva la lista.





            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }






         
        }
    
    
        //metodo agregar, modificar, eliminar...
    
    
    
    }
}
