use `llbqqdkmx4mkoa68`;

CREATE TABLE `ram` (
  `product_id` int NOT NULL,
  `product_name` varchar(40) NOT NULL,
  `ddr_type` varchar(12) NOT NULL,
  `frequency` varchar(20) NOT NULL,
  `capacity` varchar(10) NOT NULL,
  `num_of_modules` varchar(12) not null,
  `type` varchar(15) not null,
  `price` float NOT NULL,
  PRIMARY KEY (`product_id`),
  CONSTRAINT FK_product_id UNIQUE (product_id),
  CONSTRAINT FK_product_name UNIQUE (product_name),
  FOREIGN KEY (product_id) REFERENCES product(product_code) ON DELETE CASCADE,
  FOREIGN KEY (product_name) REFERENCES product(product_name) ON DELETE CASCADE
);

CREATE TABLE power_supply (
	product_id INT NOT NULL,
    product_name VARCHAR(50) NOT NULL,
    power VARCHAR(15) NOT NULL,
    cable_management BOOLEAN NOT NULL,
    sata_connectors INT NOT NULL,
    form_factor VARCHAR(15) NOT NULL,
    pcie_8pin_connectors INT NOT NULL,
    pcie_6pin_connectors INT NOT NULL,
    molex_connectors INT NOT NULL,
    price FLOAT NOT NULL,
    PRIMARY KEY (product_id),    
  CONSTRAINT FK_product_id UNIQUE (product_id),
  CONSTRAINT FK_product_name UNIQUE (product_name),
  FOREIGN KEY (product_id) REFERENCES product(product_code) ON DELETE CASCADE,
  FOREIGN KEY (product_name) REFERENCES product(product_name) ON DELETE CASCADE
);

CREATE TABLE hdd_drives (
	product_id INT NOT NULL,
    product_name VARCHAR(40) NOT NULL,
    interface_type VARCHAR(10) NOT NULL,
    capacity VARCHAR(10) NOT NULL,
    form_factor VARCHAR(10) NOT NULL,
    spindle_speed VARCHAR(10) NOT NULL,
    cache_capacity VARCHAR(10) NOT NULL,
    price FLOAT NOT NULL,
    PRIMARY KEY (product_id),
  CONSTRAINT FK_product_id UNIQUE (product_id),
  CONSTRAINT FK_product_name UNIQUE (product_name),
  FOREIGN KEY (product_id) REFERENCES product(product_code) ON DELETE CASCADE,
  FOREIGN KEY (product_name) REFERENCES product(product_name) ON DELETE CASCADE
);

CREATE TABLE ssd_drives (
	product_id INT NOT NULL,
    product_name VARCHAR(40) NOT NULL,
    interface_type VARCHAR(20) NOT NULL,
    capacity VARCHAR(10) NOT NULL,
    form_factor VARCHAR(10) NOT NULL,
    nvme BOOLEAN NOT NULL,
    reading_speed VARCHAR(10) NOT NULL,
    writing_speed VARCHAR(10) NOT NULL,
    price FLOAT NOT NULL,
    PRIMARY KEY (product_id),
  CONSTRAINT FK_product_id UNIQUE (product_id),
  CONSTRAINT FK_product_name UNIQUE (product_name),
  FOREIGN KEY (product_id) REFERENCES product(product_code) ON DELETE CASCADE,
  FOREIGN KEY (product_name) REFERENCES product(product_name) ON DELETE CASCADE
);

CREATE TABLE tower_cooling (
	product_id INT NOT NULL,
    product_name VARCHAR(40) NOT NULL,
    speed_range VARCHAR(25) NOT NULL,
    height VARCHAR(10) NOT NULL,
    weight VARCHAR(10) NOT NULL,
    fan_size VARCHAR(10) NOT NULL,
    cooler_type VARCHAR(10) NOT NULL,
    cpu_socket VARCHAR(40) NOT NULL,
    max_volume VARCHAR(10) NOT NULL,
    price FLOAT NOT NULL,
    PRIMARY KEY (product_id),
  CONSTRAINT FK_product_id UNIQUE (product_id),
  CONSTRAINT FK_product_name UNIQUE (product_name),
  FOREIGN KEY (product_id) REFERENCES product(product_code) ON DELETE CASCADE,
  FOREIGN KEY (product_name) REFERENCES product(product_name) ON DELETE CASCADE
);

