# 🚀 CafeFlow - Cafe Yönetim Sistemi

## 📋 Proje Hakkında

CafeFlow, modern kafeler için geliştirilmiş kapsamlı bir yönetim sistemidir. Windows Forms tabanlı masaüstü uygulaması ve .NET Core Web API ile cafe işletmelerinin tüm operasyonlarını kolaylaştırır.

### ✨ Özellikler

#### 🖥️ Masaüstü Uygulaması
- **👤 Kullanıcı Yönetimi**: Güvenli giriş ve kayıt sistemi
- **📊 Analitik Dashboard**: Satış grafikleri ve performans metrikleri
- **📋 Sipariş Yönetimi**: Sipariş alma, izleme ve tamamlama
- **🍕 Menü Yönetimi**: Ürün ekleme, düzenleme ve kategori yönetimi
- **📦 Stok Takibi**: Envanter kontrolü ve stok uyarıları
- **📈 Raporlama**: Detaylı satış raporları ve istatistikler
- **🤖 Arduino Entegrasyonu**: Donanım kontrolü ve otomasyon

#### 🌐 Web API
- **⚡ SignalR**: Gerçek zamanlı sipariş bildirimleri
- **🔄 RESTful API**: Sipariş yönetimi endpoint'leri
- **☁️ Bulut Desteği**: Online sipariş entegrasyonu

### 🛠️ Teknoloji Stack

#### Frontend (Masaüstü)
- **.NET Framework 4.8**
- **Windows Forms**
- **LiveCharts** - Grafik görselleştirme
- **FontAwesome.Sharp** - Modern ikonlar

#### Backend
- **.NET Core** - Web API
- **SignalR** - Gerçek zamanlı iletişim
- **MySQL** - Veritabanı
- **Entity Framework** - ORM

#### Diğer Teknolojiler
- **Arduino** - Donanım entegrasyonu
- **Chart.js** - Web grafikleri
- **Swagger** - API dokümantasyonu

## 🚀 Kurulum

### Gereksinimler
- Visual Studio 2019 veya üzeri
- .NET Framework 4.8
- .NET 6.0 SDK
- MySQL Server
- Arduino IDE (opsiyonel)

### 1. Projeyi Klonlayın
```bash
git clone https://github.com/kullaniciadi/CafeFlow.git
cd CafeFlow
```

### 2. Veritabanı Kurulumu
1. MySQL Server'ı kurun ve çalıştırın
2. Yeni bir veritabanı oluşturun: `CafeDB`
3. Gerekli tabloları oluşturun:
   - `Kullanicilar` - Kullanıcı bilgileri
   - `Siparisler` - Sipariş kayıtları
   - `Urunler` - Menü ürünleri
   - `Stok` - Stok bilgileri

### 3. Veritabanı Bağlantısı
`DatabaseConnection.cs` dosyasındaki bağlantı stringini güncelleyin:
```csharp
ConnectionString = "Server=localhost;Database=CafeDB;Uid=root;Pwd=yourpassword;";
```

### 4. API Kurulumu
```bash
cd CafeFlowApi
dotnet restore
dotnet run
```

### 5. Masaüstü Uygulaması
1. Visual Studio'da `CafeFlow.sln` dosyasını açın
2. NuGet paketlerini geri yükleyin
3. Projeyi derleyin ve çalıştırın

## 📱 Kullanım

### İlk Kurulum
1. Uygulamayı başlatın
2. "Kayıt Ol" sekmesinden yeni hesap oluşturun
3. Giriş yaparak ana dashboard'a erişin

### Ana Özellikler

#### 📊 Dashboard
- Günlük/aylık satış grafikleri
- En çok satılan ürünler
- Stok durumu uyarıları
- Gelir analizi

#### 📋 Sipariş İşlemleri
1. "Siparişler" sekmesine gidin
2. Yeni sipariş oluşturun
3. Masa numarası ve müşteri bilgilerini girin
4. Ürünleri sepete ekleyin
5. Siparişi onaylayın

#### 🍕 Menü Yönetimi
1. "Menü" bölümünden ürünleri görüntüleyin
2. Yeni ürün eklemek için "Ürün Ekle" butonunu kullanın
3. Mevcut ürünleri düzenleyin veya silin

#### 📦 Stok Takibi
1. "Stok" sekmesinden mevcut stoku görüntüleyin
2. Stok girişi/çıkışı yapın
3. Kritik stok seviyelerini takip edin

## 🔧 API Kullanımı

### Sipariş Ekleme
```http
POST /api/orders
Content-Type: application/json

{
  "isim": "Ahmet Yılmaz",
  "masaNo": 5,
  "telefon": "0555-123-4567",
  "siparisAciklamasi": "2x Cappuccino\n1x Cheesecake",
  "toplamTutar": 85.50,
  "siparisTarihi": "2024-01-15T14:30:00",
  "durum": "Ödeme Tamamlandı"
}
```

### SignalR Bağlantısı
```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/orderHub")
    .build();

connection.on("ReceiveOrderUpdate", (orderId, isim, masaNo) => {
    console.log(`Yeni sipariş: ${isim} - Masa ${masaNo}`);
});
```

## 🔒 Güvenlik

- Kullanıcı şifreleri şifrelenmiş olarak saklanır
- SQL injection koruması
- Parameterized queries kullanımı
- CORS politikaları yapılandırılmış

## 📈 Performans

- **Gerçek zamanlı güncellemeler**: SignalR ile anlık bildirimler
- **Hızlı veri erişimi**: Optimize edilmiş MySQL sorguları
- **Responsive UI**: Modern ve kullanıcı dostu arayüz

## 🤝 Katkıda Bulunma

1. Bu repository'yi fork edin
2. Yeni bir feature branch oluşturun (`git checkout -b feature/yeni-ozellik`)
3. Değişikliklerinizi commit edin (`git commit -am 'Yeni özellik eklendi'`)
4. Branch'inizi push edin (`git push origin feature/yeni-ozellik`)
5. Pull Request oluşturun

## 📝 License

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakın.


## 📋 Changelog

### v1.0.0 (2024-01-15)
- ✅ Temel cafe yönetimi özellikleri
- ✅ Kullanıcı giriş/kayıt sistemi
- ✅ Sipariş yönetimi
- ✅ Menü ve stok takibi
- ✅ Analitik dashboard
- ✅ SignalR entegrasyonu
- ✅ Arduino kontrolü

## 🛠️ Gelecek Özellikler

- [ ] Mobil uygulama desteği
- [ ] Online ödeme entegrasyonu
- [ ] QR kod menü sistemi
- [ ] Müşteri sadakat programı
- [ ] Çoklu dil desteği
- [ ] Gelişmiş raporlama modülü

## 📸 Ekran Görüntüleri

### Dashboard
![Dashboard](docs/dashboard.png)

### Sipariş Yönetimi
![Orders](docs/orders.png)

### Menü Yönetimi
![Menu](docs/menu.png)

---

⭐ **Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!**
