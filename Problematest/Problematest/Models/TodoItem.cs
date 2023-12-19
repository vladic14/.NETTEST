namespace Problematest.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public DateTime DataLimita { get; set; }
        public StatusSarcina Status { get; set; }
    }

    public enum StatusSarcina
    {
        Pending = 0,
        Done = 1,
        Rejected = 2
    }

}
