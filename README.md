Algorithms

#1. Uppgift 1 
Implementera mergesort och quicksort specifikt för att sortera en array av int (som MyInsertionTest gör). Kopiera inte bara kod från boken eller från nätet – förutom det ni får från MyInsertionTest (observera att den innehåller en shuffle-metod ni kan använda till quicksort) och ändra, utan skriv själv från scratch, med utgångspunkt från beskrivningarna ovan. (Om ni väljer att ”fuska” genom att ta kod från andra håll är det inget vi kan göra något åt, men det förtar en stor del av poängen med uppgiften och gör att ni inte lär er så mycket. Om det är någon detalj i beskrivningen ni inte förstår utan att titta i bokens kod får ni naturligtvis göra det, men skriv aldrig av utan att förstå.)

    Testkör koden enligt samma modell som i MyInsertionTest för att se till att det funkar korrekt. Prova att läsa indata både från filen smallints och largeints.

#2. Uppgift 2
Välj ett eller flera av dessa alternativ för att testa för att undersöka eller försöka förbättra er mergesort eller quicksort (eller båda), och gör en utvärdering av hur algoritmen beter sig i förhållande till den oförändrade. Observera att det inte alls är säkert att allt faktiskt medför någon märkbar förändring i exekveringstiden i det praktiska fallet, det är bland annat det ni ska utvärdera!

    Det är viktigt att ni inte bara testar med indata från smallints. Eftersom den har så få olika värden i förhållande till längden ger det många likadana element intill varandra i den sorterade ordningen, vilket resulterar i icke representativa resultat i en del mätningar.

## 1. 
Mergesort och quicksort: byt till insertion sort för små delar. Insertion sort är ofta snabbare än mer avancerade metoder när antalet element är litet. Ändra i koden för de båda algoritmerna så att rekursionen inte går hela vägen ner till delarrayer av storlek 1, utan byter till insertion sort när antalet element är mindre än något tal M. Experimentera för att ta reda på vad som är ett bra värde på M (är det kanske 10, 100, 1000? binärsök gärna, manuellt eller automatiskt, för att hitta en mer precis bästa brytpunkt).

        I quicksort innebär denna förändring att det är lite onödigt att göra shuffle på alla element i arrayen: det borde räcka att räkna ut ett slumptal varje gång man kör en partitionering, vilket nu blir mindre än det totala antalet element. Därför kan detta experiment gärna kombineras med c (ingen shuffle). Blir det någon skillnad i körtid tack vare det minskade antalet ”slumptal”? Blir det samma förändring för alla arraystorlekar, eller varierar det med antalet element (fundera och testa)?

##2. 
Mergesort: minimera kopieringar till extralagring. Den givna, enklaste, formuleringen av mergesort kopierar en del av arrayen till extralagringen (aux-arrayen) vid varje merge. Det gör att det blir en del kopierande fram och tillbaka, som kan undvikas i de flesta fall om man låter sorteringens input och output vara olika arrayer. Då kan varannan nivå i rekursionsdjupet ta element från originalarrayen och lägga i extraarrayen, och varannan tvärtom. Vi låter alltså merge-operationen flytta element åt ena hållet när rekursionsdjupet är jämnt och åt andra när rekursionsdjupet är udda. Det kan dock behövas en kopieringsomgång, eftersom vi inte kan vara säkra på att alltid få ett udda antal rekursionsnivåer totalt. (Det här är en enkel idé, som dock kan vara lite trixig att få rätt på detaljerna i.)

        Blir det någon skillnad i körtid tack vare det minskade antalet kopieringar? Blir det samma förändring för alla arraystorlekar, eller varierar det med antalet element (fundera och testa)?

# Uppgift 3
Quicksort: Ingen shuffle. Gör inte den inledande omblandningsoperationen i quicksort, utan testa att istället välja pivotelement med några olika strategier. Prova följande idéer. I samtliga fall blir det antagligen lättast att implementera genom att man byter elementet man valt mot det första, och sedan kör algoritmen precis som i originalkoden.
* Originalkoden väljer det första. Fundera på (eller läs om) hur indata då behöver se ut för att vi ska hamna i ett urartningsfall som ger kvadratisk tidskomplexitet. Testa det sedan i praktiken.
* Välj det sista som pivotelement istället. Förändrar det vilka fall som blir kvadratiska urartningar (fundera och testa)?
* Välj det mittersta. Kan ni hitta ett fall som urartar till kvadratisk tid?
* Välj ett slumpmässigt element. (Se i shuffle-implementationen hur man får fram ett slumptal mellan två gränser.)
* Frivillig ytterligare variant: välj medianen av det första, sista och mittersta elementet. Kan ni hitta ett fall som urartar till kvadratisk tid nu?

Fundera och gör mätningar. För att testa på fallet när input redan är sorterad, eller sorterad i omvänd ordning, kan man använda sin egen sorteringsalgoritm för att placera elementen i den ordningen. Andra specialfall går också att tänka ut och generera; inget krav att ni gör det fullständigt, men fundera gärna på det.

