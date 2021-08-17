using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WriteTextFiles {
    /// <summary>
    /// 텍스트 파일에 출력
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            // 코드 실행 전 C 드라이버에 Example 폴더가 존재하는지 확인
            if (!Directory.Exists(@"C:\Example")) {
                Console.WriteLine("실행하려면 C:\\Example 폴더가 존재해야 합니다.");
                return;
            }

            UsingStreamWriter.WriteNewTextFile();
            UsingStreamWriter.AppendTextFile();
            UsingStreamWriter.UsingWriteAllLines();
            UsingStreamWriter.UsingWriteAllLinesWithLINQ();
            UsingStreamWriter.InsertLines();
            UsingStreamWriter.InsertLines_WrongWay();
        }
    }

    // 텍스트 파일에 한 행씩 문자열 출력
    public static class UsingStreamWriter {
        // 텍스트 파일을 생성하여 문자열 출력
        public static void WriteNewTextFile() {
            var filePath = @"C:\Example\고향의봄.txt";

            // StreamWriter의 생성자에서 파일 경로 지정
            // 문자 인코드는 기본 문자코드(UTF-8)로 지정
            // 생성자가 호출될 때 파일이 존재하지 않으면 새 파일 생성, 이미 존재하는 경우에는 덮어쓰기 모드로 열림
            // 아래의 코드에서는 4개의 행만크므이 데이터가 파일에 출력됨
            using (var writer = new StreamWriter(filePath)) {
                writer.WriteLine("나의 살던 고향은");
                writer.WriteLine("꽃피는 산골");
                writer.WriteLine("복숭아꽃 살구꽃");
                writer.WriteLine("아기 진달래");
            }

            DisplayLines(@"C:\Example\고향의봄.txt");
        }

        // 기존 텍스트 파일 끝에 행을 추가
        // StreamWriter 생성자의 두 번쨰 인수인 append 플래그에 true를 지정, false를 지정하면 덮어쓰기 모드
        public static void AppendTextFile() {
            // '고향의봄.txt' 파일이 존재하지 않는 상황에서 실행하면 새 파일이 생성되고 lines의 내용이 추가됨
            var lines = new[] {"====", "울긋불긋 꽃대궐", "차리인 동네",};
            var filePath = @"C:\Example\고향의봄.txt";
            using (var writer = new StreamWriter(filePath, append: true)) {
                foreach (var line in lines)
                    writer.WriteLine(line);
            }

            DisplayLines(@"C:\Example\고향의봄.txt");
        }

        // 문자열 배열을 한번에 파일에 출력
        public static void UsingWriteAllLines() {
            var lines = new[] {"Seoul", "New Delhi", "Bangkok", "London", "Paris",};
            var filePath = @"C:\Example\Cities.txt";
            File.WriteAllLines(filePath, lines);

            DisplayLines(filePath);
        }

        // IEnumerable<string>을 인수에 넘겨 쿼리 결과를 출력
        public static void UsingWriteAllLinesWithLINQ() {
            var names = new List<string> {
                "Seoul", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            var filePath = @"C:\Example\Cities.txt";

            // 문자열의 길이가 5문자보다 긴 문자만 출력
            File.WriteAllLines(filePath, names.Where(s => s.Length > 5));

            DisplayLines(filePath);
        }

        // 기존 텍스트 파일의 첫머리에 행을 삽입
        // 파일의 첫머리에 행을 삽입하는 기능은 StreamWriter 클래스에 존재하지 않음
        // FileStream 클래스에 있는 Position 속성에 0을 대입하여 구현 가능
        public static void InsertLines() {
            var originalFilePath = @"C:\Example\고향의봄.txt";
            var filePath = @"C:\Example\고향의봄2.txt";
            File.Copy(originalFilePath, filePath, overwrite: true);

            // FileStream 클래스를 사용하여 텍스트 파일 열기
            // ( FileMode.Open -> 기존 파일 열기, FileAccess.ReadWrite -> 읽기/쓰기 가능, FileShare.None -> 다른 프로세서의 접근 제한)
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) {
                // 위의 stream 객체를 인수로 사용하여 StreamReader와 StreamWriter 객체 생성
                using (var reader = new StreamReader(stream))
                using (var writer = new StreamWriter(stream)) {
                    // ReadToEnd 메서드로 한꺼번에 모든 행을 읽어들임, 반환값의 형은 string
                    string texts = reader.ReadToEnd();
                    // 파일의 마지막 까지 읽었으므로 파일 안의 포지션은 끝을 가리킴
                    // FileStream 클래스에 있는 Position 속성에 0을 대입하여 포지션을 첫머리로 되돌림
                    stream.Position = 0;
                    // WriteLine 메서드를 통해 행을 출력
                    // Position 속성이 0(파일의 첫머리) 이므로 첫머리에 출력됨
                    writer.WriteLine("삽입할 새 행1");
                    writer.WriteLine("삽입할 새 행2");
                    // 위에서 읽어 들인 모든 텍스트를 Write 메서드를 통해 한꺼번에 써넣음
                    writer.Write(texts);
                }
            } // using 문을 빠져나와 FileStream을 닫음

            DisplayLines(filePath);
        }

        // 위의 InsertLines() 메서드의 좋지 않은 구현 방법
        // 아래와 같은 버그가 발생할 경우 재현이 어렵기 때문에 디버깅이 어려움
        public static void InsertLines_WrongWay() {
            var originalFilePath = @"C:\Example\고향의봄.txt";
            var filePath = @"C:\Example\고향의봄2.txt";
            File.Copy(originalFilePath, filePath, overwrite: true);

            string texts = "";
            // 파일을 모두 읽어들음
            using (var reader = new StreamReader(filePath)) {
                texts = reader.ReadToEnd();
            } // StreamReader 종료

            // ... 다른 프로세스/스레드가 파일의 내용을 수정할 수 있음

            // 파일을 다시 열어서 출력 처리를 실행
            using (var writer = new StreamWriter(filePath)) {
                writer.WriteLine("삽입할 새 행1");
                writer.WriteLine("삽입할 새 행2");
                writer.Write(texts);
            }

            DisplayLines(filePath);
        }

        private static void DisplayLines(string filePath) {
            var xlines = File.ReadAllLines(filePath, Encoding.UTF8);
            foreach (var line in xlines) {
                Console.WriteLine(line);
            }

            Console.WriteLine();
        }
    }
}