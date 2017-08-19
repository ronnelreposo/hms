using hms_proto.Controller;
using hms_proto.Records;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace hms_proto
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();

            var rooms = new List<Room> {
                new Room { No = 101, Type = RoomType.Ordinary, Status = RoomStatus.Vacant },
                new Room { No = 103, Type = RoomType.Deluxe, Status = RoomStatus.Vacant },
                new Room { No = 105, Type = RoomType.Ordinary, Status = RoomStatus.Occupied },
                new Room { No = 109, Type = RoomType.Ordinary, Status = RoomStatus.Vacant }
            };

            MainController.LoadVacantRooms(Rooms: rooms, DataGridView: walkIn_dataGridView);
        }

        private void walkIn_checkIn_button_Click(object sender, EventArgs e) =>
            MainController.Transact(
                IsReviewed: walkIn_review_checkBox.Checked,
                Book: new Book
                {
                    Room = new Room { No = 101, Status = RoomStatus.Occupied, Type = RoomType.Deluxe },
                    Customer = new Customer
                    {
                        FirstName = MainController.SetDefault(firstname_tb.Text.Trim()),
                        LastName = MainController.SetDefault(lastname_tb.Text.Trim()),
                        Phone = MainController.SetDefault(phone_textBox.Text.Trim())
                    },
                    DateIn = DateTime.Now,
                    DateOut = walkIn_dateOut_dateTimePicker.Value
                },
                OnReviewCompleted: (message, heading) => MessageBox.Show(message, heading),
                OnCompleted: (message) => MessageBox.Show(message));
    }
}