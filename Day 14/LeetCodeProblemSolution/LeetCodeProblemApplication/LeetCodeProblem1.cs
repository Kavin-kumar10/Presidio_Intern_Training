namespace LeetCodeProblemApplication
{
    public class LeetCodeProblem1
    {
        public async Task<int> MinimumDepth(TreeNode root)
        {
            if (root == null) return 0;
            if (root.Left == null && root.Right == null) return 1;
            if(root.Left == null) return 1 + await MinimumDepth(root.Right);
            if(root.Right == null) return 1 + await MinimumDepth(root.Left);
            return 1 + Math.Min(await MinimumDepth(root.Left),await MinimumDepth(root.Right));
        }

        public async Task GetTreeMinDepthValuesAsync()
        {
            int[] values = { 3, 9, 20, -1, -1, 15, 7 };
            TreeBuilder builder = new TreeBuilder();
            TreeNode root = builder.BuildTree(values);
            Console.WriteLine("The Minimum depth of the given Tree is : "+await MinimumDepth(root));
        }
        public static void Main(string[] args)
        {
            LeetCodeProblem1 program = new LeetCodeProblem1();
            program.GetTreeMinDepthValuesAsync();
        }
    }
}
