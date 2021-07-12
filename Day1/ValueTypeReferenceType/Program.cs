using System;

namespace ValueTypeReferenceType {
    internal class Program {
        public static void Main(string[] args) {
            // C#에는 값형(Value Type)와 참조형(Reference Type)이 존재 -> 프로그램 실행 및 메모리 효율성 때문

            // 매우 큰 객체가 값형이라면 -> 변수를 대입할 때마다 객체의 내용을 복사 -> 비효율적
            // 매우 큰 객체가 참조형이라면 -> 참조(주소)를 복사하면 됨 -> 효율적

            // 매우 작은 객체가 값형이라면 -> 변수의 영역 자체에 객체를 저장함 -> 효율적
            // 매우 작은 객체가 참조형이라면 -> 작은 객체를 위해 두 개의 영역을 할당 -> 비효율적
            

            // 값형: int, long, decimal, char, byte, Struct 
            // 참조형:  object, string, Class
            
            // 구조체(값형) 실행 코드
            StructTest structTest = new StructTest();
            structTest.Run();
            Console.WriteLine();

            // 클래스(참조형) 실행 코드
            ClassTest classTest = new ClassTest();
            classTest.Run();
        }
    }

    class StructTest {
        public void Run() {
            MyPoint a = new MyPoint(10, 20);

            MyPoint b = a;

            Console.WriteLine("a: ({0},{1})", a.X, a.Y);
            Console.WriteLine("b: ({0},{1})", b.X, b.Y);

            a.X = 80;

            Console.WriteLine("a: ({0},{1})", a.X, a.Y);
            Console.WriteLine("b: ({0},{1})", b.X, b.Y);
        }

        // MyPoint라는 구조체 정의
        struct MyPoint {
            public int X { get; set; }
            public int Y { get; set; }

            // 생성자
            public MyPoint(int x, int y) {
                this.X = x;
                this.Y = y;
            }
        }
    }

    class ClassTest {
        public void Run() {
            // 특정 번지에 X: 10, Y: 20이 존재, b는 아직 존재하지 않음 
            MyPoint a = new MyPoint(10, 20);

            // 변수 a의 값을 변수 b에 대입하면 (10, 20)이라는 값을 가진 객체를 가리키는 참조가 변수 b에 대입
            // a와 b는 같은 객체를 참조 
            MyPoint b = a;

            Console.WriteLine("a: ({0},{1})", a.X, a.Y);
            Console.WriteLine("b: ({0},{1})", b.X, b.Y);

            // a.X = 80; 이 실행되면 변수 a를 통해 (10, 20)이라는 값을 가진 객체가 (80, 20)으로 변경
            // 변수 b에도 같은 참조가 저장되어 있으므로 b.X를 참조하면 80이 얻어짐
            a.X = 80;

            Console.WriteLine("a: ({0},{1})", a.X, a.Y);
            Console.WriteLine("b: ({0},{1})", b.X, b.Y);
        }

        class MyPoint {
            public int X { get; set; }
            public int Y { get; set; }

            // 생성자
            public MyPoint(int x, int y) {
                this.X = x;
                this.Y = y;
            }
        }
    }
}