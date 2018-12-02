using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            SyllableSeparator separator = new SyllableSeparator("Чай - сам лист чайного куста, " +
                "обработанный и подготовленный для приготовления напитка. Подготовка эта включает предварительную сушку, " +
                "скручивание, более или менее длительное ферментативное окисление, окончательную сушку. Прочие операции " +
                "вводятся в процесс только для производства отдельных видов и сортов чая.");
            Console.WriteLine(separator.GetSeparatedWords());
        }
    }
}
