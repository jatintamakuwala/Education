CREATE DATABASE EDUCATION
go

USE [Education]
GO
/****** Object:  Table [dbo].[ClassMst]    Script Date: 05/01/2013 15:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassMst](
	[ClassMstID] [bigint] IDENTITY(1,1) NOT NULL,
	[ClassMstName] [varchar](150) NOT NULL,
 CONSTRAINT [PK_ClassMst] PRIMARY KEY CLUSTERED 
(
	[ClassMstID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ClassMst] ON
INSERT [dbo].[ClassMst] ([ClassMstID], [ClassMstName]) VALUES (1, N'Mathematics')
INSERT [dbo].[ClassMst] ([ClassMstID], [ClassMstName]) VALUES (2, N'Physics')
SET IDENTITY_INSERT [dbo].[ClassMst] OFF
/****** Object:  Table [dbo].[Student]    Script Date: 05/01/2013 15:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [bigint] IDENTITY(100,1) NOT NULL,
	[FirstName] [varchar](75) NOT NULL,
	[LastName] [varchar](100) NULL,
	[ClassMstID] [bigint] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [ClassMstID]) VALUES (101, N'Mukesh', N'Kalgude', 1)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [ClassMstID]) VALUES (102, N'Sufiyan', N'Mansur', 2)
INSERT [dbo].[Student] ([StudentID], [FirstName], [LastName], [ClassMstID]) VALUES (103, N'Rajnikant', N'Rana', 1)
SET IDENTITY_INSERT [dbo].[Student] OFF
/****** Object:  Table [dbo].[Professor]    Script Date: 05/01/2013 15:49:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Professor](
	[ProfessorID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](75) NOT NULL,
	[LastName] [varchar](100) NULL,
	[ClassMstID] [bigint] NOT NULL,
 CONSTRAINT [PK_Professor] PRIMARY KEY CLUSTERED 
(
	[ProfessorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Professor] ON
INSERT [dbo].[Professor] ([ProfessorID], [FirstName], [LastName], [ClassMstID]) VALUES (2, N'Jignesh', N'Rupawala', 1)
INSERT [dbo].[Professor] ([ProfessorID], [FirstName], [LastName], [ClassMstID]) VALUES (3, N'Shailesh', N'Sakaria', 2)
SET IDENTITY_INSERT [dbo].[Professor] OFF
/****** Object:  ForeignKey [FK_Professor_ClassMst]    Script Date: 05/01/2013 15:49:21 ******/
ALTER TABLE [dbo].[Professor]  WITH CHECK ADD  CONSTRAINT [FK_Professor_ClassMst] FOREIGN KEY([ClassMstID])
REFERENCES [dbo].[ClassMst] ([ClassMstID])
GO
ALTER TABLE [dbo].[Professor] CHECK CONSTRAINT [FK_Professor_ClassMst]
GO
/****** Object:  ForeignKey [FK_Student_ClassMst]    Script Date: 05/01/2013 15:49:21 ******/
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_ClassMst] FOREIGN KEY([ClassMstID])
REFERENCES [dbo].[ClassMst] ([ClassMstID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_ClassMst]
GO
