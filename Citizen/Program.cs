using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citizen
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();

            Worker worker = new Worker(23344, 44);
            Student student = new Student(456387, 20);
            Retiree retiree = new Retiree(13344, 65);
            Retiree retiree2 = new Retiree(034566, 90);
            Student student2 = new Student(543566, 23);
            Worker worker2 = new Worker(23344, 55);
            //Console.WriteLine(worker);
            
            queue.Add(worker);
            queue.Add(student);
            queue.Add(retiree);
            queue.Add(retiree2);
            queue.Add(student2);


            foreach (Citizen item in queue)
            {
                Console.WriteLine("Age - {0}, Passport - {1}", item.Age, item.Passport);
            }
            Console.WriteLine();
            queue.Add(worker2);
            foreach (Citizen item in queue)
            {
                Console.WriteLine("Age - {0}, Passport - {1}", item.Age, item.Passport);
            }




            Console.ReadKey();
        }
    }
}
