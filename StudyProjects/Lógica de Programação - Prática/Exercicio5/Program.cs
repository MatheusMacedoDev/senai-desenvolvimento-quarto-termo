/*
Crie um programa que peça ao usuário para digitar um texto e conte quantas vezes cada
letra do alfabeto aparece no texto.
*/

Console.Write("Digite um texto qualquer: ");
string text = Console.ReadLine();

char[] alphabet = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
int[] lettersOccurences = new int[26];

char[] textChars = text.ToCharArray(0, text.Length);

for (int textCharIndex = 0; textCharIndex < textChars.Length; textCharIndex++)
{
    string currentTextChar = textChars[textCharIndex].ToString();

    for (int letterIndex = 0; letterIndex < alphabet.Length; letterIndex++)
    {
        string currentAlphabetLetter = alphabet[letterIndex].ToString();
    
        if (currentTextChar.Equals(currentAlphabetLetter, StringComparison.InvariantCultureIgnoreCase)) 
        {
            lettersOccurences[letterIndex]++;
            break;
        }
    }
}

Console.WriteLine("Ocorrências por letra do alfabeto: ");
for (int i = 0; i < lettersOccurences.Length; i++)
{
    System.Console.WriteLine($"{Char.ToUpper(alphabet[i])} - {lettersOccurences[i]}");
}