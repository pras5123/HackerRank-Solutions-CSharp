using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRankPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem 1 : https://www.hackerrank.com/challenges/alternating-characters/problem
            //int minCount = MinimumDeletionString(1,"AABCD");
            //Problem 2  : https://www.hackerrank.com/challenges/anagram
            //int mincount = anagram("aaabbb");
            //Problem 3 : https://www.hackerrank.com/challenges/beautiful-binary-string/problem
            //int count = beautifulBinaryString("01001010");
            //Problem 4 : https://www.hackerrank.com/challenges/caesar-cipher-1/problem
            //string result = caesarCipher("1X7T4VrCs23k4vv08D6yQ3S19G4rVP188M9ahuxB6j1tMGZs1m10ey7eUj62WV2exLT4C83zl7Q80M", 2);
            //Problem 5 : https://www.hackerrank.com/challenges/camelcase/problem
            //int result = camelcase("saveChangesInTheEditor");
            //Problem 6 : https://www.hackerrank.com/challenges/funny-string/problem
            //string result = funnyString("bcxz");
            //Problem 7 : Check whether the given string is palindrome. //Own problems tried.
            //( if the reversal of the original string is same as original string, its a palindrome)                      
            //string result = CheckPalindrome("nitin");
            //Problem 8 : https://www.hackerrank.com/challenges/game-of-thrones/problem (check if the string can be re-arranged as a palindrome)
            string result = gameOfThrones("aaabbbb");




            //Contests
            
            
            
            var k = "";

        }



        #region Minimum change count for an Anagram  
        /* The original word or phrase is known as the subject of the anagram. Any word or phrase that exactly reproduces the letters 
         * in another order is an anagram . Example : the word "binary" into "brainy" or the word "adobe" into "abode".
        */
        static int anagram(string s)
        {
            //The idea is to make character count arrays for both the strings and store frequency of each character. 
            //If two strings contains same data set in any order then strings are called Anagram
            int count = 0;
            if(s.Length % 2 !=0)
            {
                return -1; // If its not a equal number of character, return -1 immediately
            }
            int halfLength = s.Length / 2;
            string s1 = s.Substring(0, halfLength);  // ( 0 start , total  4 ) 
            string s2 = s.Substring(halfLength, halfLength);  // (4 start, total 4)
            // store the count of character 
            int[] char_count = new int[26];
            // Iterate through the int array and increment against the found character
            for (int i = 0; i < s1.Length; i++)
            {
                char_count[s1[i] - 97]++;
            }
            // Iterate through the  same int array and keep decrementing. Count only those index value going as -ve
            for (int i = 0; i < s2.Length; i++)
            {
              int result=  char_count[s2[i] -97]--;
              if (result <= 0)
                    count++;
            }

            return count;
            /*
               Time Complexity : O(n)
                Auxiliary space : O(ALPHABET-SIZE)             
             */

        }
        #endregion

        #region MinimumDeletionString
        private static int  MinimumDeletionString(int q, string s)
        {
            /*
                 5
                AAAA
                BBBBB
                ABABABAB
                BABABA
                AAABBB             
             */
            int result = 0;
            /*TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            Console.WriteLine("Input number of Samples : q");
            int q = Convert.ToInt32(Console.ReadLine()); */
            for (int qItr = 0; qItr < q; qItr++)
            {
                //Console.WriteLine("Input the strings");
                //string s = Console.ReadLine();
                 result = alternatingCharacters(s);
                //textWriter.WriteLine(result);
            }

            return result;
        }
        static int alternatingCharacters(string s)
        {
            int minimumDeletionCount=0;
            //since it generates error finding the end of next, changing s.Length -- > s.Length-1
            for (int i = 0; i < s.Length-1; i++)   //You cannot do i=i+2 because you need to compare each character with the next, back to i++
            {
                //char individualCharacter = s[i];
                if (s[i] == s[i + 1])
                {
                    minimumDeletionCount++;
                } 
            }
            return minimumDeletionCount;

            /*
             We've to simply track the alternating characters while traversing the characters of the string
            - If the character being traversed is same as previous character then increment it and move to the next character
             * Time Complexity:  O(n) //we need to traverse the entire string
             * Space Complexity: O(1) //we are reading every string input in a test case from console input stream character by character 
                                  in place of saving the entire string in memory. So constant space.
             
             */
        }
        #endregion

        #region Beautiful Binary string 010- to take off
        static int beautifulBinaryString(string b)
        {
            int count = 0;
            for (int i = 0; i < b.Length-2; i++)
            {
                if (b[i] == '0' && b[i + 1] =='1' && b[i + 2] == '0')   //here we are comparing 3 increments so Length-2 in the for loop
                {
                    count++;
                    i= i + 2;  // If you find 010, immediately increase the count and jump next to 3rd position 
                }
            }
            return count;
        }
        #endregion

        #region CeaserCipher 
        static string caesarCipherObsolete(string s, int k)
        {
            StringBuilder sbBuild = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char l = s[i];
                //checking for this range because other special character must not be shifted
                if ((l >= 65 && l <= 90) || (l >= 97 && l <= 122))  
                {
                    //Problem with this approach is, we wont get shifting right if we get y or z in this example.
                   l = (char)(l + k);                   
                }             
                sbBuild.Append(l);
            }
            return sbBuild.ToString();
        }
        static string caesarCipherNotWorking(string s, int k)
        {
            /*
             Expected input : 1X7T4VrCs23k4vv08D6yQ3S19G4rVP188M9ahuxB6j1tMGZs1m10ey7eUj62WV2exLT4C83zl7Q80M
             Expected output : 1Y7U4WsDt23l4ww08E6zR3T19H4sWQ188N9bivyC6k1uNHAt1n10fz7fVk62XW2fyMU4D83am7R80N
             */
            StringBuilder sbBuild = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char l = s[i];
                int CharacterToEndDifference = 0;
                int SubtractedShift = 0;
                if (l >= 65 && l <= 90) 
                {
                    if (l + k <= 90)
                    {
                        l = (char)(l + k);
                    }
                    else
                    {
                        CharacterToEndDifference = (90 - l);
                        SubtractedShift = k - CharacterToEndDifference;
                        l = (char)(64 + SubtractedShift);
                    }
                }
                else if (l>=97 && l<=122)
                {
                    if (l + k <= 122)
                    {
                        l = (char)(l + k);
                    }
                    else
                    {

                        CharacterToEndDifference = (122 - l);
                        SubtractedShift = k - CharacterToEndDifference;
                        l = (char)(96 + SubtractedShift);

                    }
                }

                sbBuild.Append(l);
            }
            return sbBuild.ToString();

        }
        static string caesarCipher(string s, int k)
        {
            StringBuilder sbBuild = new StringBuilder();
            if (k > 26)
            {
                k = k % 26;
            }
            for (var i = 0; i < s.Length; i++)
            {
                var asciiCode = (int)s[i];
                if (asciiCode >= 97 && asciiCode <= 122 )
                {
                    //small case alphabets
                    if (asciiCode + k <= 122)
                        //we're within range. Replace the encoded character
                        sbBuild.Append((char)(asciiCode + k));
                    else
                    {
                        //(asciiCode + k-1) - is larger always so use that first in order to avoid -ve numbers
                        //for the range between 97 and 122, we need to add the extra overflow number to starting number i.e. 97
                        //Extra overflow number can be calculated by taking the (highest number) in the range (122) and then take (highest number+shift number -1)
                        //Then do  : (highest number+shift number -1) - (highest number)  ==> you will get extra numbers. you can then add it to 97
                        sbBuild.Append((char)(97 + ((asciiCode + k-1) - 122 )));
                    }
                }
                else if (asciiCode >= 65 && asciiCode <= 90 )
                {
                    //upper case alphabets
                    if (asciiCode + k <= 90)
                        //we're within range. Replace the encoded character
                        sbBuild.Append((char)(asciiCode + k));
                    else
                    {
                        sbBuild.Append((char)(65 + ((asciiCode + k - 1) -90 )));
                    }
                }
                else
                {
                    sbBuild.Append(s[i]);
                }              
            }
            return sbBuild.ToString();

            //Time Complexity:  O(n) iteration of whole input text is required once. 
            //Space Complexity: O(n) we need to store the entire input text in memory to process it.
        }
        #endregion

        #region Camel Case Character Count
        static int camelcase(string s)
        {
            int count=1;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 65 && s[i] <= 90)
                {
                    count++;
                }
                //Time Complexity:  O(n)
                //Space Complexity: O(1) //dynamically allocated variables are fixed for any length of input.
            }
            return count;
        }
        #endregion

        #region Funny String 
        static string funnyString(string s)
        {
            for (int i = 0; i < s.Length-1; i++)
            {
                int forwardDifference = Math.Abs((int)(s[i] - s[i + 1]));  //We get -ve values if we do not use absolute values
                //int reverseDifference = (int)(s[s.Length]-s[s.Length-1]);  //This holds good only for the first iteration
                int reverseDifference = Math.Abs((int)(s[s.Length-1-i] - s[s.Length-1-(i+1)]));
                if (forwardDifference != reverseDifference)
                {
                    return "Not Funny";
                }
            }
            return "Funny";

            /*
             - Here we have to iterate through the string and keep checking the difference between adjacent characters
             - The only trick is that we can check the difference both in forward and reverse direction at the same time and compare them in single go. So, we don't require two iteration.
                Time Complexity:  O(n) //we need to iterate the entire string once.
                Space Complexity: O(n) //we need to store entire string in memory to process both in forward and reverse direction at the same time.
             */
        }
        #endregion

        #region Check if the string is Palindrome
        static string CheckPalindrome(string s)
        {
            StringBuilder sbReverse = new StringBuilder();
            //Start taking the character in reverse way until the condition i>=0 holds good
            for (int i = s.Length - 1; i>=0; i--)
            {
                sbReverse.Append(s[i]);                
            }
            if (s == sbReverse.ToString())
            {
                return "String is Palindrome";
            }
            return "String is not a Palindrome";
        }
        #endregion



        #region Game Of Thrones  :Check if a string can be rearranged into a palindrome
        /*
         A set of characters can form a palindrome if at most one character occurs odd number of times and all characters occur even number of times.
            A simple solution is to run two loops, the outer loop picks all characters one by one, the inner loop counts number of occurrences of the 
         * picked character. We keep track of odd counts. Time complexity of this solution is O(n2). 
         * 
         * 
         * We can do it in O(n) time using a count array. Following are detailed steps.
            1) Create a count array of alphabet size which is typically 256. Initialize all values of count array as 0.
            2) Traverse the given string and increment count of every character.
            3) Traverse the count array and if the count array has more than one odd values, return false. Otherwise return true.  
         * 
         * 
         * 
         * We can do it in O(n) time using a list. Following are detailed steps.
            1) Create a character list.
            2) Traverse the given string.
            3) For every character in the string, remove the character if the list already contains else add to the list.
            4) If the string length is even the list is expected to be empty.
            5) Or if the string length is odd the list size is expected to be 1
            6) On the above two conditions (3) or (4) return true else return false.
         */
        static string gameOfThrones(string s)
        {
            int[] charCount = new int[256];
            for (int i = 0; i < s.Length; i++)
            {
                charCount[s[i]]++;
            }
            return "";

        }
        #endregion

    }
}
