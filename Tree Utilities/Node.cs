using System;

namespace Tree_Utilities
{
    public class Node
    {
    	public int data;
    	public Node left;
    	public Node right;

    	public Node(int data)
    	{
    		this.data = data;
    	}

    	public bool IsLeafNode()
    	{
    		if(this.left == null && this.right==null)
    			return true;
    		return false;
    	}
    }
}
