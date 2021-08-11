using System;
using System.Globalization;

namespace DateTime {
    /// <summary>
    /// 날짜와 시간 처리
    /// </summary>
    internal class Program {
        public static void Main(string[] args) {
            DateTimeStruct.CreateDateTime();
            DateTimeStruct.GetPropertyValues();
            DateTimeStruct.DayOfWeek();
            DateTimeStruct.IsLeapYear();
            DateTimeStruct.StringToDateTime();
            Console.WriteLine();

            DateTimeFormat.VariousToString();
            DateTimeFormat.KoreanCalendar();
            DateTimeFormat.GetKoreanDayName();
            Console.WriteLine();

            CompareDateTimeStruct.CompareDatetime();
            CompareDateTimeStruct.CompareDate();
            Console.WriteLine();

            CalculateDateTime.AddTimeSpan();
            CalculateDateTime.SubtractTimeSpan();
            CalculateDateTime.AddDays();
            CalculateDateTime.AddYearsAndMonths();
            CalculateDateTime.DifferenceBetweenDatetimes();
            CalculateDateTime.DifferenceBetweenDays();
            CalculateDateTime.GetEndOfMonth();
            CalculateDateTime.GetTotalDays();
            Console.WriteLine();
        }
    }

    // DateTime 객체 생성
    public static class DateTimeStruct {
        // DateTime 객체 생성
        public static void CreateDateTime() {
            // 생성자의 인수에 연도, 월, 일 을 지정
            var dt1 = new System.DateTime(2021, 7, 10);
            // 생성자의 인수에 연도, 월, 일, 시, 분, 초 를 지정
            var dt2 = new System.DateTime(2021, 7, 10, 10, 10, 30);

            Console.WriteLine(dt1);
            Console.WriteLine(dt2);
            Console.WriteLine();

            // 현재의 날짜를 반환
            var today = System.DateTime.Today;
            // 현재의 날짜와 시각 정보를 반환
            var now = System.DateTime.Now;

            Console.WriteLine("Today : {0}", today);
            Console.WriteLine("Now : {0}", now);
        }

        // Year, Month, Day, Hour 등 과 같은 속성(Property)을 참조하여 DateTime 객체의 날짜와 시각 정보를 구할 수 있음
        // 이러한 속성(Property)는 읽기 전용이며, DateTime 형은 불변 객체이므로 속성값을 수정할 수 없음
        public static void GetPropertyValues() {
            var now = System.DateTime.Now;
            int year = now.Year; // 연도: Year
            int month = now.Month; // 월: Month
            int day = now.Day; // 일: Day
            int hour = now.Hour; // 시: HourW
            int minute = now.Minute; // 분: Minute
            int second = now.Second; // 초: Second
            int millisecond = now.Millisecond; // 1/100초: Millisecond

            // 다음과 같은 코드는 빌드 오류가 발생 (불변 객체이므로 수정 불가)
            // var date = new System.DateTime(2021, 7, 10)
            // date.Day = 30;

            Console.WriteLine($"{now}");
            Console.WriteLine($"{year}/{month}/{day} {hour}:{minute}:{second} {millisecond}");
        }

        // 지정한 날짜의 요일을 구함
        // DateTime 구조체에 있는 DayOfWeek 속성 참조
        // DayOfWeek 속성의 형은 열거형(enum)
        public static void DayOfWeek() {
            var today = System.DateTime.Today;
            DayOfWeek dayOfWeek = today.DayOfWeek;
            if (dayOfWeek == System.DayOfWeek.Saturday)
                Console.WriteLine("오늘은 토요일입니다.");
            else
                Console.WriteLine("오늘은 토요일이 아닙니다.");
        }

        // 윤년 판정
        // DateTime 구조체에 있는 IsLeapYear 정적 메서드 이용
        public static void IsLeapYear() {
            // 윤년이라면 true, 윤년이 아니라면 false 반환
            var isLeapYear = System.DateTime.IsLeapYear(2021);
            if (isLeapYear)
                Console.WriteLine("윤년입니다.");
            else
                Console.WriteLine("윤년이 아닙니다.");
        }

        // 날짜 형식의 문자열을 DateTime 객체로 변환
        // DateTime 구조체에 있는 TryParse 정적 메서드 이용
        public static void StringToDateTime() {
            // 변수를 초기화하지 않고 선언
            System.DateTime dt1;
            // TryParse 메서드의 첫 번째 인수에 변환 대상이 되는 날짜 형식의 문자열 기입
            // 두 번째 인수에 out 키워드를 붙인 DateTime 형 변수 기입 (변환된 결과가 이 변수에 저장)
            // 변환에 성공하면 true, 변환에 실패하면 fasle 반환
            if (System.DateTime.TryParse("2021/7/10", out dt1))
                Console.WriteLine(dt1);

            System.DateTime dt2;
            if (System.DateTime.TryParse("2021/7/10 10:10:30", out dt2))
                Console.WriteLine(dt2);
        }
    }

