USE [FirstDB]
GO
/****** Object:  StoredProcedure [dbo].[proc_Login_Student1]    Script Date: 11-07-2024 11:57:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[proc_Login_Student1](@Password varchar(20),@Email varchar(20))
as begin
select count(*) from TB_Hostel where  Email=@Email and Password=@Password and IsAcTIVE=1
end;