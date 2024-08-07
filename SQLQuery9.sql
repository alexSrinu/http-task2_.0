USE [FirstDB]
GO
/****** Object:  StoredProcedure [dbo].[proc_insert_TB_Hostel]    Script Date: 11-07-2024 12:23:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[proc_insert_TB_Hostel]
--(@Name varchar(30),@Password varchar(20),
--@MobileNo varchar(20),@Email varchar(20),@CountryId varchar(15),
--@Gender varchar(6),@Hobbies varchar(100),@DateOfBirth date,@Id int out)
--as begin
--insert into TB_Hostel values (@Name,@Password,@MobileNo,@Email,@CountryId,@Gender,@Hobbies,@DateOfBirth)
--set @Id=@@IDENTITY and IsActive=1
--END
--ALTER procedure [dbo].[proc_insert_TB_Hostel]
(
    @Name varchar(30),
    @Password varchar(20),
    @MobileNo varchar(20),
    @Email varchar(20),
    @CountryId varchar(15),
    @Gender varchar(6),
    @Hobbies varchar(100),
    @DateOfBirth date,
    @Id int out
)
as
begin
    insert into TB_Hostel (Name, Password, MobileNo, Email, CountryId, Gender, Hobbies, DateOfBirth, IsActive)
    values (@Name, @Password, @MobileNo, @Email, @CountryId, @Gender, @Hobbies, @DateOfBirth, 1)
    
    set @Id = @@IDENTITY
end
select * from TB_Hostel
DECLARE @NewId INT;
exec proc_insert_TB_Hostel @Name='srinu',@Password='456123',@MobileNo='9844444213',@Email='srinu@gmail.com',
@CountryId='US',@Gender='MALE',@Hobbies='TEACHING',
@DateOfBirth='1969-04-22', @Id = @NewId OUTPUT;