using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    public class Dizi
    {
        private int[] elemanlar;

        public Dizi(int[] elemanlar)
        {
            this.elemanlar = elemanlar;
        }

        public void Yazdir()
        {
            Console.WriteLine("Dizi elemanlari: " + string.Join(", ", elemanlar));
        }

        public static Dizi operator +(Dizi dizi1, Dizi dizi2)
        {
            int[] birlesikDizi = new int[dizi1.elemanlar.Length + dizi2.elemanlar.Length];
            Array.Copy(dizi1.elemanlar, birlesikDizi, dizi1.elemanlar.Length);
            Array.Copy(dizi2.elemanlar, 0, birlesikDizi, dizi1.elemanlar.Length, dizi2.elemanlar.Length);

            return new Dizi(birlesikDizi);
        }

        public static float operator ==(Dizi dizi1, Dizi dizi2)
        {
            float varyans1 = dizi1.Hesapla();
            float varyans2 = dizi2.Hesapla();

            return varyans1 == varyans2 ? 1 : 0;
        }

        public static float operator !=(Dizi dizi1, Dizi dizi2)
        {
            float varyans1 = dizi1.Hesapla();
            float varyans2 = dizi2.Hesapla();

            return varyans1 != varyans2 ? 1 : 0;
        }

        public float Hesapla()
        {
            float toplam = 0;
            float ortalam = 0;

            foreach (int eleman in elemanlar)
            {
                toplam += eleman;
            }

            ortalam = toplam / elemanlar.Length;

            float varyans = 0;

            foreach (int eleman in elemanlar)
            {
                float fark = eleman - ortalam;
                varyans += fark * fark;
            }

            return varyans / elemanlar.Length;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int[] dizi1Elemanlar = new int[10];
            int[] dizi2Elemanlar = new int[10];

            Random rastgele = new Random();

            for (int i = 0; i < 10; i++)
            {
                dizi1Elemanlar[i] = rastgele.Next(0, 100);
                dizi2Elemanlar[i] = rastgele.Next(0, 100);
            }

            Dizi dizi1 = new Dizi(dizi1Elemanlar);
            Dizi dizi2 = new Dizi(dizi2Elemanlar);

            Console.WriteLine("Dizi 1:");
            dizi1.Yazdir();

            Console.WriteLine("\nDizi 2:");
            dizi2.Yazdir();

            Dizi birlesikDizi = dizi1 + dizi2;
            Console.WriteLine("\nBirlesik Dizi:");
            birlesikDizi.Yazdir();

            float varyansDizi1 = dizi1.Hesapla();
            float varyansDizi2 = dizi2.Hesapla();
            float varyansBirlesikDizi = birlesikDizi.Hesapla();

            Console.WriteLine("\nDizi 1 Varyansı: " + varyansDizi1);
            Console.WriteLine("Dizi 2 Varyansı: " + varyansDizi2);
            Console.WriteLine("Birlesik Dizi Varyansı: " + varyansBirlesikDizi);

            Console.WriteLine("\nDizi 1 ve Dizi 2'nin Varyansları Eşit mi?");
            float esitMi = dizi1 == dizi2;
            Console.WriteLine(esitMi == 1 ? "Evet" : "Hayır");

        }
    }
}
