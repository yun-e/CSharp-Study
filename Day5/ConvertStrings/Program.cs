using System;

namespace ConvertStrings {
    /// <summary>
    /// 문자열 변환
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            SourceCodes.Trim();
            Console.WriteLine();
            
            SourceCodes.Remove();
            Console.WriteLine();
            
            SourceCodes.Insert();
            Console.WriteLine();
            
            SourceCodes.Replace();
            Console.WriteLine();
            
            SourceCodes.ToUpper();
            Console.WriteLine();
        }
    }

    public static class SourceCodes {
        // 문자열의 앞뒤 공백 제거
        public static void Trim() {
            var target = "   non-whitespace characters   ";
            
            // target 문자열의 앞뒤 공백 제거
            // target.Trim(); 의 형태로 사용 불가능
            // [Column] 문자열은 불변 객체
            var replaced = target.Trim();
            Console.WriteLine("[{0}]", replaced);
            
            // target 문자열 앞의 공백 제거
            var replaced1 = target.TrimStart();
            
            // target 문자열 뒤의 공백 제거
            var replaced2 = target.TrimEnd();
            Console.WriteLine("[{0}]\n[{1}]", replaced1, replaced2);
        }
        
        // 지정 위치부터 임의 개수의 문자를 삭제
        public static void Remove() {
            var target = "01234ABC567";
            // 다섯 번쨰 문자부터 3개의 문자 삭제
            var result = target.Remove(5, 3);
            Console.WriteLine(result);
        }
        
        // 문자열에 다른 문자열 삽입
        public static void Insert() {
            var target = "01234";
            // 두 번째 문자 자리에 "abc" 삽입
            var result = target.Insert(2, "abc");
            Console.WriteLine(result);
        }
        
        // 문자열의 일부를 다른 문자열로 치환
        public static void Replace() {
            var target = "I hope you could come with us.";
            // 존재하는 "hope"를 모두 "wish"로 치환
            // oldValue를 찾을 수 없으면 수정하지 전의 문자열을 그대로 반환
            var replaced = target.Replace("hope", "wish");
            Console.WriteLine(replaced);
        }
        
        // 소문자를 대문자로 변환 (ToLower 메서드를 사용하면 대문자를 소문자로 변환 가능)
        public static void ToUpper() {
            var target = "The quick brown fox jumps over the lazy dog.";
            var replaced = target.ToUpper();
            Console.WriteLine(replaced);
        }
    }
    
}