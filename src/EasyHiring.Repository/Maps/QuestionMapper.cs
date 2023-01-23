using EasyHiring.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace EasyHiring.Repository.Maps;

public class QuestionMapper : MongoDbClassMap<Question>
{
    public override void Map(BsonClassMap<Question> cm)
    {
        cm.AutoMap();
        cm.SetIgnoreExtraElements(true);
    }
}