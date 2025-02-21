CREATE DATABASE IF NOT EXISTS Vehicledatabase;
USE Vehicledatabase;
CREATE TABLE IF NOT EXISTS cars (
    id INT AUTO_INCREMENT PRIMARY KEY,
    type VARCHAR(50) NOT NULL,
    color VARCHAR(20) NOT NULL,
    window_type VARCHAR(20) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);
INSERT INTO cars (type, color, window_type) VALUES
    ('Car', 'Red', 'Clear'),
    ('Bus', 'Blue', 'Tinted'),
    ('Car', 'Green', 'Clear'),
    ('Bus', 'Yellow', 'Tinted');
SELECT DATABASE() AS 'Current Database';
SELECT table_name FROM information_schema.tables WHERE table_schema = 'Vehicledatabase';
SELECT * FROM Vehicledatabase.cars;
GRANT ALL PRIVILEGES ON Vehicledatabase.* TO 'user1'@'%';
FLUSH PRIVILEGES;