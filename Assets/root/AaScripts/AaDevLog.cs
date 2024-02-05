#region Primeros20Dias
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

ordenado carpetas y actualizado el main de todos






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

hacer por la tarde:

1: Arreglar takedamage de los enemigos--Ok
2: revisar el playerheal--Ok

3: 
a venido jorge, nueva to do list con prioridades:
cambiar instancias objetos x object polling--Problema, solucinar ma�ana en clase
cambiar lista y referencias de la sala de rondas al roundManager--Ok
   

Dejar codigo limpio para ma�ana poder hacerlo/solucinarlo con jorge--Ok
quitado trabajo fin de semana q hay q mejorar,--Ok
mejorado enemigos volador y normal.--Ok
a�adido instancia de enemigos al entrar en la sala de rondas(inicio de object booling)--Ok



Dia15:

Mejoras enemigo:
Ahora se espera u poco cuando te sales de su zona, lo que hace q no parezca como q te esta siguiendo todo el rato,--Ok
si esta atacando no se gira--Ok
siempre mira donde toca.--Ok
te empuja hacia afuera siempre--No, casi siempre si, pero ns cuando no lo hace.

BossFight:
Vida boss--Ok
effecto hacer da�o boss--Ok
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

Arreglar sistema salas hoy(para ponerme a modelar ma�ana.(imposible xd) imposible mis cojones lest goooo(despuies de como toda la tarde xdd)

cunado desactivo al enemigo, se queda mitad animacion para siempre.(desactivar sprite)--Ok


-----
co�a xq esto tiene tela:
Restructurado enemigo melee por complete, usado scrips antiguos y nuevos, a�adido a la lista de prioridades cambiar los scripts antiguos por los nuievos
ahora las rondas funcionan con el enemigo mele, meter ma�ana que funcionen tambien con los voladores y el cristal(y toda la pesca)

arreglar ma�ana seguro el tema del parry



FinDeSemana(Dia17):
A�adido enemigo volador al sistema de rondas(falta perfeccionar mucho)
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
A�adir nuevo sistema camera boundaries
a�adir miniMapa basico


Dia19:
Mejorado nuevo sistema camaras, a�adido bloques que delemitan boundaries
a�adida camara de los pasillos(camara estable que te sigue por el pasillo) No implementada en todos los pasillos
a�adida sala grande con scripts modificados para que la camara funcione bien, la transicion sea smooth y no se salga de la sala.

quitado todos los colliders de todas las salas.
a�adidos colliders para suelo paredes techo
a�adido tp al final de primer piso que te lleva al segundo

cosas que faltan:
A�adir boundaries salas 3,4,6--Ok
meter movimiento puente--Ok
meter transicion al boss.--Ok


Hacer ma�ana:
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
A�adir sistema rondas, muerte restablece sala, si superas la sala te vas.

De momento:
si te mueres se reinicia todo bienm, despues comprobar si hace las rondas bn(sin infinito)--Ok





Dia 21:
rafaga aa.--Ok(de momento)
hacer que enemigo volador se mueva--Ok
Eliminado enemigo volador--Ok
Borrar scrips que tienen que ver con enemigo volador--Ok
Arreglado bug que buffer jump no salta igual si estas quieto que en moviemineto(no lo tenia en mente pero se me ha ocurrido de la nada)

Hacer x la tarde:
A�adir cristal, que te dispare y atraviese plataformas pero no paredes--

Antes que se me olvide, quiero meter un enevnto de esos, para que las salas como la del boss o la sala de rondas se puedan suscribir cunado el pj entra,
y si muere que desde el playerHealth lo llame, por lo tanto, el pj simepre que muere llama al evento ese, si no estas en la sala de rondas, no pasa anda,
si estas, como el script de la sala de rondas habra a�adido un metodo que reinicie la sala a ese evento, se reiniciara.lo mismo con la del boss--
(ahora toca hacerlo xd)



Dia22:

Solucionado y a�adido tema nuevas ramas, problemas con ramas, organizacion de carpetas, etc.
a�adido que aparezca el cristal en las rondas--ok
a�adir que para pasar de ronda el cirstal tiene que estar roto--Ok

Hacer por la tarde:
a�adir que al morir se restablezca la sala--Ok
corregir camara al entrar en sala--(solucionCutreTEMP)--Ok

Solucionar punto PivoteBoss--Ok
Empezar boss--Ok
Hacer barra vida pocha--Ok

Hacer ma�ana:
A�adir "Final" pocho
A�dir menus si eso
Creditos: x to skip
Trabajar en el boss

Dia23:

Pedir y apuntar feedback
A�adido parar en seco al saltar
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
Hacer ma�ana, mejorar y terminar todo camaras 



Dia25(18/12/23):

Arreglar respawn con camaras:--Ok
para hacer eso, he usado los metodos que ya tenia en CameraManager, cuando pones el respawnpoint, pones currentcam as respawnposcam, y luego cunado mueres usando
el metodo de CameraMangaer, desactivo la currentCam y activo la Respawnposcam, luego pongo currentcam a respawncam

Arreglar gancho feedbackVisual--Ok
Arreglar slide plataformas sala estatua--Ok
hacer que tpfuncione bien--Ok
A�adir unlockCollider--Ok
Terminar camaras`+ camaraBridge(1.6)--Ok
A�adir movvimiento en puete--Ok

PostMa�anaClase:

A�dir Fade-In/Fate-Out--Ok(pero no se usa)

Implementar sala rondas(espero q no de problemas xd)--OK(habra q ajustarla pero estar esta




Empezar a trabajar en la bossfight con medidad nuevas--Ok

A�adir entrada a boss + empezar bossfight--Ok

A�adidos ataques boss, mas interacciones--Ok

A�adido menu basico para entrar--Ok

a�adido delegado en player health para las interacciones(si funciona pasar a otro script)

Hacer ma�ana:


Dia26(19/12/23):
A�adir script mencionado arriba,--Ok
a�adir atajo--Ok
dar a probar build.--Ok
Arreglar enemigos para usar solo un prefab--Ok
A�adirAnimacionEntryEnemigo--Ok
arreglado Tp no funciona de arriba a abajo--Ok
A�adir interactuarPara tp--Ok




Dia27(20/12/23):
Arreglado colliders
a�adidas plataformas del gancho + ajustado sus coliders
a�adidos enemigos al mapa
ajustado tp al boss y al segundo piso


probar build y arreglar bugs:
hacer q trampas se vean--Ok
a�adir algo de sentido a la caida--Ok
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
A�adir delegado ondeath para el player--Ok(funcional en RoundManager)
Borrar Scripts inutiles--

Dia29(Muy poco tiempo(25/12/23):
hacer merge desde el avion--Ok
corregir problemas merge--Ok
a�adir cosas todolist--Ok
cosas hechas todolist:

-Cambiar punete a Action map distinto
me tengo que ir, a�adido el mapa de acciones:
cosas que hacer al volver:
biorrar los inputs que se ponian al entrar en el puente, a�adir que se cambie de mapa al entrar
creo que ya xd


Dia 30(26/12/23):
Terminar cosas cambiar de mapa en el puente,--Ok
cambiar todas referencias a movimiento tercera persona en lugar de puente--Ok
arreglar tema minimapa y uimanager duplicado--Ok
cambiar transicion a bossfight con nuevo mapa--Ok
arreglar inputs con cambio de nombre del otro mapa--
---------
Problema que a surgido, el cambio de escena al boss, se hace con otro script, no con el mismo que el resto de transiciones, 
la solucion q se me ha ocurrido seria a�adir otra boleana para si lleva a bossfight o no, y en caso de activarla que te pida un metodo que a�adir para empezar la bossfgiht con un timer.
ahora oslo me quedan 30 min, y me tendre que ir, a ver si me da timepo.
puta q me pario otro problema jaja, para el boss no queremos que sea interactuable, queremos que te haga tp sin mas, supongo que por eso no lo he a�adido antes,
SOlucion temporal, te sale texto de desafiar al boss,
----
problema que solucionar proximo dia, no te deja interactuar por el cambio de mapa
a�adir lo mencionado del boss
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
a�adido doble salto al caer y al salir del hook--Ok
problema, coyote jump hace el doble jump
sol: A�adido variable de isfalling, puedes hacer doble salto cunado estas cayendo y el coyotetimer ya ha pasado(es decir q no podrias saltar)
Gancho en pared()
De momen to vamos a ajustar hooks para que funcione con el otro sistema



hacer despues del patio:

-Enemigos spawnean donde quieren--Ok
Era cosa de una animacion, y de que cambiaba el transform.`pos en lugar del transform.localpos
Estan en estados que no toca--Ns, de momento no he conseguido q pase



-Cambiar que parry solo sea hacia delante--Ok
comprobar xq entra 3 veces, si esta stun no pude hacer da�p
esto no acaba de funcionar, ademas el bug de perma stun puede sercausado por esto
Nuevo sistema, ahora es una caja el ataque, en lugar de la maza en si. si esta el enemigo stun no te puede hacer da�o.



-Arreglar bugs Hook:
.si haces parry en la plataforma, dejas de estar en la plataforma--Ok
.si te pegan en mitad se buggea y te quedas ahi volando--Ok
.algunas veces te pasas volado y atraviessas los hooks--




Dia34(09/01/24):

a�adir cosas que a�adi en la build de jorge, y he perdido(Cerrar juego(hasta que pueda preguntar a jorge por los problemas))

-Enemigo se sale de las plataformas y atraviesa paredes--Ok
-parry y proyectiles va mal--Ok
-Enemigo sale en estado que no toca--Creo que Ok ESTABA MAL(ahora creo que si esta bn)


-Cambiar sistema camaras(falta por a�adir la camara del boss)
A�adir esta tarde-->



desafiar boss, lo matas, te salen los creditos(con un metodo q llamaremos desde la animacion de muerte) te sale una opcion de si quieres seguir juegando, si le das  a que si, te lleva al mapa
otra vez, pero ahora puedes salir de la sala del boss a otras con normalidad.

Hecho todo hasta lo de volver xd
para eso necesito el sistema de guardado
fumada

Cosas que guardar a nivel basico:
ultimo punto de guardado, que el pj reaparezca en la posicion que le toca.

he hecho muchas cosas, pero mini resumen para ma�ana es que me guardo el valor del floar currentRoom, para esto,
cunado seteo un nuevo respawnpoint, transformo el valor del enum a float con un switch, y ese es el valor que guardo,
cunado lo lodeo, lo vuelvo a pasar de float a enum 
problemas: el spawnpoin ahora mismo no esta vinculado al numero de la room.
tendria que vincualarlo de alguna forma(ahora no se me ocurre) para asi en el start del spawnpoint, poner la posicion del plahyer al spawnpint.



Dia35(10/01/24):

Planning Ma�ana:

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
Solucionar bugs peque�os, actualizar lista todolist con estos bugs.

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
a�adir fade--Ok



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

a�adir aa que funcione bien--Ok
cambiado el sistema dde aa por completo(si metiesemos mas adelante el 3cer ataque otra vez, supongo que seria hacer lo mismo
pero con un comprobador durante el seundo ataque,(el q ya esta) y luego meter otra booleana dentro del animator, q si le has dado a un eneimgo se ponga a true, y si se pone
a true haces el tercero y sino no(al igual lo ahago ahora q no parece tan complicado xd)

A�adir tercer aa--OK


A�adir palanca--Ok

Mejorar tuto--OK


-(Opcional)-Solucinar bugs--OK

-hook hace que salgas volando--OK

-Bug golpe midhook--Ok(probar)

-salto al pilar(solucion cutre)

-te puedes subir en el enemy spwawn(solucion cutre)

 

*/
#endregion
/*


Dia41:

Meter boss bueno--No pude

Importar boss--No pude

empezar con los ataques.--No pude

no he podido hacer los ataques por tema de rootmotion, me espro a pregunarle a jorge ma�ana.

meter modelo enemigo meelee con animaciones--Ok(parece poco pero me toco hacer todo el enemigo de 0 xd)

mal dia, no me han salido las cosas :(





Dia 42:

Haccer que las oleadas funcionen con el nuevo enemigo--Ok

Solucionar bugs:
-Le das dos veces al atacar, y te hjace el tocho


Borrar todas referencias y scritps de la bossfight--Ok
ataque columnas--Ok
ataque dash--Ok
ataque disco--Ok
A�adir effecto visual de hacer da�o--Ok


Dia43:

ajustar pilares boss--Ok
Cambiar collider dhas--Ok

-Aniamciones nuevas fate--Ok

-Texturas fate--Ok

-hacer tutorial--Ok

Mejorar enemigo melee--OK


inplementar nuevo mapa--Ok


Arreglar bugs buidl--Ok

a�adir atajo y doble salto al guardado--Ok

Arreglar textos--Ok



Dia44:

A�adida trampa nueva, creado animaciones de abrir y cerrar--Ok

Implementar trampa en tutorial--Ok

implementar trampa en sala doble salto--

implementar trampa en sala Oleadas--Ok

Arreglar bug enemigo melee no le puedes pegar--Ok
A�adir vaya nueva, con animacion de abrir y cerrar--Ok

Hacer despues del patio:

-enfocar salida en sala rondas--oK

-a�ADIR Palanca con animacion en sala dole salto--Ok

-Arreglar creditos--Ok








TAREDE:
-A�adir Menus:

menu pause
--Resume-->
--Opciones-->
volumen general
sonidos 
musica
calidad
exit<--
--Main Menu-->

--Play-->
--Load-->

--Options-->
volumen general
sonidos 
musica
calidad
exit<--

--Creditos-->

--Exit-->
--Ok
--Falta darle funcionalidad a los sonidos



Dia45:

meter animaciones nuevas boss--Ok
arreglar bug puertas sala rondas--Ok
apuntar feedback profesores

Boss:
a�adir stun del aatque(mismo para los dos lados)--Ok
Stun especifico por lado--OK
pincho especifico por lado--Ok
�rrelgar bug vida--Ok


Guia primera fase:--Ok

pilares- CD de 3 ataque, es decir, se empieza a barajar la posibilidad de que salga una vez han pasado 3 ataques.
Patada- no puede salir tres veces seguidas
disco- no puede salir tres veces seguidas
combo- CD de 3 ataque, es decir, se empieza a barajar la posibilidad de que salga una vez han pasado 3 ataques.(6to obligatorio)

Nashe




Guia segunda fase:

combo- sale normal
Patada- salen 40%menos (randmon tange dentro q si sale el 40% llama a otro ataque)
Pilares-  80% probabilidad de que la animacion de disco llame a otro ataque a mitad(solo con patada o disco)
disco- 80% probabilidad de que la animacion de disco llame a otro ataque a mitad(solo con patada o pilar)


Para disco y pilares
se podria hacer con eventos en la animacion, que en caso de estar en la segunda fase, tengan un 80% de posibilidades de llamar a otro ataque y por lo tanto irse.
Patada:
si cunado llamas al ataque, el random range sobre 10 que tiene dentro no da numeors del 1-4, llama a otro.
combo:
si toca toca xd(25%)


a�adir combos de ataques--
a�adir segunda fase--




Dia46:
Metido mapa nuevo--Ok
Solucionar problemas con z de la sala--OK
A�adir nuevo walk--Ok

Despues del patiio

arreglar posiciones bossfight--Ok
arreglar rotacion animaciones boss--Ok
arreglar bossfight en general xd--OK
A�adir movimiento cortinas + reverencia--Ok

Solucionar pilares(mas grandes)--Ok
mover posiciones vcombo--Ok

falta por hacer del boss:

arregar coliders
ajustar da�o y forma de recivir el da�o
revisar en clase y ajustar mas cosas.
-Terminar boss FIght(animacion muerte)



Dia47:
ToDoList

--solucionar problema con carpeta antigua--



-A�adir sonicods
--A�adido FMOD--Ok
--A�adir salto--Ok
--Doble salto--Ok
--Arreglar bug con buggger timer--Ok
--A�adido todos los sonidos de fate--OK
--Arreglado bug respawn--OK


segunda fase no se reinicia tras muerte--OK
Enemigo no se le puede pegar--Ok
-SFX--OK




Dia48:
Arreglar problemas fmod y meter proyecti en pc nuevo--Ok
A�adir animacion sentar buena--Ok
sala desaparece-Ok(sol cutre)
Cambiar animaciones por nuevas--OK


dia 49:
BUG Silla con popUps--Ok

-Recolocar asset Puerta y comprobar gameplay 1 vez--OK

-hacer que los fmod listeners esten en todas las escenas--Ok

-probar que funciona con la main theme--Ok

-meter fade in fade out en las canciones(main theme, level theme)--OK

-A�adir musica:
problema con transion de la musica, empieza en la "pantalla de carga" pero no hay pantalla de carga
mneter pantalla de carga--Ok

por la tarde:
mter sonidos otra vez--Ok
terminar de meter musica--Ok
Meter volumen sfx y musica--Ok(faltan los menues)


Dia50:

Meter nueva barra de vida--OK
Meter animaciones y modelo de cristal nuevo--Ok
Programar cristal nuevo--OK
animarr creistal nueevo--Ok
Implementar cristal nuevo en rondas--Ok


Dia51:
arreglar  colliders raycast crsital--Ok
añadir daño al pj--Ok

arreglar animaciones salto--Oks
movimiento camra al entrer rondas--Ok
arreglar instantBoss--Ok
nuevo stun boss--OK

-puerta se abre al pillar la silla--Ok


ajustar ataques boss--OK
subir daño tercer ataque--Ok
solucinar posiciones combo--Ok

meter escalera nueva(atajo)--



Dia52:

Arreglar posiciones sillas--Ok
-añadir muerte boss-OK
-Ajustar sillas--oK
-aJUSTAR Menues--Ok


Dia53:
meter todo arte 2d:

mETER animaciones popups(fade InFadeOut)--Ok
-meter arte 2d para coger gancho y doble salto--Ok
meter fade in fade out en el tutorial enemigo melee(Tutorial)--Ok
-meter arte parry--Ok
-hacer que animaciones funcionen bn en todas las sillas--Ok
-Solucionar enemigo desaparece en 2 seg;

-Meter cuadro en menues-Ok
-Meter barra vida nueva--Ok

meter fade en guia sentarse silla--Ok
Lo mismo pero para todas--Ok
popUpDesaparece al sentarse--Ok


arreglar sentado en silla raro--Ak



FALTA:
Palanca--Ok
Arreglar problema popup1-3-1--Ok
Fate para subir y bajar mapa-OK
Fade al coger doble salto--OK


--
-Meter font definitiva--Ok
hacer prueba en menu pause--OK




PREGUNTAR DAILY:
fate desafiar boss---
fate subir y bajar atajo-
fade al abrir menu--






-----------------------------------------------------------------------------------------------------------------------------------
ToDoList:
-----------------------------------------------------------------------------------------------------------------------------------


--Meter textura enemigo Melee

-Ajustar camaras--
transicionesCamaras--
   
   
-implementar rayo laser--
   
-Cambiar trampas por nuevas--





-----


-----
BOSS
-----







NO PRIORITARIO:
-hacer coleccionable


-Re hacer el sistema de aa triple, o por lo menos entenderolo
-Revisar todos los sccrips del melee por nuevos(hechos la mtad o asi)
-A�adir regiones y ordenar codigo
-Cambiar forma de actualizar la vida(usando el get/Set)
-Cambiar todas referencia hook por interact
-hacer tanto boss como enemigos con clases heredadas y metodos como kill comunes
VFX:
-temblor al morir


-----------------------------------------------------------------------------------------------------------------------------------
BUGS:
-----------------------------------------------------------------------------------------------------------------------------------
Tp fin juego instant no rula

salto raro animacion�
animacion stun
animacion muerte boss
spam sonido silla
con doble salto puedes salir y entrar de sala rondas
parry del reves(no sabemos xq)


No prioritario
-si mueres en el enemigo entry, se buggea

----------------------------------------------------------------------------------------------------------------------------------
PREGUNTAS:
-----------------------------------------------------------------------------------------------------------------------------------




preguntar Jorge:
-Luz al iniciar desde otra escena


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
ORGANIZACION
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Objetivos FIN-JUEGO(cosas que faltan por a�adir):
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
-A�adir UI parry(circulo)

------------------------------
1 semana meter anims boss y pj
------------------------------
-meter animaicones pj, y solucionar bugs que puedan traer
-meter animaciones boss, hacer los ataques que faltan y terminar la bossfight
-solucionar bugs, y que la bossfght se sienta muy bien.
-arreglar sala rondas para que se entienda que tienes el cristal
-a�adir modo berserk(si todo lo anterior esta bien.)
-------------------------------------
1 semana cerrar juego y arreglar bugs
-------------------------------------
-A�adir menues
-A�adir todo el sonido
-Comprobar que tenemos el juego 100% jugable a escepcion de las animaciones del meelee
-arreglar sala rondas para que se entienda que tienes el cristal
-a�adir modo berserk(si todo lo anterior esta bien.)
--------------------------------
1 semana meter animaciones melee
--------------------------------
-meter animaciones melee y solucionar bugs que puedan traer
-asegurarse de que se siente bien el enemigo
-solucionar bugs del juego
-arreglar sala rondas para que se entienda que tienes el cristal
-a�adir modo berserk(si todo lo anterior esta bien.)

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