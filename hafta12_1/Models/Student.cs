namespace hafta12_1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }

        public ICollection<Register> DersBilgileri { get; set; }
    }
}
