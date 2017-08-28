using hms_proto.Core;
using System.Windows.Forms;

namespace hms_proto.Extensions
{
    static class MessageBoxExt
    {
        const string emptyString = "";
        internal static Unit Show(string message, string caption = emptyString)
        {
            MessageBox.Show(message, caption);
            return Unit.Unit;
        }
    }
}
