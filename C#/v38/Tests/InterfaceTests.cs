using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class InterfaceTests
    {
        [Fact]
        void Test_DebitCard()
        {
            var card = new DebitCard(1000);

            var paymentMade =  card.TryMakePayment(600);
            Assert.True(paymentMade);

            paymentMade = card.TryMakePayment(600);
            Assert.False(paymentMade);
        }
        [Fact]
        void Test_CreditCard()
        {
            var card = new CreditCard(1000, 500);

            var paymentMade = card.TryMakePayment(600);
            Assert.True(paymentMade);

            paymentMade = card.TryMakePayment(600);
            Assert.True(paymentMade);

            paymentMade = card.TryMakePayment(600);
            Assert.False(paymentMade);
        }
    }
    interface IPayer
    {
        public bool TryMakePayment(int amount);
    }

    class DebitCard : IPayer
    {
        private int _balance;
        public DebitCard(int balance)
        {
            _balance = balance;
        }
        public bool TryMakePayment(int amount)
        {
            bool canPay = amount <= _balance;

            if (canPay)
            {
                _balance -= amount;
            }

            return canPay;
        }
    }

    class CreditCard : IPayer
    {
        private int _balance;
        private int _credit;
        public CreditCard(int balance, int credit)
        {
            _balance = balance;
            _credit = credit;
        }

        public bool TryMakePayment(int amount)
        {
            bool canPay = amount <= (_balance + _credit);

            if (canPay)
            {
                if (_balance < amount)
                {
                    amount -= _balance;
                    _balance = 0;

                    _credit -= amount;
                }
                else
                {
                    _balance -= amount;
                }
            }

            return canPay;
        }
    }
}
