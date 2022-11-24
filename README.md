# Ventas.SER



Compañia Licorera de Nicaragua necesita hacer un sistema para agilizar la facturación a sus
clientes, el sistema debe permitir gestionar clientes y productos, la facturación puede ser en
dos monedas córdobas o dólares, para la conversión se debe utilizar la tasa de cambio del dia.
Por lo mencionado anteriormente se necesita que el API cuente con los siguientes endpoints:

Clientes </br></br>
Productos </br></br>
Tasa de Cambio </br></br>
Factura </br></br>
Detalle Factura </br></br>

Cliente

</br></br>

GET
/api/Cliente 

POST
/api/Cliente

GET
/api/Cliente/{id}

PUT
/api/Cliente/{id}

DELETE
/api/Cliente/{id}

GET
api/Cliente/Buscar/{parametro}

</br></br>
Factura

</br></br>

GET
​/api​/Factura

POST
​/api​/Factura

GET
​/api​/Factura​/{parametro}

</br></br>
Producto
</br></br>

GET
​/api​/Producto

POST
​/api​/Producto

PUT
​/api​/Producto

GET
​/api​/Producto​/{id}

DELETE
​/api​/Producto​/{id}

GET
​/api​/Producto​/Buscar​/{parametro}

</br></br>
Reporte
</br></br>

POST
​/api​/Reporte​/{id}


</br></br>
TasaCambio


GET
​/api​/TasaCambio

POST
​/api​/TasaCambio

PUT
​/api​/TasaCambio

GET
​/api​/TasaCambio​/{fecha}

DELETE
​/api​/TasaCambio​/{id}

GET
​/api​/TasaCambio​/~api​/TasaCambio​/Mes​/{month}
