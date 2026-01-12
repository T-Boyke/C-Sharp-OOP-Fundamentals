```mermaid
sequenceDiagram
    %%participant A as Arzt
    create actor A as Arzt
    participant B as UI
    participant C as Verordnungen
    participant D as Medikation
    participant E as MediDB
    A->>B: ausgabeMedikationsplan()
    activate B
    B->>C: getMedikamente(patient)
    activate C
    C--)B: medikamenteList
    deactivate C

    loop für jedes Medikament in medikamenteList
        B->>D: getEinnahme(medikament, patient)
        activate D
        D--)B: einnahmeString
        deactivate D
        opt einnahmeString ist leer
            B->>E: getStandardMedikation(medikament)
            activate E
            E--)B: standardEinnahme
            deactivate E
        end
            B->>B: ausgabeMedikation(einnahmeString)
            activate B
            B-->>B:
            deactivate B
    end
    B--)A:
    deactivate B
```
