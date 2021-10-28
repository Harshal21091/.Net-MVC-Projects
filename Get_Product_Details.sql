USE [Inventory]
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Product_List]    Script Date: 10/16/2021 6:08:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		HarshalC
-- Create date: 16-OCT-2021
-- Description:	Get product details for update.
-- exec [Get_Product_By_ID]
-- =============================================
ALTER PROCEDURE [dbo].[Get_Product_Details]
@PRODUCTID	INT 
AS
BEGIN
	SELECT PRODUCT_ID, PRODUCT_NAME,
	DISCRIPTTION,
    RETAIL_PRICE, 
	ACTUAL_PRICE,
    CATEGORY FROM PRODUCT_DETAILS  where PRODUCT_ID = @PRODUCTID and IS_ACTIVE = 1
END