CREATE TABLE water_cooling (
	product_id INT NOT NULL,
    product_name VARCHAR(40) NOT NULL,
    fan_size VARCHAR(10) NOT NULL,
    cpu_socket VARCHAR(25) NOT NULL,
    cooler_type VARCHAR(10) NOT NULL,
    installed_fans INT NOT NULL,
    max_volume VARCHAR(10) NOT NULL,
    price FLOAT NOT NULL,
	PRIMARY KEY (product_id),
  CONSTRAINT FK_product_id UNIQUE (product_id),
  CONSTRAINT FK_product_name UNIQUE (product_name),
  FOREIGN KEY (product_id) REFERENCES product(product_code) ON DELETE CASCADE,
  FOREIGN KEY (product_name) REFERENCES product(product_name) ON DELETE CASCADE
);

CREATE TABLE `processor` (
  `product_id` int NOT NULL,
  `product_name` varchar(40) NOT NULL,
  `cpu_socket` varchar(20) NOT NULL,
  `cpu_cores` int NOT NULL,
  `threads` int NOT NULL,
  `cpu_speed` float NOT NULL,
  `integrated_graphics` varchar(30) not null,
  `price` float NOT NULL,
  PRIMARY KEY (`product_id`),
  CONSTRAINT FK_product_id UNIQUE (product_id),
  CONSTRAINT FK_product_name UNIQUE (product_name),
  FOREIGN KEY (product_id) REFERENCES product(product_code) ON DELETE CASCADE,
  FOREIGN KEY (product_name) REFERENCES product(product_name) ON DELETE CASCADE
);

CREATE TABLE `graphics_card` (
  `product_id` int NOT NULL,
  `product_name` varchar(40) NOT NULL,
  `vram_type` varchar(12) NOT NULL,
  `vram_capacity` int NOT NULL,
  `bus_width` varchar(15) NOT NULL,
  `connectors` varchar(40) NOT NULL,
  `price` float NOT NULL,
  PRIMARY KEY (`product_id`),
  CONSTRAINT FK_product_id UNIQUE (product_id),
  CONSTRAINT FK_product_name UNIQUE (product_name),
  FOREIGN KEY (product_id) REFERENCES product(product_code) ON DELETE CASCADE,
  FOREIGN KEY (product_name) REFERENCES product(product_name) ON DELETE CASCADE
);

CREATE TABLE product (
	product_code INT NOT NULL,
    product_name VARCHAR(50) NOT NULL,
    product_type INT NOT NULL,
    CONSTRAINT FK_product_name UNIQUE (product_name),
    CONSTRAINT FK_product_code UNIQUE (product_code),
    primary key (product_code, product_name, product_type),
    foreign key (product_type) references product_types(type_id)
);

CREATE TABLE product_types (
	type_id INT NOT NULL,
    type_name VARCHAR(20) NOT NULL,
    PRIMARY KEY (type_id)
);

