namespace Domain2
{
    public class Money
    {
        int rub;
        int cop;

        public string IntMoneyToString(int money)
        {
            string result = "0.00";
            rub = money / 100;
            cop = money % 100;
            if (cop == 0)
            {
                result = rub + ".00";
            }
            else result = rub + "." + cop;
            return result;
        }

        public int StringMoneyToInt(string money)
        {
            money = money.Replace(".", "");
            money = money.Replace(",", "");
            return int.Parse(money);
        }

        public int SummMoney(int money1, int money2)
        {
            return money1 + money2;
        }
    }
}
