# Der Database-First-Ansatz
Den Database-First Ansatz haben wir bereits kennen gelernt. Aus einer bestehenden Datenbank werden Models und der Database-Context generiert. Natürlich kann auch aus bestehenen Models und einem Database-Context eine Datenbank generiert werden.

## Anwendung
Der Ansatz eigent sich gut für prototyping oder kleinen Projekte die von der "grünen Wiese" weg erstellt werden. Meistens wird in diesen Fällen ohne DB-Team gearbeitet. Der Entwickler kann sich so auf einfache Weise eine Datenbank erstellen lassen. Für große Projekte ist der Ansatz nicht zu empfehlen.

# Vorgehensweise bei Code First
Wir haben noch keine Datenbank. Sie wird aus den Models (Source Code) erstellt.

## Installation von Entity Framework Core
Wie im Database First Ansatz (den wir schon kennen gelernt haben), benötigen wir auch hier wieder einige NuGet-Packages:

+ Microsoft.EntityFrameworkCore.Tools
+ Microsoft.EntityFrameworkCore.Sqlite
+ Microsoft.EntityFrameworkCore.Design

Wir müssen die NuGat-Package wie folgt installieren:

```Powershell
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Sqlite
Install-Package Microsoft.EntityFrameworkCore.Design
```
Entweder direkt über die Packet Manager Console, oder etwas konfortabler über den NuGet Packet Manager.

Das Package <code>Designer</code> ermöglicht uns die Erstellung von Migrations. Diese Package muss immer im ausführbaren Projket installiert werden. Dazu später mehr.

## Generieren (coden) der Model-Klassen
Als nächstes können wir die Models erstellen. Sie dienen dabei als Vorlage für die zu erstellende Datenbank, In der Applikation haben sie aber die gewohnte Funktion als Datenhalter. Es besteht also kein Unterschied.

Wir verwenden gewohnte C#-Datentypen.

z.B.:
```C#
public class Pupil
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public virtual Guid SchoolClassId { get; set; }
}
```

## Festlege der Feldgrößen, Datentypen, ...
Es gibt nun 2 Möglichkeiten der Konfiguration:

### Annotations in der Model-Klasse:
In dieser Variante werden Annotations an die Properties der Models platziert:

z.B.:

```C#
[Required]
public Guid Id { get; set; }

[Required]
[MaxLength(250)]
public string FirstName { get; set; }

[Required]
[MaxLength(250)]
public string LastName { get; set; }
```
### Configuration:
In dieser Variante werden die Informationen in die Configutration der Models eingetragen.

```C#
        public void Configure(EntityTypeBuilder<Pupil> builder)
        {
            builder.ToTable("Pupils");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.FirstName).HasMaxLength(250).IsRequired();
            builder.Property(c => c.LastName).HasMaxLength(250).IsRequired();

            builder.HasData(
                new Pupil() 
                { 
                    Id = new Guid("26a76d85-7577-4b53-abd1-4aca501a3f68"), 
                    FirstName = "Vorname 1", 
                    LastName = "Nachname 1",
                     Gender = "M", 
                     SchoolClassId = new Guid("75d42b58-c4c6-4380-9f8b-bacdcf8e03ee")
                },
                new Pupil() 
                { 
                    Id = new Guid("5699f9fe-4f2d-4c00-b226-007e0ff42ca7"), 
                    FirstName = "Vorname 2", 
                    LastName = "Nachname 2", 
                    Gender = "M", 
                    SchoolClassId = new Guid ("75d42b58-c4c6-4380-9f8b-bacdcf8e03ee")
                },
                ...
            );
        }
```

## Generieren (coden) der Configuration
Wir müssen der Datenbank natürlich die Abhängigkeiten mitteilen, die erstellt werden sollen. Also alle Relationen. Wie bereits besprochen, sind sie im Model in Form von <code>ICollection</code> abgebildet. Diese werden vom OR-Mapper in Relationen zwischen den Tabellen übertragen.

Die Abfolge der Schritte ist immer ähnlich (gleich) und kann daher durchaus als _Kochrezept_ verstanden werden.

z.B.:

ein _Team_ hat viele _Messages_:

oder 

_Team_ 1 .. n _Message_

..würde so in der Team-Configuration angelegt werden:

```C#
builder.HasMany(c => c.Messages).WithOne(c => c.Team).HasForeignKey(c => c.TeamId).OnDelete(DeleteBehavior.Cascade);
```

Achtung: Natürlich muss auch imModel die relation in Form einer Collection abgebildet werden. Hierfür muss der Modifier virtual verwendet werden, da EF Core das Property überschreiben wird.

## Generieren (coden) des DBContext
In dieser Variante müssen wir den DB Context selbst programmieren. In der Database First-Variant wird er erstelt, muss aber eigentlich immer angepasst werden.

Die dafür notwendige Klasse leitet von der Klasse <code>DbContext</code> ab, im Namespace <code>Microsoft.EntityFrameworkCore</code>.

Anschließend werden die Properties gesetzt, die die Tabellen in der Datenbank repräsentieren gesetzt:

```C#
 public DbSet<Pupil> Pupils { get; set; }
```

Anschließend wird der Default-LKonstruktor überschrieben:

```C#
public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        { }
```

Dann überschreiben wir die Methode on <code>OnModelCreating</code> die von der Basisklasse zur Verfügung gestellt wird.

```C#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.ApplyConfiguration(new PupilConfiguration());
}
```

## Migrations
Wir sind nun breit die datenbannk zu erstellen. Wie bereits oben eerwähnt, hilft uns dabei der Designer. Wir erstellen nun eine Migration. Migrations syncrosisieren die Models mit der Datenbank. Wird etwas an dern Models geändert, muss eine neue Migration angelgt werden.

Es gint folgende Migration-Kimmandos:

| Kommandos                         | Beschreibung                                                              |
| --------------------------------- |---------------------------------------------------------------------------|
| add-migration <migration name>    | Erstellt eine neue Migration (Migration Snapshot)                         |
| remove-migration                  | Löscht den letzten Migration Snapshot                                     |
| update-database                   | Aktualisiert die Datenbabnk basierend auf dem letzten Migration Snapshot  |
| script-migration                  | Generiert ein SQL-Script aller Migrations                                 |

## CRUD Operations


## Übung
Lade die Solution <code>XX</code> herunter und ergänze sie um das Model <code>SchoolClass</code>. Das Datenmodell sieht dabei so aus, dass eine <code>SchoolClass</code> n <code>Pupils</code> hat.

#### Vorgehensweise:
+ Füge das Model im richtigen Namesapce hinzu.
+ Erstelle ein Property in <code>Pupils</code>, das eine Referenz auf <code>SchoolClass</code> hat.
+ Erstelle ein Property mit dem richtigen Datentyp in <code>Pupils</code>, das die Id der referenzierten <code>SchoolClass</code> speichert. (<code>SchoolClassId</code>)
+ Füge eine Configuration für das Model hinzu (Vergiss dabei nicht auf die Relation).
+ Erstelle eine neue Migration mit einem eindeutigen namen.
+ Führe eine Aktualsierung der Datenbank mit dem entsprechenden Kommando durch.

##### (Für die schnellen)
+ Erstelle CRUD-Methoden in der <code>Program.cs</code>. Du kannst dich dabei an die Controller-Logik der Übung REST -  Entity Framework halten.

xxxx