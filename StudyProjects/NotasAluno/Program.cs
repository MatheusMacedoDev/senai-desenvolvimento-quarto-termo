dfloat nota = float.Parse(Console.ReadLine());

if (nota >= 7) 
{
    Console.WriteLine("Aprovado");
}
else if (nota >= 4) 
{
    Console.WriteLine("Em recuperação");
}
else 
{
    Console.WriteLine("Reprovado");
}