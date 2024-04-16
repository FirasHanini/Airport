IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Passengers] (
    [PassengerId] int NOT NULL IDENTITY,
    [Birthdate] datetime2 NOT NULL,
    [PassporitNumber] nvarchar(max) NOT NULL,
    [EmailAdress] nvarchar(max) NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [TelNumber] nvarchar(max) NOT NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [EmployementDate] datetime2 NULL,
    [Function] nvarchar(max) NULL,
    [Salary] float NULL,
    [HealthInformation] nvarchar(max) NULL,
    [Nationality] nvarchar(max) NULL,
    CONSTRAINT [PK_Passengers] PRIMARY KEY ([PassengerId])
);
GO

CREATE TABLE [Planes] (
    [PlaneId] int NOT NULL IDENTITY,
    [Capacity] int NOT NULL,
    [ManufactureDate] datetime2 NOT NULL,
    [PlaneType] int NOT NULL,
    CONSTRAINT [PK_Planes] PRIMARY KEY ([PlaneId])
);
GO

CREATE TABLE [Flights] (
    [FlightId] int NOT NULL IDENTITY,
    [Destination] nvarchar(max) NOT NULL,
    [Departure] nvarchar(max) NOT NULL,
    [FlightDate] datetime2 NOT NULL,
    [EffectiveArrival] datetime2 NOT NULL,
    [EstimatedDuration] float NOT NULL,
    [myPlanePlaneId] int NOT NULL,
    CONSTRAINT [PK_Flights] PRIMARY KEY ([FlightId]),
    CONSTRAINT [FK_Flights_Planes_myPlanePlaneId] FOREIGN KEY ([myPlanePlaneId]) REFERENCES [Planes] ([PlaneId]) ON DELETE CASCADE
);
GO

CREATE TABLE [FlightPassenger] (
    [FlightId] int NOT NULL,
    [PassengersPassengerId] int NOT NULL,
    CONSTRAINT [PK_FlightPassenger] PRIMARY KEY ([FlightId], [PassengersPassengerId]),
    CONSTRAINT [FK_FlightPassenger_Flights_FlightId] FOREIGN KEY ([FlightId]) REFERENCES [Flights] ([FlightId]) ON DELETE CASCADE,
    CONSTRAINT [FK_FlightPassenger_Passengers_PassengersPassengerId] FOREIGN KEY ([PassengersPassengerId]) REFERENCES [Passengers] ([PassengerId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_FlightPassenger_PassengersPassengerId] ON [FlightPassenger] ([PassengersPassengerId]);
GO

CREATE INDEX [IX_Flights_myPlanePlaneId] ON [Flights] ([myPlanePlaneId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240318204349_firstMigrBlyad', N'7.0.16');
GO

COMMIT;
GO

