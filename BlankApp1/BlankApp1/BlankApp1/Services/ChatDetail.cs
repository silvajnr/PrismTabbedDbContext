using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlankApp1
{
    public class ChatDetail
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }

        //Relationships
        public string ChatId { get; set; }
        [JsonIgnore]
        [ForeignKey("ChatId")]
        public virtual Chat Chats { get; set; }
    }
}