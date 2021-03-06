# Procesmodel:


# Processtyringsværktøj
- Kanban

# Systemudviklingsmetode


# Teknikker og værktøjer:
- Pair programming (XP)



# Document management: 
- Github,  google docs og emails.

# Krav fra projektoplæg:
- Løsningens bærende element skal være en web applikation.
- Vi skal bruge ASP.NET Core 2.x MVC og ASP.NET Core 2.x Web API.
- Vi skal gøre brug af entity framework
- Vi skal anvende Docker til virtualisering af løsningen.
- Der skal tages højde for samtidighedsproblemer, samt tilføjes autentifikation.
- Vi skal vælge og benytte en passende procesmodel
- Vi skal vælge og benytte en passende systemudviklingsmetode og eventuelt tilpasse den
- Vi skal sikre jer, at jeres løsning lever op til gængse sikkerhedsstandarder, herunder sikring mod de mest gængse hackingangreb.
# Opdeling i microservices - kravsindsamling
- Reminder: 
  - Hvis en bruger af systemet ikke har brugt applikationen til at træne med, skal systemet først udsende en notifikation til brugeren. Hvis en trænningssesion ikke er påbegyndt efter 48 timer, vil den udspecificerede træningspartner for den specifikke bruger blive notificeret om fraværet af træning. 
- Matchmaking:
  - Skal bruges til at finde træningspartnere tæt på. Man specificerer postnummer og så bliver man matchet med andre brugere, som befinder sig tæt på.
  - Man skal kunne lave et filter med kriterier, som træningspartnerne skal imødekomme, fx. alder og køn
  - Man skal kunne kommunikere med sine træningspartnere via chatbeskeder.
  - Skal bruges til at vælge træningstypen. Der skal laves en dropdown-menu, hvorpå alle mulige træningsformer er mulige. Derudover skal det også være muligt at tilføje sine egne træningssessioner, hvis de prædifenerede ikke eksisterer på listen. 
- Gamification
  - Man skal modtage trofæer, når man opnår forskellige ting med sin træning. Hvis man fx slår rekorder i de forskellige discipliner, eller man opnår et x antal træningspas.
  - Der skal være en samlet tabel, hvor man bliver placeret afhængig af hvor mange point man har opnået gennem træning. Det kunne f.eks. være muligt at se, hvor godt man klarer sig ift. venner/forbindelser og/eller på lokalt by-niveau (andre i byen som også bruger applikationen) 
- Authentication og authorization 
  - Det skal være muligt at gendanne sit kodeord, gerne med nulstillings-email. 
  - Du skal kunne registrere en bruger og derefter blive logget ind med dine personlige oplysninger. Brugere som ikke er logget ind skal ikke have lov til at oprette træningssessioner eller melde sig til dem. 
  - Det skal være muligt for ikke-registrerede bruger at se træningssessioner     og hvem man kan træne med. 

# High level design

Områder:
- Application security
  - Vi vil gøre brug af Asp.Net core’s Identity services, for at både gemme og beskytte vores brugeres personlige oplysninger. JSon Web Tokens vil blive brugt til at autorisere brugerne og hvilken funktionalitet, de har adgang til. Begrundelsen for at vælge denne løsning er at sikkerhed er et rigtigt vigtigt emne i dagens samfund. Derfor har vi besluttet at gå med en anerkendt metode, der både er gennemtestet og sikker. 
- Database
  - Entity Framework Core: Vi vil ikke spilde tiden med at skrive SQL-statements og SPs, som udfører trivielle CRUD-operationer
  - Microsoft SQL Server  
- Deploy 
- GDPR
  - Vi gemmer og bruger persondata i overensstemmelse med GDPR (se f.x. privacy-by-design).
  - Vi sikrer applikationen i overensstemmelse med GDPR (se f.x. security-by-design).
- Arkitektur
  - ASP.NET Core API og MVC 
  - REST
  - Microservices
