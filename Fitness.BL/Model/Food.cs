using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }

        public double Proteins { get; set; }

        public double Fats { get; set; }
        public double Carbohydates { get; }
        public double Carbohydrates { get; set; }

        public double Callories { get; }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(
            string name,
            double Proteins,
            double Fats,
            double Carbohydates,
            double Callories)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("message", nameof(name));
            }

            this.Name = name;
            this.Proteins = Proteins / 100.0;
            this.Fats = Fats / 100.0;
            this.Carbohydates = Carbohydates / 100.0;
            this.Callories = Callories / 100.0;

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
