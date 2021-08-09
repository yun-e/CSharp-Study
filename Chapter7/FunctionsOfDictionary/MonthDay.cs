using System;

namespace FunctionsOfDictionary {
    public class MonthDay {
        public int Day { get; private set; }

        public int Month { get; private set; }

        public MonthDay(int month, int day) {
            this.Month = month;
            this.Day = day;
        }
        
        //override -> 상위 클래스에 정의도니 메서드를 하위 클래스에서 재정의하여 사용

        // MonthDay끼리 비교
        // 이 코드가 없으면 KeyNotFoundException 예외 발생
        public override bool Equals(object obj) {
            var other = obj as MonthDay;
            if (other == null)
                throw new ArgumentException();
            return this.Day == other.Day && this.Month == other.Month;
        }

        // 해시 코드 구함
        // 해시 코드(해시값) -> 객체의 값을 가지고 일정한 계산을 통해 구한 int 형의 값으로 Dictionary 내부에서는 값을 찾을 때 인덱스로 이용
        //                    같은 객체로부터는 항상 같은 해시값이 생성되어야 함
        //                    다른 객체가 동일한 해시값을 생성해도 문제는 없으나, 동일한 값이 반환되는 빈도가 높으면 Dictionary가 가진 속도의 장점이 사라짐
        //                    해시값이 같은 경우에는 Equals 메서드를 통해 객체가 같은지 여부가 판단됨
        // 이 코드가 없으면 KeyNotFoundException 예외 발생
        public override int GetHashCode() {
            return Month.GetHashCode() * 31 + Day.GetHashCode();
        }
    }
}