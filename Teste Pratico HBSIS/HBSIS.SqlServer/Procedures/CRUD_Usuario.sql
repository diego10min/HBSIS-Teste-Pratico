-- =============================================
-- Author:		Diego Nascimento		
-- Create date: 10/06/2017
-- Description:	CRUD_Usuario
-- =============================================
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