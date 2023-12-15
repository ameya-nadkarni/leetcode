/*
Given a string s, find the length of the longest 
substring
 without repeating characters.

 

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.

*/

namespace Leetcode.Puzzles.puzzles;

public class LongestSubstringWithoutRepeatingCharactersPuzzle : PuzzleBase
{
    public override void PrintOutput(int solutionIndex, params object[] parameters)
    {
        var s = parameters[0] as String;
        int output = solutionIndex switch
        {
            1 => Invoke(() => { return LengthOfLongestSubstring1(s); }),
            2 => Invoke(() => { return LengthOfLongestSubstring2(s); }),
            _ => throw new NotImplementedException(),
        };
        Console.WriteLine($"Input: s = {s}");
        Console.WriteLine($"Output: {output}");
        Console.WriteLine("-------------------------------------\r\n");
    }

    public int LengthOfLongestSubstring2(string s)
    {
        HashSet<char> set = new();
        int max = 0, left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            while (set.Contains(s[right]))
                set.Remove(s[left++]);
            set.Add(s[right]);
            if (set.Count > max)
                max = set.Count;
        }

        return max;
    }

    public int LengthOfLongestSubstring1(string s)
    {
        var activeBucket = new Dictionary<int, List<char>>();
        var frozenBucket = new Dictionary<int, List<char>>();

        for (int i = 0; i < s.Length; i++)
        {
            activeBucket[i] = new List<char>();
            foreach (var key in activeBucket.Keys)
            {
                if (!activeBucket[key].Contains(s[i]))
                {
                    activeBucket[key].Add(s[i]);
                }
                else
                {
                    frozenBucket[key] = activeBucket[key];
                    activeBucket.Remove(key);
                }
            }
        }
        int max = 0;
        foreach (var key in activeBucket.Keys)
        {
            if (activeBucket[key].Count > max)
                max = activeBucket[key].Count;
        }
        foreach (var key in frozenBucket.Keys)
        {
            if (frozenBucket[key].Count > max)
                max = frozenBucket[key].Count;
        }
        return max;
    }
}