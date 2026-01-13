### Lösungstabelle: UML-Beziehungen

| Beschreibung | Beziehungstyp | Klassendiagramm (Symbolik) | Begründung |
| :--- | :--- | :--- | :--- |
| Eine Immobilie besteht aus mehreren Wohnungen. | **Komposition** | Linie mit einer **gefüllten Raute (♦)** auf der Seite der `Immobilie`. | Es liegt eine **Existenzabhängigkeit** vor. Die Teile (Wohnungen) können physisch nicht ohne das Ganze (Immobilie) existieren. Wird das Gebäude zerstört, sind die Wohnungen ebenfalls weg. |
| Bewohner können entweder Mieter oder Eigentümer sein. | **Generalisierung** (Vererbung) | Pfeile mit einer **hohlen Dreiecksspitze (△)** zeigen von `Mieter` und `Eigentümer` auf `Bewohner`. | Es handelt sich um eine **"Ist-ein"-Beziehung** (Spezialisierung). Mieter und Eigentümer sind spezifische Untergruppen der allgemeinen Klasse Bewohner. |
| In einer Mietervereinigung gibt es mehrere Mieter. | **Aggregation** | Linie mit einer **hohlen Raute (◇)** auf der Seite der `Mietervereinigung`. | Es ist eine **lose "Ganzes-Teile"-Beziehung**. Die Teile (Mieter) können eigenständig existieren. Wenn der Verein (das Ganze) aufgelöst wird, existieren die Mieter als Personen weiter. |

### Zum besseren Verständnis (Alltags-Analogien)

Um die Unterschiede der Beziehungen klarer zu machen:

* **Komposition (Strenge Bindung):** Denk an einen **Baum und ein Blatt**. Wenn der Baum stirbt und verrottet, stirbt das Blatt zwangsläufig mit. Es ist funktional untrennbar verbunden.
* **Generalisierung (Ist-ein):** Denk an **Obst und Apfel**. Ein Apfel *ist ein* Obst. Er erbt die Eigenschaften von Obst (z.B. essbar, pflanzlich), ist aber eine spezielle Form davon.
* **Aggregation (Lose Bindung):** Denk an ein **Fußballteam und Spieler**. Das Team besteht aus Spielern, aber wenn der Verein pleitegeht, existieren die Spieler als Menschen weiter und können zu einem anderen Team wechseln.
