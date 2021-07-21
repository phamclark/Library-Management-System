using LibraryBookStore.Models.Catalog;
using LibraryBookStore.Models.Checkin;
using LibraryBookStore.Models.Checkout;
using LibraryBookStore.Models.Hold;
using LibraryUnity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using LibraryService.Interfaces;

namespace LibraryBookStore.Controllers
{
    public class CatalogController : Controller
    {
        protected ILibraryAsset _asset;
        protected ICheckout _checkout;

        public CatalogController(
            ILibraryAsset asset,
            ICheckout checkout)
        {
            _asset = asset;
            _checkout = checkout;
        }
        public async Task<IActionResult> Index()
        {
            var assetModels = await _asset.All();
            var listingResult = assetModels.Select(rs => new AssetIndexListingModel
            {
                Id = rs.Id,
                CoverImageUrl = rs.CoverImageUrl,
                Title = rs.Title,
                Type = _asset.GetType(rs.Id),
                PublishingYear = rs.PublishingYear
            });

            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };
            return View(model);
        }
        public async Task<IActionResult> Detail(Guid Id)
        {
            var asset = await _asset.GetById(Id);

            var currentHolds = _checkout.GetCurrentHolds(asset.Id)
                .Select(x => new AssetHoldModel()
                {
                    PatronName = "",
                    HoldPlaced = x.HoldPlaced
                });
            var model = new AssetDetailModel()
            {
                AssetId = asset.Id,
                Tittle = asset.Title,
                PublishedYear = asset.PublishingYear,
                Cost = asset.Cost,
                Status = asset.Status.Name,
                CoverImage = asset.CoverImageUrl,
                CurrentLocation = asset.Location.Name,
                ISBNCodeImage = $"data:image/Png;base64,{BarCodeConverter(BarcodeGenerator.ISBN(_asset.GetIsbn(asset.Id)))}",
                ISBN = _asset.GetIsbn(asset.Id),
                CurrentHolds = currentHolds,
                LastestCheckout = _checkout.GetLatestCheckout(asset.Id),
                CheckoutHistory = _checkout.GetCheckoutHistories(asset.Id).Result.Data.Results,
                PatronName = _checkout.GetPatronCheckout(asset.Id)
            };
            return View(model);
        }
        
        public IActionResult Checkout(Guid Id)
        {
            var asset = _asset.GetById(Id);
            var model = new CheckoutModel()
            {
                AssetId = Id,
                ImageUrl = asset.Result.CoverImageUrl,
                Title = asset.Result.Title,
                IsCheckedOut = _checkout.IsAssetCheckedOut(Id)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CheckOut(Guid AssetId, Guid LibraryCardId)
        {
            _checkout.CheckOutItem(AssetId, LibraryCardId);
            return RedirectToAction("Detail", new { Id = AssetId });
        }

        public IActionResult CheckIn(Guid AssetId)
        {
            var asset = _asset.GetById(AssetId);
            var model = new CheckinModel()
            {
                AssetId = asset.Result.Id,
                ImageUrl = asset.Result.CoverImageUrl,
                Title = asset.Result.Title
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CheckIn(Guid AssetId, Guid LibraryCardId)
        {
            _checkout.CheckInItem(AssetId, LibraryCardId);
            return RedirectToAction("Detail", new { Id = AssetId });
        }

        public IActionResult Hold(Guid AssetId)
        {
            var asset = _asset.GetById(AssetId);
            var holds = _checkout.GetCurrentHolds(AssetId);
            var model = new HoldModel()
            {
                AssetId = asset.Result.Id,
                ImageUrl = asset.Result.CoverImageUrl,
                Title = asset.Result.Title,
                NumberOfHolds = holds.Count()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Hold(Guid AssetId, Guid LibraryCardId)
        {
            _checkout.PlaceHold(AssetId, LibraryCardId);
            return RedirectToAction("Detail", new { Id = AssetId });
        }

        [HttpPost]
        public IActionResult MarkLost(Guid AssetId)
        {
            _checkout.MarkLost(AssetId);
            return RedirectToAction("Detail", new { Id = AssetId });
        }
        [HttpPost]
        public IActionResult MarkFound(Guid AssetId)
        {
            _checkout.MarkFound(AssetId);
            return RedirectToAction("Detail", new { Id = AssetId });
        }

        protected string BarCodeConverter(Bitmap bImage)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] byteImage = ms.ToArray();
            var SigBase64 = Convert.ToBase64String(byteImage); //Get Base64
            return SigBase64;
        }
    }
}
