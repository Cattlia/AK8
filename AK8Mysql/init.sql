CREATE DATABASE IF NOT EXISTS bilarkiv;
USE bilarkiv;

CREATE TABLE IF NOT EXISTS cars (
    id INT AUTO_INCREMENT PRIMARY KEY,
    type VARCHAR(50) NOT NULL,
    color VARCHAR(20) NOT NULL,
    window_type VARCHAR(20) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO cars (type, color, window_type) VALUES
('car', 'red', 'clear'),
('bus', 'blue', 'tinted'),
('car', 'green', 'clear'),
('bus', 'yellow', 'tinted');

SELECT DATABASE() AS 'Current Database';
SELECT table_name FROM information_schema.tables WHERE table_schema = 'bilarkiv';
SELECT * FROM bilarkiv.cars;