using System;
using System.Collections.Generic;
using System.Linq;


namespace _04._Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> textToChange = Console.ReadLine().Split(new char[] {' ',},StringSplitOptions.RemoveEmptyEntries).ToList();
           
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string[] morseLetters = {".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", ".-.", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            
            string newText = "";
            
            for (int i = 0; i < textToChange.Count; i++)
            {
                for (int j = 0; j < 37; j++)
                {
                    if (textToChange[i] == morseLetters[j])
                    {
                        newText += letters[j];
                        break;
                    }
                }
            }
            string result = string.Join(" ",newText.ToUpper().Split("|"));
            
            Console.WriteLine(result);
            
            
        }
    }
}
