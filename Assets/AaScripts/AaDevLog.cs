/*
Dia0(07-11-22):
Trabajado en PlayerHook, PlayerGroundCheck, PlayerMovement, PlayerJump
Ninguna perfeccionada, pero todas mas menos funcionan, tambien creado el proyecto y creado el repositorio en github


Dia1(08-11-22):
PlayerHook ahora solo se puede usar una vez, coyote jump, jump buffering, y doble salto funciona guay(tocara cambiarlo pero en principio bases solidas)
Se suponia que iba alimpiar codigo hoy, pero al final no lo he hecho(se ha complicado el tema de el salto)
metido el mapa de adrian aunque no se si eso esyaba ya ayer,
ma�ana molaria:
----------------------
TODO(En prioridad):
Limpiar codigo: :)
Bug Camara: :)
Aa: :)
Hacer sistema de vida solido: :/
a�adirlo al hud: :(
Hacer enemigos basicos: :/
A�adir Parry: :/

----------------------

Dia2:(09-11-22):
--
Hecho por la ma�ana
A�adidos ataques(con cubos)
vida basica(no hay nada q te quite vida)
doble salto visual
arreglado bug camara
limpiado codigo
rotaionpersonaje(capsula) arreglado
--
Tarde

Dia3:(09-11-22):
--
A�adido enegimo pocho
Lo estoy escribiendo el domingo y ns q hice jaja
--
Fin de semana1:
A�adido nuevo sistema de enemigo un poco mejor,(no programado pero por lo menos esta muy setteado para ma�ana.

Dia4(13-11-23):
Hecho Por la Ma�ana:
Enemigo(por pullir obb pero bastante mejor q el del otro dia)
Parry(funciona la parte del enemigo(lo stunea)) falta meteer que recuperes vida
Movimiento adicional camara(jostic derecho abajo mueve la camara abajo)
Metido el mapa y ajustes de pablo
Ahora me voy a poner con el cambio de sentido(q lo haga mas rapido)(ns si acabare ahora o por la tarde)
Cambio de sentido terminado
Hecho x la tarde:
empezado sistema respawn
solucion pocha de camera boundaries
investigado mas sobre el enemigo
----
hacer ma�ana:
DEJAR CLARO TODA LA PROGRAMACION Q VOY A NECESITAR
si eso terminar respawn.

Dia5:
A�adidas todas las cosas que se me han podido ocurrir al trello
Terminado respawn con los altares
solucionado problema rotacion camara al reaparecer.
investigado sobre camera boundaries, de momento he encontrado una solucion super pocha(ma�ana preguntar en clase)
Hcaer ma�ana:
A�adir player hit y si tengo tiempo Aa


Dia6:
hecho por la ma�ana:
A�adido player Hit
A�adido Aa aereo vertical y horizontal
a�adido sprite temporal del enemigo, hechas animaciones pochas para este enemigo, y mejorado el enemigo(ahora te emppuja bn y toda la pesca)
A�adido q mueras, te hagas invisible y aprarezcas

para hacer por la tarde:
mejorar enemigo a full y hacer enemigo volador si tengo timepo

Tarde:
Trabajado en mejorar el enemigo:
quitado RB, ahora se mueve por movetowards, quitado todos los colliders, el enemigo te empuja, pero lo puedes atravesar.
si caes por encima de el, no te empuja, te relentiza y lo atraviesas. igual q si le saltas, para asi no cortar el salto(blaspgemous)
No tiene puntos muertos ya(en los q te podias quedar y se quedaba pegando a la nada.)
el personaje se hace inbulnerable tgemporalmente cunado le golpean
cambiado el modo de hacer el parry(ahora va por una variable que esta en el gamemanager)




Dia7:
Alargado aa
a�adido enemigo volador(programado movimiento)
Pensado sistema oleadas, cristal que spawnea enemigos
Mejorado player hit.
a�adido que el parry stune al enemigo volador


Dia8:

PECH:

En Fate podemos separar las mec�nicas del personaje en dos apartados. Adem�s de las mec�nicas b�sicas de un metroidvania (correr y salto) 
al final del salto puedes volver a pulsar el bot�n para realizar un peque�o impulso con el que poder llegar m�s lejos.
Adem�s, con el ataque principal recuperas cierta cantidad de vida.

En Fate, las mecanicas se podrian dividir en dos secciones, las habilidades basicas del personaje, como serian los auto ataques,
el salto el movimiento, o el parry y las habilidades obtenidas por el personaje a lo largo del nivel

Dentro de las mec�nicas mas compejas en Fate, podriamos encontrar el parry y el gancho. El parry, es una habilidad que al ser usada, protejera
al personaje durante un brebe periodo de timepo, en el cual si el personaje es atacado, blockeara y devolvera este ataque,
stuneando al enemigo atacante. Esta habilidad consumira un % de vida, que sera devuelto en caso de de acertar la habilidad.

Por otro lado, el gancho, te permitira llegar a sitios a los cuales no podrias llegar con la movilidad base del personaje,
desbloqueando asi, formas de esquivar los ataques de los enemigos, y zonas del mapa.

Finalmente, y un poco menos compleja estaria el doble salto, que como su nombre indica, te permitiria inpulsarte una vez mas durante el salto.
Esto te permitira tener mayor movilidad, asi como acceder a zones que antes no podias.


En cuanto a mecanicas del entorno, podriamos dividirlas tambien en dos secciones, Interactuables por el persoanje, y que que afectan sobre el.

En cuanto a las que afectan sobre el, tenemos las basicas, como el enemigo mele,
Este, estara patrullando una zona, y una vez te vea, este te perseguira y atacara, sus ataques seran poderosos pero lentos, por lo que usar 
el parry, sera la mejor opcon para derrotarlo.
El enemigo volador, Estara fijo en una zona, y cunado te vea, se lanzara a por ti comom un kamikaze, golpeandote o explotando contra el suelo.

En cunato a otras cosas que tendras que tener en cunata durante el nivel, podrian tambien encontrase trampas de pinchos en el suelo.



------------
Cambiado enemigo volador, ahora te ve, y se lanza a por ti, explotando tanto si impacta contigo como si impacta con el suelo.

hacer ahora/despues del patio:
Cambiar funcionamiento parry





Dia9(21-11-2023):
Arreglado bug al iniciar la partida

A�adido desblockeo de salto, limpiado codigo, comentado codigo y corregido bugs como doble cliuck hace qye sates mas alto,
a�adir ahora que no te deje hacer doble salto con menos de x distancia al suelo.

A�adida zona que desbloquea el salto
mejorado el salto en general

arreglar salto y cambio de direccion

corregir bug aa hace que saltes menos

Me pase a ayudar con buscar refes el resto del dia

Dia 10(22/11/23):

corregir bug aa hace que saltes menos
Solucionado bug aa hace q salte mensos.

Corregido bug q si te mueves saltas menos por tema de drag:
solucionado poniendo drag a 0 cunado saltas(por si diese problemas mas adelantes)


salto y cambio de direccion se sobreescriben
Solucionado cambio de direccion se sobreescriben

modificado el generic health, para que sirva para todos los enemigos.

Empezado sistema rondas, entras, se cierran las puertas y aparecen una cantidad de enemigos dependiendo de la ronda, en zonas aleatorias.(solo mele)
Ma�ana terminarlo del todo:
Si mueres se reinicia,
que funcionen las rondas,
que aparezcan los voladores etc.





Dia11(23/11/23):

trabajado en sistema de oleadas

muerte reinicia la sala por completo
sistema de rondas mejorado para q funcionen con los voladores(no a�adidos aun)
romper el cristal hace que se abran las puertas y superes la sala.



Dia12(24/11/23):
A�adidos enemigos voladores, hecho que funcionen las oleadas con ellos tambien,
Cambiado sistema de respawn(GameobjList)Preguntar jorge.
Solucionar errores sistema oleadas.


Dia13:
TodoList Hoy:
A�adir respawn infinito: hecho
Actualizar Trello: hecho

--
Parry ahora no te puede matar
Parry ahora cancela aa, lo que hace que responda antes.
Barra de vida se actualiza con todo(golpes,ataques,etc.)






Dia14:

TodoList hacer ma�ana(o al terminar las prioridades nuevas al hablar con jorge:
Vida boss: a medias
effecto hacer da�o boss: a medias
matar boss: otro dia
entrar en sala boss: otro dia
meter todo el graybox: otro dia

--preguntar jorge hasta que punto es worth usar interfazes cuando me obliga a hacer el metodo publico--
no lo es, quitar
----------
a�adidas interfaces de ikilleable, idamageable y healplayer
x la ma�ana, empezado a hacer boss, pero me he desviado a hacer interfaces y aplicarlas a los enemigos.

a venido jorge, nueva to do list con prioridades:
cambiar instancias objetos x object polling
cambiar lista y referencias de la sala de rondas al roundManager


















-----------------------------------------------------------------------------------------------------------------------------------
COSAS A TENRE EN CUNETA;
rafaga aa
Modificar collider Parry(De momento estunnea te pegue por donde te pegue.)
XQ CUNADO LE DAS A ALGO Y NO PUEDES HCARELO EN EL MOMENTO, L HACE AL TERMINAR LA ACCION
A�adir regiones y ordenar codigo


PREGUNTAS:

PREGUNTAR JOREGE Como de pocho es poner en el gamemanager un public void q actualice el UI, pero este metodo lo que hace es llamar al metodo dentro de uiManager
Otra opcion seria hacer el gameobject.findgooftype<uimanager> pero ns q es mejor






 */