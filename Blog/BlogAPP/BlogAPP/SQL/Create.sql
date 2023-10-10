create database BlogApp
use BlogApp

create table Genders(
	[Id] int primary key identity,
	[Name] nvarchar(50) not null,
)


create table Users (
    [Id] int primary key identity,
    [Name] nvarchar(50) NOT NULL,
    [Surname] nvarchar(50) NOT NULL,
    [Email] nvarchar(80) not null,
    [Password] nvarchar(50) NOT NULL,
	[ImagePath] nvarchar(max),
	[PhoneNumber] nvarchar(50),
	[Address] nvarchar(50),
	[Profession] nvarchar(max),
	[Gender] int foreign key references Genders([Id]),
    CONSTRAINT CHK_ValidEmail CHECK (Email LIKE '%_@_%._%'),
    CONSTRAINT CHK_ValidPassword CHECK (LEN([Password]) >= 8 AND [Password] LIKE '%[0-9]%' AND [Password] LIKE '%[a-zA-Z]%')
)

insert into Genders([Name])
values('Male'), ('Female')

select * from Users

insert into Users([Name], [Surname], [Email], [Password], [Gender], [ImagePath])
values('Abulqasim', 'Nazarov', 'abulqasim.nazarov@gmail.com', 'qwerty12345', 1, '"D:\ORMmodule\ORM\Blog\BlogAPP\BlogAPP\Assets\CatProfil.jpg"')