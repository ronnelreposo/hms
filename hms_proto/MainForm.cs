using hms_proto.Controller;
using hms_proto.Records;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using hms_proto.Extensions;

namespace hms_proto
{
    public partial class MainForm: Form
    {
        List<Room> rooms = new List<Room> {
                new Room { No = 101, Type = RoomType.Ordinary, Status = RoomStatus.Vacant },
                new Room { No = 103, Type = RoomType.Deluxe, Status = RoomStatus.Vacant },
                new Room { No = 105, Type = RoomType.Ordinary, Status = RoomStatus.Occupied },
                new Room { No = 109, Type = RoomType.Ordinary, Status = RoomStatus.Vacant }
        };

        public MainForm()
        {
            InitializeComponent();

            MainController.LoadVacantRooms(Rooms: rooms, DataGridView: walkIn_dataGridView);
        }

        private void walkIn_checkIn_button_Click(object sender, EventArgs e)
        {
            const string NotAvail = "Not Available";
            var book = new Book
            {
                Room = MainController.DefaultRoom(Room: rooms[0], DataGridView: walkIn_dataGridView),
                Customer = new Customer
                {
                    FirstName = firstname_tb.Text.Trim()._(NotAvail),
                    LastName = lastname_tb.Text.Trim()._(NotAvail),
                    Phone = phone_textBox.Text.Trim()._(NotAvail)
                },
                DateIn = DateTime.Now,
                DateOut = walkIn_dateOut_dateTimePicker.Value
            };

            var savedBook = saveBook(book);

            MainController.Transact(
                IsReviewed: walkIn_review_checkBox.Checked,
                Book: book,
                OnReviewCompleted: (message, heading) => savedBook(() => MessageBox.Show(message, heading))(err => MessageBox.Show(err)),
                OnCompleted: (message) => savedBook(() => MessageBox.Show(message))(err => MessageBox.Show(err)));
        }

        Func<Book, Func<Action, Action<Action<string>>>> saveBook = book => onSuccess => onFail =>
        {
            MainController.bookDatabase.Add(book);
            onSuccess();
            onFail("failure message");
        };

        void walkIn_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e) =>
            walkIn_roomNo_label.Text = ((DataGridView)sender)
                .SelectedRows[0]
                .Cells
                .ToArray<string>()
                .ToRoom()
                .No
                .ToString();
    }
}