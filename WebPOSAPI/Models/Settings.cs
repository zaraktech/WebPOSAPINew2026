using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Settings
    {
        [Key]
        public int Key { get; set; }

        public string KeyName { get; set; }

        public string KeyValue { get; set; }
    }
}
