create database Blogram
use Blogram

create table Statuses(
	[Id] int primary key identity,
	[StatusName] nvarchar(50) not null,
)


create table Users (
    [Id] uniqueidentifier PRIMARY KEY DEFAULT (newid()),
    [Name] nvarchar(50) NOT NULL,
    [Surname] nvarchar(50) NOT NULL,
    [Email] nvarchar(80),
    [Password] nvarchar(50) NOT NULL,
	[Status] int foreign key references Statuses([Id]),
    CONSTRAINT CHK_ValidEmail CHECK (Email LIKE '%_@_%._%'),
    CONSTRAINT CHK_ValidPassword CHECK (LEN([Password]) >= 8 AND [Password] LIKE '%[0-9]%' AND [Password] LIKE '%[a-zA-Z]%')
)

insert into Statuses([StatusName])
values('Online'), ('Offline'), ('Hidden')

insert into Users([Name], [Surname], [Email], [Password], [Status])
values('Abulqasim', 'Nazarov', 'abulqasim.nazarov@gmail.com', 'qwerty12345', 