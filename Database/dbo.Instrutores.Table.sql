USE [GerenciadorLives]
GO
/****** Object:  Table [dbo].[Instrutores]    Script Date: 01/03/2021 15:19:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instrutores](
	[InstrutorID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Instagram] [nvarchar](max) NULL,
	[DataNascimento] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Instrutores] PRIMARY KEY CLUSTERED 
(
	[InstrutorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Instrutores] ON 

INSERT [dbo].[Instrutores] ([InstrutorID], [Nome], [Email], [Instagram], [DataNascimento]) VALUES (1, N'Tia', N'tia@teste.com', N'@tiatiatia', CAST(N'2004-11-10T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Instrutores] ([InstrutorID], [Nome], [Email], [Instagram], [DataNascimento]) VALUES (2, N'José', N'Alexander@aaa', N'Alexander', CAST(N'1975-08-04T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Instrutores] ([InstrutorID], [Nome], [Email], [Instagram], [DataNascimento]) VALUES (3, N'Bob Ross', N'bob@ross.com', N'@bobross', CAST(N'1940-07-15T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Instrutores] OFF
GO
