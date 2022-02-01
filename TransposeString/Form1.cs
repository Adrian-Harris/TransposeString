namespace TransposeString
{
    public partial class Form1 : Form
    {

        private void Form_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        public Form1()
        {
            InitializeComponent();
            this.notifyIcon1.ContextMenuStrip.Items.Add(button1.Text, null, button1_Click);
            this.notifyIcon1.ContextMenuStrip.Items.Add(button6.Text, null, button6_Click);
            this.notifyIcon1.ContextMenuStrip.Items.Add(button7.Text, null, button7_Click);
            this.notifyIcon1.ContextMenuStrip.Items.Add(button5.Text, null, button5_Click);
            this.notifyIcon1.ContextMenuStrip.Items.Add(button2.Text, null, button2_Click);
            this.notifyIcon1.ContextMenuStrip.Items.Add(button4.Text, null, button4_Click);
            this.notifyIcon1.ContextMenuStrip.Items.Add(button3.Text, null, button3_Click);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            splitLines(@"", @",", @"");
        }


        private void button5_Click(object sender, EventArgs e)
        {
            splitLines(@"(", @",", @")");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            splitLines(@"""", @""", """, @"""");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            splitLines(@"(""", @""", """, @""")");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            splitLines(@"", @"|", @"");
        }


        void splitLines(string startchars, string midchars, string endchars)
        {
            string[] lines;
            string InString;

            try
            {
                InString = Clipboard.GetText();
                
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);    
                return;
            }

            string result = startchars;
                lines = InString.Split(Environment.NewLine);
                int totalLines = lines.Count();
                int Currentline = 0;

                foreach (string line in lines)
                {
                    if (Currentline == totalLines - 1)
                    {
                        midchars = "";
                    }

                if (line.Trim().Length > 0)
                {
                    result += line + midchars;
                }
                    Currentline++;
                }

                result += endchars;

            try
            {
                Clipboard.SetText(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            splitLines(@"'", @"', '", @"'");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            splitLines(@"('", @"', '", @"')");
        }
    }
}