You've done the right thing by naming them before adding them to the `Controls` collection. **You don't need to do anything else**, thanks to the [string indexer](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/using-indexers#example-2) of the `Controls` collection, just refer to a control (for example) as `Controls["pcb01"]` as shown in the working minimal example below.

~~~
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
~~~
[![set colors by string reference][1]][1]
___

That said, I agree with Jimi's comment that you might greatly benefit from a `TableLayoutPanel`.

**TableLayoutPanel Minimal Example**

~~~
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
    }
}
~~~
___
In this case, there are at least two answers to the question:

>Is there a way to reference a picturebox just created and added during runtime?

~~~
currMap.Controls["pcb20"].BackColor = Color.Red;
currMap.GetControlFromPosition(2,1).BackColor = Color.Green;
~~~

___

I would take it a step further and recommend that you inherit `PictureBox` to make something like `SmartSquare`, a custom `PictureBox` that might (for example) know what color it's supposed to be based on the `ValueForDemo` property.


**`SmartSquare` Minimal Example**

~~~
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
~~~
___
**`SmartSquare` Demo**

Using your examples of `{5, 0, 1}`:

[![smart square][2]][2]


  [1]: https://i.sstatic.net/nSUulxsP.png
  [2]: https://i.sstatic.net/AJAgL2C8.png