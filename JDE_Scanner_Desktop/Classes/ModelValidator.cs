using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDE_Scanner_Desktop.Classes
{
    public class ModelValidator
    {
        public bool Validate(object instance)
        {
            string errorMsg = "";
            bool val = false;
            ValidationContext context = new ValidationContext(instance);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(instance, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                {
                    errorMsg += result.ErrorMessage + Environment.NewLine;
                }
                MessageBox.Show(errorMsg);
            }
            else
            {
                val = true;
            }

            return val;
        }
    }
}
