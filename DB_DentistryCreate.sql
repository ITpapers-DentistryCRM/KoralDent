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
	StaffId integer IDENTITY(1,1) NOT NULL,
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
	DoctorId integer IDENTITY(1,1) NOT NULL,
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
	SpecializationId integer IDENTITY(1,1) NOT NULL,
	SpecializationName nvarchar(50) NOT NULL,
  CONSTRAINT [PK_SPECIALIZATION] PRIMARY KEY CLUSTERED
  (
  [SpecializationId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Patient] (
	PatientId integer IDENTITY(1,1) NOT NULL,
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
	ServiceId integer IDENTITY(1,1) NOT NULL,
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
	RegistrationStatusId integer IDENTITY(1,1) NOT NULL,
	RegistrationStatusName nvarchar(30) NOT NULL,
	RegistrationStatusInfo nvarchar(300) NOT NULL
  CONSTRAINT [PK_RegistrationStatus] PRIMARY KEY CLUSTERED
  (
  [RegistrationStatusId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Registration] (
	RegistrationId integer IDENTITY(1,1) NOT NULL,
	RegistrationDate date NOT NULL,
	RegistrationTime time NOT NULL,
	RegistrationComment nvarchar(300),
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
	Registration_ServiceId integer IDENTITY(1,1) NOT NULL,
	RegistrationId integer NOT NULL,
	ServiceId integer NOT NULL

  CONSTRAINT [PK_Registration_Service] PRIMARY KEY CLUSTERED
  (
  [Registration_ServiceId] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Account] (
	AccountId integer IDENTITY(1,1) NOT NULL,
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
	@doc int,
	@p int,
	@rs int
as
begin
	insert Registration(RegistrationDate,RegistrationTime,RegistrationComment,DoctorId,PatientId,RegistrationStatusId) values (@d,@t,@c,@doc,@p,@rs)
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

create proc AddRegistrationStatus
	@n nvarchar(30),
	@i nvarchar(300)

as
begin
	insert RegistrationStatus(RegistrationStatusName,RegistrationStatusInfo) values (@n,@i)
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
--=============================================================================

exec AddAccount 'boss','bOOs'
exec AddAccount 'admin','coral'
exec AddAccount 'dr.Hunko','DocHunko'
exec AddAccount 'dr.Boyko','DocBoyko'
exec AddAccount 'dr.Gerasi','DocGerasi'
exec AddAccount 'dr.Lanova','DocLanova'
exec AddAccount 'dr.Korzhov','DocKorzhov'
exec AddAccount 'dr.Kolesnik','DocKolesnik'
exec AddAccount 'dr.Kukhar','DocKukhar'
exec AddAccount 'dr.Tsymba','DocTsymba'
exec AddAccount 'dr.Zraevsky','DocZraevsky'

--======RegistrationStatus====================================================================================================================

exec AddRegistrationStatus 'Free-Reservation', 'Doctor have a free time'
exec AddRegistrationStatus 'Reservation', 'Waiting for call from administrator'
exec AddRegistrationStatus 'Confirmed reservation', 'Administrator confirmed reservation'
exec AddRegistrationStatus 'Canceled reservation', 'Patient canceled reservation'
exec AddRegistrationStatus 'Completed', 'All work were done'

--======Patient=======================================================================================================================

exec AddPatient 'Pasha Ivanov','+380995553344','pashaI@gmail.com'
exec AddPatient 'Vanya Pushkin','+380667775454','vanyaP@gmail.com'
exec AddPatient 'Danya','+380689519663','Denchik@gmail.com'
exec AddPatient 'Masha Pavlova','+380998529764','mashylia@gmail.com'
exec AddPatient 'vlad motsak','+380997894523','vladMMM@gmail.com'
exec AddPatient 'Olya Morguz','+3807418923','OlgaMOR@gmail.com'

--======Staff=======================================================================================================================

exec AddStaff '1','1','Hunko','Dmitry','Yurievich','1980-02-21','100000'
exec AddStaff '2','2','Dzuba','Alla','Alexeyevna','1970-03-17','55000'
exec AddStaff '3','3','Hunko','Dmitry','Yurievich','1980-02-21','95000'
exec AddStaff '4','3','Boyko','Alesya','Nikolaevna','1985-06-11','65000'
exec AddStaff '5','3','Gerasimenko','Dmitry','Nikolaevich','1987-10-01','115000'
exec AddStaff '6','3','Lanovaya','Natalia','Vasilievna','1972-11-11','85000'
exec AddStaff '7','3','Korzhov','Alexey','Pavlovich','1969-04-24','125000'
exec AddStaff '8','3','Kolesnik','Tatiana','Viktorovna','1980-01-29','175000'
exec AddStaff '9','3','Kukhar','Igor','Vasilievich','1976-02-19','65000'
exec AddStaff '10','3','Tsymbalyuk','Alexander','Vladimirovich','1968-10-01','75000'
exec AddStaff '11','3','Zraevsky','Andrey','Ruslanovich','1974-05-24','125000'

--======Specialization=======================================================================================================================

exec AddSpecialization 'Orthodontist'
exec AddSpecialization 'Orthopedist'
exec AddSpecialization 'Surgeon'
exec AddSpecialization 'Therapist'
exec AddSpecialization 'Implantologist'
exec AddSpecialization 'All'

--=====Doctor========================================================================================================================

exec AddDoctor '3','3','Surgeon, Orthopedist. Work experience: 19 years'
exec AddDoctor '2','3','Surgeon, Orthopedist. Work experience: 19 years'
exec AddDoctor '4','4','Therapist. Work experience: 14 years'
exec AddDoctor '4','5','Dentist therapist, orthopedist, surgeon. Work experience: 10 years'
exec AddDoctor '2','5','Dentist therapist, orthopedist, surgeon. Work experience: 10 years'
exec AddDoctor '3','5','Dentist therapist, orthopedist, surgeon. Work experience: 10 years'
exec AddDoctor '4','6','Dentist therapist, orthopedist. Work experience: 14 years'
exec AddDoctor '2','6','Dentist therapist, orthopedist. Work experience: 14 years'
exec AddDoctor '1','7','Orthodontist. Work experience: 19 years'
exec AddDoctor '1','8','Orthodontist. Work experience: 16 years'
exec AddDoctor '4','9','Therapist, Orthopedist. Work experience: 10 years'
exec AddDoctor '2','9','Therapist, Orthopedist. Work experience: 10 years'
exec AddDoctor '2','10','Orthopedist, Surgeon, Implantologist. Experience: 20 years'
exec AddDoctor '3','10','Orthopedist, Surgeon, Implantologist. Experience: 20 years'
exec AddDoctor '5','10','Orthopedist, Surgeon, Implantologist. Experience: 20 years'
exec AddDoctor '3','11','Dentist surgeon. Work experience: 5 years'

--=====Service====================================================================================================================================
--prevention
exec AddService 'Initial consultation', 'Answers to questions from a highly qualified doctor', '00:15:00','0','6'
exec AddService 'Professional teeth cleaning', 'brush + paste', '00:30:00','600','4'
exec AddService 'Complex cleaning 1', '(scaler + Air- flow) - first degree of difficulty', '00:30:00','1350','4'
exec AddService 'Complex cleaning 2', '(scaler + Air- flow) - second degree of difficulty', '00:40:00','1500','4'
exec AddService 'Complex cleaning 3', '(scaler + Air- flow) - third degree of difficulty', '00:50:00','1700','4'
exec AddService 'Complex cleaning', '(scaler + Air- flow + application with rem. gel)', '01:00:00','2850','4'
--caries treatment
exec AddService 'Temporary filling', 'Temporary filling', '00:15:00','250','4'
exec AddService 'Long-lasting temporary filling', 'Long-lasting temporary filling', '00:20:00','550','4'
exec AddService 'Placement of fillings under the crown', 'Placement of fillings under the crown', '00:30:00','800','4'
exec AddService 'Correction of the filling', 'Polishing or correction of the filling', '00:20:00','600','4'
exec AddService 'Filling with photopolymer (small caries)', 'Filling with photopolymer (small caries)', '00:10:00','700','4'
exec AddService 'Filling with photopolymer (medium caries)', 'Filling with photopolymer (medium caries)', '00:20:00','800','4'
exec AddService 'Filling with photopolymer (deep caries)', 'Filling with photopolymer (deep caries)', '00:30:00','900','4'
exec AddService 'Artistic restoration of the tooth crown 1', 'First degree of difficulty', '00:20:00','1500','4'
exec AddService 'Artistic restoration of the tooth crown 2', 'Second degree of difficulty', '00:40:00','1750','4'
exec AddService 'Artistic restoration of the tooth crown 3', 'Third degree of difficulty', '01:00:00','2800','4'
--dental treatment under a microscope
exec AddService 'Root canal treatment in one visit 1', 'One-canal tooth, initial treatment and root canal filling', '00:30:00','2700','2'
exec AddService 'Root canal treatment in one visit 2', 'Two-channel tooth, initial treatment and root canal filling', '01:00:00','4500','2'
exec AddService 'Root canal treatment in one visit 3', 'Three-channel tooth, initial treatment and root canal filling', '01:30:00','6000','2'
exec AddService 'Root canal treatment in one visit 4', 'Four-channel tooth, initial treatment and root canal filling', '02:00:00','8000','2'
exec AddService 'Root canal treatment in two visits 1', 'One-canal tooth, initial treatment and root canal filling', '00:20:00','2050','2'
exec AddService 'Root canal treatment in two visits 2', 'Two-channel tooth, initial treatment and root canal filling', '00:40:00','2900','2'
exec AddService 'Root canal treatment in two visits 3', 'Three-channel tooth, initial treatment and root canal filling', '01:00:00','3900','2'
exec AddService 'Root canal treatment in two visits 4', 'Four-channel tooth, initial treatment and root canal filling', '01:20:00','4900','2'
exec AddService 'Root canal filling 1', 'Single canal tooth, root canal filling', '00:20:00','1080','2'
exec AddService 'Root canal filling 2', 'Two-canal tooth, root canal filling', '00:40:00','1050','2'
exec AddService 'Root canal filling 3', 'Three-canal tooth, root canal filling', '01:00:00','4300','2'
exec AddService 'Root canal filling 4', 'Four canal tooth, root canal filling', '01:20:00','5550','2'
--tooth extraction
exec AddService 'Conductive anesthesia', 'Conductive anesthesia', '00:10:00','250','3'
exec AddService 'Removal of a tooth', 'Removal of a tooth (simple)', '00:10:00','400','3'
exec AddService 'Difficult tooth extraction 1', 'Difficult tooth extraction (1st degree of difficulty)', '00:20:00','600','3'
exec AddService 'Difficult tooth extraction 2', 'Difficult tooth extraction (2nd degree of difficulty)', '00:30:00','800','3'
exec AddService 'Removal of impacted tooth', 'Removal of impacted tooth', '01:00:00','2000','3'
exec AddService 'Removal of impacted tooth', 'Removal of an impacted tooth using piezosurgery', '02:00:00','4800','3'
exec AddService 'Removal of a baby tooth (simple)', 'Removal of a baby tooth (simple)', '00:15:00','250','3'
exec AddService 'Removal of a baby tooth (complex)', 'Removal of a baby tooth (complex)', '00:20:00','400','3'
--implantation
exec AddService 'Making a surgical template for implant placement', 'Making a surgical template for implant placement', '01:00:00','3000','5'
exec AddService 'Installation of one Neobiotech implant', 'Placement of one Neobiotech implant', '02:30:00','8000','5'
exec AddService 'Installation of one Dio implant', 'Installation of one Dio implant', '02:30:00','9000','5'
exec AddService 'Bone plastics', 'Bone plastics', '01:03:00','4000','5'
exec AddService 'Sinus lifting open', 'Sinus lifting open', '03:00:00','10000','5'
exec AddService 'Sinus lifting closed', 'Sinus lifting closed', '02:00:00','5000','5'
exec AddService 'Splitting of the alveolar bone', 'Splitting of the alveolar bone', '01:30:00','4300','5'
exec AddService 'Application of bone material BioOss 1 cc', 'Application of bone material BioOss 1 cc', '01:00:00','5000','5'
exec AddService 'Collagen membrane application for one implant / tooth', 'Collagen membrane application for one implant / tooth', '01:00:00','3000','5'
exec AddService 'Guided bone regeneration', 'Guided bone regeneration', '03:00:00','10000','5'
exec AddService 'Installation of an orthodontic microimplant', 'Installation of an orthodontic microimplant', '02:00:00','4000','5'
--prosthetics
exec AddService 'Acquiring a PrimeScan digital impression', 'Acquiring a PrimeScan digital impression', '00:20:00','500','2'
exec AddService 'Making a temporary plastic crown', 'Making a temporary plastic crown', '00:30:00','800','2'
exec AddService 'Manufacturing and cementation of a cermet stump inlay', 'Manufacturing and cementation of a cermet stump inlay', '00:30:00','2500','2'
exec AddService 'Manufacturing and cementation of a zirconium stump inlay', 'Manufacturing and cementation of a zirconium stump inlay', '00:30:00','4500','2'
exec AddService 'Production of metal-ceramic crown', 'Production of metal-ceramic crown', '00:30:00','3300','2'
exec AddService 'Manufacturing of inlay, E-max crown, zirconium crown', 'Manufacturing of inlay, E-max crown, zirconium crown', '00:30:00','6500','2'
exec AddService 'Manufacturing of a highly aesthetic zirconia crown, veneer', 'Manufacturing of a highly aesthetic zirconia crown, venee', '00:30:00','8500','2'
exec AddService 'Making a zirconium crown for an implant', 'Making a zirconium crown for an implant', '00:30:00','5500','2'
exec AddService 'Cementation of the crown with composite cement', 'Cementation of the crown with composite cement', '00:30:00','300','2'
exec AddService 'Manufacturing of a partially removable denture', 'Manufacturing of a partially removable denture', '00:30:00','8400','2'
exec AddService 'Manufacturing of a complete removable prosthesis from plastmass', 'Manufacturing of a complete removable prosthesis from plastmass', '00:30:00','11200','2'
exec AddService 'Making a clasp prosthesis', 'Making a clasp prosthesis', '00:30:00','12500','2'
--orthodontics
exec AddService 'Photography', 'Photography', '00:15:00','100','1'
exec AddService 'Making a removable device with a screw', 'Making a removable device with a screw', '00:30:00','4100','1'
exec AddService 'Removable apparatus manufacturing - bioblock (Mu apparatus)', 'Removable apparatus manufacturing - bioblock (Mu apparatus)', '00:30:00','6850','1'
exec AddService 'Non-removable apparatus manufacturing - Ross apparatus', 'Non-removable apparatus manufacturing - Ross apparatus', '00:30:00','6700','1'
exec AddService 'Distaljet apparatus manufacturing', 'Distaljet apparatus manufacturing', '00:30:00','14000','1'
exec AddService 'Fixation of the classic metal bracket system', 'Fixation of the classic metal bracket system', '02:00:00','12500','1'
exec AddService 'Fixation of the self-ligating metal bracket system Pitts 21', 'Fixation of the self-ligating metal bracket system Pitts 21', '02:00:00','18000','1'
exec AddService 'Fixation of the ceramic bracket system', 'Fixation of the ceramic bracket system', '02:30:00','18000','1'
exec AddService 'Ceramic self-ligating braces fixation', 'Ceramic self-ligating braces fixation', '03:00:00','26600','1'
exec AddService 'Replacing the arc with a thermoactive', 'Replacing the arc with a thermoactive', '00:30:00','450','1'
exec AddService 'Drawing up a treatment plan (orthodontics)', 'Laboratory diagnostics, scanning, printing diagnostic models on a 3D printer, drawing up a treatment plan', '01:30:00','6500','1'
exec AddService 'Installing a fixed retainer', 'Installing a fixed retainer', '01:00:00','1700','1'
exec AddService 'Installing a Removable Kappa Retainer', 'Installing a Removable Kappa Retainer', '01:00:00','1550','1'
exec AddService 'Fixing the ring with spacer', 'Fixing the ring with spacer', '02:00:00','2500','1'
exec AddService 'Correction, activation of the removable device', 'Correction, activation of the removable device', '02:00:00','200','1'

--=====Registration======================================================================================================================

 exec AddRegistration '2020-12-17','10:00:00','Important patient','1','1','1'
 exec AddRegistration '2020-12-17','14:00:00','discount: -5%','1','2','1'
 exec AddRegistration '2020-12-17','15:00:00','none','4','3','1'
 exec AddRegistration '2020-12-18','09:00:00','Hunko family','2','4','1'
 exec AddRegistration '2020-12-18','13:00:00','discount: -5%','6','5','1'
 exec AddRegistration '2020-12-18','19:00:00','none','4','6','1'

  --=====Registration======================================================================================================================

  exec AddRegistration_Service '1','20'
  exec AddRegistration_Service '1','15'
  exec AddRegistration_Service '1','5'
  exec AddRegistration_Service '2','51'
  exec AddRegistration_Service '3','22'
  exec AddRegistration_Service '3','17'
  exec AddRegistration_Service '4','1'
  exec AddRegistration_Service '5','50'
  exec AddRegistration_Service '5','55'
  exec AddRegistration_Service '6','5'
  exec AddRegistration_Service '6','7'



