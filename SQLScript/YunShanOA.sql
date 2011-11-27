CREATE DATABASE YunShanOA
GO
USE YunShanOA
GO
--����MeetingTpe��
CREATE TABLE MeetingType
(
MeetingTypeID INT NOT NULL IDENTITY PRIMARY KEY,--MeetingTypeID ����
MeetingTypeName NVARCHAR(50) NOT NULL,--MeetingTypeName ������������
MeetingTypeDescription NVARCHAR(MAX) NULL--MeetingTypeDescription ��������
)
GO
--------------------------------------------------------------------------------------------
--����Workflows��
CREATE TABLE Workflows
(
WFID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,--WFID ����
WFTID UNIQUEIDENTIFIER NOT NULL,--������ģ�����͵�ID
WFName NVARCHAR(50) NULL,--����������
Status INT NULL--״̬
)
ALTER TABLE [dbo].[Workflows] ADD  CONSTRAINT [DF__Workflows__WFTID]  DEFAULT (newid()) FOR [WFTID]
-------------------------------------------------------------------------------------------------
--����MeetingApplyForm��
GO
CREATE TABLE MeetingApplyForm
(
	MeetingApplyFormID INT NOT NULL IDENTITY PRIMARY KEY,--MeetingApplyFormID
	ApplyUserName NVARCHAR(20) NOT NULL,--��������ߵ�����
	MeetingTypeID INT NOT NULL ,--�������͵�ID�����
	MeetingTopic NVARCHAR(100) NOT NULL,--��������
	MeetingIntroduction NVARCHAR(2000) NOT NULL,--�������
	BeginTime datetime NOT NULL,--��ʼʱ��
	EndTime datetime NOT NULL,--����ʱ��
	MeetingStatus INT NOT NULL,--����״̬�����������(0)��������(1)���������(2) 3��״̬
	WFID UNIQUEIDENTIFIER NOT NULL,--������ID ���
	Comments NVARCHAR(2000) NOT NULL --���鱸ע
)

-----ΪMeetingApplyForm���Լ��
ALTER TABLE MeetingApplyForm
ADD CONSTRAINT FK_MeetingApplyform_MeetingType FOREIGN KEY(MeetingTypeID) REFERENCES meetingtype(MeetingTypeID)
ALTER TABLE MeetingApplyForm
ADD CONSTRAINT FK_MeetingApplyform_Workflows FOREIGN KEY(WFID) REFERENCES Workflows(WFID)
-----����������

-----------------------------------------------------------------------------------------------------
GO
CREATE TABLE MeetingParticipationMember--��ϯ�������Ա��
(
MeetingApplyFormID INT NOT NULL,
EmployeeNo INT NOT NULL,
MePartiMemberName NVARCHAR(14) NOT NULL
)
ALTER TABLE dbo.MeetingParticipationMember ADD CONSTRAINT pk_EmployeeNo PRIMARY KEY (EmployeeNo,MeetingApplyFormID)

ALTER TABLE MeetingParticipationMember
ADD CONSTRAINT FK_MeetingParticipationMember_MeetingApplyform FOREIGN KEY(MeetingApplyFormID) REFERENCES MeetingApplyform(MeetingApplyFormID)
---------------------------------------------------------------------------------------------------------
GO
CREATE TABLE MeetingRoom--������
(
MeetingRoomID int NOT NULL IDENTITY PRIMARY KEY,
MeetingRoomName NVARCHAR(50) NOT NULL,
MeetingRoomCapacity int NOT NULL,
MeetingRoomStatus int NOT NULL,
MeetingTypeID int NOT NULL
)
ALTER TABLE MeetingRoom
ADD CONSTRAINT FK_MeetingType_MeetingRoom FOREIGN KEY(MeetingTypeID) REFERENCES MeetingType(MeetingTypeID)
---------------------------------------------------------------------------------------------------------
GO
CREATE TABLE MeetingAndRoom---����ͻ�����
(
MeetingAndRoomID int NOT NULL IDENTITY PRIMARY KEY,
MeetingApplyFormID int NOT NULL,
MeetingRoomID int NOT NULL
)
ALTER TABLE MeetingAndRoom
ADD CONSTRAINT FK_MeetingApplyForm_MeetingAndRoom FOREIGN KEY(MeetingApplyFormID) REFERENCES MeetingApplyForm(MeetingApplyFormID)

