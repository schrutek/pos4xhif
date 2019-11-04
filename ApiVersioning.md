# API-Versioning
Wir haben eine REST Api geschrieben, die nun von vielen Clients verwendet wird und die zufreiden sind. 
Allerdings möchten wir nun ein neues, wichtiges Feature hinzufügem, dass allerdings wesentliche Teile 
der API verändert. Die bestehenden Kunden kann man dadurch natürlcih nicht vor den Kopf stoßen.

Dafür gint es eine Lösung:

_Eine API-URI die wir kennen:_

```http
.../api/pupil
```

_z.B.: Eine versionierte API-Url:_
```http
.../api/v2/pupil
```
## Routen sind eindeutig, auch versionierte
Prinzipiell setztt ASP Core die eindeutigkeit von Routen voraus, da es eine 1-1 Zuordnung zwischen Route und Controller voraussetzt. (Eine Route kann immer nur zu einer Controller-Methode gehen). Durch  Versionierung können nun auch Routen über ihre Version eindeutig identifiziert werden.

z.B.: _.../api/pupil_ kann es für unterschiedliche Versionen geben.


## Arten der Versionierung
REST gibt keine konkrete Art der Versonierung vor, allerdings haben sich im Laufe der Zeit 4 Arten der Versioniertung durchgesetzt, bzw. werden vom Framework unterstützt:

- [Quer-String-Versioning](#Quer-String-Versioning)
- [URL-Path-Versioning](#URL-Path-Versioning)
- [Header-Versioning](#Header-Versioning)
- [Media-Type-Versioning](#Media-Type-Versioning)

### Quer-String-Versioning
(Default)
An die URL, also an den Query-Strring wird einfach ein weiterer Parameter angefügt:

```http
.../api/pupil?api-version=1.0
.../api/pupil?api-version=2.0
```

(siehe https://github.com/microsoft/aspnet-api-versioning/wiki/Versioning-via-the-Query-String)

### URL-Path-Versioning
Das ist die einfachste und am heufigsten verwendete Art der Versionierung, Allerdings verstößt es gegen den Ansatz, dass eine URI eine eindeutige Resource identifiziert. Andererseits sollte nach dem HATEOAS-Paradigma lediglich die Start-Uri einer REST API relevant sein, da ja alle weitern URIs von der API bereitgestellt werden.

Beispiel für URI-Versioning:
```http
http://localhost:5001/api/pupil
http://localhost:5001/api/v2/pupil
http://localhost:5001/api/v2.1/pupil
```

Die Versionsnummer muss dabei keineswegs numerisch sein, oder das Prefix 'v' tragen. Es ist aber verbreitet.

(siehe https://github.com/microsoft/aspnet-api-versioning/wiki/Versioning-via-the-URL-Path)


### Header-Versioning
Hier wird die Versionsnummer im Header vom Client an den Server übertragen. 

Nachteil dieser Variante ist allerdings, die erhöhte Komplexität in der Generierung der Requests.

z.B.:
```http
Accept-version: v1
Accept-version: v2
```
### Media-Type-Versioning
Bei deiser Variante wird die Versionierung mittels _Inhaltsverhandlungen_ (content negotiation) durchgeführt. Der Vorteil ist, dass hier einzelne Teile einer API versioniert werden können, was die Komplexität serverseitig reduziert.

```http
GET api/pupil HTTP/1.1
host: localhost
accept: text/plain;v=2.0” 
```

(siehe https://github.com/microsoft/aspnet-api-versioning/wiki/Versioning-by-Media-Type)

***

__Wir beschäftigen uns mit der populärsten Variante weiter (URL-Path-Versioning):__

## Insatllation der NuGet-Packages
Wir müssen dazu folgendes NuGat-Package installieren:
```powershell
Install-Package Microsoft.AspNetCore.Mvc.Versioning
```
Entweder direkt über die Packet Manager Console, oder etwas konfortabler über den NuGet Packet Manager.

## Erweiterung der _startup.cs_
Zur _ServicesCollection_ der _Startup.cs_ muss die Versioning-Middleware hinzugefügt werden. Idealerweise passiert das wieder (über die bereits bekannt Weise) mittels einer Extension-Methode, die die _ServicesCollection_ erweitert.

```C#
services.AddApiVersioning(options => 
{
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});
```

## Erweiterung des Controllers
Die Erweiterungen am Controller sind recht überschaubar. Wir haben bereits die Annutation "_Route_" kennen gelernt. Diese wird um den Versionseintrag "_/v{version:apiversion}/_" erweitert.

Dazu wird allerding eine weitere Annutation über dem Controller festgelegt, die die Versionsnummer definiert:

```C#
[ApiVersion("1.0")]
[Route("api/v{version:apiversion}/[controller]")]
```

Die unterschiedlichen Versionen werden am einfachsten im selben Controller-File (cs-File) implementiert und in unterschiedlichen Namespaces untergebracht.

z.B.:

```C#
namespace SPG.Pupil.Api.Controllers.V1
{
    ...
}

namespace SPG.Pupil.Api.Controllers.V2
{
    ...
}
```

## Abschließend
Prinzipell gilt:

Eine  Versionierung ist schnell programmiert, aber eine sauber Versionierung muss richtig durchdacht sein. Die Gefahr bestehen darin, das man durch die Abwärtskompatibilität sehr rasch unübersichtliche Controller erzeugt.

Daher sollten Controller nur die notwendigsten Codezeilen enthalten. Der Hauptteil der Logik sollte von Services umgesetzt werden, die idealereise durch Dependency-Injection instanziert werden. Das gewährleistet noch am ehesten eine saubere Lösung. Ich erinnere an die Regeln:

- so wenige Änderungen wir möglich nach der Veröffentlichung (vorher Gedanken machen)
- KISS (keep it simple an stupid)

Wird eine API einem breiten Publikum zur Verfügung gestellt, ist die Versionierung absolut notwendig. Wird in einer Applikation API und Client vom gleichen Entwicklerteam betreut, oder von Teams betreut die eng zusammenarbeiten, gibt es keinen Grund für Versionierung.

***

## Übung
Öffne die Solution _PostRequestExample.sln_ von der letzten DB-Übung und erweitere Sie um Versionierung. Gehe dabei so vor:

- Installiere alle notwndigen Packages
- Schreibe die Extension-Method (lege dazu eine neue Klasse _VersioningExtensions.cs_ im Namespace _Extensions_ an)
- Erweitere die _Startup.cs_
- Erweitere den Controller (V1 und V2)
- Im Namespace V2 ändere in der Get-Methode den Zugriff von DB wieder zurück auf die Mock.Db (von _SchuleContext_ zurück zu _SchuelerDb_)