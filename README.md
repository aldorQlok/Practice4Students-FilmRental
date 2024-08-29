# 🎬 FilmRental API - ASP.NET Core Web API Project

Välkommen till **FilmRental API** - ett projekt skapat med ASP.NET Core Web API! 🚀 Detta projekt är utformat för att ge dig en chans att dyka djupare in i kodens uppbyggnad och se hur ett REST API fungerar i praktiken. Du uppmuntras att granska, reflektera och förbättra koden genom att identifiera förbättringsområden och implementera ny funktionalitet.

## 🎯 Projektmål
Det här projektet är till för att:
- Ge dig praktisk erfarenhet av att arbeta med ASP.NET Core Web API.
- Lära dig hur ett API fungerar, hur CRUD-operationer implementeras och vilka statuskoder som används.
- Uppmuntra dig att tänka kritiskt och hitta sätt att förbättra koden.

## 📝 Uppgifter och Utmaningar
Här är några områden du kan fokusera på när du går igenom projektet:

### 1. 📜 Kodgranskning
- Gå igenom koden i **Controllers**, **Services**, och **Repositories**. Fundera över hur koden kan förbättras och om den följer bästa praxis.
- Kontrollera att rätt **statuskoder** returneras i varje scenario (t.ex. `200 OK`, `201 Created`, `204 No Content`, `400 Bad Request`, `404 Not Found`).
  
### 2. ⚠️ Felhantering
- Identifiera platser där **felhantering** saknas eller kan förbättras. Hur kan vi bättre hantera undantag eller oväntade situationer?
- Implementera tydliga och användarvänliga felmeddelanden som hjälper utvecklare och användare att förstå vad som gick fel.

### 3. 🛡️ Validering och Säkerhet
- Se till att korrekt **validering** av data sker vid inmatning, särskilt vid POST och PUT-operationer. Är alla obligatoriska fält markerade som `[Required]`?
- Fundera på om det finns potentiella säkerhetsproblem, som t.ex. felaktig hantering av användarinmatning.

### 4. 🛠️ Extra Funktionalitet
- Är det någon extra funktionalitet som du tycker skulle passa in? Lägg till nya endpoints, förbättra befintlig logik eller skapa nya DTOs för att optimera datatrafiken.
- Fundera på hur du kan göra API:et mer skalbart eller tillgängligt.

### 5. 📈 Prestanda och Effektivitet
- Analysera hur **prestanda** kan förbättras. Finns det operationer som kan optimeras, t.ex. genom att använda asynkrona metoder mer effektivt?
- Kontrollera att rätt `Include` används för att minimera onödiga databasfrågor.

### 6. 📚 Kommentera Koden
- Koden som den är nu saknar kommentarer. När du går igenom koden, skriv egna **kommentarer** för att beskriva vad varje del gör och varför. Det hjälper inte bara dig, utan även andra som tittar på koden i framtiden.

## 🚀 Kom igång
För att komma igång med projektet:
1. Gör en fork av detta repo: `Practice4Students-FilmRental` till ditt eget GitHub-konto.
2. Klona din fork lokalt: `git clone https://github.com/ditt-användarnamn/Practice4Students-FilmRental.git`
3. Skapa en migration genom att skriva: `add-migration init` i Package Manager Console.
4. Skapa databasen genom att skriva: `update-database` i Package Manager Console.
5. Nu kan du starta appen och kan testa alla endpoints.
6. APIets UI når du via Swagger på `https://localhost:7127/swagger`

## 💡 Uppmuntran
- Samarbeta gärna med andra! Diskutera koden, utmana varandras lösningar och dela idéer om förbättringar. Tillsammans kan ni lära er ännu mer och skapa en bättre slutprodukt.

## 🎉 Lycka till!
Låt din kreativitet flöda och använd detta tillfälle för att lära dig så mycket som möjligt. Det är inte bara en övning i att hitta problem, utan också en chans att utveckla lösningar och bygga en robust och skalbar applikation!

Happy coding! 👩‍💻👨‍💻
