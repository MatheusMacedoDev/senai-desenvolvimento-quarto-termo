/*
Crie um programa que calcule a soma dos números pares de um vetor de 10 elementos.  
Utilize um laço for para percorrer o vetor e uma estrutura condicional if para identificar  os números pares. 
*/

int[] numbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

int evenNumbersSum = 0;

for (int i = 0; i < numbers.Length; i++)
{
    int currentNumber = numbers[i];

    if (currentNumber % 2 == 0) 
    {
        evenNumbersSum += currentNumber;
    }
}

Console.WriteLine($"A soma dos elementos pares é igual a {evenNumbersSum}");