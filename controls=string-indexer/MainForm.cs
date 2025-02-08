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
                    var pcb = new PictureBox();
                    pcb.Name = "pcb" + i + "" + j;
                    pcb.Margin = new Padding(0);
                    pcb.Size = new Size(slotSize, slotSize);
                    pcb.Location = new Point(0 + i * slotSize, 0 + j * slotSize);
                    pcb.Left += 50;
                    pcb.Top += 50;
                    // Skip the colors so this example can set them below
                    this.Controls.Add(pcb);
                    pcb.BorderStyle = BorderStyle.FixedSingle;

                    Debug.WriteLine(pcb.Name);
                }
            }
            Controls["pcb00"].BackColor = Color.Red;
            Controls["pcb01"].BackColor = Color.LightBlue;
            Controls["pcb02"].BackColor = Color.Green;
            Controls["pcb10"].BackColor = Color.Yellow;
            Controls["pcb11"].BackColor = Color.Purple;
            Controls["pcb12"].BackColor = Color.Orange;
            Controls["pcb20"].BackColor = Color.Pink;
            Controls["pcb21"].BackColor = Color.Brown;
            Controls["pcb22"].BackColor = Color.Gray;
        }
    }
}
