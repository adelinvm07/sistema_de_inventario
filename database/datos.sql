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

INSERT INTO Productos (categoria_id, suplidor_id, nombre, precio_unitario) VALUES
-- Electrónica (id: 1)
(1, 1, 'Laptop Dell Latitude 3420', 45000.00),
(1, 1, 'Monitor Samsung 24 Pulgadas', 8500.00),
(1, 3, 'Mouse Inalámbrico Logitech', 1200.00),
(1, 3, 'Teclado Mecánico Redragon', 3500.00),
(1, 1, 'Cable HDMI 2 metros', 450.00),
-- Electrodomésticos (id: 2)
(2, 2, 'Microondas Panasonic', 6500.00),
(2, 2, 'Cafetera Oster 12 Tazas', 2100.00),
(2, 5, 'Nevera Ejecutiva Mabe', 12500.00),
(2, 2, 'Dispensador de Agua', 4800.00),
-- Mobiliario (id: 3)
(3, 5, 'Silla Ergonómica Mesh', 7500.00),
(3, 5, 'Escritorio en L', 15000.00),
(3, 5, 'Archivador de Metal 3 Gavetas', 8500.00),
(3, 5, 'Silla de Visita', 2500.00),
-- Ferretería (id: 4)
(4, 6, 'Taladro Percutor DeWalt', 9500.00),
(4, 6, 'Juego de Destornilladores Stanley', 1500.00),
(4, 6, 'Cinta Métrica 5m', 350.00),
(4, 6, 'Caja de Herramientas 19 Pulgadas', 2200.00),
-- Papelería (id: 5)
(5, 3, 'Caja de Papel Bond 8.5x11', 2800.00),
(5, 3, 'Caja de Bolígrafos Azules BIC', 450.00),
-- Alimentos y Bebidas (id: 6)
(6, 4, 'Caja de Café Santo Domingo 1lb', 3200.00);
