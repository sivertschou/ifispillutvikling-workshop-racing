# Racing-workshop med IFI Spillutvikling

Velkommen til racing-workshop!
Hvis du ikke allerde har installert Unity kan du gjøre det [her](https://store.unity.com/download?ref=personal). Vi bruker versjon 2018.2.7.

## Oppgave 1

### Sett opp prosjektet
Start Unity og opprett et prosjekt. Prosjektet skal bruke templaten 2D. Når prosjektet er åpnet kan du klone/laste ned dette repoet ([last ned repoet som .zip her](https://github.com/sivertschou/ifispillutvikling-workshop-racing/archive/master.zip)).
Når repoet er lastet ned må du finne Unity-prosjektet i filutforskeren din. Dette kan enkelt gjøres ved å høyreklikke inne i Project-vinduet, deretter "Show in Explorer" eller lignende. Du vil nå se at du er i prosjektets submappe; Assets. Dra alle filene inne i den nedlastede Assets-mappen inn i Unity-prosjektets Assets-mappe.

### Prosjektets struktur
Nå som vi har åpnet prosjektet vil vi se flere ulike vinduer. Hvis du ikke ser vinduet du ønsker å bruke kan du klikke på Window -> <vinduet du vil åpne> øverst i menybaren. Vi skal fokusere på vinduene:
* **Hierarchy** - Her ser vi alle de aktive objektene i scenen vår
* **Scene** - her plasserer og flytter objekter i scenen vår
* **Game** - her ser vi hvordan spillet vil se ut (fra kameraets perspektiv)
* **Inspector** - her ser vi informasjon om det valgte objektet
* **Project** - her ser vi filene som ligger i prosjektet
* **Tile Palette** - her har vi en oversikt over de ulike flisene (tiles) som vi ønsker å bruke som banen vår

Til tross for at hele prosjektet består av mange mapper og filer, vil vi kun trenge å bry oss om mappen Assets. Her vil alle filene vi bruker i spillet ligge. Vi legger til undermapper for å holde prosjektet oversiktlig. Dette er ekstra viktig når vi skal lage større prosjekter.

I Project-vinduet (og også prosjektet vårt) har mappene:
* **Prefabs** - her ligger våre forhåndsdefinerte spillobjekter. Dette er blant annet sammensetninger mellom kode og grafikk
* **Scenes** - her ligger scenene/spillnivåene våre
* **Scripts** - her ligger koden vår
* **Sprites** - her ligger 2D-grafikk
* **Tilemap** - her ligger kode vi trenger for at bilbanen enkelt skal kunne lages

## Oppgave 2
I denne delen skal vi sette opp spillet vårt. Når vi åpner prosjektet skal scenen "BaseScene" være åpnet, hvis den ikke er det må vi åpne denne fra mappen Assets -> Scenes. 

Her ser vi en gressflate med en liten del av en bilbane. Hvis vi tar en titt på **Hierarcy-vinduet** vårt ser vi har to objekter; "Main Camera" og "Grid", og at "Grid" har flere underobjekter (barn/children). 
**Main Camera** er kameraet som bestemmer det som skal vises i spillet - hva som vises kan vi se i vinduet "Game". 
**Grid** er det viktigste vi har i scenen vår enn så lenge. Det er her selve banen vår ligger og vil ligge, og selve rutenettet/komponenten brukes til å enkelt kunne plassere sprites/grafikk. Hvis vi tar en tit på underobjektene til "Grid" ser vi at vi har:
* **Track** - der vi har grafikken til selve banen/veien. Her ligger det også et script og en komponent som påvirker bilen, men mer om det senere.
* **Grass** - Her ligger selve gresset vårt. Dette er her kun for det estetiske.
* **Details** - Her vil vi kunne legge på diverse grafikkdetaljer, som for eksempel startstreken som allerede ligger der.

### Legge til bilen
Siden vi allerede har en liten del av bilbanen, kan vi legge til bilen vår for å teste hvordan standaroppførselen fungerer.
Vi navigerer oss mappen **Prefabs** ser vi en prefab med navn "CarPrefab". Vi kan nå dra og slippe denne prefaben inn i scenen vår, gjerne slik at den står på veien. Hvis vi nå tar en titt på "Hierarcy"-vinduet vårt skal vi nå ha tre objekter; "Main Camera", "Grid" og "CarPrefab". 
***
Klikk på bilen, enten i "Scene"- eller "Hierarcy"-vinduet. Vi ser nå at "Inspector"-vinduet vårt har fylt seg med informasjon om bilen. Helt øverst ser vi teksten "CarPrefab". Dette er navnet på objektet vårt, og det endrer vi til _MyCar_. 
Videre ser vi at bilobjektet har flere komponenter;
* **Transform** - informasjon om objektets posisjon, rotasjon og størrelse
* **Sprite Renderer** - en komponent som inneholder informasjon om hva slags 2D-grafikk som objektet skal vise/ha.
* **Capsule Collider2D** - en komponent som gjør at objektet kan kollidere med andre objekter (som har en Collider2D-komponent). Denne ser vi som en grønn kapsel rundt bilen.
* **Rigidbody2D** - en komponent som gjør at objektet kan bli påvikret av fysikk-motoren (Physics Engine) til Unity. Vi vil bruke denne til å få bilen til å bevege seg.
* **Car** - et script som vi har laget. Dette håndterer alt av oppførselen til bilen.
* **Player Inputs** - et script som vi har laget. Denne håndterer brukerinput, som igjen blir brukt av _Car_-scriptet.

Hvis vi trykker på **Play** øverst i midten av editoren (Play-knappen - man kan også bruke snarveien **Ctrl/Cmd + P**), kan vi bevege bilen vår. Hvis vi tar en titt på **Car-scriptet** ser vi at vi har mappet ulike variabler til ulike taster; forward er mappet til W, brake er mappet til S osv. Vi kan endre på disse, men vi lar de være enn så lenge. Det viktigste er at vi kan bevege på bilen vår ved å bruke W, A, S, og D.

### Endre bilen

Hvis vi ønsker at bilen skal f.eks. kjøre fortere kan vi ta en titt på **Car-scriptet**. Her har vi flere variabler vi kan endre på; blant annet _Acceleration_ og _Max Speed_. (OBS: Dersom du fortsatt er i Play-modus, altså at spillet kjører, vil ikke endringene bli lagret når du går ut av Play-modus).
***
Hvis vi ønsker å endre farge på bilen, så kan vi så klart gjøre det! Bilen som vi ser den nå er kun en sprite som vises gjennom **Sprite Renderer**, og denne kan vi bytte ut. 
* Finn _Sprite Renderer_-komponenten på bilen. 
* Klikk på den lille sirkelen ved siden av det øverste feltet i komponenten (feltet heter Sprite)
* Velg en passende bil-sprite fra menyen som kommer opp.

Kult, vi har nå en bil som vi enkelt kan endre både kjøreoppførsel og utseende!

## Oppgave 3

Banen vår er nå noe kjedelig, så det må vi gjøre noe med!


* Bak _Inspector_-vinduet skal det ligge et vindu som heter **Tile Palette**. Åpne dette vinduet ved å klikke på taben. Dersom du ikke skulle se dette vinduet, vil man kunne finne det ved å klikke på _Window_ -> _2D_ -> _Tile Palette_.
* Vi ser nå en toolbar øverst, her har vi diverse verktøy, men vi trenger foreløpig kun å bry oss om penselen/brush og viskelæret.
* Under toolbaren ser vi en dropdown; her ønsker vi at **Track** skal være valgt. Dette bestemmer hvilket lag vi skal tegne på, og _Track_ er en referanse til underobjektet til _Grid_-objektet.
* Under denne dropdownen ser vi selve paletten vår. Her kan vi klikke på en rute og bruke den som pensel.
* Klik nå på ruten med asfalt-spriten (øverst til venstre av spritene). Nå som denne er valgt kan vi begynne å tegne på banen vår.
* Tegn en bane med denne penselen i _Scene View_

Når du har laget en bane du er fornøyd med, kan du teste denne ved å klikke på _Play_
***
Hvis vi ønsker å legge til detaljer bør vi bytte det aktive Tile map-et fra _Track_ til _Details_, og deretter endre til en sprite/pensel som vi ønsker å tegne med. **Husk** å endre tilbake til _Track_ hvis du skal legge til mer på banen.

## Oppgave 4
Nå som vi har fått på plass det aller viktigste, kan vi nå begynne å fokusere på mindre ting. I denne delen skal vi legge til et kamera som følger bilen. En enkel måte å gjøre dette på er å lage et script som gjør at kameraet alltid har samme x- og y-verdiposisjon som bilen.

Naviger til **Scripts-mappen**. Opprett et nytt C#-script ved å høyreklikke i mappen, deretter _Create_ -> _C# Script_ og kall denne **CameraController**. 
Dobbelklikk på _CameraController_ for å åpne scriptet. 

Vi kan slette metoden _Start_, slik at vi sitter igjen med disse linjene:
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	
	}
}
```

For å få informasjon om bilens posisjon (x og y) trenger vi å opprette en referanse av typen Transform. Vi kaller denne carTrans og setter den lik null. Vi legger til [SerializeField] foran slik at vi får tilgang til denne variabelen fra editoren.

```C#
..
[SeriallizeField] Transform carTrans = null;

public class CameraController : MonoBehaviour {
..
```
Nå som vi har laget en referanse fra scriptet som vi kan sette i editoren, er det på tide å teste det. 
* Gå tilbake til Unity og velg **Main Camera** i _Hierarchy_-vinduet. 
* Klikk på **Add Componenet** i _Inspector_-vinduet. 
* Søk på _CameraController_, som er navnet på scriptet vi nettopp opprettet.

Nå har vi lagt til vårt selvlagde script på kameraet!
Hvis vi tar en titt på script-komponenten (_CameraController_) ser vi at vi også har et felt med navn _carTrans_ som tar inn en komponent av typen Transform.
Dra bilen (_MyCar_) fra _Hierarchy_-vinduet til feltet til _carTrans_. Vi har nå tilgang til Transform-komponenten til bilen gjennom _CameraController_-scriptet på _Main Camera_. 

Hvis vi kjører programmet nå ser vi at ingenting spesielt skjer. Det er fordi vi enda ikke har lagt til noe funksjonalitet i _CameraController_-scriptet.

***
Hvis vi går tilbake til koden/scriptet, så kan vi legge til noen linje i Update-metoden. Update-metoden kjøres for hver frame (ofte minst 60 ganger i sekundet), så her kan vi legge til funksjonalitet som gjør at kameraets x- og y-posisjon er lik bilens.

```C#
void Update () {
	//setter kameraets posisjon til å være bilens posisjon, 
	//men med et offset i z-aksen (slik at kameraet ikke er inni bilen)
	transform.position = carTrans.position + new Vector3(0f, 0f, -10f);
}
```

Hvis vi ønsker å zoome mer inn eller ut, kan vi endre på **Camera**-komponenten i _Inspector_-vinduet når vi har valgt _Main Camera_. Der kan vi endre zoom ved å endre **Size**-verdien.

## Oppgave 5

Nå om vi har fått på plass både bilen, banen og kameraet kan det være på tide å legge til multiplayer.

Dette kan vi enkelt gjøre ved å kopiere/duplisere (duplicate) _MyCar_ og _Main Camera_. Dette kan vi gjøre ved å markere begge objektene, deretter trykker vi på **Ctrl/Cmd + D**. For å holde prosjektet oversiktlig bør vi endre den nye bilens navn til f.eks. _MyCar2_ og kameraets navn til _Cam2_. Vi må nå endre bilens _Player Inputs_-komponents taster (W kan f.eks. endres til _Up Arrow_ osv.). Vi kan også endre denne bilens farger, slik som vi gjorde tidligere.
Siden _Main Camera_ har en komponent som heter _Audio Listener_, og siden vi har duplisert dette kameraet, må vi fjerne denne komponenten til _Cam2_. Dette er kun fordi at Unity kun tillater at man har én _Audio Listener_ per scene.
Vi må også få _Cam2_ sitt _CameraController_-script til å peke på **_MyCar2_**, og ikke _MyCar_. 
***
Nå som vi har satt opp det meste, er det nå på tide å lage split-screen-effekten. Vi ønsker nå å vise alt som vises av _Main Camera_ (altså i hovedsak _MyCar_) på venstre halvdel av skjermen, og alt som vises av _Cam2_ på høyre side av skjermen.
En enkel måte å oppnå dette på er ved å endre på **Camera**-komponenten til kameraene. Vi ønsker å endre på verdiene til _Viewport Rect_. 
Vi ønsker å endre _Main Camera_ sin _Viewpoint Rect_ sin **_width_** til 0.5. 
Vi ønsker å endre _Cam2_ sin _Viewpoint Rect_ sin **_width_** til 0.5 og **_x_** til 0.5.

Hvis vi starter spillet nå, ser vi at vi har oppnådd en split-screen-effekt!
