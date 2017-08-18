using System;
using System.Linq;
using System.Windows.Forms;

namespace hms_proto.Utils
{
  static class Util
  {
    internal static Func<Label, Label> clearLabel = Label => { Label.Text = string.Empty; return Label; };
    internal static Label[] clearLabels(Label[] Labels) => Labels.Select(clearLabel).ToArray();
    
    /// <summary>
    /// Checks if the value is valid using Validation.
    /// if the value is invalid, then OnInValidField is invoked,
    /// otherwise none.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Validation">The validator.</param>
    /// <param name="OnInValidField">The action invoked if has invalid values.</param>
    /// <param name="ErrorFieldsAndValues">A pair of values T and string. Representing Field and Value.</param>
    /// <returns>true if has invalid value(s).</returns>
    internal static bool IsValidValuedField<T>(Func<Tuple<T, string>, bool> Validation, Action<T[]> OnInValidField, Tuple<T, string>[] ErrorFieldsAndValues)
    {
      var invalidLabels = ErrorFieldsAndValues.Where(Validation);
      var hasInvalids = invalidLabels.Count() > 0;
      if (hasInvalids) {
        Func<Tuple<T, string>, T> firstItem = tuple => tuple.Item1;
        OnInValidField(invalidLabels.Select(firstItem).ToArray());
        return true;
      }
      return false;
    } /* end isValidValuedField */
  }
}
