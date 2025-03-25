using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRATICA_1__CALCULADORA_PILHA_
{
    class Program
    {
        static void Main(string[] args)
        {
            Pilha pilha = new Pilha(100);
            Console.WriteLine("Calculadora Científica com Pilha\nDigite números para empilhar ou operadores (+, -, *, /) para calcular:");

            while (true)
            {
                string entrada = Console.ReadLine();
                if (int.TryParse(entrada, out int numero))
                {
                    if (!pilha.Cheia()) pilha.Empilhar(numero);
                    else Console.WriteLine("Erro: Pilha cheia.");
                }
                else if ("+-*/".Contains(entrada) && entrada.Length == 1)
                {
                    if (pilha.Vazia())
                    {
                        Console.WriteLine("Erro: Pilha vazia.");
                        continue;
                    }

                    if (pilha.Vazia())
                    {
                        Console.WriteLine("Erro: Pilha não contém elementos suficientes para a operação.");
                        continue;
                    }

                    int b = pilha.Desempilhar();
                    int a = pilha.Vazia() ? 0 : pilha.Desempilhar();
                    int resultado = 0;

                    switch (entrada)
                    {
                        case "+":
                            resultado = a + b;
                            break;
                        case "-":
                            resultado = a - b;
                            break;
                        case "*":
                            resultado = a * b;
                            break;
                        case "/":
                            if (b == 0)
                            {
                                Console.WriteLine("Erro: Divisão por zero.");
                                pilha.Empilhar(a);
                                pilha.Empilhar(b);
                                continue;
                            }
                            resultado = a / b;
                            break;
                        default:
                            Console.WriteLine("Erro: Operação inválida.");
                            continue;
                    }

                    pilha.Empilhar(resultado);
                    Console.WriteLine($"Resultado: {resultado}");
                }
                else if (entrada.ToLower() == "sair") break;
                else Console.WriteLine("Entrada inválida.");
            }
        }
    }
}

    