ALTER TABLE MeetingAndRoom
ADD CONSTRAINT FK_MeetingRoom_MeetingAndRoom FOREIGN KEY(MeetingRoomID) REFERENCES MeetingRoom(MeetingRoomID)

--------------------------------------------------------------------------------------------------------
GO
CREATE TABLE ReviewMeetingApply--�鿴���������
(
ReviewMeetingApplyID INT NOT NULL IDENTITY PRIMARY KEY,
MeetingApplyFormID INT NOT NULL,
ReviewUserName NVARCHAR(20) NULL,
Agree INT NULL,
)
ALTER TABLE ReviewMeetingApply
ADD CONSTRAINT FK_MeetingApplyForm_ReviewMeetingApply FOREIGN KEY(MeetingApplyFormID) REFERENCES MeetingApplyForm(MeetingApplyFormID)

-----------------------------------------------------------------------------------------------------
GO
CREATE TABLE MeetingEquipment---�����豸��
(
MeetingEquipmentID INT NOT NULL IDENTITY PRIMARY KEY,
EquipmentName NVARCHAR(14) NOT NULL,
EquipmentDescription NVARCHAR(400) NULL,
Status INT NOT NULL,
MeetingEquipmentCount INT NOT NULL,
MeetingEquipmentFreeCount INT NOT NULL,
Comments NVARCHAR(200) NULL
)
----------------------------------------------------------------------------------------------
GO
CREATE TABLE MeetingAndEquipment--������豸
(
MeetingAndEquipmentID INT NOT NULL IDENTITY PRIMARY KEY,
MeetingApplyFormID INT NOT NULL,
MeetingEquipmentID INT NOT NULL,
MeetingEquipmentCount INT NOT NULL,
Status INT NULL
)
ALTER TABLE MeetingAndEquipment
ADD CONSTRAINT FK_MeetingApplyForm_MeetingAndEquipment FOREIGN KEY(MeetingApplyFormID) REFERENCES MeetingApplyForm(MeetingApplyFormID)
ALTER TABLE MeetingAndEquipment
ADD CONSTRAINT FK_MeetingEquipment_MeetingAndEquipment FOREIGN KEY(MeetingEquipmentID) REFERENCES MeetingEquipment(MeetingEquipmentID)
ALTER TABLE [dbo].MeetingAndEquipment ADD  CONSTRAINT [DF__MeetingAndEquipment__ID__0AD2A005]  DEFAULT (2) FOR [Status]

