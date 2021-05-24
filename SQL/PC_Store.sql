CREATE TABLE `ram` (
  `product_id` int NOT NULL,
  `product_name` varchar(40) NOT NULL,
  `ddr_type` varchar(12) NOT NULL,
  `frequency` int NOT NULL,
  `capacity` int NOT NULL,
  `num_of_modules` varchar(12) not null,
  `type` varchar(10) not null,
  `price` float NOT NULL,
  PRIMARY KEY (`product_id`)
);

CREATE TABLE power_supply (
	product_id INT NOT NULL,
    product_name VARCHAR(40) NOT NULL,
    power VARCHAR(8) NOT NULL,
    cable_management BOOLEAN NOT NULL,
    sata_connectors INT NOT NULL,
    form_factor VARCHAR(15) NOT NULL,
    pcie_8pin_connectors INT NOT NULL,
    pcie_6pin_connectors INT NOT NULL,
    molex_connectors INT NOT NULL,
    price FLOAT NOT NULL,
    PRIMARY KEY (product_id)
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
    PRIMARY KEY (product_id)
);

CREATE TABLE ssd_drives (
	product_id INT NOT NULL,
    product_name VARCHAR(40) NOT NULL,
    interface_type VARCHAR(10) NOT NULL,
    capacity VARCHAR(10) NOT NULL,
    form_factor VARCHAR(10) NOT NULL,
    nvme BOOLEAN NOT NULL,
    reading_speed VARCHAR(10) NOT NULL,
    writing_speed VARCHAR(10) NOT NULL,
    price FLOAT NOT NULL,
    PRIMARY KEY (product_id)
);

CREATE TABLE tower_cooling (
	product_id INT NOT NULL,
    product_name VARCHAR(40) NOT NULL,
    speed_range VARCHAR(25) NOT NULL,
    height VARCHAR(10) NOT NULL,
    weight VARCHAR(10) NOT NULL,
    fan_size VARCHAR(10) NOT NULL,
    cooler_type VARCHAR(10) NOT NULL,
    cpu_socket VARCHAR(25) NOT NULL,
    max_volume VARCHAR(10) NOT NULL,
    price FLOAT NOT NULL,
    PRIMARY KEY (product_id)
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
	PRIMARY KEY (product_id)
);

CREATE TABLE `processor` (
  `product_id` int NOT NULL,
  `product_name` varchar(40) NOT NULL,
  `cpu_socket` varchar(20) NOT NULL,
  `cpu_cores` int NOT NULL,
  `threads` int NOT NULL,
  `cpu_speed` float NOT NULL,
  `integrated_graphics` varchar(10) not null,
  `price` float NOT NULL,
  PRIMARY KEY (`product_id`)
);

CREATE TABLE `graphics_card` (
  `product_id` int NOT NULL,
  `product_name` varchar(40) NOT NULL,
  `vram_type` varchar(12) NOT NULL,
  `vram_capacity` int NOT NULL,
  `bus_width` varchar(6) NOT NULL,
  `connectors` varchar(25) NOT NULL,
  `price` float NOT NULL,
  PRIMARY KEY (`product_id`)
);

CREATE TABLE product (
	product_code INT NOT NULL,
    product_name VARCHAR(40) NOT NULL,
    product_type INT NOT NULL,
    FOREIGN KEY (product_type) REFERENCES product_types(type_id),
    FOREIGN KEY (product_code) REFERENCES ram(product_id),
    FOREIGN KEY (product_code) REFERENCES graphics_card(product_id),
    FOREIGN KEY (product_code) REFERENCES processor(product_id),
    FOREIGN KEY (product_code) REFERENCES hdd_drives(product_id),
    FOREIGN KEY (product_code) REFERENCES power_supply(product_id),
    FOREIGN KEY (product_code) REFERENCES tower_cooling(product_id),
    FOREIGN KEY (product_code) REFERENCES water_cooling(product_id),
    FOREIGN KEY (product_code) REFERENCES ssd_drives(product_id),
    FOREIGN KEY (product_name) REFERENCES ram(product_name),
    FOREIGN KEY (product_name) REFERENCES graphics_card(product_name),
    FOREIGN KEY (product_name) REFERENCES processor(product_name),
    FOREIGN KEY (product_name) REFERENCES hdd_drives(product_name),
    FOREIGN KEY (product_name) REFERENCES power_supply(product_name),
    FOREIGN KEY (product_name) REFERENCES tower_cooling(product_name),
    FOREIGN KEY (product_name) REFERENCES water_cooling(product_name),
    FOREIGN KEY (product_name) REFERENCES ssd_drives(product_name)
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
    FOREIGN KEY (product_id) REFERENCES basket(product_id)
);
