using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;
namespace DietaPwr
{
    public partial class Form1 : Form
    {
        bool ograniczBialko = false;
            bool ograniczTluszcze = false;
            bool ograniczWeglowodany = false;
            bool ograniczWapn = false;
            bool ograniczZelazo = false;
            bool ograniczSod = false;
            bool ograniczWita = false;
            bool ograniczTiamine = false;
            bool ograniczWitc = false;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczBialko)
            {
                ograniczBialko = false;
                bialkoOd.ReadOnly = true;
                bialkoDo.ReadOnly = true;
            }
            else
            {
                ograniczBialko = true;
                bialkoOd.ReadOnly = false;
                bialkoDo.ReadOnly = false;
            }

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczSod)
            {
                ograniczSod = false;
                sodOd.ReadOnly = true;
                sodDo.ReadOnly = true;
            }
            else
            {
                ograniczSod = true;
                sodOd.ReadOnly = false;
                sodDo.ReadOnly = false;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bialkoOd_TextChanged(object sender, EventArgs e)
        {

        }

        private void tluszczeBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczTluszcze)
            {
                ograniczTluszcze = false;
                tluszczeOd.ReadOnly = true;
                tluszczeDo.ReadOnly = true;
            }
            else
            {
                ograniczTluszcze = true;
                tluszczeOd.ReadOnly = false;
                tluszczeDo.ReadOnly = false;
            }
        }

        private void weglowodanyBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczWeglowodany)
            {
                ograniczWeglowodany = false;
                weglowodanyOd.ReadOnly = true;
                weglowodanyDo.ReadOnly = true;
            }
            else
            {
                ograniczWeglowodany = true;
                weglowodanyOd.ReadOnly = false;
                weglowodanyDo.ReadOnly = false;
            }
        }

        private void wapnBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczWapn)
            {
                ograniczWapn = false;
                wapnOd.ReadOnly = true;
                wapnDo.ReadOnly = true;
            }
            else
            {
                ograniczWapn = true;
                wapnOd.ReadOnly = false;
                wapnDo.ReadOnly = false;
            }
        }

        private void zelazoBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczZelazo)
            {
                ograniczZelazo = false;
                zelazoOd.ReadOnly = true;
                zelazoDo.ReadOnly = true;
            }
            else
            {
                ograniczZelazo = true;
                zelazoOd.ReadOnly = false;
                zelazoDo.ReadOnly = false;
            }
        }

        private void witaBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczWita)
            {
                ograniczWita = false;
                witaOd.ReadOnly = true;
                witaDo.ReadOnly = true;
            }
            else
            {
                ograniczWita = true;
                witaOd.ReadOnly = false;
                witaDo.ReadOnly = false;
            }
        }

        private void tiaminaBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczTiamine)
            {
                ograniczZelazo = false;
                tiaminaOd.ReadOnly = true;
                tiaminaDo.ReadOnly = true;
            }
            else
            {
                ograniczTiamine = true;
                tiaminaOd.ReadOnly = false;
                tiaminaDo.ReadOnly = false;
            }
        }

        private void witcBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczWitc)
            {
                ograniczWitc = false;
                witcOd.ReadOnly = true;
                witcDo.ReadOnly = true;
            }
            else
            {
                ograniczWitc = true;
                witcOd.ReadOnly = false;
                witcDo.ReadOnly = false;
            }
        }
    }
}
