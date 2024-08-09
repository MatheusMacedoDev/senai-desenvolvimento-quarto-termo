/*
Crie uma função que recebe um número como parâmetro e retorna a tabuada desse  número até o número 10. 
Utilize um laço for para gerar os múltiplos do número. 
*/
class Program
{
    public static int[] getMultiplicationTable(int number) 
    {
        int[] multiplicationTable = new int[11];

        Console.WriteLine($"\nTabuada de {number}:");

        for (int i = 0; i < multiplicationTable.Length; i++)
        {
            multiplicationTable[i] = number * i;
            Console.WriteLine($"{number} x {i} = {multiplicationTable[i]}");
        }

        return multiplicationTable;
    }

    public static void Main(string[] args)
    {
        Console.Write("Digite um número: ");
        int number = int.Parse(Console.ReadLine());

        getMultiplicationTable(number);
    }
}