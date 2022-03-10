/*
Author: Engin Yenice
Github: github.com/enginyenice
Website: enginyenice.com
*/

namespace EntityFramework.Core.Persistence.Repositories
{
    public class Entity
    {
        #region Constructors

        public Entity()
        {
        }

        public Entity(int id) : this()
        {
            Id = id;
        }

        #endregion Constructors

        #region Properties

        public int Id { get; set; }

        #endregion Properties
    }
}