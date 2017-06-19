-- =============================================
-- Author:		Diego Nascimento		
-- Create date: 10/06/2017
-- Description:	Listar_Usuario
-- =============================================
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