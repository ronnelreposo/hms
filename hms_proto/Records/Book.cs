using System;

namespace hms_proto.Records
{
    struct Book
    {
        internal Room Room { get; set; }
        internal Customer Customer { get; set; }
        internal DateTime DateIn { get; set; }
        internal DateTime DateOut { get; set; }
    }
}
