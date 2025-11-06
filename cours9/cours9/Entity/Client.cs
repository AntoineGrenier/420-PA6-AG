namespace cours9.Entity
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
    }
}
