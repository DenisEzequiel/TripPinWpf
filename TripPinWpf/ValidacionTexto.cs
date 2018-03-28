using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TripPinWpf
{
    public class ValidacionTexto : ValidationRule
    {
        public int LargoMaximo { get; set; }
        public bool Requerido { get; set; }
        public string ExpReg { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var texto = value as string;

            if (texto != null)
            {
                if (texto == "" && Requerido)
                {
                    return new ValidationResult(false, "Este campo no puede estar vacio");
                }
                else if (texto.Length > LargoMaximo)
                {
                    return new ValidationResult(false, "El campo tiene que tener una longitud menor o igual a "+LargoMaximo);
                }
                else if(ExpReg != null && !Regex.IsMatch(texto, ExpReg))
                {
                    return new ValidationResult(false,null);
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
