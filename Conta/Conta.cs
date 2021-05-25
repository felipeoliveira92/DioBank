using System;

namespace DioBank
{
    public class Conta
    {
        private TipoConta tipoConta { get; set;}
        private double Saldo { get; set;}
        private double Credito { get; set;}
        private string Nome { get; set;}

        public Conta(TipoConta tipoConta, double Saldo, double Credito, string Nome)
        {
            this.tipoConta = tipoConta;
            this.Saldo = Saldo;
            this.Credito = Credito;
            this.Nome = Nome;
        }
        public bool Sacar(double valorSaque)
        {
            if(this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine($"O saldo da conta de {this.Nome} é {this.Saldo}");

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine($"O saldo da conta de {this.Nome} é {this.Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno+= $"tipoConta {this.tipoConta} | ";
            retorno+= $"Nome {this.Nome} | ";
            retorno+= $"Saldo {this.Saldo} | ";
            retorno+= $"Credito {this.Credito} | ";
            return retorno;
        }
    }
}