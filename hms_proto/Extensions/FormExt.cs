using System.Windows.Forms;
using System.Reactive;
using System;
using System.Reactive.Linq;

namespace hms_proto.Extensions
{
    static class FormExt
    {
        internal static IObservable<EventPattern<EventArgs>> StreamEventLoad (this Form form) =>
            Observable.FromEventPattern(form, "Load");

        internal static Unit UShowDialog(this Form form)
        {
            form.ShowDialog();
            return Unit.Default;
        }
        internal static Unit UShow(this Form form)
        {
            form.Show();
            return Unit.Default;
        }
        internal static Unit UHide(this Form form)
        {
            form.Hide();
            return Unit.Default;
        }
    }
}
