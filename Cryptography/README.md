# Adesso.Dapr.Crypt
 
Bu proje, .NET 8 ile geliştirilmiş ve Dapr.io ile entegre edilmiş bir Web API uygulamasıdır. Proje, güvenli kriptografi işlemleri için Dapr bileşenlerini kullanır ve Docker container'ları içinde çalıştırılmak üzere tasarlanmıştır.
 
## Özellikler
 
- **.NET 8**: Güçlü ve modern bir web uygulama çerçevesi.
- **Dapr**: Mikroservisler için taşınabilir, olay odaklı bir runtime.
- **AES Şifreleme**: Güvenli veri şifreleme ve şifre çözme işlemleri.
- **Azure Key Vault**: Sırların güvenli bir şekilde saklanması.
 
## Kurulum
 
Projeyi yerel olarak çalıştırmak için aşağıdaki adımları izleyin:
 
### Önkoşullar
 
- Docker ve Docker Compose yüklü olmalıdır.
- .NET 8 SDK yüklü olmalıdır (opsiyonel, Docker kullanılıyorsa gerekli değildir).
 
### Yapılandırma
 
1. Projeyi GitHub'dan klonlayın veya indirin.
2. `src/Adesso.Dapr.Crypt` dizinine gidin.
3. Dapr için Azure Key Vault sırlar yönetimi bileşenini içeren `components` dizinindeki `azurekeyvault.yaml` dosyasını kontrol edin.
 
### Docker Compose ile Çalıştırma
 
1. Ana dizine gidin.
2. Aşağıdaki komutu çalıştırarak tüm servisleri başlatın:
 
   ```bash
   docker-compose up --build
   ```
 
Bu komut, Web API ve Dapr servislerini Docker container'larında başlatır. Web API'ye `http://localhost:5000/` adresinden erişebilirsiniz.
 
### API Endpoints
 
- **POST api/sample/encrypt**: Metni şifreler.
- **POST api/sample/decrypt**: Şifreli metni çözer.
- **GET /info**: Uygulama bilgisini gösterir.

## Docker Compose Yapılandırma Detayları
 
### 1. Dapr'ın Yapılandırılması
 
Docker Compose dosyasında, Dapr'ın CLI komutları kullanılarak başlatılması ve uygulamanın içinde çalıştırılması için yapılandırma yapılmıştır. Bu sayede Dapr, uygulamanın ağ modu ile uyumlu bir şekilde çalışır ve uygulamanın Dapr tarafından sağlanan özelliklerden doğrudan yararlanmasını sağlar.
 
### 2. Dapr Bileşenleri Yapılandırması
 
`components` dizini, Dapr bileşenlerinin yapılandırma dosyalarını içerir. Bu yapılandırmalar, Dapr'ın Azure Key Vault gibi hizmetlerle nasıl etkileşime gireceğini tanımlar. Docker Compose dosyasında, bu bileşenlerin uygulama konteyneri içerisinde kullanılabilir olması için ilgili volume montajları yapılmıştır.
 
## Geliştirme ve Katkıda Bulunma
 
Projeyi yerel geliştirme ortamınızda çalıştırmak ve değişiklikler yapmak için:
 
1. `src/Adesso.Dapr.Crypt` dizinine gidin.
2. İhtiyacınız olan değişiklikleri yapın.
3. Docker Compose ile projeyi yeniden başlatarak değişikliklerinizi test edin.
 
Katkıda bulunmak için, lütfen pull request göndermeden önce projenin katkıda bulunma rehberini okuyun.
 
## Kaynaklar
 
İlgili makale ve
 
dokümantasyona [Dapr.io](https://docs.dapr.io/developing-applications/building-blocks/secrets/secrets-overview/) ve [Azure Key Vault](https://docs.microsoft.com/en-us/azure/key-vault/) sayfalarından ulaşabilirsiniz.
 
---