namespace numberGuessingGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Enabled = false;
            button2.Enabled = false;
        }
        private int tahminSayisi;
        private bool yeniOyun = true;
        private int sayi;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;

            textBox1.Focus();
            if (yeniOyun)
            {
                Random rassal = new Random();
                sayi = rassal.Next(1, 100);


                MessageBox.Show("Random Say� Olu�turuldu!", "�nemli Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                yeniOyun = false;
                return;
            }
            DialogResult = MessageBox.Show("Yeni Bir Say� �retmek �stiyor musunuz?", "�nemli Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                Random rassal = new Random();
                sayi = rassal.Next(1, 100);

                MessageBox.Show("Yeni bir Random Say� Olu�turuldu!", "�nemli Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                yeniOyun = false;
                return;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tahminSayisi += 1;
            label5.Text = tahminSayisi.ToString();
            int tahmin = Convert.ToUInt16(textBox1.Text);
            textBox1.Clear();
            if (tahmin == sayi)
            {
                label3.Text = textBox1.Text;
                MessageBox.Show("Tebrikler! Tahmininiz Do�ru\nOyunu " + label5.Text.ToString() + " ad�mda tamamlad�n�z! ", "TEBR�KLER!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                label5.Text = "";
                DialogResult = MessageBox.Show("Yeni Oyuna Ba�lamak �ster misiniz?", "Yeni Oyun", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult == DialogResult.Yes)
                {
                    yeniOyun = true;
                    button1.PerformClick();
                }
                else
                {
                    Application.Exit();
                }
                
            }
            else if (tahmin < sayi)
            {
                label3.Text = "Daha B�y�k";
                return;
            }
            else
            {
                label3.Text = "Daha K���k";
                return;
            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // E�er say�sal de�ilse, olay� i�leme alma ve TextBox'a yazd�rma
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (button2.Enabled)
            {
                if (e.KeyCode == Keys.Enter && !yeniOyun)
                {
                    button2_Click(sender, e);
                    e.Handled = true; // Tu�a bas�ld���nda Enter'� i�leme alma
                }

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                // E�er bo� ise, button2'yi devre d��� b�rak
                button2.Enabled = false;
            }
            else
            {
                // Bo� de�ilse, button2'yi etkinle�tir
                button2.Enabled = true;
            }
        }
    }
}