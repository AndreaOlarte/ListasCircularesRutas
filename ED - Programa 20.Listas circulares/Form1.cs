using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ED___Programa_20.Listas_circulares
{
    public partial class Form1 : Form
    {
        Base miBase;
        Ruta ruta = new Ruta();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            miBase = new Base(txtBase.Text, dtpMinutos.Value);
            ruta.agregar(miBase);
        }

        private void btnEnInicio_Click(object sender, EventArgs e)
        {
            miBase = new Base(txtBase.Text, dtpMinutos.Value);
            ruta.agregarInicio(miBase);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            miBase = new Base(txtBase.Text, dtpMinutos.Value);
            if (!ruta.insertarDespues(txtInsertar.Text, miBase))
                txtMostrar.Text = "No se pudo insertar la base";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            miBase = ruta.buscar(txtBase.Text);
            if (miBase != null)
                txtMostrar.Text = miBase.ToString();
            else
                txtMostrar.Text = "No se encontró dicha base";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!ruta.eliminar(txtBase.Text))
                txtMostrar.Text = "No se pudo eliminar dicha base";
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtMostrar.Text = ruta.reporte();
        }

        private void btnRecorrido_Click(object sender, EventArgs e)
        {
            txtMostrar.Text = ruta.recorrido(txtBase.Text, dtpInicio.Value, dtpFin.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now.AddHours(2);
        }
    }
}
