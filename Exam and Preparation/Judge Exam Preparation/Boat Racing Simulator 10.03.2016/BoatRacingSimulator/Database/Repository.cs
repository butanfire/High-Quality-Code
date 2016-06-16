namespace BoatRacingSimulator.Database
{
    using System.Collections.Generic;
    using Exceptions;
    using Interfaces;
    using Utility;

    public class Repository<T> : IRepository<T> where T : IModelable
    {
        public Repository()
        {
            ItemsByModel = new Dictionary<string, T>();
        }

        protected Dictionary<string, T> ItemsByModel { get; set; }

        public virtual void Add(T item)
        {            
            if (ItemsByModel.ContainsKey(item.Model))
            {
                throw new DuplicateModelException(Constants.DuplicateModelMessage);
            }

            ItemsByModel[item.Model] = item;
        }

        public virtual T GetItem(string model)
        {
            if (!ItemsByModel.ContainsKey(model))
            {
                throw new NonExistantModelException(Constants.NonExistantModelMessage);
            }

            return ItemsByModel[model];
        }
    }
}
