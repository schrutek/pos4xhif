# Formeln in Excel

Das Excel mit Formeln umgehen kann, ist vermutlich nichts großartig neues. Eine Formel schreibt man in jene Zelle, in der man das Ergebnis der Formel stehen haben möchte. Jede Formel beginnt mit einem = (ist gleich) Zeichen.

z.B.: Ich habe in einer Zelle den Wert 3 und in einer anderen Zelle (egal wo) einen anderen Wert und ich mövhte die beiden addieren, sieht das so aus:

![Formeln01](Formeln01.PNG)

3 + 5

die Formel dafür:

=A3+A4 (es beginnt immer mit =, und anschließend die Zellen angeben mit denen man rechnen möchte

## Zellenbezüge

Wie teilt man nun Excel mit, mit welchen Zellen man rechnen möchte. Das funktioniert über die Zellenbezüge.

A3 heißt: Die Splate A, die dritte Zeile, bzw. was dort drinnen steht.

Würde man nun die Formel in Zelle A5 nach rechts kopieren, zählt Excel automatisch die Spalten ebenfalls in die höhe. (A, B, C, D, ...)

![Formeln02](Formeln02.PNG)

Das macht Excel automatisch für uns. Das funktioniert in alle Richtungen, waagerecht oder senkrecht. Das ist sehr praktisch, weil man so Formeln über reinen BEreich einfach nach unten, oben, unten, links oder rechts ziehen kann und Excel geht in den Zeilen und Spalten automatsich weiter.

Manchmal will man das aber nicht, dann muss man Excel explizit sagen, welcher Wert in der Formel, die Zelle nicht verlassen soll. Das machtt man mit dem $-Zeichen.

z.B.: Ich möchte die Summen der Tabelle (Zeile 5) immer mit dem Wert in Zelle E1 multiplizieren. Dann muss man angeben:

=A3+A4*$E$1

$E$1 heißt: Bleib immer in der Zelle E1. Würde man das nicht angeben, würde Excel für die Formel in Spalte B  mit dem Wert in F1 rechnen und für die Spalte C mit dem Wert in G1. Das wäre falsch, weil dort nichts drinnen steht.

Shortcut für diese Funktion ist die F4-Taste. Also einfach die Zelle in der Formel eingeben und dann F4 drücken, dann spart man sich die Eingabe der $-Zeichen.

![Formeln03](Formeln03.PNG)

Das gilt für Splaten und Zeilen separat.

$E$1 ... zähle Spalte und Zeile nie hoch
$E1 ... bleibe in der Splate, aber Zähle die zeile hoch
E$1 ... bleibe in der Zeile, aber zähle die Splate hoch

## Formeln

Das obere Beispiel ist bereits eine Formel. Excel kann sehr gut rechnen. Man kann beliebig viele Zelleninhalte addiern, multiplizieren, dividieren, usw. Darüber hinaus verfügt Excel über ein reiches Set an Funktionen.

## Funktionen

Funktionen können in Formeln verwendet werden. Eine Formel kann auch nur aus einer einzelnen Funktion bestehen. Z.B. einer Summe.

Klickt man hier, wird ein Dialog geöffnet in dem man eine Funktion auswählen kann:

![Formeln04](Formeln04.PNG)

Es gibt in Excel davon sehr viele und es würde den Rahmen sprengen, diese alle zu beschreiben. Wir werden uns nur mit den wichtigsten beschäftigen.

### Summe

Die Summen-Funktion ist quasi das gleiche wie oben. A1+A2+A3+A4.

Soweit so gut, möchte man aber die Summe über 1.283 Zeilen wissen, tippt man relativ lange. Das geht einfacher:

![Formeln05](Formeln05.PNG)

Kurze Erklärung dazu. In der Zelle B9 möchte ich die Summe über alle Zellen darüber bilden. Das geht mit der Summe-Funktion. Die Zelle B9 enthält also nur eine einzige Funktion, nämlich SUMME (in meiner Englischen Version SUM). In der Klammer stehen die Parameter. Die Summe soll also über den Bereich B2 bis B8 berechnet werden. Also alle Werte in diesem bereich sollen addiert werden. Jede Funktion hat natürlich ihre eigenen Parameter. Möchte man eine Funktion benutzen, sollte man über die Parameter dieser Funktion bescheid wissen. Excel bietet dazu einige Informatonen, aber nicht sehr detailliert. Man muss wissen wan man tut. Wenn man sich hier auf Neuland begibt, bleibt einem googeln nicht erspart.

**Parameter werden mit einem Semikolon (;) getrennt!**

### WENN (IF)

Die WENN-Funktion zum Beispiel, benötigt 3 Parameter. Der erste ist die Bedingung (wie eine IF-Beingung in Java), der 2. Parameteer ist der DANN-Zweig, der dritte Parameter der SONST-Zweig (ELSE).

![Formeln06](Formeln06.PNG)

Diese Beispiel schreibt in die Zelle C3, ob der Wert in Zelle B3 kleiner oder größer 5 ist.

## Parameter von Funktionen

Parameter werden mit einem Semikolon (;) getrennt. Die Datentypen die dabei verwendet werden können, sind ganz unterschiedlich. Es können Zahlenwerte, Zeichenketten (String) oder Datumswerte sein. Es ist im Prinzip wie in Java, wenn man eine Methode aufruft. Bei Excel muss man allerdings immer ein bißchen nachdenken, welchen Datentp die Funktion erwartet. Meinstens ist es aber logisch.

Parameter können natürlich weitere Funktionen enthalten. So kann sich eine Formel ziemlich tief verschachteln. Das kann schnell unübersichtlich werden. Excel bietet nur eine kleine Hilfe, indem die Zellen, die in einer Formel vorkommen und die Zellenbezüge in der Formel in der selben Farbe markiert. Die Klammerung allerdings sollte man immer im Auge behalten. Stimmt sie nicht, gibt Excel eine Fehlermeldung aus und versucht die Formel nach bestem Wissen und Gewissen zu korrigieren. Das gelingt aber nicht immer.

## Übung

In der Übung beschäftigen wir uns mit den wichtigsten Formeln in Excel. Es sind jene Formeln, die man eigentlich immer wieder braucht.

Auf moodle ist ein Excel-Sheet hochgeladen. Das Sheet enthält lediglich Tabellen mit Zahlen. Es sollen in jedem einzelen Arbeitsblatt die richtigen Formeln mit den richtigen Parametern und Zellenbezüge eingesetzt werden.

### Arbeitsblatt: WENN-DANN-SONST

In Spalte E und F ist eine Staffelung von Bonuswerten aufgelistet und die entsprechenden Prozentwerte dazu. Es soll in Splate C der entsprechende Bonus berechnet werden.

Z.B.: Liegt der Umsatz zwischen 100.000 € und 150.000 € erhält der Kunde einen Bonus von 2% von seinem Umsatz (Spalte B). Der Wert soll in der Splate C berechnet werden. Für die Zeile 7 wäre das richtige Ergebnis 3.750 €. Die Staffelung ist wie gesagt in den Splaten E, F und G angegeben.

Das ist bestimmt die schwierigste Übung, da hier sehr viel überlegt werden muss, daher ist sie gleich zu Beginn.

### Arbeitsblatt: SVERWEIS

Der SVERWEIS ist so etwas wie eine Suche. Aus den Spalten F und G wird die Splate C mit Werten befüllt. Splate C wir aus der Spalte G befüllt, wenn der Wert in Spalte A mit jenem in Splate F übereinstimmt.

### Arbeitsblatt: SUMMEWENN

Hier wird die Summe unter einer bestimmten Bedingung gebildet. Es sollen die Umsätze der Kundenarten a, b, c, d separat ausgegeben werden.

### Arbeitsblatt: ZAEHLENWENN

Das ist ganz ähnlich wie Summe Wenn, nur das hier keine Summe, sondern die Anzahl ausgegeben wird.

### Arbeitsblatt: ANZAHL2

Zählt die Werte in einem Bereich, unabhängig vom Datentyp, außer leere Zellen.

### Arbeitsblatt: VERKETTEN

Verketten wird hauptsächlich für Strings verwendet. Es ist sehr hilfreich, wenn man aus einzelnen Strings in einzelen Zellen, einen ganzen Satz oder etwas ähnliches bauen (verketten) möchte. In dieser Übung soll aus Vorname, Nachname und Geschlecht eine Anrede wie "Sehr geehrter Herr Max Muster", oder "Sehr geehrte Frau Maria Muster" zusammengebaut werden. Wir haben das im Zusammenhang mit dem Serienbrief schon besprochen. Es ist meiner Meinung nach eine sehr hilfreiche Funktionen.

Ich habe wieder ein Video gefunden, dass ihr euch unbedingt ansehen solltet. Es erklärt die Funktionen nicht nur sehr gut, es enthält quasi die Lösung zu dieser Übung und wird euch sehr helfen. Damit ist die Übung plötzlich sehr viel leichter.

https://www.youtube.com/watch?v=GwA67xGbZOw
