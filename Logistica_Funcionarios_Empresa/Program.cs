using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica_Empresa
{

    abstract class Empresa
    {
        List<Funcionario> funcionarios = new List<Funcionario>();
    }

    abstract class Funcionario
    {
        public string nome;
        protected string senha;
        protected string CPF;

        public Funcionario(string nome, string senha, string CPF)
        {
            this.nome = nome;
            this.senha = senha;
            this.CPF = CPF;
        }

        public virtual double CalcularSalario()
        {
            return 0;
        }
    }

    class CEO : Funcionario
    {
        int horasTrabalhadas = 0;

        public CEO(string nome, string senha, string CPF, int horasTrabalhadas) : base(nome, senha, CPF)
        {
            this.horasTrabalhadas = horasTrabalhadas;
        }

        public override double CalcularSalario()
        {
            if (horasTrabalhadas == 0 || horasTrabalhadas < 0 || horasTrabalhadas > 320)
            {
                throw new HorasInvalidas("Valor de horas inválido.");
            }
            else
            {
                return horasTrabalhadas * 166;
            }
        }
        public override string ToString()
        {
            return "=============================================" +
                "\nPerfil Profissional" +
                "\n" +
                "\nNome: " + nome +
                "\nSenha: " + senha +
                "\nCPF: " + CPF +
                "\nTotal de Horas Trabalhadas no Mês: " + horasTrabalhadas +
                "\nSalário do Mês: " + CalcularSalario() + " R$" +
                "\nFunção: Chefe." +
                "\n=============================================";
        }
    }

    class Trabalhadores : Funcionario
    {
        int horasTrabalhadas = 0;

        public Trabalhadores(string nome, string senha, string CPF, int horasTrabalhadas) : base(nome, senha, CPF)
        {
            this.horasTrabalhadas = horasTrabalhadas;
        }

        public override double CalcularSalario()
        {
            if (horasTrabalhadas == 0 || horasTrabalhadas < 0 || horasTrabalhadas > 320)
            {
                throw new HorasInvalidas("Valor de horas inválido.");
            }
            else
            {
                return horasTrabalhadas * 30;
            }
        }

        public override string ToString()
        {
            return "=============================================" +
                "\nPerfil Profissional" +
                "\n" +
                "\nNome: " + nome +
                "\nSenha: " + senha +
                "\nCPF: " + CPF +
                "\nTotal de Horas Trabalhadas no Mês: " + horasTrabalhadas +
                "\nSalário do Mês: " + CalcularSalario() + " R$" +
                "\nFunção: Funcionário Regular." +
                "\n=============================================";
        }
    }

    class Auxiliadores : Funcionario
    {
        int horasTrabalhadas = 0;

        public Auxiliadores(string nome, string senha, string CPF, int horasTrabalhadas) : base(nome, senha, CPF)
        {
            this.horasTrabalhadas = horasTrabalhadas;
        }
        public override double CalcularSalario()
        {
            if (horasTrabalhadas == 0 || horasTrabalhadas < 0 || horasTrabalhadas > 320)
            {
                throw new HorasInvalidas("Valor de horas inválido.");
            }
            else
            {
                return horasTrabalhadas * 10;
            }
        }
        public override string ToString()
        {
            return "=============================================" +
                "\nPerfil Profissional" +
                "\n" +
                "\nNome: " + nome +
                "\nSenha: " + senha +
                "\nCPF: " + CPF +
                "\nTotal de Horas Trabalhadas no Mês: " + horasTrabalhadas +
                "\nSalário do Mês: " + CalcularSalario() + " R$" +
                "\nFunção: Funcionário Terciário." +
                "\n=============================================";
        }
    }

    class Juniors : Funcionario
    {
        int horasTrabalhadas = 0;

        public Juniors(string nome, string senha, string CPF, int horasTrabalhadas) : base(nome, senha, CPF)
        {
            this.horasTrabalhadas = horasTrabalhadas;
        }

        public override double CalcularSalario()
        {
            if (horasTrabalhadas == 0 || horasTrabalhadas < 0 || horasTrabalhadas > 180)
            {
                throw new HorasInvalidas("Valor de horas inválido.");
            }
            else
            {
                return horasTrabalhadas * 8;
            }
        }
        public override string ToString()
        {
            return
                "=============================================" +
                "\nPerfil Profissional" +
                "\n" +
                "\nNome: " + nome +
                "\nSenha: " + senha +
                "\nCPF: " + CPF +
                "\nTotal de Horas Trabalhadas no Mês: " + horasTrabalhadas +
                "\nSalário do Mês: " + CalcularSalario() + " R$" +
                "\nFunção: Júnior." +
                "\n=============================================";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string nome = "";
            string senha = "";
            string CPF = "";
            int horas = 0;
            int funcao = 0;

            try
            {
                Console.Write("Digite Nome de Usuário: ");
                nome = Console.ReadLine();
                Console.Write("Digite Senha: ");
                senha = Console.ReadLine();
                Console.Write("Digite o CPF: ");
                CPF = Console.ReadLine();

                VerificadorDeCPF Vcpf = new VerificadorDeCPF();
                if (!Vcpf.Verificar(CPF))
                {
                    throw new CPFInvalidoException("CPF Inválido, tente novamente mais tarde.");
                }

                Console.Write("Digite o número de horas trabalhadas no mês: ");
                horas = Convert.ToInt32(Console.ReadLine());
            }
            catch (HorasInvalidas ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }

            if (horas != 0 && horas > 0 && horas < 400)
            {
                Console.WriteLine();
                Console.WriteLine("Processando Informações...");
                Console.WriteLine();

                Console.Write("Login confirmado, transferindo dados para o sistema... " +
                   "\n" + "\nPressione ENTER para avançar...");
                Console.ReadKey();

                Console.Clear();

                Console.WriteLine("======================================================================");
                Console.WriteLine("Por favor, selecione o cargo correto:");
                Console.WriteLine("(1) Chefe.");
                Console.WriteLine("(2) Gerente.");
                Console.WriteLine("(3) Funcionário.");
                Console.WriteLine("(4) Segurança.");
                Console.WriteLine("(5) Faxineiro.");
                Console.WriteLine("(6) Estagiário.");
                Console.WriteLine("(7) Jovem Aprendiz.");
                Console.WriteLine("======================================================================");
                Console.Write("Digite o valor correspondente ao seu cargo: ");
                funcao = Convert.ToInt32(Console.ReadLine());
                do
                {
                    if (funcao == 1)
                    {
                        Funcionario pessoa = new CEO(nome, senha, CPF, horas);
                        Console.WriteLine(pessoa);
                        break;
                    }
                    if (funcao == 2 || funcao == 3)
                    {
                        Funcionario pessoa = new Trabalhadores(nome, senha, CPF, horas);
                        Console.WriteLine(pessoa);
                        break;
                    }
                    if (funcao == 4 || funcao == 5)
                    {
                        Funcionario pessoa = new Auxiliadores(nome, senha, CPF, horas);
                        Console.WriteLine(pessoa);
                        break;
                    }
                    if (funcao == 6 || funcao == 7)
                    {
                        Funcionario pessoa = new Juniors(nome, senha, CPF, horas);
                        Console.WriteLine(pessoa);
                        break;
                    }
                }
                while (funcao > 0 && funcao < 8);
                Console.ReadKey();
            }
        }
    }
}
