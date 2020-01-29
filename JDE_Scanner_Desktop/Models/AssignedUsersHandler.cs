using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Models
{
    public class AssignedUsersHandler
    {
        public List<User> AssignedUsers { get; set; } = new List<User>();
        public List<User> AssignableUsers { get; set; }
        public Form ParentForm { get; set; }
        public List<Tuple<int, string, bool>> Users { get; set; } = new List<Tuple<int, string, bool>>();

        public frmOptionPicker FrmOptionPicker { get; set; }
        public string AssignedUserNames { get; set; }
        public int ProcessId { get; set; }

        public Process Processes { get; set; }

        public ProcessAssignKeeper ProcessAssigns { get; set; } = new ProcessAssignKeeper();

        public AssignedUsersHandler(Form parent)
        {
            ParentForm = parent;
        }

        public async Task LoadProcessAssigns()
        {
            if (ProcessId > 0)
            {
                await ProcessAssigns.Refresh($"ProcessId={ProcessId}");
                if (ProcessAssigns.Items.Any())
                {
                    foreach (ProcessAssign pa in ProcessAssigns.Items)
                    {
                        AssignedUsers.Add(new User { UserId = pa.UserId, Name = pa.UserName });
                        AssignedUserNames += pa.UserName + ", ";
                    }
                    AssignedUserNames = AssignedUserNames.Substring(0, AssignedUserNames.Length - 2);
                }
            }

        }

        public async Task LoadUsers()
        {
            UsersKeeper uk = new UsersKeeper();
            await uk.Refresh();
            AssignableUsers = uk.Items;
        }

        public void ShowDialog()
        {
            if (AssignableUsers.Any())
            {
                Users.Clear();
                foreach (User u in AssignableUsers)
                {
                    Users.Add(new Tuple<int, string, bool>(u.UserId, u.FullName, AssignedUsers.Where(us => us.UserId == u.UserId).Any()));
                }
                FrmOptionPicker = new frmOptionPicker(ParentForm, Users);
                DialogResult result = FrmOptionPicker.ShowDialog(ParentForm);
                if (result == DialogResult.OK)
                {
                    
                    var PickedItems = FrmOptionPicker.ReturnItems;
                    AssignedUsers.Clear();

                    if (PickedItems.Any(i => i.Item3 == true))
                    {
                        foreach (var item in PickedItems.Where(i => i.Item3 == true))
                        {
                            AssignedUsers.Add(new User { UserId = item.Item1, Name = item.Item2 });
                        }
                        AssignedUserNames = "Przypisani: " + string.Join(", ", PickedItems.Where(t => t.Item3).Select(t => t.Item2).ToList());
                    }
                    else
                    {
                        AssignedUserNames = "Przypisani: ";
                    }
                }
            }
            
        }
    }
}
