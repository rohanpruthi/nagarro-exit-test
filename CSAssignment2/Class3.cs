using System;
using System.Collections.Generic;
using System.Linq;

namespace CSAssignment2
{
    class BinaryTree<T>
    {
        T data;//for parent node
        public BinaryTree<T> left;//for left child
        public BinaryTree<T> right;//for right child
        public Queue<BinaryTree<T>> queue = new Queue<BinaryTree<T>>();//queue for level-order traversal
        public Stack<BinaryTree<T>> stack1 = new Stack<BinaryTree<T>>();//stack1 & stack2 for Spiral-Order Traversal.
        public Stack<BinaryTree<T>> stack2 = new Stack<BinaryTree<T>>();

        public BinaryTree<T> newnode(T data)
        {
            BinaryTree<T> BinaryTreeNode = new BinaryTree<T>();
            BinaryTreeNode.data = data;
            BinaryTreeNode.left = null;
            BinaryTreeNode.right = null;
            return BinaryTreeNode;
        }
        /// <summary>
        /// Traverses the tree in level order of tree and adds the nodes to a queue
        /// </summary>
        /// <param name="binaryTree">object of class BinaryTree to be performed action on</param>
        public void LevelOrderTraversal(BinaryTree<T> binaryTree)
        {
            if (binaryTree == null)//if tree have no value simply return.
                return;
            Console.WriteLine(binaryTree.data + ConstantString.InsertSpace);
            if (binaryTree.left != null)                       //if it has left child
                queue.Enqueue(binaryTree.left);                //put it into queue.
            if (binaryTree.right != null)                     //if it has right child
                queue.Enqueue(binaryTree.right);             //put right child into queue.
            if (queue.Count != 0)                           //until queue is emply
                LevelOrderTraversal(queue.Dequeue());       //calling function recursively to traverse all nodes in tree.
        }
        /// <summary>
        /// Traverses the tree in spiral order of tree and adds the nodes to a queue
        /// </summary>
        /// <param name="binaryTree">object of class BinaryTree to be performed action on</param>
        public void SpiralOrderTraversal(BinaryTree<T> binaryTree)
        {
            if (binaryTree.data == null)        //if tree have no value simply return.
                return;
            stack1.Push(binaryTree);            //else push the nodes in stack.
            bool flag = true;                   //keep flag
            BinaryTree<T> poppedElement;
            while (stack1.Count() != default(int) || stack2.Count() != default(int))
            {
                if (flag)                       //if flag is true
                {
                    while (stack1.Count() != default(int)) //empty stack one by pushing and poping items.
                    {
                        poppedElement = stack1.Pop();//pop items and display
                        Console.WriteLine(poppedElement.data + ConstantString.InsertSpace);
                        if (poppedElement.right != null)//if right item is there
                            stack2.Push(poppedElement.right);//push it 
                        if (poppedElement.left != null)//if left item is there push it
                            stack2.Push(poppedElement.left);
                    }
                }
                else
                {
                    while (stack2.Count() != default(int))                  //empty stack two  by pushing and poping items.
                    {
                        poppedElement = stack2.Pop();
                        Console.WriteLine(poppedElement.data + ConstantString.InsertSpace);
                        if (poppedElement.left != null)          //if left item is there 
                            stack1.Push(poppedElement.left);    //push it
                        if (poppedElement.right != null)       //if right item is there
                            stack1.Push(poppedElement.right); //push it
                    }
                }
                flag = !flag;                //make flag false
            }
        }        
    }
}
