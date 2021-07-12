using System; // using 지시자로 네임스페이스르 지저

namespace Namespace {
    internal class Program { // Program 클래스는 Namespace라는 네임스페이스에 속함
        public static void Main(string[] args) {
            // 네임스페이스는 많은 클래스 중 사용할 클래스를 선택하는 기능

            // Console 클래스가 소속되어 있는 네임스패이스 이름(System)을 완전 수식명으로 지정
            System.Console.WriteLine("Hello! C# World.");

            // 네임스페이스(System)이 생략되어 있음
            Console.WriteLine("Hello! C# World.");

            // Namespace라는 네임스페이스에 Product 클래스가 있으므로, using 불필요
            Product yakkwa = new Product(123, "약과", 180);
        }
    }

    public class Product {
        // Product의 속성(Property) 선언

        // Product Code
        public int Code { get; private set; } // set 접근자의 권한을 private으로 설정 -> 생성자를 통하지 않고 속성값 설정 불가능

        // Product Name
        public string Name { get; private set; }

        //Product Price (세금 미포함)
        public int Price { get; private set; }

        // 생성자: 클래스와 이름이 같은 특수한 메서드
        public Product(int code, string name, int price) {
            this.Code = code;
            this.Name = name;
            this.Price = price;
        }

        // 8%의 Tax를 계산하여 반환
        public int GetTax() {
            return (int) (Price * 0.08);
        }

        // Price에 Tax를 합산
        public int GetPriceIncludingTax() {
            return Price + GetTax();
        }
    }
}