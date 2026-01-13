# Lösung: 3. Handlungsschritt (Proxy-Entwurfsmuster)

## a) Ergänzung des UML-Klassendiagramms

### 1. Klasse: RealMitglied
**Attribute (Sichtbarkeit: klassenintern `-`):**
- `- name : String`
- `- service : String`
- `- rating : Double`
- `- countRatings : Integer`

**Methoden (Sichtbarkeit: öffentlich `+`):**
- `+ RealMitglied(name : String, service : String)` (Konstruktor)
- `+ setService(service : String) : void` (Interface-Implementierung)
- `+ giveRating(rating : Integer) : Double` (Interface-Implementierung)
- `+ getName() : String` (vorhanden)
- `+ getService() : String` (vorhanden)

### 2. Klasse: Proxy
**Methoden (Sichtbarkeit: öffentlich `+`):**
- `+ Proxy(mitglied : RealMitglied, user : RealMitglied)` (Konstruktor)
- `+ setService(service : String) : void` (Interface-Implementierung)
- `+ giveRating(rating : Integer) : Double` (Interface-Implementierung)
- `+ isOwner() : boolean` (vorhanden)

### 3. Beziehungen (Diagramm-Logik)
- **Realisation:** Gestrichelte Linie mit hohler Pfeilspitze von `Proxy` und `RealMitglied` nach oben zum Interface `Mitglied`.
- **Assoziation:** Durchgezogene Linie von `Proxy` zu `RealMitglied` (da Proxy Instanzvariablen vom Typ RealMitglied hält).
- **Client-Verbindung:** Durchgezogene Linie von `Client` zum Interface `Mitglied`.



---

## c) Implementierung der statischen Fabrikmethode

**Anforderung:** Der Client nutzt nicht mehr den Konstruktor, sondern `Proxy.getInstance()`.

**Pseudocode:**

```java
// Innerhalb der Klasse Proxy
public static Proxy getInstance(RealMitglied mitglied, RealMitglied user) {
    // Erzeugung einer neuen Instanz und Rückgabe
    Proxy proxyInstance = new Proxy(mitglied, user);
    return proxyInstance;
}
```
