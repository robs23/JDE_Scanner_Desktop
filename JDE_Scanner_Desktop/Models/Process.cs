using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE_Scanner_Desktop.Models
{
    public class Process
    {
        public int ProcessId { get; set; }
        public string Description { get; set; }
        public DateTime? StartedOn { get; set; }
        public int StartedBy { get; set; }
        public string StartedByName { get; set; }
        public DateTime? FinishedOn { get; set; }
        public int FinishedBy { get; set; }
        public string FinishedByName { get; set; }
        public int ActionTypeId { get; set; }
        public string ActionTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsFrozen { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsSuccessfull { get; set; }
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public string Output { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public int TenantId { get; set; }
        public string TenantName { get; set; }
    }
}
