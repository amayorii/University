namespace Laba5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Square square = new Square(100, 75, Color.Black, 50);
            square.MoveRightOn(200);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ellipse ellipse = new Ellipse(100, 150, Color.RebeccaPurple, 100);
            ellipse.MoveRightOn(200);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
