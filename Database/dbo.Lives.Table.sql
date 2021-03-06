USE [GerenciadorLives]
GO
/****** Object:  Table [dbo].[Lives]    Script Date: 01/03/2021 15:19:25 ******/
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
	[Valor] [decimal](10, 2) NULL,
 CONSTRAINT [PK_Lives] PRIMARY KEY CLUSTERED 
(
	[LiveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Lives] ON 

INSERT [dbo].[Lives] ([LiveId], [Nome], [Descricao], [InstrutorId], [Data], [Duracao], [Valor]) VALUES (1, N'Começando novamente', N'Alterações da MS na nomenclatura dos frameworks', 1, CAST(N'2021-04-01T20:00:00.0000000' AS DateTime2), 20, CAST(550.00 AS Decimal(10, 2)))
INSERT [dbo].[Lives] ([LiveId], [Nome], [Descricao], [InstrutorId], [Data], [Duracao], [Valor]) VALUES (2, N'Escovando bits', N'Validação dos dados durante migrações', 2, CAST(N'2021-03-01T00:00:00.0000000' AS DateTime2), 20, CAST(500.00 AS Decimal(10, 2)))
INSERT [dbo].[Lives] ([LiveId], [Nome], [Descricao], [InstrutorId], [Data], [Duracao], [Valor]) VALUES (3, N'Etapas de produção', N'Frita o pastel, depois escolhe o sabor', 3, CAST(N'2021-04-15T00:00:00.0000000' AS DateTime2), 30, CAST(600.00 AS Decimal(10, 2)))
INSERT [dbo].[Lives] ([LiveId], [Nome], [Descricao], [InstrutorId], [Data], [Duracao], [Valor]) VALUES (4, N'Teste tia 2', N'pegando dois registros', 1, CAST(N'2021-10-09T00:00:00.0000000' AS DateTime2), 40, CAST(78.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Lives] OFF
GO
ALTER TABLE [dbo].[Lives]  WITH CHECK ADD  CONSTRAINT [FK_Lives_Instrutores_InstrutorId] FOREIGN KEY([InstrutorId])
REFERENCES [dbo].[Instrutores] ([InstrutorID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lives] CHECK CONSTRAINT [FK_Lives_Instrutores_InstrutorId]
GO
