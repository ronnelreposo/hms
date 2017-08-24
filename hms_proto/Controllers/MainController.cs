using hms_proto.Extensions;
using hms_proto.Records;
using System;
using System.Collections.Generic;
using System.Data;
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

        internal static DataTable LoadVacantRooms(IEnumerable<Room> rooms, DataTable dataTable)
        {
            var columns = dataTable.Columns.Add("No", "Type", "Status");
            var rows = rooms.Where(room => room.IsVacant())
                .Select(room => room.ToStringArray())
                .ToArray()
                .Aggregate(dataTable.Rows, DataRowCollectionExt.AddRow);
            return dataTable;
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
            OnReviewCompleted(Book.ToString(), transactCompleted);
        } /*end Transact */
    }
}