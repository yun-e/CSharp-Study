using System.Collections.Generic;
using System.IO;

namespace SalesCalculator {
    public class SalesCounter {
        private List<Sale> _sales;

        // 생성자
        public SalesCounter(string filePath) {
            _sales = ReadSales(filePath);
        }

        // 점포별 매출을 구함
        public Dictionary<string, int> GetPerStoreSales() {
            // Dictionary 클래스는 키에 대응되는 값(Value)과 키(Key)를 연관시켜 값에 접근하는 데이터 구조
            
            // var 이라는 암시형을 사용하여 더욱 간결하게 정리 가능하며, 아래의 코드와 같은 의미 
            // var dict = new Dictionary<string, int>();
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (Sale sale in _sales) {
                // 지정한 ShopName이 dict 안에 저장되어 있는지 ContainsKey 메서드를 사용하여 조사
                if (dict.ContainsKey(sale.ShopName))
                    dict[sale.ShopName] += sale.Amount;

                // 저장되어 있지 않다면 dict에 저장
                else
                    dict[sale.ShopName] = sale.Amount;
            }

            return dict;
        }
        
        // 매출 데이터를 읽어들인 후 Sales 오브젝트 리스트 반환
        // 메서드 이름: 여러개의 Sale을 반환한다는 의미를 명확히 하기 위해 ReadSales 복수형으로 지정
        private static List<Sale> ReadSales(string filePath) {
            // CSV 파일에 몇 행의 데이터가 포함되어 있는지 알 수 없음 -> 배열에 저장하는 것은 바람직하지 않음
            // 인스턴스를 생성 후 요소를 추가할 수 있는 List<T> generic 클래스에 저장
            // 매출 데이터를 넣을 리스트 객체 생성
            List<Sale> sales = new List<Sale>();

            // File 클래스에 있는 ReadAllLines 라는 정적 메서드를 사용해 모든 행을 읽어들인 후 string 배열에 저장
            // 몇 만 행의 거대한 파일에 적용하기는 어렵지만 작은 파일에는 편리함 
            string[] lines = File.ReadAllLines(filePath);

            // 읽어 들인 행을 모두 처리
            // for 문으로도 반복해서 처리할 수 있지만, 반복 횟수를 지정하지 않아 실수의 위험이 줄어듦
            foreach (string line in lines) {
                // String 클래스의 Split 메서드를 사용하여 문자열을 콤마(,)로 분리하여 배열에 저장
                string[] items = line.Split(',');

                // '객체 이니셜라이저'를 사용하여 초기화
                // 어느 객체를 초기화하고 있는 것인지 명확히 할 수 있음
                Sale sale = new Sale {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2])
                };

                // 새성한 Sale 객체를 sales 컬렉션에 추가
                sales.Add(sale);
            }
            
            // sales 객체 반환
            return sales;
        }
    }
}