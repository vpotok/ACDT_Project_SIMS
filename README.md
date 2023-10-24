[![C#](https://badgen.net/badge/Language/C%23/green)](https://docs.microsoft.com/en-us/dotnet/csharp/) [![Microsoft SQL Server](https://badgen.net/badge/Database/Microsoft%20SQL%20Server/orange)](https://www.microsoft.com/en-us/sql-server) [![Docker](https://badgen.net/badge/Tool/Docker/blue?icon=docker)](https://www.docker.com/) [![Spectre.Console.net](https://badgen.net/badge/Website/Spectre.Console.net/purple)](https://spectresystems.github.io/spectre.console/)






# Security Incident Management System
Unser Sicherheitsereignis-Verwaltungsprogramm ist ein leistungsstarkes Tool, das Ihnen hilft, sicherheitsrelevante Vorfälle effizient zu erfassen und zu verwalten. Es bietet eine Vielzahl von Funktionen, die Ihnen dabei helfen, den Überblick über Sicherheitsvorfälle zu behalten und angemessen darauf zu reagieren.

## Funktionen
1. Manuelle Erfassung von sicherheitsrelevanten Vorfällen: Erfassen Sie wichtige Informationen wie Schweregrad, Vorfallsstatus, Zeitstempel, Beschreibung und wer diesen gemeldet hat.
2. Eskalation an den nächsten Benutzer: Automatisches Weiterleiten von Vorfällen an den entsprechenden Benutzer basierend auf einem vordefinierten Eskalationslevel.
3. Notifizierung: Grundlegende Benachrichtigungsfunktionen über Discord.
4. Log-Tabelle: Behalten Sie den Überblick über Aktivitäten im System, einschließlich Vorfall hinzufügen/bearbeiten/schließen, Eskalation, Notifizierung sowie Benutzer hinzufügen/löschen.

# Funktionsbeschreibung

## Benutzerverwaltung

### 1. insert user
   - Ermöglicht das Hinzufügen eines Benutzers zur Datenbank.
### 2. select user
   - Ermöglicht die Auswahl eines Benutzers anhand der ID und zeigt die entsprechenden Details an.
### 3. select all user
   - Zeigt alle Benutzer und ihre Tabellenwerte an.
### 4. update user
   - Ermöglicht das Aktualisieren der Attribute "Vorname", "Nachname", "isAdmin" und "isActive" eines Benutzers.

## Vorfälle
### 1. select unsolved incidents
   - Zeigt alle Vorfälle an, bei denen der Status auf "unsolved" gesetzt ist (d.h. incident = 0).
### 2. update vorfallstatus
   - Ermöglicht das Aktualisieren des Status eines Vorfalls anhand seiner ID, um ihn als "erledigt" zu kennzeichnen.
### 3. escalation
   - Sendet Nachrichten an die jeweils zuständigen Personen, basierend auf dem Schweregrad des Vorfalls.


## Version 1.0.0.0

## Systemvoraussetzungen

- Betriebssystem: Windows, Linux oder macOS
- .NET-Runtime: .NET Core 3.0 oder höher

## Docker-Setup

Stellen Sie sicher, dass Docker auf Ihrem System installiert ist. Sowohl das Programm als auch der dazugehörige Datenbankserver laufen in einem Docker-Container, der sich im Docker-Netzwerk befindet.
DOCKER NETWORK USW.

### Dockerfile


### docker-compose.yml


## Roadmap
Phase 1: Grundlegende Struktur und Benutzerverwaltung (2 Monate)
- Implementierung von Benutzerverwaltungsfunktionen: "insert user", "select user", "select all user" und "update user".

Phase 2: Incident-Management-Funktionen (3 Monate)
- Entwicklung des Incident Management Systems mit Funktionen wie "select unsolved incidents", "update vorfallstatus" und "escalation".

Phase 3: Sicherheitsmaßnahmen und Feinabstimmung (2 Monate)
- Integration von Sicherheitsmaßnahmen, Benachrichtigungssystem und umfassende Tests zur Sicherstellung der Zuverlässigkeit.

Phase 4: Erweiterung und Skalierung (3 Monate)
- Implementierung zusätzlicher Funktionen basierend auf Benutzerfeedback, Skalierung des Systems und Leistungsoptimierung.


## ER-Diagramm
[ER-Diagramm](/ER-Diagramm.png)
![alt text](https://github.com/vpotok/ACDT_Project_SIMS/blob/master/ER-Diagramm.png?raw=true)

## Klassendiagramm
[Klassendiagramm](/uml_sims.png)
![alt text](https://github.com/vpotok/ACDT_Project_SIMS/blob/master/uml_sims.png?raw=true)

## Ergebnisse zu SAST (Semgrep)
Semgrep-Rulesets können potenzielle Sicherheitslücken in SQL-Anweisungen aufgrund fehlender Prepared Statements anzeigen, obwohl die tatsächliche Anfälligkeit für SQL-Injection nicht gegeben ist.
[SAST semgrep](/SAST_(semgrep))

## Lizenz
MIT License
Copyright (c) 2023 by Kristallgolem, vpotok, bakedstroh, ifarghali

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
