using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman1
{
    public class Ipucu
    {
        public string Kelime { get; set; }
        public string IpucuMetni { get; set; }
        public string Zorluk { get; set; } // "Kolay", "Orta", "Zor"

        // Bu yapıcı, manuel nesne oluşturmak için kullanılır.
        public Ipucu(string kelime, string ipucuMetni, string zorluk)
        {
            Kelime = kelime;
            IpucuMetni = ipucuMetni;
            Zorluk = zorluk;
        }

        // Parametresiz constructor da lazım çünkü sen { } ile nesne oluşturuyorsun
        public Ipucu() { }
    }

    public static class IpucuListesi
    {
        public static Dictionary<string, List<Ipucu>> Kategoriler = new Dictionary<string, List<Ipucu>>()
        {
            { "Matematik", new List<Ipucu>
                {
                    // Kolay - 7 adet
                    new Ipucu { Kelime = "toplama", IpucuMetni = "İki sayıyı birleştirme işlemi", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "çıkarma", IpucuMetni = "Eksiltme işlemi", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "çarpma", IpucuMetni = "Tekrarlı toplama işlemi", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "bölme", IpucuMetni = "Bir sayıyı eşit parçalara ayırma", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "kare", IpucuMetni = "Dört kenarı eşit şekil", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "üçgen", IpucuMetni = "Üç açısı ve üç kenarı olan şekil", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "daire", IpucuMetni = "Merkezi ve yarıçapı olan yuvarlak şekil", Zorluk = "Kolay" },
                    
                    // Orta - 7 adet
                    new Ipucu { Kelime = "çember", IpucuMetni = "Daire kenarı", Zorluk = "Orta" },
                    new Ipucu { Kelime = "paralel", IpucuMetni = "Hiç kesişmeyen doğrular", Zorluk = "Orta" },
                    new Ipucu { Kelime = "köşegen", IpucuMetni = "Çokgenin karşılıklı köşelerini birleştiren doğru", Zorluk = "Orta" },
                    new Ipucu { Kelime = "açı", IpucuMetni = "İki doğrunun kesişiminde oluşan ölçü", Zorluk = "Orta" },
                    new Ipucu { Kelime = "türev", IpucuMetni = "Değişim oranını hesaplama", Zorluk = "Orta" },
                    new Ipucu { Kelime = "katsayı", IpucuMetni = "Bir terimin önündeki çarpan", Zorluk = "Orta" },
                    new Ipucu { Kelime = "polinom", IpucuMetni = "Değişken ve katsayılardan oluşan ifade", Zorluk = "Orta" },
                    
                    // Zor - 7 adet
                    new Ipucu { Kelime = "integral", IpucuMetni = "Alan hesaplamada kullanılır", Zorluk = "Zor" },
                    new Ipucu { Kelime = "limit", IpucuMetni = "Bir değere yaklaşma", Zorluk = "Zor" },
                    new Ipucu { Kelime = "matris", IpucuMetni = "Sayıların dikdörtgen düzeni", Zorluk = "Zor" },
                    new Ipucu { Kelime = "logaritma", IpucuMetni = "Üs alma işleminin tersi", Zorluk = "Zor" },
                    new Ipucu { Kelime = "türevlenebilir", IpucuMetni = "Fonksiyonun düzgün değiştiği yerler", Zorluk = "Zor" },
                    new Ipucu { Kelime = "determinant", IpucuMetni = "Kare matrislerle ilişkili sayı", Zorluk = "Zor" },
                    new Ipucu { Kelime = "tanjant", IpucuMetni = "Bir açının karşı ve komşu kenarlarının oranı", Zorluk = "Zor" }
                }
            },

            { "Tarih", new List<Ipucu>
                {
                    // Kolay - 7 adet
                    new Ipucu { Kelime = "osmanlı", IpucuMetni = "600 yıl hüküm süren imparatorluk", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "cumhuriyet", IpucuMetni = "1923'te ilan edildi", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "bizans", IpucuMetni = "İstanbul'un eski adı Konstantinopolis'in devleti", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "selçuklu", IpucuMetni = "Anadolu'daki ilk Türk devleti", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "hititler", IpucuMetni = "Anadolu'da kurulmuş eski bir uygarlık", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "kanuni", IpucuMetni = "Osmanlı'nın en uzun hüküm süren padişahı", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "kurtuluş", IpucuMetni = "1919-1922 arası yapılan savaş", Zorluk = "Kolay" },
                    
                    // Orta - 7 adet
                    new Ipucu { Kelime = "malazgirt", IpucuMetni = "1071'de kazanılan büyük savaş", Zorluk = "Orta" },
                    new Ipucu { Kelime = "fatih", IpucuMetni = "İstanbul'u fetheden padişah", Zorluk = "Orta" },
                    new Ipucu { Kelime = "tanzimat", IpucuMetni = "Osmanlı'daki modernleşme hareketi", Zorluk = "Orta" },
                    new Ipucu { Kelime = "çanakkale", IpucuMetni = "Birinci Dünya Savaşı'ndaki zafer", Zorluk = "Orta" },
                    new Ipucu { Kelime = "ıslahat", IpucuMetni = "1856'da ilan edilen ferman", Zorluk = "Orta" },
                    new Ipucu { Kelime = "inkılap", IpucuMetni = "Cumhuriyet dönemindeki köklü değişiklikler", Zorluk = "Orta" },
                    new Ipucu { Kelime = "sakarya", IpucuMetni = "Kurtuluş savaşının dönüm noktası olan meydan muharebesi", Zorluk = "Orta" },
                    
                    // Zor - 7 adet
                    new Ipucu { Kelime = "kapitülasyon", IpucuMetni = "Osmanlı'nın verdiği ekonomik ayrıcalık", Zorluk = "Zor" },
                    new Ipucu { Kelime = "sevr", IpucuMetni = "İmzalanıp uygulanmayan antlaşma", Zorluk = "Zor" },
                    new Ipucu { Kelime = "duraklama", IpucuMetni = "Osmanlı'nın gerileme öncesi dönemi", Zorluk = "Zor" },
                    new Ipucu { Kelime = "meşrutiyet", IpucuMetni = "Anayasal düzen", Zorluk = "Zor" },
                    new Ipucu { Kelime = "trablusgarp", IpucuMetni = "Osmanlı'nın İtalya ile yaptığı savaş", Zorluk = "Zor" },
                    new Ipucu { Kelime = "mütareke", IpucuMetni = "Savaşın geçici olarak durdurulması", Zorluk = "Zor" },
                    new Ipucu { Kelime = "teşkilat", IpucuMetni = "Kurtuluş savaşında kurulan gizli direniş örgütü", Zorluk = "Zor" }
                }
            },

            { "Coğrafya", new List<Ipucu>
                {
                    // Kolay - 7 adet
                    new Ipucu { Kelime = "kıta", IpucuMetni = "Büyük kara parçası", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "akarsu", IpucuMetni = "Sürekli akan su kaynağı", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "göl", IpucuMetni = "Karaların içinde yer alan su kütlesi", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "plato", IpucuMetni = "Yüksek ve düz arazi", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "ova", IpucuMetni = "Düz ve alçak arazi", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "deniz", IpucuMetni = "Kıtaları çevreleyen tuzlu su kütlesi", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "iklim", IpucuMetni = "Bir bölgedeki uzun süreli hava durumu", Zorluk = "Kolay" },
                    
                    // Orta - 7 adet
                    new Ipucu { Kelime = "delta", IpucuMetni = "Nehirlerin denize ulaştığı yerde oluşan şekil", Zorluk = "Orta" },
                    new Ipucu { Kelime = "fay", IpucuMetni = "Depremle ilgili kırık hat", Zorluk = "Orta" },
                    new Ipucu { Kelime = "kanyon", IpucuMetni = "Akarsu aşındırmasıyla oluşan derin vadi", Zorluk = "Orta" },
                    new Ipucu { Kelime = "volkan", IpucuMetni = "Magmanın yeryüzüne çıktığı yer", Zorluk = "Orta" },
                    new Ipucu { Kelime = "buzul", IpucuMetni = "Yüksek dağların zirvelerindeki donmuş su kütlesi", Zorluk = "Orta" },
                    new Ipucu { Kelime = "meridyen", IpucuMetni = "Kuzey ve güney kutuplarını birleştiren hayali çizgi", Zorluk = "Orta" },
                    new Ipucu { Kelime = "paralel", IpucuMetni = "Ekvatore paralel uzanan enlem çizgisi", Zorluk = "Orta" },
                    
                    // Zor - 7 adet
                    new Ipucu { Kelime = "izoterm", IpucuMetni = "Aynı sıcaklık değerlerini gösteren eğri", Zorluk = "Zor" },
                    new Ipucu { Kelime = "bazalt", IpucuMetni = "Volkanik kayaç türü", Zorluk = "Zor" },
                    new Ipucu { Kelime = "orojenez", IpucuMetni = "Dağ oluşum süreci", Zorluk = "Zor" },
                    new Ipucu { Kelime = "moren", IpucuMetni = "Buzulların taşıdığı malzeme yığını", Zorluk = "Zor" },
                    new Ipucu { Kelime = "antisiklon", IpucuMetni = "Yüksek basınç alanı", Zorluk = "Zor" },
                    new Ipucu { Kelime = "akifer", IpucuMetni = "Yeraltı suyu taşıyan geçirgen katman", Zorluk = "Zor" },
                    new Ipucu { Kelime = "alüvyon", IpucuMetni = "Akarsuların taşıyıp biriktirdiği malzeme", Zorluk = "Zor" }
                }
            },

            { "Genel Kültür", new List<Ipucu>
                {
                    // Kolay - 7 adet
                    new Ipucu { Kelime = "türkiye", IpucuMetni = "Akdeniz'e kıyısı olan ülke", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "ankara", IpucuMetni = "Türkiye'nin başkenti", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "karadeniz", IpucuMetni = "Türkiye'nin kuzeyindeki deniz", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "piramit", IpucuMetni = "Mısır'daki büyük yapı", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "evren", IpucuMetni = "Galaksilerin bulunduğu uzayın tamamı", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "futbol", IpucuMetni = "Dünyada en popüler takım sporu", Zorluk = "Kolay" },
                    new Ipucu { Kelime = "mozart", IpucuMetni = "Ünlü klasik müzik bestecisi", Zorluk = "Kolay" },
                    
                    // Orta - 7 adet
                    new Ipucu { Kelime = "atatürk", IpucuMetni = "Cumhuriyetin kurucusu", Zorluk = "Orta" },
                    new Ipucu { Kelime = "mezopotamya", IpucuMetni = "Uygarlığın beşiği sayılan bölge", Zorluk = "Orta" },
                    new Ipucu { Kelime = "everest", IpucuMetni = "Dünyanın en yüksek dağı", Zorluk = "Orta" },
                    new Ipucu { Kelime = "amazon", IpucuMetni = "Dünyanın en büyük yağmur ormanları", Zorluk = "Orta" },
                    new Ipucu { Kelime = "venedik", IpucuMetni = "Su kanallarıyla ünlü İtalyan şehri", Zorluk = "Orta" },
                    new Ipucu { Kelime = "rönesans", IpucuMetni = "Avrupa'da sanat ve bilimin yeniden doğuşu", Zorluk = "Orta" },
                    new Ipucu { Kelime = "einstein", IpucuMetni = "Görelilik teorisini geliştiren bilim adamı", Zorluk = "Orta" },
                    
                    // Zor - 7 adet
                    new Ipucu { Kelime = "nobel", IpucuMetni = "Her yıl verilen prestijli ödül", Zorluk = "Zor" },
                    new Ipucu { Kelime = "louvre", IpucuMetni = "Paris'teki ünlü sanat müzesi", Zorluk = "Zor" },
                    new Ipucu { Kelime = "beethoven", IpucuMetni = "9. senfoniyi besteleyen Alman müzisyen", Zorluk = "Zor" },
                    new Ipucu { Kelime = "himalaya", IpucuMetni = "Dünyanın en yüksek dağ sırası", Zorluk = "Zor" },
                    new Ipucu { Kelime = "shakespeare", IpucuMetni = "Romeo ve Juliet'in yazarı", Zorluk = "Zor" },
                    new Ipucu { Kelime = "arkeoloji", IpucuMetni = "Eski uygarlıkları kazılarla inceleyen bilim", Zorluk = "Zor" },
                    new Ipucu { Kelime = "antropoloji", IpucuMetni = "İnsan kültürünü ve toplumunu inceleyen bilim dalı", Zorluk = "Zor" }
                }
            },

            { "Karma", new List<Ipucu>() } // Karma kategorisi boş bırakıldı, aşağıda doldurulacak
        };

        // Karma kategorisini diğer kategorilerden rastgele seçerek dolduralım
        static IpucuListesi()
        {
            // Karma kategorisi için diğer kategorilerden ipuçlarını kopyalayalım
            var karma = Kategoriler["Karma"];
            var random = new Random();

            // Her zorluk seviyesi için
            foreach (var zorluk in new[] { "Kolay", "Orta", "Zor" })
            {
                // Diğer kategorilerden toplam 7 ipucu alalım
                var tümİpuçları = Kategoriler
                    .Where(k => k.Key != "Karma")
                    .SelectMany(k => k.Value.Where(i => i.Zorluk == zorluk))
                    .ToList();

                // Rasgele 7 ipucu seçelim
                for (int i = 0; i < 7; i++)
                {
                    if (tümİpuçları.Count > 0)
                    {
                        int index = random.Next(tümİpuçları.Count);
                        karma.Add(tümİpuçları[index]);
                        tümİpuçları.RemoveAt(index);
                    }
                }
            }
        }
    }
}