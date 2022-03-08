using ContactControl.Models;
using ContactControl.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class ContactController : Controller
{
    private readonly IContactRepository _contactRepository;
    public ContactController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    public IActionResult Index()
    {
        List<Contact> contacts = _contactRepository.ListAll();
        return View(contacts);
    }
    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Edit(int id)
    {
        Contact contact = _contactRepository.ListId(id);
        return View(contact);
    }

    public IActionResult DeleteVerification(int id)
    {
        Contact contact = _contactRepository.ListId(id);
        return View(contact);
    }

    public IActionResult Delete(int id)
    {
        try
        {
            _contactRepository.Delete(id);
            TempData["SuccessMessage"] = "Contact deleted successfully";
            return RedirectToAction("Index");
        }
        catch (System.Exception error)
        {

            TempData["ErrorMessage"] = $"Hey, could not delete this contact, please try again. Error detail: {error.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Create(Contact contact)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contactRepository.Create(contact);
                TempData["SuccessMessage"] = "Contact created successfully";
                return RedirectToAction("Index");
            }

            return View(contact);
        }
        catch (System.Exception error)
        {
            TempData["ErrorMessage"] = $"Hey, could not create this contact, please try again. Error detail: {error.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Edit(Contact contact)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contactRepository.Edit(contact);
                TempData["SuccessMessage"] = "Contact changed successfully";
                return RedirectToAction("Index");
            }

            return View(contact);
        }
        catch (System.Exception error)
        {

            TempData["ErrorMessage"] = $"Hey, could not change this contact, please try again. Error detail: {error.Message}";
            return RedirectToAction("Index");
        }
    }
}