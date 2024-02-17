class Program
{
    static void Main()
    {
        Stack<int> amountOfMoney = new Stack<int>(Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray());

        Queue<int> priceSize = new Queue<int>(Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray());

        int countOfStack = amountOfMoney.Count;
        int henryAteFoods = 0;
        int henryResto = 0;

        while (amountOfMoney.Count > 0 && priceSize.Count > 0)
        {
            int AmountMoney = amountOfMoney.Pop();
            int priceSizes = priceSize.Dequeue();

            if (AmountMoney == priceSizes)
            {
                henryAteFoods++;
            }
            else if (AmountMoney > priceSizes)
            {
                henryAteFoods++;
                henryResto += AmountMoney - priceSizes;
            }
            else if (AmountMoney < priceSizes)
            {
                AmountMoney += henryResto;
                if (AmountMoney >= priceSizes)
                {
                    henryAteFoods++;
                    henryResto -= AmountMoney - priceSizes;

                    if (AmountMoney - priceSizes == 0)
                    {
                        henryResto = 0;
                    }
                }
            }
        }

        if ( henryAteFoods == countOfStack)
        {
            Console.WriteLine($"Gluttony of the day! Henry ate {henryAteFoods} foods.");
        }
        else if (henryAteFoods > 0)
        {
            if (henryAteFoods == 1)
            {
                Console.WriteLine($"Henry ate: {henryAteFoods} food.");
            }
            else
            {
                Console.WriteLine($"Henry ate: {henryAteFoods} foods.");
            }
            
        }
        else if (henryAteFoods == 0) 
        {
            Console.WriteLine("Henry remained hungry. He will try next weekend again.");
        }


    }
}