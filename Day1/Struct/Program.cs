using System;

namespace Struct {
    internal class Program {
        public static void Main(string[] args) {
            // 구조체도 다음과 같이 new 연산자를 사용해 객체를 생성 
            // ex) System.DateTime 구조체, System.TimeSpan 구조체, System.Drawing.Color 구조체 등
            DateTime dateTime = new DateTime(2021, 07, 11);

            // dateTime 객체의 Year(2021) 값을 대입
            int year = dateTime.Year;

            // 10일 후를 구함
            DateTime daysAfter10 = dateTime.AddDays(10);
            
            
            // 클래스와 구조체의 차이점
            // 클래스는 변수가 있는 곳과 다른 곳에 객체의 영역이 확보되고, 변수에는 참조가 저장됨
            // myClass 객체는 메모리의 Heap 영역에 할당됨
            MyClass myClass = new MyClass {X = 1, Y = 2};
            
            // 구조체는 변수 자체에 객체가 저장되며, 상속을 할 수 없음
            // myStruct 객체는 메모리의 Stack 영역에 할당됨
            MyStruct myStruct = new MyStruct {X = 3, Y = 4};

            // 출력
            Console.WriteLine("X={0} Y={1}", myClass.X, myClass.Y);
            Console.WriteLine("X={0} Y={1}", myStruct.X, myStruct.Y);
        }
    }

    // 클래스
    class MyClass {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // 구조체
    struct MyStruct {
        public int X { get; set; }
        public int Y { get; set; }
    }
}