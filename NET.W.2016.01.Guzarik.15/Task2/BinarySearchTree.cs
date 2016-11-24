using System;
using System.Collections.Generic;

namespace Task2
{
    /// <summary>
    /// Class represents binary search tree
    /// </summary>
    public sealed class BinarySearchTree<T>
    {
        private Node<T> _root;
        private readonly IComparer<T> _comparer;

        /// <summary>
        /// Returns the number of elements in the tree
        /// </summary>
        public int Count { get; private set; }

        #region Constructors

        /// <summary>
        /// Creates binary search tree with default comparer
        /// </summary>
        public BinarySearchTree() : this(Comparer<T>.Default) { }
        
        /// <summary>
        /// Creates binary search tree on the specified collection
        /// </summary>
        /// <exception cref="ArgumentNullException">The collection is null</exception>
        public BinarySearchTree(IEnumerable<T> collection) : this(collection, Comparer<T>.Default) { }

        /// <summary>
        /// Creates binary search tree on the specified comparer
        /// </summary>
        /// <exception cref="ArgumentNullException">The comparer is null</exception>
        public BinarySearchTree(IComparer<T> comparer)
        {
            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException(nameof(comparer));

            _comparer = comparer;
        }

        /// <summary>
        /// Creates binary search tree on the specified collection and comparer
        /// </summary>
        /// <exception cref="ArgumentNullException">The comparer or the collection is null</exception>
        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer)
        {
            if (ReferenceEquals(collection, null))
                throw new ArgumentNullException(nameof(collection));

            if (ReferenceEquals(comparer, null))
                throw new ArgumentNullException(nameof(comparer));

            _comparer = comparer;
            AddRange(collection);
        }

        #endregion

        #region API

        /// <summary>
        /// Adds a collection to the tree
        /// </summary>
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var variable in collection)
                Add(variable);
        }

        /// <summary>
        /// Adds an item to the tree
        /// </summary>
        /// <exception cref="ArgumentNullException">The item is null</exception>
        public void Add(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException(nameof(item));

            var node = new Node<T>(item);

            if (_root == null)
            {
                _root = node;
                return;
            }

            Node<T> current = _root, parent = null;

            while (current != null)
            {
                parent = current;
                current = _comparer.Compare(item, current.Value) < 0 ? current.Left : current.Right;
            }

            if (_comparer.Compare(item, parent.Value) < 0)
                parent.Left = node;
            else
                parent.Right = node;

            Count++;
        }

        /// <summary>
        /// Removes an item from the tree
        /// </summary>
        /// <exception cref="ArgumentNullException">The item is null</exception>
        /// <exception cref="ArgumentException">The tree is emty or item is not in the tree</exception>
        public void Remove(T item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException(nameof(item));

            if (ReferenceEquals(_root, null))
                throw new ArgumentException("The tree is empty");

            Node<T> current = _root, parent = null;

            int result;
            do
            {
                result = _comparer.Compare(item, current.Value);
                if (result < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result > 0)
                {
                    parent = current;
                    current = current.Right;
                }
                if (current == null)
                    throw new ArgumentException($"{nameof(item)} is not in the tree");
            } while (result != 0);

            if (current.Right == null)
            {
                if (current == _root)
                    _root = current.Left;
                else
                {
                    result = _comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = current.Left;
                    else
                        parent.Right = current.Left;
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (current == _root)
                    _root = current.Right;
                else
                {
                    result = _comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = current.Right;
                    else
                        parent.Right = current.Right;
                }
            }
            else
            {
                Node<T> min = current.Right.Left, prev = current.Right;
                while (min.Left != null)
                {
                    prev = min;
                    min = min.Left;
                }
                prev.Left = min.Right;
                min.Left = current.Left;
                min.Right = current.Right;

                if (current == _root)
                    _root = min;
                else
                {
                    result = _comparer.Compare(current.Value, parent.Value);
                    if (result < 0)
                        parent.Left = min;
                    else
                        parent.Right = min;
                }
            }
            Count--;
        }

        /// <summary>
        /// Clears the tree
        /// </summary>
        public void Clear()
        {
            _root = null;
            Count = 0;
        }

        /// <summary>
        /// Determines whether the tree contains the item
        /// </summary>
        public bool Contains(T item)
        {
            var current = _root;
            while (current != null)
            {
                var result = _comparer.Compare(item, current.Value);
                if (result == 0)
                    return true;
                current = result < 0 ? current.Left : current.Right;
            }

            return false;
        }

        #endregion

        #region Iterators

        /// <summary>
        /// Iterates through the tree
        /// </summary>
        /// <remarks>Order: node, left subtree, right subtree</remarks>
        public IEnumerable<T> Preorder()
        {
            if (_root == null)
                yield break;

            var stack = new Stack<Node<T>>();
            stack.Push(_root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Value;
                if (node.Right != null)
                    stack.Push(node.Right);
                if (node.Left != null)
                    stack.Push(node.Left);
            }
        }

        /// <summary>
        /// Iterates through the tree
        /// </summary>
        /// <remarks>Order: left subtree, node, right subtree</remarks>
        public IEnumerable<T> Inorder()
        {
            if (_root == null)
                yield break;

            var stack = new Stack<Node<T>>();
            var node = _root;

            while (stack.Count > 0 || node != null)
                if (node == null)
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
                else
                {
                    stack.Push(node);
                    node = node.Left;
                }
        }

        /// <summary>
        /// Iterates through the tree
        /// </summary>
        /// <remarks>Order: left subtree, right subtree, node</remarks>
        public IEnumerable<T> Postorder()
        {
            if (_root == null)
                yield break;

            var stack = new Stack<Node<T>>();
            var node = _root;

            while (stack.Count > 0 || node != null)
                if (node == null)
                {
                    node = stack.Pop();
                    if (stack.Count > 0 && node.Right == stack.Peek())
                    {
                        stack.Pop();
                        stack.Push(node);
                        node = node.Right;
                    }
                    else
                    {
                        yield return node.Value;
                        node = null;
                    }
                }
                else
                {
                    if (node.Right != null)
                        stack.Push(node.Right);
                    stack.Push(node);
                    node = node.Left;
                }
        }

        /// <summary>
        /// Iterates through the collection preorder
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return Preorder().GetEnumerator();
        }

        #endregion

        private sealed class Node<TValue>
        {
            public TValue Value { get; set; }
            public Node<TValue> Left { get; set; }
            public Node<TValue> Right { get; set; }

            public Node(TValue value)
            {
                Value = value;
            }
        }
    }
}
