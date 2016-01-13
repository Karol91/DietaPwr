using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic.FileIO;
using lpsolve55;
using System.Globalization;
namespace DietaPwr
{
    
    public partial class PanelGlowny : Form
    {
        NumberFormatInfo provider = new NumberFormatInfo();
        bool ograniczBialko = false;
        bool ograniczTluszcze = false;
        bool ograniczWeglowodany = false;
        bool ograniczWapn = false;
        bool ograniczZelazo = false;
        bool ograniczSod = false;
        bool ograniczWita = false;
        bool ograniczTiamine = false;
        bool ograniczWitc = false;
        int lp;
        int lkolumn; //liczba kolumn dla lp
        int lwierszy=1; //liczba wierszy dla lp
        double[] row;
        double[] variables;
        string wyniki;
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
                lwierszy--;
            }
            else
            {
                ograniczBialko = true;
                bialkoOd.ReadOnly = false;
                bialkoDo.ReadOnly = false;
                lwierszy++; ;
            }

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczSod)
            {
                ograniczSod = false;
                sodOd.ReadOnly = true;
                sodDo.ReadOnly = true;
                lwierszy--;
            }
            else
            {
                ograniczSod = true;
                sodOd.ReadOnly = false;
                sodDo.ReadOnly = false;
                lwierszy++;
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
                lwierszy--;
            }
            else
            {
                ograniczTluszcze = true;
                tluszczeOd.ReadOnly = false;
                tluszczeDo.ReadOnly = false;
                lwierszy++;
            }
        }

        private void weglowodanyBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczWeglowodany)
            {
                ograniczWeglowodany = false;
                weglowodanyOd.ReadOnly = true;
                weglowodanyDo.ReadOnly = true;
                lwierszy--;
            }
            else
            {
                ograniczWeglowodany = true;
                weglowodanyOd.ReadOnly = false;
                weglowodanyDo.ReadOnly = false;
                lwierszy++;
            }
        }

        private void wapnBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczWapn)
            {
                ograniczWapn = false;
                wapnOd.ReadOnly = true;
                wapnDo.ReadOnly = true;
                lwierszy--;
            }
            else
            {
                ograniczWapn = true;
                wapnOd.ReadOnly = false;
                wapnDo.ReadOnly = false;
                lwierszy++;
            }
        }

        private void zelazoBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczZelazo)
            {
                ograniczZelazo = false;
                zelazoOd.ReadOnly = true;
                zelazoDo.ReadOnly = true;
                lwierszy--;
            }
            else
            {
                ograniczZelazo = true;
                zelazoOd.ReadOnly = false;
                zelazoDo.ReadOnly = false;
                lwierszy++;
            }
        }

        private void witaBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczWita)
            {
                ograniczWita = false;
                witaOd.ReadOnly = true;
                witaDo.ReadOnly = true;
                lwierszy--;
            }
            else
            {
                ograniczWita = true;
                witaOd.ReadOnly = false;
                witaDo.ReadOnly = false;
                lwierszy++;
            }
        }

        private void tiaminaBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczTiamine)
            {
                ograniczZelazo = false;
                tiaminaOd.ReadOnly = true;
                tiaminaDo.ReadOnly = true;
                lwierszy--;
            }
            else
            {
                ograniczTiamine = true;
                tiaminaOd.ReadOnly = false;
                tiaminaDo.ReadOnly = false;
                lwierszy++;
            }
        }

        private void witcBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ograniczWitc)
            {
                ograniczWitc = false;
                witcOd.ReadOnly = true;
                witcDo.ReadOnly = true;
                lwierszy--;
            }
            else
            {
                ograniczWitc = true;
                witcOd.ReadOnly = false;
                witcDo.ReadOnly = false;
                lwierszy++;
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

        private void button2_Click(object sender, EventArgs e)
        {
            lkolumn = listaProduktowFiltr.Count();
            lp = lpsolve.make_lp(lwierszy, lkolumn);
            row = new double[lkolumn];
            provider.NumberDecimalSeparator = ".";  
            //ustawianie nazw kolumn
            for (int i = 0; i < lkolumn; i++)
            {
                lpsolve.set_col_name(lp, i, listaProduktowFiltr[i].FoodName);
               
            }
            //stworzenie funkcji celu
            row = new double[lkolumn];
            for (int i = 0; i < lkolumn; i++)
                row[i] = Convert.ToDouble(listaProduktowFiltr[i].Calories, provider);
                lpsolve.set_obj_fn(lp, row);
                lpsolve.set_minim(lp);
                
#region dodawanie ograniczeń
            if (ograniczBialko)
            {
                for (int i = 0; i < lkolumn; i++)
                    row[i] = Convert.ToDouble(listaProduktowFiltr[i].Protein, provider);
                if(bialkoOd.Text!="")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.GE, Convert.ToDouble(bialkoOd.Text,provider));
                if(bialkoDo.Text!="")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.LE, Convert.ToDouble(bialkoDo.Text, provider));
            }
            if (ograniczTluszcze)
            {
                for (int i = 0; i < lkolumn; i++)
                    row[i] = Convert.ToDouble(listaProduktowFiltr[i].Fat, provider);
                if (tluszczeOd.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.GE, Convert.ToDouble(tluszczeOd.Text, provider));
                if (tluszczeDo.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.LE, Convert.ToDouble(tluszczeDo.Text, provider));
            }
            if (ograniczWeglowodany)
            {
                for (int i = 0; i < lkolumn; i++)
                    row[i] = Convert.ToDouble(listaProduktowFiltr[i].Carbohydrates, provider);
                if (weglowodanyOd.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.GE, Convert.ToDouble(weglowodanyOd.Text, provider));
                if (weglowodanyDo.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.LE, Convert.ToDouble(weglowodanyDo.Text, provider));
            }
            if (ograniczWapn)
            {
                for (int i = 0; i < lkolumn; i++)
                    row[i] = Convert.ToDouble(listaProduktowFiltr[i].Calcium, provider);
                if (wapnOd.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.GE, Convert.ToDouble(wapnOd.Text, provider));
                if (wapnDo.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.LE, Convert.ToDouble(wapnDo.Text, provider));
            }
            if (ograniczZelazo)
            {
                for (int i = 0; i < lkolumn; i++)
                    row[i] = Convert.ToDouble(listaProduktowFiltr[i].Iron, provider);
                if (zelazoOd.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.GE, Convert.ToDouble(zelazoOd.Text, provider));
                if (zelazoOd.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.LE, Convert.ToDouble(zelazoDo.Text, provider));
            }
            if (ograniczSod)
            {
                for (int i = 0; i < lkolumn; i++)
                    row[i] = Convert.ToDouble(listaProduktowFiltr[i].Sodium, provider);
                if (sodOd.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.GE, Convert.ToDouble(sodOd.Text, provider));
                if (sodDo.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.LE, Convert.ToDouble(sodDo.Text, provider));
            }
            if (ograniczWita)
            {
                for (int i = 0; i < lkolumn; i++)
                    row[i] = Convert.ToDouble(listaProduktowFiltr[i].VitaminA, provider);
                if (witaOd.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.GE, Convert.ToDouble(witaOd.Text, provider));
                if (witaDo.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.LE, Convert.ToDouble(witaDo.Text, provider));
            }
            if (ograniczTiamine)
            {
                for (int i = 0; i < lkolumn; i++)
                    row[i] = Convert.ToDouble(listaProduktowFiltr[i].Thiamin, provider);
                if (tiaminaOd.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.GE, Convert.ToDouble(tiaminaOd.Text, provider));
                if (tiaminaDo.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.LE, Convert.ToDouble(tiaminaDo.Text, provider));
            }
            if (ograniczWitc)
            {
                for (int i = 0; i < lkolumn; i++)
                    row[i] = Convert.ToDouble(listaProduktowFiltr[i].VitaminC, provider);
                if (witcOd.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.GE, Convert.ToDouble(witcOd.Text, provider));
                if (witcDo.Text != "")
                    lpsolve.add_constraint(lp, row, lpsolve.lpsolve_constr_types.LE, Convert.ToDouble(witcDo.Text, provider));
            }
           
#endregion
            //rozwiązanie
            variables = new double[lkolumn];
            lpsolve.solve(lp);
            lpsolve.get_variables(lp, variables);
            wyniki = "";
            for (int i = 0; i < lkolumn; i++)
            {
                if(variables[i]!=0)
                    wyniki += "\n" + listaProduktowFiltr[i].FoodName + ": " + variables[i].ToString();

            }
            richTextBox1.Clear();
            richTextBox1.Text = wyniki;
            lpsolve.print_objective(lp);
            lpsolve.print_solution(lp, 10);
           

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
