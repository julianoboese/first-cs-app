using System;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe o nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;
                    case "2":
                        foreach(var i in alunos)
                        {
                            if (!string.IsNullOrEmpty(i.Nome))
                                Console.WriteLine($"ALUNO: {i.Nome} - NOTA: {i.Nota}");
                        }

                        break;
                    case "3":
                        decimal somaNotas = 0;
                        var numAlunos = 0;
                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            { 
                                somaNotas += alunos[i].Nota;
                                numAlunos++;
                            }
                        }

                        var media = somaNotas / numAlunos;
                        
                        Conceito conceito;
                        if (media < 2)
                        {
                            conceito = Conceito.E;
                        }
                        else if (media < 4)
                        {
                            conceito = Conceito.D;
                        }
                        else if (media < 6)
                        {
                            conceito = Conceito.C;
                        }
                        else if (media < 8)
                        {
                            conceito = Conceito.B;
                        }
                        else
                        {
                            conceito = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {media} - CONCEITO: {conceito}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
