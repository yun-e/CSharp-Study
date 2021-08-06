using System;
using System.Linq;

namespace CheckStrings {
    /// <summary>
    /// 문자열 판정
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            CheckNull.Run();
            Console.WriteLine();

            StartsWith.Run();
            Console.WriteLine();

            Contains.Run();
            Console.WriteLine();

            LINQ.Any();
            LINQ.All();
            Console.WriteLine();
        }
    }

    // null 또는 빈 문자열 판정
    public static class CheckNull {
        public static void Run() {
            var str = "";

            // 문자열이 null 인지 빈 문자열인지 조사하기 위해 IsNullOrEmpty 메서드 사용
            if (String.IsNullOrEmpty(str))
                Console.WriteLine("null 또는 빈 문자열입니다.");

            // 아래 두개의 코드로도 동일한 결과를 얻을 수 있지만 길이가 장황해짐
            // How 보다는 What 의 관점에서 코드 작성
            if (str == null || str == "")
                Console.WriteLine("null 또는 빈 문자열입니다.");

            if (str == null || str.Length == 0)
                Console.WriteLine("null 또는 빈 문자열입니다.");

            // null이 아닌것이 확실하다면 다음과 같이 작성해도 무방함
            // 만약 str이 null이라면 NullReferenceException 예외가 발생
            // String.Empty 대신 ""를 사용해도 무방함 (개인의 취향)
            if (str == String.Empty)
                Console.WriteLine("빈 문자열입니다.");

            // 빈 문자로만 구성된 문자열 판정
            // null, "", " " 모두 true가 됨
            if (String.IsNullOrWhiteSpace(str))
                Console.WriteLine("null 또는 빈 문자열 또는 공백 문자열입니다.");
        }
    }

    // 지정한 부분 문자열로 시작하는지 조사
    public static class StartsWith {
        public static void Run() {
            var str = "Visual Studio";

            // 문자열 str이 'Visual' 로 시작하는지 조사
            if (str.StartsWith("Visual")) {
                Console.WriteLine("Visual로 시작됩니다.");
            }

            // 위 코드와 동일한 결과이지만, 위의 코드가 더 직관적임
            if (str.IndexOf("Visual") == 0) {
                Console.WriteLine("Visual로 시작됩니다.");
            }

            // EndsWith 메서드를 통해 해당 문자열이 인수로 전달된 부분 문자열로 끝나는지 조사
            str = "InvalidException";
            if (str.EndsWith("Exception")) {
                Console.WriteLine("Exception으로 끝납니다.");
            }
        }
    }

    // 지정한 부분 문자열이 포함되어 있는지 조사
    public static class Contains {
        public static void Run() {
            var str = "C# Program";

            // 해당 문자열 안에 인수로 전달받은 부분 문자열이 포함되어 있는지 조사하기 위해 Contains 메서드 사용
            // 문자열 str에 'Program' 이라는 문자열이 포함되어 있는지 조사
            if (str.Contains("Program")) {
                Console.WriteLine("Program이 포함돼 있습니다.");
            }

            // 위 코드와 동일한 결과이지만, 위의 코드가 더 직관적임
            if (str.IndexOf("Program") >= 0) {
                Console.WriteLine("Program이 포함돼 있습니다.");
            }

            // 지정한 문자가 포함되어 있는지 조사하는 코드
            // String 클래스는 IEnumerable<char> 인터페이스를 구현 -> LINQ의 Contains 메서드 사용
            var target = "The quick brown fox jumps over the lazy dog.";
            var contains = target.Contains('b');
            Console.WriteLine(contains);

            // 위 코드와 동일한 결과이지만, 위의 코드가 더 직관적임
            var contains2 = target.IndexOf('b') >= 0;
            Console.WriteLine(contains);
        }
    }

    // LINQ를 사용하여 조건을 만족하는 문자 조사
    public static class LINQ {
        // 조건을 만족하는 문자가 포함되어 있는지 조사
        // LINQ의 Any 메서드를 사용
        public static void Any() {
            var target = "C# Programming";

            // LINQ 사용
            {
                // Any 메서드에 인수로 넘겨 준 람다식의 결과 중 하나라도 true를 반환하면 Any 메서드는 true를 반환
                // true 를 반환한 시점에서 문자열을 조사하는 작업 종료
                var isExists = target.Any(c => Char.IsLower(c));
                Console.WriteLine(isExists);
            }

            // LINQ 미사용
            // 코드의 양 증가 및 break 문의 부재 등 실수의 가능성 높아짐
            {
                bool isExists = false;
                foreach (char c in target) {
                    if (Char.IsLower(c)) {
                        isExists = true;
                        break;
                    }
                }

                Console.WriteLine(isExists);
            }
        }

        // 모든 문자가 조건을 만족하는지 조사
        // LINQ의 All 메서드를 사용
        public static void All() {
            string target = "141421356";
            // LINQ 사용
            {
                // Char 구조체를 통해 IsDigit 이라는 정적 메서드를 사용하여 해당 문자열이 숫자인지 여부 조사
                // 아래의 코드에서는 모두 숫자이므로 true 대입
                var isAllDigits = target.All(c => Char.IsDigit(c));
                Console.WriteLine(isAllDigits);
            }

            // LINQ 미사용
            {
                bool isAllDigits = true;
                foreach (char c in target) {
                    if (!Char.IsDigit(c)) {
                        isAllDigits = false;
                        break;
                    }
                }

                Console.WriteLine(isAllDigits);
            }
        }
    }
}