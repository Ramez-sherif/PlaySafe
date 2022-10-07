namespace PlaySafe.Models
{
    public class Comments
    {
        public Guid  Id { get; set; }
        public string Comment { get; set; }
        public User U_ID { get; set; }

    }
}
