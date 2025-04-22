

namespace kulup.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? MessageContent { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}