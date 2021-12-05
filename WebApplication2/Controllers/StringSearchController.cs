﻿using System.Linq;
using AutoMapper;
using EfEx;
using EfEx.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebService.ViewModels;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;


namespace WebService.Controllers
{
    [ApiController]
    [Route("api/StringSearch")]
    public class StringSearchController : Controller

    { 
        private readonly IDataService _dataService;
        private readonly LinkGenerator _linkGenerator;
        private readonly IMapper _mapper;


        public StringSearchController(IDataService dataService, LinkGenerator linkGenerator, IMapper mapper)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpGet("{s}", Name = nameof(StringSearch))]

        public IActionResult StringSearch(string s)
        {
            var stringSearch = _dataService.StringSearch(s);
            if (stringSearch == null)
            {
                return NotFound();
            }
            return Ok(stringSearch.Select(CreateStringSearchViewModel));
        }

        private StringSearchViewModel CreateStringSearchViewModel(StringSearch stringSearch)
        {
            var model = _mapper.Map<StringSearchViewModel>(stringSearch);
            model.Url = GetUrl(stringSearch);
            model.Tconst = stringSearch.Tconst;
            model.Title = stringSearch.Title;
            return model;
        }
        private string GetUrl(StringSearch stringSearch)
        {
            return _linkGenerator.GetUriByName(HttpContext, nameof(StringSearch), new { stringSearch.Tconst });
        }
    }



}
