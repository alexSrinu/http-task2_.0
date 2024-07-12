USE [FirstDB]
GO
/****** Object:  StoredProcedure [dbo].[proc_checkEmail]    Script Date: 11-07-2024 16:08:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
select * from tb_hostel
ALTER procedure [dbo].[proc_checkEmail] 'ammulu@gmail.com'
@Email varchar(20)
as begin
declare @count int
select @count=count(ID)
from TB_Hostel
where Email=@Email and IsActive=1
if(@count>0)
select 1 as MobileNoExists
else
select 0 as MobileNoExists
end