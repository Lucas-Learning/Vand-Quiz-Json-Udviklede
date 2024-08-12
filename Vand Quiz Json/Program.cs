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
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int inputMenu;
                Console.WriteLine("Valg en test som du gerne vil lave");
                Console.WriteLine("1. Vand quiz");
                Console.WriteLine("2. Programmerings quiz");
                Console.WriteLine("3. SQL quiz");
                inputMenu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (inputMenu)
                {
                    case 1:
                        VandQuiz vq = new VandQuiz();
                        vq.VandQuizzen();
                        break;
                    case 2:
                        ProgQuiz pq = new ProgQuiz();
                        pq.ProgQuizzen();
                        break;
                    case 3:
                        SqlQuiz sq = new SqlQuiz();
                        sq.SqlQuizzen();
                        break;
                    case 4:
                        Console.WriteLine("Exit");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
    
