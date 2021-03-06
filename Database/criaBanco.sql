USE [LivesContext-1]
GO
/****** Object:  Table [dbo].[Inscricoes]    Script Date: 24/02/2021 16:45:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscricoes](
	[InscricaoId] [int] IDENTITY(1,1) NOT NULL,
	[LiveId] [int] NOT NULL,
	[InscritoId] [int] NOT NULL,
	[Pago] [bit] NOT NULL,
	[boleto] [int] NOT NULL,
 CONSTRAINT [PK_Inscricoes] PRIMARY KEY CLUSTERED 
(
	[InscricaoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inscritos]    Script Date: 24/02/2021 16:45:35 ******/
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
/****** Object:  Table [dbo].[Instrutores]    Script Date: 24/02/2021 16:45:35 ******/
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
/****** Object:  Table [dbo].[Lives]    Script Date: 24/02/2021 16:45:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lives](
	[LiveId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Descricao] [nvarchar](max) NULL,
	[InstrutorId] [int] NOT NULL,
	[Data] [datetime2](7) NOT NULL,
	[Duracao] [int] NOT NULL,
	[Valor] [real] NOT NULL,
 CONSTRAINT [PK_Lives] PRIMARY KEY CLUSTERED 
(
	[LiveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Inscricoes] ON 

INSERT [dbo].[Inscricoes] ([InscricaoId], [LiveId], [InscritoId], [Pago], [boleto]) VALUES (1, 2, 2, 0, 2)
INSERT [dbo].[Inscricoes] ([InscricaoId], [LiveId], [InscritoId], [Pago], [boleto]) VALUES (2, 1, 1, 0, 1)
SET IDENTITY_INSERT [dbo].[Inscricoes] OFF
GO
SET IDENTITY_INSERT [dbo].[Inscritos] ON 

INSERT [dbo].[Inscritos] ([InscritoId], [Nome], [Email], [Instagram], [DataNascimento]) VALUES (1, N'Joao', N'joao@testeemail.com', N'@joaozin', CAST(N'1985-02-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Inscritos] ([InscritoId], [Nome], [Email], [Instagram], [DataNascimento]) VALUES (2, N'Maria', N'radiotiva@nobel.com', N'@tobrilhando', CAST(N'1930-09-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Inscritos] ([InscritoId], [Nome], [Email], [Instagram], [DataNascimento]) VALUES (3, N'Carl', N'sagan@space.com', N'@casquinhadenoz', CAST(N'1940-05-02T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Inscritos] ([InscritoId], [Nome], [Email], [Instagram], [DataNascimento]) VALUES (6, N'Martinho', N'perseverance@nasa.com', N'@comoestoudirigindoemmarte', CAST(N'1970-07-17T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Inscritos] OFF
GO
SET IDENTITY_INSERT [dbo].[Instrutores] ON 

INSERT [dbo].[Instrutores] ([InstrutorID], [Nome], [Email], [Instagram], [DataNascimento]) VALUES (1, N'Tia', N'Alexander', N'Alexander', CAST(N'2019-09-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Instrutores] ([InstrutorID], [Nome], [Email], [Instagram], [DataNascimento]) VALUES (2, N'José', N'Alexander', N'Alexander', CAST(N'2019-09-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Instrutores] OFF
GO
SET IDENTITY_INSERT [dbo].[Lives] ON 

INSERT [dbo].[Lives] ([LiveId], [Nome], [Descricao], [InstrutorId], [Data], [Duracao], [Valor]) VALUES (1, N'Começando novamente', N'Alterações da MS na nomenclatura dos frameworks', 1, CAST(N'2021-04-01T00:00:00.0000000' AS DateTime2), 20, 126)
INSERT [dbo].[Lives] ([LiveId], [Nome], [Descricao], [InstrutorId], [Data], [Duracao], [Valor]) VALUES (2, N'Escovando bits', N'Validação dos dados durante migrações', 1, CAST(N'2021-03-01T00:00:00.0000000' AS DateTime2), 20, 126)
SET IDENTITY_INSERT [dbo].[Lives] OFF
GO
ALTER TABLE [dbo].[Inscricoes]  WITH CHECK ADD  CONSTRAINT [FK_Inscricoes_Inscritos_InscritoId] FOREIGN KEY([InscritoId])
REFERENCES [dbo].[Inscritos] ([InscritoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inscricoes] CHECK CONSTRAINT [FK_Inscricoes_Inscritos_InscritoId]
GO
ALTER TABLE [dbo].[Inscricoes]  WITH CHECK ADD  CONSTRAINT [FK_Inscricoes_Lives_LiveId] FOREIGN KEY([LiveId])
REFERENCES [dbo].[Lives] ([LiveId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inscricoes] CHECK CONSTRAINT [FK_Inscricoes_Lives_LiveId]
GO
ALTER TABLE [dbo].[Lives]  WITH CHECK ADD  CONSTRAINT [FK_Lives_Instrutores_InstrutorId] FOREIGN KEY([InstrutorId])
REFERENCES [dbo].[Instrutores] ([InstrutorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lives] CHECK CONSTRAINT [FK_Lives_Instrutores_InstrutorId]
GO
