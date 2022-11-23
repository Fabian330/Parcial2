using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial2
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["TiendaUHConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select v.codigoVenta, c.codigoCajero, c.nombreCajero, p.codigoProducto, p.nombreProducto, p.precio, m.codigoMaquina, m.piso\r\nfrom Venta v\r\ninner join Cajeros c on c.codigoCajero = v.cajero\r\ninner join Productos p on p.codigoProducto = v.producto\r\ninner join MaquinasRegistradoras m on m.codigoMaquina = v.maquina"))
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

        protected void bIngresar_Click(object sender, EventArgs e)
        {
            Datos.c1 = tC1.Text;
            Datos.c2 = tC2.Text;
            Datos.c3 = tC3.Text;

            String s = System.Configuration.ConfigurationManager.ConnectionStrings["TiendaUHConnectionString"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand(" INSERT INTO Venta (cajero, maquina, producto) VALUES ('" + Datos.c1 + "', '" + Datos.c2 + "', '" + Datos.c3 + "')", conexion);
            comando.ExecuteNonQuery();
            conexion.Close();

            LlenarGrid();

            tC1.Text = "";
            tC2.Text = "";
            tC3.Text = "";
        }
    }
}