create database Academy

use Academy




create table Teachers(
	[TeacherId] int primary key identity,
	[TeacherName] nvarchar(50) not null,
)

create table Groups(
	[Id] int primary key identity,
	[GroupName] nvarchar(50) not null,
	[StudentsCount] int not null,
	[TeacherId] int foreign key references Teachers([TeacherId]) on delete cascade not null,
)


create table Students(
	[StudentId] int primary key identity,
	[StudentName] nvarchar(50) not null,
	[TeacherId] int foreign key references Teachers([TeacherId]) on delete cascade not null,
)


