use master
go

if DB_ID('Clinic') is not null
	drop database Clinic
go
CREATE DATABASE [Clinic]
GO
USE [Clinic]
GO

CREATE TABLE [Staff] (
	Id integer NOT NULL,
	LastName nvarchar(50) NOT NULL,
	Name nvarchar(50) NOT NULL,
	MiddleName nvarchar(50) NOT NULL,
	Birthday date NOT NULL,
	Salary float,
  CONSTRAINT [PK_STAFF] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Doctor] (
	Id integer NOT NULL,
	SpecializationId integer NOT NULL,
	StaffId integer NOT NULL,
	Info nvarchar(500) NOT NULL
  CONSTRAINT [PK_DOCTOR] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Specialization] (
	Id integer NOT NULL,
	Name nvarchar(50) NOT NULL,
  CONSTRAINT [PK_SPECIALIZATION] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Patient] (
	Id integer NOT NULL,
	Name nvarchar(50) NOT NULL,
	Phone nvarchar(50) NOT NULL,
	Email nvarchar(50),
  CONSTRAINT [PK_PATIENT] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Service] (
	Id integer NOT NULL,
	Name nvarchar(50) NOT NULL,
	Description nvarchar(200) NOT NULL,
	Duration time NOT NULL,
	Price float NOT NULL,
	SpecializationId integer NOT NULL,
  CONSTRAINT [PK_SERVICE] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [RegistrationStatus] (
	Id integer NOT NULL,
	Name nvarchar(30) NOT NULL,
	Info nvarchar(300)
  CONSTRAINT [PK_RegistrationStatus] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Registration] (
	Id integer NOT NULL,
	Date date NOT NULL,
	Time time NOT NULL,
	Comment nvarchar(300),
	ServiceId integer NOT NULL,
	DoctorId integer NOT NULL,
	PatientId integer NOT NULL,
	RegistrationStatusId integer NOT NULL 
  CONSTRAINT [PK_REGISTRATION] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Registration_Service] (
	Id integer NOT NULL,
	RegistrationId integer NOT NULL,
	ServiceId integer NOT NULL

  CONSTRAINT [PK_Registration_Service] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

ALTER TABLE [Doctor] WITH CHECK ADD CONSTRAINT [Doctor_fk0] FOREIGN KEY ([SpecializationId]) REFERENCES [Specialization]([Id])
--ON UPDATE CASCADE
GO
ALTER TABLE [Doctor] CHECK CONSTRAINT [Doctor_fk0]
GO
ALTER TABLE [Doctor] WITH CHECK ADD CONSTRAINT [Doctor_fk1] FOREIGN KEY ([StaffId]) REFERENCES [Staff]([Id])
--ON UPDATE CASCADE
GO
ALTER TABLE [Doctor] CHECK CONSTRAINT [Doctor_fk1]
GO



ALTER TABLE [Service] WITH CHECK ADD CONSTRAINT [Service_fk0] FOREIGN KEY ([SpecializationId]) REFERENCES [Specialization]([Id])
--ON UPDATE CASCADE
GO
ALTER TABLE [Service] CHECK CONSTRAINT [Service_fk0]
GO

ALTER TABLE [Registration] WITH CHECK ADD CONSTRAINT [Registration_fk0] FOREIGN KEY ([ServiceId]) REFERENCES [Service]([Id])
--ON UPDATE CASCADE
GO
ALTER TABLE [Registration] CHECK CONSTRAINT [Registration_fk0]
GO
ALTER TABLE [Registration] WITH CHECK ADD CONSTRAINT [Registration_fk1] FOREIGN KEY ([DoctorId]) REFERENCES [Doctor]([Id])
--ON UPDATE CASCADE
GO
ALTER TABLE [Registration] CHECK CONSTRAINT [Registration_fk1]
GO
ALTER TABLE [Registration] WITH CHECK ADD CONSTRAINT [Registration_fk2] FOREIGN KEY ([PatientId]) REFERENCES [Patient]([Id])
--ON UPDATE CASCADE
GO
ALTER TABLE [Registration] CHECK CONSTRAINT [Registration_fk2]
GO
ALTER TABLE [Registration] WITH CHECK ADD CONSTRAINT [Registration_fk3] FOREIGN KEY ([RegistrationStatusId]) REFERENCES [RegistrationStatus]([Id])
--ON UPDATE CASCADE
GO
ALTER TABLE [Registration] CHECK CONSTRAINT [Registration_fk3]
GO
ALTER TABLE [Registration_Service] WITH CHECK ADD CONSTRAINT [Registration_Service_fk0] FOREIGN KEY ([RegistrationId]) REFERENCES [Registration]([Id])
--ON UPDATE CASCADE
GO
ALTER TABLE [Registration_Service] CHECK CONSTRAINT [Registration_Service_fk0]
GO
ALTER TABLE [Registration_Service] WITH CHECK ADD CONSTRAINT [Registration_Service_fk1] FOREIGN KEY ([ServiceId]) REFERENCES [Service]([Id])
--ON UPDATE CASCADE
GO
ALTER TABLE [Registration_Service] CHECK CONSTRAINT [Registration_Service_fk1]
GO

--=============================================================================

create proc AddStaff
	@ln nvarchar(50),
	@n nvarchar(50),
	@mn nvarchar(50),
	@b date,
	@s float

as
begin
	insert Staff(LastName,Name,MiddleName,Birthday,Salary) values (@ln,@n,@mn,@b,@s)
end
go

create proc AddSpecialization
	@n nvarchar(50)

as
begin
	insert Specialization(Name) values (@n)
end
go


create proc AddDoctor
	@s int,
	@st int,
	@i nvarchar(500)

as
begin
	insert Doctor(SpecializationId,StaffId, Info) values (@s,@st,@i)
end
go

create proc AddPatient
	@n nvarchar(50),
	@p nvarchar(50),
	@e nvarchar(50)


as
begin
	insert Patient(Name,Phone,Email) values (@n,@p,@e)
end
go

create proc AddService
	@n nvarchar(50),
	@des nvarchar(200),
	@d time,
	@p float,
	@s int

as
begin
	insert Service(Name,Description,Duration,Price,SpecializationId) values (@n,@des,@d,@p,@s)
end
go

create proc AddRegistration
	@d date,
	@t time,
	@c  nvarchar(300),
	@s int,
	@doc int,
	@p int

as
begin
	insert Registration(Date,Time,Comment,ServiceId,DoctorId,PatientId) values (@d,@t,@c,@s,@doc,@p)
end
go

create proc AddRegistration_Service
	@r int,
	@s int

as
begin
	insert Registration_Service(RegistrationId,ServiceId) values (@r,@s)
end
go

