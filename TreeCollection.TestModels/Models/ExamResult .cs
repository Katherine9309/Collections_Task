using TreeCollection.TestModels.Enums;

namespace TreeCollection.TestModels.Models
{
    public class ExamResult:IComparable<ExamResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exams Exam { get; set; }
        public Score Score { get; set; }
        public DateTime Date { get; set; }

        public ExamResult(int id, string name, Exams exam, Score score, DateTime date)
        {
            Id = id;
            Name = name;
            Exam = exam;
            Score = score;
            Date = date;
            
            
        }

        public int CompareTo(ExamResult other)
        {
            int compareResult = this.Name.CompareTo(other.Name);
            if (compareResult == 0) {
                compareResult = this.Date.CompareTo(other.Date);
                if(compareResult == 0) { 
                    compareResult=this.Id.CompareTo(other.Id);
                }
            }
            return compareResult;
        }
    }
}
