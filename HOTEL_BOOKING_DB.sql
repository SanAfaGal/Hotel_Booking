-- TABLES

CREATE TABLE tbl_customers (
    id_customer INT IDENTITY(1,1) PRIMARY KEY,
    dni_customer NVARCHAR(12) NOT NULL UNIQUE,
    first_name NVARCHAR(50) NOT NULL,
    last_name NVARCHAR(50) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    phone NVARCHAR(20) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE tbl_room_categories (
    id_category INT IDENTITY(1,1) PRIMARY KEY,
    name_catgory NVARCHAR(50) NOT NULL UNIQUE,
    description NVARCHAR(255) NOT NULL,
    base_price DECIMAL(10, 2) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE tbl_rooms (
    id_room INT IDENTITY(1,1) PRIMARY KEY,
    id_category INT,
    room_status NVARCHAR(20) NOT NULL DEFAULT 'Available' CHECK (room_status IN ('Available', 'Occupied')),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_room_category FOREIGN KEY (id_category) REFERENCES tbl_room_categories(id_category) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE tbl_reservations (
    id_reservation INT IDENTITY(1,1) PRIMARY KEY,
    id_customer INT,
    id_room INT,
    checkin DATETIME NOT NULL,
    checkout DATETIME NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_reservation_customer FOREIGN KEY (id_customer) REFERENCES tbl_customers(id_customer) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT fk_reservation_room FOREIGN KEY (id_room) REFERENCES tbl_rooms(id_room) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT chk_checkout_after_checkin CHECK (checkout > checkin) -- Restriction to ensure checkout is after checkin
);

-- TRIGGERS

CREATE TRIGGER trg_update_customer
ON tbl_customers
AFTER UPDATE
AS
BEGIN
    UPDATE tbl_customers
    SET updated_at = CURRENT_TIMESTAMP
    FROM tbl_customers
    INNER JOIN inserted ON tbl_customers.id_customer = inserted.id_customer;
END;

CREATE TRIGGER trg_update_room_category
ON tbl_room_categories
AFTER UPDATE
AS
BEGIN
    UPDATE tbl_room_categories
    SET updated_at = CURRENT_TIMESTAMP
    FROM tbl_room_categories
    INNER JOIN inserted ON tbl_room_categories.id_category = inserted.id_category;
END;

CREATE TRIGGER trg_update_room
ON tbl_rooms
AFTER UPDATE
AS
BEGIN
    UPDATE tbl_rooms
    SET updated_at = CURRENT_TIMESTAMP
    FROM tbl_rooms
    INNER JOIN inserted ON tbl_rooms.id_room = inserted.id_room;
END;

CREATE TRIGGER trg_update_reservation
ON tbl_reservations
AFTER UPDATE
AS
BEGIN
    UPDATE tbl_reservations
    SET updated_at = CURRENT_TIMESTAMP
    FROM tbl_reservations
    INNER JOIN inserted ON tbl_reservations.id_reservation = inserted.id_reservation;
END;


-- INSERT

INSERT INTO tbl_room_categories (name_catgory, description, base_price)
VALUES 
    ('Standard', 'Standard room with basic amenities', 100.00),
    ('Deluxe', 'Luxury room with additional amenities', 150.00),
    ('Suite', 'Luxury suite with premium amenities', 250.00),
    ('Executive', 'Executive room with extra space', 200.00),
    ('Family', 'Family room with space for the whole family', 180.00);

