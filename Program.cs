
namespace ConsoleApp2
{
    class Program
    {
        public enum Months
        {
            January = 0,
            Fabruary = 1,
            March = 2,
            April = 3,
            May = 4,
            June = 5,
            July = 6,
            August = 7,
            September = 8,
            October = 9,
            November = 10,
            December = 11
        }

        class MyDS
        {
            private Dictionary<Months, Dictionary<string, int>> table;

            public MyDS()
            {
                table = new Dictionary<Months, Dictionary<string, int>>();
                foreach (Months key in Enum.GetValues(typeof(Months)))
                    table.Add(key, new Dictionary<string, int>());
            }

            public int FindValue(string month, string productName)
            {
                int result = 0;

                try
                {
                    Months m = (Months)(Enum.Parse(typeof(Months), month));
                    if (table.TryGetValue(m, out Dictionary<string, int> value))
                    {
                        if (value.ContainsKey(productName))
                        {
                            result = value[productName];
                        }
                    }
                }
                catch
                {
                    return result;
                }

                return result;
            }

            public void PutValue(int value, string month, string productName)
            {
                try
                {
                    Months m = (Months)(Enum.Parse(typeof(Months), month));
                    if (table.TryGetValue(m, out Dictionary<string, int> dict))
                    {
                        if (dict.ContainsKey(productName))
                        {
                            dict[productName] = value;
                        }
                        else
                        {
                            this.AddProduct(productName);
                            dict[productName] = value;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Error adding value.");
                }
            }

            public void AddProduct(string productName)
            {
                foreach (var key in table.Keys)
                {
                    var dict = new Dictionary<string, int>();
                    dict.Add(productName, 0);
                    table[key] = dict;
                }
            }

        }

        public static void Main(string[] args)
        {
            MyDS ds = new MyDS();
            ds.AddProduct("product1");
            ds.PutValue(34, "December", "product1");
            var value = ds.FindValue("December", "product1");
            Console.WriteLine(value);
        }
    }
}