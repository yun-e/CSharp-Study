using System;


namespace CSharpIdiomsOfBranches {
    /// <summary>
    /// 판정과 분기애 관한 관용구
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            _If _if =new _If();
            _if.GoodExampleWithOneVariable();
            _if.BadExampleWithOneVariable();
            _if.GoodExampleWithTwoVariables();
            _if.BadExampleWithTwoVariables();
            Console.WriteLine();

            ElseIf elseIf = new ElseIf();
            elseIf.GoodExample();
            elseIf.BadExample();
            Console.WriteLine();

            _Bool _bool = new _Bool();
            _bool.GoodExample();
            _bool.BadExample();
            Console.WriteLine();
            
            ReturnBool returnBool = new ReturnBool();
            returnBool.Main();
            Console.WriteLine();
        }
    }

    /// <summary>
    /// 단순한 비교
    /// </summary>
    public class _If {
        // 비교하려는 변수는 비교 연산자의 왼쪽에 위치
        // 인간의 일반적인 사고방식에 맞추어 작성
        public void GoodExampleWithOneVariable() {
            var age = 10;
            if (age <= 10) {
                Console.WriteLine("10세 이하입니다.");
            }
        }

        public void BadExampleWithOneVariable() {
            var age = 10;
            if (10 >= age) {
                Console.WriteLine("10세 이하입니다.");
            }
        }

        public void GoodExampleWithTwoVariables() {
            var num = 55;
            if (50 <= num && num <= 100) {
                Console.WriteLine("범위 안에 있습니다.");
            }
        }

        public void BadExampleWithTwoVariables() {
            var num = 55;
            if (num >= 50 && num <= 100) {
                Console.WriteLine("범위 안에 있습니다.");
            }
        }

    }

    public class ElseIf {
        // 하나의 변숫갑셍 의해 처리를 여러개로 분기시킬 경우에는 아래와 같이 들여쓰기
        public void GoodExample() {
            int num = 90;
            if (num > 80) {
                Console.WriteLine("A급입니다.");
            }
            else if (num > 60) {
                Console.WriteLine("B급입니다.");
            }
            else if (num > 40) {
                Console.WriteLine("C급입니다.");
            }
            else {
                Console.WriteLine("D급입니다.");
            }
        }

        // 문법적인 구조로는 이상이 없지만 의미적인 구조를 제대로 표현하지 못함
        public void BadExample() {
            int num = 90;
            if (num > 80)
                Console.WriteLine("A급입니다.");
            else if (num > 60)
                Console.WriteLine("B급입니다.");
            else if (num > 40)
                Console.WriteLine("C급입니다.");
            else
                Console.WriteLine("D급입니다.");
        }
    }

    /// <summary>
    /// Bool 값 판단
    /// </summary>
    public class _Bool {
        public void GoodExample() {
            int? num = 10;
            if (num.HasValue)
                Console.WriteLine("값을 기다립니다.");
        }

        // 명시가 필요한 경우를 제외하면 num.HasValue == true 라고 작성할 필요 없음
        public void BadExample() {
            int? num = 10;
            if (num.HasValue == true)
                Console.WriteLine("값을 기다립니다.");
        }
    }

    /// <summary>
    /// Bool 값 반환
    /// </summary>
    public class ReturnBool {
        public void Main() {
            var str = "Hello";
            Console.WriteLine(GoodExample(str));
            Console.WriteLine(BadExample1(str));
            Console.WriteLine(BadExample2(str));
            Console.WriteLine(BadExample3(str));
            Console.WriteLine(BadExample4(str));
        }

        public bool GoodExample(string str) {
            var line = "Hello";
            return line == "Hello";
        }

        // BadExample1, 2, 3, 4가 틀린 코드는 아님
        // 단지 GoodExample 코드에 비해 거추장스러우며 불필요하게 길어짐
        public bool BadExample1(string str) {
            var line = "Hello";

            if (line == str)
                return true;
            else
                return false;
        }
        public bool BadExample2(string str) {
            var line = "Hello";

            if (line == str)
                return true;
            return false;
        }
        public bool BadExample3(string str) {
            var line = "Hello";
            var result = line == str;

            return result;
        }
        
        public bool BadExample4(string str) {
            var line = "Hello";
            bool result = false;

            if (line == str)
                result = true;

            return result;
        }
    }
}