-- Create the book_reservation table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.book_reservation') AND type in (N'U'))
BEGIN
    CREATE TABLE dbo.book_reservation
    (
        code INT IDENTITY(1,1) PRIMARY KEY,
        date_in DATE,
        book_name INT,
        abonent INT,
        date_out DATE
    );
END

-- Create the book table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.book') AND type in (N'U'))
BEGIN
    CREATE TABLE dbo.book
    (
        code INT IDENTITY(1,1) PRIMARY KEY,
        _name VARCHAR(60),
        author VARCHAR(60),
        genre INT,
        lable INT,
        release_date DATE,
        _count INT,
        _cost INT
    );


END

-- Create the person table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.person') AND type in (N'U'))
BEGIN
    CREATE TABLE dbo.person
    (
        ticket_code INT IDENTITY(1,1) PRIMARY KEY,
        surname VARCHAR(60),
        _name VARCHAR(60),
        father_name VARCHAR(60),
        contact_phone VARCHAR(13),
        registration_date DATE
    );
END

-- Create the genre table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.genre') AND type in (N'U'))
BEGIN
    CREATE TABLE dbo.genre
    (
        code INT IDENTITY(1,1) PRIMARY KEY,
        name VARCHAR(60)
    );
END

-- Create the publisher table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.publisher') AND type in (N'U'))
BEGIN
    CREATE TABLE dbo.publisher
    (
        code INT IDENTITY(1,1) PRIMARY KEY,
        _name VARCHAR(60),
        city VARCHAR(60),
        contact_name VARCHAR(60),
        contact_phone VARCHAR(13)
    );
END
-- Create the book_reservation table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.book_reservation') AND type in (N'U'))
BEGIN
    CREATE TABLE dbo.book_reservation
    (
        code INT IDENTITY(1,1) PRIMARY KEY,
        date_in DATE,
        book_name INT,
        abonent INT,
        date_out DATE
    );

END

-- Create the book table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.book') AND type in (N'U'))
BEGIN
    CREATE TABLE dbo.book
    (
        code INT IDENTITY(1,1) PRIMARY KEY,
        _name VARCHAR(60),
        author VARCHAR(60),
        genre INT,
        lable INT,
        release_date DATE,
        _count INT,
        _cost INT
    );

END

-- Create the person table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.person') AND type in (N'U'))
BEGIN
    CREATE TABLE dbo.person
    (
        ticket_code INT IDENTITY(1,1) PRIMARY KEY,
        surname VARCHAR(60),
        _name VARCHAR(60),
        father_name VARCHAR(60),
        contact_phone VARCHAR(13),
        registration_date DATE
    );
END

-- Create the genre table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.genre') AND type in (N'U'))
BEGIN
    CREATE TABLE dbo.genre
    (
        code INT IDENTITY(1,1) PRIMARY KEY,
        name VARCHAR(60)
    );
END

-- Create the publisher table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.publisher') AND type in (N'U'))
BEGIN
    CREATE TABLE dbo.publisher
    (
        code INT IDENTITY(1,1) PRIMARY KEY,
        _name VARCHAR(60),
        city VARCHAR(60),
        contact_name VARCHAR(60),
        contact_phone VARCHAR(13)
    );
END
BEGIN
    ALTER TABLE dbo.book_reservation
    ADD CONSTRAINT FK_BookReservation_Book FOREIGN KEY (book_name) REFERENCES dbo.book(code) ON UPDATE CASCADE ON DELETE CASCADE;

    ALTER TABLE dbo.book_reservation
    ADD CONSTRAINT FK_BookReservation_Person FOREIGN KEY (abonent) REFERENCES dbo.person(ticket_code) ON UPDATE CASCADE ON DELETE CASCADE;

    
    ALTER TABLE dbo.book
    ADD CONSTRAINT FK_Book_Genre FOREIGN KEY (genre) REFERENCES dbo.genre(code) ON UPDATE CASCADE ON DELETE CASCADE;

    ALTER TABLE dbo.book
    ADD CONSTRAINT FK_Book_Publisher FOREIGN KEY (lable) REFERENCES dbo.publisher(code) ON UPDATE CASCADE ON DELETE CASCADE;

    
    ALTER TABLE dbo.book_reservation
    ADD CONSTRAINT FK_BookReservation_Book FOREIGN KEY (book_name) REFERENCES dbo.book(code) ON UPDATE CASCADE ON DELETE CASCADE;

    ALTER TABLE dbo.book_reservation
    ADD CONSTRAINT FK_BookReservation_Person FOREIGN KEY (abonent) REFERENCES dbo.person(ticket_code) ON UPDATE CASCADE ON DELETE CASCADE;

        ALTER TABLE dbo.book
    ADD CONSTRAINT FK_Book_Genre FOREIGN KEY (genre) REFERENCES dbo.genre(code) ON UPDATE CASCADE ON DELETE CASCADE;

    ALTER TABLE dbo.book
    ADD CONSTRAINT FK_Book_Publisher FOREIGN KEY (lable) REFERENCES dbo.publisher(code) ON UPDATE CASCADE ON DELETE CASCADE;
END

