
using System.Runtime.InteropServices;
using TreeCollection;

namespace Program

{
    internal class Program
    {
        static void Main(string[] args)
        {
          
             var tree = new Tree<int>(false);
             foreach (var item in new[] { 3, 4, 2, 1, 6, 7, 5, 9, 15, 12, 14, 13, 10, 0, -7, -1, -9, -2, -3, -8 })
             {
                 tree.Add(item);
             }
          
           // var source = new[] { 3, 4, 2 };
           // var tree = new Tree<int>();
           //
           // foreach (var item in source)
           // {
           //     tree.Add(item);
           // }
           //
           // // Action
           //
           // var actual = new List<int>();
           //
           // foreach (var _ in tree)
           // {
           //     foreach (var item in tree)
           //     {
           //         actual.Add(item);  
           //     }
           // }
           //
            

        }
    }
}
