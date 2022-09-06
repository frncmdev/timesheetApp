create table [Teacher] (
    [TeacherID] NVARCHAR(32) PRIMARY KEY,
    [FirstName] NVARCHAR(50) not null,
    [SurName] NVARCHAR(50) not null,
    [Email] NVARCHAR(100) not null UNIQUE,
    [PASSWORD] BINARY(64) not null,
    [DateCreated] DATETIME not null,
    [Salt] NVARCHAR(32) not null UNIQUE,
    CONSTRAINT EMAIL_LIKE_REGEX
        check(Email like '%__@%.%')
)

create table [Class] (
    ClassID NVARCHAR(32) PRIMARY KEY,
    ClassName NVARCHAR(50) not null,
    ClassDescription NVARCHAR(200) not null,
)
create table [student] (
    [StudentID] INT PRIMARY KEY,
    [FirstName] NVARCHAR(50) not null,
    [SurName] NVARCHAR(50) not null,
    [Email] NVARCHAR(100) not null UNIQUE,
    [PASSWORD] binary(64) not null,
    [Salt] NVARCHAR(32) not null unique,
    [DateCreated] DATETIME not null
    CONSTRAINT EMAIL_LIKE_REGEX
        check(Email like '%__@%.%')
  
)
create table [Timesheet] (
    timesheetID NVARCHAR(32) PRIMARY KEY,
    [Date] DATETIME NOT NULL,
    [checked] bit,
    isValid bit,
    studentID int not null, 
    Email NVARCHAR(100) not NULL UNIQUE,
    CONSTRAINT EMAIL_LIKE_REGEX
        check(Email like '%__@%.%'),
    CONSTRAINT FK_Student foreign KEY (studentID) REFERENCES [student]
)
create table [task] (
    TaskID int IDENTITY(1,1) PRIMARY KEY,
    taskName NVARCHAR(50) not null,
    taskDescription NVARCHAR(200),
)
create table [TaskLine]
(
    TimeDone int not null,
    TaskID int not NULL,
    TimeSheetID NVARCHAR(32) not null,
    CONSTRAINT FK_TASKID
        FOREIGN KEY (taskid) REFERENCES task,
    CONSTRAINT FK_TIMESHEETID
        FOREIGN key (timesheetID) REFERENCES timesheet,
    constraint PK PRIMARY key(TaskID, TimeSheetID)
)
create table TeacherClassAllocation
(
    TeacherID NVARCHAR(32) not null,
    classID nvarchar(32) not NULL,
    CONSTRAINT FK_TEACHERID
        FOREIGN KEY (TeacherID) REFERENCES Teacher,
    CONSTRAINT FK_ClassID
        FOREIGN key (ClassID) REFERENCES [CLASS],
    constraint PK PRIMARY key(TeacherID, ClassID)
)
create table ClassStudentAllocation
(
    classID nvarchar(32) not null,
    StudentID int not null,
    CONSTRAINT FK_StudentID
        FOREIGN KEY (StudentID) REFERENCES student,
    CONSTRAINT FK_TIMESHEETID
        FOREIGN key (classID) REFERENCES [CLASS],
    constraint PK PRIMARY key(classid, studentID)
)