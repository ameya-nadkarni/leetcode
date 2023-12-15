/*
Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.

Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

 

Example 1:

Input: x = 123
Output: 321
Example 2:

Input: x = -123
Output: -321
Example 3:

Input: x = 120
Output: 21
 

Constraints:

-231 <= x <= 231 - 1
*/

namespace Leetcode.Puzzles.puzzles;

public class ReverseIntegerPuzzle : PuzzleBase
{
    public override void PrintOutput(int solutionIndex, params object[] parameters)
    {
        var x = (int)parameters[0];
        int output = solutionIndex switch
        {
            1 => Invoke(() => { return Reverse(x); }),
            _ => throw new NotImplementedException()
        };

        Console.WriteLine($"Input: x = {x}");
        Console.WriteLine($"Output: {output}");
        Console.WriteLine("-------------------------------------\r\n");
    }

    public int Reverse(int x)
    {
        int r = 0;
        int max = int.MaxValue / 10;
        int min = int.MinValue / 10;
        while (x != 0)
        {
            if (min <= r && r <= max)
            {
                r = 10 * r + (x % 10);
                x /= 10;
            }
            else
                return 0;
        }

        return r;
    }
}
