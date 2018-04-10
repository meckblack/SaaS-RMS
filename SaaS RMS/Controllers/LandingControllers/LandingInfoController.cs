﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SaaS_RMS.Data;
using SaaS_RMS.Models.Enities.Landing;
using SaaS_RMS.Models.Enums;

namespace SaaS_RMS.Controllers.LandingControllers
{
    public class LandingInfoController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _environment;

        #region Constructor

        public LandingInfoController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _db = context;
            _environment = environment;
        }

        #endregion

        #region Index

        public async Task<IActionResult> Index()
        {
            var landingInfo = await _db.LandingInfo.ToListAsync();
            return View(landingInfo);
        }

        #endregion

        #region Create

        //GET: LandingInfo/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Approval = new SelectList(Enum.GetValues(typeof(ApprovalEnum)));
            return View();
        }

        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LandingInfo landingInfo, IFormFile file, UploadType uploadType)
        {
            if (file == null || file.Length == 0)
            {
                ViewData["null_image"] = "Please select an image";
            }
            else
            {
                var fileinfo = new FileInfo(file.FileName);
                var filename = DateTime.Now.ToFileTime() + fileinfo.Extension;
                var uploads = Path.Combine(_environment.WebRootPath, "uploads" + uploadType);
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, filename), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }

                if (ModelState.IsValid)
                {
                    var allLandingInfo = await _db.LandingInfo.ToListAsync();

                    if (allLandingInfo.Any(l => l.Approval == ApprovalEnum.Apply && landingInfo.Approval == ApprovalEnum.Apply))
                    {
                        TempData["landinginfo"] = "The Landing information wasn't added because another Landing Information is already applied!!! " +
                            "Try chaning the Approval field to Neglect";
                        TempData["notificationType"] = NotificationType.Error.ToString();
                        return RedirectToAction("Index");
                    }

                    landingInfo.Image = filename;
                    await _db.AddAsync(landingInfo);
                    await _db.SaveChangesAsync();

                    TempData["landinginfo"] = "You have successfully added a new Landing Information!!!";
                    TempData["notificationType"] = NotificationType.Success.ToString();

                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Edit

        //GET: LandingInfo/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landingInfo = await _db.LandingInfo.SingleOrDefaultAsync(l => l.LandingInfoId == id);

            if (landingInfo == null)
            {
                return NotFound();
            }

            ViewBag.Approval = new SelectList(Enum.GetValues(typeof(ApprovalEnum)));
            return View(landingInfo);
        }

        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, LandingInfo landingInfo, IFormFile file, UploadType uploadType)
        {
            if(id != landingInfo.LandingInfoId)
            {
                return NotFound();
            }

            if (file == null || file.Length == 0)
            {
                ViewData["null_image"] = "Please select an image";
            }

            else
            {
                var fileinfo = new FileInfo(file.FileName);
                var filename = DateTime.Now.ToFileTime() + fileinfo.Extension;
                var uploads = Path.Combine(_environment.WebRootPath, "uploads" + uploadType);
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, filename), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }

                if (ModelState.IsValid)
                {
                    var allLandingInfo = await _db.LandingInfo.ToListAsync();

                    if (allLandingInfo.Any(l => l.Approval == ApprovalEnum.Apply && landingInfo.Approval == ApprovalEnum.Apply
                                            || landingInfo.Approval == ApprovalEnum.Neglect && allLandingInfo.ToArray().Length > 1))
                    {
                        TempData["landinginfo"] = "The Landing information wasn't modified because another Landing Information is already applied!!! " +
                            "Try chaning the Approval field to Neglect";
                        TempData["notificationType"] = NotificationType.Error.ToString();
                        return RedirectToAction("Index");
                    }
                    
                    landingInfo.Image = filename;
                    _db.Update(landingInfo);
                    await _db.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete

        //GET: LandingInfo/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var landingInfo = await _db.LandingInfo.SingleOrDefaultAsync(b => b.LandingInfoId == id);

            if (landingInfo == null)
            {
                return NotFound();
            }

            return PartialView("Delete", landingInfo);
        }

        //POST:
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var landingInfo = await _db.LandingInfo.SingleOrDefaultAsync(b => b.LandingInfoId == id);

            if (landingInfo.Approval == ApprovalEnum.Apply)
            {
                TempData["landingInfo"] = "You cannot delete this Landing Information because it is currently been applied. " +
                    "Apply another Landing Information before you delete!!!";
                TempData["notificationType"] = NotificationType.Info.ToString();

                return Json(new { success = true });
            }

            if (landingInfo != null)
            {
                _db.LandingInfo.Remove(landingInfo);    
                await _db.SaveChangesAsync();

                TempData["landingInfo"] = "You have successfully deleted a Landing Information!!!";
                TempData["notificationType"] = NotificationType.Success.ToString();

                return Json(new { success = true });
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region LandingInfo Exists

        private bool LandingInfoExists(int id)
        {
            return _db.LandingInfo.Any(b => b.LandingInfoId == id);
        }

        #endregion

    }
}