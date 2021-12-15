using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyQuestions.Models
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> Questions { get; }
        void SaveQuestion(Question question);
        Question DeleteQuestion(int questionNo);

    }
}
