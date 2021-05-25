INSERT graphics_card 
VALUES (483, 'PNY Quadro RTX4000', 'GDDR6', 8, '256bit', 'DisplayPort x 4', 864.76),
	   (431, 'Sapphire Radeon PULSE RX 550', 'GDDR5', 2, '64bit', 'DisplayPort x 1, HDMI x 1, DVI x 1', 94.16),
       (278, 'Palit GeForce GTX1050Ti StormX', 'GDDR5', 4, '128bit', 'DisplayPort x 1, HDMI x 1, DVI x 1', 310.08),
       (636, 'AMD Radeon Pro WX9100', 'GDDR6', 16, '2048bit', 'DisplayPort x 4', 1538.17),
       (426, 'ASUS GeForce GT 710-SL-1GD5-BRK', 'GDDR5', 1, '32bit', 'DVI x 1, HDMI x 1', 44.50),
       (968, 'PNY Quadro RTX5000', 'GDDR6', 16, '256bit', 'DisplayPort x 4', 1874.42),
       (269, 'PNY Quadro P620 4xMDP', 'GDDR5', 2, '128bit', 'miniDisplayPort x 4', 171.96),
       (205, 'ASUS GT710-H4-SL-2GD5', 'GDDR5', 2, '64bit', 'HDMI x 4', 83.11),
       (283, 'ZOTAC GeForce GT 1030', 'GDDR5', 2, '64bit', 'DVI x 1, HDMI x 1', 112.35),
       (466, 'Sapphire GPRO 4300', 'GDDR5', 4, '128bit', 'miniDisplayPort x 4', 181.55);

INSERT processor 
VALUES (318, 'AMD Ryzen 5 5600X Boxed', 'Sockel AM4', 6, 12, 3.70, 'no integerated GPU', 252.09),
	   (975, 'AMD Ryzen 7 3700X Boxed', 'Sockel AM4', 8, 16, 3.60, 'no integerated GPU', 234.50),
	   (404, 'Intel Core i9-9900', 'Sockel 1151-v2', 8, 16, 3.10, 'Intel UHD Graphics 630', 263.84),
	   (261, 'Intel Core i7-10700K', 'Sockel 1200', 8, 16, 3.80, 'Intel UHD Graphics 630', 294.12),
	   (827, 'AMD Ryzen 9 5950X BOX', 'Sockel AM4', 16, 32, 3.40, 'no integerated GPU', 704.19),
	   (470, 'AMD Ryzen 9 5900X Box', 'Sockel AM4', 12, 24, 3.70, 'no integerated GPU', 486.55),
	   (303, 'Intel Core i5-7600K', 'Sockel 1151', 4, 4, 3.80, 'Intel UHD Graphics 630', 151.00),
	   (130, 'AMD Ryzen 5 3600 Boxed', 'Sockel AM4', 6, 12, 3.60, 'no integerated GPU', 159.66),
	   (864, 'Intel Core i7-9700KF', 'Sockel 1151-v2', 8, 8, 3.60, 'no integerated GPU', 209.23),
	   (519, 'AMD Ryzen 3 1200 AF Box', 'Sockel AM4', 4, 4, 3.10, 'no integerated GPU', 85.57);
       
INSERT hdd_drives 
VALUES (338, 'WD Gold WD6003FRYZ', 'SATA3', '6.0 TB', '3.5"', '7200 rpm', '256 MB', 252.09),
	   (706, 'WD Gold WD4003FRYZ', 'SATA3', '4.0 TB', '3.5"', '5400 rpm', '256 MB', 195.39),
	   (964, 'WD Blue Desktop WD20EZAZ', 'SATA3', '2.0 TB', '3.5"', '7200 rpm', '256 MB', 46.13),
	   (396, 'Seagate IronWolf Pro ST8000NE001', 'SATA3', '8.0 TB', '3.5"', '7200 rpm', '256 MB', 259.66),
	   (460, 'Seagate Skyhawk ST2000VX008', 'SATA3', '2.0 TB', '3.5"', '7200 rpm', '64 MB', 67.14),
	   (455, 'WD Ultrastar DC HC510 HUH721010ALE600', 'SATA3', '10.0 TB', '3.5"', '7200 rpm', '256 MB', 427.23),
	   (331, 'Toshiba X300 High-Performance', 'SATA3', '4.0 TB', '3.5"', '7200 rpm', '128 MB', 110.09),
	   (957, 'WD Red Plus WD40EFZX', 'SATA3', '4.0 TB', '3.5"', '5400 rpm', '128 MB', 109.16),
	   (532, 'Toshiba P300 HDWD240UZSVA', 'SATA3', '4.0 TB', '3.5"', '5400 rpm', '128 MB', 101.60),
	   (777, 'Seagate EXOS 7E8 ST4000NM000A', 'SATA3', '4.0 TB', '3.5"', '7200 rpm', '256 MB', 142.77);
       
