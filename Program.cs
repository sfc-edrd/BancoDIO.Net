using System;
using DIOBANCO.Entities;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace DIOBANCO
{
    class Program
    {
        static List<Conta> Contas = new List<Conta>();       
        static void Main(string[] args)
        {
            
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while( opcaoUsuario.ToUpper() != "X"  )
            {
                switch (opcaoUsuario.ToUpper())
                {
                    case "1":
                        ListarContas();
                        break;
                    
                    case "2": 
                        InserirConta();
                        break;

                    case "3": 
                        Transferir();
                        break;
                    
                    case "4":
                        Sacar();
                        break;

                    case "5":
                        Depositar();
                        break;

                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();    
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }      
            System.Console.WriteLine("Obrigado por usar nossos serviços.");
        }
        
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            System.Console.WriteLine("DIOBank");
            System.Console.WriteLine("Informe a opção desejada:");
            System.Console.WriteLine("1 - Listar contas");
            System.Console.WriteLine("2 - Inserir nova conta");
            System.Console.WriteLine("3 - Transferir");
            System.Console.WriteLine("4 - Sacar");
            System.Console.WriteLine("5 - Depositar");
            System.Console.WriteLine("C - Limpar Tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine("------------------");
            System.Console.Write("Opção: ");
            
            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }

        private static void ListarContas()
        {
            if (Contas.Count != 0) 
            {
                for (var i = 0; i < Contas.Count; i++)
                {                
                    Console.WriteLine($"#{i} -> {Contas[i].ToString()}");
                }
                return;
                 
            }
            Console.WriteLine("Nenhuma Conta criada ainda.");
            
        }


        private static void InserirConta()
        {
            TipoConta tipoConta = (TipoConta)1;
            Console.Write("Nome: ");
            string Nome = Console.ReadLine();            

            Console.Write("Tipo de conta [Fisica (1) / Juridica (2)]: ");
            string selecao = Console.ReadLine();

            while(!String.IsNullOrEmpty(selecao)) {
                switch (selecao)
                {
                    case "1":
                        selecao = null;
                        break;
                    case "2":
                        tipoConta = (TipoConta)2;
                        selecao = null;
                        break;

                    default:
                        Console.WriteLine("Opção invalida. Entre com 1 para PF e 2 para PJ.");
                        break;

                }
            

            }

                   

            Console.Write("Saldo Inicial: ");
            double Saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);            

            Console.Write("Credito: ");
            double Credito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);            

            Conta novaConta = new Conta(Nome: Nome,
                                        tipoConta: TipoConta.PessoaFisica, 
                                        Saldo: Saldo, 
                                        Credito: Credito);
            Contas.Add(novaConta);
            
        }

        private static void Transferir()
        {
            ListarContas();

            Console.Write("Numero da conta de origem: ");
            int NumContaOrigem = int.Parse(Console.ReadLine());
            
            Console.Write("Numero da conta de destino: ");
            int NumContaDestino = int.Parse(Console.ReadLine());
            
            Console.Write("Valor da transferencia: R$ ");
            double ValorTransferencia = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            Contas[NumContaOrigem].Transferir(ValorTransferencia, Contas[NumContaDestino]);
            
        }

        private static void Sacar()
        {
            ListarContas();

            Console.Write("Numero da conta: ");
            int NumContaOrigem = int.Parse(Console.ReadLine());
                        
            Console.Write("Valor do Saque: R$ ");
            double ValorSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            if (Contas[NumContaOrigem].Sacar(ValorSaque))  Console.WriteLine("Saque Efetuado.");

        }
        private static void Depositar()
        {
            ListarContas();

            Console.Write("Numero da conta para deposito: ");
            int NumContaDeposito = int.Parse(Console.ReadLine());
                        
            Console.Write("Valor do Deposito: R$ ");
            double ValorDeposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Contas[NumContaDeposito].Depositar(ValorDeposito);
            
        }

    }
}
