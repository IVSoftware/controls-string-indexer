using System.Diagnostics;

namespace controls_string_indexer
{
    public partial class MainForm : Form
    {
        TableLayoutPanel currMap;
        public MainForm()
        {
            InitializeComponent();
            const int DIM = 3;
            Padding = new Padding(25);
            currMap = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = DIM,
                ColumnCount = DIM,
                BackColor = Color.LightBlue,
                Padding = new Padding(2),
            }; 
            Controls.Add(currMap);
            int autoIncrement = 0;
            for (int col = 0; col < DIM; col++)
            {
                currMap.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1));
                for (int row = 0; row < DIM; row++)
                {
                    currMap.RowStyles.Add(new RowStyle(SizeType.Percent, 1));
                    var pcb = new SmartSquare
                    {
                        Name = $"pcb{col}{row}",
                        ValueForDemo = autoIncrement++, 
                    };
                    currMap.Controls.Add(pcb, col, row);
                }
            }
            currMap.Controls["pcb20"].BackColor = Color.Red;
            currMap.GetControlFromPosition(2,1).BackColor = Color.Green;
        }
    }
    class SmartSquare : PictureBox
    {
        public SmartSquare() 
        { 
            Margin = new Padding(2);
            Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.FixedSingle;
        }

        public int ValueForDemo
        {
            get => _valueForDemo;
            set
            {
                if (!Equals(_valueForDemo, value))
                {
                    _valueForDemo = value;
                    switch (_valueForDemo)
                    {
                        case 0:
                            BackColor = Color.White;
                            break;
                        case 1:
                            BackColor = Color.Gray;
                            break;
                        case 5:
                            BackColor = Color.Yellow;
                            break;
                        default:
                            BackColor = Color.Transparent;
                            break;
                    }
                }
            }
        }
        int _valueForDemo = int.MinValue;
    }
}
