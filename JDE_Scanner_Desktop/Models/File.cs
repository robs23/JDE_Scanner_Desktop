using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class File : Entity<File>
    {
        [DisplayName("ID")]
        public int FileId { get; set; }

        public override int Id {
            set => value = FileId;
            get => FileId;
        }

        [DisplayName("Nazwa")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        [DisplayName("Token")]
        public string Token { get; set; }
    }
}
