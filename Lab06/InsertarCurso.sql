USE [School]
GO
/****** Object:  StoredProcedure [dbo].[InsertCourse]    Script Date: 26/09/2021 11:47:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[InsertCourse]
		@CourseID int,
		@Title nvarchar(50),
		@Credits int,
		@DepartmentID int
		AS
		INSERT INTO dbo.Course(CourseID,
					Title, 
					Credits, 
					DepartmentID)
		VALUES (@CourseID
			@Title, 
			@Credits, 
			@DepartmentID);