
# 🧠 HashSozlukGUI_Fix

Bu proje, **Avalonia UI** kullanılarak geliştirilen basit ama işlevsel bir görsel sözlük uygulamasıdır. Anahtar-değer (hash tablosu) mantığı ile çalışır. Kullanıcı, uygulama arayüzü üzerinden veri ekleyebilir, arayabilir ve silebilir.

---

## 🚀 Özellikler

- 📝 Anahtar-değer (key-value) çifti ekleme
- 🔍 Anahtar ile değer arama
- ❌ Anahtar silme (silinen hücreler özel olarak işaretlenir)
- 📊 Hash tablosunun görsel gösterimi
- 📄 Kullanıcı işlemlerini açıklayan log paneli

---

## 🛠 Teknolojiler

- **C#**
- **Avalonia UI**
- **.NET 6 veya üzeri**

---

## 📦 Kurulum ve Çalıştırma

### Gerekli Araçlar
- [.NET SDK 6.0+](https://dotnet.microsoft.com/en-us/download)
- [Avalonia Extension](https://marketplace.visualstudio.com/items?itemName=AvaloniaTeam.AvaloniaforVisualStudio) (VS için önerilir)

### Projeyi Çalıştırma

```bash
git clone https://github.com/kullaniciadi/HashSozlukGUI_Fix.git
cd HashSozlukGUI_Fix
dotnet restore
dotnet run
```

> Not: Visual Studio ya da Rider kullanıyorsan `.axaml` dosyaları otomatik olarak tanınacaktır.

---

## 📁 Proje Yapısı

```
├── App.axaml.cs           → Uygulama başlatma ve yaşam döngüsü
├── Program.cs             → Avalonia uygulama giriş noktası
├── HashTable.cs           → Hash tablo veri yapısı (Add, Search, Delete, Rehash)
├── Views/MainWindow.axaml → Arayüz tanımı (bu dosya sende mevcutsa eklemen gerekir)
```

---

## 📷 Arayüz Özeti

- `TextBox` ile anahtar ve değer girişi yapılır.
- `Add`, `Search`, `Delete` butonları ilgili işlemleri yapar.
- `WrapPanel` içinde hash tablosunun kutucuklarla görsel temsili yapılır.
- `LogBlock` alanında işlem geçmişi görüntülenir.

---

## 📌 Notlar

- Hash çatışmalarında lineer probe kullanılır.
- Silinen hücreler `"__DELETED__"` anahtarı ile işaretlenir.
- Load factor > 0.75 olduğunda otomatik olarak yeniden boyutlandırma yapılır.