INSERT power_supply 
VALUES (933, 'Cooler Master MWE V2 Bronze White Edition', '600 Watt', 0, 6, 'ATX', 4, 4, 0, 33.61),
       (658, 'Cooler Master MWE V2 Bronze', '700 Watt', 0, 8, 'ATX', 4, 4, 0, 42.01),
       (263, 'GIGABYTE GP-P650B Netzteil', '660 Watt', 0, 6, 'ATX', 1, 4, 3, 41.92),
       (492, 'Seasonic Prime Ultra 1300 Platinum', '1300 Watt', 1, 12, 'ATX', 12, 0, 5, 293.23),
       (929, 'Seasonic Prime Ultra 1300 Gold', '1300 Watt', 1, 12, 'ATX', 12, 12, 5, 235.21),
       (319, 'Corsair TX750M 80+ Gold', '750 Watt', 1, 8, 'ATX', 4, 4, 7, 83.34),
       (112, 'GIGABYTE GP-P850GM 80+ Gold', '850 Watt', 1, 8, 'ATX', 4, 4, 3, 79.82),
       (479, 'MSI MPG A750GF', '750 Watt', 1, 8, 'ATX', 6, 0, 5, 104.96),
       (998, 'MSI MPG A650GF', '650 Watt', 1, 8, 'ATX', 4, 0, 5, 75.62),
       (392, 'NZXT C750 80+ Gold', '750 Watt', 1, 8, 'ATX', 6, 6, 6, 94.87);
       
INSERT ram 
VALUES (363, 'G.Skill Trident Z', 'DDR4', '3600 MHz', '32 GB', '2x 16 GB Kit', 'DIMM 288 Pin', 152.93),
	   (291, 'Kingston HyperX Fury Black', 'DDR4', '3200 MHz', '32 GB', '2x 16 GB Kit', 'DIMM 288 Pin', 155.21),
	   (339, 'Crucial CT16G4SFRA32A', 'DDR4', '3200 MHz', '16 GB', '1x 16 GB Kit', 'SO-DIMM 260 Pin', 68.82),
	   (720, 'Crucial Ballistix Black RGB', 'DDR4', '3600 MHz', '16 GB', '2x 8 GB Kit', 'DIMM 288 Pin', 93.18),
	   (520, 'Crucial Ballistix Black', 'DDR4', '3600 MHz', '32 GB', '2x 16 GB Kit', 'DIMM 288 Pin', 159.57),
	   (432, 'Patriot Viper4 Blackout', 'DDR4', '3600 MHz', '16 GB', '2x 8 GB Kit', 'DIMM 288 Pin', 79.84),
	   (160, 'G.Skill Aegis', 'DDR4', '3200 MHz', '16 GB', '2x 8 GB Kit', 'DIMM 288 Pin', 70.53),
	   (901, 'Corsair Vengeance LPX Schwarz', 'DDR4', '3600 MHz', '16 GB', '2x 8 GB Kit', 'DIMM 288 Pin', 80.65),
	   (513, 'Patriot Viper Steel', 'DDR4', '3600 MHz', '16 GB', '2x 8 GB Kit', 'DIMM 288 Pin', 83.62),
	   (517, 'G.Skill Ripjaws V', 'DDR4', '3200 MHz', '16 GB', '2x 8 GB Kit', 'DIMM 288 Pin', 79.75);
       
INSERT ssd_drives 
VALUES (275, 'Corsair SSD MP600 CORE', 'PCI Express x4', '1.0 TB', 'M.2', 1, '4700 MB/s', '1950 MB/s', 137.83),
	   (966, 'Toshiba SSD RD500', 'PCI Express x4', '1.0 TB', 'M.2', 1, '3400 MB/s', '3200 MB/s', 108.24),
	   (441, 'Corsair Force MP510B', 'PCI Express x4', '960 GB', 'M.2', 1, '3480 MB/s', '3000 MB/s', 119.52),
	   (358, 'Samsung SSD 970 Evo Plus', 'PCI Express x4', '2.0 TB', 'M.2', 1, '3500 MB/s', '3300 MB/s', 352.93),
	   (962, 'Samsung 870 EVO', 'SATA3', '1.0 TB', '2.5"', 0, '560 MB/s', '530 MB/s', 96.63),
	   (526	, 'WD Black SSD SN850 Gaming', 'PCI Express x4', '1.0 TB', 'M.2', 1, '7000 MB/s', '5100 MB/s', 403.35),
	   (748, 'Samsung SSD 980 Pro', 'PCI Express x4', '500 GB', 'M.2', 1, '6900 MB/s', '5000 MB/s', 107.55),
	   (244, 'Samsung SSD 870 QVO', 'SATA3', '4.0 TB', '2.5"', 0, '560 MB/s', '530 MB/s', 294.11),
	   (764, 'Seagate BarraCuda Q1', 'SATA3', '960 GB', '2.5"', 0, '550 MB/s', '500 MB/s', 71.42),
	   (110, 'Crucial BX500', 'SATA3', '2.0 TB', '2.5"', 0, '540 MB/s', '500 MB/s', 168.06);
       
