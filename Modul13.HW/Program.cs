using System.Diagnostics;

namespace Modul13.HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание №1

            List<string> list = new List<string>();

            LinkedList<string> lincked_list = new LinkedList<string>();

            LinkedListNode<string> node = new LinkedListNode<string>(string.Empty);

            string path = "C:\\Users\\zuevi\\Desktop\\Текстовый документ.txt";
            int i = 0;
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    
                    list.Add(line);
                    lincked_list.AddLast(line);
                    if(i == 1)
                    {
                        node = new LinkedListNode<string>(line);
                    }
                    i++;
                }
            }

            string insert = "Тестовая строка для вставки";

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            list.Insert(1, insert);
            stopwatch.Stop();

            Console.WriteLine("List: " + stopwatch.ElapsedTicks); ;

            LinkedListNode<string> node_ = new LinkedListNode<string>(string.Empty);
            node_ = lincked_list.Find(node.Value);

            stopwatch.Reset();
            stopwatch.Start();
            lincked_list.AddAfter(node_, "Тестовая строка для вставки");
            stopwatch.Stop();

            Console.WriteLine("Linked List: " + stopwatch.ElapsedTicks);

            //Задание №2
            string text = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                text = reader.ReadToEnd();
            }
            string[] ArString = text.Split(new char[] { ' ' });
            Dictionary<string, int> dr = new Dictionary<string, int>();
            foreach (string s in ArString)
                if (dr.Keys.Contains(s)) dr[s]++;
                else dr.Add(s, 1);
            string S = ""; int k = 0;
            foreach (KeyValuePair<string, int> kk in dr.OrderByDescending(x => x.Value))
            {
                S += kk.Key + " " + kk.Value.ToString() + "\n";
                k++;
                if (k == 10) break;
            }
            Console.WriteLine(S);

        }
    }
}
