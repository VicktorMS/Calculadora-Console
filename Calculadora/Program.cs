using System;
using System.Threading;

class Program
{
    public delegate string MathOperation(double a, double b);

    void TitleDecoration(string title)
    {
        string decoration = "";
        foreach (char letter in title)
        {
            decoration += '*';
        }
        Console.WriteLine(decoration);
        Console.WriteLine(title);
        Console.WriteLine(decoration);

    }

    static double RequestUserInputNumber(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string userInput = Console.ReadLine()!;
            double parsedNumber;
            if (double.TryParse(userInput, out parsedNumber))
            {
                return parsedNumber;
            }
            else
            {
                Console.WriteLine("Você digitou um número inválido, por favor tente novamente.");
            }
        }
    }

    void WelcomeMessage()
    {
        Console.WriteLine(@"
██╗███╗░░██╗███████╗███╗░░██╗███████╗████████╗
██║████╗░██║██╔════╝████╗░██║██╔════╝╚══██╔══╝
██║██╔██╗██║█████╗░░██╔██╗██║█████╗░░░░░██║░░░
██║██║╚████║██╔══╝░░██║╚████║██╔══╝░░░░░██║░░░
██║██║░╚███║██║░░░░░██║░╚███║███████╗░░░██║░░░
╚═╝╚═╝░░╚══╝╚═╝░░░░░╚═╝░░╚══╝╚══════╝░░░╚═╝░░░");

        TitleDecoration("Olá, seja muito bem vindo a calculadora em C#.");
    }

    public void MainMenu()
    {
        WelcomeMessage();
        Console.WriteLine("Selecione uma das opções abaixo: \n");
        Console.WriteLine("Digite 1 para realizar uma adição");
        Console.WriteLine("Digite 2 para realizar uma subtração");
        Console.WriteLine("Digite 3 para realizar uma multiplicação");
        Console.WriteLine("Digite 4 para realizar uma divisão");
        Console.WriteLine("Digite 0 para realizar sair do programa");

        string userChoice = Console.ReadLine()!;
        switch (userChoice)
        {
            case "1":
                Operation("Soma", Sum);
                break;
            case "2":
                Operation("Subtração", Subtraction);
                break;
            case "3":
                Operation("Multiplicação", Multiplication);
                break;
            case "4":
                Operation("Divisão", Division);
                break;
            case "0":
                Console.Clear();
                Console.WriteLine("Obrigado por usar esta calculadora.");
                Thread.Sleep(1000);
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                MainMenu();
                break;
        }
    }


    //Operações Matemáticas
    public static string Subtraction(double a, double b)
    {
        double result = a - b;
        return result.ToString();
    }

    public static string Sum(double a, double b)
    {
        double result = a + b;
        return result.ToString();
    }

    public static string Multiplication(double a, double b)
    {
        double result = a * b;
        return result.ToString();
    }

    public static string Division(double a, double b)
    {
        double result = a / b;
        double rest = a % b;
        string resultString = result.ToString("F2");
        string restString = rest.ToString("F2");
        return $"{resultString} \nO resto da divisão é: {restString}";
    }


    //Função de operação
    void Operation(string operationName, MathOperation operation)
    {
        Console.Clear();
        while (true)
        {
            TitleDecoration($"Você está realizando uma {operationName}!");
            double firstNumber = RequestUserInputNumber("Digite o primeiro termo:");
            double secondNumber = RequestUserInputNumber("Digite o segundo termo:");

            string result = operation(firstNumber, secondNumber);

            Console.Clear();
            Console.WriteLine("A {3} entre {0} e {1} é igual a: {2}", firstNumber, secondNumber, result, operationName);
            Console.WriteLine("\n\n");
            Console.WriteLine($"Digite 1 para realizar outra {operationName} \nDigite 2 para voltar para o menu \nDigite qualquer tecla para sair do programa");


            string userOption = Console.ReadLine()!;
            switch (userOption)
            {
                case "1":
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    MainMenu();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    public static void Main(string[] args)
    {
        Program p = new Program();
        p.MainMenu();
    }

}
