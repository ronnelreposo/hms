using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace hms_proto.Extensions
{
    static class TextBoxExt
    {
        internal static IObservable<EventPattern<EventArgs>> StreamEventTextChanged (this TextBox textbox)
            => Observable.FromEventPattern(textbox, "TextChanged");
        internal static IObservable<string> StreamStringTextChanged (this TextBox textbox)
            => Observable.FromEventPattern(textbox, "TextChanged").Select(_ => textbox.Text);
    }
}
