using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class SendMailModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MailTo { get; set; }
        public string MailCC { get; set; }
        public string MailSubject { get; set; }      
        public string MailBody { get; set; }
        public List<IFormFile>? Attachments { get; set; }
        public bool MailAccess { get; set; }
        public DateTime MailDate { get; set; }
      
    }
}
