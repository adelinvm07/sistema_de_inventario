USE SistemaInventario;
GO

INSERT INTO Suplidores (nombre_empresa, nombre_contacto, telefono, correo_electronico, sitio_web) VALUES 
('TechDominicana S.R.L.', 'Carlos Martínez', '809-555-1001', 'ventas@techdom.do', 'https://techdom.do'),
('Distribuidora del Caribe', 'Ana Gómez', '829-555-2002', 'contacto@distcaribe.com', NULL),
('Importaciones Globales', 'Luis Polanco', '849-555-3003', 'info@iglobales.do', 'http://iglobales.do'),
('Alimentos Nacionales', 'María Fernández', '809-555-4004', 'ventas@alinac.com', NULL),
('Muebles y Equipos RD', 'José Ramón', '829-555-5005', 'jramon@mueblesrd.do', 'https://mueblesrd.do'),
('Ferretería Industrial', 'Elena Suriel', '849-555-6006', 'soporte@ferreteriaind.com', 'https://ferreteriaind.com');

INSERT INTO Categorias (nombre, descripcion) VALUES 
('Electrónica', 'Dispositivos tecnológicos, computadoras y accesorios.'),
('Electrodomésticos', 'Equipos eléctricos para el hogar y la oficina.'),
('Mobiliario', 'Muebles de oficina, sillas ergonómicas y escritorios.'),
('Ferretería', 'Herramientas manuales, eléctricas y materiales de construcción.'),
('Papelería', 'Material gastable, papel, bolígrafos y suministros.'),
('Alimentos y Bebidas', 'Productos no perecederos y refrigerios para oficina.');

INSERT INTO Productos (categoria_id, nombre, precio_unitario) VALUES 
-- Electrónica (id: 1)
(1, 'Laptop Dell Latitude 3420', 45000.00),
(1, 'Monitor Samsung 24 Pulgadas', 8500.00),
(1, 'Mouse Inalámbrico Logitech', 1200.00),
(1, 'Teclado Mecánico Redragon', 3500.00),
(1, 'Cable HDMI 2 metros', 450.00),
-- Electrodomésticos (id: 2)
(2, 'Microondas Panasonic', 6500.00),
(2, 'Cafetera Oster 12 Tazas', 2100.00),
(2, 'Nevera Ejecutiva Mabe', 12500.00),
(2, 'Dispensador de Agua', 4800.00),
-- Mobiliario (id: 3)
(3, 'Silla Ergonómica Mesh', 7500.00),
(3, 'Escritorio en L', 15000.00),
(3, 'Archivador de Metal 3 Gavetas', 8500.00),
(3, 'Silla de Visita', 2500.00),
-- Ferretería (id: 4)
(4, 'Taladro Percutor DeWalt', 9500.00),
(4, 'Juego de Destornilladores Stanley', 1500.00),
(4, 'Cinta Métrica 5m', 350.00),
(4, 'Caja de Herramientas 19 Pulgadas', 2200.00),
-- Papelería (id: 5)
(5, 'Caja de Papel Bond 8.5x11', 2800.00),
(5, 'Caja de Bolígrafos Azules BIC', 450.00),
-- Alimentos y Bebidas (id: 6)
(6, 'Caja de Café Santo Domingo 1lb', 3200.00);

INSERT INTO Suplidores_productos (suplidor_id, producto_id) VALUES 
(1, 1), (1, 2), (1, 5),                 -- TechDominicana provee Laptop, Monitor y Cable
(3, 3), (3, 4),                         -- Importaciones Globales provee Mouse y Teclado
(2, 6), (2, 7), (2, 9),                 -- Distribuidora del Caribe provee Microondas, Cafetera y Dispensador
(5, 8),                                 -- Muebles y Equipos RD provee Nevera Ejecutiva
(5, 10), (5, 11), (5, 12), (5, 13),     -- Muebles y Equipos RD provee todo el Mobiliario
(6, 14), (6, 15), (6, 16), (6, 17),     -- Ferretería Industrial provee todas las Herramientas
(3, 18), (3, 19),                       -- Importaciones Globales provee la Papelería
(4, 20),                                -- Alimentos Nacionales provee el Café
(3, 1),                                 -- Importaciones Globales también provee la Laptop Dell
(1, 4);                                 -- TechDominicana también provee el Teclado Mecánico