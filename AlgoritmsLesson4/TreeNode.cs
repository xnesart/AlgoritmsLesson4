namespace AlgoritmsLesson4
{
    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;
        public int Height;

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
            Height = 1;
        }
    }
}