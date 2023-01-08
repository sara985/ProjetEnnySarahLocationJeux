USE [master]
GO
/****** Object:  Database [GameSwitch]    Script Date: 08-01-23 14:05:49 ******/
CREATE DATABASE [GameSwitch]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 08-01-23 14:05:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GameSwitch].[dbo].[Admin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[email] [varchar](300) NOT NULL,
	[password] [varchar](80) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [email_unique_admin] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [username_unique_admin] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 08-01-23 14:05:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GameSwitch].[dbo].[Booking](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[borrowerId] [int] NOT NULL,
	[gameId] [int] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[durationInWeeks] [int] NOT NULL,
	[bookingDate] [date] NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Console]    Script Date: 08-01-23 14:05:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GameSwitch].[dbo].[Console](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Console] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Copy]    Script Date: 08-01-23 14:05:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GameSwitch].[dbo].[Copy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ownerId] [int] NOT NULL,
	[isAvailable] [bit] NOT NULL,
	[gameId] [int] NOT NULL,
 CONSTRAINT [PK_Copy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 08-01-23 14:05:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GameSwitch].[dbo].[Game](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[year] [int] NULL,
	[creditsValued] [int] NOT NULL,
	[consoleAndVersion] [varchar](80) NOT NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 08-01-23 14:05:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GameSwitch].[dbo].[Image](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[image] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loan]    Script Date: 08-01-23 14:05:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GameSwitch].[dbo].[Loan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[copyId] [int] NOT NULL,
	[borrowerId] [int] NOT NULL,
	[startDate] [date] NOT NULL,
	[endDate] [date] NOT NULL,
	[effectiveEndDate] [date] NULL,
	[creditsValued] [int] NOT NULL,
	[total] [int] NULL,
 CONSTRAINT [PK_Loan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 08-01-23 14:05:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GameSwitch].[dbo].[Player](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](80) NOT NULL,
	[balance] [int] NOT NULL,
	[signUpDate] [date] NOT NULL,
	[birthDate] [date] NOT NULL,
	[firstName] [varchar](50) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[email] [varchar](250) NOT NULL,
	[hadBirthdayCredit] [bit] NOT NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [email_unique] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [username_unique] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Version]    Script Date: 08-01-23 14:05:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GameSwitch].[dbo].[Version](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[consoleId] [int] NOT NULL,
	[version] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Version] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Player]    Script Date: 08-01-23 14:05:49 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Player] ON [GameSwitch].[dbo].[Player]
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Player_1]    Script Date: 08-01-23 14:05:49 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Player_1] ON [GameSwitch].[dbo].[Player]
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [GameSwitch].[dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Copy] FOREIGN KEY([gameId])
REFERENCES [GameSwitch].[dbo].[Game] ([id])
GO
ALTER TABLE [GameSwitch].[dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Copy]
GO
ALTER TABLE [GameSwitch].[dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Player] FOREIGN KEY([borrowerId])
REFERENCES [GameSwitch].[dbo].[Player] ([id])
GO
ALTER TABLE [GameSwitch].[dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Player]
GO
ALTER TABLE [GameSwitch].[dbo].[Copy]  WITH CHECK ADD  CONSTRAINT [FK_Copy_Game] FOREIGN KEY([gameId])
REFERENCES [GameSwitch].[dbo].[Game] ([id])
GO
ALTER TABLE [dbo].[Copy] CHECK CONSTRAINT [FK_Copy_Game]
GO
ALTER TABLE [GameSwitch].[dbo].[Copy]  WITH CHECK ADD  CONSTRAINT [FK_Copy_Player] FOREIGN KEY([ownerId])
REFERENCES [GameSwitch].[dbo].[Player] ([id])
GO
ALTER TABLE [GameSwitch].[dbo].[Copy] CHECK CONSTRAINT [FK_Copy_Player]
GO
ALTER TABLE [GameSwitch].[dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_Copy] FOREIGN KEY([copyId])
REFERENCES [GameSwitch].[dbo].[Copy] ([id])
GO
ALTER TABLE [GameSwitch].[dbo].[Loan] CHECK CONSTRAINT [FK_Loan_Copy]
GO
ALTER TABLE [GameSwitch].[dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_Player] FOREIGN KEY([borrowerId])
REFERENCES [GameSwitch].[dbo].[Player] ([id])
GO
ALTER TABLE [GameSwitch].[dbo].[Loan] CHECK CONSTRAINT [FK_Loan_Player]
GO
ALTER TABLE [GameSwitch].[dbo].[Version]  WITH CHECK ADD  CONSTRAINT [FK_Version_Console] FOREIGN KEY([consoleId])
REFERENCES [GameSwitch].[dbo].[Console] ([id])
GO
ALTER TABLE [GameSwitch].[dbo].[Version] CHECK CONSTRAINT [FK_Version_Console]
GO

Insert into [GameSwitch].[dbo].[Player] VALUES('sarah', 'ghhMyiXGh8HShKZva2r5S8OIiRBjcZwFU43A3QpAnKU=', 10, '2022-01-21','2000-01-13', 'Sarah','Coquereau','sarah@gmail.com', 0);
Insert into [GameSwitch].[dbo].[Player] VALUES('enny', 'ghhMyiXGh8HShKZva2r5S8OIiRBjcZwFU43A3QpAnKU=', 10, '2022-01-05','2000-02-13', 'Enny','Frans','enny@gmail.com', 0);

insert into [GameSwitch].[dbo].Admin values('admin','admin@gmail.com','condorcet')

insert into [GameSwitch].[dbo].[Console] values('Xbox');
insert into [GameSwitch].[dbo].[Console] values('PlayStation');

insert into [GameSwitch].[dbo].[Version] values(1,'360');
insert into [GameSwitch].[dbo].[Version] values(1,'One');
insert into [GameSwitch].[dbo].[Version] values(2,'4');
insert into [GameSwitch].[dbo].[Version] values(2,'5');

insert into [GameSwitch].[dbo].[Game] values('Zelda', 2006, 4,'Xbox 360')
insert into [GameSwitch].[dbo].[Game] values('MarioKart', 2008, 3,'Xbox One')
insert into [GameSwitch].[dbo].[Game] values('Kingsman', 2012, 4,'PlayStation 4')
insert into [GameSwitch].[dbo].[Game] values('Sonic Colors', 2021, 4,'PlayStation 5')

insert into [GameSwitch].[dbo].[Copy] VALUES(1,1,3)
insert into [GameSwitch].[dbo].[Copy] VALUES(1,1,2)
insert into [GameSwitch].[dbo].[Copy] VALUES(2,1,2)
insert into [GameSwitch].[dbo].[Copy] VALUES(2,1,1)

insert into [GameSwitch].[dbo].[Loan] VALUES(2,1,'2022-01-01','2022-01-14','2022-01-14',3,6)
insert into [GameSwitch].[dbo].[Loan] VALUES(2,1,'2021-11-03','2022-11-16','2022-01-14',4,8)

