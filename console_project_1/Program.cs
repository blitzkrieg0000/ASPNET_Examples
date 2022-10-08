using System;
using System.Diagnostics;
using System.Net;

namespace console_project_1 {
    class Program {
        static void Main(string[] args) {

        }
    }

    class calisan {

        private static int numara;

        public calisan() {
            numara++;
        }

        public static int Numara {
            get { return numara; }
            set => numara = value;
        }
    }


}