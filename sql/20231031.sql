show databases;
use school;
create table student(
	num integer PRIMARY KEY auto_increment,
    name varchar(20),
    age integer,
    gender varchar(10),
    date varchar(30)
); 

show index from student;

insert into student(name, age, gender, date) values('홍길동', 20, '남성', '~~');

select *
from student;