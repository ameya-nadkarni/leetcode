/*
Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

The overall run time complexity should be O(log (m+n)).

 

Example 1:

Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.
Example 2:

Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
 

Constraints:

nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-106 <= nums1[i], nums2[i] <= 106
*/

using Leetcode.Puzzles.puzzles;

class MedianOfTwoSortedArrays : PuzzleBase
{
    public override void PrintOutput(int solutionIndex, params object[] parameters)
    {
        var nums1 = parameters[0] as int[];
        var nums2 = parameters[1] as int[];
        double output = solutionIndex switch
        {
            1 => Invoke(() => { return FindMedianSortedArrays1(nums1, nums2); }),
            2 => Invoke(() => { return FindMedianSortedArrays2(nums1, nums2); }),
            3 => Invoke(() => { return FindMedianSortedArrays3(nums1, nums2); }),
            _ => throw new NotImplementedException(),
        };
        Console.WriteLine($"Input: nums1 = [{string.Join(", ", nums1)}], nums2 = [{string.Join(", ", nums2)}]");
        Console.WriteLine($"Output: {output}");
        Console.WriteLine("-------------------------------------\r\n");
    }


    public double FindMedianSortedArrays3(int[] nums1, int[] nums2)
    {
        int n1 = 0, n2 = 0, m = 0;

        bool isOdd = (nums1.Length + nums2.Length) % 2 == 1;
        int med = ((nums1.Length + nums2.Length) / 2) + 1;

        int low = 0, high = 0;

        while (n1 < nums1.Length && n2 < nums2.Length && m < med)
        {
            low = high;
            if (nums1[n1] < nums2[n2])
                high = nums1[n1++];
            else
                high = nums2[n2++];
            m++;
        }

        while (n1 < nums1.Length && m < med)
        {
            low = high;
            high = nums1[n1++];
            m++;
        }

        while (n2 < nums2.Length && m < med)
        {
            low = high;
            high = nums2[n2++];
            m++;
        }

        return isOdd ? high : (low + high) / 2.0;
    }

    public double FindMedianSortedArrays2(int[] nums1, int[] nums2)
    {
        int n1 = 0, n2 = 0, m = 0;
        var indices = new List<Tuple<bool, int>>();

        bool isOdd = (nums1.Length + nums2.Length) % 2 == 1;
        int med = ((nums1.Length + nums2.Length) / 2) + 1;

        int num1 = 0, num2 = 0;

        while (m < med)
        {
            num1 = n1 >= nums1.Length ? int.MaxValue : nums1[n1];
            num2 = n2 >= nums2.Length ? int.MaxValue : nums2[n2];
            if (num1 < num2)
            {
                indices.Add(Tuple.Create(true, n1++));
            }
            else if (num1 > num2)
            {
                indices.Add(Tuple.Create(false, n2++));
            }
            else if (n1 < n2)
            {
                indices.Add(Tuple.Create(true, n1++));
            }
            else
            {
                indices.Add(Tuple.Create(false, n2++));
            }
            m++;
        }

        var last = indices.Last();
        num1 = last.Item1 ? nums1[last.Item2] : nums2[last.Item2];
        if (isOdd)
            return Math.Min(num1, num2);
        else
        {
            last = indices[indices.Count - 2];
            num2 = last.Item1 ? nums1[last.Item2] : nums2[last.Item2];
            return (num1 + num2) / 2.0;
        }
    }

    public double FindMedianSortedArrays1(int[] nums1, int[] nums2)
    {
        var merged = nums1.ToList();
        merged.AddRange(nums2);
        merged.Sort();
        var total = nums1.Length + nums2.Length;
        if (total % 2 == 0)
        {
            int i1 = (total / 2) - 1, i2 = (total / 2);
            return (double)(merged[i1] + merged[i2]) / 2.0;
        }
        else
        {
            int i1 = total / 2;
            return (double)merged[i1];
        }
    }
}