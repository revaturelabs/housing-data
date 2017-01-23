USE master;
GO

--create database
CREATE DATABASE HousingDB_Dev;
GO
USE HousingDB_Dev;
GO

--create schema
CREATE SCHEMA [Housing];
GO

CREATE SCHEMA [Associate];
GO

CREATE SCHEMA [Batch];
GO

CREATE SCHEMA [Gender];
GO

--create Housing schema tables
CREATE TABLE [Housing].[HousingUnit](
	[HousingUnitId] int IDENTITY(1,1) NOT NULL,
	[AptNumber] nvarchar(100) NOT NULL,
	[MaxCapacity] int NOT NULL,
	[GenderId] int NOT NULL,
	[HousingComplexId] int NOT NULL,
	[Active] bit NOT NULL,
	CONSTRAINT [PK_HousingUnit_HousingUnitId] PRIMARY KEY CLUSTERED ([HousingUnitId])
);
GO 

CREATE TABLE [Housing].[HousingComplex](
	[HousingComplexId] int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(200) NOT NULL,
	[Address] nvarchar(500) NOT NULL,
	[PhoneNumber] nvarchar(20) NOT NULL,
	[Active] bit NOT NULL,
	CONSTRAINT [PK_HousingComplex_HousingComplexId] PRIMARY KEY CLUSTERED ([HousingComplexId])
);
GO 

CREATE TABLE [Housing].[HousingData](
	[HousingDataId] int IDENTITY(1,1) NOT NULL,
	[AssociateId] int NOT NULL,
	[HousingUnitId] int NOT NULL, 
	[MoveInDate] date NOT NULL,
	[MoveOutDate] date NOT NULL,
	[Active] bit NOT NULL, 
	CONSTRAINT [PK_HousingData_HousingDataId] PRIMARY KEY CLUSTERED ([HousingDataId])
);
GO 

--create Associate schema tables
CREATE TABLE [Associate].[Associate](
	[AssociateId] int IDENTITY(1,1) NOT NULL,
	[FirstName] nvarchar(100) NOT NULL,
	[LastName] nvarchar(100) NOT NULL,
	[GenderId] int NOT NULL,
	[BatchId] int NOT NUll,
	[PhoneNumber] nvarchar(15) NOT NULL,
	[Email] nvarchar(100) NOT NULL,
	[DateOfBirth] date NOT NULL,
	[HasCar] bit NOT NULL,
	[HasKeys] bit NOT NULL,
	[Active] bit NOT NULL,
	CONSTRAINT [PK_Associate_AssociateId] PRIMARY KEY CLUSTERED ([AssociateId])
);
GO

--create Batch schema tables 
CREATE TABLE [Batch].[Batch](
	[BatchId] int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(100) NOT NULL,
	[Instructor] nvarchar(200) NOT NULL,
	[StartDate] date NOT NULL,
	[EndDate] date NOT NULL,
	[Active] bit NOT NULL,
	[Technology] nvarchar(100) NOT NULL,
 CONSTRAINT [PK__Batch__BatchId] PRIMARY KEY CLUSTERED ([BatchId])
);
GO

--create Gender schema tables
CREATE TABLE [Gender].[Gender](
	[GenderId] int IDENTITY(1,1) NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[Active] bit NOT NULL,
 CONSTRAINT [PK__Gender__GenderId] PRIMARY KEY CLUSTERED ([GenderId])
);
GO 

--create Housing schema foreign keys 
ALTER TABLE [Housing].[HousingUnit] ADD CONSTRAINT [FK_HousingUnit_HousingComplex] FOREIGN KEY([HousingComplexId])
REFERENCES [Housing].[HousingComplex] ([HousingComplexId]) ON UPDATE CASCADE;
GO

ALTER TABLE [Housing].[HousingUnit] ADD CONSTRAINT [FK_HousingUnit_Gender] FOREIGN KEY([GenderId])
REFERENCES [Gender].[Gender] ([GenderId]) ON UPDATE CASCADE;
GO

ALTER TABLE [Housing].[HousingData] ADD CONSTRAINT [FK_HousingData_HousingUnit] FOREIGN KEY([HousingUnitId])
REFERENCES [Housing].[HousingUnit] ([HousingUnitId]) ON UPDATE CASCADE;
GO

ALTER TABLE [Housing].[HousingData] ADD CONSTRAINT [FK_HousingData_Associate] FOREIGN KEY([AssociateId])
REFERENCES [Associate].[Associate] ([AssociateId]);
GO


--create Associate schema foreign keys 
ALTER TABLE [Associate].[Associate]  ADD CONSTRAINT [FK_Associate_Batch] FOREIGN KEY([BatchId])
REFERENCES [Batch].[Batch] ([BatchId]) ON UPDATE CASCADE;
GO

ALTER TABLE [Associate].[Associate]  ADD CONSTRAINT [FK_Associate_Gender] FOREIGN KEY([GenderId])
REFERENCES [Gender].[Gender] ([GenderId]) ON UPDATE CASCADE;
GO

--create unique indices 
CREATE UNIQUE NONCLUSTERED INDEX [IX_HousingComplex_Name_Address] ON [Housing].[HousingComplex]
([Name] ASC, [Address] ASC);
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Associate_Email] ON [Associate].[Associate] ([Email]);
GO

