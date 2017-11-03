/*
  File:     goinsp.sql

  Summary:  Creates the GoInsp database.

  Date:     December 22, 2015
  Updated:  December 22, 2015
 */

 USE [master];
-- ********************
-- Drop Database
-- ********************
 IF EXISTS(SELECT [name]
           FROM [master].[sys].[databases]
           WHERE [name] = N'GoInsp')
   DROP DATABASE [GoInsp];

-- ********************
-- Create Database
-- ********************
 CREATE DATABASE [GoInsp];
 GO
 USE [GoInsp];

-- ********************
-- Create Tables
-- ********************
CREATE TABLE [Company] (
  [CompanyID]          INT IDENTITY (1, 1) NOT NULL,
  [CompanyName]        NVARCHAR(50)        NOT NULL,
  [CompanyEmail]       NVARCHAR(255)       NOT NULL,
  [CompanyPhone]       NVARCHAR(30)        NULL,
  [CompanyAddress]     NVARCHAR(50)        NULL,
  [CompanyCity]        NVARCHAR(50)        NULL,
  [CompanyZip]         NVARCHAR(30)        NULL,
  [CompanyDefaultFlag] BIT DEFAULT 0
);
GO

CREATE TABLE [Region] (
  [RegionID]   INT IDENTITY (1, 1) NOT NULL,
  [RegionCode] NVARCHAR(10)        NOT NULL,
  [RegionName] NVARCHAR(50)        NOT NULL
);
GO

CREATE TABLE [User] (
  [UserID]          INT IDENTITY (1, 1) NOT NULL,
  [UserCompanyID]   INT                 NULL,
  [UserRegionID]    INT                 NULL,
  [UserEmail]       NVARCHAR(255)       NOT NULL,
  [UserPassword]    NVARCHAR(255)       NOT NULL,
  [UserFirstName]   NVARCHAR(50)        NOT NULL,
  [UserLastName]    NVARCHAR(50)        NOT NULL,
  [UserDefaultFlag] BIT DEFAULT 0
);
GO

CREATE TABLE [Role] (
  [RoleID]          INT IDENTITY (1, 1) NOT NULL,
  [RoleName]        NVARCHAR(30)        NOT NULL,
  [RoleDescription] TEXT                NULL,
  [RoleDefaultFlag] BIT DEFAULT 0
);
GO

CREATE TABLE [UserRole] (
  [UserRoleID] INT IDENTITY (1, 1) NOT NULL,
  [UserID]     INT                 NOT NULL,
  [RoleID]     INT                 NOT NULL
);
GO

CREATE TABLE [Node] (
  [NodeID]          INT IDENTITY (1, 1) NOT NULL,
  [NodeName]        NVARCHAR(255)       NOT NULL,
  [NodeDefaultFlag] BIT DEFAULT 0
);
GO

CREATE TABLE [RoleNode] (
  [RoleNodeID] INT IDENTITY (1, 1) NOT NULL,
  [RoleID]     INT                 NOT NULL,
  [NodeID]     INT                 NOT NULL
);
GO

CREATE TABLE [Template] (
  [TemplateID]          INT IDENTITY (1, 1) NOT NULL,
  [TemplateUserID]      INT                 NULL,
  [TemplateName]        NVARCHAR(50)        NOT NULL,
  [TemplateDescription] TEXT                NULL,
  [TemplateDefaultFlag] BIT DEFAULT 0,
);
GO

CREATE TABLE [QuestionType] (
  [QuestionTypeID]   INT IDENTITY (1, 1) NOT NULL,
  [QuestionTypeName] NVARCHAR(30)        NOT NULL
);
GO

CREATE TABLE [Question] (
  [QuestionID]          INT IDENTITY (1, 1) NOT NULL,
  [QuestionTypeID]      INT                 NOT NULL,
  [QuestionTemplateID]  INT                 NOT NULL,
  [QuestionTitle]       TEXT                NOT NULL,
  [QuestionDescription] TEXT                NULL
);
GO

CREATE TABLE [Answer] (
  [AnswerID]          INT IDENTITY (1, 1) NOT NULL,
  [AnswerQuestionID]  INT                 NOT NULL,
  [AnswerTitle]       TEXT                NOT NULL,
  [AnswerDescription] TEXT                NULL
);
GO

CREATE TABLE [InspectionType] (
  [InspectionTypeID]   INT IDENTITY (1, 1) NOT NULL,
  [InspectionTypeName] NVARCHAR(50)        NOT NULL
);
GO

CREATE TABLE [Inspection] (
  [InspectionID]          UNIQUEIDENTIFIER NOT NULL,
  [InspectionTypeID]      INT              NOT NULL,
  [InspectionUserID]      INT              NULL,
  [InspectionCompanyID]   INT              NULL,
  [InspectionState]       NCHAR            NOT NULL DEFAULT 'P',
  [InspectionRegion]      NVARCHAR(50)     NOT NULL,
  [InspectionTitle]       TEXT             NOT NULL,
  [InspectionDescription] TEXT             NULL,
  [InspectionStartTime]   DATETIME         NULL,
  [InspectionEndTime]     DATETIME         NULL
);
GO

CREATE TABLE [QuestionInstance] (
  [QuestionInstanceID]           UNIQUEIDENTIFIER NOT NULL,
  [QuestionInstanceType]         NVARCHAR(30)     NOT NULL,
  [QuestionInstanceInspectionID] UNIQUEIDENTIFIER NOT NULL,
  [QuestionInstanceTitle]        TEXT             NOT NULL,
  [QuestionInstanceDescription]  TEXT             NULL,
  [QuestionInstanceValue]        TEXT             NULL,
  [QuestionInstanceComment]      TEXT             NULL
);
GO

CREATE TABLE [AnswerInstance] (
  [AnswerInstanceID]                 UNIQUEIDENTIFIER NOT NULL,
  [AnswerInstanceQuestionInstanceID] UNIQUEIDENTIFIER NOT NULL,
  [AnswerInstanceTitle]              TEXT             NOT NULL,
  [AnswerInstanceDescription]        TEXT             NULL
);
GO

