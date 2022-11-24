namespace DogSitter.LogicalService
{
    public static class Support
    {
        public static bool CheckTimeOverLaps(DateTime starta,DateTime startb,DateTime enda,DateTime endb)
        {
            //(StartA <= EndB)  and  (EndA >= StartB)
            bool answer =false;
            if (starta <= endb && enda >= startb)
                answer = true;
            return answer;
        }
    }
}
