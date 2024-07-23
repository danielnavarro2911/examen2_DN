using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace examen2_DN.vistas
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_lista();
                LlenarGrid();
            }
        }

        protected void cargar_lista()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT nombre_partido FROM partido";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    ddlPartidos.DataSource = reader;
                    ddlPartidos.DataTextField = "nombre_partido";
                    ddlPartidos.DataBind();
                }
            }
            ddlPartidos.Items.Insert(0, new ListItem("Seleccione un partido", "0"));
        }

        protected void registrar_voto()
        {
            if (ddlPartidos.SelectedIndex > 0) // Verificar que se haya seleccionado un partido válido
            {
                string partidoSeleccionado = ddlPartidos.SelectedItem.Text;
                string connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO votos (nombre_partido) VALUES (@nombre_partido)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre_partido", partidoSeleccionado);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                LlenarGrid();
            }
            
        }

        protected void Bregistrar_voto_Click(object sender, EventArgs e)
        {
            registrar_voto();
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM votos"))
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
    }
}
