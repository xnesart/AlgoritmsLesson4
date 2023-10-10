using System;

namespace AlgoritmsLesson4
{
    public class AVLTree
    {
        private TreeNode root;

        public void Add(int value)
        {
            root = AddRecursive(root, value);
        }

        private TreeNode AddRecursive(TreeNode node, int value)
        {
            if (node == null)
            {
                return new TreeNode(value);
            }

            if (value < node.Value)
            {
                node.Left = AddRecursive(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = AddRecursive(node.Right, value);
            }
            else
            {
                // Duplicate values are not allowed
                return node;
            }

            // Update height
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            // Perform balancing
            int balance = GetBalance(node);

            // Left Left Case
            if (balance > 1 && value < node.Left.Value)
            {
                return RightRotate(node);
            }

            // Right Right Case
            if (balance < -1 && value > node.Right.Value)
            {
                return LeftRotate(node);
            }

            // Left Right Case
            if (balance > 1 && value > node.Left.Value)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && value < node.Right.Value)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        public void Delete(int value)
        {
            root = DeleteRecursive(root, value);
        }

        private TreeNode DeleteRecursive(TreeNode root, int value)
        {
            if (root == null)
            {
                return root;
            }

            if (value < root.Value)
            {
                root.Left = DeleteRecursive(root.Left, value);
            }
            else if (value > root.Value)
            {
                root.Right = DeleteRecursive(root.Right, value);
            }
            else
            {
                // Node with only one child or no child
                if (root.Left == null || root.Right == null)
                {
                    TreeNode temp = (root.Left == null) ? root.Right : root.Left;

                    // No child case
                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }
                    else // One child case
                    {
                        root = temp; // Copy the contents of the non-empty child
                    }
                }
                else
                {
                    // Node with two children: Get the inorder successor (smallest
                    // in the right subtree)
                    TreeNode temp = FindMinValueNode(root.Right);

                    // Copy the inorder successor's data to this node
                    root.Value = temp.Value;

                    // Delete the inorder successor
                    root.Right = DeleteRecursive(root.Right, temp.Value);
                }
            }

            // If the tree had only one node then return
            if (root == null)
            {
                return root;
            }

            // Update height of current node
            root.Height = 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right));

            // Perform balancing
            int balance = GetBalance(root);

            // Left Left Case
            if (balance > 1 && GetBalance(root.Left) >= 0)
            {
                return RightRotate(root);
            }

            // Left Right Case
            if (balance > 1 && GetBalance(root.Left) < 0)
            {
                root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            }

            // Right Right Case
            if (balance < -1 && GetBalance(root.Right) <= 0)
            {
                return LeftRotate(root);
            }

            // Right Left Case
            if (balance < -1 && GetBalance(root.Right) > 0)
            {
                root.Right = RightRotate(root.Right);
                return LeftRotate(root);
            }

            return root;
        }

        private TreeNode FindMinValueNode(TreeNode root)
        {
            TreeNode current = root;
            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        private int GetHeight(TreeNode node)
        {
            return (node == null) ? 0 : node.Height;
        }

        private int GetBalance(TreeNode node)
        {
            return (node == null) ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }

        private TreeNode RightRotate(TreeNode y)
        {
            TreeNode x = y.Left;
            TreeNode T2 = x.Right;

            // Perform rotation
            x.Right = y;
            y.Left = T2;

            // Update heights
            y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));
            x.Height = 1 + Math.Max(GetHeight(x.Left), GetHeight(x.Right));

            // Return new root
            return x;
        }

        private TreeNode LeftRotate(TreeNode x)
        {
            TreeNode y = x.Right;
            TreeNode T2 = y.Left;

            // Perform rotation
            y.Left = x;
            x.Right = T2;

            // Update heights
            x.Height = 1 + Math.Max(GetHeight(x.Left), GetHeight(x.Right));
            y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));

            // Return new root
            return y;
        }

        public void InOrderTraversal()
        {
            InOrderTraversalRecursive(root);
        }

        private void InOrderTraversalRecursive(TreeNode node)
        {
            if (node != null)
            {
                InOrderTraversalRecursive(node.Left);
                Console.Write(node.Value + " ");
                InOrderTraversalRecursive(node.Right);
            }
        }
    }
}