namespace DistanceConverter {
    // 클래스 안에 있는 모든 멤버가 정적 멤버일 경우 클래스를 정적 클래스로 지정 가능

    // 정적 클래스는 인스턴스 생성 불가능 -> UnitConverter converter = new UnitConverter(); 오류 발생
    // 정적 클래스로 사용 시 불필요한 인스턴스를 생성하는 일이 사라짐

    // C# 초기에는 클래스에 static 사용이 불가능 -> 생성자를 private으로 지정하여 인스턴스 생성을 막음 (현재는 사용 X) 
    public class UnitConverter {
        // ratio 상수 정의
        // const로 지정한 상수는 public으로 지정하지 않도록 주의 -> 다른 클래스가 참조할 경우 버전 관리에 문제가 생길 수 있음
        private const double ratio = 0.3048;

        // public으로 지정하여 다른 클래스가 접근할 수 있게 한 경우 -> static readonly 사용
        public static readonly double Ratio = 0.3048;

        // feet를 meter로 환산
        public double ToMeter(double feet) {
            return feet * 0.3048;
        }

        // meter를 feet로 환산

        // FromMeter 메서드는 인수가 같으면 반환값은 항상 일정 -> 인수의 값에 따라 반환값 결정
        // 인스턴스 속성이나 인스턴스 필드를 이용하지 않는 메서드는 정적 메서드로 만들 수 있음
        public static double FromMeter(double meter) {
            return meter / 0.3048;
        }
    }
}