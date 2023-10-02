namespace _02_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TASK asenkron programlamada yapılması gerekn işleri temsil eder. Taskın olayı bir işin tamamlanıp,tamamlanmadığını yani durum bilgisini
            //söyleyebilir. Eğer işlem bir sonuç verirse task bize bu sonucu bildirir.

            //void-> Task GeriDeğerDöndürenMetot -> Task<TResult>

            //Task oluşturmanın 3 yönetimi vardır
            //1) Task.FactoryçStartView
            //2) Task.Instance
            //3) Task.Run Metodu


            #region Task-1
            //var task =new Task(()=>GetRandomNumber());
            //task.Start();

            //Console.WriteLine("Program Başladı");
            //Console.Read();
            #endregion

            #region Task-2
            //Task.Run(() => GetRandomNumber());

            //Console.WriteLine("Program Başladı");
            //Console.Read();
            #endregion

            #region Task-3
            //Task.Factory.StartNew(() => GetRandomNumber());

            //Console.WriteLine("Program Başladı");
            //Console.Read();
            #endregion

            #region Task-4
            //Task<int> task=Task.Run(() => GetRandomNumber());

            //Console.WriteLine("Rastgele Sayı: "+task.Result);
            //Console.WriteLine("Program Başladı");
            //Console.Read();
            #endregion
        }
        static int GetRandomNumber()
        {
            Thread.Sleep(1000);
            int random=new Random().Next(1,100);
            return random;
        }
    }
}