    // DateTime 날짜 포맷
    public static class DateTimeFormat {
        public static void VariousToString() {
            var date = new System.DateTime(2021, 7, 10, 22, 10, 30);
            var s1 = date.ToString("d"); // 8/10/2021
            var s2 = date.ToString("D"); // Tuesday, July 10, 2021
            var s3 = date.ToString("yyyy-MM-dd"); // 2021-07-10
            var s4 = date.ToString("yyyy년M월d일(ddd)"); // 2021년7월10일(Tue)
            var s5 = date.ToString("yyyy년MM월dd일 HH시mm분ss초"); // 2021년07월10일 22시10분30초
            var s6 = date.ToString("f"); // Tuesday, July 10, 2021 10:10 PM
            var s7 = date.ToString("F"); // Tuesday, July 10, 2021 10:10:30 PM
            var s8 = date.ToString("t"); // 10:10 PM
            var s9 = date.ToString("T"); // 10:10:30 PM
            var s10 = date.ToString("tt hh:mm"); // PM 10:10
            var s11 = date.ToString("HH시mm분ss초"); // 22시10분30초


            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);
            Console.WriteLine(s5);
            Console.WriteLine(s6);
            Console.WriteLine(s7);
            Console.WriteLine(s8);
            Console.WriteLine(s9);
            Console.WriteLine(s10);
            Console.WriteLine(s11);
        }

        // 단기 날짜 표시
        // DateTime 클래스와 함께 CultureInfo 클래스와 KoreanCalendar 클래스 (System.Globalization 네임스페이스에 정의) 사용
        public static void KoreanCalendar() {
            var date = new System.DateTime(2021, 7, 10);
            var culture = new CultureInfo("ko-KR");
            culture.DateTimeFormat.Calendar = new KoreanCalendar();
            // 연호와 함께 날짜 출력
            var str = date.ToString("ggyyyy년M월d일", culture);
            Console.WriteLine(str);
            // 연호 출력
            var str2 = date.ToString("gg", culture);
            Console.WriteLine(str2);
            // 요일 출력
            var str3 = date.ToString("ddd", culture);
            Console.WriteLine(str3);
        }

