using System;

namespace ValueReferencesApp
{
    public class Person
    {
        public string Name { get; set; } = "";
    }

    public static class MemoryExperiment
    {
        /// <summary>
        /// Versucht, einen Wertetyp (int) zu ändern. 
        /// Da int 'By Value' übergeben wird, passiert im Original nichts.
        /// </summary>
        public static void ModifyValue(int val)
        {
            val = 999;
        }

        /// <summary>
        /// Ändert einen Wertetyp über 'ref'. 
        /// Das Original WIRD verändert.
        /// </summary>
        public static void ModifyValueRef(ref int val)
        {
            val = 999;
        }

        /// <summary>
        /// Ändert ein Objekt (Referenztyp).
        /// Die Adresse wird kopiert, aber beide zeigen auf dasselbe Haus.
        /// Änderungen sind sichtbar!
        /// </summary>
        public static void ModifyReferenceContent(int[] arr)
        {
            if (arr != null && arr.Length > 0)
            {
                arr[0] = 999;
            }
        }

        /// <summary>
        /// Ändert die Referenz selbst (auf ein neues Objekt).
        /// Das Original zeigt weiterhin auf das alte Objekt.
        /// </summary>
        public static void ReassignReference(Person person)
        {
            // person zeigt jetzt auf ein NEUES Objekt im Heap.
            // Die Variable beim Aufrufer zeigt aber noch auf das alte Objekt.
            person = new Person { Name = "New Person" };
        }

        /// <summary>
        /// Ändert die Referenz über 'ref'.
        /// Wir tauschen das Haus aus, und der Aufrufer merkt es!
        /// </summary>
        public static void ReassignReferenceRef(ref Person person)
        {
            person = new Person { Name = "New Person" };
        }
    }
}
