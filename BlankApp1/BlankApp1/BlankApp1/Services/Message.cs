using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlankApp1
{
    public class Message
    {
        [Key]
        public string Id { get; set; }
        public string Text { get; set; }


        //Relationships
        public virtual string ChatId { get; set; }
        [JsonIgnore]
        [ForeignKey("ChatId")]
        public virtual Chat Chats { get; set; }

    }
}