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


                MessageBox.Show("Random Sayý Oluþturuldu!", "Önemli Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                yeniOyun = false;
                return;
            }
            DialogResult = MessageBox.Show("Yeni Bir Sayý Üretmek Ýstiyor musunuz?", "Önemli Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                Random rassal = new Random();
                sayi = rassal.Next(1, 100);

                MessageBox.Show("Yeni bir Random Sayý Oluþturuldu!", "Önemli Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Tebrikler! Tahmininiz Doðru\nOyunu " + label5.Text.ToString() + " adýmda tamamladýnýz! ", "TEBRÝKLER!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                label5.Text = "";
                DialogResult = MessageBox.Show("Yeni Oyuna Baþlamak Ýster misiniz?", "Yeni Oyun", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
                label3.Text = "Daha Büyük";
                return;
            }
            else
            {
                label3.Text = "Daha Küçük";
                return;
            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Eðer sayýsal deðilse, olayý iþleme alma ve TextBox'a yazdýrma
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
                    e.Handled = true; // Tuþa basýldýðýnda Enter'ý iþleme alma
                }

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                // Eðer boþ ise, button2'yi devre dýþý býrak
                button2.Enabled = false;
            }
            else
            {
                // Boþ deðilse, button2'yi etkinleþtir
                button2.Enabled = true;
            }
        }
    }
}