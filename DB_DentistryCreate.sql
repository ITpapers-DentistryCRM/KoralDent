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
	StaffId integer NOT NULL,
	AccountId integer NOT NULL,
	AccountLevel integer NOT NULL,
	StaffLastName nvarchar(50) NOT NULL,
	StaffName nvarchar(50) NOT NULL,
	StaffMiddleName nvarchar(50) NOT NULL,
	StaffBirthday date NOT NULL,
	StaffSalary float NOT NULL
	
  CONSTRAINT [PK_STAFF] PRIMARY KEY CLUSTERED
  (
  [StaffId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Doctor] (
	DoctorId integer NOT NULL,
	SpecializationId integer NOT NULL,
	StaffId integer NOT NULL,
	DoctorInfo nvarchar(500) NOT NULL
  CONSTRAINT [PK_DOCTOR] PRIMARY KEY CLUSTERED
  (
  [DoctorId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Specialization] (
	SpecializationId integer NOT NULL,
	SpecializationName nvarchar(50) NOT NULL,
  CONSTRAINT [PK_SPECIALIZATION] PRIMARY KEY CLUSTERED
  (
  [SpecializationId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Patient] (
	PatientId integer NOT NULL,
	PatientName nvarchar(50) NOT NULL,
	PatientPhone nvarchar(50) NOT NULL,
	PatientEmail nvarchar(50) NOT NULL,
  CONSTRAINT [PK_PATIENT] PRIMARY KEY CLUSTERED
  (
  [PatientId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Service] (
	ServiceId integer NOT NULL,
	ServiceName nvarchar(50) NOT NULL,
	ServiceDescription nvarchar(200) NOT NULL,
	ServiceDuration time NOT NULL,
	ServicePrice float NOT NULL,
	SpecializationId integer NOT NULL,
  CONSTRAINT [PK_SERVICE] PRIMARY KEY CLUSTERED
  (
  [ServiceId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [RegistrationStatus] (
	RegistrationStatusId integer NOT NULL,
	RegistrationStatusName nvarchar(30) NOT NULL,
	RegistrationStatusInfo nvarchar(300) NOT NULL
  CONSTRAINT [PK_RegistrationStatus] PRIMARY KEY CLUSTERED
  (
  [RegistrationStatusId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Registration] (
	RegistrationId integer NOT NULL,
	RegistrationDate date NOT NULL,
	RegistrationTime time NOT NULL,
	RegistrationComment nvarchar(300),
	ServiceId integer NOT NULL,
	DoctorId integer NOT NULL,
	PatientId integer NOT NULL,
	RegistrationStatusId integer NOT NULL 
  CONSTRAINT [PK_REGISTRATION] PRIMARY KEY CLUSTERED
  (
  [RegistrationId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Registration_Service] (
	Registration_ServiceId integer NOT NULL,
	RegistrationId integer NOT NULL,
	ServiceId integer NOT NULL

  CONSTRAINT [PK_Registration_Service] PRIMARY KEY CLUSTERED
  (
  [Registration_ServiceId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Account] (
	AccountId integer NOT NULL,
	AccountLogin nvarchar(50) NOT NULL,
	AccountPassword nvarchar(50) NOT NULL
  CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED
  (
  [AccountId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [Staff] WITH CHECK ADD CONSTRAINT [Staff_fk0] FOREIGN KEY ([AccountId]) REFERENCES [Account]([AccountId])
--ON UPDATE CASCADE
GO
ALTER TABLE [Staff] CHECK CONSTRAINT [Staff_fk0]
GO
ALTER TABLE [Doctor] WITH CHECK ADD CONSTRAINT [Doctor_fk0] FOREIGN KEY ([SpecializationId]) REFERENCES [Specialization]([SpecializationId])
--ON UPDATE CASCADE
GO
ALTER TABLE [Doctor] CHECK CONSTRAINT [Doctor_fk0]
GO
ALTER TABLE [Doctor] WITH CHECK ADD CONSTRAINT [Doctor_fk1] FOREIGN KEY ([StaffId]) REFERENCES [Staff]([StaffId])
--ON UPDATE CASCADE
GO
ALTER TABLE [Doctor] CHECK CONSTRAINT [Doctor_fk1]
GO



ALTER TABLE [Service] WITH CHECK ADD CONSTRAINT [Service_fk0] FOREIGN KEY ([SpecializationId]) REFERENCES [Specialization]([SpecializationId])
--ON UPDATE CASCADE
GO
ALTER TABLE [Service] CHECK CONSTRAINT [Service_fk0]
GO

ALTER TABLE [Registration] WITH CHECK ADD CONSTRAINT [Registration_fk0] FOREIGN KEY ([ServiceId]) REFERENCES [Service]([ServiceId])
--ON UPDATE CASCADE
GO
ALTER TABLE [Registration] CHECK CONSTRAINT [Registration_fk0]
GO
ALTER TABLE [Registration] WITH CHECK ADD CONSTRAINT [Registration_fk1] FOREIGN KEY ([DoctorId]) REFERENCES [Doctor]([DoctorId])
--ON UPDATE CASCADE
GO
ALTER TABLE [Registration] CHECK CONSTRAINT [Registration_fk1]
GO
ALTER TABLE [Registration] WITH CHECK ADD CONSTRAINT [Registration_fk2] FOREIGN KEY ([PatientId]) REFERENCES [Patient]([PatientId])
--ON UPDATE CASCADE
GO
ALTER TABLE [Registration] CHECK CONSTRAINT [Registration_fk2]
GO
ALTER TABLE [Registration] WITH CHECK ADD CONSTRAINT [Registration_fk3] FOREIGN KEY ([RegistrationStatusId]) REFERENCES [RegistrationStatus]([RegistrationStatusId])
--ON UPDATE CASCADE
GO
ALTER TABLE [Registration] CHECK CONSTRAINT [Registration_fk3]
GO
ALTER TABLE [Registration_Service] WITH CHECK ADD CONSTRAINT [Registration_Service_fk0] FOREIGN KEY ([RegistrationId]) REFERENCES [Registration]([RegistrationId])
--ON UPDATE CASCADE
GO
ALTER TABLE [Registration_Service] CHECK CONSTRAINT [Registration_Service_fk0]
GO
ALTER TABLE [Registration_Service] WITH CHECK ADD CONSTRAINT [Registration_Service_fk1] FOREIGN KEY ([ServiceId]) REFERENCES [Service]([ServiceId])
--ON UPDATE CASCADE
GO
ALTER TABLE [Registration_Service] CHECK CONSTRAINT [Registration_Service_fk1]
GO

--=============================================================================

create proc AddStaff
	@aId integer,
	@aLvl integer,
	@ln nvarchar(50),
	@n nvarchar(50),
	@mn nvarchar(50),
	@b date,
	@s float

as
begin
	insert Staff(AccountId,AccountLevel,StaffLastName,StaffName,StaffMiddleName,StaffBirthday,StaffSalary) values (@aId,@aLvl,@ln,@n,@mn,@b,@s)
end
go

create proc AddSpecialization
	@n nvarchar(50)

as
begin
	insert Specialization(SpecializationName) values (@n)
end
go


create proc AddDoctor
	@s int,
	@st int,
	@i nvarchar(500)

as
begin
	insert Doctor(SpecializationId,StaffId, DoctorInfo) values (@s,@st,@i)
end
go

create proc AddPatient
	@n nvarchar(50),
	@p nvarchar(50),
	@e nvarchar(50)


as
begin
	insert Patient(PatientName,PatientPhone,PatientEmail) values (@n,@p,@e)
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
	insert Service(ServiceName,ServiceDescription,ServiceDuration,ServicePrice,SpecializationId) values (@n,@des,@d,@p,@s)
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
	insert Registration(RegistrationDate,RegistrationTime,RegistrationComment,ServiceId,DoctorId,PatientId) values (@d,@t,@c,@s,@doc,@p)
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
create proc AddAccount
	@l nvarchar(50),
	@p nvarchar(50)
as
begin
	insert Account(AccountLogin,AccountPassword) values (@l,@p)
end
go

