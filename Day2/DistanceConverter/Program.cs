using System;

namespace DistanceConverter {
    internal class Program {
        public static void Main(string[] args) {
            Step1 step1 = new Step1();
            step1.Main();
            Console.WriteLine();

            Step2 step2 = new Step2();
            step2.Main();
            Console.WriteLine();

            Step3 step3 = new Step3();
            step3.Main();
            Console.WriteLine();

            Step4 step4 = new Step4();
            step4.Main();
            Console.WriteLine();

            Step5 step5 = new Step5();
            step5.Main();
            Console.WriteLine();
        }
    }


    // 'feet에서 meter로 환산표를 작성한다' 라는 목적은 달성
    // 한번 작서하면 다시는 유지보수하지 않을 프로그램
    // feet * 0.3048 이라는 로직이 다른 코드와 묶여 있기 때문에 쉽게 재사용 할 수 없음
    class Step1 {
        public void Main() {
            // feet에서 meter로 환산표 출력
            // for 문을 사용해 처리를 반복하며, feet * 0.3048 을 계산하여 meter 변수에 대입 후 출력
            for (int feet = 1; feet <= 10; feet++) {
                double meter = feet * 0.3048;
                Console.WriteLine("{0} ft = {1:0.0000} m", feet, meter); // '0.0000'은 소수점 네 자리까지 표시하는 포맷 설정
            }
        }
    }

    /* ------------------------------------------------------------------------------------------------------------- */

    // FeetToMeter라는 메서드를 정의하여 거리를 환산하는 부분을 메서드 형태로 독립시킴
    // 거리를 환산하는 로직이 하나의 메서드로서 분리됐으므로 재사용하기 편해짐
    // FeetToMeter 메서드에는 콘솔 응용 프로그램에 의존하는 부분이 없으므로 WindowsForms, WPF에도 그대로 이용 가능
    class Step2 {
        public void Main() {
            // feet에서 meter로 환산표 출력
            for (int feet = 1; feet <= 10; feet++) {
                double meter = FeetToMeter(feet);
                Console.WriteLine("{0} f = {1:0.0000} m", feet, meter);
            }
        }

        // feet를 meter로 환산
        public double FeetToMeter(int feet) {
            // FeetToMeter 메서드의 시그니처(메서드 이름, 반환값의 형, 인수, 접근자 제한 수준과 같이 메서드가 가지는 특징)를 결정
            return feet * 0.3048; // 인수로 받은 거리(feet)를 meter로 변환하여 반환
        }
    }

    /* ------------------------------------------------------------------------------------------------------------- */

    // 앞서 제작한 프로그램에 'feet에서 meter로 환산', 'meter에서 feet로 환산' 기능을 추가
    // Main메서드가 매우 복잡해짐 (두 가지 기능을 모두 내포하고 있음) 
    // 메서드는 기능을 단순하게 만들어야함 (프로그래밍의 철칙 중의 철칙)
    class Step3 {
        public void Main() {
            // 어떤 표를 출력할지에 대한 인수값을 입력
            string args = Console.ReadLine();

            // feet에서 meter로 환산표 출력
            if (args == "-tom") {
                for (int feet = 1; feet <= 10; feet++) {
                    double meter = FeetToMeter(feet);
                    Console.WriteLine("{0} ft = {1:0.0000} m", feet, meter);
                }
            }
            // meter에서 feet로 환산표 출력
            else if (args == "-tof") {
                for (int meter = 1; meter <= 10; meter++) {
                    double feet = MeterToFeet(meter);
                    Console.WriteLine("{0} m = {1:0.0000} ft", meter, feet);
                }
            }
        }

        // feet를 meter로 환산
        static double FeetToMeter(int feet) {
            return feet * 0.3048;
        }

        // meter를 feet로 환산
        static double MeterToFeet(int meter) {
            return meter / 0.3048;
        }
    }

    /* ------------------------------------------------------------------------------------------------------------- */

    // Main 메서드로부터 두 개의 기능을 독립시킴
    // PrintFeetToMeterList와 PrintMeterToFeetList라는 두 개의 메서드를 정의하고, 두 함수를 Main 메서드에서 호출
    class Step4 {
        public void Main() {
            // 어떤 표를 출력할지에 대한 인수값을 입력
            string args = Console.ReadLine();

            if (args == "-tom") {
                PrintFeetToMeterList(1, 10);
            }
            else if (args == "-tof") {
                PrintMeterToFeetList(1, 10);
            }
        }

        // feet에서 meter로 환산표 출력
        static void PrintFeetToMeterList(int start, int stop) {
            for (int feet = start; feet <= stop; feet++) {
                double meter = FeetToMeter(feet);
                Console.WriteLine("{0} ft = {1:0.0000} m", feet, meter);
            }
        }

        // meter에서 feet로 환산표 출력
        static void PrintMeterToFeetList(int start, int stop) {
            for (int meter = start; meter <= stop; meter++) {
                double feet = MeterToFeet(meter);
                Console.WriteLine("{0} m = {1:0.0000} ft", meter, feet);
            }
        }

        // feet를 meter로 환산
        static double FeetToMeter(int feet) {
            return feet * 0.3048;
        }

        // meter를 feet로 환산
        static double MeterToFeet(int meter) {
            return meter / 0.3048;
        }
    }

    /* ------------------------------------------------------------------------------------------------------------- */

    // 거리를 환산하는 로직을 클래스로 독립 시키면 다른 곳에서도 이용 가능
    // FeetToMeter와 MeterToFeet 메서드를 Program 클래스에서 독립시켜 UnitConverter라는 클래스에 정의
    class Step5 {
        public void Main() {
            // 어떤 표를 출력할지에 대한 인수값을 입력
            string args = Console.ReadLine();

            if (args == "-tom") {
                PrintFeetToMeterList(1, 10);
            }
            else if (args == "-tof") {
                PrintMeterToFeetList(1, 10);
            }
        }

        // feet에서 meter로 환산표 출력
        static void PrintFeetToMeterList(int start, int stop) {
            // 인스턴스 생성은 반복문 내에서 하지 않음
            // 루프를 돌 때마다 반복해서 인스턴스를 생상하므로 리소스가 낭비됨
            UnitConverter converter = new UnitConverter();
            for (int feet = start; feet <= stop; feet++) {
                double meter = converter.ToMeter(feet);
                Console.WriteLine("{0} ft = {1:0.0000} m", feet, meter);
            }
        }

        // meter에서 feet로 환산표 출력
        //
        static void PrintMeterToFeetList(int start, int stop) {
            for (int meter = start; meter <= stop; meter++) {
                double feet = UnitConverter.FromMeter(meter);
                Console.WriteLine("{0} m = {1:0.0000} ft", meter, feet);
            }
        }
    }
}