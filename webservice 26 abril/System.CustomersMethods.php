<?php
function registraComprador($id, $nombre, $direccion, $beneficiario, $residencia, $ocupacion, $estado_civil, $tel, $tel1){
	$mysqli = new mysqli(DB_HOST,DB_USER,DB_PASSWORD,DB_NAM);
	if ($mysql_connect_errno){
		printf("conexion fallida %s/n",mysql_connect_error());
		exit();
	}
	$query = "INSERT INTO `Comprador`(`id`, `nombre`, `direccion`, `beneficiario`, `residencia`, `ocupacion`, `estado_civil`, `tel`, `tel1`) VALUES ('$id', '$nombre','$direccion', '$beneficiario', '$residencia', '$ocupacion', '$estado_civil', '$tel', '$tel1')";
	$result = $mysqli->query($query);
	$mysqli->close();
	return new soapval('return','xsd:string', 'usuario registrado con EXITO');

/*	$sesion = validaSesion($id_sesion);
	if($sesion != null){
		$id_usuario = $sesion->getId_user();
		$usuario = $sesion->getUsuario();
		if($usuario->getTipo() == 1 || $usuario->getTipo() == 1) {
			$query ="INSERT INTO Comprador(id, nombre, apellidoPaterno, apellidoMaterno, domicilio, recidencia, e_civil, ocupacion, beneficiario, tels, colonia, estado, municipio) VALUES(NULL, '$nombre', '$apellidoPaterno', '$apellidoMaterno', '$domicilio', '$recidencia', '$e_civil', '$ocupacion', '$beneficiario', '$tels', '$colonia', '$estado', '$municipio')";
			$mysqli = new mysqli(DB_HOST,DB_USER,DB_PASSWORD,DB_NAM);
			if ($mysqli->connect_errno) {
			    return new soapval('return','xsd:string','no se puede crear el usuario nuevo');
			}else{
				$mysqli->query($query);
				$echo = $mysqli->affected_rows;
				if($echo ==1){
					$mysqli->close();
					return new soapval('return','xsd:string', "OKAY");
				}else{
					$mysqli->close();
					return new soapval('return','xsd:string', "ERROR");
				}
			}
			return new soapval('return','xsd:string', $query);
		}else{
			return new soapval('return','xsd:string', 'NO TIENE ACCESO');
		}
	}else{
		return new soapval('return','xsd:string','NO TIENE ACCESO');
	}*/

}

function updateIdComprador($idComprador, $nombreComprador){

	$mysqli = new mysqli(DB_HOST,DB_USER,DB_PASSWORD,DB_NAM);
	if ($mysql_connect_errno){
		printf("conexion fallida %s/n",mysql_connect_error());
		exit();
	}
	$query = "UPDATE `Comprador` SET `id`='$idComprador' WHERE `nombre` = '$nombreComprador' " ;
	$mysqli->query($query);
	$echo = $mysqli->affected_rows;
	if ($echo == 1) {
		return new soapval('return','xsd:string', "Actualizacion del ID del cliente EXITOSA");
	}else{
		return new soapval('return','xsd:string', "No hubo cambio");
	}
}

function updateComprador($idComprador, $nombreComprador, $direccion, $beneficiario, $residencia, $ocupacion, $estado_civil, $tel, $tel1){

	$mysqli = new mysqli(DB_HOST,DB_USER,DB_PASSWORD,DB_NAM);
	if ($mysql_connect_errno){
		printf("conexion fallida %s/n",mysql_connect_error());
		exit();
	}
	$query = "UPDATE `Comprador` SET  `nombre` = '$nombreComprador' ,`direccion`='$direccion',`beneficiario`='$beneficiario',`residencia`='$residencia',`ocupacion`='$ocupacion',`estado_civil`='$estado_civil',`tel`='$tel',`tel1`='$tel1' WHERE `id`='$idComprador'" ;
	$mysqli->query($query);
	$echo = $mysqli->affected_rows;
	if ($echo == 1) {
		return new soapval('return','xsd:string', "Actualizacion de cliente EXITOSA");
	}else{
		return new soapval('return','xsd:string', "No hubo cambio");
	}

/*	$sesion = validaSesion($id_sesion);
	$sesion = validaSesion($id_sesion);
	if($sesion != null){
		$id_usuario = $sesion->getId_user();
		$usuario = $sesion->getUsuario();
		if($usuario->getTipo() == 1){
			if(idCompradorExist($id_comprador)){
				if($nombre != "" && $apellidoPaterno != "" && $apellidoMaterno != "" && $domicilio != "" && $recidencia != "" && $e_civil != "" && $ocupacion != "" && $beneficiario != "" && $tels != "" && $colonia != ""  && $estado != "" && $municipio != ""){
					return new soapval('return','xsd:string', 'procesiendo...');
				}else{
					return new soapval('return','xsd:string', 'llene todos los campos');
				}
			}else{

				return new soapval('return','xsd:string', 'no existe');
			}

		}else{
			return new soapval('return','xsd:string', 'NO TIENE ACCESO');
		}
	}else{
		return new soapval('return','xsd:string','NO TIENE ACCESO');
	}*/
}

