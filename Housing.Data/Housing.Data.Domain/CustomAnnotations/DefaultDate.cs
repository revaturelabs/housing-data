using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Housing.Data.Domain.CustomAnnotations
{
    public sealed class DefaultDate :ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = true;
            if ((DateTime)value <= DateTime.MinValue)
            {
                result = false;
            }
            return result;
        }
    }
}