CREATE TABLE basket (
  id INT NOT NULL,
  user_id bigint unsigned NOT NULL,
  product_id int NOT NULL,
  counts int NOT NULL,
  date_add datetime NOT NULL,
  PRIMARY KEY (id),
  CONSTRAINT FK_counts_basket UNIQUE (counts),
  FOREIGN KEY (product_id) REFERENCES product(product_code) ,
  FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE orders (
	id INT NOT NULL, 
    user_id BIGINT UNSIGNED NOT NULL,
    product_id INT NOT NULL,
    counts INT NOT NULL,
    price FLOAT NOT NULL,
    purchase_date DATETIME NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (user_id) REFERENCES basket(user_id),
    FOREIGN KEY (product_id) REFERENCES basket(product_id),
    FOREIGN KEY (counts) REFERENCES basket(counts)
);

CREATE TABLE `users` (
  `user_id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `user_login` varchar(60) NOT NULL,
  `password_hash` varchar(200) NOT NULL,
  `password_salt` varchar(20) NOT NULL,
  `user_name` varchar(60) NOT NULL,
  `user_lastname` varchar(60) NOT NULL,
  `email` varchar(100) NOT NULL,
  `user_role` int NOT NULL,
  `created_at` datetime NOT NULL,
  `last_login` datetime NOT NULL,
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `user_id` (`user_id`),
  UNIQUE KEY `user_login` (`user_login`),
  UNIQUE KEY `email` (`email`),
  KEY `user_role` (`user_role`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`user_role`) REFERENCES `roles` (`role_id`)
);

CREATE TABLE `roles` (
  `role_id` int NOT NULL,
  `role_type` varchar(60) NOT NULL,
  PRIMARY KEY (`role_id`),
  UNIQUE KEY `role_id` (`role_id`)
);

CREATE TRIGGER auto_add_ram   
BEFORE INSERT ON ram FOR EACH ROW INSERT INTO product VALUES (NEW.product_id, NEW.product_name, 1);

CREATE TRIGGER auto_add_ssd_drives   
BEFORE INSERT ON ssd_drives FOR EACH ROW INSERT INTO product VALUES (NEW.product_id, NEW.product_name, 6);

CREATE TRIGGER auto_add_hdd_drives   
BEFORE INSERT ON hdd_drives FOR EACH ROW INSERT INTO product VALUES (NEW.product_id, NEW.product_name, 7);

CREATE TRIGGER auto_add_processor  
BEFORE INSERT ON processor FOR EACH ROW INSERT INTO product VALUES (NEW.product_id, NEW.product_name, 5);

CREATE TRIGGER auto_add_tower_cooling  
BEFORE INSERT ON tower_cooling FOR EACH ROW INSERT INTO product VALUES (NEW.product_id, NEW.product_name, 4);

CREATE TRIGGER auto_add_water_cooling
BEFORE INSERT ON water_cooling FOR EACH ROW INSERT INTO product VALUES (NEW.product_id, NEW.product_name, 3);

CREATE TRIGGER auto_add_power_supply   
BEFORE INSERT ON power_supply FOR EACH ROW INSERT INTO product VALUES (NEW.product_id, NEW.product_name, 8);

CREATE TRIGGER auto_add_graphics   
BEFORE INSERT ON graphics_card FOR EACH ROW INSERT INTO product VALUES (NEW.product_id, NEW.product_name, 2);

-- Delete triggers
CREATE TRIGGER auto_delete_graphics   
AFTER DELETE ON graphics_card FOR EACH ROW DELETE FROM product WHERE product_code=old.product_id;

CREATE TRIGGER auto_delete_ram   
AFTER DELETE ON ram FOR EACH ROW DELETE FROM product WHERE product_code=old.product_id;

CREATE TRIGGER auto_delete_ssd 
AFTER DELETE ON ssd_drives FOR EACH ROW DELETE FROM product WHERE product_code=old.product_id;

CREATE TRIGGER auto_delete_hdd   
AFTER DELETE ON hdd_drives FOR EACH ROW DELETE FROM product WHERE product_code=old.product_id;

CREATE TRIGGER auto_delete_tower_cooling
AFTER DELETE ON tower_cooling FOR EACH ROW DELETE FROM product WHERE product_code=old.product_id;

CREATE TRIGGER auto_delete_water_cooling
AFTER DELETE ON water_cooling FOR EACH ROW DELETE FROM product WHERE product_code=old.product_id;

CREATE TRIGGER auto_delete_processor
AFTER DELETE ON processor FOR EACH ROW DELETE FROM product WHERE product_code=old.product_id;

CREATE TRIGGER auto_delete_power_supply
AFTER DELETE ON power_supply FOR EACH ROW DELETE FROM product WHERE product_code=old.product_id;
