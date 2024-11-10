# FinalProject

### Clean Code 
Bir Manager kendisi hariç başka bir "Data Access Layer"ı implemente edemez. Bunun yerine Servisleri(Service) kullanabilir

Her Entity nin kendine ait ve Servisi (Service) vardır.

Aşağıdakiler gerekli projelere Nuget pakages kullanılarak indirilmiştir.
- Microdoft Entity Framework
- Autofac,
  - Autofac kullanılmasının sebebi ayı zamanda AOP(Aspect Oriented Programming) sağlamasıdır.
- Autofac.Extras.DynamicProxy,
- Autofac.Extensions.DependencyInjection
- FluentValidation,

WebApi projesinde tanımlanan IoC configurasyonu Business projesi altında DependencyResolvers altında Autofac klasörü altında yer almaktadır.

Cross Cutting Concerns (Uygulamayı dikine kesen ilgi alanları)
Uygulamada tüm katmanlarda kullanabilecegi için Core kısmına yazılır.
	-Log
	-Cache
	-Transaction
	-Authorization
	- performans yönetimi gibi

AOP ile metotların başında, sonunda veya hata verdiğinde calıştırmak istenen metotlar varsa
bunları design etmeye yarar. Bu yonteme interceptor(interception) denir
