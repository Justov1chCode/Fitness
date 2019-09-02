using System;


namespace Fitness.BL.Model
{
    [Serializable]
    public class User
    {
        public string Name { get; }
        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public int Age { get { return DateTime.Now.Year - this.BirthDate.Year; } }

        public User(String name,
                    Gender gender, 
                    DateTime birthdate, 
                    double weight,
                    double height )
        {
            #region Проверка аргументов
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или пробелом. ", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть не выбран.", nameof(gender));
            }

            if(birthdate <= DateTime.Parse("01.01.1900") || birthdate >= DateTime.Now)
            {
                throw new ArgumentException("Введите возрат конкретно.", nameof(birthdate));
            }

            if (weight < 0)
            {
                throw new ArgumentException("Вес не может быть меньше нуля.", nameof(weight));
            }

            if(height < 0)
            {
                throw new ArgumentException("Рост не может быть меньше нуля.", nameof(height));
            }
            #endregion

            this.Name = name;
            this.Gender = gender;
            this.BirthDate = birthdate;
            this.Weight = weight;
            this.Height = Height;
        }

        public User(String name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или пробелом. ", nameof(name));
            }
            this.Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }

    }
}
