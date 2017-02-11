  
namespace OnePos.Message.Model
{
    public class DatabaseConnection
    {
        public int ConnectionId { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DatabaseName { get; set; }
        public int StoreId { get; set; }
        public bool IsMainDB { get; set; }
    }
}
