#pragma warning disable IDE0090, IDE0060, IDE1006, IDE0051, IDE0044


//Birden fazla metodu tetikleyen yapılara delegate denir.
namespace cs_delegates {

    delegate void WorkDelegate(int sayi1, int sayi2);

    class Program {
        static void Main(string[] args) {

            //Delegate Oluştur
            WorkDelegate delegate_1 = new WorkDelegate(Topla);
            delegate_1 += Carp;

            //Delegate Çalıştır
            delegate_1.Invoke(3, 5);
        }

        static void Topla(int numara1, int numara2) {
            Console.WriteLine(numara1 + numara2);
        }

        static void Carp(int x, int y) {
            Console.WriteLine(x * y);
        }

    }

}
