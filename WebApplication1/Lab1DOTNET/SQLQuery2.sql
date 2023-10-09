-- Удаление хранимой процедуры
DROP PROCEDURE IF EXISTS ShowCompanyForProvidedEmployeeId;


USE [DapperASPNetCore]
GO

-- Создание хранимой процедуры ShowCompanyForProvidedEmployeeId
CREATE PROCEDURE ShowCompanyForProvidedEmployeeId
    @EmployeeID INT
AS
BEGIN
    -- Объявление переменных для хранения данных о компании и сотруднике
    DECLARE @CompanyName NVARCHAR(50)
    DECLARE @CompanyAddress NVARCHAR(60)
    DECLARE @CompanyCountry NVARCHAR(50)
    DECLARE @EmployeeName NVARCHAR(50)
    DECLARE @EmployeeAge INT
    DECLARE @EmployeePosition NVARCHAR(50)

    -- Получение информации о компании и сотруднике
    SELECT 
        @CompanyName = C.[Name],
        @CompanyAddress = C.[Address],
        @CompanyCountry = C.[Country],
        @EmployeeName = E.[Name],
        @EmployeeAge = E.[Age],
        @EmployeePosition = E.[Position]
    FROM 
        [dbo].[Employees] E
    INNER JOIN 
        [dbo].[Companies] C ON E.[CompanyId] = C.[Id]
    WHERE 
        E.[Id] = @EmployeeID;

    -- Вывод информации
    SELECT 
        @CompanyName AS CompanyName,
        @CompanyAddress AS CompanyAddress,
        @CompanyCountry AS CompanyCountry,
        @EmployeeName AS EmployeeName,
        @EmployeeAge AS EmployeeAge,
        @EmployeePosition AS EmployeePosition;
END;
