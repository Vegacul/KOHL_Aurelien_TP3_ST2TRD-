using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KOHL_Aurelien_TP3_ST2TRD
{
    class ThreadExo2
    {
        

        private static Mutex mut = new Mutex();

        public static void exo2()
        {
            // Déclaration du thread
            Thread myThread1;
            Thread myThread2;
            Thread myThread3;


            myThread1 = new Thread((o => GLobalThread(10, 50, ' ')));
            myThread2 = new Thread((w => GLobalThread(11, 40, '*')));
            myThread3 = new Thread((y => GLobalThread(9, 20, '°')));


            // Lancement du thread
            

            myThread1.Start();
            myThread2.Start();
            myThread3.Start();

            myThread1.Join();
            myThread2.Join();
            myThread3.Join();


        }

        public static void GLobalThread(int duree, int freq, char caractere)
        {
            DateTime date2 = DateTime.Now.AddSeconds(duree);


            while (DateTime.Now <= date2)
            {
                mut.WaitOne();
                Console.Write(caractere);

                mut.ReleaseMutex();
                Thread.Sleep(freq);

            }
            //Console.Write("fin");
        }


    }
}
