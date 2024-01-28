# Adesso.Dapr.PubSub
 
Bu proje, .NET 8 ile geliştirilmiş ve Dapr.io ile entegre edilmiş bir Web API uygulamasıdır. RabbitMQ kullanarak pub/sub (yayıncı-abone) modelini uygular. Projeyi Docker container'ları içinde çalıştırmak için Docker ve Docker Compose kullanılır.
 
## Özellikler
 
- **.NET 8**: Güçlü ve modern bir web uygulama çerçevesi.
- **Dapr**: Mikroservisler için taşınabilir, olay odaklı bir runtime.
- **RabbitMQ**: Güvenilir mesajlaşma için kullanılan açık kaynak bir message broker.
 
## Kurulum
 
Projeyi yerel olarak çalıştırmak için aşağıdaki adımları izleyin:
 
### Önkoşullar
 
- Docker ve Docker Compose yüklü olmalıdır.
- .NET 8 SDK yüklü olmalıdır (opsiyonel, Docker kullanılıyorsa gerekli değildir).
 
### Yapılandırma
 
1. Projeyi GitHub'dan klonlayın veya indirin.
2. `PubSub/src/Adesso.Dapr.PubSub` dizinine gidin.
3. Dapr için RabbitMQ pub/sub bileşenini içeren `components` dizinindeki `rabbitmq-pubsub.yaml` dosyasını kontrol edin.
 
### Docker Compose ile Çalıştırma
 
1. `PubSub/deploy/` dizinine gidin.
2. Aşağıdaki komutu çalıştırarak tüm servisleri başlatın:
 
   ```bash
   docker-compose up --build
   ```
 
Bu komut, RabbitMQ, Web API ve Dapr servislerini Docker container'larında başlatır. Web API'ye `http://localhost:5000/` adresinden, RabbitMQ yönetim arayüzüne ise `http://localhost:15672/` adresinden erişebilirsiniz.
 
### API Endpoints
 
- **POST api/sample/publish**: Bir mesaj yayınlar.
- **POST api/sample/subscribe**: Yayınlanan mesajları alır.


## Geliştirme ve Katkıda Bulunma
 
Projeyi yerel geliştirme ortamınızda çalıştırmak ve değişiklikler yapmak için:
 
1. `PubSub/src/Adesso.Dapr.PubSub` dizinine gidin.
2. İhtiyacınız olan değişiklikleri yapın.
3. Docker Compose ile projeyi yeniden başlatarak değişikliklerinizi test edin.
 
Katkıda bulunmak için, lütfen pull request göndermeden önce projenin katkıda bulunma rehberini okuyun.

## Kaynaklar
 
İlgili makale ve dokümantasyona [bu linkten](https://docs.dapr.io/developing-applications/building-blocks/pubsub/pubsub-overview/) ulaşabilirsiniz.