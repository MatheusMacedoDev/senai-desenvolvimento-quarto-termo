/*
 Crie um programa que permita que o usuário cadastre 5 nomes em um vetor. Após o
cadastro, o programa deve imprimir na tela os nomes cadastrados em ordem alfabética.
Utilize um laço for para o cadastro e um método de ordenação de sua preferência (por
exemplo, bubble sort) para ordenar os nomes.
*/

string[] names = new string[5];

Console.WriteLine("Digite 5 nomes a seguir:");

for (int i = 0; i < names.Length; i++)
{    
    Console.Write($"{i + 1}) ");
    names[i] = Console.ReadLine();
}

Console.WriteLine("\nOs nomes em ordem: ");

Array.Sort(names);

for (int i = 0; i < names.Length; i++)
{    
    Console.WriteLine($"{i + 1}) {names[i]}");
}