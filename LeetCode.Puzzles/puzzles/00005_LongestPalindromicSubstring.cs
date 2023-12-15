/*
Given a string s, return the longest 
palindromic
 
substring
 in s.

 

Example 1:

Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.
Example 2:

Input: s = "cbbd"
Output: "bb"
 

Constraints:

1 <= s.length <= 1000
s consist of only digits and English letters.

*/

namespace Leetcode.Puzzles.puzzles;

public class LongestPalindromicSubstringPuzzle : PuzzleBase
{
    public override void PrintOutput(int solutionIndex, params object[] parameters)
    {
        var s = parameters[0] as string;
        string output = solutionIndex switch
        {
            1 => Invoke(() => { return LongestPalindrome_1(s); }),
            _ => throw new NotImplementedException()
        };

        Console.WriteLine($"Input: s = {s}");
        Console.WriteLine($"Output: {output}");
        Console.WriteLine("-------------------------------------\r\n");
    }

    public string LongestPalindrome_1(string s)
    {
        int index = -1, length = -1;
        bool odd, even;
        for (int i = 0; i < s.Length; i++)
        {
            odd = even = true;
            for (int j = 0; j <= Math.Min(i, s.Length - i - 1); j++)
            {
                if (odd && s[i - j] == s[i + j])
                {
                    int l = 2 * j + 1;
                    if (length < l)
                    {
                        index = i;
                        length = l;
                    }
                }
                else
                    odd = false;

                if (even && (i + j < s.Length - 1) && s[i - j] == s[i + j + 1])
                {
                    int l = 2 * j + 2;
                    if (length < l)
                    {
                        index = i;
                        length = l;
                    }
                }
                else
                    even = false;
            }
        }


        return s.Substring(index - (length - 1) / 2, length);
    }
}