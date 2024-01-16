#region Primeros20Dias
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


Puente:

Terminar graybox
Añadir nuevo sistema camera boundaries
añadir miniMapa basico


Dia19:
Mejorado nuevo sistema camaras, añadido bloques que delemitan boundaries
añadida camara de los pasillos(camara estable que te sigue por el pasillo) No implementada en todos los pasillos
añadida sala grande con scripts modificados para que la camara funcione bien, la transicion sea smooth y no se salga de la sala.

quitado todos los colliders de todas las salas.
añadidos colliders para suelo paredes techo
añadido tp al final de primer piso que te lleva al segundo

cosas que faltan:
Añadir boundaries salas 3,4,6--Ok
meter movimiento puente--Ok
meter transicion al boss.--Ok


Hacer mañana:
Dejar claras dimensiones salas que ahora mismo no funcionan, ponerme con movimiento del pj



Dia20:

Trabajando en bugs del salto:

te deja hacer 2 saltos si lo haces rapido--Sol

Si mantienes en movimiento vuelve a saltar, quieto no(dejar para mas adelante)

Poner spawnpoints--Ok

Sala rondas:

hecho animaciones abrir y cerrar puertas--Ok

Mejorar pilares que caen, y hacer que te maten bn--Ok

Hacer por la tarde:
Añadir sistema rondas, muerte restablece sala, si superas la sala te vas.

De momento:
si te mueres se reinicia todo bienm, despues comprobar si hace las rondas bn(sin infinito)--Ok





Dia 21:
rafaga aa.--Ok(de momento)
hacer que enemigo volador se mueva--Ok
Eliminado enemigo volador--Ok
Borrar scrips que tienen que ver con enemigo volador--Ok
Arreglado bug que buffer jump no salta igual si estas quieto que en moviemineto(no lo tenia en mente pero se me ha ocurrido de la nada)

Hacer x la tarde:
Añadir cristal, que te dispare y atraviese plataformas pero no paredes--

Antes que se me olvide, quiero meter un enevnto de esos, para que las salas como la del boss o la sala de rondas se puedan suscribir cunado el pj entra,
y si muere que desde el playerHealth lo llame, por lo tanto, el pj simepre que muere llama al evento ese, si no estas en la sala de rondas, no pasa anda,
si estas, como el script de la sala de rondas habra añadido un metodo que reinicie la sala a ese evento, se reiniciara.lo mismo con la del boss--
(ahora toca hacerlo xd)



Dia22:

Solucionado y añadido tema nuevas ramas, problemas con ramas, organizacion de carpetas, etc.
añadido que aparezca el cristal en las rondas--ok
añadir que para pasar de ronda el cirstal tiene que estar roto--Ok

Hacer por la tarde:
añadir que al morir se restablezca la sala--Ok
corregir camara al entrar en sala--(solucionCutreTEMP)--Ok

Solucionar punto PivoteBoss--Ok
Empezar boss--Ok
Hacer barra vida pocha--Ok

Hacer mañana:
Añadir "Final" pocho
Añdir menus si eso
Creditos: x to skip
Trabajar en el boss

Dia23:

Pedir y apuntar feedback
Añadido parar en seco al saltar
nerfeo robo vida
reducida duracion parry


Ahbora no puedes hacer el parry durante Gamemanager.instance.instrongAttack;



Dia24(16/12/23):

Lista:

Copiar al enemigo de blashphemous:
Tempos blashphemous:
estado: quieto,
si te ve te persigue, te mira, te ataca, duracion ataque: 
si hay dos, y consigues q se pongan uno encima del otro, se combierten en el mismo enemigo
Ataca rapido, vuelve y espra un poco para volver a atacar.
Hit:
Stun 1 segundo--Ok
Hit te  quita todas las animaciones--Ok
Tempo aa--Ok
Solucionar problema con player hit y desactivar clases.


Solucionar bug aa arriba pega abajo antes

MOdo berserk


Cambiado layer mask del pj 

Hecho nuevo sistema de camaras entero

Nuevo sistema TP
Hacer mañana, mejorar y terminar todo camaras 



Dia25(18/12/23):

Arreglar respawn con camaras:--Ok
para hacer eso, he usado los metodos que ya tenia en CameraManager, cuando pones el respawnpoint, pones currentcam as respawnposcam, y luego cunado mueres usando
el metodo de CameraMangaer, desactivo la currentCam y activo la Respawnposcam, luego pongo currentcam a respawncam

