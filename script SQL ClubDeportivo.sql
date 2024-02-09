CREATE TABLE Socios(
id_socio INTEGER(4) NOT NULL AUTO_INCREMENT,
nombre VARCHAR(40) NOT NULL,
ap_paterno VARCHAR(30) NOT NULL,
ap_materno VARCHAR(30) NOT NULL,
curp VARCHAR(18) ,
pdf_curp VARCHAR(30),
fecha_nacimiento DATE NOT NULL,
edad INTEGER(3),
direccion VARCHAR(150),
correo VARCHAR(50),
telefono VARCHAR(10),
fecha_ingreso DATE NOT NULL,
fecha_reingreso DATE,
fecha_cambio_estatus DATE,
tipo_socio CHAR(1)
PRIMARY KEY (id_socio)
UNIQUE (curp)
);

CREATE TABLE Usuarios(
id_usuario INTEGER(4) NOT NULL AUTO_INCREMENT,
contrasena VARCHAR(20)
PRIMARY KEY (id_usuario)
);

CREATE TABLE Defunciones(
id_defuncion INTEGER(4) NOT NULL AUTO_INCREMENT,
id_socio INTEGER(4) NOT NULL,
fecha_defuncion DATE NOT NULL,
beneficiario VARCHAR(50),
monto DOUBLE(7,2),
PRIMARY KEY (id_defuncion),
FOREIGN KEY (id_socio) REFERENCES Socios(id_socio)
);

CREATE TABLE Pagos(
folio_pago INTEGER(5) NOT NULL AUTO_INCREMENT,
id_socio INTEGER(4) NOT NULL,
fecha_emision DATE NOT NULL,
fecha_pago DATE,
monto_total DOUBLE(6,2),
PRIMARY KEY (folio_pago),
FOREIGN KEY (id_socio) REFERENCES Socios(id_socio)
);

CREATE TABLE Tarifas(
id_tarifa INTEGER(3) NOT NULL AUTO_INCREMENT,
concepto VARCHAR(100) NOT NULL,
monto DOUBLE(5,2) NOT NULL,
tipo_tarifa CHAR(2) NOT NULL,
PRIMARY KEY (id_tarifa)
);

CREATE TABLE Detalle_recibos(
folio_pago INTEGER(5) NOT NULL,
id_tarifa INTEGER(3) NOT NULL,
monto DOUBLE(5,2) NOT NULL,
FOREIGN KEY (folio_pago) REFERENCES Pagos(folio_pago),
FOREIGN KEY (id_tarifa) REFERENCES Tarifas(id_tarifa)
);