- User interface:
  - Da det ikke er en del af vores fokusområde, designer vi ikke UI’et på vores Webapplikation. Vi henter i stedet et færdigt template fra templatemonster eller et andet sted
- External interfaces
  - Vi integrerer et map (Google Maps? Ja, det er en god ide) i forbindelse med Matchmaking
  - Mailudbyder: SMTP-tjeneste til afsendelse af mails til bekræftelse og nulstilling af kodeord mm.

## High level design
Sikkerhed:
Vi indsamler ingen personfølsomme data.
Brugeren kan, hvis de ønsker det, selv beskrive deres sygdom gennem en ‘beskrivelses boks’
Hardware:
Skal have en enhed, som understøtter en browser
Skal have internetadgang.
En database, hvor der er plads til profiler, og billeder
Server til websiden
Arkitektur
ASP. NET Core MVC (Model-View-Controller)
Client/server & multi-tier

User Interface
Single window
Mock-up?
Internal interfaces
SCRUM
Entity framework

External interface
API for geolocation
Database
Vi gemmer data i en Relationel DB. Den skal kunne indeholde billeder, tekst.
MS SQL
Rapport
2-4 siders refleksion over valg og brug af procesmodel og systemudviklingsmetoder. 
Web application
Low-level design

## Low level design
Vi har benyttet Entity Framework Core og derfor kontrollerer det hvordan arv i entity klasserne er repræsenteret i databasen.

I vores projekt kunne man alternativt  have bruge refinement i form af både træning, samt trofæer (template method) hvor der ville have været en superklasse (skitse) som skulle specialiseres ned i subklasser.

Vi vælger at bruge MVC. Dertil kunne man også have tilføjet et observer pattern der kan holde styr på når properties ændre sig, og fyrer events til dette.

Vi har valgt at oprette en relationel database til projektet. Årsagen ligger i at relationelle databaser er simple, nemme at bruge og giver god mulighed for at søge, samle data fra forskellige tabeller, sortere resultater og omrokere data.

Vi har opnået 3 NF da vi har ingen felter uden for primærnøglen der er indbyrdes afhængige. Ligeledes findes der ingen transitive funktionelle afhængigheder mellem non-prime attributter.




## Requirements Gathering - fra det oprindelige projekt==>
Indsamling af Krav:
Da vi ikke havde mulighed for at spørge brugerne (De demente) om krav til systemet, valgte vi at benytte Jerry’s fremlæggelse som kravindsamling. Under præsentationen kom han ind på hvem brugerne er, hvor langt de er i sygdomsforløbet og hvordan de opfører sig i den digitale sfære.
Samtidigt fik vi udleveret krav fra underviserne omkring selve systemet og hvad det skal ende ud i. Da projektets primære formål er at få brugt vores viden, var kravene derfor at binde læring sammen med praksis.

Use cases
Use case: Find træning
En bruger vil gerne finde en træning. Brugeren trykker “find en træningspartner i dit område”. Når brugeren finder en træning vil der gives besked om “Træning fundet”. Beskeden vil ligeledes indeholde et kort der viser hvor træningen afholdes. 

Use case: Opret træning
En bruger vil gerne oprette en træning. Brugeren trykker på “opret træning”. Inden træningen bliver oprettet, skal brugeren specificere træningen og hvad den skal indeholde.


Use case: Oversigt over point
En bruger vil gerne have en oversigt over point og opnåelser. Han trykker på knappen “point oversigt”, hvorefter han kan danne sig et overblik over, hvor mange point han har, hvor mange gange han har trænet og hans opnåelser. 

Use case: Notifikationer og kontaktpersoner
En bruger vil gerne have tilsendt en besked, når han skal træne. Han vælger via indstillingerne, at han gerne vil have en notification klokken 16:00. Derudover, vælger han yderlige to kontaktpersoner, som også får en besked, hvis bruger ikke reagere på sin egen besked. 

⇐ slut
