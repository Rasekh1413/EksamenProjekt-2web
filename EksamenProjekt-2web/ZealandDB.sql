
DROP TABLE IF EXISTS [dbo].[Akademi];
DROP TABLE IF EXISTS [dbo].[Lærere];
DROP TABLE IF EXISTS [dbo].[Uddannelse];
DROP TABLE IF EXISTS [dbo].[Studieleder];
DROP TABLE IF EXISTS [dbo].[Fag];
DROP TABLE IF EXISTS [dbo].[Kompetencer];
DROP TABLE IF EXISTS [dbo].[HukommelseRAM];

GO

-- 1. Akademi  
CREATE TABLE Akademi (
    AkademiID INT PRIMARY KEY IDENTITY(1,1),
    AkademiNavn NVARCHAR(100) NOT NULL,
    Beskrivelse NVARCHAR(500),
    AkademiAdresse NVARCHAR(200) NOT NULL,
    AkademiLokation NVARCHAR(100) NOT NULL,
    AntalLærere INT DEFAULT 0
);

-- 2. Lærere 
CREATE TABLE Lærere (
    LærerID INT PRIMARY KEY IDENTITY(1,1),
    Adgangskode NVARCHAR(255) NOT NULL,
    Navn NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Telefonnummer NVARCHAR(20),
    Ansættelsesform NVARCHAR(50) NOT NULL,
    Timetal INT DEFAULT 0,
    Status NVARCHAR(50) DEFAULT 'Aktiv',
    Hjemmeplacering NVARCHAR(100),
    Primærplacering NVARCHAR(100),
    AkademiID INT NOT NULL,
    FOREIGN KEY (AkademiID) REFERENCES Akademi(AkademiID)
);

-- 3. Uddannelse 
CREATE TABLE Uddannelse (
    UddannelseID INT PRIMARY KEY IDENTITY(1,1),
    UddannelseNavn NVARCHAR(100) NOT NULL,
    Beskrivelse NVARCHAR(500),
    Semester INT NOT NULL,
    Lokale NVARCHAR(50),
    Kalender DATETIME,
    AkademiID INT NOT NULL,
    FOREIGN KEY (AkademiID) REFERENCES Akademi(AkademiID)
);

-- 4. Studieleder 
CREATE TABLE Studieleder (
    StudielederID INT PRIMARY KEY IDENTITY(1,1),
    Navn NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Telefon NVARCHAR(20),
    Adgangskode NVARCHAR(255) NOT NULL,
    AkademiID INT NOT NULL,
    FOREIGN KEY (AkademiID) REFERENCES Akademi(AkademiID)
);

-- 5. Fag
CREATE TABLE Fag (
    FagID INT PRIMARY KEY IDENTITY(1,1),
    FagNavn NVARCHAR(100) NOT NULL,
    UddannelseID INT NOT NULL,
    FOREIGN KEY (UddannelseID) REFERENCES Uddannelse(UddannelseID)
);

-- 6. Kompetencer 
CREATE TABLE Kompetencer (
    KompetenceID INT PRIMARY KEY IDENTITY(1,1),
    KompetenceNavn NVARCHAR(100) NOT NULL,
    FagID INT NOT NULL,
    FOREIGN KEY (FagID) REFERENCES Fag(FagID)
);

-- 7. HukommelseRAM - Allokering 
CREATE TABLE HukommelseRAM (
    HukommelseRAMID INT PRIMARY KEY IDENTITY(1,1),
    Kalender DATETIME NOT NULL,
    AkademiID INT NOT NULL,
    UddannelseID INT NOT NULL,
    FagID INT NOT NULL,
    LærerID INT NOT NULL,
    KompetenceID INT NOT NULL,
    FOREIGN KEY (AkademiID) REFERENCES Akademi(AkademiID),
    FOREIGN KEY (UddannelseID) REFERENCES Uddannelse(UddannelseID),
    FOREIGN KEY (FagID) REFERENCES Fag(FagID),
    FOREIGN KEY (LærerID) REFERENCES Lærere(LærerID),
    FOREIGN KEY (KompetenceID) REFERENCES Kompetencer(KompetenceID)
);

-- Insert into Akademi
INSERT INTO Akademi (AkademiNavn, Beskrivelse, AkademiAdresse, AkademiLokation)
VALUES 
('Zealand Campus Køge', 'IT Education Hub', 'Lyngvej 21, 4600 Køge', 'Køge'),
('Zealand Campus Roskilde', 'Business Programs', 'Maglegårdsvej 8, 4000 Roskilde', 'Roskilde');

-- Insert into Lærere (Lynda and Maria)
INSERT INTO Lærere (Navn, Email, Adgangskode, Telefonnummer, Ansættelsesform, AkademiID)
VALUES 
('Lynda Jensen', 'lynda@zealand.dk', 'hashed_password_1', '+45 12345678', 'Full-time', 1),
('Maria Sørensen', 'maria@zealand.dk', 'hashed_password_2', '+45 87654321', 'Part-time', 1);

-- Insert into Uddannelse
INSERT INTO Uddannelse (UddannelseNavn, Beskrivelse, Semester, Lokale, AkademiID)
VALUES 
('Datamatiker', 'Software Development', 2, 'Room A1', 1),
('Webudvikling', 'Frontend & Backend', 2, 'Room B2', 1);

-- Insert into Studieleder (Per and Ivan)
INSERT INTO Studieleder (Navn, Email, Telefon, Adgangskode, AkademiID)
VALUES 
('Per Hansen', 'per@zealand.dk', '+45 11223344', 'hashed_password_3', 1),
('Ivan Nielsen', 'ivan@zealand.dk', '+45 44332211', 'hashed_password_4', 1);

-- Insert into Fag
INSERT INTO Fag (FagNavn, UddannelseID)
VALUES 
('Programming 1.2', 1),
('Database Design', 1);

-- Insert into Kompetencer
INSERT INTO Kompetencer (KompetenceNavn, FagID)
VALUES 
('C#', 1),
('SQL', 2);

-- Insert into HukommelseRAM - Allokering
INSERT INTO HukommelseRAM (Kalender, AkademiID, UddannelseID, FagID, LærerID, KompetenceID)
VALUES 
('2025-03-01 10:00:00', 1, 1, 1, 1, 1),
('2025-03-02 11:00:00', 1, 1, 2, 2, 2);