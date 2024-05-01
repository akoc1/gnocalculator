namespace OgrenciOrtalamasi.Models
{
    public class Student
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();

        private double _gno { get; set; }
        public double GNO
        {
            get
            {
                double output = 0D, credits = 0D, katki = 0D;

                foreach(Lesson lesson in Lessons)
                {
                    katki += lesson.Average * lesson.AKTSCredit;
                    credits += lesson.AKTSCredit;
                }

                output = katki / credits;

                _gno = output;

                return _gno;
            }
            private set
            {
                _gno = value;
            }
        }

        public override string ToString()
        {
            string output = string.Empty;

            foreach(Lesson lesson in Lessons)
            {
                output += $"{FirstName} {LastName} ogrencisinin {lesson.Name} dersinin vize notu: {lesson.VisaScore}";
                output += $"\n{FirstName} {LastName} ogrencisinin {lesson.Name} dersinin final notu: {lesson.FinalScore}";
            }

            return output;
        }
    }
}
