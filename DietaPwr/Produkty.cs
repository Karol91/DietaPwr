using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DietaPwr
{
    public sealed class Produkty : CsvClassMap<Produkty>
    {
        
        private string type;
        private string foodName;
        private string calories;
        private string protein;
        private string fat;
        private string carbohydrates;
        private string calcium;
        private string iron;
        private string sodium;
        private string vitaminA;
        private string vitaminC;
        private string thiamin;




        public string Type
        {
            get { return type; }
            set { type = value; }
        }


        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; }
        }

        public string Calories
        {
            get { return calories; }
            set { calories = value; }
        }

        public string Protein
        {
            get { return protein; }
            set { protein = value; }
        }

        public string Fat
        {
            get { return fat; }
            set { fat = value; }
        }

        public string Carbohydrates
        {
            get { return carbohydrates; }
            set { carbohydrates = value; }
        }

        public string Calcium
        {
            get { return calcium; }
            set { calcium = value; }
        }

        public string Iron
        {
            get { return iron; }
            set { iron = value; }
        }

        public string Sodium
        {
            get { return sodium; }
            set { sodium = value; }
        }

        public string VitaminA
        {
            get { return vitaminA; }
            set { vitaminA = value; }
        }

        public string Thiamin
        {
            get { return thiamin; }
            set { thiamin = value; }
        }

        public string VitaminC
        {
            get { return vitaminC; }
            set { vitaminC = value; }
        }

        public Produkty()
        {
            //Map(m => m.Type).Name("Type");
            //Map(m => m.FoodName).TypeConverter<LeadingSpaceTypeConverter>().Index(1);
            //Map(m => m.Calories).Name("Calories");
            //Map(m => m.Protein).Name("Protein");
            //Map(m => m.Fat).Name("Fat");
            //Map(m => m.Carbohydrates).Name("Carbohydrates");
            //Map(m => m.Calcium).Name("Calcium");
            //Map(m => m.Iron).Name("Iron");
            //Map(m => m.Sodium).Name("Sodium");
            //Map(m => m.VitaminA).Name("Vitamin A");
            //Map(m => m.Thiamin).Name("Thiamin");
            //Map(m => m.VitaminC).Name("Vitamin C");
        }

        public class LeadingSpaceTypeConverter : DefaultTypeConverter
        {

            public override string ConvertToString(TypeConverterOptions options, object value)
            {
                if (value == null)
                {
                    return String.Empty;
                }

                return String.Concat(" ", value.ToString());
            }
        }
    }
}
