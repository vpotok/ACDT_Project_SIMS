# Security Incident Management System
Unser Sicherheitsereignis-Verwaltungsprogramm ist ein leistungsstarkes Tool, das Ihnen hilft, sicherheitsrelevante Vorfälle effizient zu erfassen und zu verwalten. Es bietet eine Vielzahl von Funktionen, die Ihnen dabei helfen, den Überblick über Sicherheitsvorfälle zu behalten und angemessen darauf zu reagieren.

## Funktionen
1. Manuelle Erfassung von sicherheitsrelevanten Vorfällen: Erfassen Sie wichtige Informationen wie Schweregrad, Vorfallsstatus, Zeitstempel, Beschreibung und wer ihn gemeldet hat.
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

## Systemvoraussetzungen

- Betriebssystem: Windows, Linux oder macOS
- .NET-Runtime: .NET Core 3.0 oder höher

## Docker-Setup

Stellen Sie sicher, dass Docker auf Ihrem System installiert ist. Sowohl das Programm als auch der dazugehörige Datenbankserver laufen in einem Docker-Container, der sich im Docker-Netzwerk befindet.
DOCKER NETWORK USW.

## Version 1.2.3 TODO (muss der App-Version entsprechen) (fiktiver) - Roadmap

## ER-Diagramm

## Klassendiagramm

## Ergebnisse zu SAST (Semgrep)

## Lizenz
MIT License
Copyright (c) 2023 by Kristallgolem, vpotok, bakedstroh, ifarghali

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
