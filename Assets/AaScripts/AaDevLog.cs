/*
Dia0(07-11-22):
Trabajado en PlayerHook, PlayerGroundCheck, PlayerMovement, PlayerJump
Ninguna perfeccionada, pero todas mas menos funcionan, tambien creado el proyecto y creado el repositorio en github


Dia1(08-11-22):
PlayerHook ahora solo se puede usar una vez, coyote jump, jump buffering, y doble salto funciona guay(tocara cambiarlo pero en principio bases solidas)
Se suponia que iba alimpiar codigo hoy, pero al final no lo he hecho(se ha complicado el tema de el salto)
metido el mapa de adrian aunque no se si eso esyaba ya ayer,
mañana molaria:
----------------------
TODO(En prioridad):
Limpiar codigo: :)
Bug Camara: :)
Aa: :)
Hacer sistema de vida solido: :/
añadirlo al hud: :(
Hacer enemigos basicos: :/
Añadir Parry: :/

----------------------

Dia2:(09-11-22):
--
Hecho por la mañana
Añadidos ataques(con cubos)
vida basica(no hay nada q te quite vida)
doble salto visual
arreglado bug camara
limpiado codigo
rotaionpersonaje(capsula) arreglado
--
Tarde

Dia3:(09-11-22):
--
Añadido enegimo pocho
Lo estoy escribiendo el domingo y ns q hice jaja
--
Fin de semana1:
Añadido nuevo sistema de enemigo un poco mejor,(no programado pero por lo menos esta muy setteado para mañana.

Dia4(13-11-23):
Hecho Por la Mañana:
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
hacer mañana:
DEJAR CLARO TODA LA PROGRAMACION Q VOY A NECESITAR
si eso terminar respawn.

Dia5:
Añadidas todas las cosas que se me han podido ocurrir al trello
Terminado respawn con los altares
solucionado problema rotacion camara al reaparecer.
investigado sobre camera boundaries, de momento he encontrado una solucion super pocha(mañana preguntar en clase)
Hcaer mañana:
Añadir player hit y si tengo tiempo Aa


Dia6:
hecho por la mañana:
Añadido player Hit
Añadido Aa aereo vertical y horizontal
añadido sprite temporal del enemigo, hechas animaciones pochas para este enemigo, y mejorado el enemigo(ahora te emppuja bn y toda la pesca)
Añadido q mueras, te hagas invisible y aprarezcas

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
añadido enemigo volador(programado movimiento)
Pensado sistema oleadas, cristal que spawnea enemigos
Mejorado player hit.
añadido que el parry stune al enemigo volador


Dia8:

PECH:

En Fate podemos separar las mecánicas del personaje en dos apartados. Además de las mecánicas básicas de un metroidvania (correr y salto) 
al final del salto puedes volver a pulsar el botón para realizar un pequeño impulso con el que poder llegar más lejos.
Además, con el ataque principal recuperas cierta cantidad de vida.

En Fate, las mecanicas se podrian dividir en dos secciones, las habilidades basicas del personaje, como serian los auto ataques,
el salto el movimiento, o el parry y las habilidades obtenidas por el personaje a lo largo del nivel

Dentro de las mecánicas mas compejas en Fate, podriamos encontrar el parry y el gancho. El parry, es una habilidad que al ser usada, protejera
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

Añadido desblockeo de salto, limpiado codigo, comentado codigo y corregido bugs como doble cliuck hace qye sates mas alto,
añadir ahora que no te deje hacer doble salto con menos de x distancia al suelo.

Añadida zona que desbloquea el salto
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
Mañana terminarlo del todo:
Si mueres se reinicia,
que funcionen las rondas,
que aparezcan los voladores etc.





Dia11(23/11/23):

trabajado en sistema de oleadas

muerte reinicia la sala por completo
sistema de rondas mejorado para q funcionen con los voladores(no añadidos aun)
romper el cristal hace que se abran las puertas y superes la sala.



Dia12(24/11/23):
Añadidos enemigos voladores, hecho que funcionen las oleadas con ellos tambien,
Cambiado sistema de respawn(GameobjList)Preguntar jorge.
Solucionar errores sistema oleadas.


Dia13:
TodoList Hoy:
Añadir respawn infinito: hecho
Actualizar Trello: hecho

--
Parry ahora no te puede matar
Parry ahora cancela aa, lo que hace que responda antes.
Barra de vida se actualiza con todo(golpes,ataques,etc.)

ordenado carpetas y actualizado el main de todos






Dia14:

TodoList hacer mañana(o al terminar las prioridades nuevas al hablar con jorge:
Vida boss: a medias
effecto hacer daño boss: a medias
matar boss: otro dia
entrar en sala boss: otro dia
meter todo el graybox: otro dia

--preguntar jorge hasta que punto es worth usar interfazes cuando me obliga a hacer el metodo publico--
no lo es, quitar
----------
añadidas interfaces de ikilleable, idamageable y healplayer
x la mañana, empezado a hacer boss, pero me he desviado a hacer interfaces y aplicarlas a los enemigos.

hacer por la tarde:

1: Arreglar takedamage de los enemigos--Ok
2: revisar el playerheal--Ok

3: 
a venido jorge, nueva to do list con prioridades:
cambiar instancias objetos x object polling--Problema, solucinar mañana en clase
cambiar lista y referencias de la sala de rondas al roundManager--Ok
   

Dejar codigo limpio para mañana poder hacerlo/solucinarlo con jorge--Ok
quitado trabajo fin de semana q hay q mejorar,--Ok
mejorado enemigos volador y normal.--Ok
añadido instancia de enemigos al entrar en la sala de rondas(inicio de object booling)--Ok



Dia15:

Mejoras enemigo:
Ahora se espera u poco cuando te sales de su zona, lo que hace q no parezca como q te esta siguiendo todo el rato,--Ok
si esta atacando no se gira--Ok
siempre mira donde toca.--Ok
te empuja hacia afuera siempre--No, casi siempre si, pero ns cuando no lo hace.

BossFight:
Vida boss--Ok
effecto hacer daño boss--Ok
EntradaALaHabitacion--Ok
matar boss--Ok






Dia16:
empezado a trabajar en las oleadas con el nuevo sistema y con el object pooling.
intentado arreglar rondas con object pool, preguntar jorge.


usar awake para buscar variables y start para definir valores(cambiar todas clases a esto)--Ok
Estoy usando algunas interfaces comom ihealplayer solo para saber si curarle, si tener en cuneta nada mas, ns si eso es productivo o no(cambiar por clases vacias)--Ok
XQ CUNADO LE DAS A ALGO Y NO PUEDES HCARELO EN EL MOMENTO, L HACE AL TERMINAR LA ACCION(arreglado x codigo)--Ok
Solucionar bug deslizar al aparecer(otra vez)(ES LA GRAVEDAD)--Ok

Arreglar problemas con player--Ok(no arreglado cosas, pero como de momento lo dejo un poco mas de lado, me centro mejor en arreglar las salas.

Arreglar sistema salas hoy(para ponerme a modelar mañana.(imposible xd) imposible mis cojones lest goooo(despuies de como toda la tarde xdd)

cunado desactivo al enemigo, se queda mitad animacion para siempre.(desactivar sprite)--Ok


-----
coña xq esto tiene tela:
Restructurado enemigo melee por complete, usado scrips antiguos y nuevos, añadido a la lista de prioridades cambiar los scripts antiguos por los nuievos
ahora las rondas funcionan con el enemigo mele, meter mañana que funcionen tambien con los voladores y el cristal(y toda la pesca)

arreglar mañana seguro el tema del parry



FinDeSemana(Dia17):
Añadido enemigo volador al sistema de rondas(falta perfeccionar mucho)
solucionados problemas que habian con el sistema de rondas.
cambiado un poco el funcionamiento de los scrips del enemigo volador

Resto del fin de semana super chill;




Dia18(05/12/23):

Quitado temporalmente el spawn infinito de voladores en la sala de rondas, ahora funciona guay sin eso.(perfeccionar enemigos e interacciones con enemigos 

SOlucinar aa y parry sobreescriben y se buggea xd-- parece q Ok

Attaque del disco boss--ok
metter sprite boss-Estrutura basica boss--Ok
attaque pinchos--Ok


-----------------------------------------------------------------------------------------------------------------------------------
ToDoList:



arreglar mañana seguro el tema del parry


Se puede hacer doble salto rapido


cambiar todos los sccrips del melee por nuevos(hechos la mtad o asi)

revisar cosas sala oleadas y añadir enemigos voladores.


rafaga aa
Modificar collider Parry(De momento estunnea te pegue por donde te pegue.)
Añadir regiones y ordenar codigo
DARLE BUENA VUELTA AL ENEMIGO VOLADOR

meter todo el graybox: otro dia
BarraVidaBoss--






-----------------------------------------------------------------------------------------------------------------------------------
Preguntas;







 */