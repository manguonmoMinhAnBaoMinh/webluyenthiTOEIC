-- Author: minhandev-time: 03.12.2020

if exists (select name from sysdatabases where name = 'qllttoeic')
drop database qllttoeic;
go
create database qllttoeic;
go
use qllttoeic;
go
create table Users(
	idUsers int identity(00,1) not null primary key,
	ten nvarchar(225),
	nSinh char(4),
	tTrang nvarchar(50),
	nTHien datetime,
	idTest int,
)
go
 create table Test(
	idTest int identity(00,1) not null primary key,
	ten nvarchar(225),
 )
go
create table Questions(
	idQuestion int identity(000,1) not null primary key,
	cHoi nvarchar(max),
	dA nvarchar(max),
	dB nvarchar(max),
	dC nvarchar(max),
	dD nvarchar(max),
	dAn varchar(10),
	idTest int,
)
go
create table Errors(
	idQuestion int identity(000,1) not null primary key,
	cHoi nvarchar(max),
	dA nvarchar(max),
	dB nvarchar(max),
	dC nvarchar(max),
	dD nvarchar(max),
	dAn varchar(10),
	idTest int,
)
go
create table Adminstrator(
	idAd int identity(000,1) primary key not null,
	ten nvarchar(225),
	tKhoan varchar(100),
	mKhau nvarchar(100),
	nTao date,
)
go
alter table Users add constraint fk_Test_Users foreign key (idTest) references Test(idTest)
go
alter table Errors add constraint fk_Test_Errors foreign key (idTest) references Test(idTest)
go
alter table Questions add constraint fk_Test_Questions foreign key (idTest) references Test(idTest)

insert into Adminstrator values(N'Trần Minh Ân', 'admin', 'admin', '03/13/2020')