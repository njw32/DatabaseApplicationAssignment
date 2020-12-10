USE pubs;
GO

SELECT TOP 5 * FROM authors

EXEC proc_ainfo @au_id = '238-95-7766', @address = '123 Main St.', @city = Fairfax, @state = VA, @zip = 22030

SELECT TOP 5 * FROM authors

--this should (and does) fail
--EXEC proc_ainfo @au_id = '1', @address = '123 Main St.', @city = Fairfax, @state = VA, @zip = 22030

--SELECT TOP 5 * FROM authors

-- if city is too long, it gets cut off. if zip is too long or too short the update fails due to check constraint
EXEC proc_ainfo @au_id = '267-41-2394', @address = '123 Main St.', @city = 'Grand Rapids', @state = VAT, @zip = 49546

SELECT TOP 5 * FROM authors

-- if city is too short, it is padded I think
EXEC proc_ainfo @au_id = '274-80-9391', @address = '123 Main St.', @city = 'Florida', @state = F, @zip = 12345

SELECT TOP 5 * FROM authors