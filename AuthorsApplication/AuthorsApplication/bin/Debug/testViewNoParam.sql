CREATE VIEW testViewNoParam
	SELECT au_fname, au_lname, title
	FROM authors
	JOIN titleauthor ON authors.au_id = titleauthor.au_id
	JOIN titles ON titleauthor.title_id = titles.title_id
	WHERE au_id = '172-32-1176'