using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcatenateAndSplitStrings {
    /// <summary>
    /// 문자열 연결 및 분할
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            SourceCodes.Concatenate();
            Console.WriteLine();

            SourceCodes.Join();
            Console.WriteLine();

            SourceCodes.Split();
            Console.WriteLine();

            SourceCodes.StringBuilder();
            Console.WriteLine();
        }
    }

    public static class SourceCodes {
        // 두 개의 문자열 연결
        public static void Concatenate() {
            // '+' 연산자 사용
            // name 변수에는 "홍길동"이 대입
            // '='의 우변이 문자열 변수여도 결과는 같음
            {
                var name = "홍" + "길동";
                Console.WriteLine(name);
            }

            // '+' 연산자를 사용하여 3개의 문자열 연결
            {
                var word1 = "Visual";
                var word2 = "Studio";
                var word3 = "Code";
                var text = word1 + word2 + word3;
                Console.WriteLine(text);
            }

            // char형과 string형 간 '+' 연산자를 이용하여 연결
            {
                char title = '님';
                string addressee = "손오공" + title;
                Console.WriteLine(addressee);
            }

            // 문자열 끝에 다른 문자열 추가
            {
                var name = "방정환";
                name += "선생님"; // name = name + "선생님"; 과 같은 코드
                Console.WriteLine(name);
            }
        }

        // 지정한 구분 문자로 문자열 배열 연결
        // Loop 문을 사용하여 마지막 요소에 콤마(,)를 붙이지 않게 만드는 방법도 있으나
        // Join 메서드을 아는 것과 모르는 것에는 코드 생산성 측면에서 차이가 있음
        // 가진 지식만으로 프로그램을 작성하려 하지 말고, 구현하고자 하는 처리 내용이 .NET Framework에 마련되어 있는지 검색을 추천
        public static void Join() {
            var languages = new[] {"C#", "Java", "VB", "Ruby",};
            var separator = ", ";
            var result = String.Join(separator, languages);
            Console.WriteLine(result);
        }

        // 지정한 문자로 문자열 분할
        public static void Split() {
            {
                var text = "The quick brown fox jumps over the lazy dog";
                // 공백이 있는 곳을 나눠서 단어를 추출, 하나하나의 단어로 분할되어 words 배열에 저장됨
                string[] words = text.Split(' ');
                words.ToList().ForEach(Console.WriteLine);
            }
            Console.WriteLine();

            // 예제 text 마지막이 온점(.)으로 끝나는 경우의 예시
            // 위의 예시 코드로는 words[8]에 "dogs." 가 저장됨
            // 마침표를 없애기 위하여 오버로드된 Split 메서드를 사용하여 작성
            // ' '와 '.'를 구분 문자로 지정하면 words[9]에는 빈 문자열이 저장되고
            // StringSplitOptions.RemoveEmptyEntries 를 지정하여  빈 배열 요소를 제외시킴
            {
                var text = "The quick brown fox jumps over the lazy dog.";
                var words = text.Split(new[] {' ', '.'},
                    StringSplitOptions.RemoveEmptyEntries);
                words.ToList().ForEach(Console.WriteLine);
            }
        }

        // [Column] 문자열은 불변 객체 -> 문자열은 변하지 않음
        // 생성된 문자열은 두 번 다시 수정할 수 없음
        // - 장점: 수정이 되지 않기 때문에 안전함
        // - 단점: 연결, 삽입, 삭제의 처리를 하기 위해서는 그때마다 새로운 인스턴스가 생성되므로 리스소관리에 좋지 않음
        // 사용 조건 예시) 반복 처리를 하지 않을 경우 '+' 연산자로 문자열 연결
        //               반복 처리를 하는 경우 StringBuilder를 사용
        //               단, 적은 횟수로 반복하는 경우 '+' 연산자 사용
        public static void StringBuilder() {
            // s1에 있는 "ABC" 뒤에 "XYZ가 연결되는 것이 아니라 새로운 6자 크가의 인스턴스가 생성됨
            // 새롭게 생성된 인스턴스에 "ABC"가 복사되고 그 뒤에 "XYZ"가 복사됨 (총 3개의 인스턴스)
            var s1 = "ABC";
            s1 = s1 + "XYZ";

            // 다음과 같은 코드에서는 인스턴스가 엄청나게 많이 생성되며 CPU와 메모리 자원을 낭비시킴
            var s2 = "";
            for (var i = 0; i < 100; i++) {
                s2 += Function(i); // 어디선가 단어를 가져오는 함수
            }

            // .NET Framework 에는 StringBuilder라는 클래스가 있으며, 이를 사용함으로서 효율적으로 문자열을 연결 가능함


            // var sb = new StringBuilder(200) -> 200 자 만큼의 영역 확보, 확보된 영역을 초과할 시 자동으로 용량이 느러남
            var sb = new StringBuilder(); // StringBuilder 객체 생성
            foreach (var word in GetWords()) {
                sb.Append(word); // 반복문을 사용하여 문자열을 Append 메서드를 통해 추가
            }

            var text = sb.ToString(); // ToString 메서드를 통해 string 형으로 벼환

            Console.WriteLine(text);
        }

        private static IEnumerable<string> GetWords() {
            var text = "The quick brown fox jumps over the lazy dog";
            return text.Split(' ');
        }

        private static string Function(int i) {
            throw new NotImplementedException();
        }
    }
}