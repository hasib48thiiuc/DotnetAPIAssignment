﻿CREATE PROCEDURE GetAllAddresses
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Address;
END;