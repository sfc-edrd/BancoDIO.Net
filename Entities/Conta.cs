namespace DIOBANCO.Entities
{
    public class Conta
    {
        private string Nome {get; set;}
        private TipoConta TipoConta {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        
        public Conta(string Nome, TipoConta tipoConta, double Saldo, double Credito)
        {
            this.Nome = Nome;
            this.TipoConta = tipoConta;
            this.Saldo = Saldo;
            this.Credito = Credito;

        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito *-1)) 
            {
                System.Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            
            this.Saldo -= valorSaque;
            System.Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
            
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            System.Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}.");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito;
            return retorno;
        }

    }
}