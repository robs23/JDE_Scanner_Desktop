using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class StorageBin : Entity<StorageBin>
    {
        public override int Id
        {
            set => value = StorageBinId;
            get => StorageBinId;
        }
        [DisplayName("ID")]
        public int StorageBinId { get; set; }
        [DisplayName("Numer")]
        public string Number { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Token")]
        public string Token { get; set; }
    }
}
