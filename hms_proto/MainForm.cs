using hms_proto.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hms_proto
{
  public partial class MainForm: Form
  {
    public MainForm()
    {
      InitializeComponent();

      var roomDatabase = new List<Room>
      {
        new Room { No = 101, Type = RoomType.Ordinary, Status = RoomStatus.Vacant },
        new Room { No = 103, Type = RoomType.Deluxe, Status = RoomStatus.Vacant },
        new Room { No = 105, Type = RoomType.Ordinary, Status = RoomStatus.Occupied },
        new Room { No = 109, Type = RoomType.Ordinary, Status = RoomStatus.Vacant }
      };

      loadVacantRooms(roomDatabase, walkIn_dataGridView);
    }

    Func<DataTable, string, DataTable> dataTableColumnAdder = (dataTable, heading) => { dataTable.Columns.Add(heading); return dataTable; };
    Func<DataTable, string[], DataTable> dataTableRowAdder = (dataTable, row) => { dataTable.Rows.Add(row); return dataTable; };
    Func<Room, bool> vacantRoom = room => room.Status == RoomStatus.Vacant;
    Func<Room, string[]> toRow = room => new[] { room.No.ToString(), room.Type.ToString(), room.Status.ToString() };

    DataTable loadDataTableHeadings(DataTable dataTable, string[] headings) => headings.Aggregate(dataTable, dataTableColumnAdder);
    DataTable loadDataTableRows(DataTable dataTable, string[][] rows) => rows.Aggregate(dataTable, dataTableRowAdder);
    string[][] toVacantRooms(List<Room> rooms) => rooms.Where(vacantRoom).Select(toRow).ToArray();

    DataGridView loadVacantRooms(List<Room> rooms, DataGridView dataGridView)
    {
      var vacantRooms = toVacantRooms(rooms);
      var headings = new[] { "No", "Type", "Status" };
      var dataTableWithHeadings = loadDataTableHeadings(new DataTable(), headings);
      var dataTableWithRows = loadDataTableRows(dataTableWithHeadings, vacantRooms);

      dataGridView.DataSource = dataTableWithRows.DefaultView;
      return dataGridView;
    }
  }

}
