using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dominio;

namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulos> listar()
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //preparamos la consulta y ejecutamos el lector, mientras este lea se ejecutara lo del while
                datos.setConsulta("SELECT \r\nA.Id, \r\nCodigo, \r\nNombre,\r\nPrecio,\r\nIdMarca, \r\nIdCategoria, \r\nM.Descripcion AS marca, \r\nA.Descripcion,  \r\nC.Descripcion AS Categoria\r\nFROM ARTICULOS AS A\r\nINNER JOIN CATEGORIAS AS C ON C.Id = A.IdCategoria\r\nINNER JOIN MARCAS AS M ON M.Id = A.IdMarca");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();

                    // Aca rellenamos los objetos que vamos a empujar a la lista con los valores de la DB
                    // aux.prop = (tipoDato)datos.Lector["col"];
                    // --- reemplazar prop por propiedad de Articulos, tipodato por el dato esperado(como el lector devuelve
                    // --- un objeto debemos castearlo) y en col, la columna de la DB.

                    // ej-
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];  
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    aux.Imagen = new List<Imagenes>();
                    ImagenesNegocio imgNegocio = new ImagenesNegocio();
                    aux.Imagen = imgNegocio.listarImagenesPropias(aux.Id);

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Funciones para asignar a los botones del diseño
        public void Agregar(Articulos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                datos.setearParametro("@Codigo", nuevo.Codigo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@Precio", nuevo.Precio);

                datos.ejecutarAccion();

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

        public void Modificar(Articulos modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE ARTICULOS SET Codigo = @CODIGO, Nombre = @NOMBRE, Descripcion = @DESCRIPCION, IdMarca = @IDMARCA, IdCategoria = @IDCATEGORIA, Precio = @PRECIO WHERE Id = @ID");
                datos.setearParametro("@CODIGO", modificar.Codigo);
                datos.setearParametro("@NOMBRE", modificar.Nombre);
                datos.setearParametro("@DESCRIPCION", modificar.Descripcion);
                datos.setearParametro("@IDMARCA", modificar.Marca.Id);
                datos.setearParametro("@IDCATEGORIA", modificar.Categoria.Id);
                datos.setearParametro("@PRECIO", modificar.Precio);
                datos.setearParametro("@ID", modificar.Id);

                datos.ejecutarAccion();
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
        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("DELETE FROM ARTICULOS WHERE Id = @ID");
                datos.setearParametro("@ID", id);
                datos.ejecutarAccion();
                datos.setConsulta("DELETE FROM IMAGENES WHERE IdArticulo = @ID");
                datos.ejecutarAccion();
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

        public int UltimoArticuloCargado()
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("SELECT TOP(1) Id FROM ARTICULOS ORDER BY Id DESC");
                datos.ejecutarLectura();


                while(datos.Lector.Read())
                {
                    int aux = (int)datos.Lector["Id"];

                    return aux;
                }
                return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object filtrar(string campo, string criterio, string filtro)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Id, Codigo, Nombre, Precio, IdMarca, IdCategoria, M.Descripcion AS marca, A.Descripcion, C.Descripcion AS Categoria FROM ARTICULOS AS A INNER JOIN CATEGORIAS AS C ON C.Id = A.IdCategoria INNER JOIN MARCAS AS M ON M.Id = A.IdMarca WHERE ";

                switch (campo)
                {
                    case "ID":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "A.Id > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "A.Id < " + filtro;
                                break;
                            case "Igual a":
                                consulta += "A.Id = " + filtro;
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Nombre LIKE '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "A.Nombre LIKE '%" + filtro + "' ";
                                break;
                            case "Contiene":
                                consulta += "A.Nombre LIKE '%" + filtro + "%' ";
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Descripcion":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Descripcion LIKE '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "A.Descripcion LIKE '%" + filtro + "' ";
                                break;
                            case "Contiene":
                                consulta += "A.Descripcion LIKE '%" + filtro + "%' ";
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }


                datos.setConsulta(consulta);
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    aux.Imagen = new List<Imagenes>();
                    ImagenesNegocio imgNegocio = new ImagenesNegocio();
                    aux.Imagen = imgNegocio.listarImagenesPropias(aux.Id);

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
