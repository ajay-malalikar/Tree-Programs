using System;
using System.Collections.Generic;
using Tree_Utilities;

namespace Trees_Programs
{
    class Program
    {
        static void Main(string[] args)
        {
            Node parent = null;
            //int[] arr = new int[] { 10, 5, 3, 6, 13, 11, 14 };
            //foreach (var item in arr)
            //{
            //    parent = BST_Operations.Insert(parent, item);
            //}

            //BST_Operations.PreOrder(parent);
            //Console.WriteLine();
            //BST_Operations.InOrder(parent);
            //int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            //parent = BST_Operations.MinHeightTree(arr, 0, arr.Length - 1);
            //BST_Operations.LevelOrderTraversal(parent);
            //Console.WriteLine("\nNumber of Nodes:" + BST_Operations.GetLeafNodes(parent));
            //Console.WriteLine("BFS:");
            //BST_Operations.BFS(parent);
            //Console.WriteLine(BST_Operations.GetHeight(parent));
            //arr = new int[] { 1, 2, 3, 4, 5, 7, 8, 10, 100 };
            //Node parent1 = BST_Operations.MinHeightTree(arr, 0, arr.Length - 1);
            //var ans = BST_Operations.AreSame(parent, parent1);
            //Console.WriteLine(ans);
            //BST_Operations.PreOrder(parent);
            //Console.WriteLine();
            //BST_Operations.PostOrder(parent);
            //Console.WriteLine();
            //Console.WriteLine(BST_Operations.SizeOfTree(parent));
            //parent = new Node(5);
            //parent.left = new Node(2);
            //parent.left.left = new Node(1);
            //parent.left.right = new Node(1);
            //parent.right = new Node(3);
            //parent.right.left = new Node(2);
            //parent.right.left.left = new Node(1);
            //parent.right.left.right = new Node(1); ;
            //parent.right.right = new Node(2);
            //BST_Operations.PreOrder(parent);
            //Console.WriteLine();
            //Console.WriteLine(BST_Operations.CheckSum(parent));
            //int[] arr = new int[] { 2, 2, 3, 5, 8, 10 };
            //parent = BST_Operations.MinHeightTree(arr, 0, arr.Length - 1);
            //BST_Operations.ListAllPaths(parent, "");
            //BST_Operations.DFS(parent);
            parent = new Node(5);
            parent.left = new Node(2);
            parent.left.left = new Node(1);
            parent.left.left.left = new Node(1);
            parent.left.right = new Node(1);
            parent.right = new Node(3);
            parent.right.left = new Node(2);
            parent.right.left.left = new Node(1);
            parent.right.left.right = new Node(1); ;
            parent.right.right = new Node(2);
            Node n = BST_Operations.DeleteLeafs(parent);
            BST_Operations.InOrder(n);
            Console.Read();
        }
    }

    public class BST_Operations
    {
    	public static Node Insert(Node parent, int data)
    	{
    		if(parent == null)
    		{
    			return new Node(data);
    		}
    		if(data <= parent.data)
    		{
    			parent.left = Insert(parent.left, data);
    		}
    		else
    		{
    			parent.right = Insert(parent.right, data);
    		}
    		return parent;
    	}

        public static void InOrder(Node parent)
        {
            if (parent != null)
            {
                InOrder(parent.left);
                Console.Write(parent.data + " ");
                InOrder(parent.right);
            }
        }

        public static void PostOrder(Node parent)
        {
            if (parent != null)
            {
                PostOrder(parent.left);
                PostOrder(parent.right);
                Console.Write(parent.data + " ");
            }
        }

        public static void PreOrder(Node parent)
        {
            if (parent != null)
            {
                Console.Write(parent.data + " ");
                PreOrder(parent.left);
                PreOrder(parent.right);
            }
        }

        public static Node MinHeightTree(int[] arr, int l, int h)
        {
            if (l > h)
                return null;
        	if(l == h)
        		return new Node(arr[l]);
        	int mid = (l + h) / 2;
        	Node parent = new Node(arr[mid]);
        	parent.left = MinHeightTree(arr, l, mid-1);
        	parent.right = MinHeightTree(arr, mid+1, h);
        	return parent;
        }

