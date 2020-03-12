using System.ComponentModel.DataAnnotations;

namespace wall.Models
{
    public class Message : BaseEntity
    {

        public int id { get; set; }

        public int user_id { get; set; }

        public string message { get; set; }

    }
    public class Comment : BaseEntity
  {
    public int id { get; set; }
    public string comment { get; set; }
    public int messages_id { get; set; }
    public int users_id { get; set; }
  }
}
