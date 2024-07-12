USE [FirstDB]
GO
/****** Object:  StoredProcedure [dbo].[proc_Update_Student100B]    Script Date: 10-07-2024 15:21:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[proc_Update_Student100B]
(@Name varchar(30),@Password varchar(20),
@MobileNo varchar(20),@Email varchar(20),@CountryId varchar(15),
@Gender varchar(6),@Hobbies varchar(100), @DateOfBirth date,@Id int )
as begin
update TB_Hostel set Name=@Name,Password=@Password,MobileNo=@MobileNo,Email=@Email,
CountryId=@CountryId,Gender=@Gender,Hobbies=@Hobbies,DateOfBirth=@DateOfBirth,IsActive=1
where Id=@Id
end
exec proc_Update_Student100B
@Name='alex',@Password='123456',@MobileNo='9392526876',@Email='alex@gmail.com',
@CountryId='INDIA',@Gender='male',@Hobbies='SPORTS',@DateOfBirth='2023-06-09',@Id=16
select * from TB_Hostel