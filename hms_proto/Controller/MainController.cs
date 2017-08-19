using hms_proto.Records;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Windows.Forms;

namespace hms_proto.Controller
{
    static class MainController
    {
        /* Serves as the database for all book transaction. */
        internal static IList<Book> bookDatabase = new List<Book>();

        static string NotAvail = "Not Available";
        internal static Func<string, string> SetDefault = (value) => string.IsNullOrEmpty(value) ? NotAvail : value;
        internal static Func<DataTable, string, DataTable> DataTableColumnAdder = (dataTable, heading) => { dataTable.Columns.Add(heading); return dataTable; };
        internal static Func<DataTable, string[], DataTable> DataTableRowAdder = (dataTable, row) => { dataTable.Rows.Add(row); return dataTable; };

        internal static Room ToRoom(string[] Data)
        {
            Contract.Requires(Data != null);
            Contract.Requires(Data.Length > 3);
            Contract.Requires(!string.IsNullOrEmpty(Data[0]));
            Contract.Requires(!string.IsNullOrEmpty(Data[1]));
            Contract.Requires(!string.IsNullOrEmpty(Data[2]));

            RoomType roomType;
            Enum.TryParse(value: Data[1], result: out roomType);

            RoomStatus status;
            Enum.TryParse(value: Data[2], result: out status);

            return new Room {
                No = Convert.ToInt16(Data[0]),
                Type = roomType,
                Status = status
            };
        }

        static S toCollection<S, T>(int i, S accumulator, Func<int, bool> condition, Action<S, int> accumulation, T collection)
        {
            if (condition(i)) { return accumulator; }
            accumulation(accumulator, i);
            return toCollection((i + 1), accumulator, condition, accumulation, collection);
        }

        internal static T[] DataGridViewCellCollectionToArray<T>(DataGridViewCellCollection collection)
        {
            Func<int, bool> isGreaterThanCellCount = i => i > (collection.Count - 1);
            Action<T[], int> accumulateSeed = (seed, i) => seed[i] = (T) collection[i].Value;
            var accumulator = new T[collection.Count];
            return toCollection(0,
                accumulator: accumulator,
                condition: isGreaterThanCellCount,
                accumulation: accumulateSeed,
                collection: collection);
        }

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
            var data = DataGridViewCellCollectionToArray<string>(cells);
            return ToRoom(data);
        }

        internal static Func<Room, bool> VacantRoom = room => room.Status == RoomStatus.Vacant;
        internal static Func<Room, string[]> ToRow = room => new[] { room.No.ToString(), room.Type.ToString(), room.Status.ToString() };

        internal static DataTable LoadDataTableHeadings(DataTable dataTable, string[] headings) => headings.Aggregate(dataTable, DataTableColumnAdder);
        internal static DataTable LoadDataTableRows(DataTable dataTable, string[][] rows) => rows.Aggregate(dataTable, DataTableRowAdder);
        internal static string[][] ToVacantRooms(IEnumerable<Room> rooms) => rooms.Where(VacantRoom).Select(ToRow).ToArray();

        /// <summary>
        /// Load Vacant Rooms to DataGridView.
        /// </summary>
        /// <param name="Rooms"></param>
        /// <param name="DataGridView"></param>
        /// <returns></returns>
        internal static DataGridView LoadVacantRooms(IEnumerable<Room> Rooms, DataGridView DataGridView)
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