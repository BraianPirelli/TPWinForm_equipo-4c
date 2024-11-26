using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenesNegocio
    {
        public List<Imagenes> listarImagenesPropias(int IdArticulo)
        {
            List<Imagenes> lista = new List<Imagenes>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //preparamos la consulta y ejecutamos el lector, mientras este lea se ejecutara lo del while
                datos.setConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES WHERE IdArticulo = @ID");
                datos.setearParametro("@ID", IdArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagenes aux = new Imagenes();

                    // Aca rellenamos los objetos que vamos a empujar a la lista con los valores de la DB
                    // aux.prop = (tipoDato)datos.Lector["col"];
                    // --- reemplazar prop por propiedad de Articulos, tipodato por el dato esperado(como el lector devuelve
                    // --- un objeto debemos castearlo) y en col, la columna de la DB.

                    // ej-
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cargarImagen(int idArticulo, string UrlImagen)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IDARTICULO, @URL)");
            datos.setearParametro("@IDARTICULO", idArticulo);
            datos.setearParametro("@URL", UrlImagen);
            datos.ejecutarLectura();
        }

        public void cargarImagenes(int idArticulo, List<string> UrlImagenes)
        {
            AccesoDatos datos = new AccesoDatos();
            foreach (string str in UrlImagenes) {
                datos.setConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IDARTICULO, @URL)");
                datos.setearParametro("@IDARTICULO", idArticulo);
                datos.setearParametro("@URL", str);
                datos.ejecutarLectura();
            }
        }
    }
}
