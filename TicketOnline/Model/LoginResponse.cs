namespace TicketOnline.Model
{
    public class LoginResponse
    {
       public CustomerDTO user { get; set; }
        
        public string token { get; set; }
    }
}
