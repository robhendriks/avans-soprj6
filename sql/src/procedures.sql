USE [GoInsp];
GO

DROP PROCEDURE [GetPeriodsPerRegion];
GO

CREATE PROCEDURE [GetPeriodsPerRegion] 
    @GemeenteCode NVARCHAR(10)
AS
    SELECT DISTINCT([AfvalPerioden]) AS N'Period'
    FROM [Afval]
    WHERE [AfvalRegioS] = @GemeenteCode;
GO

DROP PROCEDURE [GetAfvalPerRegion];
GO

CREATE PROCEDURE [GetAfvalPerRegion]
    @GemeenteCode NVARCHAR(10),
    @Column NVARCHAR(MAX)
AS
    DECLARE @sql NVARCHAR(MAX) = 'SELECT [' + @Column + '] AS [Afval], [AfvalPerioden] AS [Period] FROM [Afval] WHERE [AfvalRegioS] = ''' + @GemeenteCode + ''' AND [' + @Column + '] IS NOT NULL;';
    exec sp_executesql @sql, N''
GO

DROP PROCEDURE [GetAfvalPerRegion2];
GO

CREATE PROCEDURE [GetAfvalPerRegion2]
    @GemeenteCode NVARCHAR(10)
AS
    SELECT *
    FROM [Afval]
    WHERE [AfvalRegioS] = @GemeenteCode;
GO