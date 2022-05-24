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
    public partial class Sistema : Form
    {
        public Sistema()
        {
            InitializeComponent();
            LeerDatos();
        }
        
        private void LeerDatos()
        {
            string consultar = "select *from proyectofinal.servicio;";
            MySqlConnection conn = Conexion.conexion_sql.obtenerConexion();
            MySqlCommand cmd = new MySqlCommand(consultar, conn);
            try
            {
                conn.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataTableServicio.DataSource = dt;
                conn.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error en la lectura: "+e.Message);
            }
        }
        
        private void boton_agregar_Click(object sender, EventArgs e)
        {
            
        }
        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void boton_calcular_Click(object sender, EventArgs e)
        {
            Catalogo catalog_productos = new Catalogo();
            catalog_productos.ShowDialog(); 
        }
    }
}
