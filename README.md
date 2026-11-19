**C# (.NET Framework 4.8)**, **Windows Forms (Guna.UI2)** ve **Microsoft SQL Server (T-SQL)** kullanılarak geliştirilmiş; müşteri dijital menü deneyimi ile yönetici ürün/kullanıcı operasyonlarını modern koyu tema arayüzünde birleştiren masaüstü kafe otomasyon sistemidir.

---

## 🎨 Tasarım Yaklaşımı ve Öne Çıkan Özellikler

* **Modern Koyu Tema & Kahve Konsepti:** Koyu espresso tonları, karamel-altın vurgular, yarı saydam kartlar ve özel ikon setleriyle standart Windows Forms görünümünün ötesinde bütünlüklü bir kullanıcı deneyimi sunar.
* **Kapsamlı Kimlik Doğrulama Akışı:**
  * Rol bazlı giriş sistemi (Müşteri / Sistem Yöneticisi)
  * Karmaşıklık kuralları doğrulamalı yeni hesap oluşturma (`HesapOlustur`)
  * E-posta üzerinden 4 haneli onay kodu ile şifre sıfırlama (`SifremiUnuttum` & `KodDogrulamaFormu`)
* **Müşteri Dijital Vitrin Deneyimi:**
  * Öne çıkan kahvelerin görsel kartlarla sergilendiği ana sayfa (`Anasayfa`) ve kahve menüsü (`KahveMenü`)
  * Marka hikayesi ve kalite metriklerinin yer aldığı kurumsal tanıtım ekranı (`Hakkimizda`)
  * Telefon, Instagram, E-posta bilgileri ve 500 karakter sınırlı doğrudan mesaj formu (`Iletisim`)
* **Gelişmiş Yönetici Kontrol Paneli (`YöneticiAnasayfa`):**
  * Toplam kullanıcı, kayıtlı kahve sayısı, günlük sipariş ve gelir özet kartları (KPI)
  * **Kahve Yönetimi (`KahveYönetimi`):** Bilgisayardan ürün görseli yükleme, kategori atama, fiyat/stok güncelleme, **ComboBox ile kategoriye göre filtreleme** ve **TextBox ile anlık kahve arama**
  * **Kullanıcı Yönetimi (`KullaniciYönetim`):** Maskelenmiş şifre güvenliği, kayıt tarihi takibi, kullanıcı ekleme/güncelleme/silme, **anlık kullanıcı arama** ve **sıralama filtreleri**

---

## 🛠️ Kullanılan Teknolojiler