function getComprador($nombreComprador){
	$mysqli = new mysqli(DB_HOST,DB_USER,DB_PASSWORD,DB_NAM);
	if ($mysql_connect_errno){
		printf("conexion fallida %s/n",mysql_connect_error());
		exit();
	}
	$query = "SELECT * FROM `Comprador` WHERE `nombre` = '$nombreComprador'" ;
						$result = $mysqli->query($query);
						$data = $result->fetch_assoc();
		    			$direccion=$data['direccion'];
		    			$beneficiario=$data['beneficiario'];
		    			$residencia=$data['residencia'];
		    			$ocupacion=$data['ocupacion'];
		    			$estado_civil=$data['estado_civil'];
		    			$tel=$data['tel'];
		    			$tel1=$data['tel1'];
						$mysqli->close();
						return new soapval('return','xsd:string', "$direccion,$beneficiario,$residencia,$ocupacion,$estado_civil,$tel,$tel1");
//	$sesion = validaSesion($id_sesion);
//	$sesion = validaSesion($id_sesion);
//	if($sesion != null){
//		$usuario = $sesion->getUsuario();
//		if($usuario->getTipo() == 1 || $usuario->getTipo() == 0){
//			$mysqli = new mysqli(DB_HOST,DB_USER,DB_PASSWORD,DB_NAM);
//			$query ="SELECT * FROM Comprador WHERE id = '$id_comprador'";
//		if ($mysqli->connect_errno) {
//				    return new soapval('return','xsd:string','no se puede crear el usuario nuevo');
//		}else{
//			$query = "SELECT nombre FROM Comprador WHERE id = '$id'";
//			$result = $mysqli->query($query);
//			$i = $result->num_rows;
//			if($i == 1){
//				$arrayJSON = array();
//				$data = $result->fetch_assoc();
//				$nombre = $data['nombre'];
//					$arrayJSON['id'] = $data['id'];
//					$arrayJSON['nombre'] = $data['nombre'];
//					$arrayJSON['apellidoPaterno'] = $data['apellidoPaterno'];
//					$arrayJSON['apellidoMaterno'] = $data['apellidoMaterno'];
//					$arrayJSON['direccion'] = $data['direccion'];
//					$arrayJSON['beneficiario'] = $data['beneficiario'];
//					$arrayJSON['residencia'] = $data['residencia'];
//					$arrayJSON['ocupacion'] = $data['ocupacion'];
//					$arrayJSON['estado_civil'] = $data['estado_civil'];
//					$arrayJSON['tel'] = $data['tel'];
//					$arrayJSON['tel1'] = $data['tel1'];
//					$arrayJSON['colonia'] = $data['colonia'];
//					$arrayJSON['estado'] = $data['estado'];
//					$arrayJSON['municipio'] = $data['municipio'];
//				$mysqli->close();
//				return new soapval('return','xsd:string', /*json_encode($arrayJSON)*/$nombre);
//			}else{
//				$mysqli->close();
//				return new soapval('return','xsd:string','NO TIENE ACCESO');
//			}
//		}
//		}else{
//			return new soapval('return','xsd:string', 'NO TIENE ACCESO');
//		}
//	}else{
//		return new soapval('return','xsd:string','NO TIENE ACCESO');
//	}
}

function getNombreComprador($id){

	$mysqli = new mysqli(DB_HOST,DB_USER,DB_PASSWORD,DB_NAM);
	if ($mysql_connect_errno){
		printf("conexion fallida %s/n",mysql_connect_error());
		exit();
	}
	$idComprador = explode(",",$id);
	$tamaño = count($idComprador);
//	return new soapval('return','xsd:string', $idComprador[0]);
	$dato = array();
//	$i=0;
	for($i=0 ; $i<$tamaño ; $i++){

		$query = "SELECT `nombre` FROM `Comprador` WHERE `id` = '$idComprador[$i]' ";
		$result = $mysqli->query($query);
		$data = $result->fetch_assoc();
		$dato[] = $data['nombre'];
	}
	$comprador = implode(",",$dato);

	$mysqli->close();
	return new soapval('return','xsd:string', $comprador);
}

