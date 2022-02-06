namespace WinFormsLabs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseCon.InsertUser(lbl_Id.Text, lbl_name.Text);
            richTextBox1.Text = DatabaseCon.getAllFields();
        }

    }
}