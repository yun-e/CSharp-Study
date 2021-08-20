using System;
using System.IO;
using System.Linq;

namespace DirectoryHandling {
    /// <summary>
    /// 디텍터리 처리
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            DirectoryExists.Run();
            Console.WriteLine();

            CreateDirectory.UsingDirectoryClass();
            CreateDirectory.UsingDirectoryInfoClass();
            Console.WriteLine();
            
            DeleteDirectory.UsingDirectoryClass();
            DeleteDirectory.UsingDirectoryInfoClass();
            Console.WriteLine();
            
            MoveDirectory.UsingDirectoryClass();
            MoveDirectory.UsingDirectoryInfoClass();
            Console.WriteLine();
            
            RenameDirectory.UsingDirectoryClass();
            RenameDirectory.UsingDirectoryInfoClass();
            Console.WriteLine();
            
            GetDirectories.Run();
            Console.WriteLine();
            
            EnumerateDirectories.Run();
            Console.WriteLine();
            
            GetFiles.Run();
            Console.WriteLine();
            
            EnumerateFiles.Run();
            Console.WriteLine();
            
            GetFilesAndDirectories.Run();
            Console.WriteLine();
            
            EnumerateFilesAndDirectories.Run();
            Console.WriteLine();
            
            ChangeLastWriteTime.Run();
            Console.WriteLine();
        }
    }

    // 디렉터리가 존재하는지 여부 조사
    // Directory.Exists 정적 메서드 사용
    public static class DirectoryExists {
        public static void Run() {
            if (Directory.Exists(@"C:\Example")) {
                Console.WriteLine("존재합니다.");
            }
            else {
                Console.WriteLine("존재하지 않습니다.");
            }
        }
    }

    // 디렉터리 생성
    public static class CreateDirectory {
        // Directory 클래스 사용
        // Directory.CreateDirectory 정적 메서드 사용
        // 접근 권한이 없거나 무효한 경로를 지정하면 예외 발생
        // 지정한 디렉터리가 이미 존재한다면 어떤 처리도 하지 않고 해당 디렉터리를 나타내는 DirectoryInfo 객체 반환
        public static void UsingDirectoryClass() {
            // 이 메서드는 생성된 디렉터리의 정보를 나타내는 DirectoryInfo 객체 반환
            DirectoryInfo di1 = Directory.CreateDirectory(@"C:\Example");

            // 하위 디렉터리 생성
            DirectoryInfo di2 = Directory.CreateDirectory(@"C:\Example\temp");
        }

        // DirectoryInfo 클래스 사용
        // Create 메서드 사용
        public static void UsingDirectoryInfoClass() {
            var di1 = new DirectoryInfo(@"C:\Example");
            di1.Create();

            // 하위 디렉터리 생성
            DirectoryInfo di2 = Directory.CreateDirectory(@"C:\Example");
            // DirectoryInfo 오브젝트인 di1는 이미 생성됨
            DirectoryInfo sdi = di2.CreateSubdirectory("temp");
        }
    }

    // 디렉터리 삭제
    public static class DeleteDirectory {
        // Directory 클래스 사용
        // Directory.Delete 정적 메서드 사용
        public static void UsingDirectoryClass() {
            // temp 디렉터리가 삭제되며, Example 디렉터리는 삭제되지 않음
            // 지정한 디렉터리가 비어 있을 때만 삭제할 수 있음
            // 파일 또는 하위 디렉터리가 해당 디렉터리에 존재한다면 IOException 예외 발생
            Directory.Delete(@"C:\Example\temp");

            // 두 번째 인수 recursive에 true를 넘겨주면 하위 디렉터리를 그 ㅏㅇㄴ에 들어 있는 파일과 함께 삭제 가능
            Directory.Delete(@"C:\Example\temp", recursive: true);
        }

        // DirectoryInfo 클래스 사용
        public static void UsingDirectoryInfoClass() {
            var di = new DirectoryInfo(@"C:\Example\temp");
            // DirectoryInfo 오브젝트인 di는 이미 생성됨
            // recursive 인수에 true를 넘겨주어 디렉터리를 그안에 들어있는 파일과 함께 삭제 가능
            di.Delete(recursive: true);
        }
    }

    // 디렉터리 이동
    public static class MoveDirectory {
        // Directory 클래스 사용
        // temp 디렉터리 안에 있는 모든 파일과 디렉터리를 MyWork 디렉터리 아래로 이동
        // 이동할 목적지인 MyWOrk 디렉터리가 이미 존재한다면 IOException 예외 발생
        public static void UsingDirectoryClass() {
            Directory.Move(@"C:\Example\temp", @"C:\MyWork");
        }

        // DirectoryInfo 클래스 사용
        // MoveTo 메서드 사용
        public static void UsingDirectoryInfoClass() {
            var di = new DirectoryInfo(@"C:\Example\temp");
            // DirectoryInfo 오브젝트인 di는 이미 생성됨
            di.MoveTo(@"C:\MyWork");
        }
    }

    // 디렉터리 이름 수정
    public static class RenameDirectory {
        // Directory 클래스 사용
        // Directory.Move 메서드 사용 (Rename 메서드는 존재하지 않음)
        public static void UsingDirectoryClass() {
            Directory.Move(@"C:\Example\temp", @"C:\Example\save");
        }

        // DirectoryInfo 클래스 사용
        // MoveTo 메서드 사용 (Rename 메서드는 존재하지 않음)
        public static void UsingDirectoryInfoClass() {
            var di = new DirectoryInfo(@"C:\Example\temp");
            // DirectoryInfo 오브젝트인 di는 이미 생성됨
            di.MoveTo(@"C:\Example\save");
        }
    }

    // 지정한 폴더에 있는 디렉터리 목록을 구함
    // Directory 클래스에 있는 GetDirectory 메서드 사용
    public static class GetDirectories {
        // Example 아래에 있는 하위 디렉터리의 전체 경로를 출력
        public static void Run() {
            var di = new DirectoryInfo(@"C:\Example");

            // 한번에 모든 하위 디렉터리를 구하여 배열을 만들기 때문에 조건에 일치하는 디렉터리가 발견된 시점에서 검색을 중단할 수 없음
            DirectoryInfo[] directories = di.GetDirectories();

            // 검색 패턴(와일드 카드) 지정
            // 이름이 P로 시작되는 디렉터리를 구함
            DirectoryInfo[] directories_wildcard = di.GetDirectories("P*");

            // 첫 번째 인수로 "*"를 지정했으므로 모든 하위 디렉터리가 검색됨
            // 두 번째 인수로 SearchOption.AllDirectories를 지정하면 모든 하위 디렉터리를 대상으로 검색 
            DirectoryInfo[] directories_searchoption = di.GetDirectories("*", SearchOption.AllDirectories);

            // GetDirectories 메서드가 하위 디렉터리에 관한 DirectoryInfo 배열을 반환하므로 foreach를 통하여 하나씩 나열
            foreach (var dinfo in directories) {
                Console.WriteLine(dinfo.FullName);
            }
        }
    }

    // 지정한 폴더에 있는 디렉터리 목록을 열거
    // DirectoryInfo 클래스의 EnumerateDictionaries 사용
    // 반환형 -> IEnumerable<DirectoryInfo>
    public static class EnumerateDirectories {
        public static void Run() {
            var di = new DirectoryInfo(@"C:\Example");

            // 전체를 한번에 구하는 것이 아니라 순서대로 열거하 수 있으므로 도중에 열거하는 작접 중지 가능 (성능면에서 유리할 수 있음)
            // LINQ의 Where 메서드를 사용해 디렉터리 이름의 길이가 10 문자 이상인 것을 추출
            var directories = di.EnumerateDirectories().Where(d => d.Name.Length >= 10);

            // 첫 번째 인수로 "*"를 지정했으므로 모든 하위 디렉터리가 검색됨
            // 두 번째 인수로 SearchOption.AllDirectories를 지정하면 모든 하위 디렉터리를 대상으로 검색 
            var directories_searchoption = di.EnumerateDirectories("*", SearchOption.AllDirectories);

            foreach (var item in directories) {
                Console.WriteLine("{0} {1}", item.FullName, item.CreationTime);
            }
        }
    }

    // 지정한 폴더에 있는 파일의 목록을 한번에 구함
    // GetFiles 메서드 사용
    public static class GetFiles {
        public static void Run() {
            var di = new DirectoryInfo(@"C:\Windows");

            FileInfo[] files = di.GetFiles();

            foreach (var item in files) {
                Console.WriteLine("{0} {1}", item.Name, item.CreationTime);
            }
        }
    }

    // 지정한 폴더에 있는 파일의 목록을 열거
    // EnumerateFiles 메서드 사용
    // 반환형 -> IEnumerable<FileInfo>
    public static class EnumerateFiles {
        public static void Run() {
            var di = new DirectoryInfo(@"C:\Example");

            // 확장자가 "txt"인 파일 20개를 구함
            // 두 번째 인수로 SearchOption.AllDirectories를 지정하였으므로 모든 하위 디렉터리를 대상으로 검색 
            // 20개의 파일이 발견된 시점에서 디렉터리 검색 작업 종료
            var files = di.EnumerateFiles("*.txt", SearchOption.AllDirectories).Take(20);

            foreach (var item in files) {
                Console.WriteLine("{0} {1}", item.Name, item.CreationTime);
            }
        }
    }

    // 파일과 디렉터리 목록을 함께 구함
    // DirectoryInfo 클래스의 GetFileSystemInfos 메서드 사용
    // 반환값 -> FileSystemInfo 형 배열 (FileSystemInfo는 FileInfo와 DirectoryInfo를 상속하는 부모 클래스)
    public static class GetFilesAndDirectories {
        // Example 디렉터리 아래에 있는 파일과 디렉터리 모두를 구함
        public static void Run() {
            var di = new DirectoryInfo(@"C:\Example");
            FileSystemInfo[] fileSystems = di.GetFileSystemInfos();
            foreach (var item in fileSystems) {
                // FileAttributes.Directory -> 디렉터리인지 여부 확인
                if ((item.Attributes & FileAttributes.Directory) == FileAttributes.Directory)

                    Console.WriteLine("디렉터리:{0} {1}", item.Name, item.CreationTime);
                else
                    Console.WriteLine("파일:{0} {1}", item.Name, item.CreationTime);
            }
        }
    }

    // 파일과 디렉터리 목록을 열거
    // DirectoryInfoClass의 EnumerateFileSystemInfos 메서드 사용
    // 반환형 -> IEnumerable<SystemInfo>
    public static class EnumerateFilesAndDirectories {
        public static void Run() {
            var di = new DirectoryInfo(@"C:\Example");
            var fileSystems = di.EnumerateFileSystemInfos();
            foreach (var item in fileSystems) {
                if ((item.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                    Console.WriteLine("디렉터리:{0} {1}", item.Name, item.CreationTime);
                else
                    Console.WriteLine("파일:{0} {1}", item.Name, item.CreationTime);
            }
        }
    }

    // 파일과 디렉터리가 변경된 시각을 수정
    public static class ChangeLastWriteTime {
        // 파일이 변경된 시각을 하위 디렉터리까지 포함해서 모두 동일한 시각으로 설정
        public static void Run() {
            var di = new DirectoryInfo(@"C:\Example");
            
            // FileSystemInfo 객체의 LastWriteTime 속서에 DateTime 객체를 대입하여 변경된 시각 설정 가능
            FileSystemInfo[] fileSystems = di.GetFileSystemInfos();
            
            foreach (var item in fileSystems) {
                item.LastWriteTime = new DateTime(2021, 8, 16, 10, 20, 30);
            }
        }
    }
}