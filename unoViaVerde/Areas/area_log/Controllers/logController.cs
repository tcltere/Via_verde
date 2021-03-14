using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace unoViaVerde.Areas.area_log.Controllers
{
    public class logController : Controller
    {
       
        // GET: area_log/log
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult superA(string clasi, string nom, string pass, string categoria)
        {
            ViewData["clasi"] = clasi;
            ViewData["nom"] = nom;
            ViewData["pass"] = pass;
            ViewData["categoria"] = categoria;
            return View();
        }
        public ActionResult mostrar()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var sentencia = new SqlCommand();
            SqlDataReader dr;
            sentencia.Connection = con;
            sentencia.CommandText = "select * from Agentes";

            sentencia.CommandType = System.Data.CommandType.Text;
            con.Open();
            dr = sentencia.ExecuteReader();
            var mensaje = "<table border=1>";


            while (dr.Read())
            {
                mensaje = mensaje + "<tr><td>" + dr["Rut"].ToString() + "&nbsp" + "|" + "&nbsp" + dr["Nombre"].ToString() + "&nbsp"+"|" + "&nbsp" + dr["Direccion"].ToString() + "&nbsp" + "|" + "&nbsp" + dr["Telefono"].ToString() + "&nbsp" + "|" + "&nbsp" + dr["Correo"].ToString() + "&nbsp" + "|" + "&nbsp" + dr["categoria"].ToString() + "&nbsp" + "|" + "&nbsp" + dr["clasificar"].ToString();
            }
            mensaje = mensaje + "</td></tr></table>";
            ViewBag.mensaje = mensaje;
            con.Close();
            return View();
        }
        public ActionResult editar(string rut, string nom, string categoria)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            var sentencia = new SqlCommand();
            sentencia.CommandType = System.Data.CommandType.Text;
            sentencia.CommandText = "update Agentes set Nombre=@pnom,categoria=@pcategoria where Rut='"+rut+"'";
            sentencia.Parameters.Add(new SqlParameter("pnom", nom));
            sentencia.Parameters.Add(new SqlParameter("pcategoria", categoria));
    

            sentencia.Connection = con;
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result != 0)
            {
                mensaje = "Registro modificado con éxito";
            }
            else
            {
                mensaje = "Debe ingresar un dato";

            }
            ViewBag.mensaje = mensaje;
            con.Close();
            return View();
        }
        public ActionResult borrar(string rut)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            var sentencia = new SqlCommand();
            sentencia.CommandType = System.Data.CommandType.Text;
            sentencia.CommandText = "DELETE from Agentes where Rut = (@prut) ";
            sentencia.Parameters.Add(new SqlParameter("prut", rut));

            sentencia.Connection = con;
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
            if (result != 0)
            {
                mensaje = "registro eliminado";
            }
            else
            {
                mensaje = "error";

            }
            ViewBag.mensaje = mensaje;
            con.Close();
            return View();
        }
        public ActionResult Admin(string op, string rut, string patente, string chofer, string orden)
        {
            if (op == "modificar")
            {   

                return View("editar");
            }
            else if (op == "eliminar") 
            {

                return View("borrar");
            }
            else if (op == "mostrar")
            {

                return View("mostrar");
            }
            else if (op == "agregar_stock")
            {

                return View();
            }
            else if (op == "buscar_solicitud")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();
                var sentencia = new SqlCommand();
                SqlDataReader clave;
                sentencia.Connection = con;
                sentencia.CommandText = "SELECT * FROM solicitud WHERE rut = @prut";
                sentencia.Parameters.Add(new SqlParameter("prut", rut));
                sentencia.CommandType = System.Data.CommandType.Text;
                clave = sentencia.ExecuteReader();
                while (clave.Read())
                {
                    if (clave["rut"].ToString() != "")
                    {
                        ViewBag.rut = clave["rut"].ToString();
                        ViewBag.cant = clave["cantidad"].ToString();
                        ViewBag.mat = clave["material"].ToString();
                        ViewBag.dir = clave["direccion"].ToString();
                        ViewBag.nom = clave["nombre"].ToString();
                        ViewBag.patente = clave["transporte_patente"].ToString();
                        ViewBag.orden = clave["id_orden"].ToString();
                        ViewBag.chofer = clave["chofer"].ToString();
                       





                    }

                    else
                    {
                       
                    }


                }
                con.Close();

                return View();
            }

            else if (op == "tabla_solicitud")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                var sentencia = new SqlCommand();
                SqlDataReader dr;
                sentencia.Connection = con;
                sentencia.CommandText = "select * from solicitud";
          
                sentencia.CommandType = System.Data.CommandType.Text;
                con.Open();
                dr = sentencia.ExecuteReader();
                var mensaje = "<table border=1>";


                while (dr.Read())
                {
                    mensaje = mensaje + "<tr><td>" + dr["rut"].ToString() + "&nbsp" + "|" + "&nbsp" + dr["nombre"].ToString() + "&nbsp" + "|" + "&nbsp" + dr["direccion"].ToString() + "&nbsp" + "|" + "&nbsp" + dr["material"].ToString() + "&nbsp" + "|" + "&nbsp" + dr["cantidad"].ToString();
                }
                mensaje = mensaje + "</td></tr></table>";
                ViewBag.mensaje = mensaje;
                con.Close();
             

                return View();
            }
            else if (op == "aceptar_solicitud")
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                con.Open();

                var sentencia = new SqlCommand();
                sentencia.CommandType = System.Data.CommandType.Text;
                sentencia.CommandText = "update solicitud set transporte_patente =@ppatente, id_orden=@porden, chofer=@pchofer where rut='" + rut + "'";
                sentencia.Parameters.Add(new SqlParameter("ppatente", patente));
                sentencia.Parameters.Add(new SqlParameter("porden", orden));
                sentencia.Parameters.Add(new SqlParameter("pchofer", chofer));

                sentencia.Connection = con;
                var result = sentencia.ExecuteNonQuery();
                var mensaje = "";
                if (result != 0)
                {
                    mensaje = "Registro modificado con éxito";
                }
                else
                {
                    mensaje = "Debe ingresar un dato";

                }
                ViewBag.mensaje = mensaje;
                con.Close();
       
                return View("solicitud");
            }


            else
            {
                return View();

            }
          
        }

        public ActionResult cta_agente1( string clasi, string nom, string pass, string categoria, string dir)
        {
            ViewData["clasi"] = clasi;
            ViewData["nom"] = nom;
            ViewData["pass"] = pass;
            ViewData["dir"] = dir;
            ViewData["categoria"] = categoria;
            return View();
        }
        public ActionResult cta_activador(string clasi, string nom, string pass)
        {
            ViewData["clasi"] = clasi;
            ViewData["nom"] = nom;
            ViewData["pass"] = pass;
            return View();
        }
        public ActionResult buscar(string rut, string nom,string pass,string clasi, string categoria, string dir)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            var sentencia = new SqlCommand();
            SqlDataReader clave;
            sentencia.Connection = con;
            sentencia.CommandText = "SELECT * FROM Agentes WHERE Rut = @prut";
            sentencia.Parameters.Add(new SqlParameter("prut", rut));
            sentencia.CommandType = System.Data.CommandType.Text;
            clave = sentencia.ExecuteReader();
            while (clave.Read())
            {
                if (pass == clave["pass"].ToString())
                {
                    ViewData["rut"] = clave["Rut"].ToString();
                    ViewData["nom"] = clave["Nombre"].ToString();
                    ViewData["pass"] = clave["pass"].ToString();
                    ViewData["clasi"] = clave["Clasificar"].ToString();
                    ViewData["categoria"] = clave["categoria"].ToString();
                    ViewData["dir"] = clave["Direccion"].ToString();
                    ViewData["validar"] = "ok";
                 
                 
                
                }
                
                else
                {
                    ViewData["validar"] = "no";
                }             
              
              
            }
            con.Close();
            return View();
        }
        public ActionResult solicitud()
        {
            return View();
        }

    }
}
