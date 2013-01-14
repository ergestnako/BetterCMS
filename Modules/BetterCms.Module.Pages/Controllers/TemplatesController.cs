﻿using System.Web.Mvc;

using BetterCms.Module.Pages.Command.Layout.DeleteTemplate;
using BetterCms.Module.Pages.Command.Layout.GetSiteSettingsTemplates;
using BetterCms.Module.Pages.Command.Layout.GetTemplatesForEdit;
using BetterCms.Module.Pages.Command.Layout.SaveTemplate;
using BetterCms.Module.Pages.Command.Widget.DeleteWidget;
using BetterCms.Module.Pages.Content.Resources;
using BetterCms.Module.Pages.ViewModels.Templates;
using BetterCms.Module.Root.Models;
using BetterCms.Module.Root.Mvc;
using BetterCms.Module.Root.Mvc.Grids.GridOptions;

namespace BetterCms.Module.Pages.Controllers
{
    public class TemplatesController : CmsControllerBase
    {
        /// <summary>
        /// Deletes template.
        /// </summary>
        /// <param name="id">The template id.</param>
        /// <param name="version">The version.</param>
        /// <returns>
        /// Json with result status.
        /// </returns>
        [HttpPost]
        public ActionResult DeleteTemplate(string id, string version)
        {
            var request = new DeleteTemplateCommandRequest
            {
                TemplateId = id.ToGuidOrDefault(),
                Version = version.ToIntOrDefault()
            };
            if (GetCommand<DeleteTemplateCommand>().ExecuteCommand(request))
            {
                Messages.AddSuccess(PagesGlobalization.DeleteTemplate_DeletedSuccessfully_Message);
                return Json(new WireJson
                {
                    Success = true
                });
            }
            return Json(new WireJson { Success = false });
        }
    

        /// <summary>
        /// Creates modal dialog for creating a new template.
        /// </summary>
        /// <returns>
        /// ViewResult to render new template modal dialog.
        /// </returns>
        [HttpGet]
        public ActionResult RegisterTemplate()
        {
            var model = GetCommand<GetTemplatesForEditCommand>().ExecuteCommand(null);
            return PartialView("EditTemplate", model);
        }

        /// <summary>
        /// Validates and saves template.
        /// </summary>
        /// <param name="model">The template view model.</param>
        /// <returns>
        /// Json with result status.
        /// </returns>
        [HttpPost]
        public ActionResult RegisterTemplate(TemplateEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = GetCommand<SaveTemplateCommand>().ExecuteCommand(model);
                if (response != null)
                {
                    if (model.Id.HasDefaultValue())
                    {
                        Messages.AddSuccess(PagesGlobalization.SaveTemplate_CreatedSuccessfully_Message);
                    }
                    return Json(new WireJson { Success = true, Data = response });
                }
            }

            return Json(new WireJson { Success = false });
        }

        /// <summary>
        /// Creates modal dialog for edit a template.
        /// </summary>
        /// <returns>
        /// ViewResult to render editing tempate modal dialog.
        /// </returns>
        [HttpGet]
        public ActionResult EditTemplate(string id)
        {
            var model = GetCommand<GetTemplatesForEditCommand>().ExecuteCommand(id.ToGuidOrDefault());
            return PartialView(model);
        }

        public ActionResult SaveTemplateRegions(TemplateRegionItemViewModel model)
        {
            return Json(new WireJson { Success = false });
        }

        /// <summary>
        /// Renders a templates list for the site settings dialog.
        /// </summary>
        /// <returns>Rendered templates list.</returns>
        public ActionResult Templates(SearchableGridOptions request)
        {
            var model = GetCommand<GetSiteSettingsTemplatesCommand>().ExecuteCommand(request);
            
            return View(model);
        }
    }
}