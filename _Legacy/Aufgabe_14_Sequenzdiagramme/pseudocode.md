```
FUNKTION ausgabeMedikationsplan():
    medikamenteList = Verordnungen.getMedikamente(patient)

    FÜR JEDES medikament IN medikamenteList:
        einnahmeString = Medikation.getEinnahme(medikament, patient)

        WENN einnahmeString IST LEER:
            einnahmeString = MediDB.getStandardMedikation(medikament)
        ENDE WENN

        UI.ausgabeMedikation(einnahmeString)
    ENDE FÜR
ENDE FUNKTION
```
