using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ReadTextFiles {
    /// <summary>
    /// 텍스트 파일 입력
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            UsingStreamReader.Run();
            Console.WriteLine();

            UsingReadAllLines.Run();
            Console.WriteLine();

            UsingReadLines.Run();
            UsingReadLines.LINQExample1();
            UsingReadLines.LINQExample2();
            UsingReadLines.LINQExample3();
            UsingReadLines.LINQExample4();
            UsingReadLines.LINQExample5();
            UsingReadLines.LINQExample6();
            Console.WriteLine();
        }
    }

    // 텍스트 파일을 한 행씩 읽어들임
    // StreamReader 클래스의 ReadLines 메서드 사용
    public static class UsingStreamReader {
        public static void Run() {
            var filePath = @"Greeting.txt";

            if (File.Exists(filePath)) { // File.Exits 라는 정적 메서드를 통해 파일의 존재 유무 확인

                // try-finally 구문으로도 사용 가능하지만 using문을 사용하는 것이 일반적임
                // StreamReader의 인스턴스를 생성하면 파일을 여는 처리도 함께 수행됨
                // 파일의 경로와 문자 인코딩을 인수에 전달해서 파일을 엶
                // 두 번째 인수를 생략하면 UTF-8이 지정되었다고 간주
                using (var reader = new StreamReader(filePath, Encoding.UTF8)) {
                    while (!reader.EndOfStream) {
                        // 텍스트를 한 행씩 읽어 들이면서 처리
                        // 파일의 마지막까지 읽어 들였는지 EndOfStream 속성을 통해 조사
                        // false 이면 아직 읽어 들일 행이 남았고, true 이면 마지막 행까지 읽어들였음    

                        var line = reader.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
        }
    }

    // 텍스트 파일을 한꺼번에 읽어들임
    // File 클래스의 ReadAllLines 메서드 사용
    public static class UsingReadAllLines {
        public static void Run() {
            var filePath = @"Greeting.txt";

            // 모든 행을 읽어 들이고 결과를 string[] 형으로 반환
            // 비교적 작은 파일에서 사용 가능
            // 거대한 텍스트 파일이라면 끝까지 읽는데 처리 지연이 발생하고 메모리를 압박하므로 주의 필요
            var lines = File.ReadAllLines(filePath, Encoding.UTF8);

            foreach (var line in lines) {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }

    // 텍스트 파일을 IEnumerable<string>으로 취급
    // File 클래스의 ReadLines 메서드 사용
    // .NET Framework 4 이상의 환경에서 사용 가능
    public static class UsingReadLines {
        public static void Run() {
            var filePath = @"Greeting.txt";

            // ReadLines 메서드는 호출한 시점에 읽기 작업이 시작됨
            // LINQ를 조합해서 다채로운 처리를 깨끗하게 작성할 수 있게 해줌
            var lines = File.ReadLines(filePath, Encoding.UTF8);

            foreach (var line in lines) {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }

        // LINQ Take 메서드
        // 첫 n 행을 읽음
        public static void LINQExample1() {
            var filePath = @"Greeting.txt";

            // 첫 10행만 읽음
            var lines = File.ReadLines(filePath, Encoding.UTF8).Take(10).ToArray();

            foreach (var line in lines) {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }

        // LINQ Count 메서드
        // 조건에 일치하는 행의 개수를 셈
        public static void LINQExample2() {
            var filePath = @"Greeting.txt";

            // "C#" 이라는 묹열이 포함되어 있는 행의 개수를 셈
            var count = File.ReadLines(filePath, Encoding.UTF8).Count(s => s.Contains("C#"));

            Console.WriteLine(count);
            Console.WriteLine();
        }

        // LINQ Where 메서드
        // 조건에 일치한 행만 읽음
        public static void LINQExample3() {
            var filePath = @"Greeting.txt";

            // 빈 문자열이나 공백인 행 이외의 행일 읽음
            var lines = File.ReadLines(filePath, Encoding.UTF8).Where(s => !String.IsNullOrWhiteSpace(s)).ToArray();

            foreach (var line in lines) {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }

        // LINQ Where 메서드
        // 조건에 일치하는 행이 존재하는지 여부 조사
        public static void LINQExample4() {
            var filePath = @"Greeting.txt";

            // 숫자로만 구성된 행이 존재하는지 조사
            // Where 메서드를 통해 빈 행을 제외한 후 Any 메서드 호출  
            var exists = File.ReadLines(filePath, Encoding.UTF8)
                .Where(s => !String.IsNullOrEmpty(s)).Any(s => s.All(c => Char.IsDigit(c)));

            Console.WriteLine(exists);
            Console.WriteLine();
        }

        // LINQ Distinct 메서드
        // 중복된 해을 제외하고 나열
        public static void LINQExample5() {
            var filePath = @"sample.txt";

            // 중복된 행일 제외하고 행으 ㅣ길이가 짧은 순서로 정렬한 후에 배열에 저장
            var lines = File.ReadLines(filePath, Encoding.UTF8).Distinct().OrderBy(s => s.Length).ToArray();

            foreach (var line in lines) {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }

        // LINQ Select 메서드
        // 행마다 어떤 변환 처리를 실행
        public static void LINQExample6() {
            var filePath = @"Code.txt";

            // 텍스트 파일에서 읽어 들인 각 행에 행 번호를 붙임
            var lines = File.ReadLines(filePath).Select((s, ix) => String.Format("{0,4}: {1}", ix + 1, s)).ToArray();

            foreach (var line in lines) {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }
}