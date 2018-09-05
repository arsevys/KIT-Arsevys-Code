var websocket=require('ws').Server;
var url=require('url');
var ws=new websocket({port:process.env.PORT ||3000 });
console.log("ya se creo el servidor");

var clientes=[];
ws.on('connection',function(cliente){
console.log("se conecto")
var id=cliente.upgradeReq.headers['sec-websocket-key'];
 var get=url.parse(cliente.upgradeReq.url,true).query;
var nombre=get.nombre;
clientes.push({'nombre': nombre, 'id' :cliente , 'llave':id}); //se agrega un cliente
console.log("se conecto :" +nombre);


//console.log(cliente);
//cliente.send("Bienvenido "+ nombre);



nuevocliente();//avisa a los otros que se conecto un nuevo cliente

cargarconectados();//muestra todos los clientes conctados

cliente.on('message',function(mensaje){
var msj=JSON.parse(mensaje);

if(msj.receptor== 'todos'){

enviaratodos(msj.mensaje);
}
else {
   console.log(msj.receptor);
	enviarfriend(msj.receptor,msj.mensaje);
}





//	console.log(mensaje);
//cliente.send(mensaje);


});


cliente.on('close',function(){



for(var i=0;i<clientes.length;i++){


if(clientes[i]["nombre"]==nombre){
	clientes.splice(i,1);
	var avisar=JSON.stringify({usuario:'desconectar',nom:nombre,llave:id});
	for(var i=0;i<clientes.length;i++){
clientes[i]["id"].send(avisar);
}  }





}});

function cargarconectados(){
	var usuarios=JSON.stringify({usuario:'cargar',nom:[], llave:[]});
var insertar=JSON.parse(usuarios);

for(var i=0;i<clientes.length;i++){
 if(clientes[i]['nombre']!= nombre){
 	insertar['nom'].push(clientes[i]['nombre']);
 	insertar['llave'].push(clientes[i]['llave']);


 }

}
var usuarios=JSON.stringify(insertar);
cliente.send(usuarios);

}


function nuevocliente(){
	var aviso=JSON.stringify({usuario:'nuevo',nom:nombre, llave:id});
for(var i=0;i<clientes.length;i++){
 if(clientes[i]['nombre']!= nombre){
 	clientes[i]['id'].send(aviso);
 }

}
}

function enviaratodos(msj){
for(var i=0;i<clientes.length;i++){
clientes[i]["id"].send(nombre+" : " +msj);
}

}



///mostramos los usuarios conectados
function mostrarconectados(){

	for(var i=0;i<clientes.length;i++){
		console.log(clientes[i]["nombre"]);
	}
}

function enviarfriend(amigo,mensaje){

	for(var i=0;i<clientes.length;i++){

		if(clientes[i]["nombre"]==amigo){
			clientes[i]["id"].send(nombre+" : " +mensaje);
		}
	}
}


});