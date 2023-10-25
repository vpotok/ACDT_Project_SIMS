CREATE DATABASE Incidentmanagement;


CREATE TABLE benutzer (
	BenutzerId int NOT NULL Identity(1, 1) PRIMARY KEY,
	Vorname varchar(255) NOT NULL,
	Nachname varchar(255) NOT NULL,
	isAdmin bit NOT NULL,
	isActive bit NOT NULL
);
CREATE TABLE benutzer_log (
	BenutzerLogId int NOT NULL Identity(1, 1) PRIMARY KEY,
	ZeitStempel datetime NOT NULL,
	Nachricht varchar(255) NOT NULL,
	BenutzerId int FOREIGN KEY REFERENCES benutzer(BenutzerId)
);
CREATE TABLE vorfall (
	VorfallID int NOT NULL Identity(1, 1) PRIMARY KEY,
	SchwereGrad int NOT NULL,
	VorfallStatus bit NOT NULL,
	Zeitstempel datetime NOT NULL,
	Beschreibung varchar(255) NOT NULL,
	BenutzerId int FOREIGN KEY REFERENCES benutzer(BenutzerId)
);
CREATE TABLE vorfall_log (
	VorfallLogId int NOT NULL Identity(1, 1) PRIMARY KEY,
	ZeitStempel datetime NOT NULL,
	Nachricht varchar(255) NOT NULL,
	VorfallId int FOREIGN KEY REFERENCES vorfall(VorfallId)
);


INSERT INTO benutzer(Vorname, Nachname, isAdmin, isActive) VALUES ('Maxi', 'Luegger', 1, 1);
INSERT INTO benutzer(Vorname, Nachname, isAdmin, isActive) VALUES ('Ibo', 'Farghali', 1, 1);
INSERT INTO benutzer(Vorname, Nachname, isAdmin, isActive) VALUES ('Tori', 'Potok', 0, 1);
INSERT INTO benutzer(Vorname, Nachname, isAdmin, isActive) VALUES ('Fabi', 'Strohmeier', 1, 1);




CREATE TRIGGER benutzer_log_eintrag ON benutzer
AFTER INSERT, UPDATE, DELETE AS
BEGIN
	DECLARE @id int;
	SELECT @id = i.BenutzerId from inserted i;
	
	INSERT INTO benutzer_log (ZeitStempel, Nachricht, BenutzerId) VALUES (CURRENT_TIMESTAMP, 
		CASE WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED)
               		THEN 'UPDATE'
                     WHEN EXISTS(SELECT * FROM INSERTED)
                        THEN 'INSERT' 
                     WHEN EXISTS(SELECT * FROM DELETED)
                        THEN 'DELETED' 
                     ELSE NULL 
         	END, 
		@id);
END



CREATE TRIGGER vorfall_log_eintrag ON vorfall
AFTER INSERT, UPDATE, DELETE AS
BEGIN
    DECLARE @id int;
    SELECT @id = i.VorfallId from inserted i;
    DECLARE @nachricht varchar(255);
    SELECT @nachricht = i.Beschreibung from inserted i;

    INSERT INTO vorfall_log (ZeitStempel, Nachricht, VorfallId) VALUES (CURRENT_TIMESTAMP, 
        CASE WHEN EXISTS(SELECT * FROM INSERTED) AND EXISTS(SELECT * FROM DELETED)
                       THEN 'UPDATE' + ': ' + @nachricht
                     WHEN EXISTS(SELECT * FROM INSERTED)
                        THEN 'INSERT' + ': ' + @nachricht
                     WHEN EXISTS(SELECT * FROM DELETED)
                        THEN 'DELETED' + ': ' + @nachricht
                     ELSE NULL 
             END, 
        @id);
END

CREATE VIEW benutzer_log_view AS SELECT * from benutzer_log;
CREATE VIEW vorfall_log_view AS SELECT * from vorfall_log;