-- Opret en ZealandDB p� lokale computer, eller ogs� p� online - Microsoft-SQL

DROP TABLE IF EXISTS dbo.UddannelseOgL�rerAllokering;
DROP TABLE IF EXISTS dbo.UddannelseOgFagAllokering;
DROP TABLE IF EXISTS dbo.L�rerOgKompetenceAllokering;
DROP TABLE IF EXISTS dbo.L�rer;
DROP TABLE IF EXISTS dbo.Studieleder;
DROP TABLE IF EXISTS dbo.Uddannelse;
DROP TABLE IF EXISTS dbo.Akademi;
DROP TABLE IF EXISTS dbo.Kompetence;
DROP TABLE IF EXISTS dbo.Fag;
GO


-- Fag
CREATE TABLE dbo.Fag (
    FagID           INT           IDENTITY(1,1) PRIMARY KEY,
    FagNavn         NVARCHAR(100) NULL,
    FagBeskrivelse  NVARCHAR(250) NULL
);
GO

-- Akademi
CREATE TABLE dbo.Akademi (
    AkademiID           INT           IDENTITY(1,1) PRIMARY KEY,
    AkademiNavn         NVARCHAR(100) NULL,
    AkademiBeskrivelse  NVARCHAR(500) NULL,
    AkademiAdresse      NVARCHAR(200) NULL,
    AkademiLokation     NVARCHAR(100) NULL,
    AntalL�rere         INT           DEFAULT 0
);
GO

-- Uddannelse
CREATE TABLE dbo.Uddannelse (
    UddannelseID          INT           IDENTITY(1,1) PRIMARY KEY,
    UddannelseNavn        NVARCHAR(100) NULL,
    UddannelseBeskrivelse NVARCHAR(500) NULL,
    Semester              INT           NULL,
    Lokale                NVARCHAR(50)  NULL,
    Kalender              DATETIME      NULL,
    AkademiID             INT           NULL,
    CONSTRAINT FK_Uddannelse_Akademi
      FOREIGN KEY (AkademiID)
      REFERENCES dbo.Akademi(AkademiID)
      ON DELETE SET NULL
      ON UPDATE CASCADE
);
GO

-- Studieleder
CREATE TABLE dbo.Studieleder (
    StudielederID   INT           IDENTITY(1,1) PRIMARY KEY,
    Navn            NVARCHAR(100) NULL,
    Email           NVARCHAR(100) NOT NULL UNIQUE,
    Telefon         NVARCHAR(20)  NULL,
    Adgangskode     NVARCHAR(255) NULL,
    AkademiID       INT           NULL,
    CONSTRAINT FK_Studieleder_Akademi
      FOREIGN KEY (AkademiID)
      REFERENCES dbo.Akademi(AkademiID)
      ON DELETE SET NULL
      ON UPDATE CASCADE
);
GO

-- Kompetence
CREATE TABLE dbo.Kompetence (
    KompetenceID          INT           IDENTITY(1,1) PRIMARY KEY,
    KompetenceNavn        NVARCHAR(100) NULL,
    KompetenceBeskrivelse NVARCHAR(250) NULL,
    FagID                 INT           NULL,
    CONSTRAINT FK_Kompetence_Fag
      FOREIGN KEY (FagID)
      REFERENCES dbo.Fag(FagID)
      ON DELETE SET NULL
      ON UPDATE CASCADE
);
GO

-- L�rer
CREATE TABLE dbo.L�rer (
    L�rerID                   INT           IDENTITY(1,1) PRIMARY KEY,
    Navn                      NVARCHAR(100) NULL,
    Email                     NVARCHAR(100) NOT NULL UNIQUE,
    Telefonnummer             NVARCHAR(20)  NULL,
    Adgangskode               NVARCHAR(255) NULL,
    Ans�ttelsesform           NVARCHAR(50)  NULL,
    Timetal                   INT           DEFAULT 0,
    Status                    NVARCHAR(50)  DEFAULT 'Aktiv',
    Hjemmeplacering           NVARCHAR(100) NULL,
    Prim�rplacering           NVARCHAR(100) NULL,
    Sekundaereplaceringer     NVARCHAR(255) NULL,
    FagligeKvalifikationer    NVARCHAR(255) NULL,
    P�dagogiskeKvalifikationer NVARCHAR(255) NULL,
    SpecielleKvalifikationer  NVARCHAR(255) NULL,
    SemesterErfaring          NVARCHAR(255) NULL,
    Beviser                   NVARCHAR(255) NULL
);
GO

