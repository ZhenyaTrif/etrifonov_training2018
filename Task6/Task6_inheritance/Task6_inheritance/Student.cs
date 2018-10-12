namespace Task6_inheritance
{
    class Student : Man, IGetExperience
    {
        private int YearInUniversity { get; set; }

        public Student(string name, string gender, int age = 17, int weight = 65): base(name, gender, age, weight)
        {
            YearInUniversity = 0;
        }

        public void ChangeYearInUniversity(int year)
        {
            YearInUniversity = year;
        }

        public void GetExperience()
        {
            YearInUniversity++;
        }
    }
}
