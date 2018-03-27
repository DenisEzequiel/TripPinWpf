using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TripPinWpf
{
    public class ValidacionTexto : ValidationRule
    {
        public int Largo { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var texto = value as string;

            if (texto != null)
            {
                if (texto == "")
                {
                    return new ValidationResult(false, "Este campo no puede estar vacio");
                }
                else if (texto.Length > Largo)
                {
                    return new ValidationResult(false, "El campo tiene que tener una longitud menor o igual a 30");
                }

            }
            return new ValidationResult(true, null);
        }
    }
}
