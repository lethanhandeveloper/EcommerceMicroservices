using EcommerceWebApi.Dto;
using EcommerceWebApi.Dtos;
using EcommerceWebApi.Entities;
using EcommerceWebApi.Entity;
using EcommerceWebApi.Repository;
using EcommerceWebApi.Services;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebApi.Controllers
{
    public class TestController : ApiController
    {
        public readonly SingletonService singletonService;

        public readonly ScopeService scopeService1;
        public readonly ScopeService scopeService2;


        public readonly TransientService transientService1;
        public readonly TransientService transientService2;

        public TestController(SingletonService singletonService, ScopeService scopeService1, ScopeService scopeService2, TransientService transientService1, TransientService transientService2)
        {
            this.singletonService = singletonService;
            this.scopeService1 = scopeService1;
            this.scopeService2 = scopeService2;
            this.transientService1 = transientService1;
            this.transientService2 = transientService2;
        }

        [HttpPost("singleton")]
        public string GetSingletonAll()
        {
            return singletonService.value;
        }

        [HttpPost("scope")]
        public string GetScopeAll()
        {
            return scopeService1.value + scopeService2.value;
        }

        [HttpPost("transient")]
        public string GetTransientAll()
        {
            return transientService1.value + transientService2.value;
        }
    }
}
