/*
 * Name : Shivanvitha Narala
 * Date: 01/23/2022
 * explaination : Answers to the six questions listed in assignment 1(Programming Introduction)
 * Self Reflection: It took me around 12 hrs to complete the assignment, Throwing custom exceptions was one of the new concepts I learned, and it was a fantastic opportunity to learn and explore the concepts of strings and arrays.
 */
using System;
using System.Linq;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Question1: Enter the string here.:");
            string s = Console.ReadLine();
            string final_string = RemoveVowels(s);
            Console.WriteLine("After removing the vowels, the final string is as follows: {0}", final_string);
            Console.WriteLine();

            //NEXT

            //Question 2:
            string[] bulls_string1 = new string[] { "Marshall", "Student", "Center" };
            string[] bulls_string2 = new string[] { "MarshallStudent", "Center" };
            Console.WriteLine("Question2");
            bool flag = ArrayStringsAreEqual(bulls_string1, bulls_string2);
            if (flag)
            {
                Console.WriteLine("Yes, the strings in both arrays are the same.");
            }
            else
            {
                Console.WriteLine("No, the strings in both arrays are not the same. ");
            }
            Console.WriteLine();

            //NEXT

            //Question 3:
            int[] bull_bucks = new int[] { 1, 2, 3, 2 };
            int unique_sum = SumOfUnique(bull_bucks);
            Console.WriteLine("Question3:");
            Console.WriteLine("The array's total number of unique elements is :{0}", unique_sum);
            Console.WriteLine();

            //NEXT

            //Question 4:
            int[,] bulls_grid = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("Question4:");
            int diagSum = DiagonalSum(bulls_grid);
            Console.WriteLine("The total of the bulls grid's diagonal elements is: {0}", diagSum);
            Console.WriteLine();

            //NEXT

            //Question 5:
            Console.WriteLine("Question5:");
            String bulls_string = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(bulls_string, indices);
            Console.WriteLine("After rotation, the final string is: {0}", rotated_string);
            Console.WriteLine();

            //NEXT

            //Quesiton 6:
            string bulls_string6 = "mumacollegeofbusiness";
            char ch = 'c';
            Console.WriteLine("Question6:");
            string reversed_string = ReversePrefix(bulls_string6, ch);
            Console.WriteLine("The prefix is reversed in the resulting string.: {0}", reversed_string);
            Console.WriteLine();
        }

        private static string RemoveVowels(string s)
        {
            try
            {
                // enter the code
                int l = s.Length;//determine the length of the string
                if (l > 10000)//Exceptions defined by the user
                {
                    throw new MaxLength(l);
                }
                String final_string = "";
                foreach (char z in s)
                {
                    if (z != 'a' && z != 'e' && z != 'i' && z != 'o' && z != 'u' && z != 'A' && z != 'E' && z != 'I' && z != 'O' && z != 'U')//checking for vowels
                    {
                        final_string = final_string + z;
                    }
                }
                return final_string;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static bool ArrayStringsAreEqual(string[] bulls_string1, string[] bulls_string2)
        {
            try
            {
                string a = "";
                foreach (string s in bulls_string1)
                {
                    a = a + s;//All of the strings in the first array are concatenated.
                }
                string b = "";
                foreach (string s in bulls_string2)
                {
                    b = b + s;//concatenate all of the strings in the second array
                }
                if (a == b)//comparing the completed strings
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        private static int SumOfUnique(int[] bull_bucks)
        {
            try
            {
                int l = bull_bucks.Length;//obtain the length of the string
                int[] x = bull_bucks;
                if (l > 100)//Exceptions defined by the user
                {
                    throw new MaxLength(l);
                }
                foreach (int i in bull_bucks)//Exceptions defined by the user
                {
                    if (i > 100)
                    {
                        throw new MaxValue(i);
                    }
                }
                int[] sample = new int[l];//making a new array
                int count = 0;
                for (int i = 0; i < l; i++)
                {
                    int n = bull_bucks[i];
                    if (sample.Contains(n))
                    {
                        count = count - n;//removing repeating elements
                    }
                    else
                    {
                        count = count + n;//incorporating distinct features
                        sample[i] = bull_bucks[i];//adding all one-of-a-kind elements to the new array
                    }
                }
                return count;
            }
            catch
            {
                throw;
            }
        }
        private static int DiagonalSum(int[,] bulls_grid)
        {
            try
            {
                // enter code
                int l = Convert.ToInt32(Math.Sqrt(bulls_grid.Length));//obtain the matrix's length/width
                int sum = 0;
                for (int i = 0; i < l; i++)//obtaining the diagnolic elements
                {
                    for (int j = 0; j < l; j++)
                    {
                        if (i == j)
                        {
                            sum = sum + bulls_grid[i, j];//First, add all of the left diagnol elements.
                        }
                        else if (i + j == (l - 1))
                        {
                            sum = sum + bulls_grid[i, j];//Later, you can add the right diagnol elements.
                        }
                    }
                }
                return sum;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }
        private static string RestoreString(string bulls_string, int[] indices)
        {
            try
            {
                int len = indices.Length;//get length of array
                if (len > 100)//user defined exceptions
                {
                    throw new MaxLength(len);
                }
                if (bulls_string.Length != indices.Length)//user defined exceptions
                {
                    throw new NotSame();
                }
                if (bulls_string.Any(char.IsUpper))//user defined exceptions
                {
                    throw new Upper();
                }
                if (indices.Distinct().Count() != indices.Length)//user defined exceptions
                {
                    throw new Repeat();
                }
                foreach (int i in indices)
                {
                    if (i > bulls_string.Length)
                    {
                        throw new OutOflength();
                    }
                }
                string result = "";
                for (int i = 0; i < len; i++)
                {
                    int n = Array.IndexOf(indices, i);//getting index value from indices
                    result = result + bulls_string[n];//adding the char from the bull_string to the final string at the index we got earlier
                }
                return result;//return string
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        private static string ReversePrefix(string bulls_string6, char ch)
        {
            try
            {
                String prefix_string = "";
                int len = bulls_string6.Length;//obtain the length of the string
                if (bulls_string6.Any(char.IsUpper))//user defined exceptions
                {
                    throw new Upper();
                }
                if (len > 250)//user defined exceptions
                {
                    throw new MaxLength(len);
                }
                int n = bulls_string6.IndexOf(ch, 0, len);//getting the index of the input char
                for (int i = n; i >= 0; i--)
                {
                    prefix_string = prefix_string + bulls_string6[i];//concat reverse part of the string
                }
                for (int i = n + 1; i < len; i++)
                {
                    prefix_string = prefix_string + bulls_string6[i];//concat the remaining part of string
                }
                return prefix_string;//return string
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
[Serializable]
public class MaxLength : Exception
{
    public MaxLength(int l)
    {
        Console.WriteLine("Lenght of input string should be less than " + l);
    }
}
public class MaxValue : Exception
{
    public MaxValue(int i)
    {
        Console.WriteLine("The input value should not be more than 100, as it is now.: " + i);
    }
}
public class Upper : Exception
{
    public Upper()
    {
        Console.WriteLine("Upper case letters appear in the input string.");
    }
}

public class Repeat : Exception
{
    public Repeat()
    {
        Console.WriteLine("All of the values in the indices array should be unique.");
    }
}

public class NotSame : Exception
{
    public NotSame()
    {
        Console.WriteLine("The lengths of the indices and the bull strings are not the same.");
    }
}
public class OutOflength : Exception
{
    public OutOflength()
    {
        Console.WriteLine("The value in the indices exceeds the number of characters in the string.");
    }
}