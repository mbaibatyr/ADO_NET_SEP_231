create table City
(
	id int primary key identity,
	name nvarchar(100),
	population int,
	birthdate datetime
)

create proc pCity -- SELECT *
as
SELECT id,
		name,
		population,
		birthdate
FROM City
ORDER BY name

alter proc pCity;2 -- SELECT BY name*
@name nvarchar(100)
/*
	pCity;2 N'а'
*/
as
SELECT id,
		name,
		population,
		birthdate
FROM City
WHERE name LIKE '%' + @name + '%'
ORDER BY name

alter proc pCity;3 -- INSERT
@name nvarchar(100),
@population int,
@birthdate datetime
/*
	pCity;3 N'Астана', 1500000, '1991-01-01'
*/
as
INSERT INTO City (name,
		population,
		birthdate)
VALUES(@name,
		@population,
		@birthdate)

create proc pCity;4 -- UPDATE
@id int,
@name nvarchar(100),
@population int,
@birthdate datetime
/*
	pCity;4 2, N'Астана', 2000000, '1992-01-01'
*/
as
UPDATE City
	SET name = @name,
		population = @population,
		birthdate = @birthdate
WHERE id = @id

create proc pCity;5 -- DELETE
@id int
/*
	pCity;5 2
*/
as
DELETE FROM City
WHERE id = @id

alter proc pCity;6 -- OUT
@cnt int OUT
/*
	DECLARE
		@cnt int
	EXEC pCity;6 @cnt OUT
	SELECT @cnt
*/
as
SELECT @cnt = COUNT(*)
FROM City