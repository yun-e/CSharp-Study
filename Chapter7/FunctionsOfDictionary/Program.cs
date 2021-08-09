using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FunctionsOfDictionary {
    /// <summary>
    /// Dictionary
    /// Dictionary<TKey, TValue> 제네릭 클래스는 '해시 테이블' 이라는 데이터 구조로 만들어진 클래스
    /// 키와 키에 대응하는 값을 여러 개 저장할 수 있는 컬렉션
    /// 배열과 리스트와 비교했을 때 키를 사용해 값을 빠른 속도로 구할 수 있다는 특징이 있음
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            Initialization.Example1();
            Initialization.Example2();
            Initialization.Example3();
            Console.WriteLine();

            
            AddGetRemoveItems.AddItemsExample1();
            AddGetRemoveItems.AddItemsExample2();
            AddGetRemoveItems.CheckItemsExample();
            AddGetRemoveItems.GetItemExample();
            AddGetRemoveItems.GetAllItemsExample();
            AddGetRemoveItems.GetAllKeysExample();
            AddGetRemoveItems.RemoveItemsExample();
            Console.WriteLine();

            
            ConvertToDictionary.ListToDictionary();
            ConvertToDictionary.DictionrayToDictionary();
            ConvertToDictionary.CustomClassSample();
            Console.WriteLine();
            
            var lines = File.ReadAllLines("sample.txt");
            var we = new WordsExtractor(lines);
            foreach (var word in we.Extract()) {
                Console.WriteLine(word);
            }
            Console.WriteLine();
            
            DuplicateKeys.Example();
            Console.WriteLine();
        }
    }

    // Dictionary 초기화
    public static class Initialization {
        // C# 3.0에 도입된 컬렉션 초기화 기능을 사용
        public static void Example1() {
            var flowerDict = new Dictionary<string, int>() {
                {"sunflower", 400},
                {"pansy", 300},
                {"tulip", 350},
                {"rose", 500},
                {"dahlia", 450},
            };
            Console.WriteLine(flowerDict["sunflower"]);
            Console.WriteLine(flowerDict["dahlia"]);
            Console.WriteLine();
        }

        // C# 6.0에 도입된 초기화 형태
        public static void Example2() {
            var flowerDict = new Dictionary<string, int>() {
                ["sunflower"] = 400,
                ["pansy"] = 300,
                ["tulip"] = 350,
                ["rose"] = 500,
                ["dahlia"] = 450,
            };
            Console.WriteLine(flowerDict["sunflower"]);
            Console.WriteLine(flowerDict["dahlia"]);
        }

        // Dictionary의 값(Value)에 사용자가 정의한 클래스의 객체를 저장
        // Employee Id를 키(Key)로 사용해 쉽고 빠르게 Employee 객체를 구하 수 있음
        public static void Example3() {
            var employeeDict = new Dictionary<int, Employee> {
                {100, new Employee(100, "이몽룡")},
                {112, new Employee(112, "변학도")},
                {125, new Employee(125, "성춘향")},
            };

            var emp0 = employeeDict[100];
            Console.WriteLine($"{emp0.Id} {emp0.Name}");
            var emp1 = employeeDict[112];
            Console.WriteLine($"{emp1.Id} {emp1.Name}");
            var emp2 = employeeDict[125];
            Console.WriteLine($"{emp2.Id} {emp2.Name}");
        }
    }

    // Dictionary에 요소 추가, 확인, 꺼내기, 삭제
    public static class AddGetRemoveItems {
        private static Dictionary<string, int> flowerDict = new Dictionary<string, int>() {
            {"sunflower", 400},
            {"pansy", 300},
            {"tulip", 350},
            {"rose", 500},
            {"dahlia", 450},
        };

        private static Dictionary<int, Employee> employeeDict = new Dictionary<int, Employee> {
            {100, new Employee(100, "이몽룡")},
            {112, new Employee(112, "변학도")},
            {125, new Employee(125, "성춘향")},
        };

        // Dictionary에 요소 추가
        // 이미 키가 Dictionary에 존재한다면 값이 치환되어 이전 값은 사라짐
        public static void AddItemsExample1() {
            flowerDict["violet"] = 600;

            employeeDict[126] = new Employee(126, "김향단");

            Console.WriteLine(flowerDict["violet"]);
            Console.WriteLine(employeeDict[126].Name);
            Console.WriteLine();
        }

        // Add 메서드를 사용하여 추가
        // 이미 키가 Dictionary에 존재한다면 ArgumentException 예외 발생
        public static void AddItemsExample2() {
            flowerDict.Add("daisy", 650);
            employeeDict.Add(127, new Employee(127, "향단"));

            Console.WriteLine(flowerDict["daisy"]);
            Console.WriteLine(employeeDict[127].Name);
            Console.WriteLine();
        }

        // [ ] 안에 키를 지정하여 키에 대응되는 값을 구함
        // 지정한 키가 Dictionary에 없으면 KeyNotFoundException 예외 발생
        public static void GetItemExample() {
            int price = flowerDict["rose"];

            var employee = employeeDict[125];

            Console.WriteLine($"price={price}");
            Console.WriteLine($"employee={employee.Id} {employee.Name}");
            Console.WriteLine();
        }

        // foreach 문을 사용해 Dictionary에 저장되어 있는 모든 요소를 꺼냄, KeyValuePair<TKey, TValue>형을 꺼낼 수 있음
        // *주의* 요소를 꺼내는 순서는 정해져 있지 않기 때문에 등록한 순서대로 나오지 않을 수도 있음
        public static void GetAllItemsExample() {
            foreach (var item in flowerDict)
                Console.WriteLine("{0} = {1}", item.Key, item.Value);
            Console.WriteLine();

            // foreach 문을 사용할 수 있다는 것은 LINQ도 사용할 수 있음을 의미
            // 평균(Average) 구하기
            var average = flowerDict.Average(x => x.Value);
            Console.WriteLine(average);

            // 합(Sum) 구하기
            int total = flowerDict.Sum(x => x.Value);
            Console.WriteLine(total);

            // 조건절(Where) 검색
            var items = flowerDict.Where(x => x.Key.Length <= 5);
            foreach (var item in items)
                Console.WriteLine("{0} = {1}", item.Key, item.Value);
            Console.WriteLine();
        }

        // Dictionary<TKey, TValue> 클래스에 있는 Keys 속서을 이용하여 저장된 모든 키를 열거
        // *주의* 요소를 꺼내는 순서는 정해져 있지 않기 때문에 등록한 순서대로 나오지 않을 수도 있음 
        public static void GetAllKeysExample() {
            foreach (var key in flowerDict.Keys)
                Console.WriteLine(key);
            Console.WriteLine();
        }

        // Dictionary에 키가 존재하는지 여부 조사
        // ContainsKey 메서드를 사용하여 존재 여부 확인
        public static void CheckItemsExample() {
            var key = "pansy";
            if (flowerDict.ContainsKey(key)) {
                var price = flowerDict[key];
                Console.WriteLine(price);
            }

            Console.WriteLine();
        }

        // Remove 메서드를 사용하여 Dictionary의 해당 요소 삭제
        // 정상적으로 삭제되면 true 반환, 지정한 키가 발견되지 않으면 false 반환
        public static void RemoveItemsExample() {
            var result = flowerDict.Remove("pansy");
            Console.WriteLine(result);
        }
    }

    // Dictionary로 변환
    // LINQ에 있는 ToDictionary 메서드를 사용하면 배열이나 List를 Dictionary로 변환 가능
    public static class ConvertToDictionary {
        // List<Employee>를 Dictionary<int, Employee>로 변환
        public static void ListToDictionary() {
            var employees = new List<Employee>() {
                new Employee(100, "이몽룡"),
                new Employee(112, "변학도"),
                new Employee(125, "성춘향"),
            };

            // ToDictionary 메서드의 첫 번째 인수에 사원 ID(emp.Id)를 나타내는 람다식을 넘겨줌
            // 사원 ID를 키(Key)로 이용하고 Employee 객체를 값(Value)로 이용하여 Dictionary 생성
            var employeeDict = employees.ToDictionary(emp => emp.Id);

            Console.WriteLine(employeeDict[100].Name);
            Console.WriteLine(employeeDict[112].Name);
            Console.WriteLine(employeeDict[125].Name);
        }

        // Dictionary에서 특정 조건을 만족하는 요소만 빼내서 새로운 Dictionary 생성
        public static void DictionrayToDictionary() {
            var flowerDict = new Dictionary<string, int>() {
                {"sunflower", 400},
                {"pansy", 300},
                {"tulip", 200},
                {"rose", 500},
                {"dahlia", 400},
            };
            // ToDictionary 메서드의 두 번째 인수에 어떤 객체를 값(Value)로 이용할지 지정
            var newDict = flowerDict.Where(x => x.Value >= 400)
                .ToDictionary(flower => flower.Key, flower => flower.Value);
            foreach (var item in newDict.Keys) {
                Console.WriteLine(item);
            }
        }

        // 사용자 지정 클래스를 키로 이용
        // 문자열, 숫자값이 아닌 사용자가 작성한 클래스를 Dictionary의 키로 이용
        public static void CustomClassSample() {
            // MonthDay 객체를 키로 이용하고 각 날짜에 대응하는 휴일을 저장
            var dict = new Dictionary<MonthDay, string> {
                {new MonthDay(6, 6), "현충일"},
                {new MonthDay(8, 15), "광복절"},
                {new MonthDay(10, 3), "개천절"},
            };
            var md = new MonthDay(8, 15);
            var s = dict[md];
            Console.WriteLine(s);
        }
    }

    // HashSet<T> 클래스
    // 키(Key) 부분만을 저장하며 값(Value)는 저장하지 않음
    // 중복을 허용핮 않는 요소의 집합을 나타내는 클래스
    public class WordsExtractor {
        private string[] _lines;

        // 생성자
        // 파일 이외의 것으로부터도 추출할 수 있도록 string[]을 인수로 받음
        public WordsExtractor(string[] lines) {
            _lines = lines;
        }

        // 10 문자 이상인 단어를 중복없이 알파벳 순으로 열거
        public IEnumerable<string> Extract() {
            var hash = new HashSet<string>(); // HashSet 객체 생성
            foreach (var line in _lines) {
                var words = GetWords(line);
                foreach (var word in words) {
                    if (word.Length >= 10)
                        hash.Add(word.ToLower()); // HashSet에 단어 등록
                }
            }

            return hash.OrderBy(s => s); // 알파벳 순으로 나열하여 반환
        }

        // 단어로 분할할 때 사용되는 분리자
        // 문자 배열을 초기화하기 보다는 ToCharArray 메서드를 사용하는 것이 편리함
        private char[] _separators = @" !?"",.".ToCharArray();

        // １행부터 단어를 꺼내서 열거
        private IEnumerable<string> GetWords(string line) {
            var items = line.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items) {
                // you're, it's, don't 에서 아포스트로피 이후에 나오는 부분 삭제
                var index = item.IndexOf("'");
                var word = index <= 0 ? item : item.Substring(0, index);
                // 알파벳만을 대상으로 함
                if (word.ToLower().All(c => 'a' <= c && c <= 'z'))
                    yield return word;
            }
        }
    }

    // 키가 중복되는 것을 허용
    // 값(Value)의 형을 string이 아닌 List<string>으로 지정 -> 하나의 키(Key)에 여러 값들(Values) 저장 가능
    public static class DuplicateKeys {
        public static void Example() {
            // 딕셔너리를 초기화
            var dict = new Dictionary<string, List<string>>() {
                {"PC", new List<string> {"퍼스널 컴퓨터", "프로그램 카운터",}},
                {"CD", new List<string> {"컴팩트 디스크", "캐시 디스펜서",}},
            };

            // 딕셔너리에 항목 추가
            var key = "EC";
            var value = "전자상거래";
            if (dict.ContainsKey(key)) { // "EC"가 이미 등록되어 있으면, EC의 값(Value)에 "전자상거래" 추가
                dict[key].Add(value);
            }
            else { // "EC"가 등록되어 있지 않다면, "전자상거래"가 저장된 리스트 객체를 등록
                dict[key] = new List<string> {value};
            }

            // 딕셔너리의 내용을 열거
            foreach (var item in dict) {
                foreach (var term in item.Value) {
                    Console.WriteLine("{0} : {1}", item.Key, term);
                }
            }
        }
    }
}