using System.Windows.Forms;
using hms_proto.Core;


namespace hms_proto.Extensions
{
    static class FormExt
    {
        internal static Unit UShowDialog(this Form form)
        {
            form.ShowDialog();
            return Unit.Unit;
        }
        internal static Unit UShow(this Form form)
        {
            form.Show();
            return Unit.Unit;
        }
        internal static Unit UHide(this Form form)
        {
            form.Hide();
            return Unit.Unit;
        }
    }
}
