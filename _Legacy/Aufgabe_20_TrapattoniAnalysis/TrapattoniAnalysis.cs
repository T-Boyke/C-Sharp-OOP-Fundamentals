/*
 * 70-483 Strings 21. Januar 2026
 * Aufgabe Trappatoni:
 * Die älteren unter Ihnen erinnern sich vielleicht noch an die legendäre Wutrede von Giovanni
 * Trappatoni während einer Pressekonferenz...
 * * a) Wie viele Sätze wirft der völlig zu Recht empörte Herr Trappatoni den Journalisten hier an den
 * Kopf? Wie viele Wörter sind es insgesamt? Versuchen Sie zunächst eine Lösung mit den
 * Methoden der Klasse String zu finden (split() könnte hier funktionieren) und versuchen Sie
 * anschließend eine alternative Lösung über eine Schleife zu finden (ein String ist ein Array aus
 * chars).
 * * b) Zerlegen Sie den Text als nächstes in einzelne Wörter und speichern Sie diese dann in einem
 * Dictionary<string, int>. Ein Dictionary ist eine Collection, bei der zu einem Schlüssel (das Wort)
 * ein beliebiger Wert (die Anzahl) gespeichert werden kann. Schauen Sie in der offiziellen
 * Dokumentation oder der IntelliSense oder einer KI Ihrer Wahl, wie man mit einem Dictionary
 * arbeiten kann. Ermitteln Sie dann das häufigste und das seltenste Wort in der Rede.
 * BITLC | Tom Selig 1
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TrapattoniAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"Es gibt im Moment in diese Mannschaft, oh, einige Spieler vergessen ihnen
Profi was sie sind. Ich lese nicht sehr viele Zeitungen, aber ich habe gehört viele
Situationen. Erstens: wir haben nicht offensiv gespielt. Es gibt keine deutsche Mannschaft
spielt offensiv und die Name offensiv wie Bayern. Letzte Spiel hatten wir in Platz drei
Spitzen: Elber, Jancker und dann Zickler. Wir müssen nicht vergessen Zickler. Zickler ist
eine Spitzen mehr, Mehmet eh mehr Basler. Ist klar diese Wörter, ist möglich verstehen, was
ich hab gesagt? Danke. Offensiv, offensiv ist wie machen wir in Platz. Zweitens: ich habe
erklärt mit diese zwei Spieler: nach Dortmund brauchen vielleicht Halbzeit Pause. Ich habe
auch andere Mannschaften gesehen in Europa nach diese Mittwoch. Ich habe gesehen auch zwei
Tage die Training. Ein Trainer ist nicht ein Idiot! Ein Trainer sie sehen was passieren in
Platz. In diese Spiel es waren zwei, drei diese Spieler waren schwach wie eine Flasche leer!
Haben Sie gesehen Mittwoch, welche Mannschaft hat gespielt Mittwoch? Hat gespielt Mehmet
oder gespielt Basler oder hat gespielt Trapattoni? Diese Spieler beklagen mehr als sie
spielen! Wissen Sie, warum die Italienmannschaften kaufen nicht diese Spieler? Weil wir
haben gesehen viele Male solche Spiel! Haben gesagt sind nicht Spieler für die italienisch
Meisters! Strunz! Strunz ist zwei Jahre hier, hat gespielt 10 Spiele, ist immer verletzt!
Was erlauben Strunz? Letzte Jahre Meister geworden mit Hamann, eh, Nerlinger. Diese Spieler
waren Spieler! Waren Meister geworden! Ist immer verletzt! Hat gespielt 25 Spiele in diese
Mannschaft in diese Verein. Muss respektieren die andere Kollegen! Haben viel nette
Kollegen! Stellen Sie die Kollegen die Frage! Haben keine Mut an Worten, aber ich weiß, was
denken über diese Spieler. Müssen zeigen jetzt, ich will, Samstag, diese Spieler müssen
zeigen mich, seine Fans, müssen alleine die Spiel gewinnen. Muss allein die Spiel gewinnen!
Ich bin müde jetzt Vater diese Spieler, eh der Verteidiger diese Spieler. Ich habe immer die
Schuld über diese Spieler. Einer ist Mario, einer andere ist Mehmet! Strunz ich spreche
nicht, hat gespielt nur 25 Prozent der Spiel. Ich habe fertig! Wenn es gab Fragen, ich kann
Worte wiederholen.";

            Console.WriteLine("--- Teil A: Statistik mit String.Split() ---");
            AnalyzeWithSplit(text);

            Console.WriteLine("\n--- Teil A (Alternativ): Statistik mit Schleife ---");
            AnalyzeWithLoop(text);

            Console.WriteLine("\n--- Teil B: Wörterbuch (Dictionary) ---");
            AnalyzeWithDictionary(text);
        }

        static void AnalyzeWithSplit(string input)
        {
            // Sätze trennen (bei . ! ?)
            // RemoveEmptyEntries verhindert, dass leere Strings gezählt werden
            string[] sentences = input.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            // Wörter trennen (bei Leerzeichen, Zeilenumbruch, Satzzeichen)
            char[] splitChars = { ' ', '\n', '\r', '.', ',', '!', '?', ':', ';' };
            string[] words = input.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine($"Anzahl Sätze: {sentences.Length}");
            Console.WriteLine($"Anzahl Wörter: {words.Length}");
        }

        static void AnalyzeWithLoop(string input)
        {
            int sentenceCount = 0;
            int wordCount = 0;
            bool insideWord = false; // "Schalter", um Wortgrenzen zu erkennen

            // Der String ist ein Array aus Chars, wir laufen einmal komplett durch
            foreach (char c in input)
            {
                // Satzende prüfen
                if (c == '.' || c == '!' || c == '?')
                {
                    sentenceCount++;
                }

                // Wortzählung Logik
                // Ist das Zeichen ein Buchstabe/Ziffer?
                if (char.IsLetterOrDigit(c))
                {
                    if (!insideWord)
                    {
                        wordCount++;     // Neues Wort beginnt
                        insideWord = true;
                    }
                }
                else
                {
                    insideWord = false; // Wir sind nicht mehr in einem Wort
                }
            }

            Console.WriteLine($"Anzahl Sätze: {sentenceCount}");
            Console.WriteLine($"Anzahl Wörter: {wordCount}");
        }

        static void AnalyzeWithDictionary(string input)
        {
            // 1. Text säubern: Alles was kein Buchstabe/Ziffer ist durch Leerzeichen ersetzen
            // Damit "Spieler!" und "Spieler" das gleiche Wort sind.
            string cleanText = Regex.Replace(input, @"[^\w\s]", " ");

            // 2. Splitten
            string[] rawWords = cleanText.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // 3. Dictionary erstellen (Case Insensitive: "Ich" == "ich")
            var wordFrequency = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            foreach (string word in rawWords)
            {
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++; // Wert erhöhen
                }
                else
                {
                    wordFrequency.Add(word, 1); // Neu anlegen
                }
            }

            // 4. Auswertung mit LINQ (Modern)
            var mostFrequent = wordFrequency.MaxBy(kvp => kvp.Value);
            var leastFrequent = wordFrequency.MinBy(kvp => kvp.Value); // Findet das erste seltenste Wort

            Console.WriteLine($"Häufigstes Wort: '{mostFrequent.Key}' ({mostFrequent.Value} mal)");
            Console.WriteLine($"Ein seltenes Wort: '{leastFrequent.Key}' ({leastFrequent.Value} mal)");
        }
    }
}
