-- =============================================
-- Author:		Diego Nascimento		
-- Create date: 10/06/2017
-- Description:	CRUD_Usuario
-- =============================================
IF (OBJECT_ID('CRUD_Usuario') IS NOT NULL)
  DROP PROCEDURE CRUD_Usuario
GO

CREATE PROCEDURE [dbo].[CRUD_Usuario]
	@Acao VARCHAR(1),
	@IdUsuario INT = NULL,
	@Nome VARCHAR(70) = NULL,
	@Telefone VARCHAR(11) = NULL,
	@Documento VARCHAR(14) = NULL,
	@IdRetorno INT OUTPUT
	AS
BEGIN
	SET NOCOUNT ON;
	IF @Acao = 'I'
		BEGIN
			INSERT INTO dbo.TB_Usuario
					( 	
						Nome,
						Telefone,
						Documento
					)
			VALUES  ( 	
						@Nome,
						@Telefone,
						@Documento
					)
			SET @IdRetorno = SCOPE_IDENTITY();
		END
	IF @Acao = 'U'
		BEGIN
			UPDATE dbo.TB_Usuario
			SET Nome			= @Nome,
				Telefone		= @Telefone,
				Documento		= @Documento
			WHERE Id_Usuario = @IdUsuario
			SET @IdRetorno = @IdUsuario
		END
	IF @Acao = 'D'
		BEGIN
			DELETE FROM dbo.TB_Usuario
			WHERE Id_Usuario = @IdUsuario
			SET @IdRetorno = @IdUsuario
		END
END
GO

-- =============================================
-- Author:		Diego Nascimento		
-- Create date: 10/06/2017
-- Description:	Listar_Usuario
-- =============================================
IF (OBJECT_ID('Listar_Usuario') IS NOT NULL)
  DROP PROCEDURE Listar_Usuario
GO

CREATE PROCEDURE [dbo].[Listar_Usuario]
	@Acao VARCHAR(50),	
	@Valor1 VARCHAR(MAX) = NULL
	AS
BEGIN
	SET NOCOUNT ON;
	IF @Acao = 'TODOS'
		BEGIN
			SELECT  Usu.Id_Usuario, Usu.Nome, Usu.Telefone, Usu.Documento
				FROM TB_Usuario Usu
				ORDER BY Usu.Id_Usuario DESC	
		END
END
GO

-- =============================================
-- Author:		Diego Nascimento		
-- Create date: 10/06/2017
-- Description:	Obter_Usuario
-- =============================================
IF (OBJECT_ID('Obter_Usuario') IS NOT NULL)
  DROP PROCEDURE Obter_Usuario
GO

CREATE PROCEDURE [dbo].[Obter_Usuario]
	@Acao VARCHAR(50),	
	@Valor1 VARCHAR(MAX) = NULL
	AS
BEGIN
	SET NOCOUNT ON;
	IF @Acao = 'ID'
		BEGIN
			SELECT  Usu.Id_Usuario, Usu.Nome, Usu.Telefone, Usu.Documento
				FROM TB_Usuario Usu
				WHERE Usu.Id_Usuario = @Valor1
		END
END