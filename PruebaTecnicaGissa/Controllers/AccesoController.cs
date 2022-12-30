using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PruebaTecnicaGissa.Models;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Data;

namespace PruebaTecnicaGissa.Controllers
{
    public class AccesoController : Controller
    {

        //GET: Acceso

        string cadena = "server=localhost; database=TestDB; integrated security=true; TrustServerCertificate=true";

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

		public ActionResult Consultor()
		{
			return View();
		}

		[HttpPost]
        public ActionResult Registrar(Usuario usuario)
        {
            string mensaje;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("test_sp_ResgistrarUsuario", cn);
                cmd.Parameters.AddWithValue("USER_LastName", usuario.USER_LastName);
                cmd.Parameters.AddWithValue("USER_NickName", usuario.USER_NickName);
                cmd.Parameters.AddWithValue("USER_UserType", usuario.USER_UserType);
                cmd.Parameters.AddWithValue("USER_Type_Ced", usuario.USER_Type_Ced);
                cmd.Parameters.AddWithValue("USER_Ced", usuario.USER_Ced);
                cmd.Parameters.AddWithValue("USER_Pass", usuario.USER_Pass);
                cmd.Parameters.AddWithValue("USER_Email", usuario.USER_Email);
                cmd.Parameters.Add("Message", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
                mensaje = cmd.Parameters["Mensaje"].ToString();
            }
            ViewData["Mensaje"] = mensaje;

            if (mensaje.Equals(""))
            {
                return RedirectToAction("Acceso", "Login");
            }
            else
            {
                return RedirectToAction("Acceso", "Login");
            }

        }

        [HttpPost]

        /*
         Funcion que recibe como parametro un Usuario y luego comprueba si el usuario esta logueado o registrado
        y lo redirecciona a la pagina de Inicio
         */
		public ActionResult Login(Usuario usuario)
        {
            
            //NO OLVIDAR CONVERTIR EL PASSWORD

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("test_sp_ValidarUsuario", cn);

                cmd.Parameters.AddWithValue("USER_NickName", usuario.USER_NickName);
                cmd.Parameters.AddWithValue("USER_Pass", usuario.USER_Pass);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                


				//Lee la primera columna y primera fila
				usuario.USER_UserType = Convert.ToString(cmd.ExecuteScalar());
            }

            if (usuario.USER_UserType.Equals("A"))
            {
                
                HttpContext.Session.SetString("usuario", usuario.USER_UserType);
				return RedirectToAction("Index", "Home");

			}
			else
            {
				return RedirectToAction("Consultor", "Acceso");
			}

         
        }

        //public ActionResult Registrar()
    }
}
