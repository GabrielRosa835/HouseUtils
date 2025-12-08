using HouseUtils.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HouseUtils.PresentationMVC.Controllers;

public class TagsController : Controller
{
   private readonly List<Tag> data = [];


   // GET: /Tags (Full Page Load)
   public IActionResult Index ()
   {
      return View(data);
   }

   // GET: /Tags/CreateRow (Returns the empty form row)
   public IActionResult CreateRow ()
   {
      return PartialView("_TagForm", new Tag { Name = "" });
   }

   // POST: /Tags/Create
   [HttpPost]
   public IActionResult Create (Tag model)
   {
      if (!ModelState.IsValid) return PartialView("_TagForm", model);

      data.Add(model);

      // Return the new read-only row to append to the table
      return PartialView("_TagRow", model);
   }

   // GET: /Tags/Edit/5 (Swaps the read-only row with a form)
   public IActionResult Edit (int id)
   {
      var tag = data.FirstOrDefault(t => t.Id == id);
      return PartialView("_TagForm", tag);
   }

   // POST: /Tags/Update/5
   [HttpPost]
   public IActionResult Update (Tag model)
   {
      if (!ModelState.IsValid) return PartialView("_TagForm", model);

      var tag = data.FirstOrDefault(t => t.Id == model.Id);
      if (tag is not null) 
      {
         tag.Name = model.Name;
         tag.Description = model.Description;
      }

      // Swap the form back to the read-only row
      return PartialView("_TagRow", model);
   }

   // DELETE: /Tags/Delete/5
   [HttpDelete]
   public IActionResult Delete (int id)
   {
      var tag = data.FirstOrDefault(t => t.Id == id);
      if (tag is not null)
      {
         data.Remove(tag);
      }
      // Return empty content to remove the element from DOM
      return Ok();
   }

   // GET: /Tags/Cancel/5 (Cancel edit, revert to row)
   public IActionResult Cancel (int id)
   {
      var tag = data.FirstOrDefault(t => t.Id == id);
      return PartialView("_TagRow", tag);
   }
}