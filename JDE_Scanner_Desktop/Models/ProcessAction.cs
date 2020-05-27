using JDE_Scanner_Desktop.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class ProcessAction : Entity<ProcessAction>
    {
        [Browsable(false)]
        public override int Id
        {
            set => value = ProcessActionId;
            get => ProcessActionId;
        }
        [DisplayName("ID")]
        public int ProcessActionId { get; set; }
        [Browsable(false)]
        public Nullable<int> ProcessId { get; set; }
        [DisplayName("Planowany start")]
        [Mergable(true)]
        public Nullable<DateTime> PlannedStart { get; set; }
        [DisplayName("Planowany koniec")]
        [Mergable(true)]
        public Nullable<DateTime> PlannedFinish { get; set; }
        [DisplayName("Zasób")]
        [Mergable(true)]
        public string PlaceName { get; set; }
        [Browsable(false)]
        public Nullable<int> ActionId { get; set; }
        [DisplayName("Czynność")]
        public string ActionName { get; set; }
        [DisplayName("Założony czas [min]")]
        public int? GivenTime { get; set; }
        [DisplayName("Typ")]
        public string Type { get; set; }
        [Browsable(false)]
        public string[] AssignedUsers { get; set; }
        [DisplayName("Przypisani użytkownicy")]
        public string AssignedUsersString { get { return string.Join(", ", AssignedUsers); } }
        [Browsable(false)]
        public List<Handling> Handlings { get; set; }
        [DisplayName("Długość [min]")]
        [Mergable(true)]
        public int? Length
        {
            get
            {
                if (Handlings.Any())
                {
                    if (Handlings.Where(h => h.FinishedOn == null).Any())
                    {
                        //there's at least 1 unfinished handling
                        int finished = Convert.ToInt32(Handlings.Where(h=>h.FinishedOn!=null).Select(h => (h.FinishedOn.Value - h.StartedOn.Value).TotalMinutes).Sum());
                        int unfinished = Convert.ToInt32(Handlings.Select(h => (DateTime.Now - h.StartedOn.Value).TotalMinutes).Sum());
                        return finished + unfinished;
                    }
                    else
                    {
                        return Convert.ToInt32(Handlings.Select(h => (h.FinishedOn.Value - h.StartedOn.Value).TotalMinutes).Sum());
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        [DisplayName("Rozpoczęcie")]
        [Mergable(true)]
        public DateTime? StartedOn { get; set; }
        [DisplayName("Zakończenie")]
        [Mergable(true)]
        public DateTime? FinishedOn { get; set; }
        
        
        [DisplayName("Obsługujący")]
        [Mergable(true)]
        public string HandlingUsers { get { return string.Join(", ", Handlings.GroupBy(h=>h.UserName).Select(h=>h.Key)); } }

        public async override Task<bool> Add()
        {
            bool x = await base.Add();
            if (x)
            {
                try
                {
                    ProcessAction _this = JsonConvert.DeserializeObject<ProcessAction>(AddedItem);
                    this.ProcessActionId = _this.ProcessActionId;
                    this.TenantId = _this.TenantId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("Tworzenie nowego rekordu zakończone powodzeniem!");
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
