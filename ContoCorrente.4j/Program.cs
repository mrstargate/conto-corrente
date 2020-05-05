using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContoCorrente._4j
{
    class Program
    {
        static void Main(string[] args)
        {
            Banca Generali = new Banca("Generali", "via Mameli 12");
            Persona Paolo=new Persona("Paolo", "Rossi", "via Garibaldi 23", "3245698450", "paolorossi@gmail.com", new DateTime (1978,05,13, 12, 45, 00));
            Persona Luca = new Persona("Luca", "Bianchi", "via Mazzini 24", "3390890678", "lucabianchi@gmail.com", new DateTime(1980,08,10,04,05,20));
            Persona Ciccio = new Persona("Ciccio", "Caputo", "Via col vento", "3273936249", "cicciocaputo@gmail.com", new DateTime(2001,03,09,09,03,01));
            ContoCorrente ContoPaolo=new ContoCorrente(Paolo,0,50,200000.00,"IT88A030901651000050570131");
            ContoCorrente ContoCiccio = new ContoCorrente(Ciccio, 0, 50, 300000, "IT88A030901651000050570132");          
            Generali.listaconti.Add(ContoPaolo);
            Conto_Online ContoLucaOnline = new Conto_Online(1000.00, Luca, 0, 50, 10000, "IT88A030901651000050570130", "CiccioCaputo", "Ciccio123");
            Generali.listaconti.Add(ContoLucaOnline);
            Console.WriteLine("Persone: \n--" + Paolo.Nome + " " + Paolo.Cognome + "\t Indirizzo: " + Paolo.Indirizzo + "\t Numero di telefono: " + Paolo.NumeroTel + "\t E-Mail: " + Paolo.EMail + "\t Data di nascita: " + Paolo.DataNascita);
            Console.WriteLine("--"+Luca.Nome + " " + Luca.Cognome + "\t Indirizzo: " + Luca.Indirizzo + "\t Numero di telefono: " + Luca.NumeroTel + "\t E-Mail: " + Luca.EMail + "\t Data di nascita: " + Luca.DataNascita);
            Console.WriteLine("--" + Ciccio.Nome + " " + Ciccio.Cognome + "\t Indirizzo: " + Ciccio.Indirizzo + "\t Numero di telefono: " + Ciccio.NumeroTel + "\t E-Mail: " + Ciccio.EMail + "\t Data di nascita: " + Ciccio.DataNascita);
            Console.WriteLine("\nBanca:\n--" + Generali.Nome + "\t" + Generali.Indirizzo);
            Console.WriteLine("\nConti correnti:\n--" + ContoPaolo.IntestatarioConto.Nome + " " + ContoPaolo.IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + ContoPaolo.MaxMovimenti + "\t Numero movimenti effettuati: " + ContoPaolo.NMovimenti + "\t IBAN: " + ContoPaolo.Iban+"\t Saldo: "+ContoPaolo.Saldo);
            Console.WriteLine("--" + ContoCiccio.IntestatarioConto.Nome + " " + ContoCiccio.IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + ContoCiccio.MaxMovimenti + "\t Numero movimenti effettuati: " + ContoCiccio.NMovimenti + "\t IBAN: " + ContoCiccio.Iban + "\t Saldo: " + ContoCiccio.Saldo);
            Console.WriteLine("\nConti correnti online:\n--" + ContoLucaOnline.IntestatarioConto.Nome + " " + ContoLucaOnline.IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + ContoLucaOnline.MaxMovimenti + "\t Numero movimenti effettuati: " + ContoLucaOnline.NMovimenti + "\t IBAN: " + ContoLucaOnline.Iban +"\t Saldo: " + ContoLucaOnline.Saldo);
            Console.WriteLine("\nLista di concorrenti della banca Generali: ");           
            for (int i = 0; i < Generali.listaconti.Count; i++)
            {
                Console.WriteLine("--" + Generali.listaconti[i].IntestatarioConto.Nome + " " + Generali.listaconti[i].IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + Generali.listaconti[i].MaxMovimenti + "\t Numero movimenti effettuati: " + Generali.listaconti[i].NMovimenti+ "\t IBAN: " + Generali.listaconti[i].Iban + "\t Saldo: " + Generali.listaconti[i].Saldo);
            }
            Bonifico bonifico = new Bonifico(ContoCiccio, new DateTime(2020 / 05 / 22), 200, ContoPaolo);
            bonifico.CreaBonifico(ContoCiccio, new DateTime(2020 / 05 / 22), 200, ContoPaolo);
            Console.WriteLine("\n\n\nMovimenti: \n");
            Console.WriteLine("\nSi effettua un bonifico da 200 euro dal conto di Paolo Rossi al conto di Ciccio Caputo, i nuovi dati dei conti saranno:");
            Console.WriteLine("--" + ContoPaolo.IntestatarioConto.Nome + " " + ContoPaolo.IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + ContoPaolo.MaxMovimenti + "\t Numero movimenti effettuati: " + ContoPaolo.NMovimenti + "\t IBAN: " + ContoPaolo.Iban + "\t Saldo: " + ContoPaolo.Saldo);
            Console.WriteLine("--" + ContoCiccio.IntestatarioConto.Nome + " " + ContoCiccio.IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + ContoCiccio.MaxMovimenti + "\t Numero movimenti effettuati: " + ContoCiccio.NMovimenti + "\t IBAN: " + ContoCiccio.Iban + "\t Saldo: " + ContoCiccio.Saldo);
            Versamento versamento = new Versamento(new DateTime(2020, 05, 22, 22, 05, 20), 40, ContoLucaOnline);
            versamento.CreaVersamento();
            Console.WriteLine("\nLuca effettura un versamento da 40 euro sul proprio conto online, i nuovi dati del suo conto saranno:");
            Console.WriteLine("--" + ContoLucaOnline.IntestatarioConto.Nome + " " + ContoLucaOnline.IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + ContoLucaOnline.MaxMovimenti + "\t Numero movimenti effettuati: " + ContoLucaOnline.NMovimenti + "\t IBAN: " + ContoLucaOnline.Iban + "\t Saldo: " + ContoLucaOnline.Saldo);
            Prelievo prelievo = new Prelievo(new DateTime(2020, 05, 22, 22, 05, 20), 200, ContoCiccio);
            prelievo.CreaPrelievo();
            Console.WriteLine("\nCicco Caputo preleva i soldi ricevuti dal bonifico effettuato da Paolo, i dati del suo conto saranno aggiornati a:");
            Console.WriteLine("--" + ContoCiccio.IntestatarioConto.Nome + " " + ContoCiccio.IntestatarioConto.Cognome + "\t Numero movimenti gratuiti: " + ContoCiccio.MaxMovimenti + "\t Numero movimenti effettuati: " + ContoCiccio.NMovimenti + "\t IBAN: " + ContoCiccio.Iban + "\t Saldo: " + ContoCiccio.Saldo);
            Console.ReadLine();
        }
    }
}
