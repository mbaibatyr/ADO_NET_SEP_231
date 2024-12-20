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