-- UddannelseOgFagAllokering
CREATE TABLE dbo.UddannelseOgFagAllokering (
    UOFAid              INT           IDENTITY(1,1) PRIMARY KEY,
    UOFAidBeskrivelse   NVARCHAR(250) NULL,
    UddannelseID        INT           NULL,
    FagID               INT           NULL,
    CONSTRAINT FK_UOFA_Uddannelse
      FOREIGN KEY (UddannelseID)
      REFERENCES dbo.Uddannelse(UddannelseID)
      ON DELETE CASCADE
      ON UPDATE CASCADE,
    CONSTRAINT FK_UOFA_Fag
      FOREIGN KEY (FagID)
      REFERENCES dbo.Fag(FagID)
      ON DELETE CASCADE
      ON UPDATE CASCADE
);
GO

-- L�rerOgKompetenceAllokering
CREATE TABLE dbo.L�rerOgKompetenceAllokering (
    LOKAid             INT           IDENTITY(1,1) PRIMARY KEY,
    LOKAidBeskrivelse  NVARCHAR(250) NULL,
    L�rerID            INT           NULL,
    KompetenceID       INT           NULL,
    CONSTRAINT FK_LOKA_L�rer
      FOREIGN KEY (L�rerID)
      REFERENCES dbo.L�rer(L�rerID)
      ON DELETE CASCADE
      ON UPDATE CASCADE,
    CONSTRAINT FK_LOKA_Kompetence
      FOREIGN KEY (KompetenceID)
      REFERENCES dbo.Kompetence(KompetenceID)
      ON DELETE CASCADE
      ON UPDATE CASCADE
);
GO

-- UddannelseOgL�rerAllokering
CREATE TABLE dbo.UddannelseOgL�rerAllokering (
    UOLAid             INT           IDENTITY(1,1) PRIMARY KEY,
    StartTid           DATETIME      NULL,
    SlutTid            DATETIME      NULL,
    UOLABeskrivelse    NVARCHAR(250) NULL,
    UddannelseID       INT           NULL,
    L�rerID            INT           NULL,
    CONSTRAINT FK_UOLA_Uddannelse
      FOREIGN KEY (UddannelseID)
      REFERENCES dbo.Uddannelse(UddannelseID)
      ON DELETE CASCADE
      ON UPDATE CASCADE,
    CONSTRAINT FK_UOLA_Laerer
      FOREIGN KEY (L�rerID)
      REFERENCES dbo.L�rer(L�rerID)
      ON DELETE CASCADE
      ON UPDATE CASCADE
);
GO


-- Akademi (6 rows)
INSERT INTO dbo.Akademi (AkademiNavn, AkademiBeskrivelse, AkademiAdresse, AkademiLokation, AntalL�rere)
VALUES
('Zealand K�ge', 'Jordbrugsteknolog og Finans�konom', 'Lyngvej 21, 4600 K�ge', 'K�ge', 3),
('Zealand Roskilde', 'Datamatiker og Multimediedesigner', 'Magleg�rdsvej 8, 4000 Roskilde', 'Roskilde', 3),
('Zealand N�stved', 'Finans�konom og Logistik�konom', 'Fem�vej 3, N�stved', 'N�stved', 3),
('Zealand Nyk�bing Falster', 'Laborant og IT-teknolog', 'Bispegade 5, Nyk�bing Falster', 'Nyk�bing Falster', 3),
('Zealand Slagelse', 'Bygningskonstrukt�r og Urban Landskabsingeni�r', 'Bredahlsgade 1A, Slagelse', 'Slagelse', 3),
('Zealand Holb�k', 'Procesteknolog og Produktionsteknolog', 'Anders Larsensvej 7-9, Holb�k', 'Holb�k', 3);

-- Fag (3 rows)
INSERT INTO dbo.Fag (FagNavn, FagBeskrivelse)
VALUES
('Databaser', 'Introduktion til databasedesign og SQL'),
('Programmering', 'Grundl�ggende programmering i C#'),
('Webudvikling', 'Udvikling af websites med HTML, CSS og JavaScript');