CREATE TABLE [Location] (
  [LocationID]           UNIQUEIDENTIFIER NOT NULL,
  [LocationInspectionID] UNIQUEIDENTIFIER NOT NULL,
  [LocationTitle]        TEXT             NOT NULL,
  [LocationDescription]  TEXT             NULL,
  [LocationLat]          FLOAT            NOT NULL,
  [LocationLong]         FLOAT            NOT NULL,
);
GO

CREATE TABLE [File] (
  [FileID]           UNIQUEIDENTIFIER NOT NULL,
  [FileInspectionID] UNIQUEIDENTIFIER NOT NULL,
  [FileFileName]     NVARCHAR(255)    NOT NULL
);
GO

CREATE TABLE [Afval] (
  [AfvalID]                          INT IDENTITY (1, 1) NOT NULL,
  [AfvalRegioS]                      NVARCHAR(10)        NOT NULL,
  [AfvalPerioden]                    NVARCHAR(50)        NOT NULL,
  [AfvalTotaalHuishoudelijkAfval]    INT DEFAULT NULL,
  [AfvalHuishoudelijkRestafval]      INT DEFAULT NULL,
  [AfvalGrofHuishoudelijkRestafval]  INT DEFAULT NULL,
  [AfvalVerbouwingsrestafval]        INT DEFAULT NULL,
  [AfvalGFTAfval]                    INT DEFAULT NULL,
  [AfvalOudPapierEnKarton]           INT DEFAULT NULL,
  [AfvalVerpakkingsglas]             INT DEFAULT NULL,
  [AfvalTextiel]                     INT DEFAULT NULL,
  [AfvalKleinChemischAfvalKCA]       INT DEFAULT NULL,
  [AfvalMetalenVerpakkingenBlik]     INT DEFAULT NULL,
  [AfvalDrankenkartons]              INT DEFAULT NULL,
  [AfvalKunststofVerpakkingen]       INT DEFAULT NULL,
  [AfvalOverigeKunststoffen]         INT DEFAULT NULL,
  [AfvalLuiers]                      INT DEFAULT NULL,
  [AfvalWitEnBruingoed]              INT DEFAULT NULL,
  [AfvalGrofTuinafval]               INT DEFAULT NULL,
  [AfvalBruikbaarHuisraad]           INT DEFAULT NULL,
  [AfvalVloerbedekking]              INT DEFAULT NULL,
  [AfvalVlakglas]                    INT DEFAULT NULL,
  [AfvalMetalen]                     INT DEFAULT NULL,
  [AfvalHoutafvalAEnBHout]           INT DEFAULT NULL,
  [AfvalHoutafvalCHout]              INT DEFAULT NULL,
  [AfvalSchoonPuin]                  INT DEFAULT NULL,
  [AfvalBitumenhoudendeDakbedekking] INT DEFAULT NULL,
  [AfvalAsbesthoudendAfval]          INT DEFAULT NULL,
  [AfvalAutobanden]                  INT DEFAULT NULL,
  [AfvalSchoneGrond]                 INT DEFAULT NULL,
  [AfvalOverigeAfvalstoffen]         INT DEFAULT NULL,
  [AfvalGemeentecode]                INT DEFAULT NULL,
  [AfvalProvincie]                   NVARCHAR(50)        NOT NULL,
  [AfvalStedelijkheid]               NVARCHAR(50)        NOT NULL,
  [AfvalInwonersPer1Januari]         INT DEFAULT NULL
);
GO

-- ********************
-- Create Primary Keys
-- ********************
ALTER TABLE [Company] ADD CONSTRAINT [PK_Company] PRIMARY KEY ([CompanyID]);
GO

ALTER TABLE [Region] ADD CONSTRAINT [PK_Region] PRIMARY KEY ([RegionID]);
GO

ALTER TABLE [User] ADD CONSTRAINT [PK_User] PRIMARY KEY ([UserID]);
GO

ALTER TABLE [Role] ADD CONSTRAINT [PK_Role] PRIMARY KEY ([RoleID]);
GO

ALTER TABLE [UserRole] ADD CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserRoleID]);
GO

ALTER TABLE [Node] ADD CONSTRAINT [PK_Node] PRIMARY KEY ([NodeID]);
GO

ALTER TABLE [RoleNode] ADD CONSTRAINT [PK_RoleNode] PRIMARY KEY ([RoleNodeID]);
GO

ALTER TABLE [Template] ADD CONSTRAINT [PK_Template] PRIMARY KEY ([TemplateID]);
GO

ALTER TABLE [QuestionType] ADD CONSTRAINT [PK_QuestionType] PRIMARY KEY ([QuestionTypeID]);
GO

ALTER TABLE [Question] ADD CONSTRAINT [PK_Question] PRIMARY KEY ([QuestionID]);
GO

ALTER TABLE [Answer] ADD CONSTRAINT [PK_Answer] PRIMARY KEY ([AnswerID]);
GO

ALTER TABLE [InspectionType] ADD CONSTRAINT [PK_InspectionType] PRIMARY KEY ([InspectionTypeID]);
GO

ALTER TABLE [Inspection] ADD CONSTRAINT [PK_Inspection] PRIMARY KEY ([InspectionID]);
GO

ALTER TABLE [QuestionInstance] ADD CONSTRAINT [PK_QuestionInstance] PRIMARY KEY ([QuestionInstanceID]);
GO

ALTER TABLE [AnswerInstance] ADD CONSTRAINT [PK_AnswerInstance] PRIMARY KEY ([AnswerInstanceID]);
GO

ALTER TABLE [Location] ADD CONSTRAINT [PK_Location] PRIMARY KEY ([LocationID]);
GO

ALTER TABLE [File] ADD CONSTRAINT [PK_File] PRIMARY KEY ([FileID]);
GO

ALTER TABLE [Afval] ADD CONSTRAINT [PK_Afval] PRIMARY KEY ([AfvalID]);
GO

-- ********************
-- Create Indexes
-- ********************
ALTER TABLE [Company] ADD CONSTRAINT [AK_Company_CompanyEmail] UNIQUE ([CompanyEmail]);
GO

ALTER TABLE [Region] ADD CONSTRAINT [AK_Region_RegionName] UNIQUE ([RegionName]);
GO

