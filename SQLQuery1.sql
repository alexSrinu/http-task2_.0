USE [FirstDB]
GO
/****** Object:  StoredProcedure [dbo].[pro_SELECT_STUDENT110]    Script Date: 10-07-2024 14:41:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[pro_SELECT_STUDENT110]
as begin
select * from TB_Hostel WHERE IsActive=0
end