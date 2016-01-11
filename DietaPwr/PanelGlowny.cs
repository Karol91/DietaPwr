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
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic.FileIO;
namespace DietaPwr
{
    public partial class PanelGlowny : Form
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
        List<Produkty> listaProduktow = null;
        List<Produkty> listaProduktowFiltr = null;

        public PanelGlowny()
        {
            InitializeComponent();

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


        private void otworzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult openFile = openFileDialog1.ShowDialog();
            if (openFile == DialogResult.OK)
            {
                try
                {
                    string file = openFileDialog1.FileName;
                    string text = File.ReadAllText(file);
                    size = text.Length;
                    if (parsujCsv(file))
                    {
                        listaProduktowFiltr = new List<Produkty>(listaProduktow);
                        BindGrid();
                        setRowNumber(dataGridView1);                                                
                    }                   
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Nie można otworzyć podanego pliku: "+exception.ToString()  , "Błąd");
                    
                }
            }
        }

        bool parsujCsv(string file)
        {
            listaProduktow = new List<Produkty>();
            try
            {

                var csv = new CsvReader(new StreamReader(file));
                while (csv.Read())
                {
                    Produkty produkt = new Produkty();
                    produkt.Type = csv.GetField<string>(0);
                    produkt.FoodName = csv.GetField<string>(1);
                    produkt.Calories = csv.GetField<string>(2);
                    produkt.Protein = csv.GetField<string>(3);
                    produkt.Fat = csv.GetField<string>(4);
                    produkt.Carbohydrates = csv.GetField<string>(5);
                    produkt.Calcium = csv.GetField<string>(6);
                    produkt.Iron = csv.GetField<string>(7);
                    produkt.Sodium = csv.GetField<string>(8);
                    produkt.VitaminA = csv.GetField<string>(9);
                    produkt.Thiamin = csv.GetField<string>(10);
                    produkt.VitaminC = csv.GetField<string>(11);

                    listaProduktow.Add(produkt);
                }
            }
               
            catch (Exception exception)
            {
                MessageBox.Show("Nie można sparsować podanego pliku: " + exception.ToString(), "Błąd");
                return false;
            }
            return true;
        }
        
        private void BindGrid()
        {            
            var filenamesList = new BindingList<Produkty>(listaProduktowFiltr);

            dataGridView1.DataSource = filenamesList; 
        }
        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }


        private void Filtrowanie(CheckBox checkbox, String typ)
        {
            try
            {
                if (checkbox.Checked)
                {
                    foreach (Produkty produkt in listaProduktow)
                    {
                        if (produkt.Type.Equals(typ))
                            listaProduktowFiltr.Add(produkt);
                    }
                }
                else
                {
                    foreach (Produkty produkt in listaProduktow)
                    {
                        if (produkt.Type.Equals(typ))
                            listaProduktowFiltr.Remove(produkt);
                    }
                }
                BindGrid();
                setRowNumber(dataGridView1);
            }
            catch (Exception)
            {
                MessageBox.Show("Wystapił błąd podczas filtrowania. Brak danych", "Błąd");
            }
        }

        #region Filtry checkBox
        private void chckBoxCheese_CheckedChanged(object sender, EventArgs e)
        {
            Filtrowanie(chckBoxCheese, chckBoxCheese.Text);
        }

        private void chckBoxJuice_CheckedChanged(object sender, EventArgs e)
        {
            Filtrowanie(chckBoxJuice, chckBoxJuice.Text);
        }

        private void chckBoxFruit_CheckedChanged(object sender, EventArgs e)
        {
            Filtrowanie(chckBoxFruit, chckBoxFruit.Text);
        }

        private void chckBoxVegetable_CheckedChanged(object sender, EventArgs e)
        {
            Filtrowanie(chckBoxVegetable, chckBoxVegetable.Text);
        }

        private void chckBoxMeat_CheckedChanged(object sender, EventArgs e)
        {
            Filtrowanie(chckBoxMeat, chckBoxMeat.Text);
        }

        private void chckBoxBreakfast_CheckedChanged(object sender, EventArgs e)
        {
            Filtrowanie(chckBoxBreakfast, chckBoxBreakfast.Text);
        }

        private void chckBoxBaked_CheckedChanged(object sender, EventArgs e)
        {
            Filtrowanie(chckBoxBaked, chckBoxBaked.Text);
        }

        private void chckBoxDessert_CheckedChanged(object sender, EventArgs e)
        {
            Filtrowanie(chckBoxDessert, chckBoxDessert.Text);
        }

        private void chckBoxDairy_CheckedChanged(object sender, EventArgs e)
        {
            Filtrowanie(chckBoxDairy, chckBoxDairy.Text);
        }

        private void chckBoxSnack_CheckedChanged(object sender, EventArgs e)
        {
            Filtrowanie(chckBoxSnack, chckBoxSnack.Text);
        }

        private void chckBoxPoultry_CheckedChanged(object sender, EventArgs e)
        {
            Filtrowanie(chckBoxPoultry, chckBoxPoultry.Text);
        }

        private void chckBoxFish_CheckedChanged(object sender, EventArgs e)
        {
            Filtrowanie(chckBoxFish, chckBoxFish.Text);
        }
        #endregion
    }
}
