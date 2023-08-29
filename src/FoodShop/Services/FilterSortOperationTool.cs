using FoodShop.Entities;

namespace FoodShop.Services
{
    public class FilterSortOperationTool
    {

        public List<Category> CategorySortBy(Sorted sortBy, List<Category> listToSort)
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

        public List<Product> ProductSortBy(Sorted sortBy, List<Product> listToSort)
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

                case Sorted.ASCENDING_PRICE:
                    return listToSort.OrderBy(s => s.Price).ToList();

                case Sorted.DESCENDING_PRICE:
                    return listToSort.OrderByDescending(s => s.Price).ToList();

                default:
                    return listToSort;

            }
        }
    }
}
