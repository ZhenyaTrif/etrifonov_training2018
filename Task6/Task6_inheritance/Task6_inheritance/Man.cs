namespace Task6_inheritance
{
    class Man
    {
        private string Name { get; set; }
        private int Age { get; set; }
        private string Gender { get; set; }
        private int Weight { get; set; }

        public Man(string name, string gender)
        {
            Name = name;
            Age = 0;
            Gender = gender;
            Weight = 3;
        }

        public Man(string name, string gender, int age, int weight): this(name, gender)
        {
            Age = age;
            Weight = weight;
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }

        public void ChangeAge(int newAge)
        {
            Age = newAge;
        }

        public void ChangeWeight(int newWeight)
        {
            Weight = newWeight;
        }
    }
}
