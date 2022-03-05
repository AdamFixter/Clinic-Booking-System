using Core;
using System.Collections.Generic;

namespace Repository
{
    public abstract class BaseRepository<T> where T : class
    {
        private readonly IUnitOfWork unitOfWork;

        protected BaseRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Insert(T t)
        {
            this.Save(t);
        }
        public IEnumerable<T> GetAll()
        {
            return this.unitOfWork.Session.CreateCriteria(typeof(T)).List<T>();
        }
        public T Get(int ID)
        {
            return this.unitOfWork.Session.Get<T>(ID);
        }
        public void Update(T t)
        {
            this.unitOfWork.Session.SaveOrUpdate(t);
        }
        public void Delete(int ID)
        {
            var data = this.unitOfWork.Session.Get<T>(ID);
            if (data != null)
            {
                this.unitOfWork.Session.Delete(data);
            }
        }
        public void Save(T t)
        {
            this.unitOfWork.Session.Save(t);
        }
    }
}
