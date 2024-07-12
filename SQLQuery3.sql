USE [FirstDB]
GO
/****** Object:  StoredProcedure [dbo].[proc_checkMobileno]    Script Date: 10-07-2024 16:19:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
select * from tb_hostel
ALTER procedure [dbo].[proc_checkMobileno] 
@MobileNo varchar(20)
as begin
declare @count int
select @count=count(ID)
from TB_Hostel
 WHERE MobileNo=@MobileNo  and IsActive=1
if(@count>0)
select 1 as MobileNoExists
else
select 0 as MobileNoExists
end
[proc_checkMobileno] '8877995544'