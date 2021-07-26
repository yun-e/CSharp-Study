using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExpressionAndLINQ {
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("BeforeLambda_Step1");
            BeforeLambda_Step1 beforeLambda_step1 = new BeforeLambda_Step1();
            beforeLambda_step1.Main();
            Console.WriteLine();

            Console.WriteLine("BeforeLambda_Step2");
            BeforeLambda_Step2 beforeLambdaStep2 = new BeforeLambda_Step2();
            beforeLambdaStep2.Main();
            Console.WriteLine();

            Console.WriteLine("BeforeLambda_Step3");
            BeforeLambda_Step3 beforeLambdaStep3 = new BeforeLambda_Step3();
            beforeLambdaStep3.Main();
            Console.WriteLine();

            Console.WriteLine("BeforeLambda_Step4");
            BeforeLambda_Step4 beforeLambdaStep4 = new BeforeLambda_Step4();
            beforeLambdaStep4.Main();
            Console.WriteLine();

            Console.WriteLine("UsingLambda");
            UsingLambda usingLambda = new UsingLambda();
            usingLambda.UsingLambda_Step0();
            usingLambda.UsingLambda_Step1();
            usingLambda.UsingLambda_Step2();
            usingLambda.UsingLambda_Step3();
            usingLambda.UsingLambda_Step4();
            usingLambda.UsingLambda_Step5();
            usingLambda.Examples();
            Console.WriteLine();

            Console.WriteLine("UsingLambdaWithList");
            UsingLambdaWithList usingLambdaWithList = new UsingLambdaWithList();
            usingLambdaWithList.ExistsMethod();
            usingLambdaWithList.FindMethod();
            usingLambdaWithList.FindIndexMethod();
            usingLambdaWithList.FindAllMethod();
            usingLambdaWithList.RemoveAllMethod();
            usingLambdaWithList.ForEachMethod();
            usingLambdaWithList.ConvertAllMethod();
            Console.WriteLine();
            
            Console.WriteLine("LINQtoObjects");
            LINQtoObjects linQtoObjects = new LINQtoObjects();
            linQtoObjects.QueryExample1();
            linQtoObjects.QueryExample2();
            linQtoObjects.QueryExample3();
            Console.WriteLine();
            
            linQtoObjects.DelayedExecution();
            Console.WriteLine();
            linQtoObjects.ImmediateExecution();
            Console.WriteLine();
        }
    }


    /// <summary>
    /// 람다식 사용 이전의 코드 
    /// </summary>

    // 범용성이 없는 Count 메서드
    // 인수로 전달된 수와 동일한 것이 몇 개 있는지 세어서 반환
    // foreach 문에서 배열의 요소를 하나씩 거내서 인수 num과 일치하면 증가
    // 배열이 고정되어 있으므로 다른 배열로 같은 작업을 하려고 할 때 재사용 불가능
    class BeforeLambda_Step1 {
        public void Main() {
            int count = Count(5);
            Console.WriteLine(count);
        }

        public int Count(int num) {
            var numbers = new[] {5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4};
            int count = 0;
            foreach (var n in numbers) {
                if (n == num)
                    count++;
            }

            return count;
        }
    }

    // 배열을 인수로 받아 재사용이 가능한 Count 메서드 
    // 특정한 배열에 의존하지 않기 때문에 범용성이 좋음
    // 하지만 다른 조건으로 카운트하려고 할 경우에는 사용 불가능
    class BeforeLambda_Step2 {
        public void Main() {
            var numbers = new[] {5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4};
            var count = Count(numbers, 5);
            Console.WriteLine(count);
        }

        public int Count(int[] numbers, int num) {
            int count = 0;
            foreach (var n in numbers) {
                if (n == num)
                    count++;
            }

            return count;
        }
    }


    class BeforeLambda_Step3 {
        // 델리게이트 선언: int형을 인수로 받고 bool 값을 반환하는 메서드 대입 가능
        // Count 메서드의 judge 인수에 int 형을 받아서 bool 값을 반환하는 메서드를 넘겨줄 수 있음
        public delegate bool Judgement(int value);

        public int Count(int[] numbers, Judgement judge) {
            int count = 0;
            foreach (var n in numbers) {
                if (judge(n) == true)
                    count++;
            }

            return count;
        }

        public void Main() {
            var numbers = new[] {5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4};
            Judgement judge = IsEven; // IsEven 메서드를 대입 (IsEven 메서드는 Count 메서드에 인수로 전달됨, IsEven 메서드는 Count 메서드에서 호출 가능)
            var count = Count(numbers, judge);
            // var count = Count(numbers, IsEven); // Count 메서드에 메서드 이름을 직접 적을 수 있음
            Console.WriteLine(count);
        }

        public bool IsEven(int n) {
            return n % 2 == 0;
        }
    }

    // n % 2 == 0 이라는 계산식을 Count 메서드에 전달하기 위해 IsEven 이라는 메서드를 정의하는 대신
    // 익명메서드를 이용하여 간결하게 작성
    class BeforeLambda_Step4 {
        public int Count(int[] numbers, Predicate<int> judge) {
            int count = 0;
            foreach (var n in numbers) {
                if (judge(n) == true)
                    count++;
            }

            return count;
        }

        public void Main() {
            var numbers = new[] {5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4};
            var count = Count(numbers, delegate(int n) { return n % 2 == 0; });
            Console.WriteLine(count);
        }
    }


    /// <summary>
    /// 람다식을 사용한 코드 
    /// </summary>

    // var count = Count(numbers, n => n % 2 == 0);
    // 위의 람다식을 가장 길게 풀어쓴 코드
    class UsingLambda {
        public int Count(int[] numbers, Predicate<int> judge) {
            int count = 0;
            foreach (var n in numbers) {
                if (judge(n) == true)
                    count++;
            }

            return count;
        }

        public void UsingLambda_Step0() {
            var numbers = new[] {5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4};

            // 아래의 코드가 람다식이며 일종의 메서드
            // delegate 키워드 대신 => (람다 연산자) 사용
            // "인수 선언 => 메서드 본문" 형태로 사용
            // judge 변수에 대입 (대입만 할 뿐이며 처리 내용이 실행되지 않음)
            Predicate<int> judge =
                (int n) => {
                    if (n % 2 == 0)
                        return true;
                    else
                        return false;
                };
            var count = Count(numbers, judge);
            Console.WriteLine(count);
        }

        // judge 변수는 대입하고 나서 바로 Count의 인수로 전달되므로 judge 변수를 없애고 Count 메서드의 인수로 지정
        public void UsingLambda_Step1() {
            var numbers = new[] {5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4};
            var count = Count(numbers,
                (int n) => {
                    if (n % 2 == 0)
                        return true;
                    else
                        return false;
                }
            );
            Console.WriteLine(count);
        }

        // return의 오른쪽에 식 작성 가능
        // n % 2 == 0은 bool 형의 값을 가짐
        // 위 두가지 이유로 if 문을 없애고 줄 바꿈 없이 한 행에 작성 가능
        public void UsingLambda_Step2() {
            var numbers = new[] {5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4};
            var count = Count(numbers, (int n) => { return n % 2 == 0; });
            Console.WriteLine(count);
        }

        // 람다식에서 { } 에 하나의 명령문만 있으면 중괄호와 return 생략 가능
        public void UsingLambda_Step3() {
            var numbers = new[] {5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4};
            var count = Count(numbers, (int n) => n % 2 == 0);
            Console.WriteLine(count);
        }

        // 람다식에서는 인수의 형 생략 가능 (컴파일러가 처리함)
        public void UsingLambda_Step4() {
            var numbers = new[] {5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4};
            var count = Count(numbers, (n) => n % 2 == 0);
            Console.WriteLine(count);
        }

        // 람다식에서 인수가 하나인 경우 소괄호 생략 가능
        // 람다식을 사용한 Count 메서드 호출의 최종적인 형태
        public void UsingLambda_Step5() {
            var numbers = new[] {5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4};
            var count = Count(numbers, n => n % 2 == 0);
            Console.WriteLine(count);
        }

        public void Examples() {
            var numbers = new[] {5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4};

            // 홀수의 개수 카운트
            var count1 = Count(numbers, n => n % 2 == 1);
            Console.WriteLine(count1);

            // 5 이상인 수의 개수 카운트
            var count2 = Count(numbers, n => n >= 5);
            Console.WriteLine(count2);

            // 5 이상 10 미만의 수 카운트
            var count3 = Count(numbers, n => 5 <= n && n < 10);
            Console.WriteLine(count3);

            // 숫자에 '1'이 포함된 수 카운트
            var count4 = Count(numbers, n => n.ToString().Contains('1'));
            Console.WriteLine(count4);
        }
    }

    /// <summary>
    /// 람다식과 List<T> 클래스의 조합 
    /// </summary>
    class UsingLambdaWithList {
        // List<string> list 객체 선언
        List<string> list = new List<string> {
            "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
        };

        // Exists 메서드
        // 인수로 지정한 조건에 일치하는 요소가 존재하는지 조사하고 true / false 반환
        public void ExistsMethod() {
            var exists = list.Exists(s => s[0] == 'A');
            Console.WriteLine(exists);
            Console.WriteLine();
        }

        // Find 메서드
        // 인수로 지정한 조건과 일치하는 요소를 검색하고 처음 발견된 요소를 반환
        public void FindMethod() {
            var name = list.Find(s => s.Length == 6);
            Console.WriteLine(name);
            Console.WriteLine();
        }

        // FindIndex 메서드
        // 발견된 요소의 인덱스 반환
        public void FindIndexMethod() {
            int index = list.FindIndex(s => s == "Berlin");
            Console.WriteLine(index);
            Console.WriteLine();
        }

        // FindAll 메서드
        // 인수로 지정한 조건과 일치하는 모든 요소 검색
        public void FindAllMethod() {
            var names = list.FindAll(s => s.Length <= 5);
            foreach (var s in names)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        // RemoveAll 메서드
        // 인수로 지정한 조건과 일치하는 요소를 리스트에서 삭제
        // 반환값은 삭제한 요소의 개수
        public void RemoveAllMethod() {
            var removedCount = list.RemoveAll(s => s.Contains("on"));
            Console.WriteLine("{0} {1}", removedCount, list.Count);
            Console.WriteLine();
        }

        // ForEach 메서드
        // 인수로 지정한 처리 내용을 리스트의 각 요소를 대상으로 실행
        public void ForEachMethod() {
            // 아래 세 줄으 코드는 동일한 내용
            list.ForEach(s => Console.WriteLine(s));
            foreach (var s in list)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        // 리스트 안에 있는 요소를 다른 형으로 변환하고 변환된 요소가 저장된 리스트를 반환
        // list 안에 있는 모든 요소를 ToLower 메서드를 통해 변환하고 그 결과룰 lowerList에 대입
        // list 자체는 바뀌지 않음
        public void ConvertAllMethod() {
            var lowerList = list.ConvertAll(s => s.ToLower());
            lowerList.ForEach(s => Console.WriteLine(s));
        }
    }

    /// <summary>
    /// LINQ to Objects
    /// </summary>

    // LINQ를 사용하여 객체, 데이터, XML과 같은 다양한 데이터를 표준화된 방법으로 처리할 수 있음
    class LINQtoObjects {
        List<string> names = new List<string> {
            "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
        };

        // Where 메서드는 시퀀스에서 조건을 만족하는 것만 추출함
        // 배열, List, Dictionary 등 IEnumerable 인터페이스를 구현하고 있는 형에는 Where 메서드 이용 가능
        // 도시 이름 글자 수가 5자 이하 출력
        public void QueryExample1() {
            IEnumerable<string> query = names.Where(s => s.Length <= 5);
            foreach (string s in query)
                Console.WriteLine(s);
        }

        // Where 메서드를 통해 추출한 문자 도시 이름을 모두 소문자로 변환 후 출력
        public void QueryExample2() {
            var query = names.Where(s => s.Length <= 5).Select(s => s.ToLower());
            foreach (string s in query)
                Console.WriteLine(s);
        }

        // names에 저장되어 있는 문장열의 길이 열거
        public void QueryExample3() {
            var query = names.Select(s => s.Length);
            foreach (var n in query)
                Console.Write("{0} ", n);
            Console.WriteLine();
        }


        // 지연실행
        // Where 메서드의 반환값을 query 변수에 대입한 후에 names 배열의 요소 수정
        // query 변수에는 검색된 결과가 대입되지 않음 -> 필요할 때 쿼리가 실행됨
        public void DelayedExecution() {
            string[] names = {
                "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra"
            };
            var query = names.Where(s => s.Length <= 5);
            foreach (var item in query)
                Console.WriteLine(item);
            Console.WriteLine("------");

            names[0] = "Busan";
            foreach (var item in query)
                Console.WriteLine(item);
        }

        // 즉시 실행
        // ToArray 메서드가 호출되었을 때 쿼리가 실행되며 결과가 배열에 저장됨
        // ToArray 대신 ToList 메서드로 바꿔도 동일한 결과
        public void ImmediateExecution() {
            string[] names = {
                "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra"
            };
            var query = names.Where(s => s.Length <= 5).ToArray(); // 배열로 변환
            foreach (var item in query)
                Console.WriteLine(item);
            Console.WriteLine("------");

            names[0] = "Busan";
            foreach (var item in query)
                Console.WriteLine(item);
        }
    }
}