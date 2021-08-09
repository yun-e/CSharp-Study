namespace FunctionsOfDictionary {
    public class Employee {
        public string Name { get; set; }
        public int Id { get; set; }

        public Employee(int id, string name) {
            Id = id;
            Name = name;
        }
    }
}