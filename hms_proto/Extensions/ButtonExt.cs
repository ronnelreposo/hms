using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Forms;

namespace hms_proto.Extensions
{
    static class ButtonExt
    {
        internal static IObservable<EventPattern<EventArgs>> StreamClick (this Button button) =>
            Observable.FromEventPattern(button, "Click");

        internal static BehaviorSubject<bool> BehaviorEnable (this Button button, bool enable) =>
            new BehaviorSubject<bool>(enable);

        internal static BehaviorSubject<bool> BehaviorEnable (this Button button, bool enable, IObservable<bool> sEnable)
        {
            var subj = button.BehaviorEnable(enable);
            sEnable.Subscribe(subj);
            subj.Subscribe(b => button.Enabled = b);

            return subj;
        }
    }
}
