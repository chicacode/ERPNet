using ERPNet.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace ERPNet.Models
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
      
    }
}
