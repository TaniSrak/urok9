using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urok9
{
    internal class Money
    {
        public int Hryvnia { get; set; }
        public int Kopecks { get; set; }

        public Money(int hryvnia, int kopecks)
        {
            Hryvnia = hryvnia;
            Kopecks = kopecks;
            if (Hryvnia < 0 || Kopecks < 0)
            {
                throw new ArgumentException("Деньги не могут быть меньше нуля!!!"); //неправильный аргумент
            }
        }

        //перегрузка
        public static Money operator +(Money m1, Money m2)
        {
            int totalKopecs = m1.Hryvnia * 100 + m1.Kopecks + m2.Hryvnia * 100 + m2.Kopecks;
            if (totalKopecs<0)
            {
                throw new BankrupException("ВЫ банкрот.");
            }
            return new Money(totalKopecs / 100, totalKopecs % 100);
        }

        public static Money operator -(Money m1, Money m2)
        {
            int totalKopecs = m1.Hryvnia * 100 + m1.Kopecks - m2.Hryvnia * 100 - m2.Kopecks;
            if (totalKopecs < 0)
            {
                throw new BankrupException("ВЫ банкрот.");
            }
            return new Money(totalKopecs / 100, totalKopecs % 100);
        }

        public static Money operator *(Money m1, int myltiplier)
        {
            int totalKopeck = (m1.Hryvnia * 100 + m1.Kopecks) * myltiplier;
            return new Money (totalKopeck / 100, totalKopeck % 100);
        }

        public static Money operator /(Money m1, int divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("Делить на ноль нельзя");
            }
            int totalKopecks = m1.Hryvnia * 100 + m1.Kopecks;
            return new Money(totalKopecks /  divisor, totalKopecks % divisor % 100);
                
        }

        //--------------------------
        public static bool operator <(Money m1, Money m2)
        {
            return m1.Hryvnia < m2.Hryvnia || (m1.Hryvnia == m2.Hryvnia && m1.Kopecks < m2.Kopecks);
        }

        public static bool operator >(Money m1, Money m2)
        {
            return m1.Hryvnia > m2.Hryvnia || (m1.Hryvnia == m2.Hryvnia && m1.Kopecks > m2.Kopecks);
        }

        //--------------------------------
        public static bool operator ==(Money m1, Money m2)
        {
            return m1.Hryvnia == m2.Hryvnia && m1.Kopecks == m2.Kopecks;
        }

        public static bool operator !=(Money m1, Money m2)
        {
            return !(m1 == m2);
        }
        
        //--------------------- инкримент дикримент
        public static Money operator ++(Money m1)
        {
            return m1 + new Money(0, 1);
        }

        public static Money operator --(Money m1)
        {
            return m1 - new Money(0, 1);
        }

        //-----------------------перевод в стороковый тип
        public override string ToString()
        {
            return $"{Hryvnia} грн, {Kopecks} коп";
        }

    }
}