ALTER TABLE [User] ADD CONSTRAINT [AK_User_UserEmail] UNIQUE ([UserEmail]);
GO

ALTER TABLE [Node] ADD CONSTRAINT [AK_Node_NodeName] UNIQUE ([NodeName]);
GO

ALTER TABLE [QuestionType] ADD CONSTRAINT [AK_QuestionType_QuestionTypeName] UNIQUE ([QuestionTypeName]);
GO

ALTER TABLE [InspectionType] ADD CONSTRAINT [AK_InspectionType_InspectionTypeName] UNIQUE ([InspectionTypeName]);
GO

-- ********************
-- Create Foreign Keys
-- ********************
ALTER TABLE [User] ADD CONSTRAINT [FK_User_Company] FOREIGN KEY ([UserCompanyID]) REFERENCES [Company] ([CompanyID]);
GO

ALTER TABLE [User] ADD CONSTRAINT [FK_User_Region] FOREIGN KEY ([UserRegionID]) REFERENCES [Region] ([RegionID]);
GO

ALTER TABLE [UserRole] ADD CONSTRAINT [FK_UserRole_User] FOREIGN KEY ([UserID]) REFERENCES [User] ([UserID]);
GO

ALTER TABLE [UserRole] ADD CONSTRAINT [FK_UserRole_Role] FOREIGN KEY ([RoleID]) REFERENCES [Role] ([RoleID]);
GO

ALTER TABLE [RoleNode] ADD CONSTRAINT [FK_RoleNode_Role] FOREIGN KEY ([RoleID]) REFERENCES [Role] ([RoleID]);
GO

ALTER TABLE [RoleNode] ADD CONSTRAINT [FK_RoleNode_Node] FOREIGN KEY ([NodeID]) REFERENCES [Node] ([NodeID]);
GO

ALTER TABLE [Template] ADD CONSTRAINT [FK_Template_User] FOREIGN KEY ([TemplateUserID]) REFERENCES [User] ([UserID]);
GO

ALTER TABLE [Question] ADD CONSTRAINT [FK_Question_QuestionType] FOREIGN KEY ([QuestionTypeID]) REFERENCES [QuestionType] ([QuestionTypeID]);
GO

ALTER TABLE [Question] ADD CONSTRAINT [FK_Question_Template] FOREIGN KEY ([QuestionTemplateID]) REFERENCES [Template] ([TemplateID]);
GO

ALTER TABLE [Answer] ADD CONSTRAINT [FK_Answer_Question] FOREIGN KEY ([AnswerQuestionID]) REFERENCES [Question] ([QuestionID]);
GO

ALTER TABLE [Inspection] ADD CONSTRAINT [FK_Inspection_InspectionType] FOREIGN KEY ([InspectionTypeID]) REFERENCES [InspectionType] ([InspectionTypeID]);
GO

ALTER TABLE [Inspection] ADD CONSTRAINT [FK_Inspection_User] FOREIGN KEY ([InspectionUserID]) REFERENCES [User] ([UserID]);
GO

ALTER TABLE [Inspection] ADD CONSTRAINT [FK_Inspection_Company] FOREIGN KEY ([InspectionCompanyID]) REFERENCES [Company] ([CompanyID]);
GO

ALTER TABLE [QuestionInstance] ADD CONSTRAINT [FK_QuestionInstance_Inspection] FOREIGN KEY ([QuestionInstanceInspectionID]) REFERENCES [Inspection] ([InspectionID]);
GO

ALTER TABLE [AnswerInstance] ADD CONSTRAINT [FK_AnswerInstance_QuestionInstance] FOREIGN KEY ([AnswerInstanceQuestionInstanceID]) REFERENCES [QuestionInstance] ([QuestionInstanceID]);
GO

ALTER TABLE [Location] ADD CONSTRAINT [FK_Location_Inspection] FOREIGN KEY ([LocationInspectionID]) REFERENCES [Inspection] ([InspectionID]);
GO

ALTER TABLE [File] ADD CONSTRAINT [FK_File_Inspection] FOREIGN KEY ([FileInspectionID]) REFERENCES [Inspection] ([InspectionID]);
GO

-- ********************
-- Insert Dummy Data
-- ********************
INSERT INTO [Company] ([CompanyName], [CompanyEmail], [CompanyPhone], [CompanyAddress], [CompanyCity], [CompanyZip], [CompanyDefaultFlag])
VALUES
  ('Bedrijf A', 'info@bedrijf-a.nl', '+01 234 567', 'Industrieweg 1', 'Dorpstad', '1234AB', 1),
  ('Bedrijf B', 'info@bedrijf-b.nl', '+02 234 567', 'Industrieweg 2', 'Dorpstad', '1234CD', 0),
  ('Bedrijf C', 'info@bedrijf-c.nl', '+03 234 567', 'Industrieweg 3', 'Dorpstad', '1234EF', 0);

