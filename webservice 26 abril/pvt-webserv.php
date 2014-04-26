<?php


	require_once "lib/config.php";
	require_once "lib/nusoap/nusoap.php";
	include "lib/System.Clases.php";

	$ns="http://serviciodeconsultas.hol.es/webservice/";

	$server = new soap_server();
	$server->configureWSDL('PVT',$ns);
	$server->wsdl->schemaTargetNamespace=$ns;

/*
* registro de las funciones del web service
*/
/////////////////USUARIOS///////////////////////
	$server->register('login',
		array('usuario' => 'xsd:string', 'password' => 'xsd:string'),
		array('return'=>'xsd:string'),$ns);

	$server->register('registraUsuario',
		array('id_sesion' => 'xsd:string',
			'nombre'=>'xsd:string',
			'apellidoPaterno'=>'xsd:string',
			'apellidoMaterno' =>'xsd:string',
			'tipo' =>'xsd:string',
			'email' =>'xsd:string',
			'password' =>'xsd:string'),
		array('return'=>'xsd:string'),$ns);

	$server->register('listarUsuarios',
		array('id_sesion' => 'xsd:string'),
		array('return'=>'xsd:string'),$ns);

	$server->register('usuarioUpdate',
		array('id_sesion' => 'xsd:string',
			'id_usuario' => 'xsd:string',
			'nombre'=>'xsd:string',
			'apellidoPaterno'=>'xsd:string',
			'apellidoMaterno' =>'xsd:string',
			'tipo' =>'xsd:string',
			'email' =>'xsd:string'),
		array('return'=>'xsd:string'),$ns);

	$server->register('usuarioChangePassword',
		array('id-sesion'=>'xsd:string',
			'id_usuario'=>'xsd:string',
			'password'=>'xsd:string'),
		array('return'=>'xsd:string'),$ns);

	$server->register('getPerfilUsuario',
		array('id-sesion'=>'xsd:string',
			'id_usuario'=>'xsd:string'),
		array('return'=>'xsd:string'),$ns);

	$server->register('buscarUsuarioPor',
		array('id-sesion'=>'xsd:string',
			'modo'=>'xsd:string',
			'valor'=>'xsd:string'),
		array('return'=>'xsd:string'),$ns);
//fin usuarios

