namespace MinimumCostForTickets
{
    internal class Program
    {
        private class MinimumCostForTickets
        {
            private int[] days;
            private int[] costs;
            private int[] memo;
            private readonly int[] durations = new int[] { 1, 7, 30 };

            private int DP(int day)
            {
                if (day >= days.Length)
                {
                    return 0;
                }
                if (memo[day] != -1)
                {
                    return memo[day];
                }
                int minCost = int.MaxValue;
                int curDay = day;
                for(int i = 0; i < durations.Length; i++)
                {
                    while(curDay < days.Length && days[curDay] < days[day] + durations[i])
                    {
                        ++curDay;
                    }
                    minCost = Math.Min(minCost, DP(curDay) + costs[i]);
                }
                memo[day] = minCost;
                return minCost;
            }

            public int MinCostTickets(int[] days, int[] costs)
            {
                this.days = days;
                this.costs = costs;
                memo = new int[days.Length];
                Array.Fill(memo, -1);
                return DP(0);
            }
        }

        static void Main(string[] args)
        {
            MinimumCostForTickets minimumCostForTickets = new();
            Console.WriteLine(minimumCostForTickets.MinCostTickets(new int[] { 1, 4, 6, 7, 8, 20 }, new int[] { 2, 7, 15 }));
            Console.WriteLine(minimumCostForTickets.MinCostTickets(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 30, 31 }, new int[] { 2, 7, 15 }));
        }
    }
}