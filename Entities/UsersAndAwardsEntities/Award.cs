using System.Collections.Generic;

namespace UsersAndAwardsEntities
{
    public class Award
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public List<User> Users { get; set; }
        
        public Award(int id, string title)
        {
            this.ID = id;
            this.Title = title;
        }

        public Award(string title)
        {
            this.Title = title;
        }

        public override string ToString()
        {
            return $"{ID} {Title}";
        }
    }
}