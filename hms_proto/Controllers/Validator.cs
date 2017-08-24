using hms_proto.Utils;
using System;
using System.Linq;
using System.Windows.Forms;
using hms_proto.Extensions;

namespace hms_proto.Controllers
{
    static class Validator
    {
        internal const int Treshold = 6;
        static Func<string, Func<Label, Label>> changeText = text => label => label.ChangeText(text);

        internal static bool hasEmptyFields (Tuple<Label, string>[] fieldsAndValues)
        {
            Func<Tuple<Label, string>, bool> emptyField = fieldAndValue => !fieldAndValue.Item2.HasValue();
            Action<Label[]> showRequiredField = labels => labels.Select(changeText("is required.")).ToArray();
            return Util.IsValidValuedField(
              Validation: emptyField,
              OnInValidField: showRequiredField,
              ErrorFieldsAndValues: fieldsAndValues);
        }

        internal static bool hasLessInputFields (Tuple<Label, string>[] fieldsAndValues, int treshold = Treshold)
        {
            Func<Tuple<Label, string>, bool> shortValueField = fieldAndValue => fieldAndValue.Item2.IsLengthLessThan(treshold);
            Action<Label[]> showShortField = labels => labels.Select(changeText("is too short.")).ToArray();
            return Util.IsValidValuedField(
              Validation: shortValueField,
              OnInValidField: showShortField,
              ErrorFieldsAndValues: fieldsAndValues);
        }
    }
}
