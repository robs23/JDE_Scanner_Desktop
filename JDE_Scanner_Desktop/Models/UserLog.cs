using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    class UserLog : Entity<UserLog>
    {
        [Browsable(false)]
        public override int Id
        {
            set => value = UserLogId;
            get => UserLogId;
        }

        [DisplayName("ID")]
        public int UserLogId { get; set; }
        [DisplayName("Platforma")]
        public string Platform { get; set; }
        [DisplayName("Urządzenie")]
        public string Device { get; set; }
        [DisplayName("Nazwa")]
        public string LogName { get; set; }
        [DisplayName("Po crashu")]
        public Nullable<bool> HasTheAppCrashed { get; set; }
        [DisplayName("Na życzenie")]
        public Nullable<bool> OnRequest { get; set; }
        [DisplayName("Komentarz")]
        public string Comment { get; set; }
    }
}
