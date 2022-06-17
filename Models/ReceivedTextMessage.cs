using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace whatsapp_chatbot.Models
{
    public class NotificationPayload
    {
        // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
        public class Change
        {
            [JsonPropertyName("value")]
            public Value Value { get; set; }

            [JsonPropertyName("field")]
            public string Field { get; set; }
        }

        public class Contact
        {
            [JsonPropertyName("profile")]
            public Profile Profile { get; set; }

            [JsonPropertyName("wa_id")]
            public string WaId { get; set; }
        }

        public class Entry
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("changes")]
            public List<Change> Changes { get; set; }
        }

        public class Message
        {
            [JsonPropertyName("from")]
            public string From { get; set; }

            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("timestamp")]
            public string Timestamp { get; set; }

            [JsonPropertyName("text")]
            public Text Text { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }
        }

        public class Metadata
        {
            [JsonPropertyName("display_phone_number")]
            public string DisplayPhoneNumber { get; set; }

            [JsonPropertyName("phone_number_id")]
            public string PhoneNumberId { get; set; }
        }

        public class Profile
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }
        }

       
        [JsonPropertyName("object")]
        public string Object { get; set; }

        [JsonPropertyName("entry")]
        public List<Entry> EntryObject { get; set; }
        

        public class Text
        {
            [JsonPropertyName("body")]
            public string Body { get; set; }
        }

        public class Value
        {
            [JsonPropertyName("messaging_product")]
            public string MessagingProduct { get; set; }

            [JsonPropertyName("metadata")]
            public Metadata Metadata { get; set; }

            [JsonPropertyName("contacts")]
            public List<Contact> Contacts { get; set; }

            [JsonPropertyName("messages")]
            public List<Message> Messages { get; set; }
        }


    }
}
