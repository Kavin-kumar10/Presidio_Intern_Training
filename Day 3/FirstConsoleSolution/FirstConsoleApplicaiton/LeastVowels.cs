using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApplicaiton
{
    internal class LeastVowels
    {
        static int minCount = int.MaxValue;
        static string minCountString = "";
        static int[] vowelsCount = { 0,0,0,0,0};


        //Get Sentance
        static string GetSentance()
        {
            string str = Console.ReadLine();
            return str;
        }

        //Split the sentance to words
        static string[] WordSplit(String str)
        {
            string[] strings = str.Split(',');
            Iterate(strings);
            return strings;
        }

        //iterator
        static void Iterate(string[] strings)
        {
            for(int i = 0; i < strings.Length; i++) {
                CountVowels(strings[i]);
            }
        }

        //Maximum vowels
        static char MaxVowel(int[] vowelsCount,out int max)
        {
            max = 0;
            int maxVowel = 0;
            for(int i = 0;i < vowelsCount.Length;i++) {
                if (vowelsCount[i] > max) { max = vowelsCount[i];maxVowel = i; };
            }
            if (maxVowel == 0) return 'a';
            else if (maxVowel == 1) return 'e';
            else if (maxVowel == 2) return 'i';
            else if (maxVowel == 3) return 'o';
            else return 'u';
        }

        //Counting Vowels
        static int CountVowels(string str)
        {
            char[] chars = str.ToCharArray();
            int count = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 'a'|| chars[i] == 'e' || chars[i] == 'i' || chars[i] == 'o' || chars[i] == 'u' ) {
                    if (chars[i] == 'a') vowelsCount[0]++;
                    else if (chars[i] == 'e') vowelsCount[1]++;
                    else if (chars[i] == 'i') vowelsCount[2]++;
                    else if (chars[i] == 'o') vowelsCount[3]++;
                    else if (chars[i] == 'u') vowelsCount[4]++;
                    count++;
                }
            }
            if (count < minCount) {
                minCount = count;
                minCountString = str;
            };
            return count;
        }

        //Main function
        static void Main(string[] args)
        {
            int max;
            string str= GetSentance();
            Console.WriteLine("Number of words "+WordSplit(str).Length);
            Console.WriteLine("Minimum Vowels String " + minCountString);
            Console.WriteLine("Maximum found vowel is "+MaxVowel(vowelsCount,out max)+" with repeation of "+max);
        }
    }
}
