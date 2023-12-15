namespace Leetcode.Puzzles.puzzles;
public abstract class PuzzleBase
{
    public abstract void PrintOutput(int solutionIndex, params object[] parameters);

    protected T Invoke<T>(Func<T> action)
    {
        int start = Environment.TickCount;
        T ret = action();
        int total = Environment.TickCount - start;
        Console.WriteLine($"Time Taken: {total} milliseconds");

        return ret;
    }
}