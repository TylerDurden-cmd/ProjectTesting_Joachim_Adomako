# Product Reordering System

## Overzicht
Dit project is een systeem voor het herbestellen van producten dat bepaalt welke producten moeten worden herbesteld op basis van hun huidige voorraad, minimale voorraad en verwachte vraag.

### Functies
- Bepalen welke producten moeten worden herbesteld.
- Ondersteuning voor meerdere producten met verschillende voorraadniveaus.
- Unit tests om de correctheid van de herbestellogica te waarborgen.
- Acceptatietests geschreven in Gherkin-syntaxis.

## Projectstructuur
- **UnitTest.cs**: Bevat unit tests voor de herbestellogica.
- **Product.feature**: Bevat acceptatietests in Gherkin-syntaxis.
- **Product.cs**: Definieert de `Product`-klasse.
- **IProductService.cs**: Definieert de `IProductService`-interface.
- **MockProductService.cs**: Mock-implementatie van `IProductService`.
- **Reorder.cs**: Bevat de logica om te bepalen welke producten moeten worden herbesteld.
- **ReorderStepDefinition.cs**: Stapdefinities voor het Gherkin-featurebestand.
- **ClassDiagram.puml**: Bevat het klassenoverzicht, te bekijken met PlantUML.

## Installatie
### Vereisten
- .NET 8
- Visual Studio of Visual Studio Code
- PlantUML (voor het bekijken van het klassenoverzicht)

### Tests uitvoeren
1. Open de oplossing in Visual Studio.
2. Bouw de oplossing om de afhankelijkheden te herstellen.
3. Voer de unit tests uit met de Test Explorer.

### Acceptatietests uitvoeren
1. Open de oplossing in Visual Studio.
2. Bouw de oplossing om de afhankelijkheden te herstellen.
3. Voer de acceptatietests uit met de Test Explorer.

## Gebruik
Om het herbestelsysteem te gebruiken, maak je een instantie van de `Reorder`-klasse en geef je een implementatie van `IProductService` door. Roep de methode `DetermineReorder` aan om de lijst met producten te verkrijgen die moeten worden herbesteld.

## Testscenario's
### Unit Tests
1. **DetermineReorder_Returns_EmptyList_WhenStockSufficient**  
   Beschrijving: Verifieert dat geen producten worden toegevoegd aan de herbestellijst wanneer de huidige voorraad voldoende is.  
   Testgegevens:  
   - Playstation 5: HuidigeVoorraad = 30, MinVoorraad = 12, VerwachteVraag = 5  
   - iPhone 14: HuidigeVoorraad = 30, MinVoorraad = 10, VerwachteVraag = 5  
   - Zenbook: HuidigeVoorraad = 20, MinVoorraad = 18, VerwachteVraag = 5  
   Verwachte resultaat: De herbestellijst moet leeg zijn.

2. **DetermineReorder_Returns_ExceptionWhenCurrentStock_LessThan_0**  
   Beschrijving: Verifieert dat een uitzondering wordt gegenereerd wanneer de huidige voorraad kleiner is dan 0.  
   Testgegevens:  
   - JBL Speaker: HuidigeVoorraad = -1, MinVoorraad = 3, VerwachteVraag = 20  
   Verwachte resultaat: Een `ArgumentException` moet worden gegenereerd.

3. **DetermineReorder_AddsProductToReorderList_WhenCurrentStockLessThanMinStock**  
   Beschrijving: Verifieert dat een product wordt toegevoegd aan de herbestellijst wanneer de huidige voorraad lager is dan de minimale voorraad.  
   Testgegevens:  
   - JBL Speaker: HuidigeVoorraad = 2, MinVoorraad = 3, VerwachteVraag = 20  
   Verwachte resultaat: De herbestellijst moet "JBL Speaker" bevatten.

