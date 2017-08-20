using hms_proto.Extensions;
using hms_proto.Records;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            var firstSelectedRow = selectedRows[0];
            var cells = firstSelectedRow.Cells;
            var data = cells.ToArray<string>();
            return data.ToRoom();
        }

        internal static Func<Room, bool> VacantRoom = room => room.Status == RoomStatus.Vacant;
        internal static Func<Room, string[]> ToArray = room => new[] { room.No.ToString(), room.Type.ToString(), room.Status.ToString() };

        /// <summary>
        /// Load Vacant Rooms to DataGridView.
        /// </summary>
        /// <param name="Rooms"></param>
        /// <param name="DataGridView"></param>
        /// <returns></returns>
        internal static DataGridView LoadVacantRooms(IEnumerable<Room> Rooms, DataGridView DataGridView)
        {
            var headings = new[] { "No", "Type", "Status" };

            var dt = new DataTable();
            dt.Columns.Add(headings);

            var rows = Rooms.Where(VacantRoom)
                .Select(ToArray)
                .ToArray()
                .Aggregate(dt.Rows, DataRowCollectionExt.AddRow);

            DataGridView.DataSource = dt.DefaultView;
            return DataGridView;
        } /* end Load Vacant Rooms. */

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