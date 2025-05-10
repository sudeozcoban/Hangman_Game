using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman1
{
    public partial class Form1 : Form
    {
        // Kategori bilgisi Form2'ye gönderilecek
        public static string secilenKategori = "Karma";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("images\\cover2.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // ComboBox içeriği eğer tasarımdan eklenmediyse:
            if (comboBox1.Items.Count == 0)
            {
                comboBox1.Items.AddRange(new string[]
                {
                    "Tarih", "Coğrafya", "Matematik", "Genel Kültür", "Karma"
                });
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        // Oyuna Başla butonu
        private void button1_Click(object sender, EventArgs e)
        {
            // Kategori seçili mi kontrol et
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen önce bir kategori seçiniz!", "Kategori Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi sonlandır
            }

            // Seçilen kategoriyi al
            secilenKategori = comboBox1.SelectedItem.ToString();

            // Oyun formunu aç
            Form2 oyunEkrani = new Form2();
            oyunEkrani.Show();
            this.Hide();

        }

        // Ayarlar butonu
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 ayarFormu = new Form3();
            ayarFormu.ShowDialog(); // Modal olarak açılır
        }
    }
}
