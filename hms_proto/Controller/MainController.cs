using hms_proto.Extensions;
using hms_proto.Records;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hms_proto.Controller
{
    static class MainController
    {
        /* Serves as the database for all book transaction. */
        internal static IList<Book> bookDatabase = new List<Book>();

        /// <summary>
        /// Returns a default Room if the DataGridView has not selected at least one row.
        /// </summary>
        /// <param name="Room">The Default Room.</param>
        /// <param name="DataGridView">The DataGridView in which the row might have selected.</param>
        /// <returns>Room.</returns>
        internal static Room DefaultRoom(Room Room, DataGridView DataGridView)
        {
            var selectedRows = DataGridView.SelectedRows;
            var hasSelectedRow = selectedRows.Count == 0;
            if (hasSelectedRow) { return Room; }
            return selectedRows[0]
                .Cells
                .ToArray()
                .ToRoom();
        }

        /* this happens because, we can't set DataColumnCollection. */
        internal static DataColumnCollection with(this DataColumnCollection ThisColumnCollection, DataColumnCollection ColumnCollection, int i = 0)
        {
            if (i > (ColumnCollection.Count - 1)) return ThisColumnCollection;
            ThisColumnCollection.Add(ColumnCollection[i]);
            return with(ThisColumnCollection, ColumnCollection, (i + 1));
        }
        internal static DataRowCollection with(this DataRowCollection ThisRowCollection, DataRowCollection RowCollection, int i = 0)
        {
            if (i > (RowCollection.Count - 1)) return ThisRowCollection;
            ThisRowCollection.Add(RowCollection[i]);
            return with(ThisRowCollection, RowCollection, (i + 1));
        }
        
        internal static DataTable with(this DataTable dt, DataColumnCollection dcc)
        {
            dt.Columns.with(dcc);
            return dt;
        }
        internal static DataTable with(this DataTable dt, DataRowCollection drc)
        {
            dt.Rows.with(drc);
            return dt;
        }

        internal static DataTable LoadVacantRooms(IEnumerable<Room> rooms, DataTable dataTable)
        {
            var columns = new DataTable().Columns.Add("No", "Type", "Status");
            var rows = rooms.Where(room => room.IsVacant())
                .Select(room => room.ToStringArray())
                .ToArray()
                .Aggregate(new DataTable().Rows, DataRowCollectionExt.AddRow);

            //var x = new DataColumnCollection[] { };

            return dataTable.with(columns).with(rows);
        } /* end Load Vacant Rooms. */

        internal static async Task<DataTable> LoadVacantRoomsAsync(IEnumerable<Room> rooms, DataTable dataTable)
            => await Task.Run(() => LoadVacantRooms(rooms, dataTable));

        /// <summary>
        /// Transact Booking for Walk-In.
        /// </summary>
        /// <param name="IsReviewed"></param>
        /// <param name="Book"></param>
        /// <param name="OnReviewCompleted"></param>
        /// <param name="OnCompleted"></param>
        internal static void Transact(bool IsReviewed, Book Book, Action<string, string> OnReviewCompleted, Action<string> OnCompleted)
        {
            var transactCompleted = "Transaction Completed";
            var notReviewed = !IsReviewed;
            if (notReviewed) { OnCompleted(transactCompleted); return; }
            string message =
                $"Date In: { Book.DateIn }\n" +
                $"Date Out: { Book.DateOut }\n" +
                $"Room No: { Book.Room.No }\n" +
                $"Room Type: { Book.Room.Type }\n" +
                $"Cust First Name: { Book.Customer.FirstName }\n" +
                $"Cust Last Name: { Book.Customer.LastName }\n" +
                $"Cust Phone: { Book.Customer.Phone }";
            OnReviewCompleted(message, transactCompleted);
        } /*end Transact */
    }
}