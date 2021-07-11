namespace Class {
    // Product 클래스
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