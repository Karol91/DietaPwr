using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DietaPwr
{
    public partial class PanelDodawania : Form
    {
        public PanelDodawania()
        {
            InitializeComponent();
        }

        private PanelGlowny panelGlowny = null;
        public PanelDodawania (Form callingForm)
        {
            panelGlowny = callingForm as PanelGlowny;
            InitializeComponent();
        }

        List<Produkty> listaProduktow = null;

        public List<Produkty> _listaProduktow
        {
            set { listaProduktow = value; }
            get { return listaProduktow; }
        }


        private void PanelDodawania_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(ListaTypow.TypProduktu)))
            {
                cbTypy.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(tbFoodName.Text) && (cbTypy.SelectedIndex > -1))
            {
                Produkty produkt = new Produkty();
                PanelDodawania panelDodawania = new PanelDodawania();
                produkt.Type = cbTypy.GetItemText(cbTypy.SelectedItem);
                produkt.FoodName = tbFoodName.Text;
                produkt.Calories = nUDCalories.Value.ToString();
                produkt.Protein = numProtein.Value.ToString();
                produkt.Fat = numFat.Value.ToString();
                produkt.Carbohydrates = numCarbo.Value.ToString();
                produkt.Calcium = numCalc.Value.ToString();
                produkt.Iron = numIron.Value.ToString();
                produkt.Sodium = numSodium.Value.ToString();
                produkt.VitaminA = numVitA.Value.ToString();
                produkt.Thiamin = numThiamin.Value.ToString();
                produkt.VitaminC = numVitC.Value.ToString();

                listaProduktow.Add(produkt);
                this.panelGlowny._listaProduktow = listaProduktow;
                this.panelGlowny.BindAndRowNumber();
                this.Close();
            }
            else
                MessageBox.Show("Enter food name and set type of food", "Warning");

        }
    }
}
