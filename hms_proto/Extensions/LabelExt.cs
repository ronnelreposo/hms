using System.Diagnostics.Contracts;
using System.Windows.Forms;

namespace hms_proto.Extensions
{
    static class LabelExt
    {
        internal static Label ChangeText(this Label label, string text)
        {
            Contract.Requires(label != null);
            Contract.Requires(text != null);

            label.Text = text;
            return label;
        } /* end changeText. */
    }
}
