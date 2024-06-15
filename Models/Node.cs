namespace LinearRegressionCalculator.Models
{
    public class Node<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
}
