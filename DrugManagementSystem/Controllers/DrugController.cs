using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DrugManagementSystem.Entities;
using DrugManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace DrugManagementSystem.Controllers
{
    [Route("api/drug")]
    public class DrugController : ControllerBase
    {
        private readonly DrugContext _drugContext;
        private readonly IMapper _mapper;

        public DrugController(DrugContext drugContext, IMapper mapper)
        {
            _drugContext = drugContext;
            _mapper = mapper;
        }

        [HttpGet("{code}")]
        public ActionResult<Drug> Get(string code)
        {
            var drug = _drugContext.Drugs
                            .FirstOrDefault(x => x.Code.Replace(" ", "-").ToLower() == code.ToLower());

            if (drug == null)
            {
                return NotFound();
            }

            return Ok(drug);
        }

        [HttpGet("filter")]
        public ActionResult<List<DrugModel>> Filter([FromQuery] string filterParam)
        {
            var resultList = new List<DrugModel>();

            if (!string.IsNullOrEmpty(filterParam))
            {
                var drugs = _drugContext.Drugs
                                .Where(x => x.Code.Replace(" ", "-").ToLower().Contains(filterParam.ToLower())
                                    || x.Label.Replace(" ", "-").ToLower().Contains(filterParam.ToLower())
                                )
                                .ToList();

                resultList = _mapper.Map<List<DrugModel>>(drugs);
            }

            return Ok(resultList);
        }

        [HttpPut("{code}")]
        public ActionResult Put(string code, [FromBody] DrugModel model)
        {
            var drug = _drugContext.Drugs
                        .FirstOrDefault(x => x.Code.Replace(" ", "-").ToLower() == code.ToLower());

            if (drug == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            drug.Description = model.Description;
            drug.Label = model.Label;
            drug.Price = model.Price;

            _drugContext.SaveChanges();

            return NoContent();
        }


        [HttpPost]
        public ActionResult Post([FromBody] DrugModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var drug = _mapper.Map<Drug>(model);
            _drugContext.Drugs.Add(drug);
            _drugContext.SaveChanges();

            var key = drug.Code.Replace(" ", "-").ToLower();

            return Created("api/drug/" + key, null);
        }

        [HttpDelete("{code}")]
        public ActionResult Delete(string code)
        {
            var drug = _drugContext.Drugs
                        .FirstOrDefault(x => x.Code.Replace(" ", "-").ToLower() == code.ToLower());

            if (drug == null)
            {
                return NotFound();
            }

            _drugContext.Remove(drug);
            _drugContext.SaveChanges();

            return NoContent();
        }

    }
}
