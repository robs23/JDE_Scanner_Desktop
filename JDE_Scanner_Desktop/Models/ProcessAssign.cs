using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class ProcessAssign : Entity<ProcessAssign>
    {
        [DisplayName("ID")]
        public int ProcessAssignId { get; set; }
        public override int Id
        {
            set => value = ProcessAssignId;
            get => ProcessAssignId;
        }
        [DisplayName("ID zgłoszenia")]
        public int ProcessId { get; set; }
        [Browsable(false)]
        public int UserId { get; set; }
        [DisplayName("Użytkownik")]
        public string UserName { get; set; }

    }
}
