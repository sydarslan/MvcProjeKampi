using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ICategoryService
    {
        //burada yapılacak işlemleri tanımla CategoryManager kısmında işlemlerin içini doldur
        List<Category> GetCategoryList();
        void CategoryAdd(Category category);
        Category GetById(int id);
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
        
    }
}