function getIdComprador($comprador){

	$mysqli = new mysqli(DB_HOST,DB_USER,DB_PASSWORD,DB_NAM);
	if ($mysql_connect_errno){
		printf("conexion fallida %s/n",mysql_connect_error());
		exit();
	}
	$query = "SELECT `id` FROM `Comprador` WHERE `nombre` = '$comprador'" ;
	$result = $mysqli->query($query);
	$data = $result->fetch_assoc();
	$id = $data['id'];
	$mysqli->close();
	return new soapval('return','xsd:string', $id);

	//	$sesion = validaSesion($id_sesion);
	//	$sesion = validaSesion($id_sesion);
	//	if($sesion != null){
	//		$usuario = $sesion->getUsuario();
	//		if($usuario->getTipo() == 1 || $usuario->getTipo() == 0){
	//			$mysqli = new mysqli(DB_HOST,DB_USER,DB_PASSWORD,DB_NAM);
	//			$query ="SELECT * FROM Comprador WHERE id = '$id_comprador'";
	//		if ($mysqli->connect_errno) {
	//				    return new soapval('return','xsd:string','no se puede crear el usuario nuevo');
	//		}else{
	//			$query = "SELECT nombre FROM Comprador WHERE id = '$id'";
	//			$result = $mysqli->query($query);
	//			$i = $result->num_rows;
	//			if($i == 1){
	//				$arrayJSON = array();
	//				$data = $result->fetch_assoc();
	//				$nombre = $data['nombre'];
	//					$arrayJSON['id'] = $data['id'];
	//					$arrayJSON['nombre'] = $data['nombre'];
	//					$arrayJSON['apellidoPaterno'] = $data['apellidoPaterno'];
	//					$arrayJSON['apellidoMaterno'] = $data['apellidoMaterno'];
	//					$arrayJSON['direccion'] = $data['direccion'];
	//					$arrayJSON['beneficiario'] = $data['beneficiario'];
	//					$arrayJSON['residencia'] = $data['residencia'];
	//					$arrayJSON['ocupacion'] = $data['ocupacion'];
	//					$arrayJSON['estado_civil'] = $data['estado_civil'];
	//					$arrayJSON['tel'] = $data['tel'];
	//					$arrayJSON['tel1'] = $data['tel1'];
	//					$arrayJSON['colonia'] = $data['colonia'];
	//					$arrayJSON['estado'] = $data['estado'];
	//					$arrayJSON['municipio'] = $data['municipio'];
	//				$mysqli->close();
	//				return new soapval('return','xsd:string', /*json_encode($arrayJSON)*/$nombre);
	//			}else{
	//				$mysqli->close();
	//				return new soapval('return','xsd:string','NO TIENE ACCESO');
	//			}
	//		}
	//		}else{
	//			return new soapval('return','xsd:string', 'NO TIENE ACCESO');
	//		}
	//	}else{
	//		return new soapval('return','xsd:string','NO TIENE ACCESO');
	//	}
}

function cargaComprador(){

	$mysqli = new mysqli(DB_HOST,DB_USER,DB_PASSWORD,DB_NAM);
	if ($mysql_connect_errno){
		printf("conexion fallida %s/n",mysql_connect_error());
		exit();
	}
	$query = "SELECT `nombre` FROM `Comprador` ORDER BY `Comprador`.`nombre` ASC" ;
	$datos = array();
	$result = $mysqli->query($query);
	while ( $data = $result->fetch_assoc()) {
		$datos[] = $data['nombre'];
	};
	$comprador = implode(",",$datos);
	$mysqli->close();
	return new soapval('return','xsd:string', $comprador);

}

function listarCompradores($id_sesion){
	$sesion = validaSesion($id_sesion);
	if($sesion != null){
		$id_usuario = $sesion->getId_user();
		$usuario = $sesion->getUsuario();
		if($usuario->getTipo() == 1 || $usuario->getTipo() == 0){
				$mysqli = new mysqli(DB_HOST,DB_USER,DB_PASSWORD,DB_NAM);
				$query ="SELECT * FROM Comprador";
				if ($mysqli->connect_errno) {
				    return new soapval('return','xsd:string','no se puede crear el usuario nuevo');
				}else{
					$result = $mysqli->query($query);
					$arrayJSON=array();
					$i=0;
					while($data = $result->fetch_assoc()){
						$arrayJSON[$i]['id'] = $data['id'];
						$arrayJSON[$i]['nombre'] = $data['nombre'];
						$arrayJSON[$i]['apellidoPaterno'] = $data['apellidoPaterno'];
						$arrayJSON[$i]['apellidoMaterno'] = $data['apellidoMaterno'];
						$arrayJSON[$i]['domicilio'] = $data['domicilio'];
						$arrayJSON[$i]['recidencia'] = $data['recidencia'];
						$arrayJSON[$i]['e_civil'] = $data['e_civil'];
						$arrayJSON[$i]['ocupacion'] = $data['ocupacion'];
						$arrayJSON[$i]['beneficiario'] = $data['beneficiario'];
						$arrayJSON[$i]['tels'] = $data['tels'];
						$arrayJSON[$i]['colonia'] = $data['colonia'];
						$arrayJSON[$i]['estado'] = $data['estado'];
						$arrayJSON[$i]['municipio'] = $data['municipio'];
						$i++;
					}
					$mysqli->close();
					return new soapval('return','xsd:string',json_encode($arrayJSON));
				}
		}else{
			return new soapval('return','xsd:string', 'NO TIENE ACCESO');
		}
	}else{
		return new soapval('return','xsd:string','NO TIENE ACCESO');
	}
}