--------------------------------------------------------------------------------------------------
GO
CREATE TABLE ArchiveMeeting --����浵
(
ArchiveMeetingID INT NOT NULL IDENTITY PRIMARY KEY,
MeetingApplyFormID INT NOT NULL,
[FileName] NVARCHAR(1000) NULL,
FilePath NVARCHAR(1000) NULL
)
ALTER TABLE ArchiveMeeting
ADD CONSTRAINT FK_MeetingApplyForm_ArchiveMeeting FOREIGN KEY(MeetingApplyFormID) REFERENCES MeetingApplyForm(MeetingApplyFormID)
---------------------------------------------------------------------------------------------------
GO
CREATE TABLE [Document]--����
(
DocumentID INT NOT NULL IDENTITY PRIMARY KEY,
DocumentName NVARCHAR(50) NULL,
DocumentPath NVARCHAR(200) NULL,
WFID UNIQUEIDENTIFIER NULL,
DocumentAuthor NVARCHAR(50)
)
----------------------------------------------------------------------------------------------------
GO
CREATE TABLE AutomobileUseForm--������;
(
AutomobileUserFormID INT NOT NULL IDENTITY PRIMARY KEY,
BeginAddress NVARCHAR(1000) NOT NULL,
EndAddress NVARCHAR(1000) NOT NULL,
BeginTime datetime NOT NULL,
EndTime datetime NOT NULL,
UserName NVARCHAR(400) NOT NULL,
Status INT NOT NULL,
Purpose NVARCHAR(1000) NOT NULL
)
------------------------------------------------------------------------------------------------
GO
CREATE TABLE AutomobileUser--����ʹ����
(
AutomobileUserID INT NOT NULL IDENTITY PRIMARY KEY,
UserName NVARCHAR(2000) NOT NULL,
AutomobileUseFormID INT NOT NULL
)
------------------------------------------------------------------------------------------------------
GO
CREATE TABLE [Log]--��־
(
LogID INT NOT NULL IDENTITY PRIMARY KEY,
UserName VARCHAR(50) NULL,
LogType VARCHAR(50) NULL,
LogContent VARCHAR(1000) NULL,
LogTime DATETIME NULL
)
---------------------------------------------------------------------------------------------------
GO
CREATE TABLE Automobile--������
(
AutomobileID INT NOT NULL IDENTITY PRIMARY KEY,
Driver NVARCHAR(2000) NOT NULL,
AutomobileLicensePlace NVARCHAR(2000) NOT NULL,
AutomobileType NVARCHAR(500) NOT NULL,
AutomobileSeatings INT NOT NULL,
AutomobileCapacity INT NOT NULL,
AutomobileStatus INT NOT NULL,
Comments NVARCHAR(1000) NOT NULL
)
------------------------------------------------------------------------------------------------------
GO
CREATE TABLE Activities--��˱�
(
ActID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
ACTTempID UNIQUEIDENTIFIER NULL,
ActName NVARCHAR(50) NULL,
WFID UNIQUEIDENTIFIER NULL,
Owners NVARCHAR(50) NULL,
LastUpdateUser NVARCHAR(50) NULL,
LastUpdateTime datetime NULL,
Status INT NULL
)
ALTER TABLE [dbo].[Activities] ADD  CONSTRAINT [DF__Activitie__ActID__0AD2A005]  DEFAULT (newid()) FOR [ActID]
------------------------------------------------------------------------------------------------
GO
CREATE TABLE WorkflowTemplates--������ģ��
(
WFTID UNIQUEIDENTIFIER NOT NULL,
WFTName NVARCHAR(50) NULL
)
ALTER TABLE [dbo].[WorkflowTemplates] ADD  CONSTRAINT [DF_WorkflowTemplates_WFTID]  DEFAULT (newid()) FOR [WFTID]
---------------------------------------------------------------------------------------
GO
CREATE TABLE DocumentTemplate--����ģ��
(
DocumentTemplateID INT NOT NULL IDENTITY PRIMARY KEY, 
DocumentTemplateName NVARCHAR(50) NULL,
DocumentTemplateDescription NVARCHAR(400) NULL,
DocumentTemplatePath NVARCHAR(100)
)
-------------------------------------------------------------------------------------------------------
GO
CREATE TABLE WorkFlow_Acts--������
(
FromAct UNIQUEIDENTIFIER NOT NULL,
ToAct UNIQUEIDENTIFIER NOT NULL
)
ALTER TABLE WorkFlow_Acts ADD CONSTRAINT pk_WorkFlow_Acts PRIMARY KEY(FromAct,ToAct)
---------------------------------------------------------------------------------------------------
GO
CREATE TABLE WFTActivities--���������
(
ActID UNIQUEIDENTIFIER NOT NULL,
ActName NVARCHAR(50) NULL,
WFTID UNIQUEIDENTIFIER NULL,
Owners NVARCHAR(200)
)
ALTER TABLE [dbo].[WFTActivities] ADD  CONSTRAINT [DF_ActivityTemplates_ActID]  DEFAULT (newid()) FOR [ActID]
-------------------------------------------------------------------------------------------------------
GO
CREATE TABLE DocumentProcessAct--������˴���
(
NodeGuid UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
nodeName NVARCHAR(50) NULL,
nodeRoles NVARCHAR(50) NULL
)
--------------------------------------------------------------------------------------------------------
GO
CREATE TABLE DocumentAndWFT--�ĵ��͹�����ģ��
(
WFTID UNIQUEIDENTIFIER NOT NULL,
DocumentTemplateID INT NOT NULL,
WFTDescription NVARCHAR(400) NULL
)
--------------------------------------------------------------------------------------------------
GO
CREATE TABLE WFT_Acts--������ģ�����
(
FromAct UNIQUEIDENTIFIER NOT NULL,
ToAct UNIQUEIDENTIFIER NOT NULL
)
ALTER TABLE WFT_Acts ADD CONSTRAINT pk_WFT_Acts PRIMARY KEY(FromAct,ToAct)
-------------------------------------------------------------------------------------
GO
CREATE TABLE ReviewAutoApply--�鿴�������״̬
(
RiviewAutoApplyID INT NOT NULL IDENTITY PRIMARY KEY ,
AutomobileUseFormID INT NOT NULL,
ReviewUserName NVARCHAR(500) NOT NULL,
Agree INT NOT NULL
)
---------------------------------------------------------------------------------------
GO
CREATE TABLE MeetingAndUser--�����Ա��
(
MeetingAndUserID INT NOT NULL PRIMARY KEY,
UserName NVARCHAR(2000) NOT NULL,
MeetingApplyFormID INT NOT NULL
)
--------------------------------------------------------------------------------------------
GO
CREATE TABLE AutomobileUse--����ʹ��
(
AutomobileUseID INT NOT NULL IDENTITY PRIMARY KEY,
AutomobileUseFormID INT NOT NULL,
AutomobileID INT NOT NULL
)
ALTER TABLE AutomobileUse
ADD CONSTRAINT FK_AutomobileUseForm_AutomobileUse FOREIGN KEY(AutomobileUseFormID) REFERENCES AutomobileUseForm(AutomobileUserFormID)

