using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibreriaClases1;

namespace Piva
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String cmd = string.Format("EXEC PA_CONSULTAR_TODO_MAYUS");

            try
            {
                DataSet ds = Utilidades.EjecutarSQL(cmd);
                tabla1.DataSource = ds.Tables[0];
               
                //String usuario = ds.Tables[0].Rows[0]["USUARIO"].ToString().Trim();
                //String contraseña = ds.Tables[0].Rows[0]["CONTRASEÑA"].ToString().Trim();
                MessageBox.Show("Datos obtenidos exitosamente");
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo obtener los datos");
            }


        }

        private void Tabla1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tabla1.Columns[e.ColumnIndex].Name == "PRECIO") 
            {
                if (Convert.ToInt32(e.Value) <= 25) 
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.Red;

                }
                if(Convert.ToInt32(e.Value) > 25 && Convert.ToInt32(e.Value) <=30 ) 
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.Orange;
                }
                if (Convert.ToInt32(e.Value) > 30)
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.GreenYellow;
                }

            }
        }
    }
}
