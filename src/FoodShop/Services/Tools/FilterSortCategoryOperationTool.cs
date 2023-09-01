using FoodShop.Entities;

namespace FoodShop.Services.Tools
{
    public class FilterSortCategoryOperationTool
    {
        public Sorted sortBy { get; set; }

        public FilterSortCategoryOperationTool(Sorted sortBy)
        {
            this.sortBy = sortBy;
        }

        public List<Category> CategorySortBy(List<Category> listToSort)
        {
            switch (sortBy)
            {
                case Sorted.NONE:
                    return listToSort;

                case Sorted.ASCENDING_ID:
                    return listToSort.OrderBy(s => s.Id).ToList();

                case Sorted.DESCENDING_ID:
                    return listToSort.OrderByDescending(s => s.Id).ToList();

                case Sorted.ASCENDING_NAME:
                    return listToSort.OrderBy(s => s.Name).ToList();

                case Sorted.DESCENDING_NAME:
                    return listToSort.OrderByDescending(s => s.Name).ToList();

                default:
                    return listToSort;

            }
        }
    }
}
