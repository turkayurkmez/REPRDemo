# REPRDemo

**.NET 10 Minimal API** ile **REPR (Request-Endpoint-Response) Pattern** uygulamasını gösteren demo projesidir.

## REPR Pattern Nedir?

REPR, her API endpoint'ini üç sorumluluğa ayıran bir tasarım desenidir:

| Bileşen | Sorumluluk |
|---------|------------|
| **Request** | Gelen veriyi temsil eden immutable DTO |
| **Endpoint** | HTTP routing ve handler'a yönlendirme |
| **Response** | Dönen veriyi temsil eden immutable DTO |

Bu yaklaşım, geleneksel controller tabanlı yapıya kıyasla daha **odaklı**, **test edilebilir** ve **sürdürülebilir** bir mimari sunar.

## Proje Yapısı

```
REPRDemo/
├── Features/
│   └── Products/
│       └── CreateProduct/
│           ├── CreateProductRequest.cs
│           ├── CreateProductEndpoint.cs
│           └── CreateProductResponse.cs
├── Models/
│   └── Product.cs
├── Services/
│   ├── ICreateProductHandler.cs
│   └── CreateProductHandler.cs
├── Shared/
│   ├── IEndpoint.cs
│   └── EndpointExtensions.cs
└── Program.cs
```

## Öne Çıkan Özellikler

- **Feature-based klasör yapısı** — Her endpoint kendi klasöründe, ilgili Request/Response ile birlikte
- **Otomatik endpoint keşfi** — `IEndpoint` arayüzü ve reflection ile tüm endpoint'ler otomatik kaydedilir
- **Handler ayrımı** — İş mantığı endpoint'ten bağımsız, DI ile enjekte edilen handler'larda
- **Record tipler** — Request ve Response modelleri için immutable record kullanımı
- **OpenAPI desteği** — Swagger/OpenAPI metadata entegrasyonu

## Gereksinimler

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

## Çalıştırma

```bash
cd REPRDemo
dotnet run
```

API varsayılan olarak `http://localhost:5295` adresinde çalışır.

## API Endpoint'leri

### Ürün Oluştur

```
POST /api/products
Content-Type: application/json

{
  "name": "Sample Product",
  "price": 29.99,
  "categoryId": 1
}
```

**Yanıt:** `201 Created`

```json
{
  "id": 1,
  "name": "Sample Product",
  "price": 29.99,
  "createdAt": "2025-07-17T12:00:00Z"
}
```

## Lisans

Bu proje eğitim amaçlıdır.