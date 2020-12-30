--Procedure NOME--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_CREATE_TBS_NOME')
	DROP PROCEDURE SP_CREATE_TBS_NOME
GO

CREATE PROCEDURE SP_CREATE_TBS_NOME (
	@Nome as nvarchar(100),
	@Cod as bigint,
	@NomeId as bigint OUTPUT
) AS 
BEGIN 
	INSERT INTO dbo.tbs_nome (nome, cod)
	VALUES (@Nome, @Cod)
	
	SELECT @NomeId = @@Identity
END

GO



--Procedure EMAIL--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_CREATE_TBS_EMAIL')
	DROP PROCEDURE SP_CREATE_TBS_EMAIL
GO

CREATE PROCEDURE SP_CREATE_TBS_EMAIL (
	@Email as nvarchar(100),
	@Cod as bigint,
	@EmailId as bigint OUTPUT
) AS 
BEGIN 
	INSERT INTO dbo.tbs_email (email, cod)
	VALUES (@Email, @Cod)
	
	SELECT @EmailId = @@Identity
END

GO

--Procedure SOBRENOME--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_CREATE_TBS_SOBRENOME')
	DROP PROCEDURE SP_CREATE_TBS_SOBRENOME
GO

CREATE PROCEDURE SP_CREATE_TBS_SOBRENOME (
	@Sobrenome as nvarchar(100),
	@Cod as bigint,
	@SobrenomeId as bigint OUTPUT
	
) AS 
BEGIN 
	INSERT INTO dbo.tbs_sobrenome (sobrenome, cod)
	VALUES (@Sobrenome, @Cod)
	
	SELECT @SobrenomeId = @@Identity
END

GO

--------------------------------

--Procedure NOME--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_OBTER_TBS_NOME')
	DROP PROCEDURE SP_OBTER_TBS_NOME
GO

CREATE PROCEDURE SP_OBTER_TBS_NOME (
	@Cod as bigint
) AS 
BEGIN 
	SELECT 
	t1.id, t1.cod, t1.nome, t2.soma
	FROM dbo.tbs_nome t1 join 
	dbo.tbs_cod_nome t2
	ON t1.cod = t2.cod
	WHERE t1.cod = @Cod
END

GO



--Procedure EMAIL--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_OBTER_TBS_EMAIL')
	DROP PROCEDURE SP_OBTER_TBS_EMAIL
GO

CREATE PROCEDURE SP_OBTER_TBS_EMAIL (
	@Cod as bigint
) AS 
BEGIN 
	SELECT 
	t1.id, t1.cod, t1.email, t2.soma
	FROM dbo.tbs_email t1 join 
	dbo.tbs_cod_email t2
	ON t1.cod = t2.cod
	WHERE t1.cod = @Cod
END

GO

--Procedure SOBRENOME--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_OBTER_TBS_SOBRENOME')
	DROP PROCEDURE SP_OBTER_TBS_SOBRENOME
GO

CREATE PROCEDURE SP_OBTER_TBS_SOBRENOME (
	@Cod as bigint
	
) AS 
BEGIN 
	SELECT 
	t1.id, t1.cod, t1.sobrenome, t2.soma
	FROM dbo.tbs_sobrenome t1 join 
	dbo.tbs_cod_sobrenome t2
	ON t1.cod = t2.cod
	WHERE t1.cod = @Cod
END

GO

--Procedure ANIMAIS--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_OBTER_TBS_ANIMAIS')
	DROP PROCEDURE SP_OBTER_TBS_ANIMAIS
GO

CREATE PROCEDURE SP_OBTER_TBS_ANIMAIS
AS 
BEGIN 
	SELECT * FROM dbo.tbs_animais
END

GO

--Procedure PAISES--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_OBTER_TBS_PAISES')
	DROP PROCEDURE SP_OBTER_TBS_PAISES
GO

CREATE PROCEDURE SP_OBTER_TBS_PAISES
AS 
BEGIN 
	SELECT * FROM dbo.tbs_paises
END

GO

--Procedure CORES--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SP_OBTER_TBS_CORES')
	DROP PROCEDURE SP_OBTER_TBS_CORES
GO

CREATE PROCEDURE SP_OBTER_TBS_CORES
AS 
BEGIN 
	SELECT c1.* FROM dbo.tbs_cores c1 left join dbo.tbs_cores_excluidas c2
	ON c1.id = c2.id
	WHERE c2.id is null

END




