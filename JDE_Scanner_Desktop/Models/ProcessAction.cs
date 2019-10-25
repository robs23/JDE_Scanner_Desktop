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
        public Nullable<DateTime> PlannedFinish { get; set; }
        [DisplayName("Zasób")]
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
        public int? Length
        {
            get
            {
                if (Handlings.Any())
                {
                    if (Handlings.Where(h => h.FinishedOn == null).Any())
                    {
                        //there's at least 1 unfinished handling
                        int finished = Convert.ToInt32(Handlings.Select(h => (h.FinishedOn.Value - h.StartedOn.Value).TotalMinutes).Sum());
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
        public DateTime? StartedOn { get
            {
                if (Handlings.Any())
                {
                    return Handlings.OrderBy(h => h.StartedOn).FirstOrDefault().StartedOn;
                }
                return null;
            }        
        }
        [DisplayName("Zakończenie")]
        public DateTime? FinishedOn
        {
            get
            {
                if (Handlings.Any())
                {
                    if (Handlings.Where(h => h.FinishedOn != null).Any())
                    {
                        return Handlings.Where(h => h.FinishedOn != null).OrderByDescending(h => h.FinishedOn).FirstOrDefault().FinishedOn;
                    }
                    else
                    {
                        return DateTime.Now;
                    }
                }
                
                return null;
            }
        }
        
        [DisplayName("Obsługujący")]
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

        //public bool Evaluate(string propertyName, object attributeType)
        //{

        //    try
        //    {
        //        //AttributeCollection attributes = TypeDescriptor.GetAttributes(PlannedStart);
        //        AttributeCollection attributes = TypeDescriptor.GetProperties(this)["PlannedStart"].Attributes;
        //        foreach(var a in attributes)
        //        {
        //            if (a.GetType() == typeof(MergableAttribute))
        //            {
        //                return ((MergableAttribute)a).Mergable;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }
        //    return false; //((MergableAttribute)attributes[typeof(MergableAttribute)]).Mergable;

        //}

        public bool Evaluate(string propertyName, Type attributeType)
        {

            try
            {
                //AttributeCollection attributes = TypeDescriptor.GetAttributes(PlannedStart);
                AttributeCollection attributes = TypeDescriptor.GetProperties(this)["PlannedStart"].Attributes;
                foreach (var a in attributes)
                {
                    if (a.GetType() == attributeType)
                    {
                        return a.Equals(true);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return false; //((MergableAttribute)attributes[typeof(MergableAttribute)]).Mergable;

        }
    }
}
