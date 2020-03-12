-- Author: minhandev-time: 03.12.2020

if exists (select name from sysdatabases where name = 'qllttoeic')
drop database qllttoeic;
go
create database qllttoeic;
go
use qllttoeic;
go
create table users --nguoidung
(
	id int identity not null primary key,
	ten nvarchar(100),
	matkhau nvarchar(100),
	ngaytao datetime,

)