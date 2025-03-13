namespace SignalRChatServer.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string Email { get; set;}

        public string Address { get; set; }

        public string Password {get; set; }

        public string Picture {get; set; }

        public string Status {get; set; }
    
    }
}