use Test
go
create table TreeTest
(
 id int identity(1,1) primary key not null,
 nodeName nvarchar(50) not null,
 parentId int not null

)