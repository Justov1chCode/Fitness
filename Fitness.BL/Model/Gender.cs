using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    [Serializable]
    public class Gender
    {
        public string Name { get; set; }

        public Gender(String name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя(Gender) не может быть пустым или пробелом", nameof(name));
            }

            this.Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