INSERT INTO [Region] ([RegionCode], [RegionName])
VALUES
  ('GM1680', 'Aa en Hunze'),
  ('GM0738', 'Aalburg'),
  ('GM0358', 'Aalsmeer'),
  ('GM0197', 'Aalten'),
  ('GM0480', 'Ter Aar'),
  ('GM0305', 'Abcoude'),
  ('GM0059', 'Achtkarspelen'),
  ('GM0360', 'Akersloot'),
  ('GM0482', 'Alblasserdam'),
  ('GM0613', 'Albrandswaard'),
  ('GM0483', 'Alkemade'),
  ('GM0361', 'Alkmaar'),
  ('GM0141', 'Almelo'),
  ('GM0034', 'Almere'),
  ('GM0484', 'Alphen aan den Rijn'),
  ('GM1723', 'Alphen-Chaam'),
  ('GM1679', 'Ambt Montfort'),
  ('GM0060', 'Ameland'),
  ('GM0306', 'Amerongen'),
  ('GM0307', 'Amersfoort'),
  ('GM0362', 'Amstelveen'),
  ('GM0363', 'Amsterdam'),
  ('GM0364', 'Andijk'),
  ('GM0199', 'Angerlo'),
  ('GM0366', 'Anna Paulowna'),
  ('GM0200', 'Apeldoorn'),
  ('GM0003', 'Appingedam'),
  ('GM0885', 'Arcen en Velden'),
  ('GM0202', 'Arnhem'),
  ('GM0106', 'Assen'),
  ('GM0743', 'Asten'),
  ('GM0650', 'Axel'),
  ('GM0744', 'Baarle-Nassau'),
  ('GM0308', 'Baarn'),
  ('GM0489', 'Barendrecht'),
  ('GM0203', 'Barneveld'),
  ('GM0144', 'Bathmen'),
  ('GM0005', 'Bedum'),
  ('GM0888', 'Beek (L.)'),
  ('GM0370', 'Beemster'),
  ('GM0889', 'Beesel'),
  ('GM0007', 'Bellingwedde'),
  ('GM0206', 'Bemmel'),
  ('GM0372', 'Bennebroek'),
  ('GM0491', 'Bergambacht'),
  ('GM1724', 'Bergeijk'),
  ('GM0893', 'Bergen (L.)'),
  ('GM0373', 'Bergen (NH.)'),
  ('GM0748', 'Bergen op Zoom'),
  ('GM0207', 'Bergh'),
  ('GM0492', 'Bergschenhoek'),
  ('GM0493', 'Berkel en Rodenrijs'),
  ('GM1859', 'Berkelland'),
  ('GM1721', 'Bernheze'),
  ('GM0568', 'Bernisse'),
  ('GM0753', 'Best'),
  ('GM0209', 'Beuningen'),
  ('GM0375', 'Beverwijk'),
  ('GM0063', 'het Bildt'),
  ('GM0310', 'De Bilt'),
  ('GM0585', 'Binnenmaas'),
  ('GM1728', 'Bladel'),
  ('GM0376', 'Blaricum'),
  ('GM0495', 'Bleiswijk'),
  ('GM0377', 'Bloemendaal'),
  ('GM0055', 'Boarnsterhim'),
  ('GM0497', 'Bodegraven'),
  ('GM1901', 'Bodegraven-Reeuwijk'),
  ('GM0755', 'Boekel'),
  ('GM0009', 'Ten Boer'),
  ('GM0064', 'Bolsward'),
  ('GM0211', 'Borculo'),
  ('GM1681', 'Borger-Odoorn'),
  ('GM0147', 'Borne'),
  ('GM0654', 'Borsele'),
  ('GM0499', 'Boskoop'),
  ('GM0756', 'Boxmeer'),
  ('GM0757', 'Boxtel'),
  ('GM0758', 'Breda'),
  ('GM0311', 'Breukelen'),
  ('GM0501', 'Brielle'),
  ('GM1876', 'Bronckhorst'),
  ('GM0213', 'Brummen'),
  ('GM0899', 'Brunssum'),
  ('GM0312', 'Bunnik'),
  ('GM0313', 'Bunschoten'),
  ('GM0214', 'Buren'),
  ('GM0381', 'Bussum'),
  ('GM0502', 'Capelle aan den IJssel'),
  ('GM0383', 'Castricum'),
  ('GM0109', 'Coevorden'),
  ('GM1706', 'Cranendonck'),
  ('GM0611', 'Cromstrijen'),
  ('GM1684', 'Cuijk'),
  ('GM0216', 'Culemborg'),
  ('GM0148', 'Dalfsen'),
  ('GM0065', 'Dantumadeel'),
  ('GM1891', 'Dantumadiel'),
  ('GM0503', 'Delft'),
  ('GM0010', 'Delfzijl'),
  ('GM0149', 'Denekamp'),
  ('GM0762', 'Deurne'),
  ('GM0150', 'Deventer'),
  ('GM0218', 'Didam'),
  ('GM0384', 'Diemen'),
  ('GM1774', 'Dinkelland'),
  ('GM0219', 'Dinxperlo'),
  ('GM0504', 'Dirksland'),
  ('GM0220', 'Dodewaard'),
  ('GM0221', 'Doesburg'),
  ('GM0222', 'Doetinchem'),
  ('GM0766', 'Dongen'),
  ('GM0058', 'Dongeradeel'),
  ('GM0315', 'Doorn'),
  ('GM0505', 'Dordrecht'),
  ('GM0498', 'Drechterland'),
  ('GM0316', 'Driebergen-Rijsenburg'),
  ('GM1719', 'Drimmelen'),
  ('GM0303', 'Dronten'),
  ('GM0225', 'Druten'),
  ('GM0226', 'Duiven'),
  ('GM0902', 'Echt'),
  ('GM0227', 'Echteld'),
  ('GM1711', 'Echt-Susteren'),
  ('GM0385', 'Edam-Volendam'),
  ('GM0228', 'Ede'),
  ('GM0317', 'Eemnes'),
  ('GM1651', 'Eemsmond'),
  ('GM0770', 'Eersel'),
  ('GM0229', 'Eibergen'),
  ('GM0905', 'Eijsden'),
  ('GM1903', 'Eijsden-Margraten'),
  ('GM0772', 'Eindhoven'),
  ('GM0230', 'Elburg'),
  ('GM0114', 'Emmen'),
  ('GM0388', 'Enkhuizen'),
  ('GM0153', 'Enschede'),
  ('GM0232', 'Epe'),
  ('GM0233', 'Ermelo'),
  ('GM0777', 'Etten-Leur'),
  ('GM1722', 'Ferwerderadiel'),
  ('GM0070', 'Franekeradeel'),
  ('GM1921', 'De Friese Meren'),
  ('GM0653', 'Gaasterl\u00e2n-Sleat'),
  ('GM0779', 'Geertruidenberg'),
  ('GM0236', 'Geldermalsen'),
  ('GM0781', 'Geldrop'),
  ('GM1771', 'Geldrop-Mierlo'),
  ('GM1652', 'Gemert-Bakel'),
  ('GM0237', 'Gendringen'),
  ('GM0907', 'Gennep'),
  ('GM0689', 'Giessenlanden'),
  ('GM0784', 'Gilze en Rijen'),
  ('GM0511', 'Goedereede'),
  ('GM1924', 'Goeree-Overflakkee'),
  ('GM0664', 'Goes'),
  ('GM0785', 'Goirle'),
  ('GM0512', 'Gorinchem'),
  ('GM0239', 'Gorssel'),
  ('GM0513', 'Gouda'),
  ('GM0693', 'Graafstroom'),
  ('GM0365', 'Graft-De Rijp'),
  ('GM0786', 'Grave'),
  ('GM0390', '''s-Graveland'),
  ('GM0517', '''s-Gravendeel'),
  ('GM0518', '''s-Gravenhage (gemeente)'),
  ('GM0519', '''s-Gravenzande'),
  ('GM0240', 'Groenlo'),
  ('GM0241', 'Groesbeek'),
  ('GM0014', 'Groningen (gemeente)'),
  ('GM0015', 'Grootegast'),
  ('GM1729', 'Gulpen-Wittem'),
  ('GM0158', 'Haaksbergen'),
  ('GM0788', 'Haaren'),
  ('GM0392', 'Haarlem'),
  ('GM0393', 'Haarlemmerliede en Spaarnwoude'),
  ('GM0394', 'Haarlemmermeer'),
  ('GM0914', 'Haelen'),
  ('GM1655', 'Halderberge'),
  ('GM0160', 'Hardenberg'),
  ('GM0243', 'Harderwijk'),
  ('GM0523', 'Hardinxveld-Giessendam'),
  ('GM0017', 'Haren'),
  ('GM0395', 'Harenkarspel'),
  ('GM0072', 'Harlingen'),
  ('GM0244', 'Hattem'),
  ('GM1937', 'Heel'),
  ('GM0396', 'Heemskerk'),
  ('GM0397', 'Heemstede'),
  ('GM0246', 'Heerde'),
  ('GM0074', 'Heerenveen'),
  ('GM0398', 'Heerhugowaard'),
  ('GM0526', 'Heerjansdam'),
  ('GM0917', 'Heerlen'),
  ('GM1658', 'Heeze-Leende'),
  ('GM0399', 'Heiloo'),
  ('GM0918', 'Helden'),
  ('GM0400', 'Den Helder'),
  ('GM0163', 'Hellendoorn'),
  ('GM0530', 'Hellevoetsluis'),
  ('GM0794', 'Helmond'),
  ('GM0531', 'Hendrik-Ido-Ambacht'),
  ('GM0248', 'Hengelo (Gld.)'),
  ('GM0164', 'Hengelo (O.)'),
  ('GM0796', '''s-Hertogenbosch'),
  ('GM0252', 'Heumen'),
  ('GM0797', 'Heusden'),
  ('GM0920', 'Heythuysen'),
  ('GM0534', 'Hillegom'),
  ('GM0798', 'Hilvarenbeek'),
  ('GM0402', 'Hilversum'),
  ('GM1735', 'Hof van Twente'),
  ('GM1911', 'Hollands Kroon'),
  ('GM0675', 'Hontenisse'),
  ('GM0118', 'Hoogeveen'),
  ('GM0018', 'Hoogezand-Sappemeer'),
  ('GM0405', 'Hoorn'),
  ('GM1507', 'Horst aan de Maas'),
  ('GM0321', 'Houten'),
  ('GM0406', 'Huizen'),
  ('GM0677', 'Hulst'),
  ('GM0256', 'Hummelo en Keppel'),
  ('GM0925', 'Hunsel'),
  ('GM0353', 'IJsselstein'),
  ('GM0645', 'Jacobswoude'),
  ('GM1884', 'Kaag en Braassem'),
  ('GM0166', 'Kampen'),
  ('GM0678', 'Kapelle'),
  ('GM0537', 'Katwijk'),
  ('GM0928', 'Kerkrade'),
  ('GM0929', 'Kessel'),
  ('GM0258', 'Kesteren'),
  ('GM1598', 'Koggenland'),
  ('GM0079', 'Kollumerland en Nieuwkruisland'),
  ('GM0588', 'Korendijk'),
  ('GM0542', 'Krimpen aan den IJssel'),
  ('GM1659', 'Laarbeek'),
  ('GM1685', 'Landerd'),
  ('GM0882', 'Landgraaf'),
  ('GM0415', 'Landsmeer'),
  ('GM0416', 'Langedijk'),
  ('GM1621', 'Lansingerland'),
  ('GM0417', 'Laren (NH.)'),
  ('GM0022', 'Leek'),
  ('GM0545', 'Leerdam'),
  ('GM0326', 'Leersum'),
  ('GM0080', 'Leeuwarden'),
  ('GM0081', 'Leeuwarderadeel'),
  ('GM0546', 'Leiden'),
  ('GM0547', 'Leiderdorp'),
  ('GM0548', 'Leidschendam'),
  ('GM1916', 'Leidschendam-Voorburg'),
  ('GM0995', 'Lelystad'),
  ('GM0082', 'Lemsterland'),
  ('GM1640', 'Leudal'),
  ('GM0327', 'Leusden'),
  ('GM0260', 'Lichtenvoorde'),
  ('GM1673', 'Liemeer'),
  ('GM0552', 'De Lier'),
  ('GM0694', 'Liesveld'),
  ('GM0418', 'Limmen'),
  ('GM0733', 'Lingewaal'),
  ('GM1705', 'Lingewaard'),
  ('GM0553', 'Lisse'),
  ('GM0808', 'Lith'),
  ('GM0140', 'Littenseradiel'),
  ('GM0262', 'Lochem'),
  ('GM0329', 'Loenen'),
  ('GM0809', 'Loon op Zand'),
  ('GM0330', 'Loosdrecht'),
  ('GM0331', 'Lopik'),
  ('GM0024', 'Loppersum'),
  ('GM0168', 'Losser'),
  ('GM0332', 'Maarn'),
  ('GM0333', 'Maarssen'),
  ('GM0933', 'Maasbracht'),
  ('GM0934', 'Maasbree'),
  ('GM1671', 'Maasdonk'),
  ('GM0263', 'Maasdriel'),
  ('GM1641', 'Maasgouw'),
  ('GM0555', 'Maasland'),
  ('GM0556', 'Maassluis'),
  ('GM0935', 'Maastricht'),
  ('GM0936', 'Margraten'),
  ('GM1663', 'De Marne'),
  ('GM0025', 'Marum'),
  ('GM0420', 'Medemblik'),
  ('GM0993', 'Meerlo-Wanssum'),
  ('GM0938', 'Meerssen'),
  ('GM0941', 'Meijel'),
  ('GM0083', 'Menaldumadeel'),
  ('GM1908', 'Menameradiel'),
  ('GM1987', 'Menterwolde'),
  ('GM0119', 'Meppel'),
  ('GM0687', 'Middelburg (Z.)'),
  ('GM0559', 'Middelharnis'),
  ('GM1842', 'Midden-Delfland'),
  ('GM1731', 'Midden-Drenthe'),
  ('GM0814', 'Mierlo'),
  ('GM0815', 'Mill en Sint Hubert'),
  ('GM0265', 'Millingen aan de Rijn'),
  ('GM1709', 'Moerdijk'),
  ('GM1927', 'Molenwaard'),
  ('GM0562', 'Monster'),
  ('GM1955', 'Montferland'),
  ('GM0335', 'Montfoort'),
  ('GM0944', 'Mook en Middelaar'),
  ('GM0563', 'Moordrecht'),
  ('GM0424', 'Muiden'),
  ('GM0565', 'Naaldwijk'),
  ('GM0425', 'Naarden'),
  ('GM1740', 'Neder-Betuwe'),
  ('GM0426', 'Nederhorst den Berg'),
  ('GM0643', 'Nederlek'),
  ('GM0946', 'Nederweert'),
  ('GM0266', 'Neede'),
  ('GM0304', 'Neerijnen'),
  ('GM0412', 'Niedorp'),
  ('GM0356', 'Nieuwegein'),
  ('GM0567', 'Nieuwerkerk aan den IJssel'),
  ('GM0569', 'Nieuwkoop'),
  ('GM0571', 'Nieuw-Lekkerland'),
  ('GM0104', 'Nijefurd'),
  ('GM0267', 'Nijkerk'),
  ('GM0268', 'Nijmegen'),
  ('GM1695', 'Noord-Beveland'),
  ('GM1699', 'Noordenveld'),
  ('GM0529', 'Noorder-Koggenland'),
  ('GM0171', 'Noordoostpolder'),
  ('GM0575', 'Noordwijk'),
  ('GM0576', 'Noordwijkerhout'),
  ('GM0577', 'Nootdorp'),
  ('GM0820', 'Nuenen, Gerwen en Nederwetten'),
  ('GM0302', 'Nunspeet'),
  ('GM0951', 'Nuth'),
  ('GM0429', 'Obdam'),
  ('GM0579', 'Oegstgeest'),
  ('GM0823', 'Oirschot'),
  ('GM0824', 'Oisterwijk'),
  ('GM1895', 'Oldambt'),
  ('GM0269', 'Oldebroek'),
  ('GM0173', 'Oldenzaal'),
  ('GM0174', 'Olst'),
  ('GM1773', 'Olst-Wijhe'),
  ('GM0175', 'Ommen'),
  ('GM0881', 'Onderbanken'),
  ('GM1586', 'Oost Gelre'),
  ('GM0692', 'Oostburg'),
  ('GM0826', 'Oosterhout'),
  ('GM0580', 'Oostflakkee'),
  ('GM0085', 'Ooststellingwerf'),
  ('GM0431', 'Oostzaan'),
  ('GM0432', 'Opmeer'),
  ('GM0086', 'Opsterland'),
  ('GM0828', 'Oss'),
  ('GM0584', 'Oud-Beijerland'),
  ('GM1509', 'Oude IJsselstreek'),
  ('GM0437', 'Ouder-Amstel'),
  ('GM0644', 'Ouderkerk'),
  ('GM0589', 'Oudewater'),
  ('GM1734', 'Overbetuwe'),
  ('GM0590', 'Papendrecht'),
  ('GM1894', 'Peel en Maas'),
  ('GM0765', 'Pekela'),
  ('GM0594', 'Pijnacker'),
  ('GM1926', 'Pijnacker-Nootdorp'),
  ('GM0439', 'Purmerend'),
  ('GM0273', 'Putten'),
  ('GM0177', 'Raalte'),
  ('GM0835', 'Ravenstein'),
  ('GM0595', 'Reeuwijk'),
  ('GM1661', 'Reiderland'),
  ('GM0703', 'Reimerswaal'),
  ('GM0274', 'Renkum'),
  ('GM0339', 'Renswoude'),
  ('GM1667', 'Reusel-De Mierden'),
  ('GM0275', 'Rheden'),
  ('GM0340', 'Rhenen'),
  ('GM0597', 'Ridderkerk'),
  ('GM0602', 'Rijnsburg'),
  ('GM0196', 'Rijnwaarden'),
  ('GM1672', 'Rijnwoude'),
  ('GM0178', 'Rijssen'),
  ('GM1742', 'Rijssen-Holten'),
  ('GM0603', 'Rijswijk (ZH.)'),
  ('GM1669', 'Roerdalen'),
  ('GM0957', 'Roermond'),
  ('GM1670', 'Roggel en Neer'),
  ('GM0736', 'De Ronde Venen'),
  ('GM1674', 'Roosendaal'),
  ('GM0599', 'Rotterdam'),
  ('GM0600', 'Rozenburg'),
  ('GM0277', 'Rozendaal'),
  ('GM0840', 'Rucphen'),
  ('GM0278', 'Ruurlo'),
  ('GM0704', 'Sas van Gent'),
  ('GM0604', 'Sassenheim'),
  ('GM0441', 'Schagen'),
  ('GM0039', 'Scheemda'),
  ('GM0458', 'Schermer'),
  ('GM0279', 'Scherpenzeel'),
  ('GM0606', 'Schiedam'),
  ('GM0088', 'Schiermonnikoog'),
  ('GM0844', 'Schijndel'),
  ('GM0962', 'Schinnen'),
  ('GM0607', 'Schipluiden'),
  ('GM0608', 'Schoonhoven'),
  ('GM1676', 'Schouwen-Duiveland'),
  ('GM0964', 'Sevenum'),
  ('GM0965', 'Simpelveld'),
  ('GM1702', 'Sint Anthonis'),
  ('GM0845', 'Sint-Michielsgestel'),
  ('GM0846', 'Sint-Oedenrode'),
  ('GM1883', 'Sittard-Geleen'),
  ('GM0051', 'Skarsterl\u00e2n'),
  ('GM0610', 'Sliedrecht'),
  ('GM0040', 'Slochteren'),
  ('GM1714', 'Sluis'),
  ('GM1698', 'Sluis-Aardenburg'),
  ('GM0090', 'Smallingerland'),
  ('GM0091', 'Sneek'),
  ('GM0342', 'Soest'),
  ('GM0847', 'Someren'),
  ('GM0848', 'Son en Breugel'),
  ('GM0612', 'Spijkenisse'),
  ('GM0037', 'Stadskanaal'),
  ('GM0180', 'Staphorst'),
  ('GM0532', 'Stede Broec'),
  ('GM0851', 'Steenbergen'),
  ('GM0280', 'Steenderen'),
  ('GM0181', 'Steenwijk'),
  ('GM1708', 'Steenwijkerland'),
  ('GM0971', 'Stein (L.)'),
  ('GM1904', 'Stichtse Vecht'),
  ('GM0617', 'Strijen'),
  ('GM1900', 'S\u00fadwest-Frysl\u00e2n'),
  ('GM0974', 'Susteren'),
  ('GM0975', 'Swalmen'),
  ('GM0715', 'Terneuzen'),
  ('GM0093', 'Terschelling'),
  ('GM0448', 'Texel'),
  ('GM1525', 'Teylingen'),
  ('GM0716', 'Tholen'),
  ('GM0977', 'Thorn'),
  ('GM0281', 'Tiel'),
  ('GM0855', 'Tilburg'),
  ('GM0183', 'Tubbergen'),
  ('GM1700', 'Twenterand'),
  ('GM1730', 'Tynaarlo'),
  ('GM0737', 'Tytsjerksteradiel'),
  ('GM0282', 'Ubbergen'),
  ('GM0856', 'Uden'),
  ('GM0450', 'Uitgeest'),
  ('GM0451', 'Uithoorn'),
  ('GM0184', 'Urk'),
  ('GM0344', 'Utrecht (gemeente)'),
  ('GM1581', 'Utrechtse Heuvelrug'),
  ('GM0981', 'Vaals'),
  ('GM0619', 'Valkenburg (ZH.)'),
  ('GM0994', 'Valkenburg aan de Geul'),
  ('GM0858', 'Valkenswaard'),
  ('GM0047', 'Veendam'),
  ('GM0345', 'Veenendaal'),
  ('GM0717', 'Veere'),
  ('GM0860', 'Veghel'),
  ('GM0861', 'Veldhoven'),
  ('GM0453', 'Velsen'),
  ('GM0454', 'Venhuizen'),
  ('GM0983', 'Venlo'),
  ('GM0984', 'Venray'),
  ('GM0620', 'Vianen'),
  ('GM0622', 'Vlaardingen'),
  ('GM0048', 'Vlagtwedde'),
  ('GM0096', 'Vlieland'),
  ('GM0718', 'Vlissingen'),
  ('GM0623', 'Vlist'),
  ('GM0986', 'Voerendaal'),
  ('GM0624', 'Voorburg'),
  ('GM0625', 'Voorhout'),
  ('GM0626', 'Voorschoten'),
  ('GM0285', 'Voorst'),
  ('GM0286', 'Vorden'),
  ('GM0186', 'Vriezenveen'),
  ('GM0865', 'Vught'),
  ('GM0866', 'Waalre'),
  ('GM0867', 'Waalwijk'),
  ('GM0627', 'Waddinxveen'),
  ('GM0289', 'Wageningen'),
  ('GM0628', 'Warmond'),
  ('GM0291', 'Warnsveld'),
  ('GM0629', 'Wassenaar'),
  ('GM0630', 'Wateringen'),
  ('GM0852', 'Waterland'),
  ('GM0988', 'Weert'),
  ('GM0457', 'Weesp'),
  ('GM0292', 'Wehl'),
  ('GM0870', 'Werkendam'),
  ('GM0459', 'Wervershoof'),
  ('GM0668', 'West Maas en Waal'),
  ('GM0558', 'Wester-Koggenland'),
  ('GM1701', 'Westerveld'),
  ('GM0293', 'Westervoort'),
  ('GM1783', 'Westland'),
  ('GM0098', 'Weststellingwerf'),
  ('GM0614', 'Westvoorne'),
  ('GM0189', 'Wierden'),
  ('GM0462', 'Wieringen'),
  ('GM0463', 'Wieringermeer'),
  ('GM0296', 'Wijchen'),
  ('GM1696', 'Wijdemeren'),
  ('GM0352', 'Wijk bij Duurstede'),
  ('GM0052', 'Winschoten'),
  ('GM0053', 'Winsum'),
  ('GM0294', 'Winterswijk'),
  ('GM0295', 'Wisch'),
  ('GM0873', 'Woensdrecht'),
  ('GM0632', 'Woerden'),
  ('GM0466', 'Wognum'),
  ('GM1690', 'De Wolden'),
  ('GM0880', 'Wormerland'),
  ('GM0351', 'Woudenberg'),
  ('GM0874', 'Woudrichem'),
  ('GM0710', 'W\u00fbnseradiel'),
  ('GM0683', 'Wymbritseradiel'),
  ('GM0479', 'Zaanstad'),
  ('GM0297', 'Zaltbommel'),
  ('GM0473', 'Zandvoort'),
  ('GM0707', 'Zederik'),
  ('GM0478', 'Zeevang'),
  ('GM0050', 'Zeewolde'),
  ('GM0355', 'Zeist'),
  ('GM0298', 'Zelhem'),
  ('GM0299', 'Zevenaar'),
  ('GM1666', 'Zevenhuizen-Moerkapelle'),
  ('GM0476', 'Zijpe'),
  ('GM0637', 'Zoetermeer'),
  ('GM0638', 'Zoeterwoude'),
  ('GM0056', 'Zuidhorn'),
  ('GM1892', 'Zuidplas'),
  ('GM0879', 'Zundert'),
  ('GM0301', 'Zutphen'),
  ('GM1896', 'Zwartewaterland'),
  ('GM0642', 'Zwijndrecht'),
  ('GM0193', 'Zwolle');

INSERT INTO [User] ([UserRegionID], [UserCompanyID], [UserEmail], [UserPassword], [UserFirstName], [UserLastName], [UserDefaultFlag])
VALUES
  (1, 1, 'jan@bedrijf-a.nl', 'test', 'Jan', 'Janssen', 1),
  (2, 1, 'piet@bedrijf-a.nl', 'test', 'Piet', 'Pieters', 0),
  (3, 1, 'klaas@bedrijf-a.nl', 'test', 'Klaas', 'Klaassen', 0);

INSERT INTO [Role] ([RoleName], [RoleDescription], [RoleDefaultFlag])
VALUES
  ('Beheer', 'Rol voor systeembeheerder(s)', 1),
  ('Manager', 'Rol voor manager(s)', 1),
  ('Inspecteur', 'Rol voor inspecteur(s)', 1);

INSERT INTO [UserRole] ([UserID], [RoleID])
VALUES
  (1, 1),
  (2, 2),
  (3, 3);

INSERT INTO [Node] ([NodeName], [NodeDefaultFlag])
VALUES
  ('*', 1);

INSERT INTO [Node] ([NodeName])
VALUES
  ('Company.*'), ('Company.Select'), ('Company.Insert'), ('Company.Update'), ('Company.Delete'),
  ('User.*'), ('User.Select'), ('User.Insert'), ('User.Update'), ('User.Delete'),
  ('Role.*'), ('Role.Select'), ('Role.Insert'), ('Role.Update'), ('Role.Delete'),
  ('Node.*'), ('Node.Select'), ('Node.Insert'), ('Node.Update'), ('Node.Delete'),
  ('Template.*'), ('Template.Select'), ('Template.Insert'), ('Template.Update'), ('Template.Delete'),
  ('Question.*'), ('Question.Select'), ('Question.Insert'), ('Question.Update'), ('Question.Delete'),
  ('Answer.*'), ('Answer.Select'), ('Answer.Insert'), ('Answer.Update'), ('Answer.Delete'),
  ('Location.*'), ('Location.Select'), ('Location.Insert'), ('Location.Update'), ('Location.Delete'),
  ('File.*'), ('File.Select'), ('File.Insert'), ('File.Update'), ('File.Delete');

INSERT INTO [RoleNode] ([RoleID], [NodeID])
VALUES
  (1, 1),
  (2, 2), (2, 7), (2, 22), (2, 27), (2, 32), (2, 37), (2, 42),
  (3, 22), (3, 27), (3, 32), (3, 37), (3, 42);

INSERT INTO [Template] ([TemplateUserID], [TemplateName], [TemplateDescription], [TemplateDefaultFlag])
VALUES
  (1, 'Vragenlijst A', 'Standaard vragenlijst A', 1),
  (1, 'Vragenlijst B', 'Standaard vragenlijst B', 0),
  (1, 'Vragenlijst C', 'Standaard vragenlijst C', 0);

INSERT INTO [QuestionType] ([QuestionTypeName])
VALUES
  ('Open'),
  ('Gesloten');

INSERT INTO [Question] ([QuestionTypeID], [QuestionTemplateID], [QuestionTitle], [QuestionDescription])
VALUES
  (1, 1, 'Vraag A', NULL),
  (1, 1, 'Vraag B', NULL),
  (2, 1, 'Vraag C', 'Selecteer een antwoord'),
  (1, 2, 'Vraag A', NULL),
  (1, 2, 'Vraag B', NULL),
  (2, 2, 'Vraag C', 'Selecteer een antwoord'),
  (1, 3, 'Vraag A', NULL),
  (1, 3, 'Vraag B', NULL),
  (2, 3, 'Vraag C', 'Selecteer een antwoord');

INSERT INTO [Answer] ([AnswerQuestionID], [AnswerTitle])
VALUES
  (3, 'Antwoord A'),
  (3, 'Antwoord B'),
  (3, 'Antwoord C'),
  (6, 'Antwoord A'),
  (6, 'Antwoord B'),
  (6, 'Antwoord C'),
  (9, 'Antwoord A'),
  (9, 'Antwoord B'),
  (9, 'Antwoord C');

INSERT INTO [InspectionType] ([InspectionTypeName])
VALUES
  ('Inspectietype A'),
  ('Inspectietype B'),
  ('Inspectietype C');

DECLARE @a UNIQUEIDENTIFIER, @b UNIQUEIDENTIFIER, @c UNIQUEIDENTIFIER;
SET @a = NEWID()
SET @b = NEWID()
SET @c = NEWID()

INSERT INTO [Inspection] ([InspectionID], [InspectionTypeID], [InspectionUserID], [InspectionCompanyID], [InspectionRegion], [InspectionTitle], [InspectionDescription], [InspectionStartTime], [InspectionEndTime])
VALUES
  (@a, 3, 1, 3, '''s-Hertogenbosch', 'Inspectie A', 'Inspectie A bij bedrijf C', '2015-01-01', '2015-02-02'),
  (@b, 3, 2, 3, '''s-Hertogenbosch', 'Inspectie B', 'Inspectie B bij bedrijf C', '2015-02-02', '2015-03-03'),
  (@c, 3, 3, 3, '''s-Hertogenbosch', 'Inspectie C', 'Inspectie C bij bedrijf C', '2015-03-03', NULL);

INSERT INTO [Location] ([LocationID], [LocationInspectionID], [LocationTitle], [LocationLat], [LocationLong])
VALUES
  (NEWID(), @a, 'Locatie A', 51.697816, 5.303675),
  (NEWID(), @b, 'Locatie B', 51.697816, 5.303675),
  (NEWID(), @c, 'Locatie C', 51.697816, 5.303675);

INSERT INTO [File] ([FileID], [FileInspectionID], [FileFileName])
VALUES
  (NEWID(), @a, 'pic-a.jpg'),
  (NEWID(), @b, 'pic-b.jpg'),
  (NEWID(), @c, 'pic-c.jpg'),
  (NEWID(), @a, 'mov-a.mp4'),
  (NEWID(), @b, 'mov-b.mp4'),
  (NEWID(), @c, 'mov-c.mp4');