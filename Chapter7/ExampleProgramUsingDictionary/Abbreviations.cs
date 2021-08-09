using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExampleProgramUsingDictionary {
    // Abbreviations 클래스는 내부에 Dictionary를 저장하고 Dictionary에 줄임말과 한국어를 기억
    public class Abbreviations {
        // 내부에서 이용하는 데이터 구조는 공개하지 않음
        private Dictionary<string, string> _dict = new Dictionary<string, string>();

        // 생성자
        public Abbreviations() {
            // 현재 폴더에 있는 "Abbreviations.txt"를 읽어 들여 Dictionary에 등록
            // 파일 안에 같은 이름의 줄임말이 존재하면 ArgumentException 예외 발생 (중복되는 줄임말이 없다고 가정)
            var lines = File.ReadAllLines("Abbreviations.txt");
            _dict = lines.Select(line => line.Split('=')).ToDictionary(x => x[0], x => x[1]);
        }

        // 요소 추가 -> Abbreviations 객체를 생성한 후에 용어를 추가할 때 사용
        public void Add(string abbr, string korean) {
            _dict[abbr] = korean;
        }

        // 인덱서: 줄임말을 키로 사용
        //        Abbreviations 객체에 배열처럼 접근 가능
        //        키(Key)를 [ ] 안에 지정
        //        인덱서에 줄임말을 지정하면 그에 대응하는 한구겅가 반환, 줄임말이 없다면 null 반환
        public string this[string abbr] {
            get {
                return _dict.ContainsKey(abbr) ? _dict[abbr] : null;
            }
        }

        // 한국어로부터 그에 대응되는 줄임말 반환
        public string ToAbbreviation(string japanese) {
            // LINQ에 있는 FirstOrDefault 메서드 사용
            // 반환 형태는 KeyValuePair<string, string>
            return _dict.FirstOrDefault(x => x.Value == japanese).Key;
        }

        // 한국어의 위치를 인수에 넘겨주고 그것이 포함되는 요소(Key,Value)를 모두 구함
        public IEnumerable<KeyValuePair<string, string>> FindAll(string substring) {
            foreach (var item in _dict) {
                if (item.Value.Contains(substring))
                    // yield return -> IEnumerable<T>형을 반환할 때 사용하는 관용구
                    // 반복문을 사용하여 List에 요소를 추가하고 반환하는 메서드가 있으면 yield return 문으로 대체 가능 (거의 모든 경우)
                    // yield return 문을 사용하면 List에 저장하지 않고 시퀀스의 형태로 요소 반환 가능
                    yield return item;
            }
        }
    }
}