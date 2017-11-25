using System;
using System.Diagnostics.Contracts;
using System.Reactive.Subjects;
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

        internal static BehaviorSubject<string> BehaviorText (this Label label, string text) =>
            new BehaviorSubject<string>(text);

        internal static BehaviorSubject<string> BehaviorText (this Label label, string text, IObservable<string> sText)
        {
            var subj = label.BehaviorText(text);
            sText.Subscribe(subj);
            subj.Subscribe(text_ => label.Text = text_);

            return subj;
        }
    }
}
