namespace TransposeString
{
    public partial class Form1 : Form
    {

        String[] lines;

        public Form1()
        {
            InitializeComponent();
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
            try
            {

                if (textBox1.Text.Length == 0)
                {
                    textBox1.Text = Clipboard.GetText();
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);    
                return;
            }

            string result = startchars;
                lines = textBox1.Text.Split(Environment.NewLine);
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
                textBox2.Text = result;

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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}