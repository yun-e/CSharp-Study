using System;

namespace Inheritance {
    internal class Program {
        public static void Main(string[] args) {
            // 상속: 이미 정의된 클래스를 기반으로 성질을 물려받고 이를 확장하거나 변경해서 새로운 클래스를 작성하는 것

            // Employee 클래스는 Person 클래스의 성질을 물려받음 -> Name 속성, Birthday 속성, GetAge 메서드를 이용할 수 있음
            Employee employee = new Employee {
                Id = 101,
                Name = "개발자",
                Birthday = new DateTime(1995, 12, 31),
                DivisionName = "프론트엔드 개발팀",
            };
            Console.WriteLine("{0}({1})은 {2}에 소속돼 있습니다.", employee.Name, employee.GetAge(), employee.DivisionName);

            // is a 관계: 'A는 B이다'가 성립하는 관계
            // ex) 사원은 사람이다, 삼각형은 도형이다, 리스트박스는 컨트롤이다

            // is a 관계가 성립하지 않으면 상속을 사용할 수 없음
            // ex) A는 B로 만들어져 있다, A는 B를 가지고 있다

            // Employee는 Person (Employee is person) 이므로 Employee 클래스의 인스턴스를 기저 클래스(Person) 변수에 대입 가능
            // 하지만 DivisionName 과 같은 Employee 클래스 고유의 속성 이용 불가능 
            Person person = new Employee();

            // Person은 Employee가 아닐 수도 있으므로(고객일 수도 있고, 주주일 수도 있음) 대입 불가능
            //Employee employee = new Person();
            
            // C#에서 모든 형을 상속해준 클래스를 거술러 올라가면 System.Object 클래스를 만남
            // 클래스의 정점에 있는 것이 Object 클래스이며, 상속할 클래스를 지정하지 않으면 상속되는 부모 클래스는 Object 클래스
            // object person = new Employee();
            // object employee = new Employee();
        }
    }

    // Person 클래스 정의
    public class Person { // public class Person : object{ 와 동일한 의미
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int GetAge() {
            DateTime today = DateTime.Today;
            int age = today.Year - Birthday.Year;
            if (today < Birthday.AddYears(age))
                age--;
            return age;
        }
    }

    // Person 클래스를 상속하여 Employee 클래스 정의
    // 상속받는 클래스 이름 뒤에 콜론(:)을 붙이고 상속할 클래스 이름(Person)을 지정

    // 상속되는 클래스 = 슈퍼 클래스, 기저 클래스, 베이스 클래스
    // 상속받는 클래스 = 서브 클래스, 파생 클래스
    public class Employee : Person {
        public int Id { get; set; }
        public string DivisionName { get; set; }
    }
}