| Katman | Teknoloji / Araç |
| :--- | :--- |
| **Programlama Dili** | C# (.NET Framework 4.8) |
| **Arayüz (UI/UX)** | Windows Forms, Guna.UI2 |
| **Veritabanı** | Microsoft SQL Server (MS SQL / T-SQL) |
| **Veri Erişimi** | ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`) |
| **Geliştirme Ortamı** | Visual Studio |

---

🖼️ Uygulama Ekran Görüntüleri

1.Kimlik Doğrulama ve Hesap İşlemleri
### Giriş Ekranı & Kayıt Olma

<img width="1127" height="955" alt="Ekran görüntüsü 2026-11-19 194920" src="https://github.com/user-attachments/assets/c64db68f-a92a-4fa7-8b5c-2853aee3f6c5" />
<img width="1137" height="934" alt="Ekran görüntüsü 2026-11-19 194929" src="https://github.com/user-attachments/assets/3b66d62c-e7c5-4d7d-a5c6-2899e6ed53a0" />

### Şifremi Unuttum & 4 Haneli Kod Doğrulama

<img width="1126" height="933" alt="Ekran görüntüsü 2026-11-19 194943" src="https://github.com/user-attachments/assets/6079f638-5924-4e94-aad7-9b357cead53e" />
<img width="798" height="692" alt="Ekran görüntüsü 2026-11-19 195003" src="https://github.com/user-attachments/assets/2451408f-c20c-4b36-921a-fcfe94a02327" />

<br>
<br>

2.Müşteri Arayüzü (Vitrin, Menü, Hakkımızda & İletişim)
### Müşteri Ana Sayfası & Öne Çıkan Kahveler
<img width="1919" height="1199" alt="Ekran görüntüsü 2026-11-19 195032" src="https://github.com/user-attachments/assets/e700e80f-a558-4e3b-b347-f7e3163e17ad" />
<img width="1915" height="1172" alt="Ekran görüntüsü 2026-11-19 195043" src="https://github.com/user-attachments/assets/257a0640-81df-4070-bd1d-bdd3e87cd196" />


#### Dijital Kahve Menüsü

**Fiyata Göre Sıralama:**
<img width="1920" height="1200" alt="Ekran görüntüsü 2026-11-19 211733" src="https://github.com/user-attachments/assets/ddb8766f-332e-4818-ac06-9e9068caf0ef" />

**Kategori Filtreleme:**
<img width="1920" height="1200" alt="Ekran görüntüsü 2026-11-19 195848" src="https://github.com/user-attachments/assets/02ff438e-27e5-4f7a-8118-0b19816c661a" />

**Anlık Kahve Arama:**
<img width="1920" height="1200" alt="Ekran görüntüsü 2026-11-19 195943" src="https://github.com/user-attachments/assets/6c11c499-4cd4-46b7-8ca8-bda16a2b282d" />

#### Hakkımızda & İletişim Ekranları

<img width="1919" height="1199" alt="Ekran görüntüsü 2026-11-19 195050" src="https://github.com/user-attachments/assets/7e38808a-11db-4d99-8e4a-411400a04d16" />
<img width="1919" height="1199" alt="Ekran görüntüsü 2026-11-19 195057" src="https://github.com/user-attachments/assets/5ecd4573-df15-46b0-af27-b03dfd8e0dce" />

<br>
<br> 

3.Yönetici Paneli, Dinamik Arama ve Filtreleme İşlemleri
### Yönetici Dashboard (Genel Bakış)
<img width="1919" height="1199" alt="Ekran görüntüsü 2026-11-19 195122" src="https://github.com/user-attachments/assets/f5865acc-2853-44cd-8898-54c96288d1e7" />

#### Kahve Yönetimi (CRUD, Görsel Ekleme, Kategori Filtreleme & Canlı Arama)
> Yönetici; yeni kahve ekleyebilir, mevcut ürünlerin fiyat/stok bilgilerini güncelleyebilir, **kategori ComboBox'ı** ile ürünleri sınıflandırabilir ve **arama kutusu** üzerinden anlık filtreleme yapabilir.

<img width="1914" height="1190" alt="Ekran görüntüsü 2026-11-19 195135" src="https://github.com/user-attachments/assets/ab556a2b-6039-4e2b-9439-7b23363e3762" />
<img width="1904" height="1199" alt="Ekran görüntüsü 2026-11-19 195620" src="https://github.com/user-attachments/assets/6a508d8a-3fe6-466b-b27a-4da1df4b3700" />

#### Kullanıcı Yönetimi (CRUD, Sıralama & Canlı Arama)
> Yönetici; kayıtlı kullanıcıları maskelenmiş şifreleriyle görüntüleyebilir, yeni kullanıcı tanımlayabilir, **arama kutusu** ve **sıralama seçenekleri** ile kayıtlar arasında hızlıca filtreleme yapabilir.

<img width="1920" height="1200" alt="Ekran görüntüsü 2026-11-19 195704" src="https://github.com/user-attachments/assets/9eefc440-cf57-4d3d-a653-dadf9946dcc9" />
<img width="1920" height="1200" alt="Ekran görüntüsü 2026-11-19 195715" src="https://github.com/user-attachments/assets/81799b3a-f8cb-45d2-9ff2-f89ebb56bcbb" />


## 🗺️ Sistemdeki Eksiklikler ve Gelecek Güncellemeler (Yol Haritası)

Projenin mevcut sürümünde temel arayüzler, veritabanı bağlantıları ve yönetici CRUD/filtreleme işlemleri aktif olarak çalışmaktadır. Sistemin uçtan uca ticari bir otomasyona dönüşmesi için planlanan 6 ana geliştirme modülü aşağıda detaylandırılmıştır:

### 1. Rol Bazlı Oturum ve Yetki Yönetimi
* [ ] Ayrı bir yönetici giriş ekranı oluşturmak yerine mevcut **`Form1`** üzerinden tek giriş noktası kullanılacaktır.
* [ ] Veritabanındaki `Kullanicilar` tablosuna eklenecek rol sütunu (`Admin` / `Kullanıcı`) doğrultusunda kullanıcılar otomatik olarak **`YöneticiAnasayfa`** veya müşteri **`Anasayfa`** ekranına yönlendirilecektir.

### 2. SMTP E-Posta Entegrasyonu ve Şifre Yenileme Akışı
* [ ] **`SifremiUnuttum`** ekranında üretilen doğrulama kodunun `MessageBox` ile ekranda gösterilmesi yerine, **SMTP servisi** aracılığıyla doğrudan kullanıcının kayıtlı e-posta adresine gönderilmesi sağlanacaktır.
* [ ] **`KodDogrulamaFormu`** onaylandıktan sonra açılacak yeni **`SifreYenilemeFormu`** üzerinden kullanıcının yeni şifresini belirleyip veritabanında güncellemesi tamamlanacaktır.

### 3. Müşteri Vitrin ve Menü Ayrımı
* [ ] Müşteri **`Anasayfa`** ekranında tüm ürün listesi yerine yalnızca yönetici tarafından belirlenen **"Öne Çıkan Kahveler"** sergilenecektir.
* [ ] Sistemdeki tüm kahvelerin listelenmesi, aranması ve kategoriye göre filtrelenmesi yalnızca **`KahveMenü`** formu üzerinden yürütülecektir.

### 4. Sepet ve Sipariş (Alışveriş) Modülü
* [ ] **Sepet Formu:** Kullanıcının menüden seçtiği kahveleri, adet bilgilerini ve toplam tutarı görüntüleyip güncelleyebileceği sepet ekranı eklenecektir.
* [ ] **Alışveriş Formu:** Sepet ekranıyla entegre çalışarak kullanıcının siparişini onaylayıp ödeme/satın alma işlemini veritabanına kaydedecek sipariş formu oluşturulacaktır.

### 5. İletişim, Talep Yönetimi ve Sosyal Medya Yönlendirmeleri
* [ ] Kullanıcıların **`Iletisim`** formu üzerinden talep/şikayet oluşturabilmesi, kendi geçmiş taleplerini tarih ve içerikleriyle listeleyip düzenleyebilmesi veya silebilmesi sağlanacaktır.
* [ ] Gelen kullanıcı taleplerinin yönetici tarafından görüntülenip yanıtlanabilmesi için **`TalepYönetimi`** adlı yeni bir yönetici formu eklenecektir.
* [ ] Talep mesajı alanına karakter sınırı eklenerek kullanıcı yazı yazdıkça **kalan karakter limitinin anlık olarak ekranda gösterilmesi** sağlanacaktır.
* [ ] İletişim ekranının sol panelindeki **WhatsApp, E-posta ve Instagram** ikonlarına tıklandığında kafenin ilgili iletişim ve sosyal medya kanallarına doğrudan yönlendirme yapılacaktır.

### 6. Canlı Yönetici Dashboard İstatistikleri
* [ ] **`YöneticiAnasayfa`** ekranında şu an sabit metin (`Label`) olarak yer alan **Toplam Kullanıcı Sayısı, Kayıtlı Kahve Sayısı, Toplam Sipariş ve Günlük Gelir** kartları veritabanından canlı SQL sorgularıyla beslenecek şekilde dinamik hale getirilecektir.
