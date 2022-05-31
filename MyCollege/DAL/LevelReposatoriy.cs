using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DataModels;

namespace DAL
{
    interface ILevelReposatoriy
    {
        IEnumerable<LevelViewModel> DropdownlistLevel();
    }
   public class LevelReposatoriy: ILevelReposatoriy
    {
        MyCollegeEntities context = new MyCollegeEntities();
        //Dropdownlist level in a page
        public IEnumerable<LevelViewModel> DropdownlistLevel()
        {
            List<LevelViewModel> levels = new List<LevelViewModel>();
            foreach (var item in context.Levels)
            {
                LevelViewModel obj = new LevelViewModel();
                obj.id = item.id;
                obj.level1 = item.level1;
                levels.Add(obj);
            }
            return levels;
        }
    }
}