function buscarCompradorPor($id_sesion, $modo, $valor){//nombre, apellido, venta, id,
	$sesion = validaSesion($id_sesion);
	if($sesion != null){
		$id_usuario = $sesion->getId_user();
		$usuario = $sesion->getUsuario();
		if($usuario->getTipo() == 1 || $usuario->getTipo() == 0){
			switch($modo){
				case 'NOMBRE'://nombre
				if(strlen($valor)<3)return new soapval('return','xsd:string','ERROR');
				$query = "SELECT * FROM Comprador WHERE (nombre LIKE  '%".$valor."%')";
				$mysqli = new mysqli(DB_HOST,DB_USER,DB_PASSWORD,DB_NAM);
					if ($mysqli->connect_errno) {
					    return new soapval('return','xsd:string','ERROR');
					}else{
						$result = $mysqli->query($query);
						$arrayJSON=array();
						$i=0;
						while($data = $result->fetch_assoc()){
							$arrayJSON[$i]['id'] = $data['id'];
							$arrayJSON[$i]['nombre'] = $data['nombre'];
							$arrayJSON[$i]['apellidoPaterno'] = $data['apellidoPaterno'];
							$arrayJSON[$i]['apellidoMaterno'] = $data['apellidoMaterno'];
							$arrayJSON[$i]['domicilio'] = $data['domicilio'];
							$arrayJSON[$i]['recidencia'] = $data['recidencia'];
							$arrayJSON[$i]['e_civil'] = $data['e_civil'];
							$arrayJSON[$i]['ocupacion'] = $data['ocupacion'];
							$arrayJSON[$i]['beneficiario'] = $data['beneficiario'];
							$arrayJSON[$i]['tels'] = $data['tels'];
							$arrayJSON[$i]['colonia'] = $data['colonia'];
							$arrayJSON[$i]['estado'] = $data['estado'];
							$arrayJSON[$i]['municipio'] = $data['municipio'];
							$i++;
						}
						$mysqli->close();
						return new soapval('return','xsd:string',json_encode($arrayJSON));
					}
				break;

				case 'APELLIDO'://apellido
					return new soapval('return','xsd:string','B');
				break;

				case 'C'://id
				return new soapval('return','xsd:string','C');
				break;

				case 'D'://venta
				return new soapval('return','xsd:string','D');
				break;

				default:
				return new soapval('return','xsd:string','OPCION NO VALIDA');
			}
		}else{
			return new soapval('return','xsd:string', 'NO TIENE ACCESO');
		}
	}else{
		return new soapval('return','xsd:string','NO TIENE ACCESO');
	}
}

function eliminaComprador($id_sesion, $id_comprador){
	$sesion = validaSesion($id_sesion);
	if($sesion != null){
		$usuario = $sesion->getUsuario();
		if($usuario->getTipo() == 1){

			$query ="DELETE FROM Comprador WHERE( id = '$id_comprador')";
			$mysqli = new mysqli(DB_HOST,DB_USER,DB_PASSWORD,DB_NAM);
			if ($mysqli->connect_errno) {
			    return new soapval('return','xsd:string','ERROR');
			}else{
				$mysqli->query($query);
				$echo = $mysqli->affected_rows;
				if($echo == 1){
					$mysqli->close();
					return new soapval('return','xsd:string', "OKAY");
				}else{
					$mysqli->close();
					return new soapval('return','xsd:string', "ERROR USUARIO NO ENCONTRADO ");
				}
			}
		}else{
			return new soapval('return','xsd:string', 'NO TIENE ACCESO');
		}
	}else{
		return new soapval('return','xsd:string','NO TIENE ACCESO');
	}
}

?>