#pragma warning disable IDE0090, IDE0060, IDE1006, IDE1006

using System.Linq.Expressions;

namespace cs_async {



    class Program {
        // delegates types: func, action, predicate 
        // Action delegates: Değer almaz ve değer döndürmez.
        public static async Task Main(string[] args) {
            //ACTION DELEGATE: Encapsulates a method that has no parameters and does not return a value

            //VOID
            Action helloAction = new(hello);

            helloAction.Invoke();

            //STRING
            Action<string> textAction = new Action<string>(yaz);
            textAction += ekranaYaz;
            textAction.Invoke("Burakhan");

            //Arrow function ile kullanım
            Action<string> arrowAction = new Action<string>(

                name => {
                    Console.WriteLine(name);
                }

            );
            arrowAction.Invoke("YENI ISIM");

            //ASYNC
            Program prog = new Program();
            await prog.islemYap();


            //! Predicate
            Predicate<string> CheckIfApple = delegate (string modelName) {
                if (modelName == "I Phone X") return true;
                else return false;
            };

            bool result = CheckIfApple("I Phone X");
            if (result) Console.WriteLine("It's an IPhone");


            //! Func
            Func<int, int, int> Addition = AddNumbers;
            int result2 = Addition(10, 20);
            Console.WriteLine($"Addition = {result2}");



            Func<int, int, int> Addition2 = new(YeniFunc);
            Expression<Func<int,int,int>> exp = (x,y) => x+y;

            Func<int, int, int> Addition3 = YeniFunc;



        }

        private static int YeniFunc(int x, int y){
            return x + y;
        }

        private static int AddNumbers(int param1, int param2) {
            return param1 + param2;
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

            void islem() {
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