using Blazored.LocalStorage;
using TechShop.Models;

namespace TechShop.Services;

public class CartService
{
    private const string CartKey = "cart";
    private readonly ILocalStorageService _localStorage;
    public List<ProductModel> Items { get; private set; } = new();


    public CartService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    // Event som talar om att carten ändrats
    public event Action? OnChange;

    //Ladda cart vid start
    public async Task LoadAsync()
    {
        Items = await _localStorage.GetItemAsync<List<ProductModel>>(CartKey)
                ?? new List<ProductModel>();
    }

    public async Task AddAsync(ProductModel product)
    {
        Items.Add(product);
        await SaveAsync();
    }
    public void Add(ProductModel product)
    {
        Items.Add(product);

        //Säg till alla lyssnare att något ändrats
        OnChange?.Invoke();
    }

    public decimal TotalPrice =>
        Items.Sum(p => p.Price);

    public void Clear()
    {
        Items.Clear();
        OnChange?.Invoke();
    }

    public async Task ClearAsync()
    {
        Items.Clear();
        await SaveAsync();
    }

    private async Task SaveAsync()
    {
        await _localStorage.SetItemAsync(CartKey, Items);
        OnChange?.Invoke();
    }
}
