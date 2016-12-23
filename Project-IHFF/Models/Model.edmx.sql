
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/23/2016 11:54:36
-- Generated from EDMX file: C:\Users\mauri\Source\Repos\Project-IHFF\Project-IHFF\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [iHFF1617S_B2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PersonsOrders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_PersonsOrders];
GO
IF OBJECT_ID(N'[dbo].[FK_FilmExhibitionsFilms]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FilmExhibitionsSet] DROP CONSTRAINT [FK_FilmExhibitionsFilms];
GO
IF OBJECT_ID(N'[dbo].[FK_FilmTicketsFilmExhibitions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketsSet_FilmTickets] DROP CONSTRAINT [FK_FilmTicketsFilmExhibitions];
GO
IF OBJECT_ID(N'[dbo].[FK_RestaurantReservationRestaurants]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketsSet_RestaurantReservation] DROP CONSTRAINT [FK_RestaurantReservationRestaurants];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketsOrders]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketsSet] DROP CONSTRAINT [FK_TicketsOrders];
GO
IF OBJECT_ID(N'[dbo].[FK_SpecialsSpecialTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketsSet_SpecialTicket] DROP CONSTRAINT [FK_SpecialsSpecialTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_Films_inherits_Items]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Items_Films] DROP CONSTRAINT [FK_Films_inherits_Items];
GO
IF OBJECT_ID(N'[dbo].[FK_FilmTickets_inherits_Tickets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketsSet_FilmTickets] DROP CONSTRAINT [FK_FilmTickets_inherits_Tickets];
GO
IF OBJECT_ID(N'[dbo].[FK_RestaurantReservation_inherits_Tickets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketsSet_RestaurantReservation] DROP CONSTRAINT [FK_RestaurantReservation_inherits_Tickets];
GO
IF OBJECT_ID(N'[dbo].[FK_Restaurants_inherits_Items]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Items_Restaurants] DROP CONSTRAINT [FK_Restaurants_inherits_Items];
GO
IF OBJECT_ID(N'[dbo].[FK_SpecialTicket_inherits_Tickets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketsSet_SpecialTicket] DROP CONSTRAINT [FK_SpecialTicket_inherits_Tickets];
GO
IF OBJECT_ID(N'[dbo].[FK_Specials_inherits_Items]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Items_Specials] DROP CONSTRAINT [FK_Specials_inherits_Items];
GO
IF OBJECT_ID(N'[dbo].[FK_Accounts_inherits_Persons]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons_Accounts] DROP CONSTRAINT [FK_Accounts_inherits_Persons];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[Items]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Items];
GO
IF OBJECT_ID(N'[dbo].[Persons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persons];
GO
IF OBJECT_ID(N'[dbo].[TicketsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketsSet];
GO
IF OBJECT_ID(N'[dbo].[FilmExhibitionsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FilmExhibitionsSet];
GO
IF OBJECT_ID(N'[dbo].[Items_Films]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Items_Films];
GO
IF OBJECT_ID(N'[dbo].[TicketsSet_FilmTickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketsSet_FilmTickets];
GO
IF OBJECT_ID(N'[dbo].[TicketsSet_RestaurantReservation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketsSet_RestaurantReservation];
GO
IF OBJECT_ID(N'[dbo].[Items_Restaurants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Items_Restaurants];
GO
IF OBJECT_ID(N'[dbo].[TicketsSet_SpecialTicket]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketsSet_SpecialTicket];
GO
IF OBJECT_ID(N'[dbo].[Items_Specials]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Items_Specials];
GO
IF OBJECT_ID(N'[dbo].[Persons_Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persons_Accounts];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [id] int IDENTITY(1,1) NOT NULL,
    [date] datetime  NOT NULL,
    [pickupCode] nvarchar(max)  NOT NULL,
    [isPaid] nvarchar(max)  NOT NULL,
    [personId] int  NOT NULL
);
GO

-- Creating table 'Items'
CREATE TABLE [dbo].[Items] (
    [id] int IDENTITY(1,1) NOT NULL,
    [description] nvarchar(max)  NULL,
    [location] nvarchar(max)  NOT NULL,
    [price] decimal(18,0)  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [imagePath] nvarchar(max)  NULL
);
GO

-- Creating table 'Persons'
CREATE TABLE [dbo].[Persons] (
    [id] int IDENTITY(1,1) NOT NULL,
    [firstName] nvarchar(max)  NOT NULL,
    [lastName] nvarchar(max)  NOT NULL,
    [email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TicketsSet'
CREATE TABLE [dbo].[TicketsSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [quantity] nvarchar(max)  NOT NULL,
    [orderId] int  NOT NULL
);
GO

-- Creating table 'FilmExhibitionsSet'
CREATE TABLE [dbo].[FilmExhibitionsSet] (
    [id] int IDENTITY(1,1) NOT NULL,
    [startTime] datetime  NOT NULL,
    [endTime] datetime  NULL,
    [filmId] int  NOT NULL
);
GO

-- Creating table 'Items_Films'
CREATE TABLE [dbo].[Items_Films] (
    [director] nvarchar(max)  NOT NULL,
    [actors] nvarchar(max)  NOT NULL,
    [capacity] nvarchar(max)  NOT NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'TicketsSet_FilmTickets'
CREATE TABLE [dbo].[TicketsSet_FilmTickets] (
    [filmExhibitionId] int  NOT NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'TicketsSet_RestaurantReservation'
CREATE TABLE [dbo].[TicketsSet_RestaurantReservation] (
    [restaurantId] int  NOT NULL,
    [reservationTime] datetime  NOT NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'Items_Restaurants'
CREATE TABLE [dbo].[Items_Restaurants] (
    [timeOpen] time  NOT NULL,
    [timeClosed] time  NOT NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'TicketsSet_SpecialTicket'
CREATE TABLE [dbo].[TicketsSet_SpecialTicket] (
    [specialId] int  NOT NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'Items_Specials'
CREATE TABLE [dbo].[Items_Specials] (
    [host] nvarchar(max)  NOT NULL,
    [capacity] int  NOT NULL,
    [startTime] datetime  NOT NULL,
    [endTime] datetime  NOT NULL,
    [id] int  NOT NULL
);
GO

-- Creating table 'Persons_Accounts'
CREATE TABLE [dbo].[Persons_Accounts] (
    [password] nvarchar(max)  NOT NULL,
    [phoneNumber] nvarchar(max)  NOT NULL,
    [id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [PK_Persons]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TicketsSet'
ALTER TABLE [dbo].[TicketsSet]
ADD CONSTRAINT [PK_TicketsSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'FilmExhibitionsSet'
ALTER TABLE [dbo].[FilmExhibitionsSet]
ADD CONSTRAINT [PK_FilmExhibitionsSet]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Items_Films'
ALTER TABLE [dbo].[Items_Films]
ADD CONSTRAINT [PK_Items_Films]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TicketsSet_FilmTickets'
ALTER TABLE [dbo].[TicketsSet_FilmTickets]
ADD CONSTRAINT [PK_TicketsSet_FilmTickets]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TicketsSet_RestaurantReservation'
ALTER TABLE [dbo].[TicketsSet_RestaurantReservation]
ADD CONSTRAINT [PK_TicketsSet_RestaurantReservation]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Items_Restaurants'
ALTER TABLE [dbo].[Items_Restaurants]
ADD CONSTRAINT [PK_Items_Restaurants]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TicketsSet_SpecialTicket'
ALTER TABLE [dbo].[TicketsSet_SpecialTicket]
ADD CONSTRAINT [PK_TicketsSet_SpecialTicket]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Items_Specials'
ALTER TABLE [dbo].[Items_Specials]
ADD CONSTRAINT [PK_Items_Specials]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Persons_Accounts'
ALTER TABLE [dbo].[Persons_Accounts]
ADD CONSTRAINT [PK_Persons_Accounts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [personId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_PersonsOrders]
    FOREIGN KEY ([personId])
    REFERENCES [dbo].[Persons]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonsOrders'
CREATE INDEX [IX_FK_PersonsOrders]
ON [dbo].[Orders]
    ([personId]);
GO

-- Creating foreign key on [filmId] in table 'FilmExhibitionsSet'
ALTER TABLE [dbo].[FilmExhibitionsSet]
ADD CONSTRAINT [FK_FilmExhibitionsFilms]
    FOREIGN KEY ([filmId])
    REFERENCES [dbo].[Items_Films]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmExhibitionsFilms'
CREATE INDEX [IX_FK_FilmExhibitionsFilms]
ON [dbo].[FilmExhibitionsSet]
    ([filmId]);
GO

-- Creating foreign key on [filmExhibitionId] in table 'TicketsSet_FilmTickets'
ALTER TABLE [dbo].[TicketsSet_FilmTickets]
ADD CONSTRAINT [FK_FilmTicketsFilmExhibitions]
    FOREIGN KEY ([filmExhibitionId])
    REFERENCES [dbo].[FilmExhibitionsSet]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FilmTicketsFilmExhibitions'
CREATE INDEX [IX_FK_FilmTicketsFilmExhibitions]
ON [dbo].[TicketsSet_FilmTickets]
    ([filmExhibitionId]);
GO

-- Creating foreign key on [restaurantId] in table 'TicketsSet_RestaurantReservation'
ALTER TABLE [dbo].[TicketsSet_RestaurantReservation]
ADD CONSTRAINT [FK_RestaurantReservationRestaurants]
    FOREIGN KEY ([restaurantId])
    REFERENCES [dbo].[Items_Restaurants]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RestaurantReservationRestaurants'
CREATE INDEX [IX_FK_RestaurantReservationRestaurants]
ON [dbo].[TicketsSet_RestaurantReservation]
    ([restaurantId]);
GO

-- Creating foreign key on [orderId] in table 'TicketsSet'
ALTER TABLE [dbo].[TicketsSet]
ADD CONSTRAINT [FK_TicketsOrders]
    FOREIGN KEY ([orderId])
    REFERENCES [dbo].[Orders]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketsOrders'
CREATE INDEX [IX_FK_TicketsOrders]
ON [dbo].[TicketsSet]
    ([orderId]);
GO

-- Creating foreign key on [specialId] in table 'TicketsSet_SpecialTicket'
ALTER TABLE [dbo].[TicketsSet_SpecialTicket]
ADD CONSTRAINT [FK_SpecialsSpecialTicket]
    FOREIGN KEY ([specialId])
    REFERENCES [dbo].[Items_Specials]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpecialsSpecialTicket'
CREATE INDEX [IX_FK_SpecialsSpecialTicket]
ON [dbo].[TicketsSet_SpecialTicket]
    ([specialId]);
GO

-- Creating foreign key on [id] in table 'Items_Films'
ALTER TABLE [dbo].[Items_Films]
ADD CONSTRAINT [FK_Films_inherits_Items]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Items]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'TicketsSet_FilmTickets'
ALTER TABLE [dbo].[TicketsSet_FilmTickets]
ADD CONSTRAINT [FK_FilmTickets_inherits_Tickets]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[TicketsSet]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'TicketsSet_RestaurantReservation'
ALTER TABLE [dbo].[TicketsSet_RestaurantReservation]
ADD CONSTRAINT [FK_RestaurantReservation_inherits_Tickets]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[TicketsSet]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'Items_Restaurants'
ALTER TABLE [dbo].[Items_Restaurants]
ADD CONSTRAINT [FK_Restaurants_inherits_Items]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Items]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'TicketsSet_SpecialTicket'
ALTER TABLE [dbo].[TicketsSet_SpecialTicket]
ADD CONSTRAINT [FK_SpecialTicket_inherits_Tickets]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[TicketsSet]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'Items_Specials'
ALTER TABLE [dbo].[Items_Specials]
ADD CONSTRAINT [FK_Specials_inherits_Items]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Items]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'Persons_Accounts'
ALTER TABLE [dbo].[Persons_Accounts]
ADD CONSTRAINT [FK_Accounts_inherits_Persons]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Persons]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------