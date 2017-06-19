CREATE TABLE [dbo].[TB_Usuario]
(
	[Id_Usuario] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] VARCHAR(70) NOT NULL, 
    [Telefone] VARCHAR(11) NOT NULL, 
    [Documento] VARCHAR(14) NOT NULL
)
