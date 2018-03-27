using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TripPinWpf
{
    public class ValidacionItemSeleccionado : ValidationRule
    {
        public bool Requerido { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            if(value != null)
            {
                int selectedIndex = (int)value;
                if (selectedIndex == -1 && Requerido)
                {
                    return new ValidationResult(false, null);
                }

                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, null);
            }
            
         
        }
    }
}