        public static int SizeOfTree(Node parent)
        {
        	if(parent == null)
        		return 0;
        	return SizeOfTree(parent.left) + SizeOfTree(parent.right) + 1;
        }

        public static bool AreSame(Node a, Node b)
        {
        	if(a==null && b== null)
        		return true;
        	if(a!=null && b!=null)
        		return a.data == b.data && AreSame(a.left, b.left) && AreSame(a.right, b.right);
        	else return false;
        }

        public static int GetHeight(Node parent)
        {
        	if(parent == null)
        		return 0;
        	int left = GetHeight(parent.left);
        	int right = GetHeight(parent.right);
        	return  1 + Math.Max(left, right);
        }

        public static int GetLeafNodes(Node parent)
        {
        	if(parent == null)
        		return 0;
            if (parent.left == null && parent.right == null)
            {
                Console.Write(parent.data + " ");
                return 1;
            }
        	return GetLeafNodes(parent.left) + GetLeafNodes(parent.right);
        }

        public static void BFS(Node parent)
        {
        	Queue<LevelNode> queue = new Queue<LevelNode>();
        	queue.Enqueue(new LevelNode(parent, 1));
        	LevelNode lNode = null;
        	int cuurentLevel = 0;
        	while(queue.Count != 0)
        	{
                lNode = queue.Dequeue();
        		if(cuurentLevel != lNode.level)
                {
                    ++cuurentLevel;
                    Console.WriteLine("\nLevel " + cuurentLevel + ":");
        		}
        		Console.Write(lNode.node.data + " ");
        		if(lNode.node.left != null)
        		{
        			queue.Enqueue(new LevelNode(lNode.node.left, lNode.level+1));

        		}
        		if(lNode.node.right != null)
        		{
        			queue.Enqueue(new LevelNode(lNode.node.right, lNode.level+1));
        		}
        	}
        }

        public static void LevelOrderTraversal(Node parent)
        {
        	int height = GetHeight(parent);
        	for(int i=1; i<= height; i++)
        	{
                Console.WriteLine("Level" + i + ": ");
        		PrintLevel(parent, i);
                Console.WriteLine();
        	}
        }	

       	static void PrintLevel(Node parent, int level)
       	{
       		if(parent == null) return;
       		if(level == 1)
       		{
       			Console.Write(parent.data + " ");
       		}
       		else
       		{
       			PrintLevel(parent.left, level-1);
       			PrintLevel(parent.right, level-1);
       		}
       	}

       	public static bool CheckSum(Node parent)
       	{
       		if(parent == null || (parent.left == null && parent.right == null))
       			return true;
            int sum = (parent.left != null ? parent.left.data : 0) + (parent.right != null ? parent.right.data : 0);
       		if(sum != parent.data)
       			return false;
       		else
       			return CheckSum(parent.left) && CheckSum(parent.right);
       	}

       	public static void ListAllPaths(Node parent, string str)
       	{
       		if(parent == null)
       			return;
            str += parent.data;
            if (parent.IsLeafNode())
            {
                Console.WriteLine(str);
                return;
            }
            str += "-->";
            ListAllPaths(parent.left, str);
            ListAllPaths(parent.right, str);
       	}

       	public static void DFS(Node parent)
       	{
       		if(parent == null)
       			return;
       		Console.Write(parent.data + " ");
       		DFS(parent.left);
       		DFS(parent.right);
       	}

       	public static int GetBalanceFactor(Node parent)
       	{
       		if(parent == null)
       			return 0;
       		return GetHeight(parent.left) - GetHeight(parent.right);
       	}

        public static Node DeleteLeafs(Node node)
        {
            if(node == null || node.IsLeafNode())
                return null;
            node.left = DeleteLeafs(node.left);
            node.right = DeleteLeafs(node.right);
            return node;
        }
    }

    class LevelNode
    {
    	public int level;
    	public Node node;
    	public LevelNode(Node node, int level)
    	{
    		this.node = node;
    		this.level = level;
    	}
    }
}


