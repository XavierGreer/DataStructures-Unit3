using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Unit3_1
{
    //Node Class for BinaryTree
    public class Node
    {
        public int Data;
        public Node Left = null, Right = null;
        public Node(int data)
        {
            this.Data = data;
        }
    }

    //BinaryTree Class implementation
    public class BinaryTree
    {
        public Node root;
        public BinaryTree()
        {
            root = null;
        }

        //in-order traversal method
        public void InOrder(Node node)
        {
            if (node == null)
                return;
            InOrder(node.Left);
            Console.Write(node.Data + " ");
            InOrder(node.Right);

        }

        //pre-order traversal method
        public void PreOrder(Node node)
        {
            if (node == null)
                return;
            Console.Write(node.Data + " ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }

        //post-order traversal method
        public void PostOrder(Node node)
        {
            if (node == null)
                return;
            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.Write(node.Data + " ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //initialize binary tree object
            BinaryTree binary = new BinaryTree();

            //Adding elements to binary tree
            binary.root = new Node(8);
            binary.root.Left = new Node(5);
            binary.root.Left.Left = new Node(9);
            binary.root.Left.Right = new Node(7);
            binary.root.Left.Right.Right = new Node(12);
            binary.root.Left.Right.Left = new Node(1);
            binary.root.Left.Right.Right.Left = new Node(2);
            binary.root.Right = new Node(4);
            binary.root.Right.Right = new Node(11);
            binary.root.Right.Right.Left = new Node(3);

            //Print In-Order traversal output
            Console.Write("In-order traversal - \t");
            binary.InOrder(binary.root);

            //Print Pre-Order traversal output
            Console.Write("\nPre-order traversal - \t");
            binary.PreOrder(binary.root);

            //Print Post-Order traversal output
            Console.Write("\nPost-order traversal - \t");
            binary.PostOrder(binary.root);
        }
    }
}