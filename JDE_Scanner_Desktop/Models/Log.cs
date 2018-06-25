using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using JDE_Scanner_Desktop.Classes;

namespace JDE_Scanner_Desktop.Models
{
    public class Log
    {
        [DisplayName("ID")]
        public int LogId { get; set; }
        [DisplayName("Czas")]
        public DateTime TimeStamp { get; set; }
        [DisplayName("Opis")]
        public string Descripiton { get; set; }
        [Browsable(false)]
        public int UserId { get; set; }
        [DisplayName("Użytkownik")]
        public string UserName { get; set; }
        [Browsable(false)]
        public int TenantId { get; set; }
        [Browsable(false)]
        public string TenantName { get; set; }
        [DisplayName("Poprzednia wartość")]
        public string OldValue { get; set; }
        [DisplayName("Nowa wartość")]
        public string NewValue { get; set; }
    }
}
