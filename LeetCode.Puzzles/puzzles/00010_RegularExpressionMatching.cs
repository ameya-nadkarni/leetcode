
/*
Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:

'.' Matches any single character.​​​​
'*' Matches zero or more of the preceding element.
The matching should cover the entire input string (not partial).

 

Example 1:

Input: s = "aa", p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
Example 2:

Input: s = "aa", p = "a*"
Output: true
Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
Example 3:

Input: s = "ab", p = ".*"
Output: true
Explanation: ".*" means "zero or more (*) of any character (.)".
 

Constraints:

1 <= s.length <= 20
1 <= p.length <= 20
s contains only lowercase English letters.
p contains only lowercase English letters, '.', and '*'.
It is guaranteed for each appearance of the character '*', there will be a previous valid character to match.
*/

namespace Leetcode.Puzzles.puzzles;

public class RegularExpressionMatching : PuzzleBase
{
    public override void PrintOutput(int solutionIndex, params object[] parameters)
    {
        var s = parameters[0] as string;
        var p = parameters[1] as string;
        bool output = solutionIndex switch
        {
            1 => Invoke(() => { return IsMatch(s, p); }),
            _ => throw new NotImplementedException()
        };

        Console.WriteLine($"Input: s = {s}, p = {p}");
        Console.WriteLine($"Output: {output}");
        Console.WriteLine("-------------------------------------\r\n");
    }

    public bool IsMatch(string s, string p)
    {
        return IsMatching(0, 0, s, p);
    }

    private bool IsMatching(int pIndex, int sIndex, string s, string p)
    {
        if (sIndex >= s.Length)
        {
            while (pIndex + 1 < p.Length && p[pIndex + 1] == '*')
            {
                pIndex += 2;
            }

            return pIndex >= p.Length;
        }
        else if (pIndex >= p.Length)
        {
            return false;
        }
        if (pIndex + 1 < p.Length && p[pIndex + 1] == '*')
        {
            while (sIndex < s.Length && (p[pIndex] == s[sIndex] || p[pIndex] == '.'))
            {
                if (IsMatching(pIndex + 2, sIndex, s, p))
                    return true;
                sIndex++;
            }

            pIndex++;
        }
        else
        {
            if (p[pIndex] == s[sIndex] || p[pIndex] == '.')
                return IsMatching(pIndex + 1, sIndex + 1, s, p);
            return false;
        }

        return IsMatching(pIndex + 1, sIndex, s, p);
    }



    // public bool IsMatch(string s, string p)
    // {
    //     int i = 0;
    //     int indexS = 0;
    //     while (i < p.Length)
    //     {
    //         char current = p[i];
    //         char? next = null;
    //         if (i + 1 < p.Length && p[i + 1] == '*')
    //             i++;

    //         if (i + 1 < p.Length)
    //             next = p[i + 1];

    //         if (p[i] == '*')
    //         {
    //             while (indexS < s.Length)
    //             {
    //                 if (current != '.' && s[indexS] != current)
    //                     break;

    //                 indexS++;

    //                 if (next != null && indexS < s.Length && s[indexS] == next)
    //                     break;
    //             }
    //         }
    //         else if (indexS >= s.Length || current != s[indexS])
    //             break;
    //         else
    //             indexS++;

    //         i++;
    //     }


    //     return i == p.Length && indexS == s.Length;
    // }





    //  public bool IsMatch(string s, string p)
    // {
    //     int indexS = 0;
    //     int i = 0;
    //     var tokens = new List<Tuple<string, int>>();
    //     while (i < p.Length)
    //     {
    //         if (i + 1 < p.Length && p[i + 1] == '*')
    //         {
    //             tokens.Add(Tuple.Create(p.Substring(i, 2), 0));
    //             i++;
    //         }
    //         else
    //             tokens.Add(Tuple.Create(p.Substring(i, 1), 1));
    //         i++;
    //     }

    //     for (i = 0; i < tokens.Count; i++)
    //     {
    //         if (tokens[i].Item2 == 0)
    //         {
    //             tokens[i] = Tuple.Create(tokens[i].Item1, s.Length - tokens.Skip(i + 1).Sum(t => t.Item2));
    //         }
    //     }

    //     i = 0;
    //     while (i < tokens.Count && indexS < s.Length)
    //     {
    //         if (tokens[i].Item1.Length == 2)
    //         {
    //             if (tokens[i].Item1[0] == '.')
    //                 while (indexS < tokens[i].Item2)
    //                 {
    //                     if (i < tokens.Count - 1 && s[indexS] == tokens[i + 1].Item1[0])
    //                         break;

    //                     indexS++;
    //                 }
    //             else
    //                 while (indexS < tokens[i].Item2 && s[indexS] == tokens[i].Item1[0]) indexS++;
    //         }
    //         else
    //         {
    //             if (tokens[i].Item1[0] == '.')
    //                 indexS++;
    //             else
    //             {
    //                 if (s[indexS] == tokens[i].Item1[0])
    //                     indexS++;
    //                 else
    //                     return false;
    //             }
    //         }

    //         i++;
    //     }

    //     if (i < tokens.Count && tokens.Skip(i).Any(t => t.Item1.Length == 1))
    //     {
    //         return false;
    //     }
    //     return indexS == s.Length;
    // }
}