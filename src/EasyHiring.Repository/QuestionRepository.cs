using EasyHiring.Domain.Entities;
using EasyHiring.Repository.Abstract;
using Microsoft.Extensions.Options;

namespace EasyHiring.Repository;

public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
{
    public QuestionRepository(IOptions<MongoDbSettings> options) : base(options)
    {
    }
}