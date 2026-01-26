namespace StaticApp
{
    public class Entity
    {
        // Statisches Feld: Wird von allen Instanzen geteilt.
        private static int _instanceCount = 0;

        public Entity()
        {
            // Bei jeder Instanziierung erhöhen wir den Zähler
            _instanceCount++;
        }

        public static int GetCount()
        {
            return _instanceCount;
        }
        
        /// <summary>
        /// Resets the counter. Useful for testing isolation.
        /// </summary>
        public static void ResetCount()
        {
            _instanceCount = 0;
        }
    }
}
