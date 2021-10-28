USE [Inventory]
GO
/****** Object:  StoredProcedure [dbo].[Delete_Product]    Script Date: 10/16/2021 6:08:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		HarshalC
-- Create date: 17-OCT-2021
-- Description:	DELETE product details for update IS_ACTIVE = 0.
-- exec [Delete_Product]
-- =============================================
ALTER PROCEDURE [dbo].[DELETE_PRODUCT]
@PRODUCTID	INT,
@STATUS INT OUTPUT
AS
BEGIN

	UPDATE PRODUCT_DETAILS
	 SET IS_ACTIVE = 0
	 WHERE PRODUCT_ID = @PRODUCTID

	SET @STATUS = '1'   -- Success

END
