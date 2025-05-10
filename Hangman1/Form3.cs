using System;
using System.Linq;
using System.Windows.Forms;

namespace Hangman1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // Süre ayarı
            numericUpDown1.Minimum = 10;
            numericUpDown1.Maximum = 300;
            numericUpDown1.Value = Ayarlar.Sure;

            // Zorluk ComboBox
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "Kolay", "Orta", "Zor" });
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedItem = Ayarlar.Zorluk;

            // Görsel Türü ComboBox
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new string[] { "Adam As", "Çiçek Yaprakları Kopar", "Ağaçtan Elma Düşür" });
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedItem = Ayarlar.GorselTuru;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Mevcut bir Form1 örneği bulmaya çalış
            Form1 anaForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            if (anaForm != null)
            {
                // Eğer varsa, onu öne getir
                anaForm.Show();
                anaForm.BringToFront();
            }
            else
            {
                // Yoksa, yeni bir Form1 oluştur
                anaForm = new Form1();
                anaForm.Show();
            }

            // Bu formu kapat
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ayarları kaydet
            Ayarlar.Sure = (int)numericUpDown1.Value;
            Ayarlar.Zorluk = comboBox1.SelectedItem?.ToString() ?? "Kolay";
            Ayarlar.GorselTuru = comboBox2.SelectedItem?.ToString() ?? "Adam As";

            MessageBox.Show("Ayarlar kaydedildi.");
        }
    }
}