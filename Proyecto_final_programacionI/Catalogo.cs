using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Proyecto_final_programacionI
{
    public partial class Catalogo : Form
    {
        public Catalogo()
        {
            InitializeComponent();
            Leer_catalogo();
        }
        private void Leer_catalogo()
        {
            string consulta_catalogo = "SELECT * FROM `productos_disponibles` WHERE 1;";
            MySqlConnection con = Conexion.conexion_sql.obtenerConexion();
            MySqlCommand cmd_catalogo = new MySqlCommand(consulta_catalogo, con);    
            try
            {
                con.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd_catalogo;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Tabla_producto.DataSource = dt;
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error en la consulta: "+e.Message);
            }

        }
    }
}
