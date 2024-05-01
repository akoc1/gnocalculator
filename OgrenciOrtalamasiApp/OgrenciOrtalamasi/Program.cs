using OgrenciOrtalamasi.Models;

namespace OgrenciOrtalamasi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Lesson> lessons = new List<Lesson>();
            List<Student> students = new List<Student>();

            lessons.Add(new Lesson { Name = "Atatürk İlk. ve İnk. Tarihi - I", AKTSCredit = 2, Coefficient = 2 });
            lessons.Add(new Lesson { Name = "Matematik - I", AKTSCredit = 4, Coefficient = 5 });
            lessons.Add(new Lesson { Name = "Mühendislik Fiziği", AKTSCredit = 3, Coefficient = 2 });
            lessons.Add(new Lesson { Name = "Bilgisayar Mühendisligine Giris", AKTSCredit = 4, Coefficient = 2 });
            lessons.Add(new Lesson { Name = "Algoritma ve Programlama - I", AKTSCredit = 4, Coefficient = 2 });
            lessons.Add(new Lesson { Name = "Algoritma ve Programlama Laboratuvari - I", AKTSCredit = 2, Coefficient = 1 });
            lessons.Add(new Lesson { Name = "Dijital Okuryazarlik", AKTSCredit = 2, Coefficient = 3 });
            lessons.Add(new Lesson { Name = "Türk Dili - I", AKTSCredit = 4, Coefficient = 2 });
            lessons.Add(new Lesson { Name = "Yabanci Dil - I", AKTSCredit = 5, Coefficient = 2.5 });

            students.Add(new Student { FirstName = "Emre", LastName = "Yildirim" });
            students.Add(new Student { FirstName = "Hakan", LastName = "Mantar" });

            GetScoresFromStudent(lessons, students);

            Console.Clear();

            PrintResults(students);

            Console.ReadLine();
        }

        private static void GetScoresFromStudent(List<Lesson> lessons, List<Student> students)
        {
            foreach (Student student in students)
            {
                foreach (Lesson lesson in lessons)
                {
                    Lesson studentLesson = new Lesson
                    {
                        Name = lesson.Name,
                        AKTSCredit = lesson.AKTSCredit,
                    };

                    studentLesson.VisaScore = GetScoreFromUser($"{student.FirstName} adlı öğrencinin {lesson.Name} dersinin vize notu: ");
                    studentLesson.FinalScore = GetScoreFromUser($"{student.FirstName} adlı öğrencinin {lesson.Name} dersinin final notu: ");

                    if (studentLesson.Average < 40)
                        studentLesson.MakeUpScore = GetScoreFromUser($"{student.FirstName} adlı öğrencinin {lesson.Name} dersinin bütünleme notu: ");

                    student.Lessons.Add(studentLesson);
                }

                Console.WriteLine();
            }
        }

        private static void PrintResults(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} adli ogrencinin GNO'su: {(float)student.GNO / 25}");

                foreach (Lesson lesson in student.Lessons)
                {
                    Console.WriteLine($"{lesson.Name} dersinin:\nOrtalamasi = {(float)lesson.Average}\nHarf notu = '{CalculateLetterScore(lesson.Average)}' dersten {PassedOrNot(lesson.Average)}\n");
                }

                Console.WriteLine();
            }

            Student bestStudent = GetBestStudent(students);

            Console.WriteLine($"Ortalamasi en iyi olan ogrenci: {bestStudent.FirstName} {bestStudent.LastName}");
        }

        private static Student GetBestStudent(List<Student> students)
        {
            return students.OrderByDescending(p => p.GNO).FirstOrDefault();
        }

        private static double GetScoreFromUser(string message)
        {
            Console.Write(message);
            double output = double.Parse(Console.ReadLine());
            return output;
        }

        private static string CalculateLetterScore(double score)
        {
            if (score >= 90) return "AA";
            if (score >= 80) return "BA";
            if (score >= 70) return "BB";
            if (score >= 60) return "CB";
            if (score >= 50) return "CC";
            if (score >= 45) return "DC";
            if (score >= 40) return "DD";
            if (score >= 30) return "FD";

            return "FF";
        }

        private static string PassedOrNot(double score)
        {
            switch (score)
            {
                case <= 39:
                    return "Kaldi";
                default:
                    return "Gecti";
            }
        }
    }
}
