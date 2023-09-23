create database ToDoListDB
use ToDoListDB;


create table [Status](
	[StatusId] int primary key identity,
	[StatusName] nvarchar(50) not null,
)

create table [Priority](
	[PriorityId] int primary key identity,
	[PriorityName] nvarchar(50) not null,
)

create table [Notifications](
	[Id] int primary key  identity,
	[Name] nvarchar(150) not null,
	[Priority] int foreign key references [Priority]([PriorityId]) on delete cascade,
	[Status] int foreign key references [Status]([StatusId]) on delete cascade,
)


insert into [Status]([StatusName])
values('Done'),('Doing'),('Will do')

insert into [Priority]([PriorityName])
values('Important'),('May be later'),('Not important')






