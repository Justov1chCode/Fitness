using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CurrentCulture;
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("welcome_msg", culture));

            Console.WriteLine(resourceManager.GetString("entername_msg", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine(Languages.Messages.choosegender_msg);
                var gender = Console.ReadLine();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");
                DateTime birthDate = ParseDateTime();

                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine(Languages.Messages.choosemove_msg);
            Console.WriteLine(Languages.Messages.eismakechoose_msg);
            var key = Console.ReadKey(true);

            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }
            

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine(Languages.Messages.name_msg);
            var food = Console.ReadLine();
            var callories = ParseDouble(Languages.Messages.calories_msg);
            var fats = ParseDouble(Languages.Messages.fats_msg);
            var prots = ParseDouble(Languages.Messages.prots_msg);
            var carbs = ParseDouble(Languages.Messages.carbs_msg);
            var weight = ParseDouble(Languages.Messages.weight_msg);
            var product = new Food(food, prots, fats, carbs, callories);
            return (product, weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine(Languages.Messages.datechoose_msg);
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(Languages.Messages.repeatinsert_msg);

                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Повторите ввод");

                }
            }
        }
    }
}
