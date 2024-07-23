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
    public partial class resultados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
            obtener_ganador();




        }
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM VotosPorPartido2"))
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
        protected void obtener_ganador()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                // Obtener el total de votos
                int totalVotos = 0;
                using (SqlCommand cmdTotal = new SqlCommand("SELECT SUM(total_votos) AS TotalVotos FROM VotosPorPartido2", con))
                {
                    totalVotos = Convert.ToInt32(cmdTotal.ExecuteScalar());
                }

                // Obtener el partido con el máximo número de votos
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 nombre_partido, total_votos FROM VotosPorPartido2 ORDER BY total_votos DESC", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string partidoGanador = reader["nombre_partido"].ToString();
                            int maxVotos = Convert.ToInt32(reader["total_votos"]);
                            double porcentaje = ((double)maxVotos / totalVotos) * 100;
                            ganador.Text = $"El partido ganador es {partidoGanador} con {maxVotos} votos, que es el {porcentaje:F2}% del total de votos.";
                        }
                        else
                        {
                            ganador.Text = "No se encontraron registros en la tabla de votos.";
                        }
                    }
                }
            }
        }

    }
}


    
