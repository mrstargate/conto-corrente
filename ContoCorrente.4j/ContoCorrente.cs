using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContoCorrente._4j
{
    class ContoCorrente
    {
        public Persona IntestatarioConto { get; set; }
        public int NMovimenti { get; set; }
        public int MaxMovimenti { get; set; }
        public double Saldo { get; set; }
        public string Iban { get; set; }
        List<Movimento> listamovienti;

        public ContoCorrente(Persona IntestatarioConto, int NMovimenti, int MaxMovimenti, double Saldo, string Iban)
        {
            this.IntestatarioConto = IntestatarioConto;
            this.NMovimenti = NMovimenti;
            this.MaxMovimenti = MaxMovimenti;
            this.Saldo = Saldo;
            this.Iban = Iban;
            this.listamovienti = new List<Movimento>();
        }

        public bool Preleva( double x)
        {
            if (NMovimenti<MaxMovimenti)
            {
                Saldo = Saldo - x;
            }
            else
            {
                Saldo = Saldo - (x + 0.5);
            }
            NMovimenti++;
            return true;
        }

        public void RestituisciSaldo(double Saldo)
        {
            Console.Write("Saldo: " + Saldo);
        }
    }
    class Movimento
    {
        protected DateTime DataMovimento;
        protected double importo;
        protected ContoCorrente conto;

        public Movimento(DateTime DataMovimento, double importo, ContoCorrente conto)
        {
            this.importo = importo;
            this.DataMovimento = DataMovimento;
            this.conto = conto;
        }
    }
    class Banca
    {
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public List<ContoCorrente> listaconti { get; set; }

        public Banca(string Nome, string Indirizzo)
        {
            this.Nome = Nome;
            this.Indirizzo = Indirizzo;
            this.listaconti = new List<ContoCorrente>();
        }
    }
    class Persona
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string NumeroTel { get; set; }
        public string EMail {get;set;}
        public DateTime DataNascita { get; set; }

        public Persona(string Nome, string Cognome, string Indirizzo, string NumeroTel, string EMail, DateTime DataNascita)
        {
            this.Nome = Nome;
            this.Cognome = Cognome;
            this.Indirizzo = Indirizzo;
            this.NumeroTel = NumeroTel;
            this.EMail = EMail;
            this.DataNascita = DataNascita;
        }
    }
    class Conto_Online:ContoCorrente
    {
        public double MaxPrelievo { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Conto_Online(double MaxPrelievo, Persona IntestatarioConto, int NMovimenti, int MaxMovimenti, double Saldo, string Iban, string Username, string Password) :base(IntestatarioConto, NMovimenti, MaxMovimenti, Saldo, Iban)
        {
            this.MaxPrelievo = MaxPrelievo;
            this.Username = Username;
            this.Password = Password;
        }

        public void StampaSaldo(double Saldo, Persona IntetstarioConto)
        {
            Console.Write("Intestatario: "+IntestatarioConto.Nome+" "+IntestatarioConto.Cognome +"\t Saldo: "+ Saldo);
        }
        public void PrelevaOnline(double Saldo, double x)
        {
            if (x<MaxPrelievo)
            {
                Preleva(x);
            }
            else
            {
                Console.WriteLine("L'importo inserito è maggiore di quello massimo.");
            }
        }
    }
    class Bonifico : Movimento
    {
        public ContoCorrente Destinatario { get; set; }

        public Bonifico(ContoCorrente Destinatario, DateTime DataMovimento, double importo, ContoCorrente conto) :base(DataMovimento, importo, conto)
        {
            this.Destinatario = Destinatario;
        }
        public void CreaBonifico(ContoCorrente Destinatario, DateTime DataMovimento, double importo, ContoCorrente conto)
        {
            conto.Saldo = conto.Saldo - importo;
            Destinatario.Saldo = Destinatario.Saldo + importo;
            conto.NMovimenti++;
        }
    }
    class Versamento : Movimento
    {
        public Versamento(DateTime DataMovimento, double importo, ContoCorrente conto) :base(DataMovimento, importo, conto)
        {
            
        }
        public void CreaVersamento()
        {
            conto.Saldo = conto.Saldo + importo;
            conto.NMovimenti++;
        }
    }
    class Prelievo : Movimento
    {
        public Prelievo(DateTime DataMovimento, double importo, ContoCorrente conto) :base(DataMovimento, importo, conto)
        {

        }
        public void CreaPrelievo()
        {
            conto.Saldo = conto.Saldo - importo;
            conto.NMovimenti++;
        }
    }
}