-- Uddannelse (3 rows)
INSERT INTO dbo.Uddannelse (UddannelseNavn, UddannelseBeskrivelse, Semester, Lokale, Kalender, AkademiID)
VALUES
('Datamatiker', 'Uddannelse i softwareudvikling', 1, 'Lokale 101', '2025-09-01', 2),
('Finans�konom', 'Uddannelse i finans og �konomi', 3, 'Lokale 205', '2025-09-01', 1),
('IT-teknolog', 'Uddannelse i IT og systemudvikling', 2, 'Lokale 301', '2025-09-01', 4);

-- Studieleder (3 rows)
INSERT INTO dbo.Studieleder (Navn, Email, Telefon, Adgangskode, AkademiID)
VALUES
('Mette Jensen', 'mette.jensen@zealand.dk', '12345678', 'hashedpassword1', 2),
('Lars Nielsen', 'lars.nielsen@zealand.dk', '87654321', 'hashedpassword2', 1),
('Anna S�rensen', 'anna.sorensen@zealand.dk', '11223344', 'hashedpassword3', 4);

-- Kompetence (3 rows)
INSERT INTO dbo.Kompetence (KompetenceNavn, KompetenceBeskrivelse, FagID)
VALUES
('SQL-ekspert', 'Ekspertise i SQL databasesp�rgsm�l', 1),
('C# programmering', 'St�rk i C# programmeringssprog', 2),
('Frontend webudvikling', 'F�rdigheder i HTML, CSS og JavaScript', 3);

-- L�rer (3 rows)
INSERT INTO dbo.L�rer (Navn, Email, Telefonnummer, Adgangskode, Ans�ttelsesform, Timetal, Status, Hjemmeplacering, Prim�rplacering, Sekundaereplaceringer, FagligeKvalifikationer, P�dagogiskeKvalifikationer, SpecielleKvalifikationer, SemesterErfaring, Beviser)
VALUES
('Peter Hansen', 'peter.hansen@zealand.dk', '23456789', 'hashedpw1', 'Fastansat', 30, 'Aktiv', 'K�ge', 'K�ge', 'Roskilde', 'C#, SQL', 'P�dagogikum', 'Ingen', '3', 'Diplom i softwareudvikling'),
('Sofie Larsen', 'sofie.larsen@zealand.dk', '98765432', 'hashedpw2', 'Deltid', 15, 'Aktiv', 'Roskilde', 'Roskilde', 'K�ge', 'HTML, CSS, JS', 'P�dagogikum', 'Specialundervisning', '2', 'Certifikat i webdesign'),
('Mikkel Mortensen', 'mikkel.mortensen@zealand.dk', '34567890', 'hashedpw3', 'Fastansat', 37, 'Aktiv', 'N�stved', 'N�stved', 'Slagelse', 'Finans, Regnskab', 'P�dagogikum', 'Ingen', '4', 'Master i finans');

-- UddannelseOgFagAllokering (3 rows)
INSERT INTO dbo.UddannelseOgFagAllokering (UOFAidBeskrivelse, UddannelseID, FagID)
VALUES
('Datamatiker obligatoriske fag', 1, 1),
('Finans�konom obligatoriske fag', 2, 3),
('IT-teknolog valgfrie fag', 3, 2);

-- L�rerOgKompetenceAllokering (3 rows)
INSERT INTO dbo.L�rerOgKompetenceAllokering (LOKAidBeskrivelse, L�rerID, KompetenceID)
VALUES
('Peter ekspert i SQL', 1, 1),
('Sofie ekspert i frontend', 2, 3),
('Mikkel ekspert i finans', 3, 2);

-- UddannelseOgL�rerAllokering (3 rows)
INSERT INTO dbo.UddannelseOgL�rerAllokering (StartTid, SlutTid, UOLABeskrivelse, UddannelseID, L�rerID)
VALUES
('2025-09-01', '2026-01-31', 'Peter underviser i Datamatiker', 1, 1),
('2025-09-01', '2026-01-31', 'Sofie underviser i Finans�konom', 2, 2),
('2025-09-01', '2026-01-31', 'Mikkel underviser i IT-teknolog', 3, 3);