        // 임의 날짜의 요일을 구함
        // DateTimeFormatInfo 클래스에 있는 GetDayName 메서드 사용
        public static void GetKoreanDayName() {
            var date = new System.DateTime(2021, 7, 11);
            var culture = new CultureInfo("ko-KR");
            culture.DateTimeFormat.Calendar = new KoreanCalendar();
            // 요일에 대한 원본 문자열 출력 (월요일, 화요일, 수요일 ... )
            var dayOfWeek = culture.DateTimeFormat.GetDayName(date.DayOfWeek);
            Console.WriteLine(dayOfWeek);
            // 요일에 대한 축약형 문자열 출력 (월, 화, 수 ... )
            var shortDayOfWeek = culture.DateTimeFormat.GetShortestDayName(date.DayOfWeek);
            Console.WriteLine(shortDayOfWeek);
        }
    }

    // DateTime 비교
    public static class CompareDateTimeStruct {
        // 날짜와 시간 비교
        // <, >, ==, != 등과 같은 비교 연산자 이용
        public static void CompareDatetime() {
            var dt1 = new System.DateTime(2021, 7, 10, 12, 0, 0);
            var dt2 = new System.DateTime(2021, 7, 11, 12, 0, 0);
            if (dt1 < dt2)
                Console.WriteLine("dt2가 미래입니다.");
            else if (dt1 == dt2)
                Console.WriteLine("dt1와 dt2는 같은 시각입니다.");
        }

        // 날짜 비교
        // 시각 정보를 포함하지 않은 날짜만 비교할 때 Date 속성 사용
        public static void CompareDate() {
            var dt1 = new System.DateTime(2021, 7, 10, 10, 0, 0);
            var dt2 = new System.DateTime(2021, 7, 10, 12, 0, 0);
            if (dt1.Date < dt2.Date)
                Console.WriteLine("dt2 쪽이 미래입니다.");
            else if (dt1.Date == dt2.Date)
                Console.WriteLine("dt1와 dt2는 같은 날짜입니다.");

            // Date 속성을 사용하지 않고 비교하면 원하는 결과가 나오지 않을수도 있음
            // 로그에 기록된 처리 시각이 21년 7월 10일 이전인지를 조사하는 코드이지만
            // logDateTime 변수에 '2021/7/10 12:10:30' 이라는 갑싱 들어있다면
            // '2021/7/10 00:00:00'과 비교되기 때문에 결과가 달라질 수 있음
            //if(logDateTime <= new DateTime(2021, 7, 10))
            //    Console.WriteLine("2021년 8월 10일 보다 과거입니다.");
        }
    }

    // DateTime 날짜 계산
    public static class CalculateDateTime {
        // 지정한 시분초 이후의 시각 계산
        // DateTime 객체에 TimeSpan 구조체 값을 더하여 계산
        public static void AddTimeSpan() {
            var now = System.DateTime.Now;
            var future = now + new TimeSpan(1, 30, 0);
            Console.WriteLine(future);
        }

        // 지정한 시분초 이전의 시각 계산
        // DateTime 객체에 TimeSpan 구조체 값을 빼서 계산
        public static void SubtractTimeSpan() {
            var now = System.DateTime.Now;
            var past = now - new TimeSpan(1, 30, 0);
            Console.WriteLine(past);
        }

        // n일 후와 n일 전의 날짜 계산
        // AddDays 메서드 사용 (양수: 미래의 날짜, 음수: 과거의 날짜)
        public static void AddDays() {
            var today = System.DateTime.Today;
            var future = today.AddDays(20);
            var past = today.AddDays(-20);
            Console.WriteLine(future);
            Console.WriteLine(past);

            // DateTime은 불변 객체 이므로 today 변수 자체를 수정할 수 없음
            // today.AddDays(20); -> today = today.AddDays(20);
        }

        // n년 후와 n개월 후의 날짜 계산
        // AddYears와 AddMonths 메서드 사용 (양수: 미래의 날짜, 음수: 과거의 날짜)
        public static void AddYearsAndMonths() {
            var date = new System.DateTime(2021, 7, 10);
            var future = date.AddYears(2).AddMonths(5);
            Console.WriteLine(future);
        }

        // 두 시각의 차이를 계산
        // 결과는 시간 간격을 나타내는 TimeSpan 형이 됨
        public static void DifferenceBetweenDatetimes() {
            var date1 = new System.DateTime(2021, 7, 10, 12, 10, 20);
            var date2 = new System.DateTime(2021, 7, 10, 14, 30, 50);
            TimeSpan diff = date2 - date1;
            Console.WriteLine("두 시각의 차는 {0}일 {1}시간 {2}분 {3}초입니다.", diff.Days, diff.Hours, diff.Minutes, diff.Seconds);
            Console.WriteLine("총 {0}초입니다.", diff.TotalSeconds);
        }

        // 두 날짜의 차이를 계산
        public static void DifferenceBetweenDays() {
            var dt1 = new System.DateTime(2021, 7, 10, 23, 0, 0);
            var dt2 = new System.DateTime(2021, 7, 11, 1, 0, 0);
            // Date 속성끼리 뺄셈
            // 시각정보는 버려짐
            TimeSpan diff_rightway = dt2.Date - dt1.Date;
            Console.WriteLine("{0}일간", diff_rightway.Days);

            // Date 속성을 사용하지 않았기 때문에 날짜의 차이를 제대로 구할 수 없음
            TimeSpan diff_wrongway = dt2 - dt1;
            Console.WriteLine("{0}일간", diff_wrongway.Days);
        }

        // 해당 월의 말일 구함
        // DaysInMonth 정적 메서드를 사용하여 해당 월의 마지막이 며칠인지 알 수 있음
        public static void GetEndOfMonth() {
            var today = System.DateTime.Today;
            // 해당 월에 며칠이 있는지를 구함
            int day = System.DateTime.DaysInMonth(today.Year, today.Month);
            // 이 day를 사용해서 DateTime 오브젝트를 생성
            // endOfMonth가 해당 월의 말일이다
            var endOfMonth = new System.DateTime(today.Year, today.Month, day);
            Console.WriteLine(endOfMonth);
        }

        // 1월 1일부터의 날짜 수 계산
        // DayOfYear 속성 사용
        public static void GetTotalDays() {
            var today = System.DateTime.Today;
            int dayOfYear = today.DayOfYear;
            Console.WriteLine(dayOfYear);

            // 다음과 같이 계산을 통해 날짜 수를 구하지 않아도 구현 가능
            var baseDate = new System.DateTime(today.Year, 1, 1).AddDays(-1);
            TimeSpan ts = today - baseDate;
            Console.WriteLine(ts.Days);
        }
    }
}