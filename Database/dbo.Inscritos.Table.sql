USE [GerenciadorLives]
GO
/****** Object:  Table [dbo].[Inscritos]    Script Date: 01/03/2021 15:19:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscritos](
	[InscritoId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Instagram] [nvarchar](max) NULL,
	[DataNascimento] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Inscritos] PRIMARY KEY CLUSTERED 
(
	[InscritoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Inscritos] ON 

INSERT [dbo].[Inscritos] ([InscritoId], [Nome], [Email], [Instagram], [DataNascimento]) VALUES (1, N'Joao', N'joao@testeemail.com', N'@joaozin', CAST(N'1985-02-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Inscritos] ([InscritoId], [Nome], [Email], [Instagram], [DataNascimento]) VALUES (2, N'Maria', N'radiotiva@nobel.com', N'@tobrilhando', CAST(N'1930-09-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Inscritos] ([InscritoId], [Nome], [Email], [Instagram], [DataNascimento]) VALUES (3, N'Carl', N'sagan@space.com', N'@casquinhadenoz', CAST(N'1940-05-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Inscritos] ([InscritoId], [Nome], [Email], [Instagram], [DataNascimento]) VALUES (6, N'Martinho', N'perseverance@nasa.com', N'@comoestoudirigindoemmarte', CAST(N'1970-07-17T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Inscritos] OFF
GO
