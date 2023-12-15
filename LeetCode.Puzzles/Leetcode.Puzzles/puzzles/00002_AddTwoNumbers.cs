/*
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

 

Example 1:


Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.
Example 2:

Input: l1 = [0], l2 = [0]
Output: [0]
Example 3:

Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]
 

Constraints:

The number of nodes in each linked list is in the range [1, 100].
0 <= Node.val <= 9
It is guaranteed that the list represents a number that does not have leading zeros.

*/


namespace Leetcode.Puzzles.puzzles;

// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public override string ToString()
    {
        var output = this;
        var sb = new System.Text.StringBuilder();
        sb.Append("[");
        while (output != null)
        {
            sb.Append(output.val.ToString() + ",");
            output = output.next;
        }

        sb.Append("]");
        return sb.ToString();
    }

    public static ListNode FromArray(int[] numbers)
    {
        ListNode root = new ListNode(numbers[0]);
        ListNode previous = root;

        for (int i = 1; i < numbers.Length; i++)
        {
            var current = new ListNode(numbers[i]);
            previous.next = current;
            previous = current;
        }

        return root;
    }
}

public class AddTwoNumbersPuzzle : PuzzleBase
{
    public override void PrintOutput(int solutionIndex, params object[] parameters)
    {
        var l1 = parameters[0] as ListNode;
        var l2 = parameters[1] as ListNode;
        ListNode output = solutionIndex switch
        {
            1 => Invoke(() => { return AddTwoNumbers(l1, l2); }),
            _ => throw new NotImplementedException(),
        };
        Console.WriteLine($"Input: l1 = {l1}, l2 = {l2}");
        Console.WriteLine($"Output: {output.ToString()}");
        Console.WriteLine("-------------------------------------\r\n");
    }

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode root = new();
        ListNode latest = root;

        while (l1 != null || l2 != null)
        {
            latest.val += (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val);
            l1 = l1?.next;
            l2 = l2?.next;

            if (latest.val > 9)
            {
                latest.val -= 10;
                latest.next = new ListNode(1);
            }
            else if (l1 != null || l2 != null)
            {
                latest.next = new ListNode();
            }

            latest = latest.next;
        }

        return root;
    }
}