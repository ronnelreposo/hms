using hms_proto.Controller;
using hms_proto.Records;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using hms_proto.Extensions;
using System.Data;
using hms_proto.Core;

namespace hms_proto
{
    public partial class MainForm : Form
    {
        List<Room> rooms = new List<Room> {
            new Room(No: 101, Type: RoomType.Ordinary, Status: RoomStatus.Vacant),
            new Room(No: 103, Type: RoomType.Deluxe, Status: RoomStatus.Vacant),
            new Room(No: 105, Type: RoomType.Ordinary, Status: RoomStatus.Occupied),
            new Room(No: 109, Type: RoomType.Ordinary, Status: RoomStatus.Vacant)
        };

        public MainForm ()
        {
            InitializeComponent();
        }

        readonly string NotAvail = "Not Available";
        private void walkIn_checkIn_button_Click (object sender, EventArgs e)
        {
            var book = new Book(
                Room: MainController.DefaultRoom(Room: rooms[0], DataGridView: walkIn_dataGridView),
                Customer: new Customer(
                    FirstName: firstname_tb.Text.Trim().OrWithValue(NotAvail),
                    LastName: lastname_tb.Text.Trim().OrWithValue(NotAvail),
                    Phone: phone_textBox.Text.Trim().OrWithValue(NotAvail)),
                DateIn: DateTime.Now,
                DateOut: walkIn_dateOut_dateTimePicker.Value);

            /* *** On Functional Reactive. */
            //var savedBook = saveBook(book);
            //MainController.Transact( 
            //    IsReviewed: walkIn_review_checkBox.Checked,
            //    Book: book,
            //    OnReviewCompleted: (message, heading) => MessageBoxExt.Show(message, heading),
            //    OnCompleted: message => MessageBoxExt.Show(message));

            MessageBox.Show(book.ToString());
        }

        void walkIn_dataGridView_CellClick (object sender, DataGridViewCellEventArgs e) =>
            walkIn_roomNo_label.Text = ( sender as DataGridView )
                .SelectedRows[0]
                .Cells
                .ToArray<string>()
                .ToRoom()
                .No
                .ToString();

        protected override async void OnLoad (EventArgs _)
        {
            var vacantRooms = await MainController.LoadVacantRoomsAsync(rooms: rooms, dataTable: new DataTable());
            walkIn_dataGridView.DataSource = vacantRooms.DefaultView;
        }
    }
}