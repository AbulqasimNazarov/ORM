

insert into Teachers([TeacherName])
values ('Aleksandr')


insert into Groups([GroupName], [StudentsCount], [TeacherId])
values ('GroupA', 12, 1)

insert into Groups([GroupName], [StudentsCount], [TeacherId])
values ('GroupB', 7, 1),
		('GroupC', 6, 1)


insert into Students([StudentName], [TeacherId])
values('Bob', 1)
