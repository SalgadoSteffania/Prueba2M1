using PepitoSchool.App.Interfaces;
using PepitoSchool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PepitoSchool.Forms.Forms
{
    public partial class FrmEstudiante : Form
    {
        public IEstudiantesServices estudiantesServices { get; set; }
        int index;
        Estudiante est;
        public FrmEstudiante( int index)
        {
            this.index = index;
            InitializeComponent();
        }

        private void FrmEstudiante_Load(object sender, EventArgs e)
        {
            if (index!= -50)
            {
                est = estudiantesServices.GetAll()[index];
                txtNames.Text = est.Nombres;
                txtLastnames.Text = est.Apellidos;
                txtCarnet.Text = est.Carnet;
                txtPhone.Text = est.Phone;
                txtDireccion.Text = est.Direccion;
                txtCorreo.Text = est.Correo;
                nudMatematicas.Value = est.Matematica;
                nudEstadistica.Value = est.Estadistica;
                nudProgramacion.Value = est.Programacion;
                nudContabilidad.Value = est.Contabilidad;
                btnAceptar.Enabled = false;
                btnModificar.Enabled = true;
            }
            else
            {
                btnAceptar.Enabled = true;
                btnModificar.Enabled = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(verificar())
            {
                Estudiante estudiante = new Estudiante()
                {
                    Nombres = txtNames.Text,
                    Apellidos = txtLastnames.Text,
                    Carnet = txtCarnet.Text,
                    Phone = txtPhone.Text,
                    Direccion = txtDireccion.Text,
                    Correo = txtCorreo.Text,
                    Matematica = (int)nudMatematicas.Value,
                    Estadistica = (int)nudEstadistica.Value,
                    Programacion = (int)nudProgramacion.Value,
                    Contabilidad = (int)nudContabilidad.Value,

                };
                estudiantesServices.Create(estudiante);
                Dispose();
            }
            else
            {
                MessageBox.Show("Tienes que llenar todos los formularios.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (verificar())
            {
                Estudiante estudiante = new Estudiante()
                {
                    Id = est.Id,
                Nombres = txtNames.Text,
                Apellidos = txtLastnames.Text,
                Carnet = txtCarnet.Text,
                Phone = txtPhone.Text,
                Direccion = txtDireccion.Text,
                Correo = txtCorreo.Text,
                Matematica = (int)nudMatematicas.Value,
                Estadistica = (int)nudEstadistica.Value,
                Programacion = (int)nudProgramacion.Value,
                Contabilidad = (int)nudContabilidad.Value,

                };
                estudiantesServices.Update(estudiante);
                Dispose();
            }
            else
            {
                MessageBox.Show("Tienes que llenar todos los formularios.");
            }
          
            
        }

        public bool verificar()
        {
            if (String.IsNullOrEmpty(txtNames.Text) || String.IsNullOrEmpty(txtLastnames.Text) || String.IsNullOrEmpty(txtCarnet.Text) || String.IsNullOrEmpty(txtPhone.Text)
                || String.IsNullOrEmpty(txtDireccion.Text) || String.IsNullOrEmpty(txtCorreo.Text) )
            {
                return false;
            }
            return true;
        }
    }
}
