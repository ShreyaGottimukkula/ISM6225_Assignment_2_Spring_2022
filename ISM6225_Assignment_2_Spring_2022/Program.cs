/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {


            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = {"hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is: {0}", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is :{0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 4, 10, 4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1  = "horse";
            string word2 = "ros";
            int minLen = MinDistance( word1,  word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
            
        }
    

        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums1, int target)
        {
            try
            {
                int min = 0;
                int max = nums1.Length - 1;
                int pos = 0;
                while (min <= max) // using while loop to do a binary search 
                {
                    int mid = (min + max) / 2; // calculating the mid value
                    if (target == nums1[mid]) // comparing the target to value in the position mid.
                    {
                        pos = mid; // if equal , storing the position.
                        break;

                    }
                    else if (target < nums1[mid])  // comparing the target , if it is less than the value in the position mid.
                    {
                        if (mid - 1 >= 0 && nums1[mid - 1] < target) // condition to know if the mid is not less than index  zero and if target , if it is greater than the value in the position mid.
                        {
                            pos = mid; // if stisfied , storing the position.
                            break;
                        }
                        max = mid - 1;
                        if (max == -1)
                            pos = min - 1; // getting the position value


                    }
                    else
                    {
                        min = mid + 1;
                        if (min > nums1.Length - 1)
                            pos = min; // storing the position value.

                    }
                }

                return pos < 0 ? pos + 1 : pos; // returing result if input not zero , and result +1 if input is zero.
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.

        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.

        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {

                paragraph = Regex.Replace(paragraph, @"[^\w\s]", ""); //using regex funtion to remove punctuations from the paragraph.
                paragraph = paragraph.ToLower(); // converting to lower case.


                string[] strlist = paragraph.Split(" ", StringSplitOptions.RemoveEmptyEntries); //converting a paragraph to an array.

                List<string> L1 = new List<string>(banned); // creating a list to store the banned words.


                
                Dictionary<string, int> dict = new Dictionary<string, int>(); //Creating a dictionary dict.

                foreach (string c in strlist) // iterating throug each char in the array starlist.
                {
                    if (dict.ContainsKey(c)) // checking condition if the element ids in the dictionary or not.
                        dict[c] = dict[c] + 1; // incrimenting count if present.
                    else if (!L1.Contains(c))
                        dict.Add(c, 1); // adding elemt if not present.
                }

                dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);//sorting the dictionary to find the highest frequency.


                return dict.First().Key.ToLower();// returing the result.

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.

        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.

        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr1)
        {
            try
            {
                Dictionary<int, int> dict = new Dictionary<int, int>(); // creating a new integer dictionary.

                foreach (int c in arr1)    //Creating a  Dictionary.
                {
                    if (dict.ContainsKey(c)) // if element already present , incrementing the count.
                        dict[c] = dict[c] + 1;
                    else
                        dict.Add(c, 1); // if not present in dictionary then adding it to dict.

                }

                dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value); // sorting through a dictionary.

                
                return  dict.First().Value; // returning the result.
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"

        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int cows = 0; // cow count
                int bulls = 0; //bull count
                Dictionary<char, int> dict = new Dictionary<char, int>();
                bool[] value = new bool[secret.Length]; // maintaining true or flase to see if the element belongs in bull count or cow count
                for (int i = 0; i < secret.Length; i++) // iterating to calculate bull
                {
                    if (secret[i] != guess[i]) // condition if elements dosent match
                    {
                        value[i] = false; //  false is put in value array if no match , hence not a bull

                    }
                    else // id matches 
                    {
                        bulls++; // incrementing bull count
                        value[i] = true;
                    }
                    if (dict.ContainsKey(secret[i])) // insert into dictionary to prevent dups
                    {
                        dict[secret[i]] = dict[secret[i]] + 1;
                    }
                    else
                    {
                        dict[secret[i]] = 1;
                    }
                }
                for (int j = 0; j < guess.Length; j++) // iterating to find cows values
                {
                    if (value[j]) continue; //  if true is  a bull, hence not used for cow value
                    if (dict.ContainsKey(guess[j]) && dict[guess[j]] > 0)
                    {
                        cows++;
                        dict[guess[j]] = dict[guess[j]] - 1;
                    }
                }



                return bulls+"A" + cows + "B"; // return result
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int length = s.Length;// taking the input length .
                List<int> res = new List<int>(); // create integer list.
                int[] mapping = new int[26]; // create integer array.
                for (int i = length - 1; i >= 0; i--)
                {
                    if (mapping[s[i] - 97] == 0)
                    {
                        mapping[s[i] - 97] = i;
                    }
                }
                int index = 0; // maintaining index
                while(length > index  ) // iterating through mapping array
                {
                    int low = index;
                    int high = mapping[s[index] - 97]; // finding the high or hypothetically assumed last element
                    int difference = high - low + 1;
                    for (int j = low; j <= high; j++) // iterating throuh mapping array
                    {
                        if (mapping[s[j] - 97] > high)
                        {
                            high = mapping[s[j] - 97]; // udating the farthest value as highes based on element occurance.
                            difference = high - low + 1; // calculating the new difference upon updated high value
                        }

                    }
                    res.Add(difference); // ading the difference to result array.
                    index = high + 1;
                }
                return res;// return the result.

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /*
        Question 6

        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.



         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.

         */

        public static List<int> NumberOfLines(int[] widths,string bulls_string9)
        {
            try
            {
                int count = 0, i = 0;
                int linecount = 1;
                string result = "";
                foreach (char c in bulls_string9)// iterating through each char in the given string.
                {
                    if (count + widths[i] <= 100) // prechceking if its exceding the condition 100 pixels
                    {

                        result = result + c.ToString(); // if not adding it 
                        count = count + widths[i]; // maintainning a count of above addition
                        i++;
                    }
                    else

                    {
                        linecount++; // if exceeds the condition 100 pixels, maitaining the count of line as no more can be added.
                        count = 0;
                        result = "";// starting a new line segment
                        result = result + c.ToString();
                        count = count + widths[i]; 
                        i++;
                        

                    }

                }
                //List<int> L = new List<int>();
                //L.Add(linecount);
                //L.Add(count);
                //return L;

                return new List<int>() { linecount, count }; // retuning result in a list
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }


        /*
        
        Question 7:

        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true

        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true

        Example 3:
        Input: bulls_string  = "(]"
        Output: false

        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                bool x = true;
                for (int i = 0; i < bulls_string10.Length; i = i + 2) // iterating through the given string char by char.
                {
                    if (bulls_string10[i] == '(') // if the current character is ( , it must be followed by ). 
                    {

                        if (bulls_string10[i + 1] == ')') x = true; // if yes print valid
                        else x = false; // if not print invalid
                    }
                    else if (bulls_string10[i] == '{') // if the current character is { , it must be followed by }. 
                    {

                        if (bulls_string10[i + 1] == '}') x = true; // if yes print valid
                        else x = false; // if not print invalid
                    }
                    else if (bulls_string10[i] == '[') // if the current character is [ , it must be followed by ].
                    {

                        if (bulls_string10[i + 1] == ']') x = true; // if yes print valid
                        else x = false; // if not print invalid
                    }
                    else x = false; // if not print invalid


                }
                

                return x;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }


        }
        


        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.

        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                string[] morseLetters = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                string[] newText = new String[words.Length]; // to store result

                for (int p = 0; p < words.Length; p++) // traversing through arry of strings-words.
                {
                    string textToChange = words[p];// considering of string at a time from array words.
                    string morsetext = ""; // converted text storing variable initialised.

                    for (int i = 0; i < textToChange.Length; i++) // traversing through each character in the considered string.
                    {
                        //Console.WriteLine("word" + i + ":"+textToChange);


                        for (short j = 0; j < 26; j++) // loop to compe with every chacracter and replace its evqivalant morse code.
                        {

                            if (textToChange[i] == letters[j]) // condition to replace it with its equivalant morse code.
                            {


                                morsetext = morsetext + morseLetters[j]; // replacing 

                            }
                        }

                    }

                    newText[p] = morsetext;
                    //Console.WriteLine(newText[p]);

                }
                HashSet<string> set = new HashSet<string>(newText); // hash set to eliminate duplicates
                return set.Count(); // returning the uniqe transition words.

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

      


        /*
        
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time. Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).

        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.

        */

        public static int SwimInWater(int[,] grid)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                throw;
            }
        }

        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:

        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.

        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')

        */

        public static int MinDistance(string word1, string word2)
        {
            try
            {
                //write your code here.
                return 0;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
