using System;

namespace ExampleProgramUsingDictionary {
    /// <summary>
    /// 딕셔너리를 이용한 예제 프로그램
    /// 줄임말과 이에 대응하는 한국어가 적힌 텍스트 파일 "Abbreviations.txt"가 있으며
    /// 이 파일을 읽어 들여서 줄임말로부터 한국어를 구하고 한국어로부터 줄임말을 구하는 프로그램
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            // 생성자를 호출
            var abbrs = new Abbreviations();

            // Add 메서드 사용
            abbrs.Add("IOC", "국제 올림픽 위원회");
            abbrs.Add("NPT", "핵확산방지조약");

            // 인덱서를 사용
            var names = new[] {"WHO", "FIFA", "NPT",};
            foreach (var name in names) {
                var fullname = abbrs[name];
                if (fullname == null)
                    Console.WriteLine("{0}을(를) 찾을 수 없습니다.", name);
                else
                    Console.WriteLine("{0}={1}", name, fullname);
            }

            Console.WriteLine();

            // ToAbbreviation 메서드를 이용
            var japanese = "동남아시아 국가 연합";
            var abbreviation = abbrs.ToAbbreviation(japanese);
            if (abbreviation == null)
                Console.WriteLine("{0}을(를) 찾을 수 없습니다.", japanese);
            else
                Console.WriteLine("「{0}」의 줄임말은 {1}입니다.", japanese, abbreviation);
            Console.WriteLine();

            // FindAll 메서드를 이용
            foreach (var item in abbrs.FindAll("국제")) {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }

            Console.WriteLine();
        }
    }
}