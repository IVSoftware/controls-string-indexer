using System.Diagnostics;

namespace controls_string_indexer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Set some values so example can compile
            const int mapSize = 3, slotSize = 100;
            bool foundPos = false;
            int[,] currMap = new int[mapSize, mapSize];
            // ========================================

            for (int i = 0; i < mapSize && !foundPos; i++)
            {
                for (int j = 0; j < mapSize && !foundPos; j++)
                {
                    var pcb = new PictureBox
                    {
                        Name = $"pcb{i}{j}",
                        Size = new Size(slotSize, slotSize),
                        Location = new Point(0 + i * slotSize, 0 + j * slotSize),
                        BackColor = Color.LightBlue,
                    };
                    pcb.Left += 50;
                    pcb.Top += 50;
                    // Skip the colors so this example can set them below
                    this.Controls.Add(pcb);
                    pcb.BorderStyle = BorderStyle.FixedSingle;

                    Debug.WriteLine(pcb.Name);
                }
            }
            Controls["pcb00"].BackColor = Color.White;
            Controls["pcb01"].BackColor = Color.Gray;
            Controls["pcb12"].BackColor = Color.Yellow;
        }
    }
}
