# Exercise06 Agent-Workflow

Diese Datei dient der Middleware als strukturierte Grundlage fuer die automatisch erzeugten Issues von Maria und Juergen. Die fachliche User Story und die Akzeptanzkriterien stehen in `README.md`.

## 1. Initiale Aufgabe von Maria an die Studierenden

Maria erstellt dieses Assignment-Issue automatisch, sobald das studentische Repository durch GitHub Classroom angelegt wurde.

Die Studierenden sollen zuerst das Repository vorbereiten:

- Den LiaScript-Course-Link in `README.md` auf das eigene studentische Repository umstellen.
- Ein leeres C#-Konsolenprojekt fuer die Baufflaechenverwaltung anlegen.
- Dafuer einen eigenen Branch verwenden, eine Pull Request nach `main` erstellen und den PR-Body mit `Closes #<Issue-Number>` verknuepfen.
- Auf die automatische Review von Lisa warten; `main` ist geschuetzt und die Vorbereitung wird erst nach positiver Review gemerged.

Der Projekt-Setup-Befehl soll explizit genannt werden:

```bash
dotnet new console -n Baufflaechenverwaltung
```

Nach dem Merge dieser Vorbereitungs-PR erstellen die Studierenden ein eigenes GitHub-Issue fuer Kevin:

- Das Issue muss von den Studierenden selbst formuliert werden.
- Das Issue muss das Label `kevin` erhalten.
- Das Issue soll Kevin konkret beauftragen, die User Story aus `README.md` umzusetzen.
- Kevin wird durch das Label `kevin` aktiviert und erstellt daraus eine Pull Request.

## 2. Validierung von Kevins Pull Request durch Lisa

Lisa reviewed Kevins Pull Request automatisch. Der Server wartet dabei auf den `dotnet-build`-Workflow und uebergibt dessen Logs an Lisa.

Lisa soll insbesondere pruefen:

- Die Akzeptanzkriterien in `README.md` sind vollstaendig und fachlich korrekt umgesetzt.
- Das C#-Projekt baut erfolgreich im `dotnet-build`-Workflow.
- Die Konsolenausgabe demonstriert die Funktionalitaet nachvollziehbar.
- Die Klassenstruktur ist erweiterbar und passt zur Flaechenverwaltung.
- Kevin hat keine unangeforderten grossen Architekturwechsel oder fachfremden Features eingebaut.

Erwartete fachliche Mindeststruktur:

- Klassen: `Grundstueck`, `Bauflaeche`, `Bauvorhaben`, `Antragsteller`
- Eigenschaften: alle in der User Story genannten Attribute fuer Flaechen, B-Plan-Daten, Antragsteller, Zeitplan und Status
- Methoden: `FlaecheReservieren()`, `BauvorhabenAnlegen()`, `StatusAktualisieren()`
- Eine einfache Demonstration in `Main()` reicht aus; ein Command-Line-Parser ist nicht erforderlich.

## 3. Erstes Issue von Juergen nach Kevins erstem Merge

Juergen erstellt nach dem Merge von Kevins erster Umsetzung ein bewusst unscharfes Folge-Issue. Dieses Issue enthaelt zwei Themen, die die Studierenden aufteilen und priorisieren sollen.

Juergens Ton soll beratend, freundlich und etwas plaudernd sein. Er darf die bisherige Arbeit von Kevin und den Studierenden loben, bleibt aber fachlich unscharf genug, damit die Studierenden uebersetzen muessen.

Enthaltene Themen:

- Falls noch nicht vorhanden oder unzureichend: ein UML-Klassendiagramm zur Klassenstruktur in `README.md` ergaenzen.
- Funktionalitaet erweitern:
  - Validierungslogik fuer Flaechen und Bauvorhaben einfuehren, zum Beispiel pruefen, ob eine Flaeche bereits bebaut ist, bevor sie reserviert wird.
  - Methode `BebaubarkeitPruefen()` implementieren, die auf Basis von B-Plan-Daten die Bebaubarkeit einer Flaeche zurueckgibt.

Die Studierenden sollen daraus zwei eigene, klare Issues erstellen. Beide studentischen Issues muessen das Juergen-Issue im Titel oder Body mit `#<Issue-Number>` referenzieren, damit die Herkunft nachvollziehbar bleibt. Hoestens eines dieser beiden Issues darf das Label `kevin` erhalten; mindestens eines muss ohne Kevin von den Studierenden selbst per Branch und Pull Request geloest werden.

## 4. Weitere Juergen-Issues zur Triage

Nach dem ersten Merge einer Juergen-Aufgabe erzeugt Juergen weitere Issues, die von den Studierenden kategorisiert werden sollen.

Die Studierenden sollen diese Aufgaben nach Prioritaet, Aufwand und Abhaengigkeiten einordnen, passende Labels setzen und entscheiden, was an Kevin uebergeben, zurueckgestellt oder verworfen wird.

Themen fuer die weiteren Issues:

1. **Datenpersistenz:** Serialisierung und Deserialisierung von Flaechen und Bauvorhaben als JSON.
2. **Benutzerverwaltung:** Rollen wie Bauamtsmitarbeiter, Antragsteller und Gutachter mit einfachen Berechtigungen.
3. **Output:** Konsolenausgabe, die alle Flaechen und deren Status uebersichtlich anzeigt.
4. **Erweiterte Validierung:** Bauvorhaben auf Ueberschneidungen mit Naturschutzgebieten pruefen; externe Datenquelle darf simuliert werden.
5. **Dokumentation:** Bericht als Textdatei mit allen aktiven Bauvorhaben und deren Status erzeugen.
6. **Erweiterbarkeit:** Neue Validierungsregeln, zum Beispiel Brandschutz oder Barrierefreiheit, sollen spaeter einfach ergaenzt werden koennen.

## 5. Labels und Verantwortlichkeiten

- `assignment`: Assignment-Issue von Maria.
- `student-task`: Aufgabe fuer die Studierenden.
- `kevin`: Issue ist fuer Kevin bestimmt und aktiviert den Kevin-Agenten.
- `csharp`: C#-Implementierungsaufgabe.
- `documentation`: Dokumentations- oder README-Aufgabe.
- `enhancement`: neue Funktionalitaet oder Erweiterung.
- `bug`: Fehler oder unerwartetes Verhalten.
- `question`: Klaerungsbedarf.
- `blocked`: blockiert durch fehlende Informationen oder Abhaengigkeiten.
- `wontfix`, `duplicate`, `invalid`, `help wanted`: normale Triage-Labels.

Kevin darf nur Issues bearbeiten, die von Studierenden erstellt wurden und das Label `kevin` tragen. Maria- und Juergen-Issues muessen von den Studierenden erst in konkrete Kevin-Issues uebersetzt werden. Bei Issues, die aus einem Juergen-Issue entstehen, muss das urspruengliche Juergen-Issue mit `#<Issue-Number>` referenziert werden.
