USE [School]
GO
/****** Object:  StoredProcedure [dbo].[BuscarPersonaNombre]    Script Date: 01/10/2021 01:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[BuscarPersonaNombre]
	@FirstName nvarchar(50)
as
select * from Person where FirstName like '%'+@FirstName+'%'