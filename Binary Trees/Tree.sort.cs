﻿...
    class Program
    {
        ...
            // данные для сортировки
            int[] arr = new int[12] {5, 10, 0, 8, -12, 11, 5, -8, 15, 8, 10, 14};

            // заполнение
            int f;
            Tree<int> tree = new Tree<int>(arr[f = 0]);
            for (f++; f < arr.Length; ++f)
            { tree.Insert(arr[f]); }

            Console.WriteLine(tree.Result());
            // -12  -8  0  5  5  8  8  10  10  11  14  15
    }

    class Tree<T> where T : IComparable<T>
    {
        private T Node { get; set; }        // узел
        private Tree<T> Left { get; set; }  // левое поддерево
        private Tree<T> Right { get; set; } // правое поддерево

        public Tree(T param)
        {
            this.Node = param;
            this.Left = null;
            this.Right = null;
        }

        public void Insert(T param)         // построение двоичного дерева
        {
            T CurrentNode = this.Node;

            if(CurrentNode.CompareTo(param) > 0)
            {
                if(this.Left == null)
                    this.Left = new Tree<T>(param);
                else
                    this.Left.Insert(param);
            }
            else
            {
                if(this.Right == null)
                    this.Right = new Tree<T>(param);
                else
                    this.Right.Insert(param);
            }
        }

        public string Result()              // обход узлов в необходимом порядке
        {                                   // вывод упорядоченных значений дерева
            string result = "";

            if(this.Left != null)
                result = this.Left.Result();

            result += $" {this.Node.ToString()} ";

            if(this.Right != null)
                result += this.Right.Result();

            return result;
        }
    }
