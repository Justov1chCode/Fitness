using System;


namespace Fitness.BL.Model
{
    public class User
    {
        public string Name { get; }

        public Gender Gender { get; }

        public DateTime BirthDate { get; }

        public double Weight { get; set; }

        public double Height { get; set; }


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

        public override string ToString()
        {
            return Name;
        }

    }
}
