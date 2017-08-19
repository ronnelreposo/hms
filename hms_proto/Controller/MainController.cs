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
        static string NotAvail = "Not Available";
        internal static Func<string, string> SetDefault = (value) => string.IsNullOrEmpty(value) ? NotAvail : value;
        internal static Func<DataTable, string, DataTable> DataTableColumnAdder = (dataTable, heading) => { dataTable.Columns.Add(heading); return dataTable; };
        internal static Func<DataTable, string[], DataTable> DataTableRowAdder = (dataTable, row) => { dataTable.Rows.Add(row); return dataTable; };
        internal static Func<Room, bool> VacantRoom = room => room.Status == RoomStatus.Vacant;
        internal static Func<Room, string[]> ToRow = room => new[] { room.No.ToString(), room.Type.ToString(), room.Status.ToString() };

        internal static DataTable LoadDataTableHeadings(DataTable dataTable, string[] headings) => headings.Aggregate(dataTable, DataTableColumnAdder);
        internal static DataTable LoadDataTableRows(DataTable dataTable, string[][] rows) => rows.Aggregate(dataTable, DataTableRowAdder);
        internal static string[][] ToVacantRooms(List<Room> rooms) => rooms.Where(VacantRoom).Select(ToRow).ToArray();

        /// <summary>
        /// Load Vacant Rooms to DataGridView.
        /// </summary>
        /// <param name="Rooms"></param>
        /// <param name="DataGridView"></param>
        /// <returns></returns>
        internal static DataGridView LoadVacantRooms(List<Room> Rooms, DataGridView DataGridView)
        {
            var vacantRooms = ToVacantRooms(Rooms);
            var headings = new[] { "No", "Type", "Status" };
            var dataTableWithHeadings = LoadDataTableHeadings(new DataTable(), headings);
            var dataTableWithRows = LoadDataTableRows(dataTableWithHeadings, vacantRooms);

            DataGridView.DataSource = dataTableWithRows.DefaultView;
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
                "Date In: " + Book.DateIn + "\n" +
                "Date Out: " + Book.DateOut + "\n" +
                "Room No: " + Book.Room.No + "\n" +
                "Room Type: " + Book.Room.Type + "\n" +
                "Cust First Name: " + Book.Customer.FirstName + "\n" +
                "Cust Last Name: " + Book.Customer.LastName + "\n" +
                "Cust Phone: " + Book.Customer.Phone;
            OnReviewCompleted(message, transactCompleted);
        } /*end TransactBook */
    }
}