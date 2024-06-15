namespace LinearRegressionCalculator.Models
{

        public class BST<T> where T : IComparable<T>
        {
            public Node<T> root;

            public int size;
            public BST()
            {
                root = null;
                size = 0;
            }

            public void Insert(T value)
            {
                root = InsertRec(root, value);
                size++;
            }

            private Node<T> InsertRec(Node<T> root, T value)
            {
                if (root == null)
                {
                    root = new Node<T>(value);
                    return root;
                }

                if (value.CompareTo(root.Value) < 0)
                {
                    root.Left = InsertRec(root.Left, value);
                }
                else if (value.CompareTo(root.Value) > 0)
                {
                    root.Right = InsertRec(root.Right, value);
                }

                return root;
            }

            public bool Search(T value)
            {
                return SearchRec(root, value) != null;
            }

            private Node<T> SearchRec(Node<T> root, T value)
            {
                if (root == null || root.Value.CompareTo(value) == 0)
                {
                    return root;
                }

                if (value.CompareTo(root.Value) < 0)
                {
                    return SearchRec(root.Left, value);
                }
                else
                {
                    return SearchRec(root.Right, value);
                }
            }

            public void Delete(T value)
            {
                root = DeleteRec(root, value);
                size--;
            }

            private Node<T> DeleteRec(Node<T> root, T value)
            {
                if (root == null)
                {
                    return root;
                }

                if (value.CompareTo(root.Value) < 0)
                {
                    root.Left = DeleteRec(root.Left, value);
                }
                else if (value.CompareTo(root.Value) > 0)
                {
                    root.Right = DeleteRec(root.Right, value);
                }
                else
                {
                    if (root.Left == null)
                    {
                        return root.Right;
                    }
                    else if (root.Right == null)
                    {
                        return root.Left;
                    }

                    root.Value = MinValue(root.Right);
                    root.Right = DeleteRec(root.Right, root.Value);
                }

                return root;
            }

            private T MinValue(Node<T> root)
            {
                T minValue = root.Value;
                while (root.Left != null)
                {
                    minValue = root.Left.Value;
                    root = root.Left;
                }
                return minValue;
            }

            public void InOrderTraversal(Action<T> action)
            {
                InOrderRec(root, action);
            }

            private void InOrderRec(Node<T> root, Action<T> action)
            {
                if (root != null)
                {
                    InOrderRec(root.Left, action);
                    action(root.Value);
                    InOrderRec(root.Right, action);
                }
            }


            ////////////////////////////////////////////////////////////////////////////////////////////

            public List<T> InOrderTraversalToList()
            {
                List<T> list = new List<T>();
                InOrderRec(root, list);
                return list;
            }

            private void InOrderRec(Node<T> root, List<T> list)
            {
                if (root != null)
                {
                    InOrderRec(root.Left, list);
                    list.Add(root.Value);
                    InOrderRec(root.Right, list);
                }
            }
        }
    }

