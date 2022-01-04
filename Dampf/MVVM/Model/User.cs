using System;

namespace Dampf.MVVM.Model
{
    public class User
    {
        public User(string name, string password, double balance)
        {
            Name = name;
            Password = password;
            Balance = balance;
        }

        public string Name { get; set; }
        public string Password { get; set; }

        public double Balance { get; set; }

        public string BalanceValue { get => Balance.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " €"; }
    }
}
