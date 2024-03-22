USE MovieLibrary;

-- Insert genres
INSERT INTO Genres (Id, Name) VALUES 
(1, 'Drama'),
(2, 'Action'),
(3, 'Comedy'),
(4, 'Thriller'),
(5, 'Adventure'),
(6, 'Sci-Fi');

-- Insert tags
INSERT INTO Tag (Name) VALUES 
('Classic'),
('Crime'),
('Masterpiece'),
('Action-packed'),
('Funny'),
('Suspenseful');

-- Insert directors
INSERT INTO Directors (Name) VALUES 
('Steven Spielberg'),
('Christopher Nolan'),
('Quentin Tarantino'),
('Martin Scorsese'),
('James Cameron'),
('Peter Jackson');

-- Insert movies
INSERT INTO Movies (Name, ReleaseDate, GenreId, Classification)
VALUES 
('The Shawshank Redemption', '1994-10-14', 1, 3), -- Drama, Platinum
('The Godfather', '1972-03-24', 1, 3), -- Drama, Platinum
('The Dark Knight', '2008-07-18', 2, 3), -- Action, Platinum
('Schindler''s List', '1993-12-15', 1, 3), -- Drama, Platinum
('Pulp Fiction', '1994-10-14', 1, 3), -- Drama, Platinum
('Forrest Gump', '1994-07-06', 1, 3), -- Drama, Platinum
('The Matrix', '1999-03-31', 6, 3), -- Sci-Fi, Platinum
('The Lord of the Rings: The Return of the King', '2003-12-17', 5, 3), -- Adventure, Platinum
('Inception', '2010-07-16', 2, 3), -- Action, Platinum
('Fight Club', '1999-10-15', 1, 3), -- Drama, Platinum
('The Silence of the Lambs', '1991-02-14', 4, 3), -- Thriller, Platinum
('The Departed', '2006-10-06', 1, 3), -- Drama, Platinum
('Goodfellas', '1990-09-19', 1, 3), -- Drama, Platinum
('The Green Mile', '1999-12-10', 1, 3), -- Drama, Platinum
('Gladiator', '2000-05-05', 5, 3), -- Adventure, Platinum
('Saving Private Ryan', '1998-07-24', 1, 3), -- Drama, Platinum
('The Usual Suspects', '1995-09-15', 4, 3), -- Thriller, Platinum
('Se7en', '1995-09-22', 4, 3), -- Thriller, Platinum
('The Lord of the Rings: The Fellowship of the Ring', '2001-12-19', 5, 3), -- Adventure, Platinum
('The Lion King', '1994-06-15', 5, 3), -- Adventure, Platinum
('Titanic', '1997-12-19', 5, 3), -- Adventure, Platinum
('Back to the Future', '1985-07-03', 6, 3), -- Sci-Fi, Platinum
('The Terminator', '1984-10-26', 2, 3), -- Action, Platinum
('The Sixth Sense', '1999-08-06', 4, 3), -- Thriller, Platinum
('The Departed', '2006-10-06', 1, 3), -- Drama, Platinum
('Alien', '1979-05-25', 6, 3), -- Sci-Fi, Platinum
('Jaws', '1975-06-20', 1, 3), -- Drama, Platinum
('Jurassic Park', '1993-06-11', 5, 3), -- Adventure, Platinum
('Die Hard', '1988-07-15', 2, 3), -- Action, Platinum
('The Shawshank Redemption', '1994-10-14', 1, 3), -- Drama, Platinum
('The Godfather', '1972-03-24', 1, 3), -- Drama, Platinum
('The Dark Knight', '2008-07-18', 2, 3), -- Action, Platinum
('Schindler''s List', '1993-12-15', 1, 3), -- Drama, Platinum
('Pulp Fiction', '1994-10-14', 1, 3), -- Drama, Platinum
('Forrest Gump', '1994-07-06', 1, 3), -- Drama, Platinum
('The Matrix', '1999-03-31', 6, 3), -- Sci-Fi, Platinum
('The Lord of the Rings: The Return of the King', '2003-12-17', 5, 3), -- Adventure, Platinum
('Inception', '2010-07-16', 2, 3), -- Action, Platinum
('Fight Club', '1999-10-15', 1, 3), -- Drama, Platinum
('The Silence of the Lambs', '1991-02-14', 4, 3), -- Thriller, Platinum
('The Departed', '2006-10-06', 1, 3), -- Drama, Platinum
('Goodfellas', '1990-09-19', 1, 3), -- Drama, Platinum
('The Green Mile', '1999-12-10', 1, 3), -- Drama, Platinum
('Gladiator', '2000-05-05', 5, 3), -- Adventure, Platinum
('Saving Private Ryan', '1998-07-24', 1, 3), -- Drama, Platinum
('The Usual Suspects', '1995-09-15', 4, 3), -- Thriller, Platinum
('Se7en', '1995-09-22', 4, 3), -- Thriller, Platinum
('The Lord of the Rings: The Fellowship of the Ring', '2001-12-19', 5, 3), -- Adventure, Platinum
('The Lion King', '1994-06-15', 5, 3), -- Adventure, Platinum
('Titanic', '1997-12-19', 5, 3), -- Adventure, Platinum
('Back to the Future', '1985-07-03', 6, 3); -- Sci-Fi, Platinum
