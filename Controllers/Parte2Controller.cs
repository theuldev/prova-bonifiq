﻿using Microsoft.AspNetCore.Mvc;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{
	
	[ApiController]
	[Route("[controller]")]
	public class Parte2Controller :  ControllerBase
	{
		/// <summary>
		/// Precisamos fazer algumas alterações:
		/// 1 - Não importa qual page é informada, sempre são retornados os mesmos resultados. Faça a correção.
		/// 2 - Altere os códigos abaixo para evitar o uso de "new", como em "new ProductService()". Utilize a Injeção de Dependência para resolver esse problema
		/// 3 - Dê uma olhada nos arquivos /Models/CustomerList e /Models/ProductList. Veja que há uma estrutura que se repete. 
		/// Como você faria pra criar uma estrutura melhor, com menos repetição de código? E quanto ao CustomerService/ProductService. Você acha que seria possível evitar a repetição de código?
		/// 
		/// </summary>
		private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        public Parte2Controller(IProductService productService, ICustomerService customerService)
        {
			_productService = productService;
			_customerService = customerService;
        }

        [HttpGet("products")]
		public PaginatedList<Product> ListProducts(int page)
		{
			return _productService.ListProducts(page);
		}

		[HttpGet("customers")]
		public PaginatedList<Customer> ListCustomers(int page)
		{
			return _customerService.ListCustomers(page);
		}
	}
}
