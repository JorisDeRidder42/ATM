USE [r0844674]
GO

/****** Object:  Table [dbo].[Accounts]    Script Date: 14/08/2022 19:19:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Accounts](
	[AccountID] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](max) NOT NULL,
	[AccountAmount] [int] NOT NULL,
	[TransactionID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Accounts_dbo.Clients_ClientID] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_dbo.Accounts_dbo.Clients_ClientID]
GO

ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Accounts_dbo.Transactions_TransactionID] FOREIGN KEY([TransactionID])
REFERENCES [dbo].[Transactions] ([TransactionID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_dbo.Accounts_dbo.Transactions_TransactionID]
GO

USE [r0844674]
GO

/****** Object:  Table [dbo].[CardAccounts]    Script Date: 14/08/2022 19:19:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CardAccounts](
	[CardAccountID] [int] IDENTITY(1,1) NOT NULL,
	[CardID] [int] NOT NULL,
	[AccountID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CardAccounts] PRIMARY KEY CLUSTERED 
(
	[CardAccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CardAccounts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CardAccounts_dbo.Accounts_AccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accounts] ([AccountID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CardAccounts] CHECK CONSTRAINT [FK_dbo.CardAccounts_dbo.Accounts_AccountID]
GO

ALTER TABLE [dbo].[CardAccounts]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CardAccounts_dbo.Cards_CardID] FOREIGN KEY([CardID])
REFERENCES [dbo].[Cards] ([CardID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CardAccounts] CHECK CONSTRAINT [FK_dbo.CardAccounts_dbo.Cards_CardID]
GO

USE [r0844674]
GO

/****** Object:  Table [dbo].[Cards]    Script Date: 14/08/2022 19:20:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cards](
	[CardID] [int] IDENTITY(1,1) NOT NULL,
	[CardName] [nvarchar](max) NOT NULL,
	[CardTypeID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Cards] PRIMARY KEY CLUSTERED 
(
	[CardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cards]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cards_dbo.CardTypes_CardTypeID] FOREIGN KEY([CardTypeID])
REFERENCES [dbo].[CardTypes] ([CardTypeID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Cards] CHECK CONSTRAINT [FK_dbo.Cards_dbo.CardTypes_CardTypeID]
GO

USE [r0844674]
GO

/****** Object:  Table [dbo].[CardTypes]    Script Date: 14/08/2022 19:20:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CardTypes](
	[CardTypeID] [int] IDENTITY(1,1) NOT NULL,
	[CardTypeName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.CardTypes] PRIMARY KEY CLUSTERED 
(
	[CardTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [r0844674]
GO

/****** Object:  Table [dbo].[Clients]    Script Date: 14/08/2022 19:20:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clients](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](max) NOT NULL,
	[ClientEmail] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[ConfirmPassword] [nvarchar](max) NOT NULL,
	[Country] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[Street] [nvarchar](max) NOT NULL,
	[HouseNumber] [nvarchar](max) NOT NULL,
	[ZipCode] [nvarchar](max) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[BirthDate] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Clients] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [r0844674]
GO

/****** Object:  Table [dbo].[Transactions]    Script Date: 14/08/2022 19:20:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionAmount] [int] NOT NULL,
	[TransactionTypeID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Transactions] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Transactions_dbo.TransactionTypes_TransactionTypeID] FOREIGN KEY([TransactionTypeID])
REFERENCES [dbo].[TransactionTypes] ([TransActionTypeID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_dbo.Transactions_dbo.TransactionTypes_TransactionTypeID]
GO

USE [r0844674]
GO

/****** Object:  Table [dbo].[TransactionTypes]    Script Date: 14/08/2022 19:20:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TransactionTypes](
	[TransActionTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionTypeName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.TransactionTypes] PRIMARY KEY CLUSTERED 
(
	[TransActionTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO




