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

