-- Crear base de datos
CREATE DATABASE TorchMediaDB;
GO

USE TorchMediaDB;
GO

-- Tabla de Usuarios
CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) NOT NULL,
    TextoAdicional NVARCHAR(MAX)
);

-- Tabla de Turnos
CREATE TABLE Turnos (
    TurnoID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT NOT NULL,
    FechaAgendada DATETIME NOT NULL,
    Estado NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_Turnos_Usuarios FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

-- Tabla para la Sección Hero
CREATE TABLE HeroContent (
    HeroContentID INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(255),
    Descripcion NVARCHAR(MAX),
    VideoUrl NVARCHAR(255)
);

-- Tabla para la Sección Quiénes Somos
CREATE TABLE QuienesSomosContent (
    QuienesSomosID INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(255),
    Descripcion NVARCHAR(MAX),
    ImagenUrl NVARCHAR(255)
);

-- Tabla para la Sección Nuestros Servicios
CREATE TABLE ServiciosContent (
    ServicioID INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(255),
    Descripcion NVARCHAR(MAX),
    IconoUrl NVARCHAR(255)
);

-- Tabla para la Sección Proyectos
CREATE TABLE ProyectosContent (
    ProyectoID INT PRIMARY KEY IDENTITY(1,1),
    VideoUrl NVARCHAR(255),
    ImagenUrl NVARCHAR(255)
);

-- Tabla para la Sección Testimonios
CREATE TABLE TestimoniosContent (
    TestimonioID INT PRIMARY KEY IDENTITY(1,1),
    VideoUrl NVARCHAR(255),
    ImagenUrl NVARCHAR(255)
);

-- Tabla para la Sección Pie de Página (Footer)
CREATE TABLE FooterContent (
    FooterID INT PRIMARY KEY IDENTITY(1,1),
    Texto NVARCHAR(255),
    Correo NVARCHAR(100),
    InstagramUrl NVARCHAR(255)
);

-- Tabla de Disponibilidad de Turnos (para que el administrador configure los horarios disponibles)
CREATE TABLE Disponibilidad (
    DisponibilidadID INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME NOT NULL,
    HoraInicio TIME NOT NULL,
    HoraFin TIME NOT NULL,
    Disponible BIT DEFAULT 1
);


-- Insertar datos en la tabla HeroContent
INSERT INTO HeroContent (Titulo, Descripcion, VideoUrl)
VALUES 
('BIENVENIDO A TorchMedia', 
'Transforma tus ideas en realidad con nuestra agencia de edición de video y embudos de ventas. Impulsa tu negocio con contenido visual impactante y estrategias de conversión efectivas. Descubre cómo podemos ayudarte a alcanzar tus objetivos hoy.', 
'Video/videoFondo.mp4');

-- Insertar datos en la tabla QuienesSomosContent
INSERT INTO QuienesSomosContent (Titulo, Descripcion, ImagenUrl)
VALUES 
('QUIÉNES SOMOS', 
'En TorchMedia, transformamos ideas en videos impactantes y estrategias de ventas efectivas para hacer crecer tu negocio. Con compromiso absoluto hacia la calidad y resultados, estamos aquí para llevar tu éxito al siguiente nivel.', 
'Img/logo.png');

-- Insertar datos en la tabla ServiciosContent
INSERT INTO ServiciosContent (Titulo, Descripcion, IconoUrl)
VALUES 
('Edición y estrategias de contenido', 
'Transformamos tus ideas en experiencias visuales memorables. Desde la edición experta hasta la estrategia de contenido, optimizamos cada detalle para captar y retener la atención de tu audiencia.', 
'Img/video edit icon.png'),
('Guiones y portadas para tus videos', 
'Creamos narrativas cautivadoras y portadas visualmente atractivas que destacan entre la multitud. Nuestros guiones y diseño de portadas garantizan que cada video no solo cuente una historia, sino que también impulse la acción de tu audiencia.', 
'Img/icono-2.png'),
('Embudos de venta', 
'Diseñamos embudos de venta personalizados que convierten visitantes en clientes. Desde la captación inicial hasta la conversión final, optimizamos cada etapa para maximizar tus conversiones y aumentar tus ingresos.', 
'Img/sales-funnel.jpg');

-- Insertar datos en la tabla ProyectosContent
INSERT INTO ProyectosContent (VideoUrl, ImagenUrl)
VALUES 
('Video/video-1.mp4', 'Img/video-1.jpg'),
('Video/video-2.mp4', 'Img/video-2.jpg'),
('Video/video-3.mp4', 'Img/video-3.jpg');

-- Insertar datos en la tabla TestimoniosContent
INSERT INTO TestimoniosContent (VideoUrl, ImagenUrl)
VALUES 
('path/to/tu-video.mp4', 'Img/testimonio-1.png');

-- Insertar datos en la tabla FooterContent
INSERT INTO FooterContent (Texto, Correo, InstagramUrl)
VALUES 
('© 2024 Todos los Derechos Reservados TorchMediaGrowth S.A.', 
'infotorchmedia@gmail.com', 
'https://www.instagram.com/torchmediagrowth');
