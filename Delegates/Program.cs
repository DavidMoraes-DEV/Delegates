using System;
using Delegates.Services;

namespace Delegates
{
    class Program
    {
        delegate double BinaryNumericOperation1(double n1, double n2); //Declaração do delegate, especificando que ele será uma referência de função que receberá dois numeros double e retorna um numero double.
        delegate double BinaryNumericOperation2(double n1);
        static void Main(string[] args)
        {
            /*
            * DELEGATES:
            - É uma referência (com type safety) para um ou mais métodos.
                - É um tipo referência

            * USOS COMUNS:
            - Comunicação entre objetos de forma flexível e entensível (eventos / callbacks)
            - Parametrização de operações por métodos (programação funcional)

            * DELEGATES PRÉ-DEFINIDOS:
            - Action
            - Func
            - Predicate

            * DEMONSTRAÇÃO BÁSICA:
            */

            double a = 10.0;
            double b = 12.0;

            double result1 = CalculationService.Sum(a, b);
            double result2 = CalculationService.Max(a, b);
            double result3 = CalculationService.Square(a);


            Console.WriteLine("Sum between A(10) and B(12): " + result1);
            Console.WriteLine("Maximum between A(10) and B(12): " + result2);
            Console.WriteLine("A(10) square: " + result3);

            //DELEGATE:-----------------------------------------------------------------------------------------------

            BinaryNumericOperation1 op1 = CalculationService.Sum; //Um delegate instânciando que o objeto "op" do tipo "BinaryNumericOperation" agora esta recebendo o método "Sum" da classe "CalculationService" guardando então a referência para essa função.
            BinaryNumericOperation1 op2 = CalculationService.Max;
            BinaryNumericOperation2 op3 = CalculationService.Square; //Como o delegate possui Type Safety éle só aceitará no BinaryNumericOperation1 função que recebem dois double e como o "Square" recebe apenas um double, é necessario criar outro delegate para esse tipo.

            double result4 = op1(a, b); //Agora é preciso apenas colocar o nome da variável que esta guardando a referência para a operação .Sum, descartando a necessidade de Colocar o nome da classe e etc.
            double result5 = op2(a, b); //Obs. Fica muito mais enchuto a sintaxe agora.
            double result6 = op3(a);

            Console.WriteLine("\nDelegate: Sum between A(10) and B(12): " + result4);
            Console.WriteLine("Delegate: Maximum between A(10) and B(12): " + result5);
            Console.WriteLine("Delegate: A(10) square: " + result6);

            //SINTAXES ALTERNATIVAS:

            BinaryNumericOperation1 op4 = new BinaryNumericOperation1(CalculationService.Sum); //Também aceita dessa forma, porém fica mais verboso.
            double result7 = op4.Invoke(a, b); // A função ".Invoke" invoca o função que possui a referência guardada na variável op4 (da na mesma de não colocar o .Invoke)
        }
    }
}