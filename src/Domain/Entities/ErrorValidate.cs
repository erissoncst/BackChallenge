using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ErrorValidate
    {
        public String ErrorMessage { get; set; }
        public String PropertyName { get; set; }

        /*internal static IEnumerable<ErrorValidate> Of(FluentValidation.Results.ValidationResult res)
        {
            return res.Errors.Select(erro => new ErrorValidate 
            { 
                ErrorMessage = erro.ErrorMessage, 
                PropertyName  = erro.PropertyName 
            });
        }*/

        internal static IEnumerable<ErrorValidate> Of(String propertyName, String errorMessage)
        {
            var list = new List<ErrorValidate>();
            list.Add(new ErrorValidate
            {
                ErrorMessage = errorMessage,
                PropertyName = propertyName
            });
            return list;
        }
    }
}
