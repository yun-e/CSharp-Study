using System;

namespace IndexAndSubstring {
    /// <summary>
    /// 문자열 검색 및 추출
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            Index.Run();
            Console.WriteLine();
            
            SubString.Example1();
            SubString.Example2();
            SubString.Example3();
            Console.WriteLine();
        }
    }

    // 부분 문자열 검색 및 위치 구하기
    // IndexOf 메서드는 인수로 전달받은 부분 문자열이 문자열 안에서 처음 발견된 위치를 반환
    public static class Index {
        public static void Run() {
            var target = "Novelist=김만중;BestWork=구운몽"; ;
            // 'BestWork='가 있는 위치를 구함 -> 13
            var index = target.IndexOf("BestWork=");
            Console.WriteLine(index);
        }
    }

    // 문자열의 일부 추출
    public static class SubString {
        
        // SubString 메서드를 사용하여 부분 문자열 추출
        // 지정한 시작 위치에서 마지막까지를 부분 문자열로 지정하여 추출
        // "BestWork="의 'B'의 인덱스에 value.Length 로 구한 "BestWork=" 문자열의 길이를 더해서 시작위치를 구함
        public static void Example1() {
            var target = "Novelist=김만중;BestWork=구운몽";
            var value = "BestWork=";
            var index = target.IndexOf("BestWork=") + value.Length;
            var bestWork = target.Substring(index);
            Console.WriteLine(bestWork);
        }
        
        // 추출할 부분 문자열의 길이를 지정하여 추출
        public static void Example2() {
            var target = "Novelist=김만중;BestWork=구운몽;Born=1687";
            var value = "BestWork=";
            var startIndex = target.IndexOf("BestWork=") + value.Length;
            var endIndex = target.IndexOf(";", startIndex);
            var bestWork = target.Substring(startIndex, endIndex - startIndex);
            Console.WriteLine(bestWork);
        }
        
        // 매직넘버: 코드 상ㅇ에 직접 쓰는 값, 그 의미를 금방 알 수 없음
        // 매직넘버를 사용한 코드이며 권장하지 않음
        // 검색할 문자열이 수정되어 길이가 변했을 경우 '9' 수정을 잊어버리면 버그가 되며, "BestWork=" 의 문자 개수를 잘못 셀 수도 있음
        public static void Example3() {
            var target = "Novelist=김만중;BestWork=구운몽";
            var index = target.IndexOf("BestWork=") + 9; // 9 -> 매직넘버
            var bestWork = target.Substring(index);
            Console.WriteLine(bestWork);
        }
    }
}