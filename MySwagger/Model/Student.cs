namespace MySwagger.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public List<StudentAddress> Address { get; set; }
    }

    public class StudentAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
    }

}
