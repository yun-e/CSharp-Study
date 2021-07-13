using System;

namespace Static {
    internal class Program {
        public static void Main(string[] args) {
            // 인스턴스를 생성하지 않은 상태에서 Today 속성을 참조
            // Today는 static 속성을 가지며, 정적 멤버를 이용할 때는 new로 객체를 생성할 필요 없음
            DateTime today = DateTime.Today;

            // 인스턴스를 생성하지 않은 상태에서 WriteLine 메서드를 호출
            // Console은 static 클래스, WriteLine은 static 메서드
            // MSDN 라이브러리의 Console 클래스에 static으로 지정되어 있음
            // public static class Console {}
            Console.WriteLine("오늘은 {0}월{1}일입니다.", today.Month, today.Day);

            // 틀린 코드이며, 다음과 같은 에러 발생
            // Program.cs(21, 30):
            // [CS0176] DateTime.Today' 멤버는 인스턴스 참조를 사용하여 액세스할 수 없습니다.
            // 대신 형식 이름을 사용하여 한정하세요.
            /*
            DateTime dateTime = new DateTime(2021, 07, 21);
            DateTime today = dateTime.Today;
            */
        }
    }
}