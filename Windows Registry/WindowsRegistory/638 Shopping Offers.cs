public class Solution
{
    public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs)
    {
        int n = price.Count;
        int m = special.Count;

        bool ValidProfitableOffer(int[] curNeeds, int i)
        {
            int packagePrice = special[i][n];
            int itemsPrice = 0;

            for (int j = 0; j < n; j++)
            {
                if (curNeeds[j] - special[i][j] < 0)
                    return false;

                itemsPrice += special[i][j] * price[j];
            }

            return packagePrice <= itemsPrice;
        }


        int res = 0;

        for (int j = 0; j < n; j++)
            res += needs[j] * price[j];

        return Math.Min(res, Solver(0, needs.ToArray()));
        int Solver(int i, int[] needs)
        {
            if (needs.Max() == 0)
                return 0;

            int totalPrice = 0;
            for (int j = 0; j < n; j++)
                totalPrice += needs[j] * price[j];


            for (int cur = i; cur < m; cur++)
            {
                if (ValidProfitableOffer(needs.ToArray(), cur))
                {
                    for (int j = 0; j < n; j++)
                        needs[j] -= special[cur][j];
                        
                    totalPrice = Math.Min(totalPrice, special[cur][n] + Solver(cur, needs));
                    totalPrice = Math.Min(totalPrice, special[cur][n] + Solver(cur + 1, needs));

                    for (int j = 0; j < n; j++)
                        needs[j] += special[cur][j];
                }

            }

            return totalPrice;
        }
    }
}
