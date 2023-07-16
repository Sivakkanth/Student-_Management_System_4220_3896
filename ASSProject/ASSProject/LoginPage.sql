create database MVVMLogin
go
use MVVMLogin
go
create table [User]
(
	Id UNIQUEIDENTIFIER primary Key default NEWID(),
	Username nvarchar (50) unique not null,
	[Password] nvarchar (100) not null,
	[Name] nvarchar (50) not null,
	[Lastname] nvarchar (50) not null,
	Email nvarchar (100) unique not null
)
go
insert into [User] values (NEWID(), 'Siva', 'Kanth', 'Karunakaran', 'Sivakkanth', 'asivabkanth@gmail.com')
insert into [User] values (NEWID(), 'Nithush', 'admin', 'Karunakaran', 'Nithushkanth', 'kdushfiy@gmail.com')
insert into [User] values (NEWID(), 'Sajeetha', '1908200', 'Karunakaran', 'Sajeetha', 'djhucsdb@gmail.com')
go

select *from [User]