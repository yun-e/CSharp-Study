using System;
using System.Linq;
using System.Collections.Generic;

namespace ArrayAndList {
    /// <summary>
    /// ArrayAndList<T>
    /// 여러 요소를 한꺼번에 관리할 수 있게 해주는 데이터 구조
    /// * 배열과 List의 공통점
    ///  - IEnumerable<T> 인터페이스를 가지고 있음 -> LINQ를 이용하면 배열과 ArrayAndList<T> 둘 다 동일한 코드로 다양한 처리를 수행할 수 있음
    /// * 배열과 List의 차이
    ///  - 배열: 인스턴스를 생성할 때 저장할 수 있는 요소의 개수가 정해지고 나주에 수정할 수 없음
    ///  - ArrayAndList: 인스턴스를 생성하고 나서 요소를 추가, 삽입, 삭제할 수 있음
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            Enumerable_Repeat.ExampleWithLINQ1();
            Enumerable_Repeat.ExampleWithLINQ2();
            Enumerable_Repeat.ExampleWithoutLINQ1();
            Enumerable_Repeat.ExampleWithoutLINQ2();
            Console.WriteLine();

            Enumerable_Range.ExampleWithLINQ();
            Enumerable_Range.ExampleWithoutLINQ();
            Console.WriteLine();

            Enumerable_Average.ExampleWithLINQ();
            Enumerable_Average.ExampleWithLambda();
            Enumerable_Average.ExampleWithoutLINQ();
            Console.WriteLine();

            Enumerable_Min.ExampleWithLINQ();
            Enumerable_Min.ExampleWithoutLINQ();
        }
    }

    // List나 배열을 일률적인 값으로 채움
    public static class Enumerable_Repeat {
        // LINQ를 사용한 코드
        // Enumerable.Repeat 메서드로 동일한 값이 반복되는 시퀀스를 만들고 이를 리스트로 변환
        public static void ExampleWithLINQ1() {
            var numbers = Enumerable.Repeat(-1, 20).ToList(); // '-1'로 20개를 채우고 ArrayAndList<int>로 변환
            foreach (var num in numbers)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }

        // Enumerable.Repeat 메서드로 컬렉션을 특정한 문자(unknown)으로 채우고 이를 배열로 변환
        public static void ExampleWithLINQ2() {
            var strings = Enumerable.Repeat("(unknown)", 12).ToArray(); // '(unknown)'로 12개를 채우고 Array로 변환
            foreach (var s in strings)
                Console.Write("{0} ", s);
            Console.WriteLine();
        }

        // LINQ를 사용하지 않은 코드
        // for문을 사용하여 배열의 각 요소를 '-1'로 설정
        public static void ExampleWithoutLINQ1() {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 20; i++) {
                numbers.Add(-1); // Add 메서드를 사용하여 List에 요소를 추가
            }

            foreach (int num in numbers)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }

        // for문을 사용하여 배열의 각 요소를 '-1'로 설정
        public static void ExampleWithoutLINQ2() {
            int[] numbers = new int[20];
            for (int i = 0; i < numbers.Length; i++) { // Length 속성을 통해 배열 요소의 개수를 구함
                numbers[i] = -1;
            }

            foreach (int num in numbers)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }
    }

    // List나 배열에 연속되는 숫자값을 설정
    public static class Enumerable_Range {
        // LINQ를 사용한 코드
        // Enumerable.Range 메서드를 사용하여 연속된 숫자값을 생성한 후 이를 배열로 변환 
        public static void ExampleWithLINQ() {
            var array = Enumerable.Range(1, 20)
                .ToArray();
            foreach (var num in array)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }

        // LINQ를 사용하지 않은 코드
        public static void ExampleWithoutLINQ() {
            int[] numbers = new int[20];
            for (int i = 0; i < numbers.Length; i++) {
                numbers[i] = i + 1;
            }

            foreach (int num in numbers)
                Console.Write("{0} ", num);
            Console.WriteLine();
        }
    }

    // 컬렉션에 있는 요소의 평균값을 구함
    public static class Enumerable_Average {
        private static IEnumerable<Book> books = Books.GetBooks();
        static List<int> numbers = new List<int> {9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4};

        // LINQ를 사용한 코드
        // Average 메서드를 사용
        public static void ExampleWithLINQ() {
            var average = numbers.Average();
            Console.WriteLine(average);
        }

        // 리스트에 있는 요소의 형이 클래스인 경우에는 다음과 같이 람다식으로 지정해서 평균값을 구할 수 있음
        public static void ExampleWithLambda() {
            var average = books.Average(x => x.Price);
            Console.WriteLine(average);
        }

        // LINQ를 사용하지 않은 코드
        public static void ExampleWithoutLINQ() {
            int sum = 0;
            foreach (int n in numbers) {
                sum += n;
            }

            double average = (double) sum / numbers.Count;
            Console.WriteLine(average);
        }
    }

    // 컬렉션에 있는 요소의 최솟값을 구함
    // Max 메서드를 사용하면 최댓값을 구할 수 있음
    public static class Enumerable_Min {
        static List<int> numbers = new List<int> {9, 7, -5, 4, 2, 5, 4, 2, -4, 8, -1, 6, 4};

        // LINQ를 사용한 코드
        // Min 메서드를 사용
        public static void ExampleWithLINQ() {
            var min = numbers.Where(n => n > 0).Min();
            Console.WriteLine(min);
        }

        // LINQ를 사용하지 않은 코드
        public static void ExampleWithoutLINQ() {
            int min = int.MaxValue;
            foreach (int n in numbers) {
                if (n <= 0)
                    continue;
                if (n < min)
                    min = n;
            }

            Console.WriteLine(min);
        }
    }

    public static class Enumerable_Count {
        public static void ExampleWithLINQ() {
        }

        public static void ExampleWithoutLINQ() {
        }
    }

    public static class Enumerable_Any {
        public static void ExampleWithLINQ() {
        }

        public static void ExampleWithoutLINQ() {
        }
    }

    public static class Enumerable_All {
        public static void ExampleWithLINQ() {
        }

        public static void ExampleWithoutLINQ() {
        }
    }
}