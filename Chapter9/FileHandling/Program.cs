using System;
using System.IO;

namespace FileHandling {
    /// <summary>
    /// 파일 처리
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            CheckFileExistence.UsingFileClass();
            CheckFileExistence.UsingFileInfoClass();
            Console.WriteLine();

            DeleteFiles.UsingFileClass();
            DeleteFiles.UsingFileInfoClass();
            Console.WriteLine();

            CopyFiles.UsingFileClass();
            CopyFiles.UsingFileInfoClass();
            Console.WriteLine();

            MoveFiles.UsingFileClass();
            MoveFiles.UsingFileInfoClass();
            Console.WriteLine();

            RenameFiles.UsingFileClass();
            RenameFiles.UsingFileInfoClass();
            Console.WriteLine();

            GetLastWriteTime.UsingFileClass();
            GetLastWriteTime.UsingFileInfoClass();
            Console.WriteLine();

            GetFileSize.UsingFileInfoClass();
            Console.WriteLine();
        }
    }

    // 파일이 존재하는지 여부 조사
    public static class CheckFileExistence {
        // File 클래스 사용
        // File.Exists 라는 정적 메서드 사용
        // 존재한다면 true, 존재하지 않는다면 false 반환
        public static void UsingFileClass() {
            if (File.Exists(@"C:\Example\Greeting.txt")) {
                Console.WriteLine("이미 존재합니다.");
            }
        }

        // FileInfo 클래스의 Exists 속성 사용
        // FileInfo 클래스에 마련된 파일 처리를 위한 속성이나 메서드는 모두 인스턴스 멤버 -> 인스턴스를 생성한 후 해당 메서드 호출
        public static void UsingFileInfoClass() {
            var fi = new FileInfo(@"C:\Example\Greeting.txt");
            if (fi.Exists)
                Console.WriteLine("이미 존재합니다.");
        }
    }

    // 파일 삭제
    public static class DeleteFiles {
        // File 클래스 사용
        // File.Delete 정적 메서드 사용
        // 지정한 파일이 존재하지 않을 경우 예외가 발생하지 않고 되돌아옴
        public static void UsingFileClass() {
            File.Delete(@"C:\Example\Greeting.txt");
        }

        // FileInfo 클래스의 Delete 메서드 사용
        // 지정한 파일이 존재하지 않을 경우 예외가 발생하지 않고 되돌아옴
        public static void UsingFileInfoClass() {
            var fi = new FileInfo(@"C:\Example\Greeting.txt");
            fi.Delete();
        }
    }

    // 파일 복사
    public static class CopyFiles {
        // File 클래스 사용
        // File.Copy 정적 메서드 사용 
        public static void UsingFileClass() {
            // 첫 번째 인수에 지정한 파일을 두 번째 인수에 지정한 파일로 복사
            // 복사 위치에 이미 파일이 존재한다면 IOException 예외 발생
            // 기존 파일을 덯ㅍ어써도 좋다면 세 번째 인수 overwrite에 true 지정
            File.Copy(@"C:\Example\source.txt", @"C:\Example\target.txt");
        }

        // FileInfo 클래스의 CopyTo 메서드 상용
        public static void UsingFileInfoClass() {
            var fi = new FileInfo(@"C:\Example\source.txt");
            FileInfo dup = fi.CopyTo(@"C:\Example\target.txt", overwrite: true);
        }
    }

    // 파일 이동
    public static class MoveFiles {
        // File 클래스 사용
        // File.Move 정적 메서드 사용
        // 첫 번째 인수에 지정한 파일을 두 번째 인수에 지정한 경로로 이동
        // 이동할 곳에 동일한 이름의 파일이 이미 존재할 경우 IOException 예외 발생
        // 복사할 곳의 데렉터리가 존재하지 않으면 DirectoryNotFoundException 예외 발생
        // 다른 드라이브 간 이동은 지원하지 않으며, 다른 드라이브를 지정한 경우 복사 처리됨
        public static void UsingFileClass() {
            File.Move(@"C:\Example\src\Greeting.txt", @"C:\Example\dest\Greeting.txt");
        }

        // FileInfo 클래스의 MoveTo 메서드 사용
        // 다른 드라이브 간 이동 지원
        public static void UsingFileInfoClass() {
            var fi = new FileInfo(@"C:\Example\src\Greeting2.txt");
            fi.MoveTo(@"C:\Example\dest\Greeting2.txt");
        }
    }

    // 파일 이름 수정
    public static class RenameFiles {
        // File 클래스 사용
        // File.Move 정적 메서드 사용
        // 이동할 곳의 경로를 이동하는 쪽과 같은 디렉터리로 지정하면 파일 이름 수정 가능
        public static void UsingFileClass() {
            File.Move(@"C:\Example\src\oldfile.txt", @"C:\Example\src\newfile.txt");
        }

        // FileInfo 클래스의 MoveTo 메서드 사용
        // 이동할 목적지 경로에 출발지와 동일한 디렉터리를 지정하면 이름 수정 가능
        public static void UsingFileInfoClass() {
            var fi = new FileInfo(@"C:\Example\src\oldfile2.txt");
            fi.MoveTo(@"C:\Example\src\newfile2.txt");
        }
    }

    // 파일을 수정한 시간과 만든 시간을 구하고 설정
    public static class GetLastWriteTime {
        // File 클래스 사용
        //File.GetLastWriteTime 정적 메서드 사용
        public static void UsingFileClass() {
            var lastWriteTime = File.GetLastWriteTime(@"C:\Example\Greeting.txt"); // 파일을 수정한 시간
            Console.WriteLine(lastWriteTime);

            File.SetLastWriteTime(@"C:\Example\Greeting.txt", DateTime.Now); // 파일을 수정한 시간 설정
            Console.WriteLine(lastWriteTime);
        }

        // FileInfo 클래스의 LastWriteTime 속성 사용
        public static void UsingFileInfoClass() {
            var fi = new FileInfo(@"C:\Example\Greeting.txt");

            DateTime lastWriteTime = fi.LastWriteTime; // 파일을 수정한 시간
            Console.WriteLine(lastWriteTime);

            fi.LastWriteTime = DateTime.Now; // 파일을 수정한 시간 설정
            Console.WriteLine(lastWriteTime);
        }
    }

    // 파일 크기 구함
    public static class GetFileSize {
        // FileInfo 클래스의 Length 속성 사용
        // 반환값: long
        public static void UsingFileInfoClass() {
            var fi = new FileInfo(@"C:\Example\Greeting.txt");
            long size = fi.Length;
            Console.WriteLine(size);
        }
    }
}