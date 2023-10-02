namespace _01_AsenkronProgramlama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task Bekletme(Wait,WaitAll,WaitAny)
            /*
             * Wait: İlgili task tamamlanması bitmeden bir sonraki kod satırı çalıştırılamaz
             * WaitAll: Parametredeki tüm taskların tamamlanması bitmeden bir sonraki kod çalıştırılamaz
             * WaitAny: Parametredeki tasklardan herhangi biri tamamlanamadan bir sonraki kod satırı çalıştırılamaz
             */

            //StartSchool().Wait();
            //Task.WaitAll(StartSchool(), TeachClass1());
            //TeachClass2();

            Task.WaitAny(StartSchool(), TeachClass1());
            TeachClass2();

            Console.Read();

            //Async(içerisinde asenkron işlem yapılacak metodu belirler),
            //Await(async olarak işaretlenen metotda asenkron çalışacak komutları temsil eder.),
            //Task(asenkron metodu temsil eder)
        }

        public static async Task StartSchool()
        {
            await Task.Delay(8000);
            Console.WriteLine("Okul Bitti");
        }

        public static async Task TeachClass1()
        {
            await Task.Delay(3000);
            Console.WriteLine("12. Sınıflar Dersi Aldı");
        }

        public static async Task TeachClass2()
        {
            await Task.Delay(2000);
            Console.WriteLine("11. Sınıflar Dersi Aldı");
        }

        #region SenkronProgramlama

        //public static void StartSchool()
        //{
        //    Thread.Sleep(8000);
        //    Console.WriteLine("Okul Başladı");
        //}

        //public static void TeachClass1()
        //{
        //    Thread.Sleep(3000);
        //    Console.WriteLine("12. Sınıf Eğitime başladı");
        //}

        //public static void TeachClass2()
        //{
        //    Thread.Sleep(2000);
        //    Console.WriteLine("11. Sınıf Eğitime başladı");
        //}
        #endregion
    }
}