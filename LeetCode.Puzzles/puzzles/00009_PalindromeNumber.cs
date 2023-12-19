
/*

*/

namespace Leetcode.Puzzles.puzzles;

public class PalindromeNumberPuzzle : PuzzleBase
{
    public override void PrintOutput(int solutionIndex, params object[] parameters)
    {
        var s = (int)parameters[0];
        bool output = solutionIndex switch
        {
            1 => Invoke(() => { return IsPalindrome_1(s); }),
            2 => Invoke(() => { return IsPalindrome_2(s); }),
            _ => throw new NotImplementedException()
        };

        Console.WriteLine($"Input: x = {s}");
        Console.WriteLine($"Output: {output}");
        Console.WriteLine("-------------------------------------\r\n");
    }

    public bool IsPalindrome_1(int x)
    {
        if (x < 0)
            return false;
        int len = (int)Math.Floor(Math.Log10(x)) + 1;
        int other = 0;

        for (int i = 0; i < len / 2; i++)
        {
            other = other * 10 + x % 10;
            x /= 10;
        }

        if (len % 2 == 1)
        {
            other = other * 10 + x % 10;
        }
        return x == other;
    }

    public bool IsPalindrome_2(int x)
    {
        if (x < 0)
            return false;
        int x1 = x; 
        int other = 0;

        while (x > 0)
        {
            other = other * 10 + x % 10;
            x /= 10;
        }

        return x1 == other;
    }
}