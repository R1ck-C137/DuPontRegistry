using DuPontRegistry.BusinessLogic;

namespace DuPontRegistry.Service
{
    public class CarFilterService : ICarFilters
    {
        // private void FillingFiltersValue()
        // {
        //     CarFilters.Brands = _carList.Select(x => x.Value.Make).Distinct().ToList(); //TODO: наверное нужно сделать ещё одну сущьность (модель) кот
        //
        //     foreach (var brand in CarFiltersValue.Brands)
        //     {
        //         var model = _carList.Where(car => car.Value.Make == brand.ToString())
        //             .Select(car => car.Value.Model).Distinct()
        //             .ToList();
        //         CarFiltersValue.Models.Add(new JObject { { "Brand", brand.ToString() }, { "Values", new JArray(model) } });
        //     }
        //
        //     CarFiltersValue.ModelYearFrom = (int)_carList
        //         .Where(car => car.Value.Modelyear.HasValue && car.Value.Modelyear > 1900)
        //         .OrderBy(car => car.Value.Modelyear)
        //         .FirstOrDefault().Value.Modelyear!;
        //
        //     CarFiltersValue.DealersName = _carList.Select(car => car.Value.DealerName).Distinct().ToList();
        // }
    }
}
