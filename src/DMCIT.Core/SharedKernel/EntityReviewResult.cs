using System.Collections.Generic;

namespace DMCIT.Core.SharedKernel
{
    public class EntityPropertyReviewResult
    {
        public enum EntityPropertyReviewResultType { ERROR, WARNING, INFO };
        public string Key { get; set; }
        public string Message { get; set; }
        public EntityPropertyReviewResultType ResultType { get; set; }
    }

    public class EntityReviewResult
    {
        public List<EntityPropertyReviewResult> Result = new List<EntityPropertyReviewResult>();

        public void AddError(string key, string message)
        {
            var item = new EntityPropertyReviewResult
            {
                Message = message,
                Key = key,
                ResultType = EntityPropertyReviewResult.EntityPropertyReviewResultType.ERROR
            };
            Result.Add(item);
        }

        public void AddWarning(string key, string message)
        {
            var item = new EntityPropertyReviewResult
            {
                Message = message,
                Key = key,
                ResultType = EntityPropertyReviewResult.EntityPropertyReviewResultType.WARNING
            };
            Result.Add(item);
        }

        public void AddInfo(string key, string message)
        {
            var item = new EntityPropertyReviewResult
            {
                Message = message,
                Key = key,
                ResultType = EntityPropertyReviewResult.EntityPropertyReviewResultType.INFO
            };
            Result.Add(item);
        }
    }

    public class EntityReviewResult<T>
    {
        public EntityReviewResult Result { get; set; }
        public T Entity { get; set; }

        public EntityReviewResult(T entity, EntityReviewResult result)
        {
            Result = result;
            Entity = entity;
        }
    }
}
