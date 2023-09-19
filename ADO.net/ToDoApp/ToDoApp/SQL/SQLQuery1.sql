create database ToDoListDB


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
values('Import'),('May be later'),('Not important')


drop database ToDoListDB

select * from [Notifications] n
join Status st on n.Id = st.[StatusId]
join Priority pr on n.Id = pr.[PriorityId]