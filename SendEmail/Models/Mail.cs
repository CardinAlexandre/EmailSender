namespace SendEmail.Models
{
	public abstract class Mail
	{
        public string Email { get; set; }

        public Mail(string email)
        {
            Email = email;
        }

        public abstract void AfficherDetails();
    }

    public class Sender : Mail
    {
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public Sender(string email, string password, string host, int port) : base(email)
        {
            Email = email;
            Password = password;
            Host = host;
            Port = port;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine($"Email: {Email}, Password: {Password}, Host: {Host}, Port: {Port}");
        }
    }

    public class Receiver : Mail
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public Receiver(string email, string name, string message) : base(email)
        {
            Email = email;
            Name = name;
            Message = message;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine($"Email: {Email}, Name: {Name}, Message: {Message}");
        }
    }
}

