namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class StartUp
    {
        static void Main(string[] args)
        {
            List<int> universe = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());
            List<int[]> sets = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] set = Console.ReadLine().Split(", ").Select(int.Parse).ToArray(); 
                sets.Add(set);
            }
            List<int[]> result = ChooseSets(sets,universe);
            Print(result);

        }

        public static List<int[]> ChooseSets(IList<int[]> sets, List<int> universe)
        {
            List<int[]> result = new();
            while (universe.Count > 0)
            {
                int[] set = sets.OrderByDescending(x => x.Count(s => universe.Contains(s))).FirstOrDefault();
                universe.RemoveAll(x => set.Contains(x));

                //for (int j = 0; j < set.Length; j++)
                //{
                //    for (int i = 0; i < universe.Count; i++)
                //    {
                //        if (universe[i] == set[j])
                //        {
                //            universe.RemoveAt(i);
                //            i--;
                //        }
                        
                //    }
                //}
                
                result.Add(set);
                sets.Remove(set);
            }

            return result;
        }

        private static void Print(List<int[]> results)
        {
            StringBuilder sb = new();
            sb.AppendLine($"Sets to take ({results.Count}):");
            for (int i = 0; i < results.Count; i++)
            {
                sb.AppendLine($"{{ {string.Join(", ",results[i])} }}");
            }
          
            Console.WriteLine(sb.ToString().Trim());
        }

    }
}