INSERT tower_cooling 
VALUES (282, 'Thermalright ARO-M14G', '300 - 1300 rpm', '16.2 cm', '880 g', '140 mm', 'Tower', 'AM4', '21.0 dB', 39.83),
	   (979, 'be quiet! Pure Rock 2 silber', '1500 rpm', '15.5 cm', '575 g', '120 mm', 'Tower', '2011 / 2011-v3 / 2066', '26.8 dB', 29.33),
	   (991, 'Arctic Freezer 7X CO', '300 - 2000 rpm', '13.3 cm', '425 g', '92 mm', 'Tower', '115x / 1200', '25.0 dB', 15.61),
	   (863, 'be quiet! Dark Rock Slim', '1500 rpm', '15.9 cm', '620 g', '120 mm', 'Tower', '2011 / 2011-v3 / 2066', '23.6 dB', 44.45),
	   (476, 'be quiet! Pure Rock 2', '1500 rpm', '15.5 cm', '575 g', '120 mm', 'Tower', 'AM4', '26.8 dB', 33.54),
	   (828, 'Arctic Freezer 7 X', '300 - 2000 rpm', '13.3 cm', '425 g', '92 mm', 'Tower', '775', '24.6 dB', 13.86),
	   (227, 'Noctua NH-U12S chromax.black', '1500 rpm', '15.8 cm', '755 g', '120 mm', 'Tower', '2011 / 2011-v3 / 2066', '22.4 dB', 70.53),
	   (550, 'GIGABYTE GP-ATC800', '600 - 2000 rpm', '16.3 cm', '1015 g', '120 mm', 'Tower', 'AM2 (+) / AM3 (+) / FM1 / FM2 (+)', '31.0 dB', 74.54),
	   (628, 'Cooler Master Wraith Ripper RGB', '0 - 2750 rpm', '16.2 cm', '1620 g', '120 mm', 'Tower', 'TR4', '38.0 dB', 92.38),
	   (904, 'Scythe Cooler Ninja 5 SCNJ-5000', '300 - 800 rpm', '15.5 cm', '1200 g', '120 mm', 'Tower', '2011 / 2011-v3 / 2066', '14.5 dB', 41.17);

INSERT water_cooling 
VALUES (924, 'Arctic Liquid Freezer II 280', '140 mm', '115x / 1200', 'Liquid', 2, '21.0 dB', 86.62),
	   (977, 'Corsair Hydro Series H100i RGB PLATINUM', '120 mm', '2011 / 2011-v3 / 2066', 'Liquid', 2, '36.0 dB', 144.54),
	   (678, 'Corsair Hydro Series H115i RGB', '140 mm', '2011 / 2011-v3 / 2066', 'Liquid', 2, '37.0 dB', 123.78),
	   (857, 'Cooler Master Masterliquid ML360R RGB', '120 mm', '2011 / 2011-v3 / 2066', 'Liquid', 3, '30.0 dB', 92.43),
	   (722, 'EVGA CLC 280', '140 mm', '2011 / 2011-v3 / 2066', 'Liquid', 2, '39.5 dB', 84.03),
	   (726, 'Thermaltake Water 3.0 Riing RGB 280', '140 mm', '2011 / 2011-v3 / 2066', 'Liquid', 2, '26.4 dB', 84.34),
	   (524, 'MSI MAG CORELIQUID 360R', '120 mm', '115x / 1200', 'Liquid', 3, '34.3 dB', 106.68),
	   (787, 'NZXT Kraken Z73', '120 mm', '2011 / 2011-v3 / 2066', 'Liquid', 3, '36.0 dB', 230.25),
	   (171, 'Enermax Liqmax III RGB 240', '120 mm', '2011 / 2011-v3 / 2066', 'Liquid', 2, '27.0 dB', 52.51),
	   (918, 'ADATA Liquid Cooling Levante XPG 240', '120 mm', '1366', 'Liquid', 2, '34.0 dB', 67.22);
       
INSERT users 
VALUES (1, 'login', 'hash', 'salt', 'name', 'lastname', 'email', 2, 25/05/2021, 25/05/2021);
       
INSERT product_types
VALUES (1, 'ram'),
	   (2, 'graphics card'),
	   (3, 'water cooling'),
	   (4, 'tower colling'),
	   (5, 'processor'),
	   (6, 'ssd drives'),
	   (7, 'hdd drives'),
	   (8, 'power supply');
       
INSERT roles
VALUES (1, 'administrator'),
	   (2, 'customer');
       