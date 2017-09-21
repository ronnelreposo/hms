using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace hms_proto.Extensions
{
    static class ButtonExt
    {
        internal static IObservable<EventPattern<EventArgs>> StreamClick (this Button button) => Observable.FromEventPattern(button, "Click");
    }
}
