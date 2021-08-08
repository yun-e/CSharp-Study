using System;

namespace CompareStrings {
    /// <summary>
    /// 문자열 비교
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            CompareWords.Run();
            Console.WriteLine();

            CompareUpperAndLowerCases.Run();
        }
    }

    // 두 문자열의 내용이 같은지 조사
    // == 연산자를 사용 -> 대소문자가 구분됨
    public static class CompareWords {
        public static void Run() {
            var str1 = "Windows";
            var str2 = "Windows";
            if (str1 == str2)
                Console.WriteLine("일치합니다.");
        }
    }

    // 대/소문자 구분 없이 비교
    // String.Compare 라는 정적 메서드 사용
    public static class CompareUpperAndLowerCases {
        public static void Run() {
            var str1 = "Windows";
            var str2 = "WINDOWS";

            // if (String.Compare(str1, str2, ignoreCase: true) == 0) 이 코드는 아래의 코드와 같은 코드
            if (String.Compare(str1, str2, true) == 0) // 세 번째 인수(ignoreCase)를 true 로 지정하여 대/소문자 구분 없이 비교
                Console.WriteLine("같다.");
            else
                Console.WriteLine("같지 않다.");
        }
    }
}