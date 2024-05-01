namespace OgrenciOrtalamasi.Models
{
    public class Lesson
    {
        public string Name { get; set; }
        public double VisaScore { get; set; }
        public double FinalScore { get; set; }
        public double MakeUpScore { get; set; }

        private double _avg;

        public double Average
        {
            get
            {
                double output = (VisaScore * 40 / 100) + (FinalScore * 60 / 100);

                if (output < 40)
                    output = (VisaScore * 40 / 100) + (MakeUpScore * 60 / 100);

                _avg = output;

                return _avg;
            }
            set
            {
                _avg = value;
            }
        }

        public double Coefficient { get; set; }
        public double AKTSCredit { get; set; }
    }
}
