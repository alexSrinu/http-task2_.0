USE [FirstDB]
GO
/****** Object:  StoredProcedure [dbo].[proc_Update_Student111]    Script Date: 11-07-2024 11:32:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[proc_Update_Student111]
(@Name varchar(30),
@MobileNo varchar(20),@Email varchar(20),@CountryId varchar(15),
@Gender varchar(6),@Hobbies varchar(100), @DateOfBirth date,@Id int )
as begin
update TB_Hostel set Name=@Name,MobileNo=@MobileNo,Email=@Email,
CountryId=@CountryId,Gender=@Gender,Hobbies=@Hobbies,DateOfBirth=@DateOfBirth,IsActive=1
where Id=@Id
end
select * from tb_hostel