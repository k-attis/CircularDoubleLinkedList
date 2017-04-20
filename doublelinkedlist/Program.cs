using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doublelinkedlist
{
    class Program
    {
        static void kiir(CircularDoubleLinkedList<Teszt> cdll)
        {
            for (int i = 0; i < cdll.Count; i++)
                Console.WriteLine(cdll[i].toString());
            Console.WriteLine("-----------------------------");
        }

        static void Main(string[] args)
        {
            CircularDoubleLinkedList<Teszt> cdll =
                new CircularDoubleLinkedList<Teszt>();

            cdll.Add(new Teszt()
            {
                text = "0"
            });
            kiir(cdll);

            cdll.Add(new Teszt()
            {
                text = "1"
            });
            kiir(cdll);

            cdll.Insert(1, new Teszt()
            {
                text = "01"
            });

            kiir(cdll);

            try
            {
                cdll.Delete(3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            kiir(cdll);

            cdll.Delete(1);
            kiir(cdll);

            Console.ReadLine();
        }
    }
}
