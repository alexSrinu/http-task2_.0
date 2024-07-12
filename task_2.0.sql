--------table creation--------
create table TB_Hostel1a
(
Id int primary key identity (1,1),
Name varchar(30),
Password varchar(20),
MobileNo varchar(20),
Email varchar(20),
CountryId varchar(15),
Gender varchar(6),
Hobbies varchar(100),
DateOfBirth date
);
ALTER TABLE TB_Hostel
add IsActive BIT
ALTER TABLE TB_Hostel
ADD CONSTRAINT PK_TB_Hostel_Name PRIMARY KEY (Name);
select * from TB_Hostel1a
alter table 1a
 
drop column IsActive



----------------insert stored procedure---------------
create procedure proc_insert_TB_Hostel1a
(@Name varchar(30),@Password varchar(20),
@MobileNo varchar(20),@Email varchar(20),@CountryId varchar(15),
@Gender varchar(6),@Hobbies varchar(100),@DateOfBirth date,@Id int out)
as begin
insert into TB_Hostel1a values (@Name,@Password,@MobileNo,@Email,@CountryId,@Gender,@Hobbies,@DateOfBirth)
set @Id=@@IDENTITY
END
------------------checking username and mobileno and emial not repeated----------------------------
CREATE PROCEDURE spCheckUserExists1d
    
    @MobileNo NVARCHAR(15),
    @Email NVARCHAR(50)
AS
BEGIN
    SELECT COUNT(*) 
    FROM TB_Hostel1a
    WHERE  MobileNo = @MobileNo OR Email = @Email;
END
CREATE PROCEDURE spCheckUserExists2D
    
    @MobileNo NVARCHAR(15)
    
AS
BEGIN
    SELECT COUNT(*) 
    FROM TB_Hostel1a
    WHERE  MobileNo = @MobileNo ;
END
CREATE PROCEDURE spCheckUserExists3d
    
    
    @Email NVARCHAR(50)
AS
BEGIN
    SELECT COUNT(*) 
    FROM TB_Hostel1a
    WHERE   Email = @Email;
END
----------------------how to see the table-----
select * from TB_Hostel1a
--------------------login stored procedure---------------
create procedure proc_Login_Student(@Name varchar(30),@Password varchar(20),@MobileNo varchar(20),@Email varchar(20))
as begin
select count(*) from TB_Hostel1a where Name=@Name or MobileNo=@MobileNo or Email=@Email and Password=@Password
end;
create procedure proc_Login_Student1b(@Password varchar(20),@Email varchar(20))
as begin
select count(*) from TB_Hostel1a where  Email=@Email and Password=@Password
end;
create procedure proc_Login_Student100(@Id int,@Password varchar(20),@Email varchar(20))
as begin
--select count(*) from TB_Hostel where  Email=@Email and Password=@Password

end;

-------------------UPDATE STORED PROCEDURE-----------------------
create procedure proc_Update_Student
(@Name varchar(30),@Password varchar(20),
@MobileNo varchar(20),@Email varchar(20),@CountryId varchar(15),
@Gender varchar(6),@Hobbies varchar(100),@DateOfBirth date,@Id int out)
as begin
update TB_Hostel set Name=@Name,Password=@Password,MobileNo=@MobileNo,Email=@Email,
CountryId=@CountryId,Gender=@Gender,Hobbies=@Hobbies,DateOfBirth=@DateOfBirth
where Email=@Email and Password=@Password
end
--------------------update without datetime stored procedure---------------------
create procedure proc_Update_Student1B
(@Name varchar(30),@Password varchar(20),
@MobileNo varchar(20),@Email varchar(20),@CountryId varchar(15),
@Gender varchar(6),@Hobbies varchar(100), @DateOfBirth date,@Id int )
as begin
update TB_Hostel set Name=@Name,Password=@Password,MobileNo=@MobileNo,Email=@Email,
CountryId=@CountryId,Gender=@Gender,Hobbies=@Hobbies,DateOfBirth=@DateOfBirth,IsActive=1
where Email=@Email and Password=@Password 
end
create procedure proc_Update_Student100B
(@Name varchar(30),
@MobileNo varchar(20),@Email varchar(20),@CountryId varchar(15),
@Gender varchar(6),@Hobbies varchar(100), @DateOfBirth date,@Id int )
as begin
update TB_Hostel set Name=@Name,MobileNo=@MobileNo,Email=@Email,
CountryId=@CountryId,Gender=@Gender,Hobbies=@Hobbies,DateOfBirth=@DateOfBirth,IsActive=1
where Id=@Id
end
-----------------retrive stored procedure------------------
create procedure pro_SELECT_STUDENT10(@Email varchar(20),@Password varchar(20))
as begin
select Name,Password,MobileNo,Email,CountryId,Gender,Hobbies from TB_Hostel where Email=@Email and Password=@Password
end
create procedure pro_SELECT_STUDENT11(@Email varchar(20),@Password varchar(20))
as begin
select * from TB_Hostel where Email=@Email and Password=@Password
end
create procedure proc_select_student111(@Id int,@Email varchar(20),@Password varchar(20))
as begin
select * from TB_Hostel where @Id=(select id from TB_Hostel where Email=@Email and Password=@Password)
end

create procedure pro_SELECT_STUDENT110
as begin
select * from TB_Hostel 
end
--------------create admin details-------------
create table TB_Admin10
(
Id int,
Email varchar(20),
Password varchar(20)
);
select * from TB_Admin10
insert into TB_Admin10 values(101,'admin@gmail.com','Admin123')
create procedure proc_TB_Admin101(@Email varchar(20),@Password varchar(20))
as begin
select count(*) from  TB_Admin10 where Email=@Email and Password=@Password
end;
------------------delete stored procedure--------------
create procedure proc_Delete_Admin1(@Id int)
as begin
delete from TB_Hostel where Id=@Id
end
exec proc_Delete_Admin1 @Id=3
-------------------------checking some queries---------------------
select * from TB_Hostel where id=(select id from TB_Hostel where Email='patlu@gmail.com ' and Password='123456')
ALTER TABLE TB_Hostel 
ADD CONSTRAINT DF_Users_IsActive DEFAULT 1 FOR IsActive;
------------------------------delete----------------------
CREATE PROCEDURE DeleteUser
    @Id INT
AS
BEGIN
    UPDATE TB_Hostel
    SET IsActive = 0
    WHERE Id = @Id;
END
exec DeleteUser
@Id=8
select * from TB_Hostel
proc_Update_Student100B
delete from TB_Hostel where Id=1015