Arreglar gancho feedbackVisual--Ok
Arreglar slide plataformas sala estatua--Ok
hacer que tpfuncione bien--Ok
Añadir unlockCollider--Ok
Terminar camaras`+ camaraBridge(1.6)--Ok
Añadir movvimiento en puete--Ok

PostMañanaClase:

Añdir Fade-In/Fate-Out--Ok(pero no se usa)

Implementar sala rondas(espero q no de problemas xd)--OK(habra q ajustarla pero estar esta




Empezar a trabajar en la bossfight con medidad nuevas--Ok

Añadir entrada a boss + empezar bossfight--Ok

Añadidos ataques boss, mas interacciones--Ok

Añadido menu basico para entrar--Ok

añadido delegado en player health para las interacciones(si funciona pasar a otro script)

Hacer mañana:


Dia26(19/12/23):
Añadir script mencionado arriba,--Ok
añadir atajo--Ok
dar a probar build.--Ok
Arreglar enemigos para usar solo un prefab--Ok
AñadirAnimacionEntryEnemigo--Ok
arreglado Tp no funciona de arriba a abajo--Ok
Añadir interactuarPara tp--Ok




Dia27(20/12/23):
Arreglado colliders
añadidas plataformas del gancho + ajustado sus coliders
añadidos enemigos al mapa
ajustado tp al boss y al segundo piso


probar build y arreglar bugs:
hacer q trampas se vean--Ok
añadir algo de sentido a la caida--Ok
hook te para a mitad--
subit enemigos --Ok
CorregirZfight--Ok


al llegar a casa:

Importar assets lucia



---ViajeChina--
Objetivos:
limpiar codigo
resolver dudas y cosas metidas en la todolist




Dia28(Desde el avion xd):
Arreglar AaDevLog--Ok
Añadir delegado ondeath para el player--Ok(funcional en RoundManager)
Borrar Scripts inutiles--

Dia29(Muy poco tiempo(25/12/23):
hacer merge desde el avion--Ok
corregir problemas merge--Ok
añadir cosas todolist--Ok
cosas hechas todolist:

-Cambiar punete a Action map distinto
me tengo que ir, añadido el mapa de acciones:
cosas que hacer al volver:
biorrar los inputs que se ponian al entrar en el puente, añadir que se cambie de mapa al entrar
creo que ya xd


Dia 30(26/12/23):
Terminar cosas cambiar de mapa en el puente,--Ok
cambiar todas referencias a movimiento tercera persona en lugar de puente--Ok
arreglar tema minimapa y uimanager duplicado--Ok
cambiar transicion a bossfight con nuevo mapa--Ok
arreglar inputs con cambio de nombre del otro mapa--
---------
Problema que a surgido, el cambio de escena al boss, se hace con otro script, no con el mismo que el resto de transiciones, 
la solucion q se me ha ocurrido seria añadir otra boleana para si lleva a bossfight o no, y en caso de activarla que te pida un metodo que añadir para empezar la bossfgiht con un timer.
ahora oslo me quedan 30 min, y me tendre que ir, a ver si me da timepo.
puta q me pario otro problema jaja, para el boss no queremos que sea interactuable, queremos que te haga tp sin mas, supongo que por eso no lo he añadido antes,
SOlucion temporal, te sale texto de desafiar al boss,
----
problema que solucionar proximo dia, no te deja interactuar por el cambio de mapa
añadir lo mencionado del boss
----


Dia31(30/12/23):

-Mover cosas player del GameManager al playerManager

he movido el healplayer, y he puesto las referencias de lo que se cura el pj en el player manager
creo que no hay mas referencias a la cantidad de vida curada en ningun sitio, pero idk
borrado clases no usadas

--------------



Dia32(31/12/24):

Terminar de mover cosas al player manager:
TODO ESTO:
    public bool canPlayerMove, canPlayerRotate, isOccupied, isPlayerStunned, isPlayerInvulnerable, isPlayerParry;
    [HideInInspector] public int playerDamage;
    public bool inStrongAttack;
    //dobleJump

cosas movidas(y solucionados errores de referencias al cambiar):
canPlayerMove--Ok
canPlayerRotate--Ok
isOccupied--Ok
Cambiado isOcupied por plauerInNormalAa, por que cumplian la misma funcion, y este ultimo es mas claro lo que hace. tmb quitado referencia en el roomtracking al playerinput, ahora la busca en el awake.
isPlayerStunned--Ok
----------
IMPORTANTE: quitado esto de el playerGravity, xq ahora mismo no le veo el uso, alomejor luego falla y toca volver a ponerlo
---------

isPlayerInvulnerable--Ok
isPlayerParry--Ok
playerDamage--Ok
Cambiado por playerCurrentDamage
PlayerHealth--Ok
isPlayerAlive--Ok
inStrongAttack--Ok

canDobleJump--Ok
Limpiado el playerGrouncheck--Ok

IsdobleJumpUnlocked--Ok

-Cambiar muerte a actionMap q no te deja hacer nada--Ok




 

*/
#endregion
/*




Dia33(Repite ese numerito):


Cambiado sistema carpetas environment y creada rama escenario-Ok



------------
-Cambiar funcionamiento Hook y hacer q funcione bien--Ok
------------
-hacer q el pj mire al hook--Ok
Primera parte(Gancho a traves)
descatkivar q de deje mitad aire cunado sales--Ok
doble salto al salir--Ok
quitado que te pare en medio--Ok
añadido doble salto al caer y al salir del hook--Ok
problema, coyote jump hace el doble jump
sol: Añadido variable de isfalling, puedes hacer doble salto cunado estas cayendo y el coyotetimer ya ha pasado(es decir q no podrias saltar)
Gancho en pared()
De momen to vamos a ajustar hooks para que funcione con el otro sistema



hacer despues del patio:

-Enemigos spawnean donde quieren--Ok
Era cosa de una animacion, y de que cambiaba el transform.`pos en lugar del transform.localpos
Estan en estados que no toca--Ns, de momento no he conseguido q pase



