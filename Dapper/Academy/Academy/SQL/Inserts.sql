

insert into Teachers([TeacherName])
values ('Aleksandr')


insert into Groups([GroupName], [StudentsCount], [TeacherId])
values ('GroupA', 12, 1)


insert into Students([StudentName], [TeacherId])
values('Bob', 1)

select * from Groups

delete from Groups 
where [Id]=1