using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2020
{
    public static class Day7
    {
        public static int Day7A()
        {
            string[] lines = File.ReadAllLines("Inputs/Day7A.txt");

            var bags = new List<Bag>();

            foreach (string line in lines)
            {
                var item = line.Split(" bags");
                var value = line.Split("contain ")[1];
                var values = value.Split(", ");
                var contents = new List<string>();
                var containsGold = false;

                foreach (var bag in values)
                {
                    var items = bag.Split(" ");
                    contents.Add($"{items[1]} {items[2]}");
                }

                if (item[0] != "shiny gold" && values[0] != "no other bags.")
                {
                    foreach (var bag in contents)
                    {
                        FindGold(bag, item[0], ref bags, ref containsGold);
                    }
                }
                
                bags.Add(new Bag { Type = item[0], Contents = contents, ContainsGold = containsGold });
            }

            return bags.Where(x=>x.ContainsGold).ToArray().Length;
        }

        public static long Day7B()
        {
            string[] lines = File.ReadAllLines("Inputs/Day7A.txt");
            var dict = new Dictionary<string, List<ContentCount>>();

            foreach (string line in lines)
            {
                var item = line.Split(" bags");
                var value = line.Split("contain ")[1];
                var values = value.Split(", ");
                var contentCounts = new List<ContentCount>();

                foreach (var bag in values)
                {
                    if(bag != "no other bags.")
                    {
                        var items = bag.Split(" ");
                        contentCounts.Add(new ContentCount($"{items[1]} {items[2]}", int.Parse(items[0])));
                    }
                }

                if (!dict.TryAdd(item[0], contentCounts))
                    Console.WriteLine(item[0]);
            }

            long count = 0;

            var gold = dict.First(x => x.Key == "shiny gold");

            foreach (var i in gold.Value)
            {
                count += GetCount(dict, i, i.Count, 0);
            }

            return count;
        }

        private static void FindGold(string bag, string type, ref List<Bag> bags, ref bool containsGold)
        {
            if (bag == "shiny gold" || bags.Find(x => x.ContainsGold && x.Type == bag) != null)
            {
                containsGold = true;

                var listToCheck = new List<string>();

                var queue = new Queue<string>();

                foreach (var b in bags.Where(x => !x.ContainsGold))
                {
                    if (b.Contents.Contains(type))
                    {
                        b.ContainsGold = true;
                        queue.Enqueue(b.Type);
                    }
                }

                while (queue.Count > 0)
                {
                    var item = queue.Dequeue();
                    foreach (var b in bags.Where(x => !x.ContainsGold))
                    {
                        if (b.Contents.Contains(item))
                        {
                            b.ContainsGold = true;
                            queue.Enqueue(b.Type);
                        }
                    }
                }
            }
        }

        private static long GetCount(Dictionary<string, List<ContentCount>> dict, ContentCount content, int multiplier, long count)
        {
            long newCount = 0;
            var item = dict.First(x => x.Key == content.Bag);

            foreach (var i in item.Value)
            {
                count += (GetCount(dict, i, i.Count, newCount) * multiplier);
            }
            
            count += content.Count;

            return count;
        }

        private class Bag
        {
            public string Type { get; set; }
            public List<string> Contents { get; set; }
            public bool ContainsGold { get; set; }
        }

        private class ContentCount
        {
            public ContentCount(string bag, int count)
            {
                Bag = bag;
                Count = count;
            }
            public int Count { get; set; }
            public string Bag { get; set; }
        }
    }
}
