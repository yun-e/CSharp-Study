using System;

namespace Class {
    internal class Program {
        public static void Main(string[] args) {
            // 클래스의 인스턴스 생성 (인스턴스: 컴퓨터의 메모리상에 확보된 클래스의 실체)
            // 하나의 클래스(Product)로부터 여러개의 인스턴스(yakkwa, chapssal)생성 가능
            Product yakkwa = new Product(123, "약과", 180);
            Product chapssal = new Product(235, "찹쌀떡", 160);

            // Product 클래스에 정의되어 있는 Price 속성을 사용해 yakkwa 객체의 상품 가격 대입
            // int price = 180
            int price = yakkwa.Price;

            // Prodcut 클래스에 정의되어 있는 GetPriceIncludingTaxd 메서드를 사용해 Tax를 포함한 Price를 대입
            // int taxIncluded = 194
            int taxIncluded = yakkwa.GetPriceIncludingTax();
            
            int yakkwaTax = yakkwa.GetTax();
            int chapssalTax = chapssal.GetTax();

            Console.WriteLine("{0} {1} {2}", yakkwa.Name, yakkwa.Price, yakkwaTax);
            Console.WriteLine("{0} {1} {2}", chapssal.Name, chapssal.Price, chapssalTax);
        }
    }
}