-Cambiar que parry solo sea hacia delante--Ok
comprobar xq entra 3 veces, si esta stun no pude hacer da´p
esto no acaba de funcionar, ademas el bug de perma stun puede sercausado por esto
Nuevo sistema, ahora es una caja el ataque, en lugar de la maza en si. si esta el enemigo stun no te puede hacer daño.



-Arreglar bugs Hook:
.si haces parry en la plataforma, dejas de estar en la plataforma--Ok
.si te pegan en mitad se buggea y te quedas ahi volando--Ok
.algunas veces te pasas volado y atraviessas los hooks--




Dia34(09/01/24):

añadir cosas que añadi en la build de jorge, y he perdido(Cerrar juego(hasta que pueda preguntar a jorge por los problemas))

-Enemigo se sale de las plataformas y atraviesa paredes--Ok
-parry y proyectiles va mal--Ok
-Enemigo sale en estado que no toca--Creo que Ok ESTABA MAL(ahora creo que si esta bn)


-Cambiar sistema camaras(falta por añadir la camara del boss)
Añadir esta tarde-->



desafiar boss, lo matas, te salen los creditos(con un metodo q llamaremos desde la animacion de muerte) te sale una opcion de si quieres seguir juegando, si le das  a que si, te lleva al mapa
otra vez, pero ahora puedes salir de la sala del boss a otras con normalidad.

Hecho todo hasta lo de volver xd
para eso necesito el sistema de guardado
fumada

Cosas que guardar a nivel basico:
ultimo punto de guardado, que el pj reaparezca en la posicion que le toca.

he hecho muchas cosas, pero mini resumen para mañana es que me guardo el valor del floar currentRoom, para esto,
cunado seteo un nuevo respawnpoint, transformo el valor del enum a float con un switch, y ese es el valor que guardo,
cunado lo lodeo, lo vuelvo a pasar de float a enum 
problemas: el spawnpoin ahora mismo no esta vinculado al numero de la room.
tendria que vincualarlo de alguna forma(ahora no se me ocurre) para asi en el start del spawnpoint, poner la posicion del plahyer al spawnpint.



Dia35(10/01/24):

Planning Mañana:

cosas que hacer hasta tener clase con jorge:
TODOLIST en orden:

