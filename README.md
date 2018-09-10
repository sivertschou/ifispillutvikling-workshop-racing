# Racing-workshop med IFI Spillutvikling

Velkommen til racing-workshop!
Hvis du ikke allerde har installert Unity kan du gjøre det [her](https://store.unity.com/download?ref=personal). Vi bruker versjon 2018.2.7.

## Oppgave 1

### Sett opp prosjektet
I denne oppgaven skal dere sette opp prosjektet. Dette kan gjøres ved å klone/laste ned dette repoet ([last ned repoet som .zip her](https://github.com/bekk/serverless-workshop/archive/master.zip)).
Når prosjektet er lastet ned og unzippet kan du starte Unity og deretter åpne prosjektet. 

### Prosjektets struktur
Nå som vi har åpnet prosjektet vil vi se flere ulike vinduer. Hvis du ikke ser vinduet du ønsker å bruke kan du klikke på Window -> <vinduet du vil åpne> øverst i menybaren. Vi skal fokusere på vinduene:
* **Hierarchy** - Her ser vi alle de aktive objektene i scenen vår
* **Scene** - her plasserer og flytter objekter i scenen vår
* **Game** - her ser vi hvordan spillet vil se ut (fra kameraets perspektiv)
* **Inspector** - her ser vi informasjon om det valgte objektet
* **Project** - her ser vi filene som ligger i prosjektet
* **Tile Palette** - her har vi en oversikt over de ulike flisene (tiles) som vi ønsker å bruke som banen vår

Til tross for at vi hele prosjektet består av mange mapper og filer, vil vi kun trenge å bry oss om mappen Assets. Her vil alle filene vi bruker i spillet ligge. Vi legger til undermapper for å holde prosjektet oversiktlig. Dette er ekstra viktig når vi skal lage større prosjekter.

Vi har mappene:
* **Scenes** - her ligger scenene/spillnivåene våre
* **Scripts** - her ligger koden vår
* **Sprites** - her ligger 2D-grafikk