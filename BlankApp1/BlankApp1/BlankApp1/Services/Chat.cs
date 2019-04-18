using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlankApp1
{

    public class Chat
    {
        [Key]
        public string Id { get; set; }
        public string SomeString { get; set; }
        public DateTime DateCreated { get; set; }

        //Relationships
        public IEnumerable<Message> Messages { get; set; }
        public ChatDetail ChatDetails { get; set; }


    }
}