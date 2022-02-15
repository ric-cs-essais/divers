using System.Collections.Generic;


namespace Infrastructure.Persistence.Database.Common.Abstracts
{
    public abstract class AConfigItemsList<T>
    {
        protected Dictionary<int, T> _oList;

        protected int _iDefaultId = 0;

        public AConfigItemsList()
        {
            this._oList = new Dictionary<int, T>();
            this._fillList();
        }

        protected abstract void _fillList();

        public T getDefault()
        {
            T retour = this.getById(this._iDefaultId);

            return (retour);

        }

        public T getById(int piId)
        {
            T retour;

            try
            {
                retour = this._oList[piId];
            }
            catch (KeyNotFoundException)
            {
                throw new System.Exception("La liste des éléments de config. ne contient pas d'élément pour la clef "+piId+".\n");
            }

            return (retour);

        }

    }
}
