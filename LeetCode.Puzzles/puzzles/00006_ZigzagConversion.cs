/*
The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
 

Example 1:

Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"
Example 2:

Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I
Example 3:

Input: s = "A", numRows = 1
Output: "A"
 

Constraints:

1 <= s.length <= 1000
s consists of English letters (lower-case and upper-case), ',' and '.'.
1 <= numRows <= 1000

*/


namespace Leetcode.Puzzles.puzzles;

public class ZigzagConversionPuzzle : PuzzleBase
{
    public override void PrintOutput(int solutionIndex, params object[] parameters)
    {
        var s = parameters[0] as string;
        var numRows = (int)parameters[1];
        string output = solutionIndex switch
        {
            1 => Invoke(() => { return Convert_1(s, numRows); }),
            2 => Invoke(() => { return Convert_2(s, numRows); }),
            _ => throw new NotImplementedException()
        };

        Console.WriteLine($"Input: s = {s}, numRows = {numRows}");
        Console.WriteLine($"Output: {output}");
        Console.WriteLine("-------------------------------------\r\n");
    }

    public string Convert_2(string s, int numRows)
    {
        if (numRows == 1)
            return s;
        var r = new string[numRows];
        bool down = false;

        for (int i = 0, index = 0; i < s.Length; i++)
        {
            r[index] += s[i];
            if (index == numRows - 1 || index == 0)
                down = !down;

            index += down ? 1 : -1;
        }

        return string.Join(string.Empty, r);
    }

    public string Convert_1(string s, int numRows)
    {
        if (numRows == 1)
            return s;
        int size = numRows + numRows - 2;
        int sliceLength = (int)Math.Ceiling((double)s.Length / size);
        var slices = new Dictionary<int, List<char>>();

        for (int i = 0; i < sliceLength; i++)
        {
            int min = i * size;
            int max = Math.Min(s.Length, min + size);

            for (int j = min; j < max; j++)
            {
                int index = Math.Abs((j % size) - (size / 2));
                if (slices.ContainsKey(index))
                    slices[index].Add(s[j]);
                else
                    slices[index] = new List<char> { s[j] };
            }
        }

        return new string(slices.Values.SelectMany(l => l).ToArray());
    }
}