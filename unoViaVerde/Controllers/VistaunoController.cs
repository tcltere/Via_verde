using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace unoViaVerde.Controllers
{
    public class VistaunoController : Controller
    {
        // GET: Vistauno
        public ActionResult Principal()
        {
            return View("/Views/misvistas/vista_uno.cshtml");
        }
        public ActionResult ingreso()
        {
            return View("/Views/misvistas/ingreso.cshtml");
        }
        public ActionResult beneficios()
        {
            return View("/Views/misvistas/beneficios.cshtml");
        }
        public ActionResult i_activador()
        {
            return View("/Views/misvistas/ingreso_activador.cshtml");
        }
        public ActionResult i_agente()
        {

            return View("/Views/misvistas/ingreso_agente.cshtml");
        }
        public ActionResult guarda(string Rut, string Nombre, string Direccion, int Telefono, string Correo, string pass, string clasi)
        {
            var mensaje = "";
          
            if (Rut == "")
            {
                mensaje = "Porfavor ingrese correctamente los datos solicitados";
            }

            else
            {
                if ((Rut).Length < 10)
                {
                    int ex = Rut.Length;
                    for (int x = 0; x < (10 - ex); x++)
                    {
                        Rut = "0" + Rut;
                    }
                }
                string[] srut = new string[10];
                for (int x = 0; x < 10; x++)
                {
                    srut[x] = Rut[x].ToString();
                }

                int[] irut = new int[8];
                for (int x = 0; x < 8; x++)
                {
                    irut[x] = int.Parse(srut[x]);
                }

                int[] digitos = new int[8];
                int[] multiplos = new int[8] { 3, 2, 7, 6, 5, 4, 3, 2 };

                for (int s = 0; s < 8; s++)
                {
                    digitos[s] = irut[s] * multiplos[s];
                }

                double dv = 0;
                dv = digitos[0] + digitos[1] + digitos[2] + digitos[3] + digitos[4] + digitos[5] + digitos[6] + digitos[7];
                dv = dv % 11;
                dv = 11 - dv;

                if ((srut[9] == "k" || srut[9] == "K") && dv == 10)
                {
                    mensaje = "rut ingresado correctamente";
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    con.Open();
                    var sentencia = new SqlCommand();
                    sentencia.CommandType = System.Data.CommandType.Text;
                    sentencia.CommandText = "insert into Agentes (Rut,Nombre,Direccion,Telefono,Correo,pass,Clasificar) values (@prut,@pnombre,@pdireccion,@ptelefono,@pcorreo,@ppass, @pclasi)";
                    sentencia.Parameters.Add(new SqlParameter("prut", Rut));
                    sentencia.Parameters.Add(new SqlParameter("pnombre", Nombre));
                    sentencia.Parameters.Add(new SqlParameter("pdireccion", Direccion));
                    sentencia.Parameters.Add(new SqlParameter("ptelefono", Telefono));
                    sentencia.Parameters.Add(new SqlParameter("pcorreo", Correo));
                    sentencia.Parameters.Add(new SqlParameter("ppass", pass));
                    sentencia.Parameters.Add(new SqlParameter("pclasi", clasi));
                    sentencia.Connection = con;
                    var result = sentencia.ExecuteNonQuery();
                     mensaje = "";
                    if (result != 0)
                    {
                        mensaje = "GRABADO";
                    }
                    else
                    {
                        mensaje = "Ingrese datos correctos";
                    }
                    ViewBag.mensaje = mensaje + Nombre;
                    con.Close();
                    return View("/Views/misvistas/ingreso_agente.cshtml");
                }
                else if (srut[9] == "0" && dv == 11)
                {
                    mensaje = "Rut Correcto, Usuario Registrado, Bienvenido a The Library";
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    con.Open();
                    var sentencia = new SqlCommand();
                    sentencia.CommandType = System.Data.CommandType.Text;
                    sentencia.CommandText = "insert into Agentes (Rut,Nombre,Direccion,Telefono,Correo,pass,Clasificar) values (@prut,@pnombre,@pdireccion,@ptelefono,@pcorreo,@ppass, @pclasi)";
                    sentencia.Parameters.Add(new SqlParameter("prut", Rut));
                    sentencia.Parameters.Add(new SqlParameter("pnombre", Nombre));
                    sentencia.Parameters.Add(new SqlParameter("pdireccion", Direccion));
                    sentencia.Parameters.Add(new SqlParameter("ptelefono", Telefono));
                    sentencia.Parameters.Add(new SqlParameter("pcorreo", Correo));
                    sentencia.Parameters.Add(new SqlParameter("ppass", pass));
                    sentencia.Parameters.Add(new SqlParameter("pclasi", clasi));
                    sentencia.Connection = con;
                    var result = sentencia.ExecuteNonQuery();
                     mensaje = "";
                    if (result != 0)
                    {
                        mensaje = "GRABADO";
                    }
                    else
                    {
                        mensaje = "Ingrese datos correctos";
                    }
                    ViewBag.mensaje = mensaje + Nombre;
                    con.Close();
                    return View("/Views/misvistas/ingreso_agente.cshtml");
                }
                else if (srut[9] == dv.ToString())
                {
                    mensaje = "Rut Correcto";
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    con.Open();
                    var sentencia = new SqlCommand();
                    sentencia.CommandType = System.Data.CommandType.Text;
                    sentencia.CommandText = "insert into Agentes (Rut,Nombre,Direccion,Telefono,Correo,pass,Clasificar) values (@prut,@pnombre,@pdireccion,@ptelefono,@pcorreo,@ppass, @pclasi)";
                    sentencia.Parameters.Add(new SqlParameter("prut", Rut));
                    sentencia.Parameters.Add(new SqlParameter("pnombre", Nombre));
                    sentencia.Parameters.Add(new SqlParameter("pdireccion", Direccion));
                    sentencia.Parameters.Add(new SqlParameter("ptelefono", Telefono));
                    sentencia.Parameters.Add(new SqlParameter("pcorreo", Correo));
                    sentencia.Parameters.Add(new SqlParameter("ppass", pass));
                    sentencia.Parameters.Add(new SqlParameter("pclasi", clasi));
                    sentencia.Connection = con;
                    var result = sentencia.ExecuteNonQuery();
                     mensaje = "";
                    if (result != 0)
                    {
                        mensaje = "GRABADO";
                    }
                    else
                    {
                        mensaje = "Ingrese datos correctos";
                    }
                    ViewBag.mensaje = mensaje + Nombre;
                    con.Close();
                    return View("/Views/misvistas/ingreso_agente.cshtml");
                }
                else if (dv == 10)
                {
                    mensaje = "Rut Incorrecto. Su Digito Verificador es: K ";

                }
                else
                {
                    mensaje = "Rut Incorrecto. favor ingresar un rut válido sin puntos ni letras y Con digito verificador";

                }
            }
            ViewBag.mensaje = mensaje;
            return View("/Views/misvistas/ingreso_agente.cshtml");
        }

        public ActionResult buscar()
        {
            return View("/Views/misvistas/reciclar.cshtml");
        }
        public ActionResult cuenta()
        {

            return View();
        }
       
        public ActionResult reciclar( string nom, string clasi, string dir)
        {
           
            ViewData["nom"] = nom;
            ViewData["clasi"] = clasi;
            ViewData["dir"] = dir;
            
            return View("/Views/misvistas/reciclar.cshtml");
        }
        [HttpPost]
        public ActionResult reciclar(  string nom, string dir, string categoria, string material, string clasi, int cant, string rut)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
              
            var sentencia = new SqlCommand();
            sentencia.CommandType = System.Data.CommandType.Text;
            sentencia.CommandText = "insert into reciclaje (Nombre,Direccion, Material,clasificacion,cantidad,rut) values (@pnombre,@pdireccion, @pmaterial,@pclasi,@pcant,@prut)";
           
            sentencia.Parameters.Add(new SqlParameter("pnombre", nom));
            sentencia.Parameters.Add(new SqlParameter("pdireccion", dir));      
            sentencia.Parameters.Add(new SqlParameter("pmaterial", material));
            sentencia.Parameters.Add(new SqlParameter("pclasi", clasi));
            sentencia.Parameters.Add(new SqlParameter("pcant", cant));
            sentencia.Parameters.Add(new SqlParameter("prut", rut));
            sentencia.Connection = con;
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";
         
                if (result != 0)
                {
                
                    mensaje = "GRACIAS"+"  "+nom+"  "+ "EL PLANETA TE AMA";
                }
                else
                {
                    mensaje = "Ingrese datos correctos";
                }
            ViewData["nom"] = nom;
            ViewData["clasi"] = clasi;
            ViewData["mat"] = material;
            ViewData["dir"] = dir;
            ViewData["rut"] = rut;
            ViewData["cant"] = cant;
         
            ViewBag.mensaje = mensaje;
            con.Close();
            return View("/Views/Vistauno/return_cta.cshtml");
        }
    

        public ActionResult activadores()
        {
            return View("/Views/misvistas/activadores.cshtml");
        }

        public ActionResult return_cta()
        {
            return View();
        }
        public ActionResult return_busqueda(string rut,string cant)
        {
            var mensaje = "";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            var sentencia = new SqlCommand();
            SqlDataReader clave;
            sentencia.Connection = con;
            sentencia.CommandText = "SELECT sum(cantidad) as cant from reciclaje where rut = '"+rut+"'";
            sentencia.CommandType = System.Data.CommandType.Text;
            clave = sentencia.ExecuteReader();
            if (clave.Read())
            {
                if (rut != "")
                {
                    mensaje ="Esta vez haz acomulado:    "+cant+" sumando un total:    "+ clave["cant"].ToString() +"    con el RUT:"+rut;
                  
                }

                else
                {
                    mensaje = "Datos no encontrados o mal ingresados";
                }


            }  
            else
            {
                mensaje = "Datos no encontrados o mal ingresados";
            }
            
            ViewBag.mensaje = mensaje;
            con.Close();
            return View();
        }
        public ActionResult stock(string material)
        {
            var mensaje = "";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            var sentencia = new SqlCommand();
            SqlDataReader clave;
            sentencia.Connection = con;
            sentencia.CommandText = "SELECT sum(cantidad) as cant from reciclaje where Material = '" + material + "'";
            sentencia.CommandType = System.Data.CommandType.Text;
            clave = sentencia.ExecuteReader();
            if (clave.Read())
            {
                if (material != "")
                {
                    mensaje = "La cantidad disponible de:  "+ material+   "    es     "  + clave["cant"].ToString();

                }

                else
                {
                    mensaje = "Datos no encontrados o mal ingresados";
                }


            }
            else
            {
                mensaje = "Datos no encontrados o mal ingresados";
            }

            ViewBag.mensaje = mensaje;
            con.Close();
            return View();
        }
        public ActionResult guardar_extraccion(string mat, int cant, string dir, string nom,string clasi,string rut, string transp, string id_o, string chofer)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=usuarios;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();

            var sentencia = new SqlCommand();
            sentencia.CommandType = System.Data.CommandType.Text;
            sentencia.CommandText = "insert into solicitud (material, cantidad,direccion, nombre,rut) values (@pmat,@pcant,@pdir, @pnom,@prut)";

            sentencia.Parameters.Add(new SqlParameter("pmat", mat));
            sentencia.Parameters.Add(new SqlParameter("pcant", cant));
            sentencia.Parameters.Add(new SqlParameter("pdir", dir));
            sentencia.Parameters.Add(new SqlParameter("pnom", nom));
            sentencia.Parameters.Add(new SqlParameter("prut", rut));
            sentencia.Connection = con;
            var result = sentencia.ExecuteNonQuery();
            var mensaje = "";

            if (result != 0)
            {

                mensaje = "GRACIAS" + "  " + nom + "  " + "EL PLANETA TE AMA";

            }
            else
            {
                mensaje = "Ingrese datos correctos";
            }
            if (transp != "")
            {
                ViewBag.aceptar = "solicitud enviada" + transp;
            }
            else
            {
                ViewBag.aceptar = "solicitud pendiente";
            }
            ViewData["nom"] = nom;
            ViewData["clasi"] = clasi;
            ViewData["mat"] = mat;
            ViewData["dir"] = dir;
            ViewData["rut"] = rut;
            ViewData["cant"] = cant;

            ViewBag.mensaje = mensaje;
            con.Close();
            return View("return_cta");
        }
    }
}
