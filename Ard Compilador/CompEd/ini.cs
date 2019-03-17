using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CompEd
{
    public partial class ini : Form
    {    
        int total = 0;

        public ini()
        {
            InitializeComponent(); 
        }

        private void ini_DoubleClick(object sender, EventArgs e)
        {
            Ide id = new Ide();
            this.Hide();
            id.Show(); 
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ini_Load(object sender, EventArgs e)
        {
            // Maximum indica el valor máximo de la barra.
            prbCarga.Maximum = 100;
            // Minimum indica el valor mínimo de la barra.
            prbCarga.Minimum = 0;
            // Value indica desde donde se va a comenzar a llenar la barra, la nuestra iniciara desde cero.
            prbCarga.Value = 0;
            // Step indica el paso de la barra, entre más pequeño sea la barra tardará más en cargar.
            prbCarga.Step = 5;
            tiempoCarga.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = prbCarga.Minimum;
            total = total + 1;
            if (total == 2 && i < prbCarga.Maximum)
            {
                prbCarga.PerformStep();
                prbCarga.PerformStep();
                prbCarga.PerformStep();
                prbCarga.PerformStep();
                lblCarga.Text = "Cargando complementos.";
            }
            if (total == 3 && i < prbCarga.Maximum)
            {
                prbCarga.PerformStep();
                prbCarga.PerformStep();
                prbCarga.PerformStep();
                prbCarga.PerformStep();
                lblCarga.Text = "Cargando complementos..";
            }
            if (total == 4 && i < prbCarga.Maximum)
            {
                prbCarga.PerformStep();
                prbCarga.PerformStep();
                prbCarga.PerformStep();
                prbCarga.PerformStep();
                lblCarga.Text = "Cargando complementos...";
            }
            if (total == 5 && i < prbCarga.Maximum)
            {
                lblCarga.Text = "Sistema cargado";
                for (int isf = i; isf < prbCarga.Maximum; isf = isf + prbCarga.Step)
                {
                    // Esta instrucción avanza la posición actual de la barra.
                    prbCarga.PerformStep();
                    lblCarga.Text = "Sistema cargado";
                }
            }
            if (total == 6 )
            {
                Ide id = new Ide();
                this.Hide();
                id.Show();
            }
        }
    }
}