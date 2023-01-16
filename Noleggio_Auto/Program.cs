using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio_Auto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variabili di prova
            string marca = "audi";
            string modello = "r8";
            string conducente = "andrea crotti";
            int km_percorsi = 200;
            int benzina = 50;
            double costo_kasko = 5000;
            double costo_noleggio = 50;

            Veicolo vc = new Veicolo(marca, modello, conducente, km_percorsi, benzina, costo_kasko, costo_noleggio, true);

            //main
            Veicolo[] lista = new Veicolo[100];
            int contatore = 0;
            Veicolo temp = new Veicolo();

            int scelta = 1;
            do
            {


                Console.WriteLine("1-Aggiungi veicolo");
                Console.WriteLine("2-Modifica veicolo esistente");
                Console.WriteLine("3-Elimina veicolo esistente");
                Console.WriteLine("4-Noleggia");
                Console.WriteLine("5-Restituisci");
                Console.WriteLine("6-Calcola prezzo");
                Console.WriteLine("7-Confronta prezzo di 2 veicoli a noleggio");
                Console.WriteLine("0-Esci");
                try
                {
                    scelta = int.Parse(Console.ReadLine());
                }
                catch { Exception e; scelta = -1; }

                switch (scelta)
                {
                    case 0:
                        break;
                    case 1:
                        Console.Write("Inserisci marca: ");
                        temp.Marca = Console.ReadLine();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;

                    default:
                        Console.WriteLine("Opzione invalida"); break;
                }

                Console.ReadKey();
                Console.Clear();

            } while (scelta != 0);
        }


        //funzioni



    }
}

