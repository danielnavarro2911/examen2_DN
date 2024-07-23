using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace examen2_DN.vistas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LlenarGrid();
            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM partido"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }

        protected void Ingresar()
        {
            if (partido.Text!="" || candidato.Text != "") { 
                String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection conexion = new SqlConnection(s);
                conexion.Open();
                SqlCommand comando = new SqlCommand($"INSERT INTO partido VALUES ('{partido.Text}','{candidato.Text}')", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
                LlenarGrid();
            }
            else { error_partido.Text = "Error, no se permiten espacios vacios"; }
        }

        protected void agregarpartido_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        protected void Borrar()
        {
            if (partido.Text != "")
            {
                String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
                SqlConnection conexion = new SqlConnection(s);
                conexion.Open();
                SqlCommand comando = new SqlCommand($"DELETE partido where nombre_partido = '{partido.Text}'", conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
                LlenarGrid();
            }
            else { error_partido.Text = "Error, no se permiten espacios vacios"; }

        }

        protected void borrarpartido_Click(object sender, EventArgs e)
        {
            Borrar();

        }
    }
}