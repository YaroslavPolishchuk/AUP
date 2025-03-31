using DB_Layer.Abstract;
using DB_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace AUP.Controllers
{
    public class MenuController:Controller
    {
        IDataRepository _postDataRepository;
        IRepository<AddressInfo> _aupRepository;
        IRepository<DistModel> _disRepository;
        int pageSize = 20;

        public MenuController(IDataRepository postDataRepository,
            IRepository<AddressInfo> aupRepository,
            IRepository<DistModel> disRepository)
        {
            _postDataRepository = postDataRepository;
            _aupRepository = aupRepository;
            _disRepository = disRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FillAUP()
        {
            var result=_postDataRepository.UploadData();
            ViewBag.result=result;
            return View("UploadAUP");
        }

        public IActionResult ShowIndexesNoCity(int? page)
        {
            ViewBag.Message = "Показати iндекси для яких не знайдено мiсто";
            int pageNumber = (page ?? 1);
            var result = _aupRepository.GetAll()
                            .Where(a => a.City == null)
                            .Take(500);
            var pagedList = result.ToPagedList(pageNumber, pageSize);
            ViewBag.pagedList = pagedList;
            ViewBag.Any = pagedList.Any();
            return View("AUPView(noCity)");
        }

        public IActionResult ShowIndexesNoRAJ(int? page)
        {
            ViewBag.Message = "Показати iндекси для яких не знайдено район";
            int pageNumber = (page ?? 1);
            var result = _aupRepository.GetAll()
                            .Where(a => a.Raj == null);
            var pagedList = result.ToPagedList(pageNumber, pageSize);
            ViewBag.pagedList = pagedList;
            ViewBag.Any = pagedList.Any();
            return View("AUPView(noDist)");
        }

        public IActionResult ShowIndexesNoOBL(int? page)
        {
            ViewBag.Message = "Показати iндекси для яких не знайдено область";
            int pageNumber = (page ?? 1);
            var result = _aupRepository.GetAll()
                            .Where(a => a.Obl == null);
            var pagedList = result.ToPagedList(pageNumber, pageSize);
            ViewBag.pagedList = pagedList;
            ViewBag.Any = pagedList.Any();
            return View("AUPView(NoObl)");
        }
        public IActionResult ShowAUP(int? page)
        {
            ViewBag.Message = "Показати адреси укрпошти";
            int pageNumber = (page ?? 1);
            var result = _aupRepository.GetAll();
            var pagedList = result.ToPagedList(pageNumber, pageSize);                        
            ViewBag.pagedList = pagedList;            
            ViewBag.Any = pagedList.Any();
            return View("AUPView");
        }
    }
}
