# FinalProject

//B?R MANAGER KEND?S? HAR?� BA?KA B?R DAL(Data Access Layer ?) ENJECTE EDEMEZ

//Her entity nin kendine ait ve service si var

Installed Belows by using nuget pakages
Microdoft Entity Framework
Autofac kullan?lmas?n?n sebebi ayn? zamanda AOP sa?lamas?d?r.
Autofact --> Autofac, Autofac.Extras.DynamicProxy, Autofac.Extensions.DependencyInjection
	FluentValidation,
	Business Projesine eklendi.


WebApi projesinde tan?mlanan IoC configurasyonun buraya bag?ml? olmamas? ad?na configurasyonalar?
Business projesi alt?nda DependencyResolvers alt?nda her bir imlementasyon olu?turulan klas�r alt?nda tan?mland?.

Cross Cutting Concerns (Uygulamay? dikine kesen ilgi alanlar?)
Uygulamada t�m katmanlarda kullanabilecegi i�in Core k?sm?na yaz?l?r
	-Log
	-Cache
	-Transaction
	-Authorization
	- performans y�netimi gibi

AOP ile metotlar?n ba??nda, sonunda veya hata verdi?inde cal??t?r?lmak istenen metotlar varsa
bunlar? design etmeye yarar. Bu yonteme interceptor(interception) denir
