using System;

namespace Main
{
    class MyBinaryTree<E> : IMyCollection<E> where E : IComparable<E>
    {
        private Node root;
        int size;

        public MyBinaryTree() {
            size = 0;
        }

        public MyBinaryTree(E element)
        {
            root = new Node(element);
            size = 1;
        }

        public MyBinaryTree(E[] elements)
        {
            size = elements.Length;
            for (int i = 0; i < elements.Length; i++)
                Add(elements[i]);
        }

        public bool Add(E element)
        {
            bool added = false;
            Node temp = new Node(element);

            if (root == null)
            {
                root = temp;
                added = true;
            }   
            else
            {
                added = Add(root, element);
            }

            if (added)
                size++;

            return added;
        }

        private bool Add(Node current, E element) {
            bool added = false;
            int comp = element.CompareTo(current.element);

            if (comp < 0)
            {
                if (current.left != null)
                    added = Add(current.left, element);
                else
                {
                    current.left = new Node(element);
                    added = true;
                }
            }
            else if (comp > 0)
            {
                if (current.right != null)
                    added = Add(current.right, element);
                else
                {
                    current.right = new Node(element);
                    added = true;
                }
            }
            else
            {
                Console.WriteLine("Element already in tree, no duplicates allowed!");
            }

            return added;
        }

        public bool Contains(E element)
        {
            bool found = false;

            found = Contains(root, element);

            return found;
        }

        private bool Contains(Node current, E element)
        {
            bool found = false;
            int comp = element.CompareTo(current.element);

            if (comp < 0)
            {
                if (current.left != null)
                    found = Contains(current.left, element);
            }
            else if (comp > 0)
            {
                if (current.right != null)
                    found = Contains(current.right, element);
            }
            else if (comp == 0)
            {
                found = true;
            }

            return found;
        }

        public bool Remove(E element)
        {
            bool removed = false;

            if(root.element.CompareTo(element) == 0)
            {
                removed = RemoveRoot();
            }
            else
            {
                removed = Remove(root, element);
            }

            if (removed)
                size--;

            return removed;
        }

        private bool Remove(Node current, E element)
        {
            bool removed = false;
            int comp = element.CompareTo(current.element);

            if (comp < 0)
            {
                if (current.left != null)
                    if (current.left.element.CompareTo(element) == 0)
                    {
                        RemoveLeftChild(current);
                        removed = true;
                    }
                    else
                        removed = Remove(current.left, element);
            }
            else if (comp > 0)
            {
                if (current.right != null)
                    if (current.right.element.CompareTo(element) == 0)
                    {
                        RemoveRightChild(current);
                        removed = true;
                    }
                    else
                        removed = Remove(current.right, element);
            }
        
            return removed;
        }

        private void RemoveLeftChild(Node current)
        {
            if(current.left.right != null && current.left.left != null)
            {
                Node temp = FindLeftMostChild(current.left.left);
                if (temp.element.CompareTo(current.left.left.element) != 0)
                {
                    temp.left = current.left.left;
                }

                temp.right = current.left.right;
                current.left = temp;
            }
            else if (current.left.right == null)
                current.left = current.left.left;
            else if (current.left.left == null)
                current.left = current.left.right;
        
        }

        private void RemoveRightChild(Node current)
        {
            if (current.right.left != null && current.right.right != null)
            {
                Node temp = FindLeftMostChild(current.right.right);
                if(temp.element.CompareTo(current.right.right.element) != 0)
                {
                    temp.right = current.right.right;
                }

                temp.left = current.right.left;
                current.right = temp;
            }
            else if (current.right.left == null)
                current.right = current.right.right;
            else if (current.right.right == null)
                current.right = current.right.left;
        }

        private bool RemoveRoot()
        {
            bool removed = false;

            if (root.left != null)
            {
                Node temp = FindRightMostChild(root.left);
                temp.right = root.right;
                root = root.left;
                removed = true;
            }
            else if (root.right != null)
            {
                Node temp = FindLeftMostChild(root.right);
                temp.left = root.left;
                root = root.right;
                removed = true;
            }
            else
            {
                root = null;
            }

            return removed;
        }

        private Node FindRightMostChild(Node current)
        {
            Node temp = current;

            if(current.right != null)
            {
                while (current.right.right != null)
                {
                    current = current.right;
                }

                temp = current.right;
                current.right = null;
            }
            

            return temp;
        }

        private Node FindLeftMostChild(Node current)
        {
            Node temp = current;

            if (current.left != null)
            {
                while (current.left.left != null)
                {
                    current = current.left;
                }

                temp = current.left;
                current.left = null;
            }
            
            return temp;
        }

        public int Size()
        {
            return size;
        }

        public override string ToString()
        {
            string output = "";
            output = BuildString(root);
            return output.Remove(output.Length - 2, 2);
        }

        private string BuildString(Node current)
        {
            string output = "";

            if (current.left != null)
                output += BuildString(current.left);

            output += current.element.ToString() + ", ";

            if (current.right != null)
                output += BuildString(current.right);
            
            return output;
        }

        public class Node
        {
            public Node left;
            public Node right;
            public E element;
            
            public Node(E element)
            {
                this.element = element;
            }
        }
        
    }
}
