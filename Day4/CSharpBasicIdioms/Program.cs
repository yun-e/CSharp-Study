using System;
using System.Collections.Generic;

namespace CSharpIdioms {
    /// <summary>
    /// 기본 관용구
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            InitializationOfVariables initializationOfVariables = new InitializationOfVariables();
            initializationOfVariables.GoodExample();
            Console.WriteLine();
            initializationOfVariables.BadExample();
            Console.WriteLine();

            InitializationOfArraysAndLists initializationOfArraysAndLists = new InitializationOfArraysAndLists();
            initializationOfArraysAndLists.GoodExample();
            Console.WriteLine();
            initializationOfArraysAndLists.BadExample();
            Console.WriteLine();

            InitializationOfDictionaries initializationOfDictionaries = new InitializationOfDictionaries();
            initializationOfDictionaries.GoodExample();
            Console.WriteLine();
            initializationOfDictionaries.BadExample();
            Console.WriteLine();

            InitializationOfObjects initializationOfObjects = new InitializationOfObjects();
            initializationOfObjects.GoodExample();
            Console.WriteLine();
            initializationOfObjects.BadExample();
            Console.WriteLine();
        }
    }

    /// <summary>
    /// 변수 초기화
    /// </summary>

    // 변수 선언과 초기화는 동시에 이뤄저야함
    public class InitializationOfVariables {
        public void GoodExample() {
            var age = 25;
            Console.WriteLine(age);
        }

        // 유지보수를 계속해감에 따라 변수 선언과 초기화 사이에 다른 코드가 추가될 수 있음 -> 코드의 가독성 하락
        // 초깃값이 무엇인지 명확히 알 수 없음
        public void BadExample() {
            int age;
            age = 25;
            Console.WriteLine(age);
        }
    }

    /// <summary>
    /// 배열 및 리스트 초기화
    /// </summary>

    // 컬렉션 초기화 구문을 사용
    // C# 3.0 이후 도입된 기능
    // GoodExample과 BadExample의 상황에서 중간에 새로운 배열 값을 추가하려 할 때 GoodExample의 경우가 훨씬 편함
    public class InitializationOfArraysAndLists {
        public void GoodExample() {
            // 마지막 요소인 "C++"와 "40" 뒤에 콤마(,)가 부터 이씀
            // 생략 가능하지만 요소를 수정하거나 추가할 떄 용이하기 때문에 작성함
            // 개인적인 취향
            var langs = new string[] {"C#", "VB", "C++",};
            var nums = new List<int> {10, 20, 30, 40,};

            foreach (var lang in langs)
                Console.WriteLine(lang);

            Console.WriteLine();

            foreach (var n in nums)
                Console.WriteLine(n);
        }

        public void BadExample() {
            string[] langs = new string[3];
            langs[0] = "C#";
            langs[1] = "VB";
            langs[2] = "C++";
            List<int> nums = new List<int>();
            nums.Add(10);
            nums.Add(20);
            nums.Add(30);
            nums.Add(40);

            foreach (var lang in langs)
                Console.WriteLine(lang);

            Console.WriteLine();

            foreach (var n in nums)
                Console.WriteLine(n);
        }
    }

    /// <summary>
    /// Dictionary 초기화
    /// </summary>
    public class InitializationOfDictionaries {
        public void GoodExample() {
            var dict1 = new Dictionary<string, string>() {
                {"kr", "한국어"},
                {"en", "영어"},
                {"es", "스페인어"},
                {"de", "독일어"},
            };

            foreach (var item in dict1)
                Console.WriteLine($"{item.Key} {item.Value}");


            // C# 6.0 이후에는 다음과 같이 작성 가능
            // Dictionary 형태와 더욱 비슷하고 직관적임
            var dict2 = new Dictionary<string, string>() {
                ["kr"] = "한국어",
                ["en"] = "영어",
                ["es"] = "스페인어",
                ["de"] = "독일어",
            };

            foreach (var item in dict2)
                Console.WriteLine($"{item.Key} {item.Value}");
        }

        public void BadExample() {
            var dict = new Dictionary<string, string>();
            dict["ko"] = "한국어";
            dict["en"] = "영어";
            dict["es"] = "스페인어";
            dict["de"] = "독일어";

            foreach (var item in dict)
                Console.WriteLine($"{item.Key} {item.Value}");
        }
    }

    /// <summary>
    /// 객체 초기화
    /// </summary>
    public class InitializationOfObjects {
        // 속성 초기화는 인스턴스가 생성된 후에 실행
        // Name, Birthday, PhoneNumber 가 Person 객체의 속성이라는 것을 명확히 보여줌
        // IntelliSense의 도움을 받아 초기화되지 않은 속성 판결 가능
        public void GoodExample() {
            var person = new Person {
                Name = "홍길동",
                Birthday = new DateTime(1995, 11, 23),
                PhoneNumber = "012-3456-7890",
            };

            Console.WriteLine($"{person.Name} {person.Birthday} {person.PhoneNumber}");
        }

        // 코드 행 사이에 다른 코드가 작성될 수 있음 -> 가독성 저하 및 유지보수의 어려움
        public void BadExample() {
            Person person = new Person();
            person.Name = "홍길동";
            person.Birthday = new DateTime(1995, 11, 23);
            person.PhoneNumber = "012-3456-7890";

            Console.WriteLine($"{person.Name} {person.Birthday} {person.PhoneNumber}");
        }
    }
}