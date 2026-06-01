namespace hafta12_1.Models
{
    public class Lesson
    {
        public int Id { get; set; } 
        public string Code { get; set; }
        public string Name { get; set; }

        //public ICollection<Register> DersKayitlari { get; set; }
        public ICollection<Register> DersKa {  get; set; }  
    }
}
