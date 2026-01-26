classDiagram
    class Warenhaus{
    - _name: string
    - _warenbestand: int
    - _kassenbestand: decimal
        
    %% Statische Felder für Aufgabe d)
    - _anzahlWarenhaueser: int$
    - _gesamtWarenbestand: int$
    - _gesamtKassenbestand: decimal$
        
    %% Properties(Kapselung)
    + >>Name: string<<
    + >>Warenbestand: int<<
    + >>Kassenbestand: decimal<<
        
    %% Konstruktor
    + Warenhaus(name:string, startWaren:int, startKasse:decimal)
        
    %% Methoden
    +InfoAusgeben() void
    +Einkauf(menge:int) bool
    +Verkauf(menge:int) bool
        
    %% Statische Methoden
    + GetGesamtStatistik() string$}
