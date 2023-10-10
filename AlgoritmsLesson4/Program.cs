using System;

namespace AlgoritmsLesson4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string addNumbers = "27,34,17,20,10,5,15,11,14,12,16,40,33,37";
            string deleteNumbers = "33,15,14";

            AVLTree avlTree = new AVLTree();

            // Add nodes
            foreach (var number in addNumbers.Split(','))
            {
                avlTree.Add(int.Parse(number));
            }

            Console.WriteLine("AVL Tree after adding nodes:");
            avlTree.InOrderTraversal();
            Console.WriteLine();

            // Delete nodes
            foreach (var number in deleteNumbers.Split(','))
            {
                avlTree.Delete(int.Parse(number));
            }

            Console.WriteLine("AVL Tree after deleting nodes:");
            avlTree.InOrderTraversal();
        }
    }
}