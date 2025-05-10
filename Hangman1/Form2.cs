using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Hangman1
{
    public partial class Form2 : Form
    {
        string secilenKelime = "";
        string gosterilenKelime = "";
        List<char> yanlisHarfler = new List<char>();
        int yanlisSayisi = 0;
        int puan = 100;
        int kalanSure = 30;
        Timer sureTimer = new Timer();
        string secilenIpucu = "";

        public Form2()
        {
            InitializeComponent();
            // Timer ayarları
            sureTimer.Interval = 1000; // 1 saniye
            sureTimer.Tick += SureTimer_Tick;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Ayarlardan süreyi al
            kalanSure = Ayarlar.Sure;

            // Seçilen kategoriye ve zorluğa göre kelime seç
            string kategori = Form1.secilenKategori;
            string zorluk = Ayarlar.Zorluk;

            var ipucu = KelimeVeIpucuSec(kategori, zorluk);
            if (ipucu != null)
            {
                secilenKelime = ipucu.Kelime;
                secilenIpucu = ipucu.IpucuMetni;
            }
            else
            {
                // Eğer kategori bulunamazsa varsayılan kelimeler
                List<string> varsayilanKelimeler = new List<string>() {
                    "telefon", "bilgisayar", "klavye", "ekran", "program",
                    "internet", "veri", "kodlama"
                };
                Random rnd = new Random();
                secilenKelime = varsayilanKelimeler[rnd.Next(varsayilanKelimeler.Count)];
                secilenIpucu = "İpucu yok";
            }

            gosterilenKelime = new string('_', secilenKelime.Length);

            // Arayüz ayarları
            label1.Text = string.Join(" ", gosterilenKelime.ToCharArray());
            label3.Text = secilenKelime.Length.ToString();
            label5.Text = "";
            label7.Text = puan.ToString() + " P";

            // Süre label'ı
            label9.Text = $"Süre: {kalanSure}";
            label9.ForeColor = Color.Red;

            // Kategori ve zorluk bilgisini görüntüle
            label11.Text = $"Kategori: {kategori} - Zorluk: {zorluk}";

            // Görsel türüne göre ilk resmi göster
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                string dosyaAdi = "";
                if (Ayarlar.GorselTuru == "Adam As")
                {
                    dosyaAdi = "man-01.jpg";
                }
                else if (Ayarlar.GorselTuru == "Çiçek Yaprakları Kopar")
                {
                    dosyaAdi = "flower-01.jpg";
                }
                else if (Ayarlar.GorselTuru == "Balon Patlat")
                {
                    dosyaAdi = "balloon-01.jpg";
                }
                else if (Ayarlar.GorselTuru == "Ağaçtan Elma Düşür")
                {
                    dosyaAdi = "apple-01.jpg";
                }
                else
                {
                    dosyaAdi = "man-01.jpg"; // default
                }

                string yol = Path.Combine(Application.StartupPath, "images", dosyaAdi);
                pictureBox1.Image = Image.FromFile(yol);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim yüklenemedi: " + ex.Message);
            }

            sureTimer.Start();
        }

        private Ipucu KelimeVeIpucuSec(string kategori, string zorluk)
        {
            // Kategorileri karşılaştırmadan önce düzenleyelim
            kategori = kategori.Trim(); // Baştaki ve sondaki boşlukları kaldır

            // Kategori adı tam eşleşmezse, benzer olanı bulmaya çalış
            string bulunanKategori = null;
            foreach (var k in IpucuListesi.Kategoriler.Keys)
            {
                if (string.Equals(k, kategori, StringComparison.OrdinalIgnoreCase))
                {
                    bulunanKategori = k;
                    break;
                }
            }

            // Hiçbir kategori eşleşmezse, varsayılan kategoriye geç
            if (bulunanKategori == null)
            {
                MessageBox.Show($"Seçilen kategori ({kategori}) bulunamadı. Varsayılan kategori kullanılacak.", "Kategori Hatası");
                bulunanKategori = "Karma"; // Varsayılan kategori
            }
            var kategoriIpuclari = IpucuListesi.Kategoriler[bulunanKategori];

            // Karma kategorisi için tüm zorluk seviyelerinden rastgele seçim yapılabilir
            if (bulunanKategori == "Karma")
            {
                Random rnd = new Random();
                return kategoriIpuclari[rnd.Next(kategoriIpuclari.Count)];
            }

            // Belirli bir zorluk seviyesine göre filtreleme
            zorluk = zorluk.Trim(); // Baştaki ve sondaki boşlukları kaldır
            var zorlukIpuclari = kategoriIpuclari.Where(i => string.Equals(i.Zorluk, zorluk, StringComparison.OrdinalIgnoreCase)).ToList();

            if (zorlukIpuclari.Count == 0)
            {
                // Buraya gelindiyse, kategori var ama seçilen zorlukta ipucu yok
                // Sessizce farklı bir zorluk seviyesinden seçim yapalım, gereksiz uyarı vermeyelim
                Random rnd = new Random();
                return kategoriIpuclari[rnd.Next(kategoriIpuclari.Count)];
            }

            // Belirli zorluk seviyesinden rastgele seçim yap
            Random random = new Random();
            return zorlukIpuclari[random.Next(zorlukIpuclari.Count)];
        }

        private void SureTimer_Tick(object sender, EventArgs e)
        {
            kalanSure--;
            label9.Text = $"Süre: {kalanSure}";
            // Son 10 saniye kaldığında ekranı titret
            if (kalanSure <= 10 && kalanSure > 0)
            {
                // Formun orjinal konumunu al
                int originalX = this.Location.X;
                int originalY = this.Location.Y;

                // Küçük bir titreşim yap
                this.Location = new Point(originalX + 3, originalY);
                System.Threading.Thread.Sleep(15);
                this.Location = new Point(originalX, originalY);
            }
            if (kalanSure <= 0)
            {
                sureTimer.Stop();
                MessageBox.Show($"Süre Doldu! Kaybettiniz.\nDoğru kelime: {secilenKelime}", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 anaForm = new Form1();
                anaForm.Show();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 1)
            {
                MessageBox.Show("Lütfen bir harf giriniz.");
                return;
            }
            char tahmin = char.ToLower(textBox1.Text[0]);
            textBox1.Clear();
            if (secilenKelime.Contains(tahmin))
            {
                char[] dizi = gosterilenKelime.ToCharArray();
                for (int i = 0; i < secilenKelime.Length; i++)
                {
                    if (secilenKelime[i] == tahmin)
                    {
                        dizi[i] = tahmin;
                    }
                }
                gosterilenKelime = new string(dizi);
                label1.Text = string.Join(" ", gosterilenKelime.ToCharArray());
                if (!gosterilenKelime.Contains('_'))
                {
                    sureTimer.Stop();

                    // Basit bir tebrik mesajı göster
                    string mesaj = $"Tebrikler, Kazandınız!\n\n" +
                                  $"Kelime: {secilenKelime}\n" +
                                  $"Toplam Puan: {puan} puan";

                    MessageBox.Show(mesaj, "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Puan göstergesini güncelle
                    label7.Text = puan.ToString() + " P";

                    // Panel rengini değiştir
                    panel1.BackColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                if (!yanlisHarfler.Contains(tahmin))
                {
                    yanlisHarfler.Add(tahmin);
                    label5.Text = string.Join(", ", yanlisHarfler);
                    yanlisSayisi++;
                    puan -= 10;
                    label7.Text = puan.ToString() + " P";
                    try
                    {
                        string dosyaAdi = "";
                        int resimNo = yanlisSayisi + 1;

                        if (Ayarlar.GorselTuru == "Adam As")
                        {
                            if (resimNo > 10) resimNo = 10;
                            dosyaAdi = $"man-{resimNo:D2}.jpg";
                        }
                        else if (Ayarlar.GorselTuru == "Çiçek Yaprakları Kopar")
                        {
                            if (resimNo > 10) resimNo = 10;
                            dosyaAdi = $"flower-{resimNo:D2}.jpg";
                        }
                        else if (Ayarlar.GorselTuru == "Balon Patlat")
                        {
                            if (resimNo > 10) resimNo = 10;
                            dosyaAdi = $"balloon-{resimNo:D2}.jpg";
                        }
                        else if (Ayarlar.GorselTuru == "Ağaçtan Elma Düşür")
                        {
                            if (resimNo > 10) resimNo = 10;
                            dosyaAdi = $"apple-{resimNo:D2}.jpg";
                        }
                        else
                        {
                            if (resimNo > 10) resimNo = 10;
                            dosyaAdi = $"man-{resimNo:D2}.jpg"; // default
                        }

                        string yol = System.IO.Path.Combine(Application.StartupPath, "images", dosyaAdi);
                        pictureBox1.Image = System.Drawing.Image.FromFile(yol);

                        // Son resimde kaybettiniz mesajı
                        if (resimNo == 10)
                        {
                            sureTimer.Stop();
                            MessageBox.Show($"Kaybettiniz! Doğru kelime: {secilenKelime}", "Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            panel1.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Resim yüklenemedi: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Oyun bitiriliyor. Ana menüye dönmek istiyor musunuz?", "Çıkış", MessageBoxButtons.YesNo);
            if (sonuc == DialogResult.Yes)
            {
                sureTimer.Stop();
                Form1 anaForm = new Form1();
                anaForm.Show();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Kaydedilen ipucunu göster
            MessageBox.Show(secilenIpucu, "İpucu");
        }
    }
}