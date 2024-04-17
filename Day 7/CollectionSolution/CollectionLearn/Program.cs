using System.Collections;

namespace CollectionLearn
{
    internal class Program
    {
        public void UnderstandingArrayListCollections()
        {
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add("kavin");

            Console.WriteLine(list[1]);
        }
        public void UnderstandingDictionaryCollections()
        {
            Dictionary<int, int> Dict = new Dictionary<int, int>();
            Dict.Add(1, 1);
            Dict.Add(2, 2);
            Dict.Add(3, 3);
            foreach (var item in Dict.Keys)
            {
                Console.WriteLine(item + " with the value of " + Dict[item]);
            }
            if (Dict.ContainsKey(1)) Console.WriteLine("Contains key of 1");
            if (Dict.ContainsValue(2)) Console.WriteLine("Contains value of 2");
        }
        static void Main(string[] args)
        {
            //new Program().UnderstandingArrayListCollections();
            new Program().UnderstandingDictionaryCollections();
        }
    }
}