///////////////COMPRADORES///////////////
$server->register('registraComprador',
	array('id'=>'xsd:string',
	      'nombre'=>'xsd:string',
		  'direccion'=>'xsd:string',
		  'beneficiario'=>'xsd:string',
		  'residencia'=>'xsd:string',
		  'ocupacion'=>'xsd:string',
		  'estado_civil'=>'xsd:string',
		  'tel'=>'xsd:string',
		  'tel1'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('updateIdComprador',
	array('idComprador'=>'xsd:string',
		  'nombreComprador'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('updateComprador',
	array('id'=>'xsd:string',
		  'nombre'=>'xsd:string',
		  'direccion'=>'xsd:string',
		  'beneficiario'=>'xsd:string',
		  'residencia'=>'xsd:string',
		  'ocupacion'=>'xsd:string',
		  'estado_civil'=>'xsd:string',
		  'tel'=>'xsd:string',
		  'tel1'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('getComprador',
	array('id_comprador'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('getNombreComprador',
	array('id'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('getIdComprador',
	array('comprador'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('cargaComprador',
	array(),
	array('return'=>'xsd:string'),$ns);

$server->register('listarCompradores',
	array('id_sesion'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('buscarCompradorPor',
	array('id_sesion'=>'xsd:string',
		'modo'=>'xsd:string',
		'valor'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('eliminaComprador',
	array('id_sesion'=>'xsd:string',
	'id_comprador'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);
//fin compradores

//////////////////VENTAS//////////////////////
$server->register('registraVenta',
	array('id_comprador'=>'xsd:string',
		'lote'=>'xsd:string',
		'tipo_pago'=>'xsd:string',
		'monto'=>'xsd:string',
		'mensualidad'=>'xsd:string',
		'Fecha_compra'=>'xsd:string',
		'fecha_corte'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('updateVenta',
	array('id_sesion'=>'xsd:string',
		'id_venta'=>'xsd:string',
		'comprador'=>'xsd:string',
		'vendedor'=>'xsd:string',
		'lote'=>'xsd:string',
		'total_venta'=>'xsd:string',
		'saldo_actual'=>'xsd:string',
		'mensualidades'=>'xsd:string',
		'pago'=>'xsd:string',
		'pago_minimo'=>'xsd:string',
		'fecha_compra'=>'xsd:string',
		'fecha_corte'=>'xsd:string',
		'tipo_pago'=>'xsd:string',
		'comicion'=>'xsd:string',
		'interes_tardio'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('getVenta',
	array('id_comprador'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('getIdCompradordeVenta',
	array(),
	array('return'=>'xsd:string'),$ns);


$server->register('getVentadeIdLote',
	array('id_lote'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('getIdLoteDeVenta',
	array('id_comprador'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('registraAbono',
	array('id_comprador'=>'xsd:string',
		'abono'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('getAbono',
	array('id_comprador'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('getIdVentaPkLote',
	array('id_lote'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('buscarVentaPor',
	array('id_sesion'=>'xsd:string',
		'modo'=>'xsd:string',
		'valor'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);
//fin ventas

////////////////PREDIOS////////////////////
$server->register('registraPredio',
	array('id_predio' =>'xsd:string',
		  'nombre_predio'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('cargaColumnaTablaPredio',
	array('nombreColumna'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('getIdPredio',
	array('nombre_predio' => 'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('getIdPredioPkLote',
	array('pk_lote' => 'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('getNombrePredio',
	array('id_predio' => 'xsd:string'),
	array('return'=>'xsd:string'),$ns);

////////////////////MAZANAS///////////////
$server->register('registraManzana',
	array('numero_manzana' => 'xsd:string',
	 	  'pk_predio'=>'xsd:string'),
    array('return'=>'xsd:string'),$ns);

$server->register('cargaColumnaTablaManzana',
	array('id_predio' => 'xsd:string',
		  'nombre_columna' => 'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('getIdManzana',
	array('numero_manzana' => 'xsd:string',
	 	  'pk_predio'=>'xsd:string'),
    array('return'=>'xsd:string'),$ns);

$server->register('getIdManzanaPkLote',
array('pk_lote'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('getNumeroManzana',
array('id_manzana'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('contarManzanas',
array('pk_predio'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

//fin manzanas

/////////////////LOTES////////////////////////
$server->register('registraLote',
	array('pk_predio'=>'xsd:string',
		'pk_manzana'=>'xsd:string',
		'n_lote'=>'xsd:string',
		'agregar'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('cargaLotes',
array('id_manzana'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('updateLote',
	array('id_sesion'=>'xsd:string',
		'id_lote'=>'xsd:string',
		'pk_manzana'=>'xsd:string',
		'estatus'=>'xsd:string',
		'n_lote'=>'xsd:string',
		'descripcion'=>'xsd:string',
		'precio'=>'xsd:string',
		'medida'=>'xsd:string',
		'pk_norte'=>'xsd:string',
		'pk_sur'=>'xsd:string',
		'pk_este'=>'xsd:string',
		'pk_oeste'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('getIdLote',
array('pk_manzana'=>'xsd:string',
	'numero_lote'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('getNumeroLote',
array('id_lote'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('updateStatusLote',
array('id_lote'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('eliminaLote',
	array('id_sesion'=>'xsd:string',
		'id_lote'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('buscaLotePor',
	array('id_sesion'=>'xsd:string',
		'modo'=>'xsd:string',
		'valor'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('contarLotes',
	array('pk_manzana'=>'xsd:string',
		'pk_predio'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('getMedida',
	 array(),
array('return'=>'xsd:string'),$ns);

$server->register('registraMedida',
	array('medida'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('insertaMedida',
	array('id_lote'=>'xsd:string',
		'medidaNorte'=>'xsd:string',
		'MedidaSur'=>'xsd:string',
		'MedidaEste'=>'xsd:string',
		'MedidaOeste'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('getMedidaOeste',
	array('id_lote'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('getMedidaNorte',
	array('id_lote'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('getMedidaSur',
	array('id_lote'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('getMedidaEste',
	array('id_lote'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);
//fin lotes

///////////////////PAGOS/////////////////////////
$server->register('registraProximoPago',
	array('id_venta'=>'xsd:string',
		  'monto'=>'xsd:string',
		  'proximo_pago'=>'xsd:string',
		  'tipo_pago'=>'xsd:string',
		  'pago_actual'=>'xsd:string',
		  'pago_final'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('getProximoPago',
	array('id_venta'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('updateStatusMora',
	array('id_venta'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('buscarPagos',
	array('id_sesion'=>'xsd:string',
		'modo'=>'xsd:string',
		'valor'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('registraPago',
	array('id_venta'=>'xsd:string',
			'monto'=>'xsd:string',
			'fecha_pago'=>'xsd:string',
			'fecha_corte'=>'xsd:string',
			'tipo_pago'=>'xsd:string',
			'pago_actual'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);
//fin de pagos

////////////// MORA  //////////////////////
$server->register('registraMora',
	array('id_venta'=>'xsd:string',
		'monto_mora'=>'xsd:string',
		'fecha_pago'=>'xsd:string',
		'mes_mora'=>'xsd:string',
		'fecha_mora'=>'xsd:string',
		'status_mora'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('getIdMora',
	array('idVenta'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('getFechaMora',
array('id_venta'=>'xsd:string'),
array('return'=>'xsd:string'),$ns);

$server->register('getMontoMora',
	array('id_venta'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

$server->register('cambiarStatusMora',
	array('id_mora'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);

////////FIN MORA/////////////////



//////////////////REPORTES//////
$server-> register('reportePago',
	array('numero_pago'=>'xsd:string',
		'fraccionamiento'=>'xsd:string',
		'numero_lote'=>'xsd:string',
		'medida_norte'=>'xsd:string',
		'medida_sur'=>'xsd:string',
		'medida_este'=>'xsd:string',
		'medida_oeste'=>'xsd:string',
		'numero_manzana'=>'xsd:string',
		'cliente'=>'xsd:string',
		'monto'=>'xsd:string',
		'fecha_pago'=>'xsd:string',
		'municipio'=>'xsd:string'),
	array('return'=>'xsd:string'),$ns);
/////////////FIN REPORTES/////


/* funciones del web service*/
include "lib/System.UserMethods.php";//usuarios

include "lib/System.SalesMethods.php";//Ventas

include "lib/System.CustomersMethods.php";//Clientes, Compradores

include "lib/System.LotsMethods.php";//Lotes

include "lib/System.ManzanasMethods.php";//Manzanas

include "lib/System.PrediosMethods.php";//Predios

include "lib/System.ClausulasMethods.php";//Clausulas

include "lib/System.PaymentsMethods.php";//Pagos

include "lib/System.ReportesMethods.php";//Reportes

include "lib/System.MoraMethods.php";//Registro publico

/*fin de las funciones para los usuarios*/

/*funciones del sistema*/
include "lib/System.Functions.php";
/**fin de las funciones del sistema*/


	$server->service($HTTP_RAW_POST_DATA);
?>