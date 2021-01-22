using System;

namespace Lesson2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameCompany = "ООО 'Адидас'";
            string addressCompany = "123592, Москва    ВЕГАС СИТИ";
            string phoneCompany = "+7 (495) 236-10-46";
            string rnKKT = "0000498646041230";
            DateTime dateTimeSale = new DateTime(2017, 10, 26, 12, 20, 00);
            int nSession = 115;
            string znKKT = "0292120006008376";
            int nReceipt = 2;
            long INN = 7714037390;
            long FN = 871_0000_100_229_908;
            string cachierName = "Белая Т. П.";
            string fnsWWW = "www.nalog.ru";
            string OFD = "Платформа ОФД";
            string ofdWWWW = "http:\\platformaofd.ru";
            string nameGoods = "2267/14 Кросссовки муж. 538390";
            double countGoods = 1;
            double priceGoods = 7390;
            int ndsRate = 18;
            string sysNalog = "ОСН";
            int FD = 3677;
            long FP = 3178274820;

            Console.WriteLine($"                    {nameCompany}") ;
            Console.WriteLine($"                    {addressCompany}");
            Console.WriteLine($"                    {phoneCompany}");
            Console.WriteLine();
            Console.WriteLine($"РН ККТ:{rnKKT}               {Convert.ToString(dateTimeSale)}");
            Console.WriteLine($"ЗН ККТ:{znKKT}               СМЕНА: {Convert.ToString(nSession)} ЧЕК: {nReceipt}");
            Console.WriteLine("КАССОВЫЙ ЧЕК/ПРИХОД");
            Console.WriteLine($"ИНН: {INN}                       ФН: {FN}");
            Console.WriteLine($"Кассир: {cachierName}");
            Console.WriteLine($"Сайт ФНС:                             {fnsWWW}");
            Console.WriteLine($"ОФД:                                  {OFD}");
            Console.WriteLine($"Сайт ОФД:                             {ofdWWWW}");
            Console.WriteLine($"                           ЧЕК");
            Console.WriteLine($"{nameGoods}");
            Console.WriteLine($"                                            {countGoods.ToString("0.000")} X {priceGoods.ToString("0.00")}");
            double summSale = countGoods * priceGoods;
            double summNDS = summSale * ndsRate / (100 + ndsRate);
            Console.WriteLine($"                                                   ={summSale.ToString("0.00")}");
            Console.WriteLine($"НДС {ndsRate}%                                             {summNDS.ToString("0.00")}");
            Console.WriteLine($"ИТОГ:                                              ={summSale.ToString("0.00")}");
            Console.WriteLine($"  ЭЛЕКТРОННЫМИ                                     ={summSale.ToString("0.00")}");
            Console.WriteLine($"ПОЛУЧЕНО:");
            Console.WriteLine($"  ПЛАТ.КАРТОЙ                                      ={summSale.ToString("0.00")}");
            Console.WriteLine($"СУММА НДС {ndsRate}%                                      ={summNDS.ToString("0.00")}");
            Console.WriteLine($"СНО: {sysNalog}                            ФД: {Convert.ToString(FD)} ФП: {Convert.ToString(FP)}");



        }
    }
}
