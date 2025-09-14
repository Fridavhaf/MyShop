
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShop.ViewModels;

namespace MyShop.Controllers;

public class ItemController : Controller
{
    private readonly ItemDbContext _itemDbContext;
    public ItemController(ItemDbContext itemDbContext)
    {
        _itemDbContext = itemDbContext;
    }

    // async/await makes database access asynchronous.
    // This means the thread is not blocked while waiting for the database,
    // and can handle other requests until the query finishes.

    public async Task<IActionResult> Table()
    {
        List<Item> items = await _itemDbContext.Items.ToListAsync();
        var itemsViewModel = new ItemsViewModel(items, "Table");
        return View(itemsViewModel);
    }

    public async Task<IActionResult> Grid()
    {
        List<Item> items = await _itemDbContext.Items.ToListAsync();
        var itemsViewModel = new ItemsViewModel(items, "Grid");
        return View(itemsViewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        var item = await _itemDbContext.Items.FirstOrDefaultAsync(i => i.ItemId == id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpGet]
    public IActionResult Create()
    {
        // This method does not access the database, so it does not need to be async.
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Item item)
    {
        if (ModelState.IsValid)
        {
            _itemDbContext.Items.Add(item);
            await _itemDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Table));
        }
        return View(item);
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var item = await _itemDbContext.Items.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Item item)
    {
        if (ModelState.IsValid)
        {
            _itemDbContext.Items.Update(item);
            await _itemDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Table));
        }
        return View(item);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _itemDbContext.Items.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _itemDbContext.Items.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            _itemDbContext.Items.Remove(item);
            _itemDbContext.SaveChanges();
            return RedirectToAction(nameof(Table));
        }
        return View(item);
    }
}
