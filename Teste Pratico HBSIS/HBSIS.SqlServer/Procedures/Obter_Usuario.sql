-- =============================================
-- Author:		Diego Nascimento		
-- Create date: 10/06/2017
-- Description:	Obter_Usuario
-- =============================================
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