------------------------------------
GO
CREATE TRIGGER [Trigger_MeetingAndRoom_MeetingApplyForm]

ON [dbo].[MeetingAndRoom]
FOR INSERT
AS
BEGIN

UPDATE MeetingApplyForm
SET MeetingStatus = 3
FROM MeetingApplyForm MAF,inserted d
WHERE  MAF.MeetingApplyFormID = d.MeetingApplyFormID
END
GO
CREATE TRIGGER [Trigger_MeetingAndRoom_MeetingRoom]
ON [dbo].[MeetingAndRoom]
FOR INSERT
AS
BEGIN
UPDATE MeetingRoom
SET MeetingRoomStatus = 1
FROM MeetingRoom r,inserted  d
WHERE r.MeetingRoomID = d.MeetingRoomID
END
GO
CREATE TRIGGER [ReviewApply_ApplyForm] ON [dbo].[MeetingApplyForm] 
FOR INSERT
AS
BEGIN
INSERT INTO [ReviewMeetingApply]
(MeetingApplyFormID)
SELECT inserted.MeetingApplyFormID FROM INSERTED
END
go
CREATE TRIGGER [Trigger_ReviewMeeting_MeetingForm]
ON [dbo].[ReviewMeetingApply]
FOR UPDATE
AS
IF
UPDATE (Agree)
BEGIN
UPDATE MeetingApplyForm
SET MeetingStatus = d.Agree
FROM MeetingApplyForm MAF,inserted d
WHERE  MAF.MeetingApplyFormID = d.MeetingApplyFormID
END
Go
create trigger tr_MeetingEquipment_status---------���»����豸״̬
on MeetingEquipment
after insert
as
update MeetingEquipment set Status=3
from inserted
where
MeetingEquipment.MeetingEquipmentID=inserted.MeetingEquipmentID
insert into dbo.MeetingEquipment(EquipmentName,EquipmentDescription,MeetingEquipmentCount,
MeetingEquipmentFreeCount,Comments) values('aaaaa','',100,50,'')