-Algunas veces te pasas volado y atraviessas los hooks(solucionar con el physics drawcircle--Ok

-Funcionamiento de este boss, te saldra el mensaje de desafiar, y en caso de darle, empezara directamente la bossfiht, creditos, seguir jugando o main menu--Ok

Hacer hud creditos, con botones de seguir jugando y exit--Ok
puedes saltar rapido manteniendo--Ok
desbloqueas sala al completar bossfight--Ok

metre cosas encuestas en bugs/todolist--

PostPatio:

Preguntas Jorge:


-COMO HACER el tema del evento desde fuera(para la entrada del boss, que le pueda poner con un evento el metodo que inicia la bossfigth--De momento no, hacer con bossManager 
y herencias cunado se haga en plan bn.

-sistema de guardado, tema de transformar el enum, y como hacer lo de guardar la posicion de respawn.(no lo he pensado mucho, pero algo del palo de:
cuando guarde la posicion, que le digo que room es la de currenrespawn point, tengo tanto el transform del respawnpoint como la room, almacenarlos de alguna forma los dos?

--------------
Hacer que sala pasillo, sea normal una vez terminada la bossfight--Ok


meter guardado(new game te cargar posicion normal, load te lleva a punto guardado si tienes.)(esta tarde)--Nashe


-meter animaciones pablo--(cunado las tenga)



Dia 36(Jueves 11/01/24)
Solucionar bugs pequeños, actualizar lista todolist con estos bugs.

-Ataacar encima del tp hace que vaya mal--Ok

-Si te pegan deslizas infinito--De momento Ok(no lo he comprobado pero deberia ir bn)

-parry no cancela combo aa--Ok


-doble salto te das con el pilar--De no se soluciona

Post Patio

PREGUNTAR JORGE--Ok

-En algunas zonas(salto 1-2 a 1-2-2) el doble salto va raro--Ok
De momento quitado la distancia al suelo(hit = null)--Ok

-GameManager no funciona en awake--Normal(Ok)

-SOlucionar bug tercera persona, si andas alante y te paras luego paras no te deja seguir-- Movida con 100 llamadas al input--Ok
cambiar inputs a update--Ok
varias inputs--Ok


Meter todas animaciones Fate y hacer que funcione con animator nuevo--Ok

Dia 37(12/01/24):


-Popups:
Silla inicio(checPoint)--Ok
Silla hook--Ok
Silla rondas--Ok
Doble Jump--OK

comprobar que va todo--Ok
arreglar menu pause--Ok

Arreglar hooks--Ok

-TUto inicio parry(Ok(Pocho de momento))

-Meter forma guay de obtener doble jump--Ok(de momento hasta postpro)

-Player No Cae en inicio(de momento np)--Arreglado con si no estas en el suelo drag = 0--Ok

comprobar guardado depsues de mal push github--Ok

-Meter Fadein Fadeout En camaras con TP:
modificar tiempo de transicion de las camaras con tp--Ok
añadir fade--Ok



Dia38(14/01/24):
-interactuar en primera silla--Ok

-solo te deberia empujar izquierda o derecha--ok
-ajustar camaras--
Solucion facil: cunado te cambiar smoth el valor de x offset de la camara actual


-Mejorar tuto--
-que se pare en el momento de hacer parry--


Dia39:
arreglar sistema camaras--Ok
poner que aa no se pueda mover camara--Ok(de momento)


Cambiar tuto--
el enemigo solo podra:
te acercas, te ataca(no te puedes girar) le stuneas, se queda ahi para siempre con el texto de atacale( si le intentas atravesar hay una pared)
lo matas y vuelves al gameplay normal
Hasta tener feedback--Ok

meter todas animaciones pablo:
air AA--Ok
-si te pegan para arriba vuelas muchisimo--Ok


AA:
hacer que si sigues atacando no salga de la animacion--Ok
con primer ataque--Ok

CUNADO TERNGA los dos ataques, que haga lo mismo pero con los dos, es decir, reproduce el primero, luego el segundo y si has vuelto a darle otra vez el primero y otra vez el segundo


proyectil en el aire no te empuja ya--Ok

hook te manda a cuenca--OK




Dia 40(1/16/24):
Importar animaciones nuevas pablo--Ok

-Melee tiene que tardar mas en atacar--OK


Meter mapa nuevo--Ok


por la tarde:
hacer todolist:

añadir aa que funcione bien--Ok
cambiado el sistema dde aa por completo(si metiesemos mas adelante el 3cer ataque otra vez, supongo que seria hacer lo mismo
pero con un comprobador durante el seundo ataque,(el q ya esta) y luego meter otra booleana dentro del animator, q si le has dado a un eneimgo se ponga a true, y si se pone
a true haces el tercero y sino no(al igual lo ahago ahora q no parece tan complicado xd)

Añadir tercer aa--OK


Añadir palanca--Ok

Mejorar tuto--OK


-(Opcional)-Solucinar bugs--OK

-hook hace que salgas volando--OK

-Bug golpe midhook--Ok(probar)

-salto al pilar(solucion cutre)

-te puedes subir en el enemy spwawn(solucion cutre)


Dia41:
PREGUNTAR:
-te puedes subir en el enemy spwawn(solucion cutre)



preguntar Jorgge:
-meter guardado preboss
-Luz al iniciar desde otra escena
-----------------------------------------------------------------------------------------------------------------------------------
ToDoList:
-----------------------------------------------------------------------------------------------------------------------------------


poner animacion de hook buena(y walk e idle)--CUNADO LAS TENGA
-hook no te deberias poder mover hasta el hook(mirar si hace falta frenar al pj cunado este la nueva)
enemigo melee(19:00h)--





-laser cristal(mas rapido menos cadencia)
-enfocar salida en sala rondas

-----
BOSS
-----
-Los pinchos siempre salen en la misma posición

-Meter todos los ataques







NO PRIORITARIO:

-Añadir musica y SFX


-Revisar todos los sccrips del melee por nuevos(hechos la mtad o asi)
-Añadir regiones y ordenar codigo
-Cambiar forma de actualizar la vida(usando el get/Set)
-Cambiar todas referencia hook por interact
-hacer tanto boss como enemigos con clases heredadas y metodos como kill comunes
VFX:
-temblor al morir


-----------------------------------------------------------------------------------------------------------------------------------
BUGS:
-----------------------------------------------------------------------------------------------------------------------------------



No prioritario
-si mueres en el enemigo entry, se buggea

----------------------------------------------------------------------------------------------------------------------------------
PREGUNTAS:
-----------------------------------------------------------------------------------------------------------------------------------





------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ORGANIZACION
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Objetivos FIN-JUEGO(cosas que faltan por añadir):
MiniMapa Funcional(Descartado)
Menues
Bossfight
Sonidos
Coleccionables(Descartado)



quedan 4 semanas

-----------------
1 semana sol bugs
-----------------
Bugs que solucionar:

Transiciones funcionan bien--
-Añadir UI parry(circulo)

------------------------------
1 semana meter anims boss y pj
------------------------------
-meter animaicones pj, y solucionar bugs que puedan traer
-meter animaciones boss, hacer los ataques que faltan y terminar la bossfight
-solucionar bugs, y que la bossfght se sienta muy bien.
-arreglar sala rondas para que se entienda que tienes el cristal
-añadir modo berserk(si todo lo anterior esta bien.)
-------------------------------------
1 semana cerrar juego y arreglar bugs
-------------------------------------
-Añadir menues
-Añadir todo el sonido
-Comprobar que tenemos el juego 100% jugable a escepcion de las animaciones del meelee
-arreglar sala rondas para que se entienda que tienes el cristal
-añadir modo berserk(si todo lo anterior esta bien.)
--------------------------------
1 semana meter animaciones melee
--------------------------------
-meter animaciones melee y solucionar bugs que puedan traer
-asegurarse de que se siente bien el enemigo
-solucionar bugs del juego
-arreglar sala rondas para que se entienda que tienes el cristal
-añadir modo berserk(si todo lo anterior esta bien.)

--------------
FIN DEL SPRINT(el juego deberia estar terminado a escepcion de los vfx, iluminacion, cinematicas, etc)
--------------
primera semana febrero: Lunes 5


Segunda y ultima semana: Lunes 12 - Viernes 16

-------------------------
q significa para el resto(hablnado exclusivamente de lo mio)
------------------------
Primera semana:
trabajo libre
Segunda semana: Lunes 15
Animaciones boss y personaje principal y cristal
Tercera semana: Lunes 22
Musica
Sonidos
Arte 2d
Cuarta semana Lunes 29
Animaciones melee

---------------
Recortes
---------------
MiniMapa Funcional(Descartado)


 */