--create triggers for soft deletes 
CREATE TRIGGER [TR_HousingUnit_SoftDelete] ON [Housing].[HousingUnit] 
INSTEAD OF DELETE
AS
	DECLARE @unitId int;
	SELECT @unitId = d.[HousingUnitId] FROM deleted d;
BEGIN
	UPDATE [HousingUnit]
	SET [Active] = 0
	WHERE [HousingUnitId] = @unitId
END;
GO

CREATE TRIGGER [TR_HousingComplex_SoftDelete] ON [Housing].[HousingComplex] 
INSTEAD OF DELETE
AS
	DECLARE @complexId int;
	SELECT @complexId = d.[HousingComplexId] FROM deleted d;
BEGIN
	UPDATE [HousingComplex]
	SET [Active] = 0
	WHERE [HousingComplexId] = @complexId
END;
GO

CREATE TRIGGER [TR_HousingData_SoftDelete] ON [Housing].[HousingData] 
INSTEAD OF DELETE
AS
	DECLARE @dataId int;
	SELECT @dataId = d.[HousingDataId] FROM deleted d;
BEGIN
	UPDATE [HousingData]
	SET [Active] = 0
	WHERE [HousingDataId] = @dataId
END;
GO

CREATE TRIGGER [TR_Associate_SoftDelete] ON [Associate].[Associate] 
INSTEAD OF DELETE
AS
	DECLARE @assocId int;
	SELECT @assocId = d.[AssociateId] FROM deleted d;
BEGIN
	UPDATE [Associate]
	SET [Active] = 0
	WHERE [AssociateId] = @assocId
END;
GO

CREATE TRIGGER [TR_Batch_SoftDelete] ON [Batch].[Batch] 
INSTEAD OF DELETE
AS
	DECLARE @batchId int;
	SELECT @batchId = d.[BatchId] FROM deleted d;
BEGIN
	UPDATE [Batch]
	SET [Active] = 0
	WHERE [BatchId] = @batchId
END;
GO

CREATE TRIGGER [TR_Gender_SoftDelete] ON [Gender].[Gender] 
INSTEAD OF DELETE
AS
	DECLARE @genderId int;
	SELECT @genderId = d.[GenderId] FROM deleted d;
BEGIN
	UPDATE [Gender]
	SET [Active] = 0
	WHERE [GenderId] = @genderId
END;
GO

--create function to return all HousingUnits in a given HousingComplex
CREATE FUNCTION [HousingUnit_By_Complex]
	(@complexId int)
    RETURNS TABLE 
    AS
    RETURN 
    (SELECT * FROM [Housing].[HousingUnit] WHERE ([HousingComplexId] = @complexId));
GO

--create function to return all HousingData corresponding to a HousingUnit
CREATE FUNCTION [HousingData_By_Unit]
	(@unitId int)
    RETURNS TABLE 
    AS
    RETURN 
    (SELECT * FROM [Housing].[HousingData] WHERE ([HousingUnitId] = @unitId));
GO

--add test data
INSERT INTO [Batch].[Batch] VALUES ('1702-feb6-java','Instructor Alpha','20170206','20170421',1,'Java');
INSERT INTO [Batch].[Batch] VALUES ('1703-mar6-java','Instructor Beta','20170306','20170519',1,'Java');
INSERT INTO [Batch].[Batch] VALUES ('1702-feb6-net','Instructor Gamma','20170206','20170421',1,'.NET');

INSERT INTO [Gender].[Gender] VALUES ('male',1);
INSERT INTO [Gender].[Gender] VALUES ('female',1);
INSERT INTO [Gender].[Gender] VALUES ('not specified',1);

INSERT INTO [Associate].[Associate] VALUES ('Sigourney','Weaver',2,2,'555-555-5555','spacequeen@gmail.com','19800101',1,1,1);
INSERT INTO [Associate].[Associate] VALUES ('Kate','McKinnon',2,2,'555-555-5555','bustdemghosts@gmail.com','19800101',0,1,1);
INSERT INTO [Associate].[Associate] VALUES ('Anna','Torv',2,3,'555-555-5555','fringe@gmail.com','19800101',1,0,1);
INSERT INTO [Associate].[Associate] VALUES ('Ruby','Rose',2,3,'555-555-5555','tattooedaussie@gmail.com','19800101',0,0,1);
INSERT INTO [Associate].[Associate] VALUES ('Martha','Van Rensselaer',2,3,'555-555-5555','beforeitwascool@gmail.com','18600101',1,1,1);

INSERT INTO [Housing].[HousingComplex] VALUES ('Camden Dulles Station','3230 Dulles Station Blvd, Herndon, VA','555-555-5555',1);
INSERT INTO [Housing].[HousingComplex] VALUES ('Dulles Greene','Some Address in Herndon','555-555-5555',1);

INSERT INTO [Housing].[HousingUnit] VALUES ('1409',6,2,1,1);
INSERT INTO [Housing].[HousingUnit] VALUES ('1450',6,1,1,1);

INSERT INTO [Housing].[HousingData] VALUES (1,1,'20170303','20170524',1);
INSERT INTO [Housing].[HousingData] VALUES (2,1,'20170303','20170526',1);
INSERT INTO [Housing].[HousingData] VALUES (3,1,'20170203','20170426',1);
INSERT INTO [Housing].[HousingData] VALUES (4,1,'20170203','20170426',1);
INSERT INTO [Housing].[HousingData] VALUES (5,1,'20170203','20170426',1);