/*==============================================================*/
/* Table: ArchiveUserCarApply                                   */
/*==============================================================*/
create table ArchiveUserCarApply (
   ArchiveUserCarID     int                  not null,
   UseCarApplyFormID    int                  not null,
   FileName             nvarchar(100)        not null,
   FilePath             nvarchar(200)        not null
)
go

alter table ArchiveUserCarApply
   add constraint PK_ARCHIVEUSERCARAPPLY primary key (ArchiveUserCarID)
go

/*==============================================================*/
/* Table: Car                                                   */
/*==============================================================*/
create table Car (
   CarId                int                  not null,
   UseCarTypeID         int                  not null,
   DriverEmail          nvarchar(50)         not null,
   Driver               nvarchar(50)         not null,
   LicenseNumber        nvarchar(50)         not null,
   ModelNumber          nvarchar(50)         not null,
   SeatingNumber        int                  not null,
   CarTypeID            int                  not null,
   Status               int                  null,
   LoadCapacity         nvarchar(200)        not null,
   Comment              nvarchar(200)        null
)
go

alter table Car
   add constraint PK_CAR primary key (CarId)
go

/*==============================================================*/
/* Table: ReviewUseCarApplyID                                   */
/*==============================================================*/
create table ReviewUseCarApplyID (
   ReviewUseCarApplyID  int                  not null,
   UseCarApplyFormID    int                  not null,
   ReviewUserName       nvarchar(20)         not null,
   Agree                int         not null
)
go

alter table ReviewUseCarApplyID
   add constraint PK_REVIEWUSECARAPPLYID primary key (ReviewUseCarApplyID)
go

/*==============================================================*/
/* Table: UseCarAndUser                                         */
/*==============================================================*/
create table UseCarAndUser (
   UseCarUserId         int                  not null,
   UseCarApplyFormID    int                  not null,
   Name                 nvarchar(20)         not null,
   Email                nvarchar(50)         not null
)
go

alter table UseCarAndUser
   add constraint PK_USECARANDUSER primary key (UseCarUserId)
go

/*==============================================================*/
/* Table: UseCarApplyForm                                       */
/*==============================================================*/
create table UseCarApplyForm (
   UseCarApplyFormID    int                  not null,
   ApplyUserName        nvarchar(20)         not null,
   UseCarTypeID         int                  not null,
   BeginTime            datetime             not null default null,
   EndTime              datetime             not null,
   StartDestination     nvarchar(20)         not null,
   EndDestination       nvarchar(20)         not null,
   ApplyStatus          int                  not null,
   WFID                 int                  not null,
   ApplyReason          nvarchar(500)        not null,
   Comment              nvarchar(200)        null
)
go

alter table UseCarApplyForm
   add constraint PK_USECARAPPLYFORM primary key (UseCarApplyFormID)
go

/*==============================================================*/
/* Table: UseCarType                                            */
/*==============================================================*/
create table UseCarType (
   UseCarTypeID         int                  not null,
   UseCarTypeName       nvarchar(20)         not null
)
go

alter table UseCarType
   add constraint PK_USECARTYPE primary key (UseCarTypeID)
go

alter table ArchiveUserCarApply
   add constraint FK_ARCHIVEU_REFERENCE_USECARAP foreign key (UseCarApplyFormID)
      references UseCarApplyForm (UseCarApplyFormID)
go

alter table Car
   add constraint FK_CAR_REFERENCE_USECARTY foreign key (UseCarTypeID)
      references UseCarType (UseCarTypeID)
go

alter table ReviewUseCarApplyID
   add constraint FK_REVIEWUS_REFERENCE_USECARAP foreign key (UseCarApplyFormID)
      references UseCarApplyForm (UseCarApplyFormID)
go

alter table UseCarAndUser
   add constraint FK_USECARAN_REFERENCE_USECARAP foreign key (UseCarApplyFormID)
      references UseCarApplyForm (UseCarApplyFormID)
go

alter table UseCarApplyForm
   add constraint FK_USECARAP_REFERENCE_USECARTY foreign key (UseCarTypeID)
      references UseCarType (UseCarTypeID)
go

