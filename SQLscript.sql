create database Bills
use Bills

create table Document
(
PK_DocumentID int identity(0,1) not null primary key,
Company varchar(30) not null,
[Date] date,
FileExt varchar(10) not null,
Tag varchar(50),
DOC varbinary(max) not null,
Category varchar(50)
)

create table Item
(
PK_ItemID int identity(0,1) not null primary key,
Name varchar(max) not null,
FK_DocumentID int foreign key references Document(PK_DocumentID) not null
)