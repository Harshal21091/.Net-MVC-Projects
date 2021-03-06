USE [Inventory]
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Product_List]    Script Date: 10/18/2021 6:18:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		HarshalC
-- Create date: 16-OCT-2021
-- Description:	Get all product list 
-- exec Get_All_Product_List
-- =============================================
ALTER PROCEDURE [dbo].[Get_All_Product_List]
	
AS
BEGIN
	SELECT PRODUCT_ID,
	PRODUCT_NAME,
	DISCRIPTTION,
    RETAIL_PRICE, 
	ACTUAL_PRICE,
    CATEGORY FROM PRODUCT_DETAILS 
	WHERE IS_ACTIVE = 1
END
