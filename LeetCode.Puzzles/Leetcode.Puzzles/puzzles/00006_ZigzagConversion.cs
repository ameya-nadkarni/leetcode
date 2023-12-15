/*

*/


using System.Text;

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