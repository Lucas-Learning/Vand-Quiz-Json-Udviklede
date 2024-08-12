using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace Vand_Quiz_Json
{
    public class VandQuiz
    {
        static List<Quizzen> Convert_json_to_cs()
        {
            string fileName = @"C:\Users\lp\Downloads\Vand-Quiz-Json-master\Vand-Quiz-Json-master\Vand Quiz Json\Spørgsmål.json";
            if (File.Exists(fileName))
            {
                string Text = File.ReadAllText(fileName);
                List<Quizzen> q = JsonConvert.DeserializeObject<List<Quizzen>>(Text);
                return q;
            }
            return (null);
        }
        public void VandQuizzen()
        {
            List<Quizzen> quizlist = Convert_json_to_cs();
            if (quizlist == null)
            {
                Console.WriteLine("Error");
                return;
            }
            QuizManager qm = new QuizManager();
            foreach (var deserialized in quizlist)
            {
                int svarInt;

                bool isValid = false;
                while (!isValid)
                {
                    int i = 1;
                    Console.WriteLine(deserialized.Spørgsmål);
                    Console.WriteLine("Skriv tallet for det svar du gerne vil vælge:");
                    Console.WriteLine("\nSvarMuligheder:\n");
                    foreach (var options in deserialized.Options)
                    {
                        Console.WriteLine(i + ". " + options);
                        i++;
                    }
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out svarInt))
                    {
                        isValid = qm.Check(deserialized, svarInt);
                    }
                    else
                    {
                        Console.WriteLine("Ugyldigt input");
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            Console.WriteLine($"Du er færdig med Quizzen og du fik {qm.result} points ud af 6");
            Console.WriteLine("Tryk på enter for at gå tilbage til menuen");
            Console.ReadKey();
        }
    }
}
