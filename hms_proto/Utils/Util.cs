using System;
using System.Linq;
using System.Windows.Forms;

namespace hms_proto.Utils
{
  static class Util
  {
    internal static Func<Label, Label> clearLabel = Label => { Label.Text = string.Empty; return Label; };
    internal static Label[] clearLabels(Label[] Labels) => Labels.Select(clearLabel).ToArray();
  }
}
