USE [Casino]
GO
/****** Object:  Table [dbo].[Games]    Script Date: 20.09.2024 19:13:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Games](
	[Game_Id] [int] IDENTITY(121,1) NOT NULL,
	[Game_Date] [date] NOT NULL,
	[Game_Stavka] [nvarchar](50) NOT NULL,
	[Game_Result] [nvarchar](50) NOT NULL,
	[Game_Bet] [int] NOT NULL,
	[Win] [nvarchar](50) NOT NULL,
	[User_Id] [int] NOT NULL,
	[Win_Count] [int] NOT NULL,
 CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED 
(
	[Game_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 20.09.2024 19:13:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Payment_Id] [int] IDENTITY(10,1) NOT NULL,
	[TypePay] [nvarchar](50) NOT NULL,
	[MethodPay] [nvarchar](50) NOT NULL,
	[User_Id] [int] NOT NULL,
	[Count] [int] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Payment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Podkrut]    Script Date: 20.09.2024 19:13:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Podkrut](
	[podkrut] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Session]    Script Date: 20.09.2024 19:13:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[Session_Id] [int] IDENTITY(300,1) NOT NULL,
	[Start] [date] NOT NULL,
	[Session_End] [date] NOT NULL,
	[User_Id] [int] NOT NULL,
	[Games_Count] [int] NOT NULL,
	[Winnig_Count] [int] NOT NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[Session_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20.09.2024 19:13:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id_User] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NULL,
	[Balance] [int] NULL,
	[Chance] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Games] ON 

INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (121, CAST(N'2024-09-15' AS Date), N'2', N'20', 5000, N'Поражение', 1, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (122, CAST(N'2024-09-15' AS Date), N'2', N'31', 5000, N'Поражение', 1, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (124, CAST(N'2024-09-15' AS Date), N'red', N'8', 5000, N'Поражение', 1, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (126, CAST(N'2024-09-15' AS Date), N'red', N'5', 6000, N'Победа', 1, 12000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (130, CAST(N'2024-09-15' AS Date), N'red', N'14', 1000, N'Победа', 1, 2000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (133, CAST(N'2024-09-15' AS Date), N'black', N'31', 1000, N'Победа', 2, 2000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (134, CAST(N'2024-09-15' AS Date), N'0', N'2', 1000, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (135, CAST(N'2024-09-15' AS Date), N'0', N'9', 1000, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (1123, CAST(N'2024-09-16' AS Date), N'red', N'9', 5000, N'Победа', 4, 10000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (2123, CAST(N'2024-09-16' AS Date), N'black', N'32', 1000, N'Поражение', 4, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (2124, CAST(N'2024-09-16' AS Date), N'red', N'31', 1000, N'Поражение', 4, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (2125, CAST(N'2024-09-16' AS Date), N'0', N'10', 1000, N'', 4, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (3123, CAST(N'2024-09-16' AS Date), N'black', N'17', 1000, N'Победа', 1, 2000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4123, CAST(N'2024-09-19' AS Date), N'red', N'32', 1000, N'Победа', 2, 2000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4124, CAST(N'2024-09-19' AS Date), N'black', N'23', 1000, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4125, CAST(N'2024-09-19' AS Date), N'red', N'22', 1000, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4126, CAST(N'2024-09-19' AS Date), N'red', N'15', 1000, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4127, CAST(N'2024-09-19' AS Date), N'black', N'23', 1000, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4128, CAST(N'2024-09-19' AS Date), N'red', N'23', 1000, N'Победа', 2, 2000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4129, CAST(N'2024-09-19' AS Date), N'1', N'33', 1000, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4130, CAST(N'2024-09-19' AS Date), N'1', N'28', 100, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4131, CAST(N'2024-09-19' AS Date), N'red', N'7', 1000, N'Победа', 2, 2000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4132, CAST(N'2024-09-19' AS Date), N'red', N'3', 5000, N'Победа', 3, 10000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4133, CAST(N'2024-09-19' AS Date), N'black', N'26', 1000, N'Победа', 3, 2000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4134, CAST(N'2024-09-19' AS Date), N'1', N'32', 1000, N'Поражение', 3, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4135, CAST(N'2024-09-19' AS Date), N'0', N'9', 1000, N'Поражение', 3, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4136, CAST(N'2024-09-19' AS Date), N'1', N'32', 500, N'Поражение', 3, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4137, CAST(N'2024-09-19' AS Date), N'7', N'16', 500, N'Поражение', 3, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4138, CAST(N'2024-09-19' AS Date), N'13', N'11', 1000, N'Поражение', 3, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4139, CAST(N'2024-09-19' AS Date), N'16', N'12', 1000, N'Поражение', 3, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4140, CAST(N'2024-09-19' AS Date), N'10', N'10', 500, N'Победа', 3, 2500)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4141, CAST(N'2024-09-19' AS Date), N'1', N'4', 1000, N'Поражение', 1, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4142, CAST(N'2024-09-19' AS Date), N'1', N'1', 1000, N'Победа', 1, 3000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (4143, CAST(N'2024-09-19' AS Date), N'7', N'7', 5000, N'Победа', 1, 15000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5123, CAST(N'2024-09-20' AS Date), N'10', N'10', 5000, N'Победа', 1, 15000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5124, CAST(N'2024-09-20' AS Date), N'16', N'32', 1000, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5125, CAST(N'2024-09-20' AS Date), N'black', N'31', 1000, N'Победа', 2, 2000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5126, CAST(N'2024-09-20' AS Date), N'red', N'13', 500, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5127, CAST(N'2024-09-20' AS Date), N'10', N'6', 500, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5128, CAST(N'2024-09-20' AS Date), N'1', N'1', 20, N'Победа', 2, 60)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5129, CAST(N'2024-09-20' AS Date), N'red', N'35', 100, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5130, CAST(N'2024-09-20' AS Date), N'red', N'19', 1000, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5131, CAST(N'2024-09-20' AS Date), N'4', N'22', 1000, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5132, CAST(N'2024-09-20' AS Date), N'1', N'1', 1000, N'Победа', 1, 3000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5133, CAST(N'2024-09-20' AS Date), N'10', N'10', 1000, N'Победа', 1, 3000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5134, CAST(N'2024-09-20' AS Date), N'7', N'7', 1000, N'Победа', 2, 3000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5135, CAST(N'2024-09-20' AS Date), N'black', N'18', 1000, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5136, CAST(N'2024-09-20' AS Date), N'red', N'27', 1000, N'Победа', 2, 2000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5137, CAST(N'2024-09-20' AS Date), N'7', N'19', 1000, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5138, CAST(N'2024-09-20' AS Date), N'13', N'0', 1000, N'Поражение', 1, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5139, CAST(N'2024-09-20' AS Date), N'19', N'6', 1000, N'Поражение', 1, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5140, CAST(N'2024-09-20' AS Date), N'10', N'10', 1000, N'Победа', 1, 3000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5141, CAST(N'2024-09-20' AS Date), N'10', N'14', 500, N'Поражение', 1, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5142, CAST(N'2024-09-20' AS Date), N'red', N'30', 1000, N'Победа', 1, 2000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5143, CAST(N'2024-09-20' AS Date), N'black', N'12', 5000, N'Поражение', 1, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5144, CAST(N'2024-09-20' AS Date), N'1', N'1', 500, N'Победа', 1, 1500)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5145, CAST(N'2024-09-20' AS Date), N'2', N'2', 500, N'Победа', 1, 1500)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5146, CAST(N'2024-09-20' AS Date), N'3', N'1', 500, N'Поражение', 1, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5147, CAST(N'2024-09-20' AS Date), N'1', N'1', 500, N'Победа', 1, 1500)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5148, CAST(N'2024-09-20' AS Date), N'4', N'4', 1000, N'Победа', 1, 3000)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (5149, CAST(N'2024-09-20' AS Date), N'19', N'24', 23500, N'Поражение', 2, 0)
INSERT [dbo].[Games] ([Game_Id], [Game_Date], [Game_Stavka], [Game_Result], [Game_Bet], [Win], [User_Id], [Win_Count]) VALUES (6123, CAST(N'2024-09-20' AS Date), N'red', N'10', 5000, N'Поражение', 2, 0)
SET IDENTITY_INSERT [dbo].[Games] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (14, N'Оплата', N'СБП', 1, 123)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (15, N'Оплата', N'Тинькофф (****4103)', 2, 132)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (16, N'Списание', N'Тинькофф (****4103)', 2, 132)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (17, N'Оплата', N'СБП', 2, 1000)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (1011, N'Оплата', N'Альфа (****5469)', 2, 12000)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (2013, N'Оплата', N'СБП', 4, 15000)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (2014, N'Оплата', N'СБП', 1, 1000)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (2015, N'Списание', N'Тинькофф (****4103)', 1, 1000)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (3011, N'Списание', N'Тинькофф (****4103)', 1, 1000)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (3012, N'Списание', N'СБП', 1, 1500)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (4011, N'Оплата', N'Тинькофф (****4103)', 2, 5000)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (4012, N'Оплата', N'Тинькофф (****4103)', 3, 20000)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (4013, N'Списание', N'Тинькофф (****4103)', 3, 2)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (4014, N'Списание', N'Тинькофф (****4103)', 3, 200)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (4015, N'Оплата', N'Тинькофф (****4103)', 3, 2000)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (5011, N'Оплата', N'СБП', 1, 123)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (6011, N'Оплата', N'Тинькофф (****4103)', 2, 5000)
INSERT [dbo].[Payments] ([Payment_Id], [TypePay], [MethodPay], [User_Id], [Count]) VALUES (6012, N'Оплата', N'СБП', 2, 10000)
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
INSERT [dbo].[Podkrut] ([podkrut]) VALUES (15)
GO
SET IDENTITY_INSERT [dbo].[Session] ON 

INSERT [dbo].[Session] ([Session_Id], [Start], [Session_End], [User_Id], [Games_Count], [Winnig_Count]) VALUES (300, CAST(N'2024-09-16' AS Date), CAST(N'2024-09-16' AS Date), 1, 1, 1)
INSERT [dbo].[Session] ([Session_Id], [Start], [Session_End], [User_Id], [Games_Count], [Winnig_Count]) VALUES (301, CAST(N'2024-09-16' AS Date), CAST(N'2024-09-16' AS Date), 1, 0, 0)
INSERT [dbo].[Session] ([Session_Id], [Start], [Session_End], [User_Id], [Games_Count], [Winnig_Count]) VALUES (1301, CAST(N'2024-09-19' AS Date), CAST(N'2024-09-19' AS Date), 1, 0, 0)
INSERT [dbo].[Session] ([Session_Id], [Start], [Session_End], [User_Id], [Games_Count], [Winnig_Count]) VALUES (1302, CAST(N'2024-09-19' AS Date), CAST(N'2024-09-19' AS Date), 1, 1, 1)
INSERT [dbo].[Session] ([Session_Id], [Start], [Session_End], [User_Id], [Games_Count], [Winnig_Count]) VALUES (2301, CAST(N'2024-09-20' AS Date), CAST(N'2024-09-20' AS Date), 2, 2, 1)
INSERT [dbo].[Session] ([Session_Id], [Start], [Session_End], [User_Id], [Games_Count], [Winnig_Count]) VALUES (2302, CAST(N'2024-09-20' AS Date), CAST(N'2024-09-20' AS Date), 2, 3, 1)
INSERT [dbo].[Session] ([Session_Id], [Start], [Session_End], [User_Id], [Games_Count], [Winnig_Count]) VALUES (2303, CAST(N'2024-09-20' AS Date), CAST(N'2024-09-20' AS Date), 2, 3, 0)
INSERT [dbo].[Session] ([Session_Id], [Start], [Session_End], [User_Id], [Games_Count], [Winnig_Count]) VALUES (2304, CAST(N'2024-09-20' AS Date), CAST(N'2024-09-20' AS Date), 2, 0, 0)
INSERT [dbo].[Session] ([Session_Id], [Start], [Session_End], [User_Id], [Games_Count], [Winnig_Count]) VALUES (2305, CAST(N'2024-09-20' AS Date), CAST(N'2024-09-20' AS Date), 1, 2, 1)
INSERT [dbo].[Session] ([Session_Id], [Start], [Session_End], [User_Id], [Games_Count], [Winnig_Count]) VALUES (2306, CAST(N'2024-09-20' AS Date), CAST(N'2024-09-20' AS Date), 1, 1, 0)
INSERT [dbo].[Session] ([Session_Id], [Start], [Session_End], [User_Id], [Games_Count], [Winnig_Count]) VALUES (2307, CAST(N'2024-09-20' AS Date), CAST(N'2024-09-20' AS Date), 1, 3, 2)
INSERT [dbo].[Session] ([Session_Id], [Start], [Session_End], [User_Id], [Games_Count], [Winnig_Count]) VALUES (2308, CAST(N'2024-09-20' AS Date), CAST(N'2024-09-20' AS Date), 2, 1, 0)
INSERT [dbo].[Session] ([Session_Id], [Start], [Session_End], [User_Id], [Games_Count], [Winnig_Count]) VALUES (3301, CAST(N'2024-09-20' AS Date), CAST(N'2024-09-20' AS Date), 2, 1, 0)
SET IDENTITY_INSERT [dbo].[Session] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id_User], [Name], [Login], [Password], [Role], [Balance], [Chance]) VALUES (1, N'Fara', N'fara', N'123', N'admin', 113622, 100)
INSERT [dbo].[Users] ([Id_User], [Name], [Login], [Password], [Role], [Balance], [Chance]) VALUES (2, N'User', N'user', N'123', N'user', 5360, 15)
INSERT [dbo].[Users] ([Id_User], [Name], [Login], [Password], [Role], [Balance], [Chance]) VALUES (3, N'ildar123', N'ildar123', N'ildar123', N'admin', 21298, 25)
INSERT [dbo].[Users] ([Id_User], [Name], [Login], [Password], [Role], [Balance], [Chance]) VALUES (4, N'test', N'test', N'123', N'admin', 13000, 25)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Games]  WITH CHECK ADD  CONSTRAINT [FK_Games_Users] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id_User])
GO
ALTER TABLE [dbo].[Games] CHECK CONSTRAINT [FK_Games_Users]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Users] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id_User])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Users]
GO
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Users] FOREIGN KEY([User_Id])
REFERENCES [dbo].[Users] ([Id_User])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Users]
GO
