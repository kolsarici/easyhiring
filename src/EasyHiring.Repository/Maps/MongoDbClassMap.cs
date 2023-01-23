using MongoDB.Bson.Serialization;

namespace EasyHiring.Repository.Maps;

public abstract class MongoDbClassMap<T>
{
    protected MongoDbClassMap()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
            BsonClassMap.RegisterClassMap<T>(Map);
    }

    public abstract void Map(BsonClassMap<T> cm);
}