namespace hafta12_1.Models
{
    public class Register
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; } //Navigation Property
        public int LessonId { get; set; }

    
        public Lesson Lesson { get; set; }//Navigation Property

        public DateTime Date { get; set; }
    }
}
