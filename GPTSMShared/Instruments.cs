namespace GPTSMShared
{
    public static class Instruments
    {
        public static bool ChangeSelectedViaID<T>(string id, ref T selectedValue, List<T> values)
        {
            if (!values.Any() || id == "-1")
            {
                return false;
            }
            if (int.TryParse(id, out int result))
            {
                selectedValue = values[result];
                return true;
            }
            throw new Exception("Provided id is not a number!");
        }
    }
}
