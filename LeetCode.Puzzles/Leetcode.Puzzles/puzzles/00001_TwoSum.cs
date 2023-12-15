/*
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one TwoSum, and you may not use the same element twice.

You can return the answer in any order.

 

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]
Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]

*/

namespace Leetcode.Puzzles.puzzles;

public class TwoSumPuzzle : PuzzleBase
{
    public override void PrintOutput(int solutionIndex, params object[] parameters)
    {
        int[] output = solutionIndex switch
        {
            1 => Invoke(() => { return TwoSum_1(parameters[0] as int[], (int)parameters[1]); }),
            2 => Invoke(() => { return TwoSum_2(parameters[0] as int[], (int)parameters[1]); }),
            3 => Invoke(() => { return TwoSum_3(parameters[0] as int[], (int)parameters[1]); }),
            4 => Invoke(() => { return TwoSum_4(parameters[0] as int[], (int)parameters[1]); }),
            _ => throw new NotImplementedException()
        };

        Console.WriteLine($"[{string.Join(", ", output)}]");
    }

    public int[] TwoSum_1(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new[] { i, j };
                }
            }
        }

        return new[] { -1, -1 };
    }

    public int[] TwoSum_2(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (i != j && nums[i] + nums[j] == target)
                {
                    return new[] { i, j };
                }
            }

        }

        return new[] { -1, -1 };
    }
    public int[] TwoSum_3(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (i != j && nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }

        }

        return new[] { -1, -1 };
    }

    public int[] TwoSum_4(int[] nums, int target)
    {
        var sums = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int spare = target - nums[i];
            if (sums.TryGetValue(spare, out int index))
                return new int[] { i, index };

            if (!sums.ContainsKey(nums[i]))
                sums[nums[i]] = i;
        }

        return new[] { -1, -1 };
    }
}