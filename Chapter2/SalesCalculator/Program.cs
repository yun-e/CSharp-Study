using System;
using System.Collections.Generic;

namespace SalesCalculator {
    internal class Program {
        public static void Main(string[] args) {
            // SalesCounter 클래스의 인스턴스 생성
            // 생성자로 넘겨주는 객체는 ReadSales 메서드에서 반환된 List<Sale> 객체
            SalesCounter sales = new SalesCounter((@"C:\Users\seung\Documents\Github\CSharpStudy\Day2\SalesCalculator\Sales.csv"));
            
            // SalesCounter에 있는 GetPerStoreSales 메서드를 호출하여 점포별 매출액을 집계
            Dictionary<string, int> amountPerStore = sales.GetPerStoreSales();
            
            // Dictionary에 저장된 요소를 하나씩 꺼내서 해당 Key(점포 이름), Value(집계된 매출액)을 출력
            foreach (KeyValuePair<string, int> obj in amountPerStore) {
                Console.WriteLine("{0} {1}", obj.Key, obj.Value);
            }
        }
    }
}