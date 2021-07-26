using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExpressionAndLINQ {
    internal class Program {
        public static void Main(string[] args) {
            Console.WriteLine("LINQtoObjects");
            LINQtoObjects linQtoObjects = new LINQtoObjects();
            linQtoObjects.QueryExample1();
            Console.WriteLine();
            linQtoObjects.QueryExample2();
            Console.WriteLine();
            linQtoObjects.QueryExample3();
            Console.WriteLine();
            
            linQtoObjects.DelayedExecution();
            Console.WriteLine();
            linQtoObjects.ImmediateExecution();
            Console.WriteLine();
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