4. **DetermineReorder_DoesNotAddProductToReorderList_WhenCurrentStockGreaterThanMinStock**  
   Beschrijving: Verifieert dat een product niet wordt toegevoegd aan de herbestellijst wanneer de huidige voorraad hoger is dan de minimale voorraad.  
   Testgegevens:  
   - JBL Speaker: HuidigeVoorraad = 4, MinVoorraad = 3, VerwachteVraag = 20  
   Verwachte resultaat: De herbestellijst moet leeg zijn.

5. **DetermineReorder_HandlesMultipleProductsWithMixedStockLevels**  
   Beschrijving: Verifieert dat de herbestellijst correct wordt bepaald voor meerdere producten met gemengde voorraadniveaus.  
   Testgegevens:  
   - JBL Speaker: HuidigeVoorraad = 2, MinVoorraad = 3, VerwachteVraag = 20  
   - Playstation 5: HuidigeVoorraad = 30, MinVoorraad = 12, VerwachteVraag = 5  
   - iPhone 14: HuidigeVoorraad = 10, MinVoorraad = 10, VerwachteVraag = 5  
   - Zenbook: HuidigeVoorraad = 20, MinVoorraad = 18, VerwachteVraag = 5  
   Verwachte resultaat: De herbestellijst moet "JBL Speaker" bevatten.

### Acceptatietests
1. **Geen producten hoeven te worden herbesteld**  
   Scenario: Geen producten hoeven te worden herbesteld.  
   Gegeven:  
   - Playstation 5: HuidigeVoorraad = 10, MinVoorraad = 5, VerwachteVraag = 20  
   - Xbox Series X: HuidigeVoorraad = 15, MinVoorraad = 10, VerwachteVraag = 15  
   Wanneer: Ik de herbestellijst bepaal.  
   Dan: De herbestellijst moet leeg zijn.

2. **Een product moet worden herbesteld**  
   Scenario: Een product moet worden herbesteld.  
   Gegeven:  
   - Playstation 5: HuidigeVoorraad = 2, MinVoorraad = 5, VerwachteVraag = 20  
   - Xbox Series X: HuidigeVoorraad = 15, MinVoorraad = 10, VerwachteVraag = 15  
   Wanneer: Ik de herbestellijst bepaal.  
   Dan: De herbestellijst moet "Playstation 5" bevatten.

3. **Productvoorraad is gelijk aan minimale voorraad**  
   Scenario: Productvoorraad is gelijk aan minimale voorraad.  
   Gegeven:  
   - Playstation 5: HuidigeVoorraad = 5, MinVoorraad = 5, VerwachteVraag = 20  
   - Xbox Series X: HuidigeVoorraad = 15, MinVoorraad = 10, VerwachteVraag = 15  
   Wanneer: Ik de herbestellijst bepaal.  
   Dan: De herbestellijst moet leeg zijn.

4. **Productvoorraad is groter dan minimale voorraad**  
   Scenario: Productvoorraad is groter dan minimale voorraad.  
   Gegeven:  
   - Playstation 5: HuidigeVoorraad = 6, MinVoorraad = 5, VerwachteVraag = 20  
   - Xbox Series X: HuidigeVoorraad = 15, MinVoorraad = 10, VerwachteVraag = 15  
   Wanneer: Ik de herbestellijst bepaal.  
   Dan: De herbestellijst moet leeg zijn.

5. **Meerdere producten met gemengde voorraadniveaus**  
   Scenario: Meerdere producten met gemengde voorraadniveaus.  
   Gegeven:  
   - Playstation 5: HuidigeVoorraad = 2, MinVoorraad = 5, VerwachteVraag = 20  
   - Xbox Series X: HuidigeVoorraad = 30, MinVoorraad = 10, VerwachteVraag = 15  
   Wanneer: Ik de herbestellijst bepaal.  
   Dan: De herbestellijst moet "Playstation 5" bevatten.

## Structuur en testaanpak
De projectstructuur is ontworpen om de logica en functionaliteiten te scheiden. Unit tests zijn ontwikkeld om elke specifieke methode en situatie te testen, terwijl acceptatietests de eindgebruikersscenario's simuleren. Door deze combinatie wordt zowel technische nauwkeurigheid als gebruiksvriendelijkheid gewaarborgd.

