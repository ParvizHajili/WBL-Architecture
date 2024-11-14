using Core.Validation;
using System.Text;

namespace Core.Extensions
{
    public static class CollectionExtenstionMethods
    {
        public static string ValidationErrorMessageNewLine(this List<ValidationErrorModel> model)
        {
            StringBuilder sb = new();

            foreach (var error in model)
            {
                sb.Append(error.ErrorMessage);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        public static string ValidationErrorMessagesWithSeperator(this List<ValidationErrorModel> model)
        {
            StringBuilder sb = new();
            foreach (var error in model)
            {
                sb.Append(error.ErrorMessage);
                sb.Append("*#");
            }

            return sb.ToString();
        }
    }
}
