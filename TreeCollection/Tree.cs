using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using TreeCollection.TestModels.Models;

namespace TreeCollection
{
    

    public class Tree<T> : IEnumerable<T>
    {
        private Node<T> root;
        private bool isReversedReading;

        public Tree(bool isReversedReading = false)
        {
            this.isReversedReading = isReversedReading;
        }

        public void Add(T newElement)
        {
            root = AddToTree(root, newElement);
        }

        private Node<T> AddToTree(Node<T> root, T newElement) 
        {
            Node<T> current = root;
            Node<T> parent = null;

            while (current != null)
            {
                int comparisonResult = Comparer<T>.Default.Compare(newElement, current.Data);

                if (comparisonResult == 0)
                {
                    throw new Exception("The new element is equal to existing one");
                }
                else if (comparisonResult < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else
                {
                    parent = current;
                    current = current.Right;
                }
            }

            Node<T> newNode = new Node<T>(newElement);

            if (parent == null)
            {
                root = newNode;
            }
            else if (Comparer<T>.Default.Compare(newElement, parent.Data) < 0)
            {
                parent.Left = newNode;
            }
            else
            {
                parent.Right = newNode;
            }

            return root;
        }


        public IEnumerator<T> GetEnumerator()
        {

            return new TreeEnumerator<T>(root, isReversedReading);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class TreeEnumerator<T> : IEnumerator<T>
    {
        private Node<T> _root;
        private bool _isReversedReading;
        private List<Node<T>> _nodes;
        private int _currentIndex;

        public TreeEnumerator(Node<T> root, bool isReversedReading)
        {
            _root = root;
            _isReversedReading = isReversedReading;
            _nodes = new List<Node<T>>();
            _currentIndex = -1;
        }

        public T Current => _nodes[_currentIndex].Data;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
           // Reset();
            if (_currentIndex < 0)
            {
                var currentNode = _root;
                var remainingNodes = new List<Node<T>>();

                while (currentNode != null || remainingNodes.Count > 0)
                {
                    while (currentNode != null)
                    {
                        remainingNodes.Add(currentNode);
                        currentNode = _isReversedReading ? currentNode.Right : currentNode.Left;
                    }

                    currentNode = remainingNodes[remainingNodes.Count - 1];
                    remainingNodes.RemoveAt(remainingNodes.Count - 1);

                    if (!currentNode.Visited)
                    {
                        _nodes.Add(currentNode);
                        currentNode.Visited = true;
                    }

                    currentNode = _isReversedReading ? currentNode.Left : currentNode.Right;
                }
            }

            _currentIndex++;
           //if (_currentIndex < _nodes.Count)
           //{
           //    Console.WriteLine($"return {_nodes[_currentIndex].Data}");
           //}
            return _currentIndex < _nodes.Count;
        }

        public void Reset()
        {
           // foreach (var node in _nodes)
           // {
           //     node.Visited = false;
           // }
            _currentIndex = -1;
        }

        public void Dispose()
        {
        }

       
    }


    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public bool Visited { get; set; }

        public Node(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        
            Visited = false;
        }
    }


}