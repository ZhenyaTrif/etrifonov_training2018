namespace Task6_inheritance
{
    class Teacher : Man, IGetExperience
    {
        private int WorkExperience { get; set; }
        private string Education { get; set; }

        public Teacher(string name, string gender, int age = 23, int weight = 70) : base(name, gender, age, weight)
        {
            WorkExperience = 0;
            Education = "Higher education";
        }

        public Teacher(string name, string gender, string education, int age = 23, int weight = 70) : base(name, gender, age, weight)
        {
            WorkExperience = 0;
            Education = education;
        }

        public void ChangeWorkExperience(int year)
        {
            WorkExperience = year;
        }

        public void GetExperience()
        {
            WorkExperience++;
        }
    }
}
