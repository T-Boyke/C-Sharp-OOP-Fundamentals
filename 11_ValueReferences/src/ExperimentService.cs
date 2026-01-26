namespace _11_ValueReferences.src
{
    public class ExperimentService
    {
        // 1. Wertetyp (Kopie)
        public void ModifyValue(int val)
        {
            val = 999;
            // Änderung nur lokal, "val" ist eine Kopie
        }

        // 2. Referenztyp (Array)
        public void ModifyReference(int[] arr)
        {
            if (arr != null && arr.Length > 0)
            {
                arr[0] = 999; 
                // Änderung am Objekt im Heap -> sichtbar für Aufrufer!
            }
        }

        // 3. ref Keyword
        public void ModifyValueRef(ref int val)
        {
            val = 999;
            // Änderung an der Referenz -> sichtbar für Aufrufer!
        }

        // Swap (Tausch)
        public void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
