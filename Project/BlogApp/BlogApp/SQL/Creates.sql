create table Users(
	[Id] int primary key identity,
	[Name] nvarchar(50) not null,
	[Email] nvarchar(50) not null,
	[Password] nvarchar(max) not null
)