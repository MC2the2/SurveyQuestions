using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyQuestions.Models
{
    public class EFQuestionRepository : IQuestionRepository
    {
        private ApplicationDbContext context;
        public EFQuestionRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Question> Questions => context.Questions;

        public void SaveQuestion(Question question)
        {
            if (question.QuestionNum == 0)
            {
                context.Questions.Add(question);
                
            }
            else
            {
                Question dbEntry = context.Questions
                .FirstOrDefault(p => p.QuestionNum== question.QuestionNum);
                if (dbEntry != null)
                {
                    dbEntry.DomainNum = question.DomainNum;
                    dbEntry.Prompt = question.Prompt;
                }
            }
            context.SaveChanges();
        }

        public Question DeleteQuestion(int QuestionNo)
        {
            Question dbEntry = context.Questions
            .FirstOrDefault(p => p.QuestionNum == QuestionNo);
            if (dbEntry != null)
            {
                context.Questions.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


    }
}
