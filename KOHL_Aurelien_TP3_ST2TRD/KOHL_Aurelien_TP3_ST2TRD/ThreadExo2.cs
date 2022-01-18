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


            // Instanciation du thread, on spécifie dans le 
            // délégué ThreadStart le nom de la méthode qui
            // sera exécutée lorsque l'on appelle la méthode
            // Start() de notre thread.

            myThread1 = new Thread((o => GLobalThread(10000, 50, ' ')));
            myThread2 = new Thread((w => GLobalThread(11000, 40, '*')));
            myThread3 = new Thread((y => GLobalThread(9000, 20, '°')));


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

            for (int i = 0; i < (duree / freq); i++)
            {
                mut.WaitOne();
                Console.Write(caractere);
                mut.ReleaseMutex();
                Thread.Sleep(freq);
            }

        }


    }
}
