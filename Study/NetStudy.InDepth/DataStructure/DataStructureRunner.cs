using System;
using NetStudy.Core;
using System.Collections.Generic;

namespace NetStudy.InDepth.DataStructure
{
    public class DataStructureRunner : IRunner
    {
        public void Run()
        {
            var root = GetRootNode();

            Console.WriteLine("BFSWithQueue");
            BFSWithQueue(root);
            Console.WriteLine("PreOrderWithRecursion");
            PreOrderWithRecursion(root);
            Console.WriteLine("PreOrderWithStack");
            PreOrderWithStack(root);
            Console.WriteLine("InOrderWithRecursion");
            InOrderWithRecursion(root);
            Console.WriteLine("InOrderWithStack");
            InOrderWithStack(root);
            Console.WriteLine("PostOrderWithRecursion");
            PostOrderWithRecursion(root);
            Console.WriteLine("PostOrderWithStack");
            PostOrderWithStack(root);
        }

        private void BFSWithQueue(TreeNode root)
        {
            if (root == null)
                return;
            Queue<TreeNode> queue = new Queue<TreeNode>();

            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                Console.WriteLine(currentNode.Val);
                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }
                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }
            }
        }
        void PostOrderWithStack(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();
            stack.Push(treeNode);
            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                stack2.Push(currentNode);
                //PostORder Left first
                if (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }
                if (currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }
            }
            while (stack2.Count > 0)
            {
                var currentNode = stack2.Pop();
                Console.WriteLine(currentNode.Val);
            }
        }

        void PreOrderWithStack(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(treeNode);
            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                Console.WriteLine(currentNode.Val);
                //PreOrder Right first
                if (currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }
                if (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }
            }
        }

        void InOrderWithStack(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();
            var currentNode = treeNode;

            while (stack.Count > 0 || currentNode != null)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = stack.Pop();
                    Console.WriteLine(currentNode.Val);
                    currentNode = currentNode.Right;
                }
            }
        }

        void PreOrderWithRecursion(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return;
            }

            Console.WriteLine(treeNode.Val);
            PreOrderWithRecursion(treeNode.Left);
            PreOrderWithRecursion(treeNode.Right);
        }

        void PostOrderWithRecursion(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return;
            }

            PostOrderWithRecursion(treeNode.Left);
            PostOrderWithRecursion(treeNode.Right);
            Console.WriteLine(treeNode.Val);
        }

        void InOrderWithRecursion(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return;
            }
            InOrderWithRecursion(treeNode.Left);
            Console.WriteLine(treeNode.Val);
            InOrderWithRecursion(treeNode.Right);
        }

        public TreeNode GetRootNode()
        {
            var treeNode = new TreeNode(1);
            treeNode.Left = new TreeNode(2);
            treeNode.Right = new TreeNode(3);
            treeNode.Left.Left = new TreeNode(4);
            treeNode.Left.Right = new TreeNode(5);
            treeNode.Right.Left = new TreeNode(6);
            treeNode.Right.Right = new TreeNode(7);
            treeNode.Left.Left.Left = new TreeNode(8);
            treeNode.Left.Left.Right = new TreeNode(9);
            treeNode.Left.Right.Left = new TreeNode(10);
            treeNode.Left.Right.Right = new TreeNode(11);
            treeNode.Right.Left.Left = new TreeNode(12);
            treeNode.Right.Left.Right = new TreeNode(13);
            treeNode.Right.Right.Left = new TreeNode(14);
            treeNode.Right.Right.Right = new TreeNode(15);

            return treeNode;
        }
    }
}
