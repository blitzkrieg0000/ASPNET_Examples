using System;
using System.Threading;
using System.Threading.Tasks;
#pragma warning disable IDE0090, IDE0060, IDE1006, IDE1006

namespace cs_async {


    
    class Program {
        // delegates types: func, action, predicate 
        // Action delegates: Değer almaz ve değer döndürmez.
        public static async Task Main(string[] args) {
            //ACTION DELEGATE: Encapsulates a method that has no parameters and does not return a value

            //VOID
            Action helloAction = new Action(hello);
            helloAction.Invoke();

            //STRING
            Action<string> textAction = new Action<string>(yaz);
            textAction += ekranaYaz;
            textAction.Invoke("Burakhan");

            //Arrow function ile kullanım
            Action<string> arrowAction = new Action<string>(name => {
                Console.WriteLine(name);
            });
            arrowAction.Invoke("YENI ISIM");

            //ASYNC
            Program prog = new Program();
            await prog.islemYap();

        }

        private static void hello() {
            Console.WriteLine("Hello");
        }
        private static void yaz(string text) {
            Console.WriteLine("Text: " + text);
        }
        private static void ekranaYaz(string text) {
            Console.WriteLine("Ekrana Yazılan: " + text);
        }

        
        public static void Topla(int x, int y) {
            Console.WriteLine($"Toplam {x + y}");
        }

        public static void Carp(int x, int y) {
            Thread.Sleep(10000);
            Console.WriteLine(x * y);
        }

        private static Task AsyncCarp(int x, int y) {

            return Task.Run(() => {
                Thread.Sleep(10000);
                Console.WriteLine(x * y);
            });
        }

        public Task AsyncCarpInt(int x, int y) {
            
            void islem(){
                Thread.Sleep(3000);
                Console.WriteLine(x * y); 
            }

            Action act = new Action(islem);
            return Task.Run(act);
        }

        public async Task islemYap() {
            await AsyncCarpInt(3, 5);
        }

    }
}